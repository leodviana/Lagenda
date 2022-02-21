using System;
using System.Collections.Generic;

namespace LagendaApp.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Empresas = new List<Empresa>();
        }


        public int isn_usuario { get; set; }


        public int isn_pessoa { get; set; }




        public string dsc_nome_usuario_exibicao { get; set; }


        public string dsc_celular_validado { get; set; }


        public string dsc_email_validado { get; set; }

        public string dsc_core1 { get; set; }


        public string dsc_core2 { get; set; }



        public string dsc_core3 { get; set; }


        public string dsc_core4 { get; set; }


        public string dsc_core5 { get; set; }


        public int isn_status_usuario { get; set; }


        public DateTime dat_cadastro { get; set; }

        
        public int isn_usuario_cadastro { get; set; }

        
        public DateTime dat_alteracao { get; set; }

        
        public int isn_usuario_alteracao { get; set; }
        public string Login { get; set; }
        public string senha { get; set; }

        public List<Empresa> Empresas { get; set; }

        public string ImagePath { get; set; }
    }
}
