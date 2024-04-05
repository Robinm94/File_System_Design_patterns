using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_System
{
    public class Directory : FileComponent, IFileSystemComponent
    {
        public override int Size
        {
            // Get the size of the directory by summing the sizes of its components
            get
            {
                int size = 0;
                foreach (FileComponent component in components)
                {
                    size += component.Size;
                }
                return size;
            }
        }
        
        // List of components in the directory
        private List<IFileSystemComponent> components = new List<IFileSystemComponent>();
        
        [SetsRequiredMembers]
        public Directory(string name)
        {
            Name = name;
        }

        // Add a component to the directory
        public override void AddComponent(IFileSystemComponent component)
        {
            components.Add(component);
        }

        // Display the directory
        public override string Display(int level)
        {
            // Add spaces to indent the directory to give a tree-like structure
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                sb.Append("    ");
            }
            if (storageProvider != null)
            {
                sb.Append(storageProvider.StorageDisplay());
            }
            sb.Append("Directory: " + Name + ", Size: " + Size);
            foreach (IFileSystemComponent component in components)
            {
                sb.Append("\n" + component.Display(level + 1));
            }
            return sb.ToString();
        }

        // Display the size of the directory
        public override string DisplaySize()
        {
            return ("Size: " + Size);
        }

        // Get the components of the directory
        public override List<IFileSystemComponent> GetComponents()
        {
            return components;
        }

        // Remove a component from the directory
        public override void RemoveComponent(IFileSystemComponent component)
        {
            components.Remove(component);
        }
    }
}
