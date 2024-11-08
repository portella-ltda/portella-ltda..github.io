using MediatR;
using System;

namespace Missaol.Application.Cliente
{
    public sealed class EncantarCommandRequest : IRequest
    {
        public Guid? Cliente { get; set; }
        public Guid? Produto { get; set; }
        public int? ProdutoNota { get; set; }
        public Guid? Atendimento { get; set; }
        public int? AtendimentoNota { get; set; }
        public Guid? Ambiente { get; set; }
        public int? AmbienteNota { get; set; }
        internal IDataAccess.Ambiente AmbienteDTO { get; set; }
        internal IDataAccess.Atendimento AtendimentoDTO { get; set; }
        internal IDataAccess.Produto ProdutoDTO { get; set; }
    }
}
