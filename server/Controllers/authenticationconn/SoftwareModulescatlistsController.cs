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

  [Route("odata/authenticationconn/SoftwareModulescatlists")]
  public partial class SoftwareModulescatlistsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public SoftwareModulescatlistsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/SoftwareModulescatlists
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.SoftwareModulescatlist> GetSoftwareModulescatlists()
    {
      var items = this.context.SoftwareModulescatlists.AsQueryable<Models.Authenticationconn.SoftwareModulescatlist>();
      this.OnSoftwareModulescatlistsRead(ref items);

      return items;
    }

    partial void OnSoftwareModulescatlistsRead(ref IQueryable<Models.Authenticationconn.SoftwareModulescatlist> items);

    partial void OnSoftwareModulescatlistGet(ref SingleResult<Models.Authenticationconn.SoftwareModulescatlist> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/SoftwareModulescatlists(sprModulecatid={sprModulecatid})")]
    public SingleResult<SoftwareModulescatlist> GetSoftwareModulescatlist(Int64 key)
    {
        var items = this.context.SoftwareModulescatlists.Where(i=>i.sprModulecatid == key);
        var result = SingleResult.Create(items);

        OnSoftwareModulescatlistGet(ref result);

        return result;
    }
    partial void OnSoftwareModulescatlistDeleted(Models.Authenticationconn.SoftwareModulescatlist item);
    partial void OnAfterSoftwareModulescatlistDeleted(Models.Authenticationconn.SoftwareModulescatlist item);

    [HttpDelete("/odata/authenticationconn/SoftwareModulescatlists(sprModulecatid={sprModulecatid})")]
    public IActionResult DeleteSoftwareModulescatlist(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.SoftwareModulescatlists
                .Where(i => i.sprModulecatid == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SoftwareModulescatlist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSoftwareModulescatlistDeleted(item);
            this.context.SoftwareModulescatlists.Remove(item);
            this.context.SaveChanges();
            this.OnAfterSoftwareModulescatlistDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSoftwareModulescatlistUpdated(Models.Authenticationconn.SoftwareModulescatlist item);
    partial void OnAfterSoftwareModulescatlistUpdated(Models.Authenticationconn.SoftwareModulescatlist item);

    [HttpPut("/odata/authenticationconn/SoftwareModulescatlists(sprModulecatid={sprModulecatid})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSoftwareModulescatlist(Int64 key, [FromBody]Models.Authenticationconn.SoftwareModulescatlist newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SoftwareModulescatlists
                .Where(i => i.sprModulecatid == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SoftwareModulescatlist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSoftwareModulescatlistUpdated(newItem);
            this.context.SoftwareModulescatlists.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.SoftwareModulescatlists.Where(i => i.sprModulecatid == key);
            this.OnAfterSoftwareModulescatlistUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/SoftwareModulescatlists(sprModulecatid={sprModulecatid})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSoftwareModulescatlist(Int64 key, [FromBody]Delta<Models.Authenticationconn.SoftwareModulescatlist> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SoftwareModulescatlists.Where(i => i.sprModulecatid == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SoftwareModulescatlist>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnSoftwareModulescatlistUpdated(item);
            this.context.SoftwareModulescatlists.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.SoftwareModulescatlists.Where(i => i.sprModulecatid == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSoftwareModulescatlistCreated(Models.Authenticationconn.SoftwareModulescatlist item);
    partial void OnAfterSoftwareModulescatlistCreated(Models.Authenticationconn.SoftwareModulescatlist item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.SoftwareModulescatlist item)
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

            this.OnSoftwareModulescatlistCreated(item);
            this.context.SoftwareModulescatlists.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/SoftwareModulescatlists/{item.sprModulecatid}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
