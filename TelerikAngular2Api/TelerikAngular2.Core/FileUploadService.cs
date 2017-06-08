using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TelerikAngular2.Core.Interfaces;
using TelerikAngular2.Data.Common;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Core
{
    public class FileUploadService : IFileUploadService
    {

        private readonly IDbRepository<Image> repositoryImage;
        private readonly IDbRepository<VisitedPlace> repositoryVisitPlace;
        private readonly IDbRepository<User> repositoryUser;
        public FileUploadService(IDbRepository<Image> repositoryImage, IDbRepository<VisitedPlace> repositoryVisitPlace, IDbRepository<User> repositoryUser)
        {
            this.repositoryImage = repositoryImage;
            this.repositoryVisitPlace = repositoryVisitPlace;
            this.repositoryUser = repositoryUser;
        }


        /// <summary>
        /// Saves the file on disk
        /// </summary>
        /// <param name="fileName">name of the file to save</param>
        /// <param name="fileBytes">the file as a byte array</param>
        /// <param name="userName">User Id</param>
        /// <returns>True if the files was saved to disk and false otherwise. 
        /// Currently the only reason for not saving the file if it is empty.</returns>
        public bool SaveFile(string fileName, byte[] fileBytes, Guid userId, string markerId, string tokenLat, string tokenLng)
        {
            bool result = false;
            //string currentFolderName = GetCurrentFolderName(userId.ToString());
            //if (!Directory.Exists(currentFolderName))
            //{
            //    System.IO.Directory.CreateDirectory(currentFolderName);
            //}

            if (!string.IsNullOrEmpty(fileName) && fileBytes.Length > 0)
            {
                SaveImageToPlace(fileName, markerId, fileBytes, userId, tokenLat, tokenLng);

                //string fullFileName = Path.Combine(currentFolderName, fileName);
                //File.WriteAllBytes(fullFileName, fileBytes);
                result = true;
            }

            return result;
        }

        private void SaveImageToPlace(string fileName, string markerId, byte[] fileBytes, Guid userId, string tokenLat, string tokenLng)
        {
            if (!string.IsNullOrEmpty(markerId))
            {
                VisitedPlace emptyPlace = new VisitedPlace();
                VisitedPlace visitPlace = this.repositoryVisitPlace.GetById(Guid.Parse(markerId));
                if (visitPlace == null)
                {
                    User user = this.repositoryUser.GetById(userId);
                    emptyPlace = new VisitedPlace()
                    {
                        Id = Guid.Parse(markerId),
                        Lat = float.Parse(tokenLat),
                        Lng = float.Parse(tokenLng),
                        IsSaved = true,
                        user = user
                    };
                    this.repositoryVisitPlace.Add(emptyPlace);
                    this.repositoryVisitPlace.Save();
                }

                Image image = new Image()
                {
                    Id = Guid.NewGuid(),
                    Name = fileName,
                    Photo = fileBytes,
                    VisitedPlace = visitPlace == null ? this.repositoryVisitPlace.GetById(emptyPlace.Id) : visitPlace
                };

                this.repositoryImage.Add(image);
                this.repositoryImage.Save();
            }
        }

        public IEnumerable<Image> GetImages(string markerId)
        {
            Guid marker = Guid.Parse(markerId);
            return this.repositoryImage.All().Where(i => i.VisitedPlace.Id == marker);

        }

        //public string SetNameToUploadFolder(string userName)
        //{
        //    string result = null;
        //    string currentFolderName = this.GetCurrentFolderName(userName);
        //    string packageName = this.GetPackageName(currentFolderName);
        //    if (!string.IsNullOrEmpty(packageName))
        //    {
        //        string targetFolderName = this.GetCurrentFolderName(userName, packageName);
        //        if (Directory.Exists(targetFolderName))
        //        {
        //            Directory.Delete(targetFolderName, true);
        //        }
        //        Directory.Move(currentFolderName, targetFolderName);
        //        result = targetFolderName;
        //    }
        //    return result;
        //}

        public string GetCurrentFolderName(string userName)
        {
            string result = $"{HttpContext.Current.Server.MapPath(@"\UploadedImages")}\\{userName}";
            return result;
        }
    }
}
