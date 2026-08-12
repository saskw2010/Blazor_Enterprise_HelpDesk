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

  [Route("odata/authenticationconn/UserAudits")]
  public partial class UserAuditsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public UserAuditsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/UserAudits
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.UserAudit> GetUserAudits()
    {
      var items = this.context.UserAudits.AsQueryable<Models.Authenticationconn.UserAudit>();
      this.OnUserAuditsRead(ref items);

      return items;
    }

    partial void OnUserAuditsRead(ref IQueryable<Models.Authenticationconn.UserAudit> items);

    partial void OnUserAuditGet(ref SingleResult<Models.Authenticationconn.UserAudit> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/UserAudits(UserAuditId={UserAuditId})")]
    public SingleResult<UserAudit> GetUserAudit(Int64 key)
    {
        var items = this.context.UserAudits.Where(i=>i.UserAuditId == key);
        var result = SingleResult.Create(items);

        OnUserAuditGet(ref result);

        return result;
    }
    partial void OnUserAuditDeleted(Models.Authenticationconn.UserAudit item);
    partial void OnAfterUserAuditDeleted(Models.Authenticationconn.UserAudit item);

    [HttpDelete("/odata/authenticationconn/UserAudits(UserAuditId={UserAuditId})")]
    public IActionResult DeleteUserAudit(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.UserAudits
                .Where(i => i.UserAuditId == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.UserAudit>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnUserAuditDeleted(item);
            this.context.UserAudits.Remove(item);
            this.context.SaveChanges();
            this.OnAfterUserAuditDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnUserAuditUpdated(Models.Authenticationconn.UserAudit item);
    partial void OnAfterUserAuditUpdated(Models.Authenticationconn.UserAudit item);

    [HttpPut("/odata/authenticationconn/UserAudits(UserAuditId={UserAuditId})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutUserAudit(Int64 key, [FromBody]Models.Authenticationconn.UserAudit newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.UserAudits
                .Where(i => i.UserAuditId == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.UserAudit>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnUserAuditUpdated(newItem);
            this.context.UserAudits.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.UserAudits.Where(i => i.UserAuditId == key);
            this.OnAfterUserAuditUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/UserAudits(UserAuditId={UserAuditId})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchUserAudit(Int64 key, [FromBody]Delta<Models.Authenticationconn.UserAudit> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.UserAudits.Where(i => i.UserAuditId == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.UserAudit>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnUserAuditUpdated(item);
            this.context.UserAudits.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.UserAudits.Where(i => i.UserAuditId == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnUserAuditCreated(Models.Authenticationconn.UserAudit item);
    partial void OnAfterUserAuditCreated(Models.Authenticationconn.UserAudit item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.UserAudit item)
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

            this.OnUserAuditCreated(item);
            this.context.UserAudits.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/UserAudits/{item.UserAuditId}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
