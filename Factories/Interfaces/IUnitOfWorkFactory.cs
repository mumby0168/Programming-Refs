using Programming_Reference_Website.Persistance;

namespace Programming_Reference_Website.Factories.Interfaces
{
    public interface IUnitOfWorkFactory
    {
         IUnitOfWork GetInstance();
    }
}