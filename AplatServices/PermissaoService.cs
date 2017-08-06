using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplatServices
{
    public class PermissaoService : IPermissaoService
    {
        public string token;
        public string user;
        private string senha;
        public PermissaoService(string user, string senha)
        {
            this.user = user;
            this.senha = senha;
        }

        public PermissaoService(string token)
        {
            this.token = token;
        }
        public PermissaoService()
        {
                
        }
        public bool Teste()
        {
            return true;
        }
    }
}
