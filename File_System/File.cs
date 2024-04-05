using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_System
{
    public class File : FileComponent, IFileSystemComponent
    {
        [SetsRequiredMembers]
        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }

        // try to add a component to the file
        public override void AddComponent(IFileSystemComponent component)
        {
            Console.WriteLine("Cannot add to a file.");
            return;
        }

        // Display the file
        public override string Display(int level)
        {
            // Add spaces to indent the file to give a tree-like structure
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                sb.Append("    ");
            }
            if (storageProvider != null)
            {
                sb.Append(storageProvider.StorageDisplay());
            }
            sb.Append("File: " + Name + ", Size: " + Size);
            return sb.ToString();
        }

        // Display the size of the file
        public override string DisplaySize()
        {
            return ("Size: " + Size);
        }

        // Try to get the components of the file
        public override List<IFileSystemComponent>? GetComponents()
        {
            Console.WriteLine("Cannot get components of a file.");
            return null;
        }

        // Try to remove a component from the file
        public override void RemoveComponent(IFileSystemComponent component)
        {
            Console.WriteLine("Cannot remove from a file.");
            return;
        }
    }
}
