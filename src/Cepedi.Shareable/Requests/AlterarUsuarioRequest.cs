using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public class AlterarUsuarioRequest : IRequest<AlterarUsuarioResponse>
{
    public int Id { get; set; } = default!;
    public string Nome { get; set; } = default!;

    public DateTime DataNascimento { get; set; }

    public string Cpf { get; set; } = default!;

    public string Celular { get; set; } = default!;

    public string Email { get; set; } = default!;
}
