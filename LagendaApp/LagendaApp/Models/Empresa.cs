using System;
namespace LagendaApp.Models
{
    
        public class Empresa
        {

            public int isn_empresa { get; set; }

            public int isn_pessoa { get; set; }

            public string dsc_nome_empresa_exibicao { get; set; }

            public int isn_status_empresa { get; set; }

            public DateTime dat_cadastro { get; set; }

            public int isn_usuario_cadastro { get; set; }

            public DateTime dat_alteracao { get; set; }

            public int isn_usuario_alteracao { get; set; }
        }
    
}
