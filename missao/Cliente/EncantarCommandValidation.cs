using FluentValidation;
using System.Linq;

namespace Missaol.Application.Cliente
{
    public sealed class EncantarCommandValidation : AbstractValidator<EncantarCommandRequest>
    {
        public EncantarCommandValidation(IDataAccess db)
        {
            RuleFor(request => request)
            .Must(request => !request.Cliente.HasValue)
            .WithName("Cliente")
            .WithMessage("Obrigatório")
            .DependentRules(() =>
            {
                RuleFor(request => request)
                .Must(request => db.Clientes.Any(cliente => cliente.Code == request.Cliente))
                .WithName("Cliente")
                .WithMessage("Não encontrado");
            });

            RuleFor(request => request)
            .Must(request => !request.Produto.HasValue)
            .WithName("Produto")
            .WithMessage("Obrigatório")
            .DependentRules(() =>
            {
                RuleFor(request => request)
                .Must(request =>
                {
                    request.ProdutoDTO = db.Produtos.SingleOrDefault(produto => produto.Code == request.Produto);
                    return request.ProdutoDTO != default;
                })
                .WithName("Produto")
                .WithMessage("Não encontrado")
                .DependentRules(() =>
                {
                    RuleFor(request => request)
                    .Must(request => request.ProdutoDTO.Qualidade?.Minima != default)
                    .WithName("Qualidade para o produto")
                    .WithMessage("Não encontrado");
                });
            });

            RuleFor(request => request)
            .Must(request => !request.Atendimento.HasValue)
            .WithName("Atendimento")
            .WithMessage("Obrigatório")
            .DependentRules(() =>
            {
                RuleFor(request => request)
                .Must(request =>
                {
                    request.AtendimentoDTO = db.Atendimentos.SingleOrDefault(atendimento => atendimento.Code == request.Atendimento);
                    return request.AtendimentoDTO != default;
                })
                .WithName("Atendimento")
                .WithMessage("Não encontrado")
                .DependentRules(() =>
                {
                    RuleFor(request => request)
                    .Must(request => request.AtendimentoDTO.Nivel?.Minimo != default)
                    .WithName("Nível para o atendimento")
                    .WithMessage("Não encontrado");
                });
            });

            RuleFor(request => request)
            .Must(request => !request.Ambiente.HasValue)
            .WithName("Ambiente")
            .WithMessage("Obrigatório")
            .DependentRules(() =>
            {
                RuleFor(request => request)
                .Must(request =>
                {
                    request.AmbienteDTO = db.Ambientes.SingleOrDefault(ambiente => ambiente.Code == request.Ambiente);
                    return request.AmbienteDTO != default;
                })
                .WithName("Ambiente")
                .WithMessage("Não encontrado")
                .DependentRules(() =>
                {
                    RuleFor(request => request)
                    .Must(request => request.AmbienteDTO.Agrado?.Minimo != default)
                    .WithName("Agrado para o ambiente")
                    .WithMessage("Não encontrado");
                });
            });
        }
    }
}
