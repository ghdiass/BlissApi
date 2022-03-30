using System;

namespace Bliss.Comunication
{
    public class ComunicacaoService : IComunicacaoService
    {
        #region Atributos Privados e Construtor

        private ISendGridComunicacao _sendGridComunicacao;
        private TipoComunicacao _tipoComunicacao;

        public ComunicacaoService(ISendGridComunicacao sendGridComunicacao,
                                  IConfiguration configuration)
        {
            _sendGridComunicacao = sendGridComunicacao;
            _tipoComunicacao = (TipoComunicacao)Convert.ToInt32(configuration.GetSection("Parametros:TipoComunicacao").Value);
        }

        #endregion

        public async Task<Emails> EnviarEmail(string email, string assunto, string template) =>
            await ObterInterface(_tipoComunicacao).EnviarEmail(email, assunto, template);

        #region Métodos Privados

        private IComunicacaoBase ObterInterface(TipoComunicacao tipoStorage) =>
            tipoStorage switch
            {
                TipoComunicacao.SendGrid => _sendGridComunicacao,
                _ => null
            };

        #endregion
    }
}
