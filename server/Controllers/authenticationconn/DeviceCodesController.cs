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

  [Route("odata/authenticationconn/DeviceCodes")]
  public partial class DeviceCodesController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public DeviceCodesController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/DeviceCodes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.DeviceCode> GetDeviceCodes()
    {
      var items = this.context.DeviceCodes.AsQueryable<Models.Authenticationconn.DeviceCode>();
      this.OnDeviceCodesRead(ref items);

      return items;
    }

    partial void OnDeviceCodesRead(ref IQueryable<Models.Authenticationconn.DeviceCode> items);

    partial void OnDeviceCodeGet(ref SingleResult<Models.Authenticationconn.DeviceCode> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/DeviceCodes(UserCode={UserCode})")]
    public SingleResult<DeviceCode> GetDeviceCode(string key)
    {
        var items = this.context.DeviceCodes.Where(i=>i.UserCode == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnDeviceCodeGet(ref result);

        return result;
    }
    partial void OnDeviceCodeDeleted(Models.Authenticationconn.DeviceCode item);
    partial void OnAfterDeviceCodeDeleted(Models.Authenticationconn.DeviceCode item);

    [HttpDelete("/odata/authenticationconn/DeviceCodes(UserCode={UserCode})")]
    public IActionResult DeleteDeviceCode(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.DeviceCodes
                .Where(i => i.UserCode == Uri.UnescapeDataString(key))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.DeviceCode>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnDeviceCodeDeleted(item);
            this.context.DeviceCodes.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDeviceCodeDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDeviceCodeUpdated(Models.Authenticationconn.DeviceCode item);
    partial void OnAfterDeviceCodeUpdated(Models.Authenticationconn.DeviceCode item);

    [HttpPut("/odata/authenticationconn/DeviceCodes(UserCode={UserCode})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDeviceCode(string key, [FromBody]Models.Authenticationconn.DeviceCode newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.DeviceCodes
                .Where(i => i.UserCode == Uri.UnescapeDataString(key))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.DeviceCode>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnDeviceCodeUpdated(newItem);
            this.context.DeviceCodes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.DeviceCodes.Where(i => i.UserCode == Uri.UnescapeDataString(key));
            this.OnAfterDeviceCodeUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/DeviceCodes(UserCode={UserCode})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDeviceCode(string key, [FromBody]Delta<Models.Authenticationconn.DeviceCode> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.DeviceCodes.Where(i => i.UserCode == Uri.UnescapeDataString(key));

            items = EntityPatch.ApplyTo<Models.Authenticationconn.DeviceCode>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnDeviceCodeUpdated(item);
            this.context.DeviceCodes.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.DeviceCodes.Where(i => i.UserCode == Uri.UnescapeDataString(key));
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDeviceCodeCreated(Models.Authenticationconn.DeviceCode item);
    partial void OnAfterDeviceCodeCreated(Models.Authenticationconn.DeviceCode item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.DeviceCode item)
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

            this.OnDeviceCodeCreated(item);
            this.context.DeviceCodes.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/DeviceCodes/{item.UserCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
