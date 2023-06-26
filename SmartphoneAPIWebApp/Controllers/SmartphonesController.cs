﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartphoneAPIWebApp.Models;

namespace SmartphoneAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartphonesController : ControllerBase
    {
        private readonly SmartPhoneAPIContext _context;

        public SmartphonesController(SmartPhoneAPIContext context)
        {
            _context = context;
        }

        // GET: api/Smartphones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Smartphone>>> GetSmartphones()
        {
          if (_context.Smartphones == null)
          {
              return NotFound();
          }
            return await _context.Smartphones.ToListAsync();
        }

        // GET: api/Smartphones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Smartphone>> GetSmartphone(int id)
        {
          if (_context.Smartphones == null)
          {
              return NotFound();
          }
            var smartphone = await _context.Smartphones.FindAsync(id);

            if (smartphone == null)
            {
                return NotFound();
            }

            return smartphone;
        }

        // PUT: api/Smartphones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmartphone(int id, Smartphone smartphone)
        {
            if (id != smartphone.Id)
            {
                return BadRequest();
            }

            _context.Entry(smartphone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartphoneExists(id))
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

        // POST: api/Smartphones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Smartphone>> PostSmartphone(Smartphone smartphone)
        {
          if (_context.Smartphones == null)
          {
              return Problem("Entity set 'SmartPhoneAPIContext.Smartphones'  is null.");
          }
            _context.Smartphones.Add(smartphone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmartphone", new { id = smartphone.Id }, smartphone);
        }

        // DELETE: api/Smartphones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmartphone(int id)
        {
            if (_context.Smartphones == null)
            {
                return NotFound();
            }
            var smartphone = await _context.Smartphones.FindAsync(id);
            if (smartphone == null)
            {
                return NotFound();
            }

            _context.Smartphones.Remove(smartphone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmartphoneExists(int id)
        {
            return (_context.Smartphones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
