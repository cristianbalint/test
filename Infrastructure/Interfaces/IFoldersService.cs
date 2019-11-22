using Common.Net46.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces
{
    public interface IFoldersService
    {
        IEnumerable<Folder> GetAll();
        Folder Get(int id);
        IOperationResult Save(Folder folder);
        IOperationResult Delete(int id);
    }
}
