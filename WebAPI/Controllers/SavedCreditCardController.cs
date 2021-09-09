using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedCreditCardController : ControllerBase
    {
        ISavedCreditCardService _savedcreditCardService;

        public SavedCreditCardController(ISavedCreditCardService savedcreditCardService)
        {
            _savedcreditCardService = savedcreditCardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _savedcreditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _savedcreditCardService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUser(int userId)
        {
            var result = _savedcreditCardService.GetByUser(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(SavedCreditCard savedCreditCard)
        {
            var result = _savedcreditCardService.Add(savedCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SavedCreditCard savedCreditCard)
        {
            var result = _savedcreditCardService.Update(savedCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SavedCreditCard savedCreditCard)
        {
            var result = _savedcreditCardService.Delete(savedCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("checkthecard")]
        public IActionResult CheckTheCreditCard(SavedCreditCard savedCreditCard)
        {
            var result = _savedcreditCardService.CheckTheCreditCard(savedCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
