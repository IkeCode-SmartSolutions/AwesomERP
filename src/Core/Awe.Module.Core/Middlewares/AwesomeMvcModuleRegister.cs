using Awe.Core.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Module.Core.Middlewares
{
    public class AwesomeMvcModuleRegister : BaseMiddleware<IMvcBuilder>
    {
        private AwesomeMvcModuleRegister(IMvcBuilder mvcBuilder, string folderPath)
            : base(folderPath)
        {
            ReturnObj = mvcBuilder;
        }

        public static AwesomeMvcModuleRegister CreateInstance(IMvcBuilder mvcBuilder, string folderPath)
        {
            return new AwesomeMvcModuleRegister(mvcBuilder, folderPath);
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
