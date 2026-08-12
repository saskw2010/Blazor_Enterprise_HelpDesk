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

  [Route("odata/authenticationconn/LocalizationResources")]
  public partial class LocalizationResourcesController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public LocalizationResourcesController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/LocalizationResources
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.LocalizationResource> GetLocalizationResources()
    {
      var items = this.context.LocalizationResources.AsQueryable<Models.Authenticationconn.LocalizationResource>();
      this.OnLocalizationResourcesRead(ref items);

      return items;
    }

    partial void OnLocalizationResourcesRead(ref IQueryable<Models.Authenticationconn.LocalizationResource> items);

    partial void OnLocalizationResourceGet(ref SingleResult<Models.Authenticationconn.LocalizationResource> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/LocalizationResources(Id={Id})")]
    public SingleResult<LocalizationResource> GetLocalizationResource(int key)
    {
        var items = this.context.LocalizationResources.Where(i=>i.Id == key);
        var result = SingleResult.Create(items);

        OnLocalizationResourceGet(ref result);

        return result;
    }
    partial void OnLocalizationResourceDeleted(Models.Authenticationconn.LocalizationResource item);
    partial void OnAfterLocalizationResourceDeleted(Models.Authenticationconn.LocalizationResource item);

    [HttpDelete("/odata/authenticationconn/LocalizationResources(Id={Id})")]
    public IActionResult DeleteLocalizationResource(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.LocalizationResources
                .Where(i => i.Id == key)
                .Include(i => i.LocalizationResourceTranslations)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.LocalizationResource>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnLocalizationResourceDeleted(item);
            this.context.LocalizationResources.Remove(item);
            this.context.SaveChanges();
            this.OnAfterLocalizationResourceDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnLocalizationResourceUpdated(Models.Authenticationconn.LocalizationResource item);
    partial void OnAfterLocalizationResourceUpdated(Models.Authenticationconn.LocalizationResource item);

    [HttpPut("/odata/authenticationconn/LocalizationResources(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutLocalizationResource(int key, [FromBody]Models.Authenticationconn.LocalizationResource newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.LocalizationResources
                .Where(i => i.Id == key)
                .Include(i => i.LocalizationResourceTranslations)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.LocalizationResource>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnLocalizationResourceUpdated(newItem);
            this.context.LocalizationResources.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.LocalizationResources.Where(i => i.Id == key);
            this.OnAfterLocalizationResourceUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/LocalizationResources(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchLocalizationResource(int key, [FromBody]Delta<Models.Authenticationconn.LocalizationResource> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.LocalizationResources.Where(i => i.Id == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.LocalizationResource>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnLocalizationResourceUpdated(item);
            this.context.LocalizationResources.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.LocalizationResources.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnLocalizationResourceCreated(Models.Authenticationconn.LocalizationResource item);
    partial void OnAfterLocalizationResourceCreated(Models.Authenticationconn.LocalizationResource item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.LocalizationResource item)
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

            this.OnLocalizationResourceCreated(item);
            this.context.LocalizationResources.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/LocalizationResources/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
