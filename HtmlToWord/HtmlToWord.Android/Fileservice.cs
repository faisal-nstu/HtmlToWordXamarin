using HtmlToWord.Droid;
using HtmlToWord.Services;
using Java.IO;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Fileservice))]
namespace HtmlToWord.Droid
{
    public class Fileservice : IFileService
    {
        public void SaveAndView(string fileName, MemoryStream stream)
        {
            try
            {
                string root = null;
                //Get the root path in android device.
                if (Android.OS.Environment.IsExternalStorageEmulated)
                {
                    root = Android.OS.Environment.ExternalStorageDirectory.ToString();
                }
                else
                    root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                //Create directory and file 
                Java.IO.File myDir = new Java.IO.File(root + "/DocProject");
                myDir.Mkdir();

                Java.IO.File file = new Java.IO.File(myDir, fileName);

                //Remove if the file exists
                if (file.Exists()) file.Delete();

                //Write the stream into the file
                FileOutputStream outs = new FileOutputStream(file);
                outs.Write(stream.ToArray());
                outs.Flush();
                outs.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("error: " + ex.Message);
            }
        }
    }
}