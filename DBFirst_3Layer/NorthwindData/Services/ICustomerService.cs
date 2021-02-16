using System.Collections.Generic;

namespace NorthwindData.Services
{
	public interface ICustomerService
	{
		List<Customer> GetCustomerList();

		Customer GetCustomerById(string customId);

		void SaveCustomerChanges();
	}
}