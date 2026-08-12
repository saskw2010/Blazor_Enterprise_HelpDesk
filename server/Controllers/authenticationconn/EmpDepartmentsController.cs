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

  [Route("odata/authenticationconn/EmpDepartments")]
  public partial class EmpDepartmentsController : ODataController
  {
    private Data.AuthenticationconnContext context;

    public EmpDepartmentsController(Data.AuthenticationconnContext context)
    {
      this.context = context;
    }
    // GET /odata/Authenticationconn/EmpDepartments
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Authenticationconn.EmpDepartment> GetEmpDepartments()
    {
      var items = this.context.EmpDepartments.AsQueryable<Models.Authenticationconn.EmpDepartment>();
      this.OnEmpDepartmentsRead(ref items);

      return items;
    }

    partial void OnEmpDepartmentsRead(ref IQueryable<Models.Authenticationconn.EmpDepartment> items);

    partial void OnEmpDepartmentGet(ref SingleResult<Models.Authenticationconn.EmpDepartment> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/authenticationconn/EmpDepartments(EmpDepartmentID={EmpDepartmentID})")]
    public SingleResult<EmpDepartment> GetEmpDepartment(Int64 key)
    {
        var items = this.context.EmpDepartments.Where(i=>i.EmpDepartmentID == key);
        var result = SingleResult.Create(items);

        OnEmpDepartmentGet(ref result);

        return result;
    }
    partial void OnEmpDepartmentDeleted(Models.Authenticationconn.EmpDepartment item);
    partial void OnAfterEmpDepartmentDeleted(Models.Authenticationconn.EmpDepartment item);

    [HttpDelete("/odata/authenticationconn/EmpDepartments(EmpDepartmentID={EmpDepartmentID})")]
    public IActionResult DeleteEmpDepartment(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.EmpDepartments
                .Where(i => i.EmpDepartmentID == key)
                .Include(i => i.TelphonUsersLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmpDepartment>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnEmpDepartmentDeleted(item);
            this.context.EmpDepartments.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEmpDepartmentDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmpDepartmentUpdated(Models.Authenticationconn.EmpDepartment item);
    partial void OnAfterEmpDepartmentUpdated(Models.Authenticationconn.EmpDepartment item);

    [HttpPut("/odata/authenticationconn/EmpDepartments(EmpDepartmentID={EmpDepartmentID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEmpDepartment(Int64 key, [FromBody]Models.Authenticationconn.EmpDepartment newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.EmpDepartments
                .Where(i => i.EmpDepartmentID == key)
                .Include(i => i.TelphonUsersLists)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmpDepartment>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnEmpDepartmentUpdated(newItem);
            this.context.EmpDepartments.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EmpDepartments.Where(i => i.EmpDepartmentID == key);
            this.OnAfterEmpDepartmentUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/authenticationconn/EmpDepartments(EmpDepartmentID={EmpDepartmentID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEmpDepartment(Int64 key, [FromBody]Delta<Models.Authenticationconn.EmpDepartment> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.EmpDepartments.Where(i => i.EmpDepartmentID == key);

            items = EntityPatch.ApplyTo<Models.Authenticationconn.EmpDepartment>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnEmpDepartmentUpdated(item);
            this.context.EmpDepartments.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.EmpDepartments.Where(i => i.EmpDepartmentID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmpDepartmentCreated(Models.Authenticationconn.EmpDepartment item);
    partial void OnAfterEmpDepartmentCreated(Models.Authenticationconn.EmpDepartment item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Authenticationconn.EmpDepartment item)
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

            this.OnEmpDepartmentCreated(item);
            this.context.EmpDepartments.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Authenticationconn/EmpDepartments/{item.EmpDepartmentID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
