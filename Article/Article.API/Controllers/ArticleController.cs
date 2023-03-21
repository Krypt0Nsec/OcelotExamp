using Article.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Article.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleController : ControllerBase
	{
		private readonly ArticleDbContext _context;

		public ArticleController(ArticleDbContext context)
		{
			_context = context;
		}

		// GET: api/<ArticleController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Models.Article>>> ArticleList()
		{
			List<Models.Article> articleList = await _context.Article.ToListAsync();
			return articleList;

		}

		// GET api/<ArticleController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Models.Article>> GetArticle(int id)
		{
			var article = await _context.Article.FindAsync(id);
			if (article == null)
			{
				return NotFound();
			}
			return article;
		}

		// POST api/<ArticleController>
		[HttpPost]

		public async Task<ActionResult<IEnumerable<Models.Article>>> AddArticle(Models.Article article)
		{
			_context.Article.Add(article);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{

				ex.Message.ToString();
			}

			return CreatedAtAction("GetArticle", new { id = article.Id }, article);
		}

		// PUT api/<ArticleController>/5
		[HttpPut("{id}")]

		public async Task<ActionResult<IEnumerable<Models.Article>>> ArticleUpdate(Models.Article article)
		{
			_context.Entry(article).Entity.ToString();
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				ex.Message.ToString();

			}
			return CreatedAtAction("GetArticle", new { id = article.Id }, article);
		}

		// DELETE api/<ArticlerController>/5
		[HttpDelete("{id}")]

		public async Task<ActionResult<Models.Article>> ArticleDelete(int id)
		{
			var article = await _context.Article.FindAsync(id);
			if (article == null)
			{
				return NotFound();
			}
			_context.Article.Remove(article);
			await _context.SaveChangesAsync();
			return article;
		}
	}
}
