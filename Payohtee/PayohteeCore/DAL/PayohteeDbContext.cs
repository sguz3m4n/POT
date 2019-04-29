using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Payohtee.Models.Customer;
using PayohteeCore.Properties;

namespace Payohtee.Data.DAL
{
    public class PayohteeDbContext : DbContext
    {
        #region Constructor

        public PayohteeDbContext(DbContextOptions<PayohteeDbContext> options) : base(options)
        {

        }

        #endregion

        #region Properties

        public string Devconn { get; set; }
        public string Stageconn { get; set; }
        public string Prodconn { get; set; }
        public IConfiguration Configuration { get; set; }
        public DbSet<Company> DbContextCompany { get; set; }
        //public DbSet<Contact> DbContextContacts { get; set; }
        //public DbSet<PolicePayment> DbContextPolicePayments { get; set; }
        //public DbSet<CustomsPayment> DbContextCustomsPayments { get; set; }
        //public DbSet<CustomsOfficer> DbContextCustomsOfficers { get; set; }
        //public DbSet<PoliceOfficer> DbConextPoliceOfficers { get; set; }
        //public DbSet<Equipment> DbContextEquipment { get; set; }
        //public DbSet<Service> DbContextService { get; set; }
        //public DbSet<Event> DbContextEvent { get; set; }
        //public DbSet<PayRate> DbContextPayRate { get; set; }

        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //use this for azure database connectivity (stage)
                Stageconn = Resources.connstage;
                //use this for azure database connectivity (production)
                Prodconn = Resources.connprod;
                //use this for local database connectivity (dev)
                Devconn = Resources.connlocal;

                optionsBuilder.UseSqlServer(Stageconn,
                        provideroptions => provideroptions.CommandTimeout(60))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<PoliceOfficer>().ToTable("PoliceOfficer");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        #endregion
    }
}
