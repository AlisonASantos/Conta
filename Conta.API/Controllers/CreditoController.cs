using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Conta.API.ViewModels;
using Conta.Domain.Interfaces;
using Conta.Domain.Models;
using Conta.Domain.Models.Validations;
using Conta.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conta.API.Controllers
{
    [ApiController]
    [Route("api/credito")]
    public class CreditoController : MainController
    {
        private readonly ILancamentosPorContaService _lancamentoPorContaService;
        private readonly IMapper _mapper;

        public CreditoController(ILancamentosPorContaService lancamentoPorContaService,
            INotificador notificador,
            IMapper mapper) : base(notificador)
        {
            _lancamentoPorContaService = lancamentoPorContaService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<ContaCorrenteViewModel>> Credito(LancamentosPorContaViewModel lancamentosPorConta)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _lancamentoPorContaService.Credito(_mapper.Map<LancamentosPorConta>(lancamentosPorConta));

            return CustomResponse(lancamentosPorConta);
        }
    }
}
