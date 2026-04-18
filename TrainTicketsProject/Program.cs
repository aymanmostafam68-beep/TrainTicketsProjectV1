using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using TrainTicketsProject.ApplicationDB;

namespace TrainTicketsProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDB.ApplicationDataAccess>
             (
             e => e.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
               );


            builder.Services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>
                (e =>
                {
                    e.User.RequireUniqueEmail = true;
                    e.Password.RequiredLength = 8;
                    e.Lockout.MaxFailedAccessAttempts = 3;

                    e.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                }

                ).AddEntityFrameworkStores<ApplicationDB.ApplicationDataAccess>()
                .AddDefaultTokenProviders();






            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IRepository<Models.GeneralSetting>, Repository<Models.GeneralSetting>>();
            builder.Services.AddScoped<IRepository<Models.Train>, Repository<Models.Train>>();
            builder.Services.AddScoped<IRepository<Models.Carriage>, Repository<Models.Carriage>>();
            builder.Services.AddScoped<IRepository<Models.CarriageSeat>, Repository<Models.CarriageSeat>>();
            builder.Services.AddScoped<IRepository<Models.Booking>, Repository<Models.Booking>>();
            builder.Services.AddScoped<IRepository<Models.Transaction>, Repository<Models.Transaction>>();
            builder.Services.AddScoped<IRepository<Models.TransactionEntry>, Repository<Models.TransactionEntry>>();
            builder.Services.AddScoped<IRepository<Models.TripSchedule>, Repository<Models.TripSchedule>>();




            builder.Services.AddScoped<IRepository<ApplicationUserOTP>, Repository<ApplicationUserOTP>>();

            builder.Services.AddScoped<ApplicationDB.ApplicationDataAccess, ApplicationDB.ApplicationDataAccess>();
            builder.Services.AddScoped<IAccountService, AccountService>();



            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddScoped<IDbInitialize, DbInitialize>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();





       

            var app = builder.Build();

             // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            using (var scope = app.Services.CreateScope())
            {
                var dbInitialize = scope.ServiceProvider.GetRequiredService<IDbInitialize>();
               await dbInitialize.Initialize();
            }



            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
