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

  [Route("odata/authenticationconn/TelphonUsersLists")]
  public partial class TelphonUsersListsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public TelphonUsersListsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/TelphonUsersLists
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.TelphonUsersList> GetTelphonUsersLists()
    {
      var items = this.context.TelphonUsersLists.AsQueryable<Models.Authenticationconn.TelphonUsersList>();
      this.OnTelphonUsersListsRead(ref items);

      return items;
    }

    partial void OnTelphonUsersListsRead(ref IQueryable<Models.Authenticationconn.TelphonUsersList> items);

    partial void OnTelphonUsersListGet(ref SingleResult<Models.Authenticationconn.TelphonUsersList> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/TelphonUsersLists(TelphonUsersListID={TelphonUsersListID})")]
    public SingleResult<TelphonUsersList> GetTelphonUsersList(Int64 key)
    {
        var items = this.context.TelphonUsersLists.Where(i=>i.TelphonUsersListID == key);
        var result = SingleResult.Create(items);

        OnTelphonUsersListGet(ref result);

        return result;
    }
    partial void OnTelphonUsersListDeleted(Models.Authenticationconn.TelphonUsersList item);
    partial void OnAfterTelphonUsersListDeleted(Models.Authenticationconn.TelphonUsersList item);

    [HttpDelete("/odata/authenticationconn/TelphonUsersLists(TelphonUsersListID={TelphonUsersListID})")]
    public IActionResult DeleteTelphonUsersList(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.TelphonUsersLists
                .Where(i => i.TelphonUsersListID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.TelphonUsersList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnTelphonUsersListDeleted(item);
            this.context.TelphonUsersLists.Remove(item);
            this.context.SaveChanges();
            this.OnAfterTelphonUsersListDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnTelphonUsersListUpdated(Models.Authenticationconn.TelphonUsersList item);
    partial void OnAfterTelphonUsersListUpdated(Models.Authenticationconn.TelphonUsersList item);

    [HttpPut("/odata/authenticationconn/TelphonUsersLists(TelphonUsersListID={TelphonUsersListID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutTelphonUsersList(Int64 key, [FromBody]Models.Authenticationconn.TelphonUsersList newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.TelphonUsersLists
                .Where(i => i.TelphonUsersListID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.TelphonUsersList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnTelphonUsersListUpdated(newItem);
            this.context.TelphonUsersLists.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.TelphonUsersLists.Where(i => i.TelphonUsersListID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "EmpDepartment,EmpJoblist");
            this.OnAfterTelphonUsersListUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/TelphonUsersLists(TelphonUsersListID={TelphonUsersListID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchTelphonUsersList(Int64 key, [FromBody]Delta<Models.Authenticationconn.TelphonUsersList> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.TelphonUsersLists.Where(i => i.TelphonUsersListID == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.TelphonUsersList>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnTelphonUsersListUpdated(item);
            this.context.TelphonUsersLists.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.TelphonUsersLists.Where(i => i.TelphonUsersListID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "EmpDepartment,EmpJoblist");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnTelphonUsersListCreated(Models.Authenticationconn.TelphonUsersList item);
    partial void OnAfterTelphonUsersListCreated(Models.Authenticationconn.TelphonUsersList item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.TelphonUsersList item)
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

            this.OnTelphonUsersListCreated(item);
            this.context.TelphonUsersLists.Add(item);
            this.context.SaveChanges();

            var key = item.TelphonUsersListID;

            var itemToReturn = this.context.TelphonUsersLists.Where(i => i.TelphonUsersListID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "EmpDepartment,EmpJoblist");

            this.OnAfterTelphonUsersListCreated(item);

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
