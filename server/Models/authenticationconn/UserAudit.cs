using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("UserAudit", Schema = "dbo")]
  public partial class UserAudit
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
    public Int64 UserAuditId
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string UserId
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTimeOffset? Timestamp
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string AuditEvent
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string IpAddress
    {
      get;
      set;
    }
  }
}
