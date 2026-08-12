using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("EmpJoblist", Schema = "dbo")]
  public partial class EmpJoblist
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
    public Int64 EmpjoblistID
    {
      get;
      set;
    }

    public IEnumerable<TelphonUsersList> TelphonUsersLists { get; set; }
    [ConcurrencyCheck]
    public string EmpjoblistDesc
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string EmpjoblistDesc1
    {
      get;
      set;
    }
  }
}
