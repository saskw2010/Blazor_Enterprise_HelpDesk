using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("mrtcontrollerName", Schema = "dbo")]
  public partial class MrtcontrollerName
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
    public Int64 controllerNameid
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string controllerName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ReportCode
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Notes
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Notes1
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string mynotes
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ModifiedBy
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? ModifiedOn
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string CreatedBy
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? CreatedOn
    {
      get;
      set;
    }
  }
}
