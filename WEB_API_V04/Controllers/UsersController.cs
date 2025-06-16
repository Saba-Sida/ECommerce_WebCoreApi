using Microsoft.AspNetCore.Mvc;
using WEB_API_V04.DTOs.User;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Mappers;
using WEB_API_V04.Repositories;
using WEB_API_V04.Services;

namespace WEB_API_V04.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepo;
        public UsersController(IUserRepository userRepository)
        {
            userRepo = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userModels = await userRepo.GetAllAsync();

            return Ok(userModels.Select(u => u.ToUserGetCompleteWithReferenceObjectsDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userModels = await userRepo.GetByIdAsync(id);

            if (userModels == null) return NotFound();

            return Ok(userModels.ToUserGetCompleteWithReferenceObjectsDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deletedObject = await userRepo.DeleteByIdAsync(id);

                if (deletedObject == null) return NotFound();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto userCreateDto)
        {
            // here to add the email verification

            try
            {
                var suchEmailAlreadyExists = await userRepo.AnyAsync(u => u.EMail == userCreateDto.EMail);

                if (suchEmailAlreadyExists) return Conflict("Account with such mail already exists");

                var userModelToCreate = userCreateDto.FromCreateDtoToUserModel();

                await userRepo.CreateAsync(userModelToCreate);

                return CreatedAtAction(nameof(GetUserById), new { id = userModelToCreate.UserId }, userModelToCreate.ToUserGetCompleteWithReferenceObjectsDto());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            try
            {
                var userModelToUpdate = userUpdateDto.FromUpdateDtoToUserModel();

                var userToUpdate = await userRepo.UpdateAsync(id, userModelToUpdate);

                if (userToUpdate == null) return NotFound();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogInDto userLogInDto)
        {
            var userToLogIn = await userRepo.FirstOrDefaultAsync(user => user.EMail == userLogInDto.EMail);

            if (userToLogIn == null) return NotFound("User not found with this email.");

            bool isCorrectPassword = PasswordService.IsCorrectPassword(userLogInDto.Password, userToLogIn.PasswordHash);

            if (isCorrectPassword) return Ok(userToLogIn.ToUserGetCompleteWithReferenceObjectsDto());

            return Unauthorized("Incorrect password.");
        }
    }
}
