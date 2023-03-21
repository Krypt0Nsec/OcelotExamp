using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Writer.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Writer.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WriterController : ControllerBase
	{

		private readonly WriterDbContext _context;

		public WriterController(WriterDbContext context)
		{
			_context = context;
		}

		// GET: api/<WriterController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Models.Writer>>> WriterList()
		{
			List<Models.Writer> writerList = await _context.Writer.ToListAsync();
			return writerList;

		}

		// GET api/<WriterController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Models.Writer>> GetWriter(int id)
		{
			var writer = await _context.Writer.FindAsync(id);
			if (writer==null)
			{
				return NotFound();
			}
			return writer;
		}

		// POST api/<WriterController>
		[HttpPost]

		public async Task<ActionResult<IEnumerable<Models.Writer>>> AddWriter(Models.Writer writer)
		{
			_context.Writer.Add(writer);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{

				ex.Message.ToString();
			}

			return CreatedAtAction("GetWriter", new {id=writer.Id}, writer);
		}

		// PUT api/<WriterController>/5
		[HttpPut("{id}")]

		public async Task<ActionResult<IEnumerable<Models.Writer>>> WriterUpdate(Models.Writer writer)
		{
			_context.Entry(writer).Entity.ToString();
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				ex.Message.ToString();
			
			}
			return CreatedAtAction("GetWriter", new { id = writer.Id }, writer);
		}

		// DELETE api/<WriterController>/5
		[HttpDelete("{id}")]

		public async Task<ActionResult<Models.Writer>> WriterDelete(int id)
		{
			var writer = await _context.Writer.FindAsync(id);
			if (writer == null)
			{
				return NotFound();
			}
			_context.Writer.Remove(writer);
			await _context.SaveChangesAsync();
			return writer;
		}
	}
}
