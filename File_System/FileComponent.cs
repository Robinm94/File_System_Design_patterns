using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_System
{
    public abstract class FileComponent : IFileSystemComponent
    {
        protected IStorageProvider? storageProvider;
        public required string Name { get; set; }
        public virtual int Size { get; set; }

        public abstract void AddComponent(IFileSystemComponent component);

        public abstract string Display(int level = 0);

        public abstract string DisplaySize();

        public abstract List<IFileSystemComponent>? GetComponents();

        public abstract void RemoveComponent(IFileSystemComponent component);

        public void SetStorageProvider(IStorageProvider storageProvider)
        {
            this.storageProvider = storageProvider;
        }

        public string StorageInfo()
        {
            if (storageProvider != null)
            {
                return storageProvider.StorageInfo(this.Name,this.Size);
            }
            return "Storage Provider not set";
        }
        
    }
}
