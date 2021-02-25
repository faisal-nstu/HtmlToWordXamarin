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
        public async Task<bool> SavePicture(string name, Stream data, string location = "temp")
        {


            byte[] bArray = new byte[data.Length];

            using (data)
            {
                data.Read(bArray, 0, (int)data.Length);
            }

            try
            {
                string folder = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                string path = System.IO.Path.Combine(folder, name);
                System.IO.File.Create(path);

                Java.IO.File file = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, name);
                OutputStream os = new FileOutputStream(file);
                os.Write(bArray);
                os.Close();
                return await Task.FromResult(true);
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine("error: " + exception.Message);
                return await Task.FromResult(false);
            }


            //string folder = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            //string path = System.IO.Path.Combine(folder, "test.txt");

            //try
            //{
            //    System.IO.File.Create(path);
            //    return await Task.FromResult(true);
            //}
            //catch (System.Exception exception)
            //{
            //    return await Task.FromResult(false);
            //}
        }

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
                Java.IO.File myDir = new Java.IO.File(root + "/meusarquivos");
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