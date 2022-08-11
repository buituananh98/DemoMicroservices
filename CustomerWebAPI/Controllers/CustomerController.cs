using CustomerWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _customerDbContext;
        //Create Constructor for CustomerController class
        public CustomerController(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        //Get all
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _customerDbContext.Customers;
        }

        //Get by id with hàm xử lý bất đồng bộ
        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<Customer>> GetById(int customerID)
        {
            var customer = await _customerDbContext.Customers.FindAsync(customerID);
            return customer;
        }

        //Insert
        [HttpPost]
        public async Task<ActionResult> Insert(Customer customer)
        {
            try
            {
                await _customerDbContext.Customers.AddAsync(customer);
                await _customerDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }

        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            try
            {
                var rs = _customerDbContext.Customers.SingleOrDefault(id => id.CustomerID == customer.CustomerID);
                if (rs != null)
                {
                    rs.CustomerName = customer.CustomerName;
                    rs.MobileNumber = customer.MobileNumber;
                    rs.Email = customer.Email;
                    await _customerDbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Delete
        [HttpDelete("{customerId:int}")]
        public async Task<ActionResult> DeleteById(int customerId)
        {
            try
            {
                var customer = await _customerDbContext.Customers.FindAsync(customerId);
                if (customer != null)
                {
                    _customerDbContext.Customers.Remove(customer);
                    await _customerDbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
