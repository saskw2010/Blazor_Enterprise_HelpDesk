using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("LocalizationResourceTranslations", Schema = "dbo")]
  public partial class LocalizationResourceTranslation
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
    public int Id
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Language
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int ResourceId
    {
      get;
      set;
    }
    public LocalizationResource LocalizationResource { get; set; }
    [ConcurrencyCheck]
    public string Value
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime ModificationDate
    {
      get;
      set;
    }
  }
}
