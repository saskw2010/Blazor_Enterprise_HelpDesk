using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;




namespace Cpdhelpdesk.Controllers.Authenticationconn
{
  using Models;
  using Data;
  using Models.Authenticationconn;

  [Route("odata/authenticationconn/TblPages")]
  public partial class TblPagesController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public TblPagesController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/TblPages
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.TblPage> GetTblPages()
    {
      var items = this.context.TblPages.AsQueryable<Models.Authenticationconn.TblPage>();
      this.OnTblPagesRead(ref items);

      return items;
    }

    partial void OnTblPagesRead(ref IQueryable<Models.Authenticationconn.TblPage> items);

    partial void OnTblPageGet(ref SingleResult<Models.Authenticationconn.TblPage> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/TblPages(id={id})")]
    public SingleResult<TblPage> GetTblPage(int key)
    {
        var items = this.context.TblPages.Where(i=>i.id == key);
        var result = SingleResult.Create(items);

        OnTblPageGet(ref result);

        return result;
    }
    partial void OnTblPageDeleted(Models.Authenticationconn.TblPage item);
    partial void OnAfterTblPageDeleted(Models.Authenticationconn.TblPage item);

    [HttpDelete("/odata/authenticationconn/TblPages(id={id})")]
    public IActionResult DeleteTblPage(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.TblPages
                .Where(i => i.id == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.TblPage>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnTblPageDeleted(item);
            this.context.TblPages.Remove(item);
            this.context.SaveChanges();
            this.OnAfterTblPageDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnTblPageUpdated(Models.Authenticationconn.TblPage item);
    partial void OnAfterTblPageUpdated(Models.Authenticationconn.TblPage item);

    [HttpPut("/odata/authenticationconn/TblPages(id={id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutTblPage(int key, [FromBody]Models.Authenticationconn.TblPage newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.TblPages
                .Where(i => i.id == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.TblPage>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnTblPageUpdated(newItem);
            this.context.TblPages.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.TblPages.Where(i => i.id == key);
            this.OnAfterTblPageUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/TblPages(id={id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchTblPage(int key, [FromBody]Delta<Models.Authenticationconn.TblPage> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.TblPages.Where(i => i.id == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.TblPage>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnTblPageUpdated(item);
            this.context.TblPages.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.TblPages.Where(i => i.id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnTblPageCreated(Models.Authenticationconn.TblPage item);
    partial void OnAfterTblPageCreated(Models.Authenticationconn.TblPage item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.TblPage item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnTblPageCreated(item);
            this.context.TblPages.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/TblPages/{item.id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
