using System;
using System.IO;
using System.Threading.Tasks;

namespace GestorTutelas.webApi.Services
{

    public class LocalFileClient : IFileClient
    {
        private string _fileRoot;

        public LocalFileClient(string fileRoot)
        {
            _fileRoot = fileRoot;
        }

        public async Task DeleteFile(string storeName, string filePath)
        {
            var path = Path.Combine(_fileRoot, storeName, filePath);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public Task<bool> FileExists(string storeName, string filePath)
        {
            var path = Path.Combine(_fileRoot, storeName, filePath);

            return Task.FromResult(File.Exists(path));
        }

        public async Task<Stream> GetFile(string storeName, string filePath)
        {
            var path = Path.Combine(_fileRoot, storeName, filePath);
            Stream stream = null;

            if (File.Exists(path))
            {
                stream = File.OpenRead(path);
            }

            return await Task.FromResult(stream);
        }

        public async Task<string> GetFileUrl(string storeName, string filePath)
        {
            return await Task.FromResult((string)null);
        }

        public async Task SaveFile(string storeName, string filePath, Stream fileStream)
        {
            var fileDirectory= Path.Combine(_fileRoot, storeName); 
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            var path = Path.Combine(fileDirectory, filePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var file = new FileStream(path, FileMode.CreateNew))
            {
                await fileStream.CopyToAsync(file);
            }
        }
    }
}