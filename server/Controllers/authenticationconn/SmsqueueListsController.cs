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

  [Route("odata/authenticationconn/SmsqueueLists")]
  public partial class SmsqueueListsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public SmsqueueListsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/SmsqueueLists
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.SmsqueueList> GetSmsqueueLists()
    {
      var items = this.context.SmsqueueLists.AsQueryable<Models.Authenticationconn.SmsqueueList>();
      this.OnSmsqueueListsRead(ref items);

      return items;
    }

    partial void OnSmsqueueListsRead(ref IQueryable<Models.Authenticationconn.SmsqueueList> items);

    partial void OnSmsqueueListGet(ref SingleResult<Models.Authenticationconn.SmsqueueList> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/SmsqueueLists(SMSQUEUEID={SMSQUEUEID})")]
    public SingleResult<SmsqueueList> GetSmsqueueList(Int64 key)
    {
        var items = this.context.SmsqueueLists.Where(i=>i.SMSQUEUEID == key);
        var result = SingleResult.Create(items);

        OnSmsqueueListGet(ref result);

        return result;
    }
    partial void OnSmsqueueListDeleted(Models.Authenticationconn.SmsqueueList item);
    partial void OnAfterSmsqueueListDeleted(Models.Authenticationconn.SmsqueueList item);

    [HttpDelete("/odata/authenticationconn/SmsqueueLists(SMSQUEUEID={SMSQUEUEID})")]
    public IActionResult DeleteSmsqueueList(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.SmsqueueLists
                .Where(i => i.SMSQUEUEID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsqueueList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmsqueueListDeleted(item);
            this.context.SmsqueueLists.Remove(item);
            this.context.SaveChanges();
            this.OnAfterSmsqueueListDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmsqueueListUpdated(Models.Authenticationconn.SmsqueueList item);
    partial void OnAfterSmsqueueListUpdated(Models.Authenticationconn.SmsqueueList item);

    [HttpPut("/odata/authenticationconn/SmsqueueLists(SMSQUEUEID={SMSQUEUEID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSmsqueueList(Int64 key, [FromBody]Models.Authenticationconn.SmsqueueList newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SmsqueueLists
                .Where(i => i.SMSQUEUEID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsqueueList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmsqueueListUpdated(newItem);
            this.context.SmsqueueLists.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.SmsqueueLists.Where(i => i.SMSQUEUEID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "SmsList");
            this.OnAfterSmsqueueListUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/SmsqueueLists(SMSQUEUEID={SMSQUEUEID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSmsqueueList(Int64 key, [FromBody]Delta<Models.Authenticationconn.SmsqueueList> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SmsqueueLists.Where(i => i.SMSQUEUEID == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsqueueList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnSmsqueueListUpdated(item);
            this.context.SmsqueueLists.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.SmsqueueLists.Where(i => i.SMSQUEUEID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "SmsList");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmsqueueListCreated(Models.Authenticationconn.SmsqueueList item);
    partial void OnAfterSmsqueueListCreated(Models.Authenticationconn.SmsqueueList item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.SmsqueueList item)
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

            this.OnSmsqueueListCreated(item);
            this.context.SmsqueueLists.Add(item);
            this.context.SaveChanges();

            var key = item.SMSQUEUEID;

            var itemToReturn = this.context.SmsqueueLists.Where(i => i.SMSQUEUEID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "SmsList");

            this.OnAfterSmsqueueListCreated(item);

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
