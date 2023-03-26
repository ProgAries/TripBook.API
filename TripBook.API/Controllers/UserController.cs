using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripBook.BLL.DTO.Users;
using TripBook.BLL.Services;
using TripBook.DAL.Context;
using TripBook.DAL.Entities;
using TripBook.DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using TripBook.BLL.DTO.List;

namespace TripBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        
        private readonly UserService _service;
        private readonly ILogger _logger;
        public UserController( UserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult AddMember(AddUserDTO add)
        {
            _logger.LogInformation("UserControler's post called");
            try
            {
                _service.AddUser(add);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok();
        }

        [HttpPatch]
        public IActionResult AddCityToVisit(AddCityDTO add)
        {
            try
            {
                _service.AddCityToVisit(User.FindFirst(ClaimTypes.NameIdentifier).Value, add);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPatch("AddVC")]
        public IActionResult AddVisitedCity(AddVisitedCityDTO add)
        {
            try
            {
                _service.AddVisitedCity(User.FindFirst(ClaimTypes.NameIdentifier).Value, add);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.delete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }
        }

        [HttpPatch("deleteCity/{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _service.DeleteCity(User.FindFirst(ClaimTypes.NameIdentifier).Value, id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpPatch("deleteVisitedCity/{id}")]
        public IActionResult RemoveVCity(int id)
        {
            try
            {
                _service.DeleteVCity(User.FindFirst(ClaimTypes.NameIdentifier).Value, id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpPut]
        public IActionResult Edit(EditInfoUserDTO edit)
        {
            try
            {
                _service.EditUser(edit, User.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return Ok(edit);
        }


        [HttpGet("profil")]
        [Authorize]
        public ActionResult<string> GetOne()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            UserDTO user = _service.GetOne(id);
            return Ok(user);
        }

        [HttpGet("gallery/{id}")]
        public ActionResult<Gallery> GetThisGallery(int id)
        {
            GetgalleryDTO gallery = _service.Getgallery(id);
            return Ok(gallery);
        }

        [HttpPatch("AddGallery/{id}")]
        public IActionResult AddGallery(int id, AddGalleryDTO add)
        {
            try
            {
                _service.AddGallery(id, add);
            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }
            return Ok();
        }

        [HttpPatch("addImg/{id}")]
        public IActionResult AddImg(int id,  AddImgToGalleryDTO add)
        {
            try
            {
                _service.AddImg(id, add.Img);
            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }
            return Ok();
        }


        [HttpPatch("deleteImg/{id}")]
        public IActionResult DeleteImg(int id)
        {
            try
            {
                _service.DeleteImg(id);
            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }
            return Ok();
        }


    }
}
