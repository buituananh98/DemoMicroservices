using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryServices.Models;
using ProductServices.Models;

namespace CategoryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryDbContext _categoryDbContext;

        //Create Constructor for CustomerController class
        public CategoryController(CategoryDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
        }

        //Get all
        [HttpGet]
        [Route("entries")]
        public ActionResult<IEnumerable<Category>> GetCustomers()
        {
            return _categoryDbContext.Categories;
        }

        //Get by id with hàm xử lý bất đồng bộ
        [HttpGet("{categoryId:int}")]
        public async Task<ActionResult<Category>> GetById(int categoryId)
        {
            var category = await _categoryDbContext.Categories.FindAsync(categoryId);
            if(category != null)
            {
                //var product = await _productDbContext 
            }
            return category;
        }

        //Insert
        [HttpPost]
        public async Task<ActionResult> Insert(Category category)
        {
            try
            {
                await _categoryDbContext.Categories.AddAsync(category);
                await _categoryDbContext.SaveChangesAsync();
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
        public async Task<ActionResult> Update(Category category)
        {
            try
            {
                var rs = _categoryDbContext.Categories.SingleOrDefault(id => id.CategoryID == category.CategoryID);
                if (rs != null)
                {
                    rs.CategoryName = category.CategoryName;
                    rs.Description = category.Description;
                    await _categoryDbContext.SaveChangesAsync();
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
        [HttpDelete("{categoryId:int}")]
        public async Task<ActionResult> DeleteById(int categoryId)
        {
            try
            {
                var category = await _categoryDbContext.Categories.FindAsync(categoryId);
                if (category != null)
                {
                    _categoryDbContext.Categories.Remove(category);
                    await _categoryDbContext.SaveChangesAsync();
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
