using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GL_Sensors_v0._2.Data;
using GL_Sensors_v0._2.Models;
using Nancy.Json;

namespace GL_Sensors_v0._2.Controllers
{
    public class MeasurementsController : Controller
    {
        private readonly GL_Sensors_v0_2Context _context;

        public MeasurementsController(GL_Sensors_v0_2Context context)
        {
            _context = context;
        }

        // GET: Measurements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Measurement.ToListAsync());
        }

        // GET: Measurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurement = await _context.Measurement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurement == null)
            {
                return NotFound();
            }

            return View(measurement);
        }

        // GET: Measurements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Measurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CzujnikId,pm_1_0,pm_2_5,pm_10,temp,humidity,Time")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measurement);
        }

        // GET: Measurements/Edit/5
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
            return View(measurement);
        }

        // POST: Measurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CzujnikId,pm_1_0,pm_2_5,pm_10,temp,humidity,Time")] Measurement measurement)
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
            return View(measurement);
        }

        // GET: Measurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurement = await _context.Measurement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurement == null)
            {
                return NotFound();
            }

            return View(measurement);
        }

        // POST: Measurements/Delete/5
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


        //Wydaje mi się, że w ten sposób będziemy dodawać rekordy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddData(string json)
        {
            var serializer = new JavaScriptSerializer();
            dynamic jsondata = serializer.Deserialize<object>(json);
            Measurement measurement = new Measurement(); ;
            //for (int i=0;i<3;++i)
            //{

                //measurement.SensorId = select [Id] from _context.Sensor where [name]="device0"; //chciałem użyć tutaj LINQ, ale coś nie działa
                measurement.pm_1_0 = jsondata["device_0"]["pm_1_0"];
                measurement.pm_2_5 = jsondata["device_0"]["pm_2_5"];
                measurement.pm_10 = jsondata["device_0"]["pm_10"];
                measurement.temp = jsondata["device_0"]["temp"];
                measurement.humidity = jsondata["device_0"]["humidity"];

                if (ModelState.IsValid)
                {
                    _context.Add(measurement);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }
            //}
            
            return View(measurement);
        }
    }
}
