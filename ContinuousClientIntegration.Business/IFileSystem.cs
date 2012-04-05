using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContinuousClientIntegration.Business
{
    public interface IFileSystem
    {
        bool DirectoryExists(string directoryPath);
        void CreateDirectory(string directoryPath);
        void DeleteDirectory(string directoryPath);
    }
}
