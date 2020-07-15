using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Conta.API.ViewModels;
using Conta.Domain.Interfaces;
using Conta.Domain.Models;
using Conta.Domain.Models.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conta.API.Controllers
{
    [ApiController]
    [Route("api/cadastrar")]
    public class CadastrarContaController : MainController
    {
        private readonly IContaCorrenteService _contaCorrenteService;
        private readonly IMapper _mapper;

        public CadastrarContaController(IContaCorrenteService contaCorrenteService,
            INotificador notificador,
            IMapper mapper) : base(notificador)
        {
            _contaCorrenteService = contaCorrenteService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<ContaCorrenteViewModel>> Adicionar(ContaCorrenteViewModel contaCorrente)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _contaCorrenteService.Adicionar(_mapper.Map<ContaCorrente>(contaCorrente));

            return CustomResponse(contaCorrente);
        }
    }
}
