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

  [Route("odata/authenticationconn/ServiceCatglists")]
  public partial class ServiceCatglistsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public ServiceCatglistsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/ServiceCatglists
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.ServiceCatglist> GetServiceCatglists()
    {
      var items = this.context.ServiceCatglists.AsQueryable<Models.Authenticationconn.ServiceCatglist>();
      this.OnServiceCatglistsRead(ref items);

      return items;
    }

    partial void OnServiceCatglistsRead(ref IQueryable<Models.Authenticationconn.ServiceCatglist> items);

    partial void OnServiceCatglistGet(ref SingleResult<Models.Authenticationconn.ServiceCatglist> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/ServiceCatglists(ServiceCatgID={ServiceCatgID})")]
    public SingleResult<ServiceCatglist> GetServiceCatglist(Int64 key)
    {
        var items = this.context.ServiceCatglists.Where(i=>i.ServiceCatgID == key);
        var result = SingleResult.Create(items);

        OnServiceCatglistGet(ref result);

        return result;
    }
    partial void OnServiceCatglistDeleted(Models.Authenticationconn.ServiceCatglist item);
    partial void OnAfterServiceCatglistDeleted(Models.Authenticationconn.ServiceCatglist item);

    [HttpDelete("/odata/authenticationconn/ServiceCatglists(ServiceCatgID={ServiceCatgID})")]
    public IActionResult DeleteServiceCatglist(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.ServiceCatglists
                .Where(i => i.ServiceCatgID == key)
                .Include(i => i.HelpDeskTickets)
                .Include(i => i.ServicesLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.ServiceCatglist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnServiceCatglistDeleted(item);
            this.context.ServiceCatglists.Remove(item);
            this.context.SaveChanges();
            this.OnAfterServiceCatglistDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnServiceCatglistUpdated(Models.Authenticationconn.ServiceCatglist item);
    partial void OnAfterServiceCatglistUpdated(Models.Authenticationconn.ServiceCatglist item);

    [HttpPut("/odata/authenticationconn/ServiceCatglists(ServiceCatgID={ServiceCatgID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutServiceCatglist(Int64 key, [FromBody]Models.Authenticationconn.ServiceCatglist newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.ServiceCatglists
                .Where(i => i.ServiceCatgID == key)
                .Include(i => i.HelpDeskTickets)
                .Include(i => i.ServicesLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.ServiceCatglist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnServiceCatglistUpdated(newItem);
            this.context.ServiceCatglists.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.ServiceCatglists.Where(i => i.ServiceCatgID == key);
            this.OnAfterServiceCatglistUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/ServiceCatglists(ServiceCatgID={ServiceCatgID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchServiceCatglist(Int64 key, [FromBody]Delta<Models.Authenticationconn.ServiceCatglist> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.ServiceCatglists.Where(i => i.ServiceCatgID == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.ServiceCatglist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnServiceCatglistUpdated(item);
            this.context.ServiceCatglists.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.ServiceCatglists.Where(i => i.ServiceCatgID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnServiceCatglistCreated(Models.Authenticationconn.ServiceCatglist item);
    partial void OnAfterServiceCatglistCreated(Models.Authenticationconn.ServiceCatglist item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.ServiceCatglist item)
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

            this.OnServiceCatglistCreated(item);
            this.context.ServiceCatglists.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/ServiceCatglists/{item.ServiceCatgID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
