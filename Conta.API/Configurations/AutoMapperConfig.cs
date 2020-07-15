using AutoMapper;
using Conta.API.ViewModels;
using Conta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ContaCorrente, ContaCorrenteViewModel>().ReverseMap();
            CreateMap<LancamentosPorConta, LancamentosPorContaViewModel>().ReverseMap();
        }
    }
}
