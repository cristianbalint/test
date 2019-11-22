using AssetManagement.Inftrastructure.Results;
using Common.Net46.Interfaces;
using Common.Net46.Services;
using Common.Net46.Storage;
using Infrastructure.Interfaces;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AssetManagement.Controllers
{
    public class AssetsController : ApiController
    {
        private readonly IAssetsService assetsService;

        public AssetsController(IAssetsService assetsService)
        {
            this.assetsService = assetsService;
        }

        private bool isAllowedType(string contentType)
        {
            string allowedAssetType = ConfigurationManager.AppSettings["AllowedAssetTypes"];
            foreach (var type in allowedAssetType.Split(','))
            {
                if (contentType.Contains(type)) return true;
            }
            return false;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return new ApiResponseResult(assetsService.GetAll());
        }

        [HttpPost]
        public IHttpActionResult Save()
        {
            IOperationResult result = null;
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["Asset"];

                if (httpPostedFile != null)
                {
                    result = isAllowedType(httpPostedFile.ContentType) ?
                        assetsService.SaveAsset(new StorageFile(httpPostedFile.FileName, httpPostedFile.InputStream, httpPostedFile.ContentType, httpPostedFile.ContentLength)) : OperationResult.Succeeded("Asset saved.");
                }
            }

            if (result != null && result.IsSuccess)
            {
                return new ApiResponseResult(200, result.Message);
            }
            else
            {
                return new ApiResponseResult("Image is missing");
            }
        }
    }
}
