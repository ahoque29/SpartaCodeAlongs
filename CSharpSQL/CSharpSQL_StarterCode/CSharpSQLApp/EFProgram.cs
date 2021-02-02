using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSQLApp
{
	public class EFProgram
	{
		public static void Main()
		{
			// specify the data source
			using var db = new NorthwindContext();
			Console.WriteLine(db.ContextId);

			//// iterate over and aoutput all customers
			//foreach (var c in db.Customers)
			//{
			//	Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerId} and lives in {c.City}");
			//}

			//// delete a customer
			//var selectedCustomer = db.Customers.Where(c => c.CustomerId == "BLOG");
			//db.Customers.RemoveRange(selectedCustomer);
			//db.SaveChanges();

			//// add a new customer
			//var newCustomer = new Customer()
			//{
			//	CustomerId = "BLOG",
			//	ContactName = "Joe Bloggs",
			//	CompanyName = "ToysRUs"
			//};
			//db.Customers.Add(newCustomer);
			//db.SaveChanges();

			//// update the customer
			//var customer = db.Customers.Where(c => c.CustomerId == "BLOG").FirstOrDefault();
			//customer.City = "Paris";
			//db.SaveChanges();

			// Trying out LINQ queries
			// define the query
			var query = db.Customers.Where(c => c.CustomerId == "BONAP");
			// execute the query
			var selected = query.FirstOrDefault();
			// define and execute in one line
			var selected2 = db.Customers.Where(c => c.CustomerId == "BONAP").FirstOrDefault();
			// LINQ to SQL
			var selected3 = db.Customers.Find("BLOG");

			// Query syntax
			Console.WriteLine("Query Syntax");
			var query1 =
				from c in db.Customers
				where c.City == "London"
				orderby c.ContactName
				select c;
			foreach (var cust in query1)
			{
				Console.WriteLine(cust.GetFullName());
			}

			// Method Syntax
			Console.WriteLine("MethodSyntax");
			IEnumerable<Customer> query2 = db.Customers
				.Where(c => c.City == "London")
				.OrderBy(c => c.ContactName);
			foreach (var cust in query2)
			{
				Console.WriteLine(cust.GetFullName());
			}
		}
	}
}
