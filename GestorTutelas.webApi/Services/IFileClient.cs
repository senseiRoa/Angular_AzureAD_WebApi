using System;
using System.IO;
using System.Threading.Tasks;

namespace GestorTutelas.webApi.Services
{

    public interface IFileClient 
    {
        Task DeleteFile(string storeName, string filePath);
        Task<bool> FileExists(string storeName, string filePath);
        Task<Stream> GetFile(string storeName, string filePath);
        Task<string> GetFileUrl(string storeName, string filePath);
        Task SaveFile(string storeName, string filePath, Stream fileStream);
    }

}