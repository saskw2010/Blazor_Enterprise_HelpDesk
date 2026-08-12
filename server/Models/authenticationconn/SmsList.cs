using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("SMSList", Schema = "dbo")]
  public partial class SmsList
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
    public Int64 SMSidauto
    {
      get;
      set;
    }

    public IEnumerable<SmsqueueList> SmsqueueLists { get; set; }
    public IEnumerable<SmsqueueListd> SmsqueueListds { get; set; }
    [ConcurrencyCheck]
    public Int64? smscatid
    {
      get;
      set;
    }
    public Smscatid Smscatid1 { get; set; }
    [ConcurrencyCheck]
    public Int64? smsbrand
    {
      get;
      set;
    }
    public Smsbrand Smsbrand1 { get; set; }
    [ConcurrencyCheck]
    public DateTime? smsdate
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string smsContent
    {
      get;
      set;
    }
  }
}
