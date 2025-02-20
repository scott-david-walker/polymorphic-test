using Api.Controllers.Framework;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Api.Controllers;

[Route("[controller]")]
public class TestController : ApiController
{
    private readonly ApplicationDbContext _context;

    public TestController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var d = new Derived()
        {
            Id = Guid.NewGuid(),
            SomeData = 42
        };
        _context.SomeEntity.Add(new SomeEntity()
        {
            Id = Guid.NewGuid(),
            BaseType = d
        });
        await _context.SaveChangesAsync();     
        return Ok();
    }
}