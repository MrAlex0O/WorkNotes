using Logic.DTOs.User;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserWriteService _userWriteService;
        IUserReadService _userReadService;
        public UserController(IUserWriteService userWriteService, IUserReadService userReadService)
        {
            _userWriteService = userWriteService;
            _userReadService = userReadService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<GetUserResponse>>> GetAll()
        {
            try
            {
                return Ok(_userReadService.GetAll());

            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegistrationRequest reg)
        {
            try
            {
                _userWriteService.Add(reg);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ChangePasswordRequest req)
        {
            try
            {
                _userWriteService.UpdatePassword(id, req);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                _userWriteService.Delete(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
