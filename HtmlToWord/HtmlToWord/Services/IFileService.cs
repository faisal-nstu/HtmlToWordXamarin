using System.IO;
using System.Threading.Tasks;

namespace HtmlToWord.Services
{
    public interface IFileService
    {
        Task<bool> SavePicture(string name, Stream data, string location = "temp");
        void SaveAndView(string fileName, MemoryStream stream);
    }
}
