using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domains.Models;
using Domains.SearchModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace MyKidsPlaceStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public CategoryController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            try
            {
                Category Category = _serviceUnitOfWork.Category.Value.Get(Id);
                return Ok(Category);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult GetList([FromBody] BaseSearch baseSearch)
        {
            try
            {
                List<Category> Category = _serviceUnitOfWork.Category.Value.List(baseSearch);
                return Ok(Category);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult GetList(int Id, [FromBody] BaseSearch baseSearch)
        {
            try
            {
                List<Category> Category = _serviceUnitOfWork.Category.Value.List(baseSearch);
                return Ok(Category);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category Category)
        {
            try
            {
                _serviceUnitOfWork.Category.Value.Add(Category);
                return Ok(Category);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] Category Category)
        {
            try
            {
                _serviceUnitOfWork.Category.Value.Update(Category);
                return Ok(Category);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                _serviceUnitOfWork.Category.Value.Remove(Id);
                return Ok(true);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}