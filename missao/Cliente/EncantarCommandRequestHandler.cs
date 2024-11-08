using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Missaol.Application.Cliente
{
    public sealed class EncantarCommandRequestHandler : IRequestHandler<EncantarCommandRequest>
    {
        IMediator Mediator { get; }
        public EncantarCommandRequestHandler(IMediator mediator)
        {
            Mediator = mediator;
        }
        public async Task Handle(EncantarCommandRequest request, CancellationToken cancellationToken)
        {
            var maximo = RequsitosEnumerar(request).Count();
            var atingido = RequsitosEnumerar(request).Where(success => success).Count();
            
            if ((atingido / maximo) < 50)
            {
                await Mediator.Publish(new EncantadoNegativoCommandNotification(), cancellationToken);
                return;
            }

            if ((atingido / maximo) < 100)
            {
                await Mediator.Publish(new EncantadoParcialmenteCommandNotification(), cancellationToken);
                return;
            }

            await Mediator.Publish(new EncantadoCommandNotification(), cancellationToken);
        }

        private static IEnumerable<bool> RequsitosEnumerar(EncantarCommandRequest request)
        {
            yield return request.ProdutoNota >= request.ProdutoDTO.Qualidade.Minima;
            yield return request.AtendimentoNota >= request.AtendimentoDTO.Nivel.Minimo;
            yield return request.AmbienteNota >= request.AmbienteDTO.Agrado.Minimo;
        }
    }
}
