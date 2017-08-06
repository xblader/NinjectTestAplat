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
            var name = context.Parameters.Where(x => x.Name == "name").FirstOrDefault().GetValue(context, null) as string;
            var tokenCA = context.Parameters.Where(x => x.Name == "tokenCA").FirstOrDefault().GetValue(context, null) as string;
            var tokenAplat = context.Parameters.Where(x => x.Name == "tokenAplat").FirstOrDefault().GetValue(context, null) as string;
            
            if(string.IsNullOrEmpty(tokenCA))
                return context.Kernel.Get<ControleAcessoNonAuthorized>();

            return context.Kernel.Get<ControleAcessoAuthorized>();
        }
    }
}
