using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Cpdhelpdesk.Models.Authenticationconn;

namespace Cpdhelpdesk.Data
{
  public partial class AuthenticationconnContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public AuthenticationconnContext(DbContextOptions<AuthenticationconnContext> options):base(options)
    {
    }

    public AuthenticationconnContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .HasOne(i => i.HelpDeskStatus)
              .WithMany(i => i.HelpDeskTickets)
              .HasForeignKey(i => i.TicketStatus)
              .HasPrincipalKey(i => i.TicketStatus);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .HasOne(i => i.LocationList)
              .WithMany(i => i.HelpDeskTickets)
              .HasForeignKey(i => i.locationID)
              .HasPrincipalKey(i => i.locationID);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .HasOne(i => i.ServiceCatglist)
              .WithMany(i => i.HelpDeskTickets)
              .HasForeignKey(i => i.ServiceCatgID)
              .HasPrincipalKey(i => i.ServiceCatgID);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .HasOne(i => i.ServicesList)
              .WithMany(i => i.HelpDeskTickets)
              .HasForeignKey(i => i.ServiceID)
              .HasPrincipalKey(i => i.ServiceID);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>()
              .HasOne(i => i.HelpDeskTicket)
              .WithMany(i => i.HelpDeskTicketDetails)
              .HasForeignKey(i => i.HelpDeskTicketId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>()
              .HasOne(i => i.LocalizationResource)
              .WithMany(i => i.LocalizationResourceTranslations)
              .HasForeignKey(i => i.ResourceId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.ServicesList>()
              .HasOne(i => i.ServiceCatglist)
              .WithMany(i => i.ServicesLists)
              .HasForeignKey(i => i.ServiceCatgID)
              .HasPrincipalKey(i => i.ServiceCatgID);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .HasOne(i => i.Smscatid1)
              .WithMany(i => i.SmsLists)
              .HasForeignKey(i => i.smscatid)
              .HasPrincipalKey(i => i.smscatid1);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .HasOne(i => i.Smsbrand1)
              .WithMany(i => i.SmsLists)
              .HasForeignKey(i => i.smsbrand)
              .HasPrincipalKey(i => i.smsbrand1);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .HasOne(i => i.SmsList)
              .WithMany(i => i.SmsqueueLists)
              .HasForeignKey(i => i.SMSidauto)
              .HasPrincipalKey(i => i.SMSidauto);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>()
              .HasOne(i => i.SmsList)
              .WithMany(i => i.SmsqueueListds)
              .HasForeignKey(i => i.SMSidauto)
              .HasPrincipalKey(i => i.SMSidauto);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>()
              .HasOne(i => i.EmpDepartment)
              .WithMany(i => i.TelphonUsersLists)
              .HasForeignKey(i => i.DepartmentID)
              .HasPrincipalKey(i => i.EmpDepartmentID);
        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>()
              .HasOne(i => i.EmpJoblist)
              .WithMany(i => i.TelphonUsersLists)
              .HasForeignKey(i => i.Jobid)
              .HasPrincipalKey(i => i.EmpjoblistID);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.status)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.type)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.UseDefaultCredentials)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.smtpPort)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.status)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.type)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.UseDefaultCredentials)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.smtpPort)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .Property(p => p.TicketGUID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .Property(p => p.TicketStatus)
              .HasDefaultValueSql("(N'New')");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .Property(p => p.TicketDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>()
              .Property(p => p.TicketDetailDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SiteContent>()
              .Property(p => p.SiteContentID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SiteContent>()
              .Property(p => p.ContentType)
              .HasDefaultValueSql("('text/plain')");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .Property(p => p.smscatid)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .Property(p => p.smsbrand)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .Property(p => p.smsdate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.smsdone)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.SCHDATE)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.Ver)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>()
              .Property(p => p.smsdone)
              .HasDefaultValueSql("((0))");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>()
              .Property(p => p.SCHDATE)
              .HasDefaultValueSql("(getdate())");


        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>()
              .Property(p => p.ModifiedOn)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>()
              .Property(p => p.CreatedOn)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.DeviceCode>()
              .Property(p => p.CreationTime)
              .HasColumnType("datetime2");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.DeviceCode>()
              .Property(p => p.Expiration)
              .HasColumnType("datetime2");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.BirthDate)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.BirthDate)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .Property(p => p.TicketDate)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>()
              .Property(p => p.TicketDetailDate)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource>()
              .Property(p => p.ModificationDate)
              .HasColumnType("datetime2");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>()
              .Property(p => p.ModificationDate)
              .HasColumnType("datetime2");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName>()
              .Property(p => p.ModifiedOn)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName>()
              .Property(p => p.CreatedOn)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant>()
              .Property(p => p.CreationTime)
              .HasColumnType("datetime2");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant>()
              .Property(p => p.Expiration)
              .HasColumnType("datetime2");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant>()
              .Property(p => p.ConsumedTime)
              .HasColumnType("datetime2");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SiteContent>()
              .Property(p => p.CreatedDate)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SiteContent>()
              .Property(p => p.ModifiedDate)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .Property(p => p.smsdate)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.SCHDATE)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>()
              .Property(p => p.SCHDATE)
              .HasColumnType("datetime");

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>()
              .Property(p => p.Cstm_No)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>()
              .Property(p => p.TSNEFNO)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>()
              .Property(p => p.Cstm_Tel)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>()
              .Property(p => p.Cstm_Tel1)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>()
              .Property(p => p.Cstm_Tel2)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.EmailqeueId)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.status)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.type)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>()
              .Property(p => p.smtpPort)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.EmailqeueId)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.status)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.type)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.smtpPort)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>()
              .Property(p => p.id)
              .HasPrecision(10, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment>()
              .Property(p => p.EmpDepartmentID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist>()
              .Property(p => p.EmpjoblistID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .Property(p => p.Id)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .Property(p => p.locationID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .Property(p => p.ServiceCatgID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>()
              .Property(p => p.ServiceID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>()
              .Property(p => p.Id)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>()
              .Property(p => p.HelpDeskTicketId)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>()
              .Property(p => p.ResourceId)
              .HasPrecision(10, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.LocationList>()
              .Property(p => p.locationID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName>()
              .Property(p => p.controllerNameid)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist>()
              .Property(p => p.ServiceCatgID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.ServicesList>()
              .Property(p => p.ServiceID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.ServicesList>()
              .Property(p => p.ServiceCatgID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SiteContent>()
              .Property(p => p.Length)
              .HasPrecision(10, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .Property(p => p.SMSidauto)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .Property(p => p.smscatid)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsList>()
              .Property(p => p.smsbrand)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Smsbrand>()
              .Property(p => p.smsbrand1)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.Smscatid>()
              .Property(p => p.smscatid1)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.SMSQUEUEID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.SMSidauto)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.smsdone)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.SMSQUEUENumber)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>()
              .Property(p => p.Ver)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>()
              .Property(p => p.SMSQUEUEID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>()
              .Property(p => p.SMSidauto)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>()
              .Property(p => p.smsdone)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>()
              .Property(p => p.SMSQUEUENumber)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist>()
              .Property(p => p.sprModulecatid)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist>()
              .Property(p => p.InstallcatModule)
              .HasPrecision(19, 4);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.TblPage>()
              .Property(p => p.id)
              .HasPrecision(10, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.TblPage>()
              .Property(p => p.Sort)
              .HasPrecision(10, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>()
              .Property(p => p.DepartmentID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>()
              .Property(p => p.Jobid)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>()
              .Property(p => p.TelphonUsersListID)
              .HasPrecision(19, 0);

        builder.Entity<Cpdhelpdesk.Models.Authenticationconn.UserAudit>()
              .Property(p => p.UserAuditId)
              .HasPrecision(19, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp> Customerswhatsapps
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.DeviceCode> DeviceCodes
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue> EmailsWhatsappQeues
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail> EmailsWhatsappQeueemails
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment> EmpDepartments
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist> EmpJoblists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus> HelpDeskStatuses
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket> HelpDeskTickets
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail> HelpDeskTicketDetails
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> LocalizationResources
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation> LocalizationResourceTranslations
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.LocationList> LocationLists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName> MrtcontrollerNames
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant> PersistedGrants
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist> ServiceCatglists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.ServicesList> ServicesLists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.SiteContent> SiteContents
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.SmsList> SmsLists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.Smsbrand> Smsbrands
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.Smscatid> Smscatids
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList> SmsqueueLists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd> SmsqueueListds
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> SoftwareModulescatlists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.TblPage> TblPages
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList> TelphonUsersLists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList> TicketRequesterUsersLists
    {
      get;
      set;
    }

    public DbSet<Cpdhelpdesk.Models.Authenticationconn.UserAudit> UserAudits
    {
      get;
      set;
    }
  }
}
