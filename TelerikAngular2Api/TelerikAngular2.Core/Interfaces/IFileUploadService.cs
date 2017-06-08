using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAngular2.Data.Models;

namespace TelerikAngular2.Core.Interfaces
{
    public interface IFileUploadService
    {
        bool SaveFile(string fileName, byte[] fileBytes, Guid userId, string markerId, string tokenLat, string tokenLng);

       // string SetNameToUploadFolder(string userName, string uploadGuid);

        string GetCurrentFolderName(string userName);

      IEnumerable<Image> GetImages(string markerId);
    }
}
