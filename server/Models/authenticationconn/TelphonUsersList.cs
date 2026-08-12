using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("TelphonUsersList", Schema = "dbo")]
  public partial class TelphonUsersList
  {
    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("@odata.etag")]
    public string ETag
    {
        get;
        set;
    }

    [ConcurrencyCheck]
    public string FullName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Extension
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string TicketRequesterEmail
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string MobileNumber
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? DepartmentID
    {
      get;
      set;
    }
    public EmpDepartment EmpDepartment { get; set; }
    [ConcurrencyCheck]
    public Int64? Jobid
    {
      get;
      set;
    }
    public EmpJoblist EmpJoblist { get; set; }
    [ConcurrencyCheck]
    public string TicketRequesterUser
    {
      get;
      set;
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 TelphonUsersListID
    {
      get;
      set;
    }
  }
}
