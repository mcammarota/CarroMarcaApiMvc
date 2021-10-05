using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
