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

  [Route("odata/authenticationconn/EmpJoblists")]
  public partial class EmpJoblistsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public EmpJoblistsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/EmpJoblists
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.EmpJoblist> GetEmpJoblists()
    {
      var items = this.context.EmpJoblists.AsQueryable<Models.Authenticationconn.EmpJoblist>();
      this.OnEmpJoblistsRead(ref items);

      return items;
    }

    partial void OnEmpJoblistsRead(ref IQueryable<Models.Authenticationconn.EmpJoblist> items);

    partial void OnEmpJoblistGet(ref SingleResult<Models.Authenticationconn.EmpJoblist> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/EmpJoblists(EmpjoblistID={EmpjoblistID})")]
    public SingleResult<EmpJoblist> GetEmpJoblist(Int64 key)
    {
        var items = this.context.EmpJoblists.Where(i=>i.EmpjoblistID == key);
        var result = SingleResult.Create(items);

        OnEmpJoblistGet(ref result);

        return result;
    }
    partial void OnEmpJoblistDeleted(Models.Authenticationconn.EmpJoblist item);
    partial void OnAfterEmpJoblistDeleted(Models.Authenticationconn.EmpJoblist item);

    [HttpDelete("/odata/authenticationconn/EmpJoblists(EmpjoblistID={EmpjoblistID})")]
    public IActionResult DeleteEmpJoblist(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.EmpJoblists
                .Where(i => i.EmpjoblistID == key)
                .Include(i => i.TelphonUsersLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmpJoblist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnEmpJoblistDeleted(item);
            this.context.EmpJoblists.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEmpJoblistDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmpJoblistUpdated(Models.Authenticationconn.EmpJoblist item);
    partial void OnAfterEmpJoblistUpdated(Models.Authenticationconn.EmpJoblist item);

    [HttpPut("/odata/authenticationconn/EmpJoblists(EmpjoblistID={EmpjoblistID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEmpJoblist(Int64 key, [FromBody]Models.Authenticationconn.EmpJoblist newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.EmpJoblists
                .Where(i => i.EmpjoblistID == key)
                .Include(i => i.TelphonUsersLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmpJoblist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnEmpJoblistUpdated(newItem);
            this.context.EmpJoblists.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EmpJoblists.Where(i => i.EmpjoblistID == key);
            this.OnAfterEmpJoblistUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/EmpJoblists(EmpjoblistID={EmpjoblistID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEmpJoblist(Int64 key, [FromBody]Delta<Models.Authenticationconn.EmpJoblist> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.EmpJoblists.Where(i => i.EmpjoblistID == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmpJoblist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnEmpJoblistUpdated(item);
            this.context.EmpJoblists.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.EmpJoblists.Where(i => i.EmpjoblistID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmpJoblistCreated(Models.Authenticationconn.EmpJoblist item);
    partial void OnAfterEmpJoblistCreated(Models.Authenticationconn.EmpJoblist item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.EmpJoblist item)
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

            this.OnEmpJoblistCreated(item);
            this.context.EmpJoblists.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/EmpJoblists/{item.EmpjoblistID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
