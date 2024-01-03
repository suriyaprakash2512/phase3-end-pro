﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppEndProject.Data;
using WebAppEndProject.Models;

namespace WebAppEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptMastersController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public DeptMastersController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/DeptMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeptMaster>>> GetDeptMaster()
        {
          if (_context.DeptMaster == null)
          {
              return NotFound();
          }
            return await _context.DeptMaster.ToListAsync();
        }

        // GET: api/DeptMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeptMaster>> GetDeptMaster(int id)
        {
          if (_context.DeptMaster == null)
          {
              return NotFound();
          }
            var deptMaster = await _context.DeptMaster.FindAsync(id);

            if (deptMaster == null)
            {
                return NotFound();
            }

            return deptMaster;
        }

        // PUT: api/DeptMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeptMaster(int id, DeptMaster deptMaster)
        {
            if (id != deptMaster.DeptCode)
            {
                return BadRequest();
            }

            _context.Entry(deptMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DeptMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeptMaster>> PostDeptMaster(DeptMaster deptMaster)
        {
          if (_context.DeptMaster == null)
          {
              return Problem("Entity set 'EmployeeDbContext.DeptMaster'  is null.");
          }
            _context.DeptMaster.Add(deptMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeptMaster", new { id = deptMaster.DeptCode }, deptMaster);
        }

        // DELETE: api/DeptMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeptMaster(int id)
        {
            if (_context.DeptMaster == null)
            {
                return NotFound();
            }
            var deptMaster = await _context.DeptMaster.FindAsync(id);
            if (deptMaster == null)
            {
                return NotFound();
            }

            _context.DeptMaster.Remove(deptMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeptMasterExists(int id)
        {
            return (_context.DeptMaster?.Any(e => e.DeptCode == id)).GetValueOrDefault();
        }
    }
}
