using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TelerikAngular2.Api.Models;
using TelerikAngular2.Core.Interfaces;
using TelerikAngular2.Data.Models;
using Z.Linq;

namespace TelerikAngular2.Api.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IVisitPlaceService visitPlaceService;
        private readonly IFileUploadService fileUploadService;
        public UserController(IUserService userService, IVisitPlaceService visitPlaceService, IFileUploadService fileUploadService) : base(userService)
        {
            this.userService = userService;
            this.visitPlaceService = visitPlaceService;
            this.fileUploadService = fileUploadService;
        }

        [HttpGet]
        [Route("api/GetUserInfo")]
        public HttpResponseMessage GetUserInfo()
        {
            User userInfo = this.GetCurrentUser();
            UserViewModel user = new UserViewModel()
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Email = userInfo.Email
            };
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpGet]
        [Route("api/GetUserPlaces")]
        public HttpResponseMessage GetUserPlaces()
        {
            User userInfo = this.GetCurrentUser();
            var visitedPlaces = userService.GetVisitedPlaces(userInfo.Id).Select(VisitedPlaceViewModel.FromVisitedPlaces);
            return Request.CreateResponse(HttpStatusCode.OK, visitedPlaces);
        }

        [Route("api/SavePlace")]
        [HttpPost]
        public HttpResponseMessage SavePlace([FromBody]VisitedPlaceViewModel savePlace)
        {
            User userInfo = this.GetCurrentUser();
            VisitedPlace dataToSave = new VisitedPlace()
            {
                Id = savePlace.Id,
                Lat = savePlace.Lat,
                Lng = savePlace.Lng,
                Name = savePlace.Label,
                Description = savePlace.Description,
                IsVisited = savePlace.isVisited,
                IsSaved = true
            };
            this.visitPlaceService.SavePlace(dataToSave, userInfo);
            return Request.CreateResponse(HttpStatusCode.Created, "Success");
        }

        [Route("api/UpdatePlace")]
        [HttpPost]
        public HttpResponseMessage UpdatePlace([FromBody]VisitedPlaceViewModel updatePlace)
        {
            User userInfo = this.GetCurrentUser();
            VisitedPlace dataToSave = new VisitedPlace()
            {
                Id = updatePlace.Id,
                Lat = updatePlace.Lat,
                Lng = updatePlace.Lng,
                Name = updatePlace.Label,
                Description = updatePlace.Description,
                IsSaved = true,
                IsVisited = updatePlace.isVisited
            };
            this.visitPlaceService.UpdatePlace(dataToSave);
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [Route("api/DeletePlace/{Id}")]
        [HttpGet]
        public HttpResponseMessage DeletePlace(string Id)
        {
            if (Id == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            this.visitPlaceService.DeletePlace(Guid.Parse(Id));
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("api/FileUpload/{markerId}")]
        public async Task<HttpResponseMessage> UploadFiles([FromUri]string markerId)
        {
            var re = Request;
            var headers = re.Headers;
            string tokenLat = string.Empty;
            string tokenLng = string.Empty;

            if (headers.Contains("lat"))
            {
                tokenLat = headers.GetValues("lat").First();
            }

            if (headers.Contains("lng"))
            {
                tokenLng = headers.GetValues("lng").First();
            }

            User userInfo = this.GetCurrentUser();
            if (userInfo.Id == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "user should not be null");
            }

            bool isSavedSuccessfully = true;
            string currentFileName = string.Empty;

            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();

                foreach (var stream in filesReadToProvider.Contents)
                {
                    currentFileName = string.Empty;
                    if (stream.Headers.ContentDisposition.FileName != null)
                    {
                        currentFileName = stream.Headers.ContentDisposition.FileName.Trim('"', '\\');
                        byte[] fileBytes = await stream.ReadAsByteArrayAsync();
                        isSavedSuccessfully = fileUploadService.SaveFile(currentFileName, fileBytes, userInfo.Id, markerId, tokenLat, tokenLng);
                    }
                    else
                    {
                        isSavedSuccessfully = false;
                    }
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                //logger.Log(LogLevel.Error, ex);
            }

            if (isSavedSuccessfully)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Failed to upload file: {currentFileName}");
            }
        }

        [HttpGet]
        [Route("api/GetImages/{markerId}")]
        public async Task<HttpResponseMessage> GetImages([FromUri]string markerId)
        {

            //   if (!string.IsNullOrEmpty(markerId))
            //  {
            var images = this.fileUploadService.GetImages(markerId).AsQueryable().Select(ImageViewModel.FromVisitedPlaces);
            images.ToList();
            //   }
            return Request.CreateResponse(HttpStatusCode.OK, images);
        }

        [HttpGet]
        [Route("api/GetVisitedPlaces")]
        public async Task<HttpResponseMessage> GetVisitedPlaces()
        {
            User userInfo = this.GetCurrentUser();
            var visitedPlaces = this.visitPlaceService.GetAllPlaces(userInfo).AsQueryable().Select(VisitedPlaceViewModel.FromVisitedPlaces);
            visitedPlaces.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, visitedPlaces);
        }

        [HttpGet]
        [Route("api/GetWishList")]
        public async Task<HttpResponseMessage> GetWishList()
        {
            User userInfo = this.GetCurrentUser();
            var visitedPlaces = this.visitPlaceService.GetWishList(userInfo).AsQueryable().Select(VisitedPlaceViewModel.FromVisitedPlaces);
            visitedPlaces.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, visitedPlaces);
        }
    }
}
