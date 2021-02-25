using System.IO;
using System.Threading.Tasks;

namespace HtmlToWord.Services
{
    public interface IFileService
    {
        void SaveAndView(string fileName, MemoryStream stream);
    }
}
