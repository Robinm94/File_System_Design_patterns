namespace File_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a root folder with a file('File1') and a subfolder('Subfolder1') with a file.");
            FileComponent root_folder1 = new Directory("Root");

            Console.WriteLine("Creating File1 in the root folder with size 100.");
            FileComponent file1 = new File("File1", 100);

            Console.WriteLine("Adding File1 to the root folder.");
            root_folder1.AddComponent(file1);

            Console.WriteLine("Creating a subfolder('Subfolder1') in the root folder.");
            FileComponent subfolder1 = new Directory("Subfolder1");

            Console.WriteLine("Creating File2 in the Subfolder1 with size 200.");
            FileComponent file2 = new File("File2", 200);

            Console.WriteLine("Adding the File2 to the Subfolder1.");
            subfolder1.AddComponent(file2);

            Console.WriteLine("Adding the Subfolder1 to the root folder.");
            root_folder1.AddComponent(subfolder1);

            Console.WriteLine();
            Console.WriteLine("Displaying the root folder.");
            Console.WriteLine(root_folder1.Display());

            Console.WriteLine();
            Console.WriteLine("Removing File1 from the root folder.");
            root_folder1.RemoveComponent(file1);
            Console.WriteLine(root_folder1.Display());

            Console.WriteLine();
            Console.WriteLine("Displaying the root folder.");
            Console.WriteLine(root_folder1.Display());

            Console.WriteLine();
            Console.WriteLine("Compressing the root folder");
            FileComponentDecorator compressedRootFolder = new CompressedFileDecorator(root_folder1);
            Console.WriteLine(compressedRootFolder.Display());

            Console.WriteLine();
            Console.WriteLine("Encrypting a new file3 and adding it to root folder ");
            FileComponent file3 = new File("File3", 100);
            FileComponentDecorator encryptedFile3 = new EncryptedFileDecorator(file3);
            root_folder1.AddComponent(encryptedFile3);
            Console.WriteLine(root_folder1.Display());

            Console.WriteLine();
            Console.WriteLine("Setting Read Permissions for the root folder");
            FileComponentDecorator fileComponentDecorator = new PermissionFileDecorator(root_folder1, Permission.Read);
            Console.WriteLine(fileComponentDecorator.Display());

            Console.WriteLine();
            Console.WriteLine("Storing the root folder on the cloud");
            IStorageProvider cloudStorage = new CloudStorageProvider();
            root_folder1.SetStorageProvider(cloudStorage);
            Console.WriteLine(root_folder1.StorageInfo());
            Console.WriteLine(root_folder1.Display());

            Console.WriteLine();
            Console.WriteLine("Storing the root folder on the local storage");
            IStorageProvider localStorage = new LocalStorageProvider();
            root_folder1.SetStorageProvider(localStorage);
            Console.WriteLine(root_folder1.StorageInfo());
            Console.WriteLine(root_folder1.Display());

        }
    }
}
