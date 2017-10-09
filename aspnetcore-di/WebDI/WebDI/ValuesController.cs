using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDI
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		private readonly IDataServiceScoped _scopedService;
		private readonly IDataServiceTransient _transientService;
		private readonly IDataServiceSingleton _singletonService;
		private readonly OtherService _otherService;

		public ValuesController(IDataServiceScoped scopedService,
			IDataServiceTransient transientService,
			IDataServiceSingleton singletonService,
			OtherService otherService)
		{
			_scopedService = scopedService;
			_transientService = transientService;
			_singletonService = singletonService;
			_otherService = otherService;
		}

		// GET: api/values
		[HttpGet]
		public IActionResult Get()
		{

			var rv = new
			{
				singleton = _singletonService.GetValue(),
				transient = _transientService.GetValue(),
				scoped = _scopedService.GetValue(),
				otherService = new
				{
					singleton = _otherService.GetFromSingleton(),
					transient = _otherService.GetFromTransient(),
					scoped = _otherService.GetFromScoped()
				}
			};

			return Ok(rv);

		}

	}
}
