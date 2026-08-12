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

  [Route("odata/authenticationconn/SmsqueueListds")]
  public partial class SmsqueueListdsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public SmsqueueListdsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/SmsqueueListds
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.SmsqueueListd> GetSmsqueueListds()
    {
      var items = this.context.SmsqueueListds.AsQueryable<Models.Authenticationconn.SmsqueueListd>();
      this.OnSmsqueueListdsRead(ref items);

      return items;
    }

    partial void OnSmsqueueListdsRead(ref IQueryable<Models.Authenticationconn.SmsqueueListd> items);

    partial void OnSmsqueueListdGet(ref SingleResult<Models.Authenticationconn.SmsqueueListd> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/SmsqueueListds(SMSQUEUEID={SMSQUEUEID})")]
    public SingleResult<SmsqueueListd> GetSmsqueueListd(Int64 key)
    {
        var items = this.context.SmsqueueListds.Where(i=>i.SMSQUEUEID == key);
        var result = SingleResult.Create(items);

        OnSmsqueueListdGet(ref result);

        return result;
    }
    partial void OnSmsqueueListdDeleted(Models.Authenticationconn.SmsqueueListd item);
    partial void OnAfterSmsqueueListdDeleted(Models.Authenticationconn.SmsqueueListd item);

    [HttpDelete("/odata/authenticationconn/SmsqueueListds(SMSQUEUEID={SMSQUEUEID})")]
    public IActionResult DeleteSmsqueueListd(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.SmsqueueListds
                .Where(i => i.SMSQUEUEID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsqueueListd>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmsqueueListdDeleted(item);
            this.context.SmsqueueListds.Remove(item);
            this.context.SaveChanges();
            this.OnAfterSmsqueueListdDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmsqueueListdUpdated(Models.Authenticationconn.SmsqueueListd item);
    partial void OnAfterSmsqueueListdUpdated(Models.Authenticationconn.SmsqueueListd item);

    [HttpPut("/odata/authenticationconn/SmsqueueListds(SMSQUEUEID={SMSQUEUEID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSmsqueueListd(Int64 key, [FromBody]Models.Authenticationconn.SmsqueueListd newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SmsqueueListds
                .Where(i => i.SMSQUEUEID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsqueueListd>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSmsqueueListdUpdated(newItem);
            this.context.SmsqueueListds.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.SmsqueueListds.Where(i => i.SMSQUEUEID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "SmsList");
            this.OnAfterSmsqueueListdUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/SmsqueueListds(SMSQUEUEID={SMSQUEUEID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSmsqueueListd(Int64 key, [FromBody]Delta<Models.Authenticationconn.SmsqueueListd> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SmsqueueListds.Where(i => i.SMSQUEUEID == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SmsqueueListd>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnSmsqueueListdUpdated(item);
            this.context.SmsqueueListds.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.SmsqueueListds.Where(i => i.SMSQUEUEID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "SmsList");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSmsqueueListdCreated(Models.Authenticationconn.SmsqueueListd item);
    partial void OnAfterSmsqueueListdCreated(Models.Authenticationconn.SmsqueueListd item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.SmsqueueListd item)
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

            this.OnSmsqueueListdCreated(item);
            this.context.SmsqueueListds.Add(item);
            this.context.SaveChanges();

            var key = item.SMSQUEUEID;

            var itemToReturn = this.context.SmsqueueListds.Where(i => i.SMSQUEUEID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "SmsList");

            this.OnAfterSmsqueueListdCreated(item);

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
