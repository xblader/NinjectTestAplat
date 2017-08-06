using Ninject.Extensions.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Factory.Factory;
using System.Reflection;

namespace NinjectTestAplat.Ninject
{
    public class CustomProvider : IInstanceProvider
    {
        public object GetInstance(IInstanceResolver instanceResolver, MethodInfo methodInfo, object[] arguments)
        {
            throw new NotImplementedException();
        }
    }
}
