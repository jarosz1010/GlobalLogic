using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GL_Sensors_v0._2.Data;
using GL_Sensors_v0._2.Models;

namespace GL_Sensors_v0._2.Controllers.Michal
{
    public class Measurements_Michal : Controller
    {
        private readonly GL_Sensors_v0_2Context _context;

        public Measurements_Michal(GL_Sensors_v0_2Context context)
        {
            _context = context;
        }

        // GET: Measurements_Michal
        public async Task<IActionResult> Index()
        {
            var gL_Sensors_v0_2Context = _context.Measurement.Include(m => m.Sensor);
            return View(await gL_Sensors_v0_2Context.ToListAsync());
        }

        // GET: Measurements_Michal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurement = await _context.Measurement
                .Include(m => m.Sensor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurement == null)
            {
                return NotFound();
            }

            return View(measurement);
        }

        // GET: Measurements_Michal/Create
        public IActionResult Create()
        {
            ViewData["SensorId"] = new SelectList(_context.Sensor, "Id", "Id");
            return View();
        }

        // POST: Measurements_Michal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SensorId,pm_1_0,pm_2_5,pm_10,temp,humidity,Time")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SensorId"] = new SelectList(_context.Sensor, "Id", "Id", measurement.SensorId);
            return View(measurement);
        }

        // GET: Measurements_Michal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurement = await _context.Measurement.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }
            ViewData["SensorId"] = new SelectList(_context.Sensor, "Id", "Id", measurement.SensorId);
            return View(measurement);
        }

        // POST: Measurements_Michal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SensorId,pm_1_0,pm_2_5,pm_10,temp,humidity,Time")] Measurement measurement)
        {
            if (id != measurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasurementExists(measurement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SensorId"] = new SelectList(_context.Sensor, "Id", "Id", measurement.SensorId);
            return View(measurement);
        }

        // GET: Measurements_Michal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurement = await _context.Measurement
                .Include(m => m.Sensor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurement == null)
            {
                return NotFound();
            }

            return View(measurement);
        }

        // POST: Measurements_Michal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var measurement = await _context.Measurement.FindAsync(id);
            _context.Measurement.Remove(measurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurement.Any(e => e.Id == id);
        }
    }
}
