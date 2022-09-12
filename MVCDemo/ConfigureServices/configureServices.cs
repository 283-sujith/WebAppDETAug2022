//using ContosoUniversity.Data;
//using Microsoft.EntityFrameworkCore;

//namespace MVCDemo.ConfigureServices
//{
//    public class configureServices
    
  
//        {
//            public Startup(IConfiguration configuration)
//            {
//                Configuration = configuration;
//            }

//            public IConfiguration Configuration { get; }

//            public void ConfigureServices(IServiceCollection services)
//            {
//                services.AddDbContext<SchoolContext>(options =>
//                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

//                services.AddControllersWithViews();
//            }
//        }
//    }
//}
