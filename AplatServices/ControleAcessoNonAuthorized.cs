using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplatServices
{
    public class ControleAcessoNonAuthorized : IControleAcesso
    {
        private string name;
        public ControleAcessoNonAuthorized(string name)
        {
            this.name = name;
        }

        public ControleAcessoNonAuthorized()
        {

        }

        public string LoggedUser()
        {
            return this.name;
        }
    }
}
