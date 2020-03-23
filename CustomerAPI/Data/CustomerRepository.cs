using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Data
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly CustomerAPIContext Db;

        // CustomerRespository constructor
        public CustomerRepository(CustomerAPIContext context)
        {
            Db = context;
        }

        public Customer Add(Customer entity)
        {
            var newCustomer = Db.Customers.Add(entity).Entity;
            Db.SaveChanges();
            return newCustomer;
        }

        public void Edit(Customer entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return Db.Customers.FirstOrDefault(c => c.customerId == id);
        }


        public void Remove(int id)
        {
            var cust = Db.Customers.FirstOrDefault(c => c.customerId == id);
            Db.Customers.Remove(cust);
            Db.SaveChanges();
        }


        IEnumerable<Customer> IRepository<Customer>.GetAll()
        {
            return Db.Customers.ToList();
        }
      
    }
}
