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
    public class SaleController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public SaleController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            try
            {
                Sale Sale = _serviceUnitOfWork.Sale.Value.Get(Id);
                return Ok(Sale);
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
                List<Sale> Sale = _serviceUnitOfWork.Sale.Value.List(baseSearch);
                return Ok(Sale);
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
        public IActionResult Create([FromBody] Sale Sale)
        {
            try
            {
                _serviceUnitOfWork.Sale.Value.Add(Sale);
                return Ok(Sale);
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
        public IActionResult Update([FromBody] Sale Sale)
        {
            try
            {
                _serviceUnitOfWork.Sale.Value.Update(Sale);
                return Ok(Sale);
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
                _serviceUnitOfWork.Sale.Value.Remove(Id);
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