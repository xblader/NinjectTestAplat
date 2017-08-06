using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplatServices
{
    public interface IControleAcessoFactory
    {
        IControleAcesso Create(string name, string tokenCA, string tokenAplat);
    }
}
