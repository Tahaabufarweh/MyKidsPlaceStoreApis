using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyKidsPlaceStore.Helpers;
using Service.UnitOfWork;

namespace MyKidsPlaceStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        
        private FileUploader fileUploaderHelper;
        public CategoryController(IServiceUnitOfWork serviceUnitOfWork, IWebHostEnvironment webHostEnvironmen)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            fileUploaderHelper = new FileUploader(webHostEnvironmen);

        }

        [HttpGet("{Id}")]
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

        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                IEnumerable<Category> categories = _serviceUnitOfWork.Category.Value.GetAll();
                return Ok(categories);
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
                BaseListResponse<Category> Category = _serviceUnitOfWork.Category.Value.List(baseSearch);
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
        public async Task<IActionResult> Create([FromForm] string categoryName, [FromForm]  string categoryNameAr,[FromForm] int status,[FromForm]  IFormFile file)
        {

            try
            {
                string fileName = await fileUploaderHelper.PostFile(file);
                Category category = new Category {
                 Id = 0,
                 CategoryName = categoryName,
                 CategoryNameAr = categoryNameAr,
                 Status = status,
                 ImagePath = fileName,
                };

                _serviceUnitOfWork.Category.Value.Add(category);
                return Ok(category);
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
        public async Task<IActionResult> Update([FromForm] int Id, [FromForm]  string categoryNameAr, [FromForm] string categoryName, [FromForm] int status, [FromForm]  IFormFile file)
        {

            try
            {
               
                Category category = _serviceUnitOfWork.Category.Value.Get(Id);
                bool isDeleted = fileUploaderHelper.DeleteFile(file.FileName);
                string fileName = await fileUploaderHelper.PostFile(file);

                category.CategoryName = categoryName;
                category.CategoryNameAr = categoryNameAr;
                category.Status = status;
                category.ImagePath = fileName;

                _serviceUnitOfWork.Category.Value.Update(category);
                return Ok(category);
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