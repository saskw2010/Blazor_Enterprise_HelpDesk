using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("SiteContent", Schema = "dbo")]
  public partial class SiteContent
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
    public Guid SiteContentID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string FileName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Path
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ContentType
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int? Length
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Byte[] Data
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Text
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Roles
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string RoleExceptions
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Users
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string UserExceptions
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Schedule
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ScheduleExceptions
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string CacheProfile
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? CreatedDate
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? ModifiedDate
    {
      get;
      set;
    }
  }
}
