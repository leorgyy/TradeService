using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Norbit.Crm.Leontev.DataLibrary.Abstractions;
using Norbit.Crm.Leontev.DataLibrary.DbConnection;
using Norbit.Crm.Leontev.DataLibrary.Repositories;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Norbit.Crm.Leontev.DataLibrary;

namespace Norbit.Crm.Leontev.WebApp
{
	/// <summary>
	/// Запуск приложения.
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Конфигурация.
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Конструктор класса.
		/// </summary>
		/// <param name="configuration">Конфигурация.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Конфигурация сервисов.
		/// </summary>
		/// <param name="services">Коллекция сервисов.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("Default", builder =>
				{
					builder.WithOrigins(Configuration.GetSection("AllowOrigins").GetValue<string>("WebClient"))
						   .AllowAnyHeader()
						   .AllowAnyMethod()
						   .AllowCredentials();
				});
			});

			services.AddControllers();

			services.AddSwaggerGen();

			services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
				.AddNegotiate();

			services.AddAuthorization(options =>
			{
				options.FallbackPolicy = options.DefaultPolicy;
			});

			services.AddLinqToDBContext<TradeDbConnection>((provider, options) =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
					   .UseDefaultLogging(provider));

			services.AddScoped<IWorkUnit, WorkUnit>();
			services.AddScoped<IDataRepository, DataRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
		}

		/// <summary>
		/// Конфигурация конвейеров.
		/// </summary>
		/// <param name="app">Билдер приложения.</param>
		/// <param name="env">Среда выполнения.</param>
		public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors("Default");

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
