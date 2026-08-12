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

  [Route("odata/authenticationconn/MrtcontrollerNames")]
  public partial class MrtcontrollerNamesController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public MrtcontrollerNamesController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/MrtcontrollerNames
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.MrtcontrollerName> GetMrtcontrollerNames()
    {
      var items = this.context.MrtcontrollerNames.AsQueryable<Models.Authenticationconn.MrtcontrollerName>();
      this.OnMrtcontrollerNamesRead(ref items);

      return items;
    }

    partial void OnMrtcontrollerNamesRead(ref IQueryable<Models.Authenticationconn.MrtcontrollerName> items);

    partial void OnMrtcontrollerNameGet(ref SingleResult<Models.Authenticationconn.MrtcontrollerName> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/MrtcontrollerNames(controllerNameid={controllerNameid})")]
    public SingleResult<MrtcontrollerName> GetMrtcontrollerName(Int64 key)
    {
        var items = this.context.MrtcontrollerNames.Where(i=>i.controllerNameid == key);
        var result = SingleResult.Create(items);

        OnMrtcontrollerNameGet(ref result);

        return result;
    }
    partial void OnMrtcontrollerNameDeleted(Models.Authenticationconn.MrtcontrollerName item);
    partial void OnAfterMrtcontrollerNameDeleted(Models.Authenticationconn.MrtcontrollerName item);

    [HttpDelete("/odata/authenticationconn/MrtcontrollerNames(controllerNameid={controllerNameid})")]
    public IActionResult DeleteMrtcontrollerName(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.MrtcontrollerNames
                .Where(i => i.controllerNameid == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.MrtcontrollerName>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMrtcontrollerNameDeleted(item);
            this.context.MrtcontrollerNames.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMrtcontrollerNameDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMrtcontrollerNameUpdated(Models.Authenticationconn.MrtcontrollerName item);
    partial void OnAfterMrtcontrollerNameUpdated(Models.Authenticationconn.MrtcontrollerName item);

    [HttpPut("/odata/authenticationconn/MrtcontrollerNames(controllerNameid={controllerNameid})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMrtcontrollerName(Int64 key, [FromBody]Models.Authenticationconn.MrtcontrollerName newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.MrtcontrollerNames
                .Where(i => i.controllerNameid == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.MrtcontrollerName>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnMrtcontrollerNameUpdated(newItem);
            this.context.MrtcontrollerNames.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MrtcontrollerNames.Where(i => i.controllerNameid == key);
            this.OnAfterMrtcontrollerNameUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/MrtcontrollerNames(controllerNameid={controllerNameid})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMrtcontrollerName(Int64 key, [FromBody]Delta<Models.Authenticationconn.MrtcontrollerName> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.MrtcontrollerNames.Where(i => i.controllerNameid == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.MrtcontrollerName>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnMrtcontrollerNameUpdated(item);
            this.context.MrtcontrollerNames.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MrtcontrollerNames.Where(i => i.controllerNameid == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMrtcontrollerNameCreated(Models.Authenticationconn.MrtcontrollerName item);
    partial void OnAfterMrtcontrollerNameCreated(Models.Authenticationconn.MrtcontrollerName item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.MrtcontrollerName item)
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

            this.OnMrtcontrollerNameCreated(item);
            this.context.MrtcontrollerNames.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/MrtcontrollerNames/{item.controllerNameid}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
