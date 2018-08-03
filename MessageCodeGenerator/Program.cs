using Ninject;
using Ninject.Extensions.Conventions;

namespace MessageCodeGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            kernel.Bind(x => x
                .FromThisAssembly()
                .SelectAllClasses()
                .BindAllInterfaces());

            var definitionsSource = kernel.Get<IDefinitionsSource>();
            var definitions = definitionsSource.Definitions;

            var generator = kernel.Get<ICodeGenerator>();
            generator.GeneratorCode(definitions);
        }
    }
}