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

  [Route("odata/authenticationconn/SiteContents")]
  public partial class SiteContentsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public SiteContentsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/SiteContents
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.SiteContent> GetSiteContents()
    {
      var items = this.context.SiteContents.AsQueryable<Models.Authenticationconn.SiteContent>();
      this.OnSiteContentsRead(ref items);

      return items;
    }

    partial void OnSiteContentsRead(ref IQueryable<Models.Authenticationconn.SiteContent> items);

    partial void OnSiteContentGet(ref SingleResult<Models.Authenticationconn.SiteContent> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/SiteContents(SiteContentID={SiteContentID})")]
    public SingleResult<SiteContent> GetSiteContent(Guid key)
    {
        var items = this.context.SiteContents.Where(i=>i.SiteContentID == key);
        var result = SingleResult.Create(items);

        OnSiteContentGet(ref result);

        return result;
    }
    partial void OnSiteContentDeleted(Models.Authenticationconn.SiteContent item);
    partial void OnAfterSiteContentDeleted(Models.Authenticationconn.SiteContent item);

    [HttpDelete("/odata/authenticationconn/SiteContents(SiteContentID={SiteContentID})")]
    public IActionResult DeleteSiteContent(Guid key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.SiteContents
                .Where(i => i.SiteContentID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SiteContent>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSiteContentDeleted(item);
            this.context.SiteContents.Remove(item);
            this.context.SaveChanges();
            this.OnAfterSiteContentDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSiteContentUpdated(Models.Authenticationconn.SiteContent item);
    partial void OnAfterSiteContentUpdated(Models.Authenticationconn.SiteContent item);

    [HttpPut("/odata/authenticationconn/SiteContents(SiteContentID={SiteContentID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSiteContent(Guid key, [FromBody]Models.Authenticationconn.SiteContent newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SiteContents
                .Where(i => i.SiteContentID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SiteContent>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSiteContentUpdated(newItem);
            this.context.SiteContents.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.SiteContents.Where(i => i.SiteContentID == key);
            this.OnAfterSiteContentUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/SiteContents(SiteContentID={SiteContentID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSiteContent(Guid key, [FromBody]Delta<Models.Authenticationconn.SiteContent> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SiteContents.Where(i => i.SiteContentID == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.SiteContent>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnSiteContentUpdated(item);
            this.context.SiteContents.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.SiteContents.Where(i => i.SiteContentID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSiteContentCreated(Models.Authenticationconn.SiteContent item);
    partial void OnAfterSiteContentCreated(Models.Authenticationconn.SiteContent item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.SiteContent item)
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

            this.OnSiteContentCreated(item);
            this.context.SiteContents.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/SiteContents/{item.SiteContentID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
