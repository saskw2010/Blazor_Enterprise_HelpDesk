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

  [Route("odata/authenticationconn/SmsLists")]
  public partial class SmsListsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public SmsListsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/SmsLists
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.SmsList> GetSmsLists()
    {
      var items = this.context.SmsLists.AsQueryable<Models.Authenticationconn.SmsList>();
      this.OnSmsListsRead(ref items);

      return items;
    }

    partial void OnSmsListsRead(ref IQueryable<Models.Authenticationconn.SmsList> items);

    partial void OnSmsListGet(ref SingleResult<Models.Authenticationconn.SmsList> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/SmsLists(SMSidauto={SMSidauto})")]
    public SingleResult<SmsList> GetSmsList(Int64 key)
    {
        var items = this.context.SmsLists.Where(i=>i.SMSidauto == key);
        var result = SingleResult.Create(items);

        OnSmsListGet(ref result);

        return result;
    }
    partial void OnSmsListDeleted(Models.Authenticationconn.SmsList item);
    partial void OnAfterSmsListDeleted(Models.Authenticationconn.SmsList item);

    [HttpDelete("/odata/authenticationconn/SmsLists(SMSidauto={SMSidauto})")]
    public IActionResult DeleteSmsList(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.SmsLists
                .Where(i => i.SMSidauto == key)
                .Include(i => i.SmsqueueLists)
                .Include(i => i.SmsqueueListds)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmsListDeleted(item);
            this.context.SmsLists.Remove(item);
            this.context.SaveChanges();
            this.OnAfterSmsListDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmsListUpdated(Models.Authenticationconn.SmsList item);
    partial void OnAfterSmsListUpdated(Models.Authenticationconn.SmsList item);

    [HttpPut("/odata/authenticationconn/SmsLists(SMSidauto={SMSidauto})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSmsList(Int64 key, [FromBody]Models.Authenticationconn.SmsList newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SmsLists
                .Where(i => i.SMSidauto == key)
                .Include(i => i.SmsqueueLists)
                .Include(i => i.SmsqueueListds)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmsListUpdated(newItem);
            this.context.SmsLists.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.SmsLists.Where(i => i.SMSidauto == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Smscatid1,Smsbrand1");
            this.OnAfterSmsListUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/SmsLists(SMSidauto={SMSidauto})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSmsList(Int64 key, [FromBody]Delta<Models.Authenticationconn.SmsList> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SmsLists.Where(i => i.SMSidauto == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnSmsListUpdated(item);
            this.context.SmsLists.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.SmsLists.Where(i => i.SMSidauto == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Smscatid1,Smsbrand1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmsListCreated(Models.Authenticationconn.SmsList item);
    partial void OnAfterSmsListCreated(Models.Authenticationconn.SmsList item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.SmsList item)
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

            this.OnSmsListCreated(item);
            this.context.SmsLists.Add(item);
            this.context.SaveChanges();

            var key = item.SMSidauto;

            var itemToReturn = this.context.SmsLists.Where(i => i.SMSidauto == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Smscatid1,Smsbrand1");

            this.OnAfterSmsListCreated(item);

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
