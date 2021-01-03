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
    public class ColorController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ColorController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                Colour color = _serviceUnitOfWork.Color.Value.Get(Id);
                return Ok(color);
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
                IEnumerable<Colour> colors = _serviceUnitOfWork.Color.Value.GetAll();
                return Ok(colors);
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
                BaseListResponse<Colour> Color = _serviceUnitOfWork.Color.Value.List(baseSearch);
                return Ok(Color);
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
        public IActionResult Create([FromBody] Colour color)
        {
            try
            {
                _serviceUnitOfWork.Color.Value.Add(color);
                return Ok(color);
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
        public IActionResult Update([FromBody] Colour color)
        {
            try
            {
                _serviceUnitOfWork.Color.Value.Update(color);
                return Ok(color);
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
                _serviceUnitOfWork.Color.Value.Remove(Id);
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