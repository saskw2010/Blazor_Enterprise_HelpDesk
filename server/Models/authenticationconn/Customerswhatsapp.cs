using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpdhelpdesk.Models.Authenticationconn
{
  [Table("Customerswhatsapp", Schema = "dbo")]
  public partial class Customerswhatsapp
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
    public Int64 Cstm_No
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Cstm_Nm
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Cstm_Nme
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? TSNEFNO
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Cstm_Email
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? Cstm_Tel
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? Cstm_Tel1
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64? Cstm_Tel2
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ModifiedBy
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? ModifiedOn
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string CreatedBy
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? CreatedOn
    {
      get;
      set;
    }
  }
}
