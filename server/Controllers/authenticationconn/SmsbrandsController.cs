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

  [Route("odata/authenticationconn/Smsbrands")]
  public partial class SmsbrandsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public SmsbrandsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/Smsbrands
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.Smsbrand> GetSmsbrands()
    {
      var items = this.context.Smsbrands.AsQueryable<Models.Authenticationconn.Smsbrand>();
      this.OnSmsbrandsRead(ref items);

      return items;
    }

    partial void OnSmsbrandsRead(ref IQueryable<Models.Authenticationconn.Smsbrand> items);

    partial void OnSmsbrandGet(ref SingleResult<Models.Authenticationconn.Smsbrand> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/Smsbrands(smsbrand1={smsbrand1})")]
    public SingleResult<Smsbrand> GetSmsbrand(Int64 key)
    {
        var items = this.context.Smsbrands.Where(i=>i.smsbrand1 == key);
        var result = SingleResult.Create(items);

        OnSmsbrandGet(ref result);

        return result;
    }
    partial void OnSmsbrandDeleted(Models.Authenticationconn.Smsbrand item);
    partial void OnAfterSmsbrandDeleted(Models.Authenticationconn.Smsbrand item);

    [HttpDelete("/odata/authenticationconn/Smsbrands(smsbrand1={smsbrand1})")]
    public IActionResult DeleteSmsbrand(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Smsbrands
                .Where(i => i.smsbrand1 == key)
                .Include(i => i.SmsLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Smsbrand>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmsbrandDeleted(item);
            this.context.Smsbrands.Remove(item);
            this.context.SaveChanges();
            this.OnAfterSmsbrandDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmsbrandUpdated(Models.Authenticationconn.Smsbrand item);
    partial void OnAfterSmsbrandUpdated(Models.Authenticationconn.Smsbrand item);

    [HttpPut("/odata/authenticationconn/Smsbrands(smsbrand1={smsbrand1})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSmsbrand(Int64 key, [FromBody]Models.Authenticationconn.Smsbrand newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Smsbrands
                .Where(i => i.smsbrand1 == key)
                .Include(i => i.SmsLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Smsbrand>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmsbrandUpdated(newItem);
            this.context.Smsbrands.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Smsbrands.Where(i => i.smsbrand1 == key);
            this.OnAfterSmsbrandUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/Smsbrands(smsbrand1={smsbrand1})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSmsbrand(Int64 key, [FromBody]Delta<Models.Authenticationconn.Smsbrand> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Smsbrands.Where(i => i.smsbrand1 == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Smsbrand>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnSmsbrandUpdated(item);
            this.context.Smsbrands.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Smsbrands.Where(i => i.smsbrand1 == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmsbrandCreated(Models.Authenticationconn.Smsbrand item);
    partial void OnAfterSmsbrandCreated(Models.Authenticationconn.Smsbrand item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.Smsbrand item)
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

            this.OnSmsbrandCreated(item);
            this.context.Smsbrands.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/Smsbrands/{item.smsbrand1}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
