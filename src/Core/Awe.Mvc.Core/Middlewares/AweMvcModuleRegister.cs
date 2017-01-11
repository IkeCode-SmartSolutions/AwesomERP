using Awe.Core.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Awe.Mvc.Core.Middlewares
{
    public class AweMvcModuleRegister : AweBaseMiddleware<IMvcBuilder>
    {
        private AweMvcModuleRegister(IMvcBuilder mvcBuilder, string folderPath)
            : base(folderPath)
        {
            ReturnObj = mvcBuilder;
        }

        public static AweMvcModuleRegister CreateInstance(IMvcBuilder mvcBuilder, string folderPath)
        {
            return new AweMvcModuleRegister(mvcBuilder, folderPath);
        }

        public override IMvcBuilder Invoke<T>()
        {
            var moduleAsms = AssemblyTools.LoadAssembliesThatImplements<T>(FolderPath);

            foreach (var asm in moduleAsms)
            {
                ReturnObj
                    .AddApplicationPart(asm);
            }

            ReturnObj.AddControllersAsServices();

            return ReturnObj;
        }
    }
}
