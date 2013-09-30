using System;

namespace EasyCombos.DAL.DBInteractions
{
    public interface IDBFactory : IDisposable
    {
        CodeFirstContext Get();
    }
}
