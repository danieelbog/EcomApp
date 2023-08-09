using Ecom.BFF.DTOs.Account;
using Ecom.Services.Account.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.BFF.Core.Models;

namespace Ecom.BFF.Controllers
{
    public class AccountController: Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("/getAuthUser")]
        public async Task<IActionResult> GetAuthUser()
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            if(applicationUser == null)
                throw new UserNotFoundServiceException();

            return Ok(applicationUser);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(applicationUser, registerDto.Password);
            if (!result.Succeeded)
                throw new UserInvalidCredentialsServiceException();

            await _signInManager.SignInAsync(applicationUser, false);
            var userDto = new UserDto(applicationUser.UserName, applicationUser.Email);
            return Ok(userDto);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var applicationUser = await _userManager.FindByNameAsync(loginDto.Username);
            if (applicationUser == null)
                throw new UserNotFoundServiceException();

            var result = await _signInManager.PasswordSignInAsync(applicationUser, loginDto.Password, false, false);
            if (!result.Succeeded)
                throw new UserInvalidCredentialsServiceException();

            var userDto = new UserDto(applicationUser.UserName, applicationUser.Email);
            return Ok(userDto);
        }

        [HttpPost]
        [Route("/logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
