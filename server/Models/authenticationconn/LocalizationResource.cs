using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("LocalizationResources", Schema = "dbo")]
  public partial class LocalizationResource
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

    public IEnumerable<LocalizationResourceTranslation> LocalizationResourceTranslations { get; set; }
    [ConcurrencyCheck]
    public string Author
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool FromCode
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool IsHidden
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool IsModified
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
    [ConcurrencyCheck]
    public string ResourceKey
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
  }
}
