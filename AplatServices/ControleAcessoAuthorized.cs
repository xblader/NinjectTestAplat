using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplatServices
{
    public class ControleAcessoAuthorized : IControleAcesso
    {
        private string name;
        private string tokenCA;
        private string tokenAplat;
        public ControleAcessoAuthorized(string name, string tokenCA, string tokenAplat)
        {
            this.name = name;
            this.tokenAplat = tokenAplat;
            this.tokenCA = tokenCA;
        }

        public ControleAcessoAuthorized()
        {

        }
    }
}
