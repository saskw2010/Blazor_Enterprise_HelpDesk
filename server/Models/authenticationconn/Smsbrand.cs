using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("smsbrand", Schema = "dbo")]
  public partial class Smsbrand
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

    [Column("smsbrand")]
    public Int64 smsbrand1
    {
      get;
      set;
    }

    public IEnumerable<SmsList> SmsLists { get; set; }
    [ConcurrencyCheck]
    public string smsbranddesc
    {
      get;
      set;
    }
  }
}
