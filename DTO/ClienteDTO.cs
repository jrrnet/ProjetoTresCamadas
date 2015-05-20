using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3Camadas.DTO
{
    class ClienteDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
