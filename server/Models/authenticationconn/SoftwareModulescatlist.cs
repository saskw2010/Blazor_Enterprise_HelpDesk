using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("SoftwareModulescatlist", Schema = "dbo")]
  public partial class SoftwareModulescatlist
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
    public Int64 sprModulecatid
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string sprModulecatDesc
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string sprModulecatDesc1
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string FuturecatDesc
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string FuturecatDesc1
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string photopath
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public decimal? InstallcatModule
    {
      get;
      set;
    }
  }
}
