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

  [Route("odata/authenticationconn/EmailsWhatsappQeueemails")]
  public partial class EmailsWhatsappQeueemailsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public EmailsWhatsappQeueemailsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/EmailsWhatsappQeueemails
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.EmailsWhatsappQeueemail> GetEmailsWhatsappQeueemails()
    {
      var items = this.context.EmailsWhatsappQeueemails.AsQueryable<Models.Authenticationconn.EmailsWhatsappQeueemail>();
      this.OnEmailsWhatsappQeueemailsRead(ref items);

      return items;
    }

    partial void OnEmailsWhatsappQeueemailsRead(ref IQueryable<Models.Authenticationconn.EmailsWhatsappQeueemail> items);

    partial void OnEmailsWhatsappQeueemailGet(ref SingleResult<Models.Authenticationconn.EmailsWhatsappQeueemail> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/EmailsWhatsappQeueemails(EmailqeueId={EmailqeueId})")]
    public SingleResult<EmailsWhatsappQeueemail> GetEmailsWhatsappQeueemail(Int64 key)
    {
        var items = this.context.EmailsWhatsappQeueemails.Where(i=>i.EmailqeueId == key);
        var result = SingleResult.Create(items);

        OnEmailsWhatsappQeueemailGet(ref result);

        return result;
    }
    partial void OnEmailsWhatsappQeueemailDeleted(Models.Authenticationconn.EmailsWhatsappQeueemail item);
    partial void OnAfterEmailsWhatsappQeueemailDeleted(Models.Authenticationconn.EmailsWhatsappQeueemail item);

    [HttpDelete("/odata/authenticationconn/EmailsWhatsappQeueemails(EmailqeueId={EmailqeueId})")]
    public IActionResult DeleteEmailsWhatsappQeueemail(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.EmailsWhatsappQeueemails
                .Where(i => i.EmailqeueId == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmailsWhatsappQeueemail>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnEmailsWhatsappQeueemailDeleted(item);
            this.context.EmailsWhatsappQeueemails.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEmailsWhatsappQeueemailDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmailsWhatsappQeueemailUpdated(Models.Authenticationconn.EmailsWhatsappQeueemail item);
    partial void OnAfterEmailsWhatsappQeueemailUpdated(Models.Authenticationconn.EmailsWhatsappQeueemail item);

    [HttpPut("/odata/authenticationconn/EmailsWhatsappQeueemails(EmailqeueId={EmailqeueId})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEmailsWhatsappQeueemail(Int64 key, [FromBody]Models.Authenticationconn.EmailsWhatsappQeueemail newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.EmailsWhatsappQeueemails
                .Where(i => i.EmailqeueId == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmailsWhatsappQeueemail>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnEmailsWhatsappQeueemailUpdated(newItem);
            this.context.EmailsWhatsappQeueemails.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EmailsWhatsappQeueemails.Where(i => i.EmailqeueId == key);
            this.OnAfterEmailsWhatsappQeueemailUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/EmailsWhatsappQeueemails(EmailqeueId={EmailqeueId})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEmailsWhatsappQeueemail(Int64 key, [FromBody]Delta<Models.Authenticationconn.EmailsWhatsappQeueemail> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.EmailsWhatsappQeueemails.Where(i => i.EmailqeueId == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmailsWhatsappQeueemail>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnEmailsWhatsappQeueemailUpdated(item);
            this.context.EmailsWhatsappQeueemails.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.EmailsWhatsappQeueemails.Where(i => i.EmailqeueId == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmailsWhatsappQeueemailCreated(Models.Authenticationconn.EmailsWhatsappQeueemail item);
    partial void OnAfterEmailsWhatsappQeueemailCreated(Models.Authenticationconn.EmailsWhatsappQeueemail item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.EmailsWhatsappQeueemail item)
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

            this.OnEmailsWhatsappQeueemailCreated(item);
            this.context.EmailsWhatsappQeueemails.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/EmailsWhatsappQeueemails/{item.EmailqeueId}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
