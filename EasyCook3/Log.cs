using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using System.IO;

namespace EasyCook3
{
    public class Log
    {
        string appDataDirectory = FileSystem.Current.AppDataDirectory;

        public async Task CreateTextFileAsync(string fileName, string content)
        {
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                await writer.WriteAsync(content);
            }
        }


    }
}
