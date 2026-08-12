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

  [Route("odata/authenticationconn/Customerswhatsapps")]
  public partial class CustomerswhatsappsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public CustomerswhatsappsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/Customerswhatsapps
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.Customerswhatsapp> GetCustomerswhatsapps()
    {
      var items = this.context.Customerswhatsapps.AsQueryable<Models.Authenticationconn.Customerswhatsapp>();
      this.OnCustomerswhatsappsRead(ref items);

      return items;
    }

    partial void OnCustomerswhatsappsRead(ref IQueryable<Models.Authenticationconn.Customerswhatsapp> items);

    partial void OnCustomerswhatsappGet(ref SingleResult<Models.Authenticationconn.Customerswhatsapp> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/Customerswhatsapps(Cstm_No={Cstm_No})")]
    public SingleResult<Customerswhatsapp> GetCustomerswhatsapp(Int64 key)
    {
        var items = this.context.Customerswhatsapps.Where(i=>i.Cstm_No == key);
        var result = SingleResult.Create(items);

        OnCustomerswhatsappGet(ref result);

        return result;
    }
    partial void OnCustomerswhatsappDeleted(Models.Authenticationconn.Customerswhatsapp item);
    partial void OnAfterCustomerswhatsappDeleted(Models.Authenticationconn.Customerswhatsapp item);

    [HttpDelete("/odata/authenticationconn/Customerswhatsapps(Cstm_No={Cstm_No})")]
    public IActionResult DeleteCustomerswhatsapp(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Customerswhatsapps
                .Where(i => i.Cstm_No == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Customerswhatsapp>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnCustomerswhatsappDeleted(item);
            this.context.Customerswhatsapps.Remove(item);
            this.context.SaveChanges();
            this.OnAfterCustomerswhatsappDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnCustomerswhatsappUpdated(Models.Authenticationconn.Customerswhatsapp item);
    partial void OnAfterCustomerswhatsappUpdated(Models.Authenticationconn.Customerswhatsapp item);

    [HttpPut("/odata/authenticationconn/Customerswhatsapps(Cstm_No={Cstm_No})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutCustomerswhatsapp(Int64 key, [FromBody]Models.Authenticationconn.Customerswhatsapp newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Customerswhatsapps
                .Where(i => i.Cstm_No == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Customerswhatsapp>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnCustomerswhatsappUpdated(newItem);
            this.context.Customerswhatsapps.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Customerswhatsapps.Where(i => i.Cstm_No == key);
            this.OnAfterCustomerswhatsappUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/Customerswhatsapps(Cstm_No={Cstm_No})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchCustomerswhatsapp(Int64 key, [FromBody]Delta<Models.Authenticationconn.Customerswhatsapp> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Customerswhatsapps.Where(i => i.Cstm_No == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.Customerswhatsapp>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnCustomerswhatsappUpdated(item);
            this.context.Customerswhatsapps.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Customerswhatsapps.Where(i => i.Cstm_No == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnCustomerswhatsappCreated(Models.Authenticationconn.Customerswhatsapp item);
    partial void OnAfterCustomerswhatsappCreated(Models.Authenticationconn.Customerswhatsapp item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.Customerswhatsapp item)
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

            this.OnCustomerswhatsappCreated(item);
            this.context.Customerswhatsapps.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/Customerswhatsapps/{item.Cstm_No}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
