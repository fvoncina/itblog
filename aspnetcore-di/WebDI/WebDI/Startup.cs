using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebDI
{
	public class Startup
	{

		public void ConfigureServices(IServiceCollection services)
		{

			// Registro como singleton
			services.AddSingleton<IDataServiceSingleton, DataService>();

			// Registro como scoped
			services.AddScoped<IDataServiceScoped, DataService>();

			// Registro como transient
			services.AddTransient<IDataServiceTransient, DataService>();

			// OtherService como scoped
			services.AddScoped<OtherService>();

			// Agrega los servicios de MVC
			services.AddMvc();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();

		}
	}
}
