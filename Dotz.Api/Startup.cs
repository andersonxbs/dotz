using AutoMapper;
using Dotz.Api.Helpers;
using Dotz.Domain.Contracts.Providers;
using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities;
using Dotz.Domain.Settings;
using Dotz.Infra.EF;
using Dotz.Infra.EF.Contexts;
using Dotz.Infra.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace Dotz.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddDbContext<SystemContext>(opt => 
            {
                opt.UseLazyLoadingProxies();
                opt.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            });

            services.AddDefaultIdentity<User>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<SystemContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped<ISecurityProvider, SecurityProvider>();

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                        {
                            NamingStrategy = new SnakeCaseNamingStrategy { ProcessDictionaryKeys = true }
                        };                        
                    });

            //JWT
            var jwtSettingsSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSettingsSection);

            var jwtsettings = jwtSettingsSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(jwtsettings.Secret);

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = jwtsettings.ValidAudience,
                        ValidIssuer = jwtsettings.ValidIssuer,
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
