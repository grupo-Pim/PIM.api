﻿using Microsoft.AspNetCore.Mvc;
using PIM.api.Entidades;
using PIM.api.Persistence;
using static PIM.api.Enum.EnumSistemaFazenda;

namespace PIM.api.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly FazendoDbContext _context;
        public ProdutoController(FazendoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddNovoProduto(Guid acesso, ProdutoInput NovoProdutoInput)
        {
            ProdutoEntidade NovoProduto = new()
            {
                ID = NovoProdutoInput.ID,
                EmpresaID = NovoProdutoInput.EmpresaID,
                FornecedorID = NovoProdutoInput.FornecedorID,
                Nome = NovoProdutoInput.Nome,
                ValorVendaKG = NovoProdutoInput.ValorVendaKG,
                Ativo = NovoProdutoInput.Ativo
            };
            var permissaoUser = userPossuiPermissao(acesso);
            if (!permissaoUser.existe) return NotFound("Usuario não existe");
            if (!permissaoUser.possuiPermissao) return Forbid("Usuario não possui permissão");

            _context.Produto.Add(NovoProduto);
            _context.SaveChanges();
            return Created("Produto criado", NovoProduto);
        }
        [HttpPut]
        public IActionResult AlterarProduto(Guid acesso, ProdutoInput ProdutoUpdateInput)
        {
            ProdutoEntidade ProdutoUpdate = new()
            {
                ID = ProdutoUpdateInput.ID,
                EmpresaID = ProdutoUpdateInput.EmpresaID,
                FornecedorID = ProdutoUpdateInput.FornecedorID,
                Nome = ProdutoUpdateInput.Nome,
                ValorVendaKG = ProdutoUpdateInput.ValorVendaKG,
                Ativo = ProdutoUpdateInput.Ativo
            };
            var permissaoUser = userPossuiPermissao(acesso);
            if (!permissaoUser.existe) return NotFound("Usuario não existe");
            if (!permissaoUser.possuiPermissao) return Forbid("Usuario não possui permissão");
         
            var produtoAlvo = _context.Produto.SingleOrDefault(o => o.ID == ProdutoUpdate.ID);
            if (produtoAlvo == null) return NotFound("produto não existe");

            produtoAlvo.ValorVendaKG = ProdutoUpdate.ValorVendaKG;
            produtoAlvo.Nome = ProdutoUpdate.Nome;
            produtoAlvo.Ativo = ProdutoUpdate.Ativo;
            _context.SaveChanges();
            return Ok("Produto alterado");
        }
        [HttpGet("Unico")]
        public IActionResult GetProduto(int ProdutoID)
        {
            var produto = _context.Produto.SingleOrDefault(o => o.ID == ProdutoID);
            return Ok(produto);
        }
        [HttpGet]
        public IActionResult GetListaProduto(int EmpresaID, int FornecedorID)
        {
            var produto = _context.Produto.Where(o => o.EmpresaID == EmpresaID && o.FornecedorID == FornecedorID).ToList();
            return Ok(produto);
        }
        [HttpDelete]
        public IActionResult ApagarProduto(Guid acesso, int ProdutoID)
        {
            var permissaoUser = userPossuiPermissao(acesso);
            if (!permissaoUser.existe) return NotFound("Usuario não existe");
            if (!permissaoUser.possuiPermissao) return Forbid("Usuario não possui permissão");

            var produtoAlvo = _context.Produto.SingleOrDefault(o => o.ID == ProdutoID);
            if (produtoAlvo == null) return NotFound("produto não existe: "+ ProdutoID);
            produtoAlvo.Ativo = false;
            _context.SaveChanges();
            return Ok("Produto inativado");
        }


        private (bool possuiPermissao, bool existe, string Mensagem) userPossuiPermissao(Guid acesso)
        {
            var user = _context.Colaboradores.FirstOrDefault(o=> o.Usuario.Acesso == acesso);
            if (user == null) return (possuiPermissao: false, existe: false, Mensagem: "Usuario não existe");

            if (user.Funcao == (int)EnumTipoUsuario.Produtor) return (possuiPermissao: false, existe: true, Mensagem: "Usuario não possui permissão");

            return (possuiPermissao: true, existe: true, Mensagem: "");
        }
    }
}
