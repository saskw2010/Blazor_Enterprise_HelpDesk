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

  [Route("odata/authenticationconn/EmailsWhatsappQeues")]
  public partial class EmailsWhatsappQeuesController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public EmailsWhatsappQeuesController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/EmailsWhatsappQeues
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.EmailsWhatsappQeue> GetEmailsWhatsappQeues()
    {
      var items = this.context.EmailsWhatsappQeues.AsQueryable<Models.Authenticationconn.EmailsWhatsappQeue>();
      this.OnEmailsWhatsappQeuesRead(ref items);

      return items;
    }

    partial void OnEmailsWhatsappQeuesRead(ref IQueryable<Models.Authenticationconn.EmailsWhatsappQeue> items);

    partial void OnEmailsWhatsappQeueGet(ref SingleResult<Models.Authenticationconn.EmailsWhatsappQeue> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/EmailsWhatsappQeues(EmailqeueId={EmailqeueId})")]
    public SingleResult<EmailsWhatsappQeue> GetEmailsWhatsappQeue(Int64 key)
    {
        var items = this.context.EmailsWhatsappQeues.Where(i=>i.EmailqeueId == key);
        var result = SingleResult.Create(items);

        OnEmailsWhatsappQeueGet(ref result);

        return result;
    }
    partial void OnEmailsWhatsappQeueDeleted(Models.Authenticationconn.EmailsWhatsappQeue item);
    partial void OnAfterEmailsWhatsappQeueDeleted(Models.Authenticationconn.EmailsWhatsappQeue item);

    [HttpDelete("/odata/authenticationconn/EmailsWhatsappQeues(EmailqeueId={EmailqeueId})")]
    public IActionResult DeleteEmailsWhatsappQeue(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.EmailsWhatsappQeues
                .Where(i => i.EmailqeueId == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmailsWhatsappQeue>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnEmailsWhatsappQeueDeleted(item);
            this.context.EmailsWhatsappQeues.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEmailsWhatsappQeueDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmailsWhatsappQeueUpdated(Models.Authenticationconn.EmailsWhatsappQeue item);
    partial void OnAfterEmailsWhatsappQeueUpdated(Models.Authenticationconn.EmailsWhatsappQeue item);

    [HttpPut("/odata/authenticationconn/EmailsWhatsappQeues(EmailqeueId={EmailqeueId})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEmailsWhatsappQeue(Int64 key, [FromBody]Models.Authenticationconn.EmailsWhatsappQeue newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.EmailsWhatsappQeues
                .Where(i => i.EmailqeueId == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmailsWhatsappQeue>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnEmailsWhatsappQeueUpdated(newItem);
            this.context.EmailsWhatsappQeues.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EmailsWhatsappQeues.Where(i => i.EmailqeueId == key);
            this.OnAfterEmailsWhatsappQeueUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/EmailsWhatsappQeues(EmailqeueId={EmailqeueId})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEmailsWhatsappQeue(Int64 key, [FromBody]Delta<Models.Authenticationconn.EmailsWhatsappQeue> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.EmailsWhatsappQeues.Where(i => i.EmailqeueId == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmailsWhatsappQeue>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnEmailsWhatsappQeueUpdated(item);
            this.context.EmailsWhatsappQeues.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.EmailsWhatsappQeues.Where(i => i.EmailqeueId == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmailsWhatsappQeueCreated(Models.Authenticationconn.EmailsWhatsappQeue item);
    partial void OnAfterEmailsWhatsappQeueCreated(Models.Authenticationconn.EmailsWhatsappQeue item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.EmailsWhatsappQeue item)
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

            this.OnEmailsWhatsappQeueCreated(item);
            this.context.EmailsWhatsappQeues.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/EmailsWhatsappQeues/{item.EmailqeueId}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
