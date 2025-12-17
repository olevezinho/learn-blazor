using BlazorShop.API.Mappings;
using BlazorShop.API.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.API.Controllers
{
    [Route("api/carrinhocompras")]
    [ApiController]
    public class CarrinhoComprasController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
        private readonly IProdutoRepository _produtoRepository;
        
        private ILogger<CarrinhoComprasController> _logger;

        public CarrinhoComprasController(ICarrinhoCompraRepository carrinhoCompraRepository,
            IProdutoRepository produtoRepository, 
            ILogger<CarrinhoComprasController> logger)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        [HttpGet("{utilizadorId:int}/itens")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> GetCarrinhoItemsAsync(int utilizadorId)
        {
            try
            {
                var carrinhoItens = await _carrinhoCompraRepository.GetAllUtilizadorItemsAsync(utilizadorId);
                if (carrinhoItens is null)
                {
                    return NoContent(); // 204 status code
                }

                var produtos = await _produtoRepository.GetAllAsync();
                if (produtos is null)
                {
                    throw new Exception("Não existem produtos ...");
                }

                var carrinhoItensDto = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);
                return Ok(carrinhoItensDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, $"Erro ao obter itens do carrinho para o utilizador {utilizadorId}.");
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> GetCarrinhoItemAsync(int id)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.GetItemByIdAsync(id);
                if (carrinhoItem is null)
                {
                    return NotFound($"Item: '{id}' não encontrado!");
                }
                
                var produto = await _produtoRepository.GetByIdAsync(carrinhoItem.ProdutoId);
                if (produto is null)
                {
                    return NotFound($"Item {id} não existe na fonte de dados!");
                }

                var cartItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
                return Ok(cartItemDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, $"Erro ao obter itens o item '{id}' do carrinho.");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> PostItemAsync([FromBody] CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var novoCarrinhoItem = await _carrinhoCompraRepository.AddItemAsync(carrinhoItemAdicionaDto);

                if (novoCarrinhoItem is null)
                {
                    return NoContent();
                }
                
                var produto = await _produtoRepository.GetByIdAsync(carrinhoItemAdicionaDto.ProdutoId);

                if (produto is null)
                {
                    throw new Exception($"Produto não localizado (Id:({carrinhoItemAdicionaDto.ProdutoId}))");
                }
                
                var novoCarrinhoItemDto = novoCarrinhoItem.ConverterCarrinhoItemParaDto(produto);
                return CreatedAtAction("GetCarrinhoItem", new { Id = novoCarrinhoItemDto.Id }, novoCarrinhoItemDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, $"Erro ao adicionar o item ao carrinho '{carrinhoItemAdicionaDto.CarrinhoId}'.");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> AtualizaQuanidadeAsync(int id,
            CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.AtualizaQuantidadeAsync(id, carrinhoItemAtualizaQuantidadeDto);

                if (carrinhoItem is null)
                {
                    return NotFound($"Carrinho item {id} não encontrado.");
                }
                
                var produto = await _produtoRepository.GetByIdAsync(carrinhoItem.ProdutoId);
                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
                return Ok(carrinhoItemDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> DeleteItemAsync(int id)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.RemoveItemAsync(id);
                if (carrinhoItem is null)
                {
                    return NotFound("Item não encontrado no carrinho!");
                }
                
                var produto = await _produtoRepository.GetByIdAsync(carrinhoItem.ProdutoId);
                if (produto is null)
                {
                    return NotFound("Produto não encontrado!");
                }
                
                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
                return Ok(carrinhoItemDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, $"Erro ao remover o carrinho '{id}'.");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
