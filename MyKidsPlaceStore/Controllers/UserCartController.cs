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
    public class UserCartController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public UserCartController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            try
            {
                UserCart UserCart = _serviceUnitOfWork.UserCart.Value.Get(Id);
                return Ok(UserCart);
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
                List<UserCart> UserCart = _serviceUnitOfWork.UserCart.Value.List(baseSearch);
                return Ok(UserCart);
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
        public IActionResult Create([FromBody] UserCart UserCart)
        {
            try
            {
                _serviceUnitOfWork.UserCart.Value.Add(UserCart);
                return Ok(UserCart);
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
        public IActionResult Update([FromBody] UserCart UserCart)
        {
            try
            {
                _serviceUnitOfWork.UserCart.Value.Update(UserCart);
                return Ok(UserCart);
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
                _serviceUnitOfWork.UserCart.Value.Remove(Id);
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