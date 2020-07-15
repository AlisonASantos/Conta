using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conta.Domain.Models.Validations
{
    public class ContaCorrenteValidations : AbstractValidator<ContaCorrente>
    {
        public ContaCorrenteValidations()
        {
            RuleFor(f => f.TitularConta)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NumeroConta)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
