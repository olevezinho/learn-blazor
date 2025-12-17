using BlazorShop.API.Mappings;
using BlazorShop.API.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        
        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetProdutosAsync()
        {
            try
            {
                var produtos = await _produtoRepository.GetAllAsync();
                if (produtos is null)
                {
                    return NotFound();
                }

                var produtosDto = produtos.ConverterProdutosParaDtos();
                return Ok(produtosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao aceder à base de dados");
            }
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDto>> GetProdutoByIdAsync(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id);
                if (produto is null)
                {
                    return NotFound("Erro ao localizar o produto.");
                }

                var produtoDto = produto.ConverterProdutoParaDto();
                return Ok(produtoDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao aceder à base de dados");
            }
        }
        
        [HttpGet("getitensporcategoria/{categoriaId:int}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetProdutosPorCategoriaIdAsync(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetByCategoriaAsync(categoriaId);
                if (produtos is null)
                {
                    return NotFound();
                }
        
                var produtosDto = produtos.ConverterProdutosParaDtos();
                return Ok(produtosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao aceder à base de dados");
            }
        }
        
        [HttpGet("getcategorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategoriasAsync()
        {
            try
            {
                var categorias = await _produtoRepository.GetAllCategoriasAsync();
                var categoriasDto = categorias.ConverterCategoriasParaDto();
                return Ok(categoriasDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao aceder à base de dados");
            }
        }
    }
}
