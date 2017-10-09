using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDI
{
	public interface IDataService
	{
		Guid GetValue();
	}

	public interface IDataServiceSingleton : IDataService
	{
	}

	public interface IDataServiceTransient : IDataService
	{
	}

	public interface IDataServiceScoped : IDataService
	{
	}

	public class DataService : IDataServiceSingleton, IDataServiceTransient, IDataServiceScoped
	{

		private readonly Guid _value;

		public DataService()
		{
			_value = Guid.NewGuid();
		}

		public Guid GetValue()
		{
			return _value;
		}
	}

	public class OtherService
	{

		private readonly IDataServiceScoped _scopedService;
		private readonly IDataServiceTransient _transientService;
		private readonly IDataServiceSingleton _singletonService;

		public OtherService(IDataServiceScoped scopedService, IDataServiceTransient transientService, IDataServiceSingleton singletonService)
		{
			_scopedService = scopedService;
			_transientService = transientService;
			_singletonService = singletonService;
		}

		public Guid GetFromScoped()
		{
			return _scopedService.GetValue();
		}

		public Guid GetFromSingleton()
		{
			return _singletonService.GetValue();
		}

		public Guid GetFromTransient()
		{
			return _transientService.GetValue();
		}

	}


}
