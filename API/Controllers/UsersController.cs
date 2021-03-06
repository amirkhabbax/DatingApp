using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
        {
            if(_context.Users == null){
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        //api/users/2
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser?>> GetUser(int id)
        {
            if(_context.Users == null){
                return NotFound();
            }
            return await _context.Users.FindAsync(id);
        }
    }
}