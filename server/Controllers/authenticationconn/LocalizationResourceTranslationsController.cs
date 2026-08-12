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

  [Route("odata/authenticationconn/LocalizationResourceTranslations")]
  public partial class LocalizationResourceTranslationsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public LocalizationResourceTranslationsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/LocalizationResourceTranslations
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.LocalizationResourceTranslation> GetLocalizationResourceTranslations()
    {
      var items = this.context.LocalizationResourceTranslations.AsQueryable<Models.Authenticationconn.LocalizationResourceTranslation>();
      this.OnLocalizationResourceTranslationsRead(ref items);

      return items;
    }

    partial void OnLocalizationResourceTranslationsRead(ref IQueryable<Models.Authenticationconn.LocalizationResourceTranslation> items);

    partial void OnLocalizationResourceTranslationGet(ref SingleResult<Models.Authenticationconn.LocalizationResourceTranslation> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/LocalizationResourceTranslations(Id={Id})")]
    public SingleResult<LocalizationResourceTranslation> GetLocalizationResourceTranslation(int key)
    {
        var items = this.context.LocalizationResourceTranslations.Where(i=>i.Id == key);
        var result = SingleResult.Create(items);

        OnLocalizationResourceTranslationGet(ref result);

        return result;
    }
    partial void OnLocalizationResourceTranslationDeleted(Models.Authenticationconn.LocalizationResourceTranslation item);
    partial void OnAfterLocalizationResourceTranslationDeleted(Models.Authenticationconn.LocalizationResourceTranslation item);

    [HttpDelete("/odata/authenticationconn/LocalizationResourceTranslations(Id={Id})")]
    public IActionResult DeleteLocalizationResourceTranslation(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.LocalizationResourceTranslations
                .Where(i => i.Id == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.LocalizationResourceTranslation>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnLocalizationResourceTranslationDeleted(item);
            this.context.LocalizationResourceTranslations.Remove(item);
            this.context.SaveChanges();
            this.OnAfterLocalizationResourceTranslationDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnLocalizationResourceTranslationUpdated(Models.Authenticationconn.LocalizationResourceTranslation item);
    partial void OnAfterLocalizationResourceTranslationUpdated(Models.Authenticationconn.LocalizationResourceTranslation item);

    [HttpPut("/odata/authenticationconn/LocalizationResourceTranslations(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutLocalizationResourceTranslation(int key, [FromBody]Models.Authenticationconn.LocalizationResourceTranslation newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.LocalizationResourceTranslations
                .Where(i => i.Id == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.LocalizationResourceTranslation>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnLocalizationResourceTranslationUpdated(newItem);
            this.context.LocalizationResourceTranslations.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.LocalizationResourceTranslations.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "LocalizationResource");
            this.OnAfterLocalizationResourceTranslationUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/LocalizationResourceTranslations(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchLocalizationResourceTranslation(int key, [FromBody]Delta<Models.Authenticationconn.LocalizationResourceTranslation> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.LocalizationResourceTranslations.Where(i => i.Id == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.LocalizationResourceTranslation>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnLocalizationResourceTranslationUpdated(item);
            this.context.LocalizationResourceTranslations.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.LocalizationResourceTranslations.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "LocalizationResource");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnLocalizationResourceTranslationCreated(Models.Authenticationconn.LocalizationResourceTranslation item);
    partial void OnAfterLocalizationResourceTranslationCreated(Models.Authenticationconn.LocalizationResourceTranslation item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.LocalizationResourceTranslation item)
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

            this.OnLocalizationResourceTranslationCreated(item);
            this.context.LocalizationResourceTranslations.Add(item);
            this.context.SaveChanges();

            var key = item.Id;

            var itemToReturn = this.context.LocalizationResourceTranslations.Where(i => i.Id == key);

            Request.QueryString = Request.QueryString.Add("$expand", "LocalizationResource");

            this.OnAfterLocalizationResourceTranslationCreated(item);

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
