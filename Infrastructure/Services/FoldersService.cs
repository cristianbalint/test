using Common.Net46.Interfaces;
using Common.Net46.Services;
using Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class FoldersService : IFoldersService
    {
        private readonly IGenericRepository<Folder> foldersRepo;

        public FoldersService(IGenericRepository<Folder> foldersRepo)
        {
            this.foldersRepo = foldersRepo;
        }
        public IOperationResult Delete(int id)
        {
            return OperationResult.Succeeded(foldersRepo.RemoveAndSave(Get(id)), "Folder deleted");
        }

        public Folder Get(int id)
        {
            return foldersRepo.Where(f => f.Id == id).FirstOrDefault();
        }

        public IEnumerable<Folder> GetAll()
        {
            return foldersRepo.GetAll();
        }

        public IOperationResult Save(Folder folder)
        {
            try
            {
                if (folder.Id <= 0)
                {
                    // create
                    return OperationResult.Succeeded(foldersRepo.AddAndSave(folder));
                }
                else
                {
                    //update
                    return OperationResult.Succeeded(foldersRepo.UpdateAndSave(folder));
                }
            }
            catch (Exception ex)
            {
                return OperationResult.NotSucceeded(ex.Message);
            }

        }
    }
}
