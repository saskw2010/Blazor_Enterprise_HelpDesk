using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("EmailsWhatsappQeueemail", Schema = "dbo")]
  public partial class EmailsWhatsappQeueemail
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
    public Int64 EmailqeueId
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Name
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? status
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? type
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string phoneFrom
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string phoneTo
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Fileurl
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string instanceid
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string whatsapppassword
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string credentialsUserName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string credentialsPassword
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Subjecttxt
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Bodytxt
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? BirthDate
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string EmailTo
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string BBCemails
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string senderemail
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string smtpHost
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string smtpEnableSsl
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public bool? UseDefaultCredentials
    {
      get;
      set;
    } = true;
    [ConcurrencyCheck]
    public Int64? smtpPort
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string whatsappResponse
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int? id
    {
      get;
      set;
    }
  }
}
