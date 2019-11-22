using AssetManagement.Inftrastructure.FIlters;
using AssetManagement.Inftrastructure.Results;
using Entities;
using Infrastructure.Interfaces;
using System.Web.Http;

namespace AssetManagement.Controllers
{
    public class FoldersController : ApiController
    {
        private readonly IFoldersService foldersService;

        public FoldersController(IFoldersService foldersService)
        {
            this.foldersService = foldersService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return new ApiResponseResult(foldersService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return new ApiResponseResult(foldersService.Get(id));
        }

        [HttpPost]
        [ValidateModelActionFilter]
        public IHttpActionResult Save(Folder value)
        {
            return new ApiResponseResult(foldersService.Save(value));
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            return new ApiResponseResult(foldersService.Delete(id));
        }
    }
}
