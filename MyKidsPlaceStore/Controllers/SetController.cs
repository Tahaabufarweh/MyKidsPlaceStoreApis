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
    public class SetController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public SetController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            try
            {
                Item Item = _serviceUnitOfWork.Item.Value.Get(Id);
                return Ok(Item);
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
                List<Item> Item = _serviceUnitOfWork.Item.Value.List(baseSearch);
                return Ok(Item);
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
        public IActionResult Create([FromBody] Item Item)
        {
            try
            {
                _serviceUnitOfWork.Item.Value.Add(Item);
                return Ok(Item);
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
        public IActionResult Update([FromBody] Item Item)
        {
            try
            {
                _serviceUnitOfWork.Item.Value.Update(Item);
                return Ok(Item);
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
                _serviceUnitOfWork.Item.Value.Remove(Id);
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