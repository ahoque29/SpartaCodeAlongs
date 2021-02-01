//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;

//namespace CSharpSQLApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var customers = new List<Customer>();
//            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
//            {
//                connection.Open();
//                Console.WriteLine(connection.State);

//                using (var command = new SqlCommand("select * from customers", connection))
//                {
//                    SqlDataReader sqlReader = command.ExecuteReader();
//                    // loop while the reader has more data to read
//                    while (sqlReader.Read())
//                    {
//                        var customerID = sqlReader["CustomerID"].ToString();
//                        var contactName = sqlReader["ContactName"].ToString();
//                        var city = sqlReader["City"].ToString();

//                        var customer = new Customer { CustomerId = customerID, ContactName = contactName, City = city };

//                        customers.Add(customer);
//                    }
//                    sqlReader.Close();
//                }
//                // iterate over and output all customers
//                foreach (var c in customers)
//                {
//                    Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerId} and lives in {c.City}");
//                }

//                var newCustomer = new Customer()
//                {
//                    CustomerId = "BLOG",
//                    ContactName = "Joe Bloggs",
//                    City = "Birmingham",
//                    CompanyName = "ToysRUs"
//                };

//                string sqlDeleteString = $"DELETE FROM CUSTOMERS WHERE CustomerId = '{newCustomer.CustomerId}'";

//                using (var command = new SqlCommand(sqlDeleteString, connection))
//                {
//                    // if success this should equal 1
//                    int affected = command.ExecuteNonQuery();
//                }

//                using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
//                {
//                    // Using System.Data;
//                    updateCustomerCommand.CommandType = CommandType.StoredProcedure;
//                    // add parameters
//                    updateCustomerCommand.Parameters.AddWithValue("ID", "newCustomer.CustomerID");
//                    updateCustomerCommand.Parameters.AddWithValue("NewName", "Joe Bloggs Updated Name");
//                    // run the update
//                    int affected = updateCustomerCommand.ExecuteNonQuery();
//                }

//            }
//        }
//    }
//}


