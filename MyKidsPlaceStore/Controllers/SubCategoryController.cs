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
    public class SubCategoryController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public SubCategoryController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                SubCategory SubCategory = _serviceUnitOfWork.SubCategory.Value.Get(Id);
                return Ok(SubCategory);
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
                BaseListResponse<SubCategory> SubCategory = _serviceUnitOfWork.SubCategory.Value.List(baseSearch);
                return Ok(SubCategory);
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

        [HttpPost("{categoryId}")]
        public IActionResult GetSubCategoryByCategoryId([FromRoute] int categoryId, [FromBody] BaseSearch baseSearch)
        {
            try
            {
                BaseListResponse<SubCategory> SubCategory = _serviceUnitOfWork.SubCategory.Value.GetSubCategoryByCategoryId(categoryId, baseSearch);
                return Ok(SubCategory);
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
        public IActionResult Create([FromBody] SubCategory SubCategory)
        {
            try
            {

                _serviceUnitOfWork.SubCategory.Value.Add(SubCategory);
                return Ok(SubCategory);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] SubCategory SubCategory)
        {
            try
            {
                _serviceUnitOfWork.SubCategory.Value.Update(SubCategory);
                return Ok(SubCategory);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _serviceUnitOfWork.SubCategory.Value.Remove(Id);
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