using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Conta.API.ViewModels;
using Conta.Domain.Interfaces;
using Conta.Domain.Models.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conta.API.Controllers
{
    [ApiController]
    [Route("api/consultar")]
    public class ConsultarContaController : MainController
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMapper _mapper;

        public ConsultarContaController(IContaCorrenteRepository contaCorrenteRepository,
            INotificador notificador,
            IMapper mapper) : base(notificador)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContaCorrenteViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(await _contaCorrenteRepository.ObterTodos());
        }

    }
}
