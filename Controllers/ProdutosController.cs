using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Context;

namespace MinhaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos =_context.Produtos.ToList();
            if(produtos is null)
            {
                return NotFound();
            }
            return produtos;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Produto> Get(int id) 
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto is null)
            {
                return NotFound();
            }
            return produto;
        }
    }
}
