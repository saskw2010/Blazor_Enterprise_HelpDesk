using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("tbl_Pages", Schema = "dbo")]
  public partial class TblPage
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
    public int id
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NameAr
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NameEn
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ContentAr
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ContentEn
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string PageType
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int? Sort
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool? IsSee
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Photo
    {
      get;
      set;
    }
  }
}
