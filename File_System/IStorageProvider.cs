using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_System
{
    // Bridge pattern Interface
    public interface IStorageProvider
    {
        string StorageInfo(string name, int size);

        string StorageDisplay();
    }

    public class LocalStorageProvider : IStorageProvider
    {
        public string StorageInfo(string name, int size)
        {
            return $"File {name} with size {size} is stored on local storage";
        }

        public string StorageDisplay()
        {
            return "Stored in Local Storage: ";
        }
    }

    public class CloudStorageProvider : IStorageProvider
    {
        public string StorageInfo(string name, int size)
        {
            return $"File {name} with size {size} is stored on the cloud";
        }

        public string StorageDisplay()
        {
            return "Stored in Cloud Storage: ";
        }
    }
}
