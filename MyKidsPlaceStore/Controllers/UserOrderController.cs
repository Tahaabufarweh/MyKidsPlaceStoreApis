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
    public class UserOrderController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public UserOrderController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            try
            {
                UserOrder UserOrder = _serviceUnitOfWork.UserOrder.Value.Get(Id);
                return Ok(UserOrder);
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
                List<UserOrder> UserOrder = _serviceUnitOfWork.UserOrder.Value.List(baseSearch);
                return Ok(UserOrder);
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
        public IActionResult Create([FromBody] UserOrder UserOrder)
        {
            try
            {
                _serviceUnitOfWork.UserOrder.Value.Add(UserOrder);
                return Ok(UserOrder);
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
        public IActionResult Update([FromBody] UserOrder UserOrder)
        {
            try
            {
                _serviceUnitOfWork.UserOrder.Value.Update(UserOrder);
                return Ok(UserOrder);
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
                _serviceUnitOfWork.UserOrder.Value.Remove(Id);
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