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
    public class OrderController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OrderController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                Orders order = _serviceUnitOfWork.Order.Value.Get(Id);
                return Ok(order);
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
                IEnumerable<Orders> orders = _serviceUnitOfWork.Order.Value.GetAll();
                return Ok(orders);
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
                BaseListResponse<Orders> Order = _serviceUnitOfWork.Order.Value.List(baseSearch);
                return Ok(Order);
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
        public IActionResult Create([FromBody] Orders order)
        {
            try
            {
                _serviceUnitOfWork.Order.Value.Add(order);
                return Ok(order);
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
        public IActionResult Update([FromBody] Orders order)
        {
            try
            {
                _serviceUnitOfWork.Order.Value.Update(order);
                return Ok(order);
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
                _serviceUnitOfWork.Order.Value.Remove(Id);
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