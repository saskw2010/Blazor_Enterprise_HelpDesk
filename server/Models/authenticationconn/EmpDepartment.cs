using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("EmpDepartment", Schema = "dbo")]
  public partial class EmpDepartment
  {
    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("@odata.etag")]
    public string ETag
    {
        get;
        set;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 EmpDepartmentID
    {
      get;
      set;
    }

    public IEnumerable<TelphonUsersList> TelphonUsersLists { get; set; }
    [ConcurrencyCheck]
    public string EmpDepartmentDesc
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string EmpDepartmentDesc1
    {
      get;
      set;
    }
  }
}
