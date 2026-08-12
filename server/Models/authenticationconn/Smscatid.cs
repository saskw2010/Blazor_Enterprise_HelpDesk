using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("smscatid", Schema = "dbo")]
  public partial class Smscatid
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

    [Column("smscatid")]
    public Int64 smscatid1
    {
      get;
      set;
    }

    public IEnumerable<SmsList> SmsLists { get; set; }
    [ConcurrencyCheck]
    public string smscatsms
    {
      get;
      set;
    }
  }
}
