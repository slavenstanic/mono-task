using System;
using Ninject;
using Project.Repository.Common;
using System.Threading.Tasks;

namespace Project.App
{
    class TestConsoleApp
    {
        static async Task Main(string[] args)
        {
            var kernel = new StandardKernel(new NinjectBindings());

            var unitOfWork = kernel.Get<IUnitOfWork>();

            Console.WriteLine("VehicleMake unosi u bazi:");
            var makes = await unitOfWork.VehicleMakes.GetAllAsync();

            foreach (var make in makes)
            {
                Console.WriteLine($"{make.Id} - {make.Name} ({make.Abrv})");
            }

            Console.ReadLine();
        }
    }
}
