using AplatServices;
using Ninject;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectTestAplat.Ninject
{
    public class CustomStrategyProvider : Provider<IControleAcesso>
    {
        protected override IControleAcesso CreateInstance(IContext context)
        {
            var idNum = context.Parameters.FirstOrDefault(p => p.Name == "name");
            var idNumValue = idNum.GetValue(context, null) as string;

            if(idNumValue == "token")
                return context.Kernel.Get<ControleAcessoAuthorized>();

            return context.Kernel.Get<ControleAcessoNonAuthorized>();
        }
    }
}
