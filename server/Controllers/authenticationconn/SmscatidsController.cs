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

  [Route("odata/authenticationconn/Smscatids")]
  public partial class SmscatidsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public SmscatidsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/Smscatids
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.Smscatid> GetSmscatids()
    {
      var items = this.context.Smscatids.AsQueryable<Models.Authenticationconn.Smscatid>();
      this.OnSmscatidsRead(ref items);

      return items;
    }

    partial void OnSmscatidsRead(ref IQueryable<Models.Authenticationconn.Smscatid> items);

    partial void OnSmscatidGet(ref SingleResult<Models.Authenticationconn.Smscatid> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/Smscatids(smscatid1={smscatid1})")]
    public SingleResult<Smscatid> GetSmscatid(Int64 key)
    {
        var items = this.context.Smscatids.Where(i=>i.smscatid1 == key);
        var result = SingleResult.Create(items);

        OnSmscatidGet(ref result);

        return result;
    }
    partial void OnSmscatidDeleted(Models.Authenticationconn.Smscatid item);
    partial void OnAfterSmscatidDeleted(Models.Authenticationconn.Smscatid item);

    [HttpDelete("/odata/authenticationconn/Smscatids(smscatid1={smscatid1})")]
    public IActionResult DeleteSmscatid(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Smscatids
                .Where(i => i.smscatid1 == key)
                .Include(i => i.SmsLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Smscatid>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmscatidDeleted(item);
            this.context.Smscatids.Remove(item);
            this.context.SaveChanges();
            this.OnAfterSmscatidDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmscatidUpdated(Models.Authenticationconn.Smscatid item);
    partial void OnAfterSmscatidUpdated(Models.Authenticationconn.Smscatid item);

    [HttpPut("/odata/authenticationconn/Smscatids(smscatid1={smscatid1})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSmscatid(Int64 key, [FromBody]Models.Authenticationconn.Smscatid newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Smscatids
                .Where(i => i.smscatid1 == key)
                .Include(i => i.SmsLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Smscatid>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmscatidUpdated(newItem);
            this.context.Smscatids.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Smscatids.Where(i => i.smscatid1 == key);
            this.OnAfterSmscatidUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/Smscatids(smscatid1={smscatid1})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSmscatid(Int64 key, [FromBody]Delta<Models.Authenticationconn.Smscatid> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Smscatids.Where(i => i.smscatid1 == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Smscatid>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnSmscatidUpdated(item);
            this.context.Smscatids.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Smscatids.Where(i => i.smscatid1 == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmscatidCreated(Models.Authenticationconn.Smscatid item);
    partial void OnAfterSmscatidCreated(Models.Authenticationconn.Smscatid item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.Smscatid item)
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

            this.OnSmscatidCreated(item);
            this.context.Smscatids.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/Smscatids/{item.smscatid1}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
