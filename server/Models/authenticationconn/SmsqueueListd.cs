using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("SMSQUEUEListd", Schema = "dbo")]
  public partial class SmsqueueListd
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
    public Int64 SMSQUEUEID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? SMSidauto
    {
      get;
      set;
    }
    public SmsList SmsList { get; set; }
    [ConcurrencyCheck]
    public Int64? smsdone
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? SMSQUEUENumber
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? SCHDATE
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string smsContentDirct
    {
      get;
      set;
    }
  }
}
