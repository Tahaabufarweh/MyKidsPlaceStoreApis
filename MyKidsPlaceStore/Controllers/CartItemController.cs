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
    public class CartItemController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public CartItemController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            try
            {
                CartItem brand = _serviceUnitOfWork.CartItem.Value.Get(Id);
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
        public IActionResult GetList([FromBody] BaseSearch baseSearch)
        {
            try
            {
                List<CartItem> CartItem = _serviceUnitOfWork.CartItem.Value.List(baseSearch);
                return Ok(CartItem);
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
        public IActionResult Create([FromBody] CartItem cartItem)
        {
            try
            {
                _serviceUnitOfWork.CartItem.Value.Add(cartItem);
                return Ok(cartItem);
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

        [HttpGet]
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