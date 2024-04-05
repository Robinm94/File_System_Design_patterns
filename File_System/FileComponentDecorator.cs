using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_System
{
    // Decorator pattern abstract component
    public class FileComponentDecorator : FileComponent, IFileSystemComponent
    {
        protected FileComponent fileComponent;
        
        [SetsRequiredMembers]
        public FileComponentDecorator(FileComponent fileComponent)
        {
            this.fileComponent = fileComponent;
            Name = fileComponent.Name;
            Size = fileComponent.Size;
        }

        public void SetComponent(FileComponent fileComponent)
        {
            this.fileComponent = fileComponent;
        }

        public override void AddComponent(IFileSystemComponent component)
        {
            if (fileComponent != null)
            {
                fileComponent.AddComponent(component);
            }
        }

        public override string Display(int level = 0)
        {
            if (fileComponent != null)
            {
                return fileComponent.Display(level);
            }
            return string.Empty;
        }

        public override string DisplaySize()
        {
            if (fileComponent != null)
            {
                return fileComponent.DisplaySize();
            }
            return string.Empty;
        }

        public override List<IFileSystemComponent>? GetComponents()
        {
            if (fileComponent != null && fileComponent is not File)
            {
                return fileComponent.GetComponents();
            }
            return null;
        }

        public override void RemoveComponent(IFileSystemComponent component)
        {
            if (fileComponent != null)
            {
                fileComponent.RemoveComponent(component);
            }
        }
    }

    public class EncryptedFileDecorator : FileComponentDecorator
    {
        [SetsRequiredMembers]
        public EncryptedFileDecorator(FileComponent fileComponent) : base(fileComponent)
        {
        }

        public override string Display(int level = 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                sb.Append("    ");
            }
            if (fileComponent != null)
            {
                sb.Append("Encrypted: " + fileComponent.Display(level).Trim());
                return sb.ToString();
            }
            return string.Empty;
        }

        public override string DisplaySize()
        {
            if (fileComponent != null)
            {
                return fileComponent.DisplaySize();
            }
            return string.Empty;
        }
    }

    public class CompressedFileDecorator : FileComponentDecorator
    {
        [SetsRequiredMembers]
        public CompressedFileDecorator(FileComponent fileComponent) : base(fileComponent)
        {
            Compresser(fileComponent);
        }

        public override string Display(int level = 0)
        {
            if (fileComponent != null)
            {
                return "Compressed: " + fileComponent.Display(level).Trim();
            }
            return string.Empty;
        }

        public override string DisplaySize()
        {
            if (fileComponent != null)
            {
                 
                return fileComponent.DisplaySize();
            }
            return string.Empty;
        }

        private void Compresser(IFileSystemComponent fileComponent)
        {
            if (fileComponent is File)
            {
                FileComponent file = (FileComponent)fileComponent;
                file.Size = file.Size / 2;
            }
            else if (fileComponent.GetComponents() != null)
            {
                foreach (IFileSystemComponent component in fileComponent.GetComponents()!)
                {
                    Compresser(component);
                }
            }
        }
    }

    public enum Permission
    {
        Read,
        Write,
        Execute
    }

    public class PermissionFileDecorator : FileComponentDecorator
    {
        private Permission permission;

        [SetsRequiredMembers]
        public PermissionFileDecorator(FileComponent fileComponent, Permission permission) : base(fileComponent)
        {
            this.permission = permission;
        }

        public override string Display(int level = 0)
        {
            if (fileComponent != null)
            {
                return "Permission: " + permission + ", " + fileComponent.Display(level).Trim();
            }
            return string.Empty;
        }

        public override string DisplaySize()
        {
            if (fileComponent != null)
            {
                return fileComponent.DisplaySize();
            }
            return string.Empty;
        }
    }
}
