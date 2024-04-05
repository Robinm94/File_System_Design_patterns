using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_System
{
    public interface IFileSystemComponent
    {
        string DisplaySize();
        void AddComponent(IFileSystemComponent component);
        void RemoveComponent(IFileSystemComponent component);
        string Display(int level = 0);
        List<IFileSystemComponent>? GetComponents();
    }
}
