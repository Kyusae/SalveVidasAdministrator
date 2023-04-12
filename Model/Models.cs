using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salve_VidasAdministrator.Model
{
    internal class NomeAdmin
    {
        public string Nome { get; set; }
    }

    internal class NomeHospital
    {
        public string Nome { get; set; }
    }

    internal class NomeUsuario
    {
        public string Nome { get; set; }
    }

    internal class Hospitais
    {
        public string Nome { get; set; }
        public string Id { get; set; }
    }

    internal class Cidade
    {
        public string Nome { get; set; }
        public string Id { get; set; }
    }

    internal class Imagem
    {
        public string Foto { get; set; }
    }

    internal class EstadosNome
    {
        public string Nome { get; set; }
    }

    internal class Estados
    {
        public string Nome { get; set; }
        public string Id { get; set; }
    }

    internal class ExisteUsuarioDoador
    {
        public string Nome { get; set; }
    }
}
