using Academica.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academica.Controllers;

public class OgrenciController:Controller
{
    private readonly DataContext _context;
    public OgrenciController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        
        return View();
    }

    public async Task<IActionResult> Index()
    {
        var ogrenciler = await _context.Ogrenciler.ToListAsync();
        return View(ogrenciler);
        
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(Ogrenci model )
    {
        _context.Ogrenciler.Add(model);
        await _context.SaveChangesAsync();
         return RedirectToAction("Index");
       
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        var ogr = await _context.Ogrenciler.FindAsync(id);
        if (ogr == null)
        {
            return NotFound();
        }
        
        return View(ogr);
            
        
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Edit(int id , Ogrenci model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException )
            {
                if (!_context.Ogrenciler.Any(e => e.Id == model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        return View(model);
    }
}

