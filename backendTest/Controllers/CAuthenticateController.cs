using BackendTest.Dtos;
using BackendTest.Models;
using BackendTest.repository;
using BackendTest.service;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CAuthenticateController : ControllerBase
    {
        private readonly AuthenticateRepository _authenticationUser;
        private readonly User _IUser;
        public CAuthenticateController(AuthenticateRepository authenticationUser)
        {
            this._authenticationUser = authenticationUser;

        }

        [HttpPost("/userValidateLogin")]
        public IActionResult Validate([FromBody] LoginRequest user)
        {
           
            try
            {
                if (user.UserMail == "" || user.UserPassword == "")
                {
                   
                    return BadRequest("Please enter the data");
                }
                else
                {

                    var UserValidated = this._authenticationUser.ValidateUser(user.UserMail , user.UserPassword );
                    if (UserValidated == null)
                    {
                        throw new Exception("User Not found");
                    }
                    //Create the token
                    string token = _authenticationUser.GenerateToken(UserValidated.UserId, UserValidated.UserName);
                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}