﻿using Auth.DTOs;
using Auth.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> CreateRole(RoleDTO role) 
        {
            var result = await _roleManager.FindByNameAsync(role.RoleName);

            if (result == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role.RoleName));

                return Ok(new ResponseDTO
                {
                    Message = "Role Created",
                    IsSuccess = true,
                    StatusCode = 201
                });
            }

            return Ok(new ResponseDTO
            {
                Message = "Invalid role",
                StatusCode = 403
            });
        }
        [HttpGet]
        public async Task<ActionResult<List<IdentityRole>>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }
        [HttpPut]
        public async Task<ActionResult<IdentityRole>> UpdateRole(string id, RoleDTO role)
        {
            var change = await _roleManager.UpdateAsync(id, role);
        }
    }
}
