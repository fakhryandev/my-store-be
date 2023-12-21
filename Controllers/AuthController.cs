using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] User user)
    {
        try
        {
            if (user == null)
            {
                return StatusCode(400, new
                {
                    success = false,
                    message = "Invalid user object"
                });
            }

            UserDTO? foundUser = _authRepository.GetUserByUsername(user.username);

            if (foundUser != null && PasswordHasher.VerifyPassword(foundUser.password, user.password))
            {
                var token = JwtGenerator.GenerateJwtToken();

                return Ok(token);
            }

            return Unauthorized("Username atau password salah");


        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = $"Internal Server Error:  {ex.Message}",
            });
        }
    }

    [HttpPost("register")]
    public ActionResult Register([FromBody] User user)
    {
        try
        {
            if (user == null)
            {
                return StatusCode(400, new
                {
                    success = false,
                    message = "Invalid user object"
                });
            }

            UserDTO? existUser = _authRepository.GetUserByUsername(user.username);

            if (existUser != null)
            {
                return StatusCode(400, new
                {
                    success = false,
                    message = "Username sudah terpakai"
                });
            }

            var hashedPassword = PasswordHasher.HashPassword(user.password);

            user.password = hashedPassword;

            _authRepository.AddUser(user);

            var response = new
            {
                status = true,
                message = "User berhasil dibuat",
            };
            return CreatedAtAction(null, response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = $"Internal Server Error:  {ex.Message}",
            });
        }
    }


}