using AwesomeErp.Core.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Middlewares
{
    public class AwesomeMvcModuleRegister : BaseMiddleware
    {
        private IMvcBuilder _mvcBuilder;

        private AwesomeMvcModuleRegister(IMvcBuilder mvcBuilder, string folderPath)
            : base(folderPath)
        {
            _mvcBuilder = mvcBuilder;
        }

        public static AwesomeMvcModuleRegister CreateInstance(IMvcBuilder mvcBuilder, string folderPath)
        {
            return new AwesomeMvcModuleRegister(mvcBuilder, folderPath);
        }

        public void Invoke<T>()
        {
            var moduleAsms = AssemblyTools.LoadAssembliesThatImplements<T>(_folderPath);

            foreach (var asm in moduleAsms)
            {
                _mvcBuilder
                    .AddApplicationPart(asm);
            }

            _mvcBuilder.AddControllersAsServices();
        }
    }
}
