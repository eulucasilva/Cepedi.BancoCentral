using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers
{
    public class AlterarUsuarioRequestHandler : IRequestHandler<AlterarUsuarioRequest, AlterarUsuarioResponse>
    {

        private readonly IUsuarioRepository _userRepository;
        private readonly ILogger<AlterarUsuarioRequestHandler> _logger;
        public AlterarUsuarioRequestHandler(IUsuarioRepository userRepository, ILogger<AlterarUsuarioRequestHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<AlterarUsuarioResponse> Handle(AlterarUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarioExistente = await _userRepository.ObtemUsuarioPorIdAsync(request.Id);

                usuarioExistente.Nome = request.Nome;
                usuarioExistente.Cpf = request.Cpf;
                usuarioExistente.Celular = request.Celular;
                usuarioExistente.DataNascimento = request.DataNascimento;
                usuarioExistente.Email = request.Email;

                await _userRepository.AlterarUsuarioAsync(usuarioExistente);

                return new AlterarUsuarioResponse(usuarioExistente.Id, "Usuário alterado com sucesso");
            }
            catch (System.Exception)
            {
                _logger.LogError("Ocorreu um erro durante a execução");
                throw;
            }
        }
    }
}