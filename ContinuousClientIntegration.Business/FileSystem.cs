using System.IO;

namespace ContinuousClientIntegration.Business
{
    public class FileSystem : IFileSystem
    {
        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        public void CreateDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }
        public void DeleteDirectory(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath, true);
            }
            catch { }
        }
    }
}
