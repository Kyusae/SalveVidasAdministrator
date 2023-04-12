using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salve_VidasAdministrator
{
    public class ViaCep
    {
        public RetornoCEP consultaCEP(string cep)
        {
            try
            {
                RestClient restClient = new RestClient(String.Format("https://viacep.com.br/ws/{0}/json", cep.Replace("-", ""))); //ROTA
                RestRequest restRequest = new RestRequest(Method.GET); //Metodo

                IRestResponse restResponse = restClient.Execute(restRequest); //Interface para executar a minha rota especificando e o meu metodo de busca.

                if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Erro - CEP informado não é valido, por favor verificar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    var retornoCEP = new JsonDeserializer().Deserialize<RetornoCEP>(restResponse);
                    RetornoCEP retornaDados = new RetornoCEP();

                    if (retornoCEP.CEP == null)
                    {
                        MessageBox.Show("Erro - CEP informado não é valido, por favor verificar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    retornaDados = new RetornoCEP()
                    {
                        CEP = retornoCEP.CEP,
                        Logradouro = retornoCEP.Logradouro,
                        Bairro = retornoCEP.Bairro,
                        localidade = retornoCEP.localidade,
                        UF = retornoCEP.UF,
                    };

                    return retornaDados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao consultar CEP pela API, por favor tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public class RetornoCEP
        {
            public string CEP { get; set; }
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string localidade { get; set; }
            public string UF { get; set; }
        }
    }
}
