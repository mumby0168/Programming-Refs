using System;
using Programming_Reference_Website.Factories.Interfaces;
using Programming_Reference_Website.Persistance;

namespace Programming_Reference_Website.Factories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public IUnitOfWork GetInstance() => new UnitOfWork((ProgrammingReferenceDbContext)_serviceProvider.GetService(typeof(ProgrammingReferenceDbContext)));
    }
}