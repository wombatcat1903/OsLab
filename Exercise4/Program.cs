using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DownloadManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> fileUrls = new List<string>
            {
                "https://www.w3resource.com/csharp-exercises/data-types/index.php",
                "https://file-examples.com/storage/feeb836c2d66294eb99ac59/2017/10/file-sample_150kB.pdf",
                "https://file-examples.com/wp-content/storage/2017/02/file_example_XLS_50.xls",
                "https://file-examples.com/wp-content/storage/2017/02/file_example_XLS_100.xls",
                "https://file-examples.com/wp-content/storage/2017/02/file-sample_100kB.doc",
                "https://file-examples.com/wp-content/storage/2017/02/file_example_XLS_10.xls",
                "https://file-examples.com/wp-content/storage/2017/10/file_example_JPG_100kB.jpg",
                "https://file-examples.com/wp-content/storage/2017/10/file_example_PNG_500kB.png",
                "https://file-examples.com/wp-content/storage/2017/10/file_example_GIF_500kB.gif",
                "https://file-examples.com/wp-content/storage/2017/10/file_example_favicon.ico",
            };

            await DownloadFilesAsync(fileUrls);
        }

        static async Task DownloadFilesAsync(List<string> fileUrls)
        {
            var tasks = new List<Task>();

            foreach (var url in fileUrls)
            {
                tasks.Add(DownloadFileAsync(url));
            }

            await Task.WhenAll(tasks);
        }

        static async Task DownloadFileAsync(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var fileName = Path.GetFileName(url);
                    await client.DownloadFileTaskAsync(url, fileName);
                    Console.WriteLine($"Downloaded: {fileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading {url}: {ex.Message}");
            }
        }
    }
}
