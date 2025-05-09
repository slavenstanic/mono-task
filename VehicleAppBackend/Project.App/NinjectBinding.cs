using Ninject.Modules;
using Project.DAL;
using Project.Repository;
using Project.Repository.Common;
using Microsoft.EntityFrameworkCore;

public class NinjectBindings : NinjectModule
{
    public override void Load()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=ProjectDB;Trusted_Connection=True;");

        Bind<ProjectDbContext>().ToSelf().InTransientScope().WithConstructorArgument("options", optionsBuilder.Options);
        Bind<IUnitOfWork>().To<UnitOfWork>().InTransientScope();
        Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>)).InTransientScope();
    }
}
