using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace MyKidsPlaceStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public BrandController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                Brand brand = _serviceUnitOfWork.Brand.Value.Get(Id);
                return Ok(brand);
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
        public IActionResult GetAllItems()
        {
            try
            {
                IEnumerable<Brand> brands = _serviceUnitOfWork.Brand.Value.GetAll();
                return Ok(brands);
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
                BaseListResponse<Brand> Brand = _serviceUnitOfWork.Brand.Value.List(baseSearch);
                return Ok(Brand);
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
        public IActionResult Create([FromBody] Brand brand)
        {
            try
            {
                _serviceUnitOfWork.Brand.Value.Add(brand);
                return Ok(brand);
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
        public IActionResult Update([FromBody] Brand brand)
        {
            try
            {
                _serviceUnitOfWork.Brand.Value.Update(brand);
                return Ok(brand);
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

        [HttpGet("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _serviceUnitOfWork.Brand.Value.Remove(Id);
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