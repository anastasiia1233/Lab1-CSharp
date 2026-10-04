using System;
using System.IO;

namespace FileOperationsGenerator
{
    internal class FileGenerator
    {
        private string mainFolder = "TestFiles";

        public int FoldersCount { get; private set; }
        public int FilesCount { get; private set; }

        public void Generate(
            int foldersCount,
            int filesCount,
            string[] extensions,
            bool readOnly)
        {
            FoldersCount = 0;
            FilesCount = 0;

            if (Directory.Exists(mainFolder))
            {
                DirectoryInfo oldDirectory = new DirectoryInfo(mainFolder);

                foreach (FileInfo file in oldDirectory.GetFiles("*", SearchOption.AllDirectories))
                {
                    file.Attributes = FileAttributes.Normal;
                }
            }

            Directory.CreateDirectory(mainFolder);

            Random random = new Random();

            for (int i = 1; i <= foldersCount; i++)
            {
                string folderPath = Path.Combine(
                    mainFolder,
                    $"Folder_{i}"
                );

                Directory.CreateDirectory(folderPath);
                FoldersCount++;

                for (int j = 1; j <= filesCount; j++)
                {
                    string extension =
                        extensions[random.Next(extensions.Length)];

                    string fileName = $"File_{j}{extension}";

                    string filePath = Path.Combine(
                        folderPath,
                        fileName
                    );

                    int fileSize = random.Next(100, 5001);

                    string content = new string('A', fileSize);

                    File.WriteAllText(filePath, content);

                    if (readOnly)
                    {
                        File.SetAttributes(
                            filePath,
                            FileAttributes.ReadOnly
                        );
                    }

                    FilesCount++;
                }
            }
        }

        public void Clear()
        {
            if (Directory.Exists(mainFolder))
            {
                DirectoryInfo directory = new DirectoryInfo(mainFolder);

                FileInfo[] files = directory.GetFiles(
                    "*",
                    SearchOption.AllDirectories
                );

                foreach (FileInfo file in files)
                {
                    file.Attributes = FileAttributes.Normal;
                }

                Directory.Delete(mainFolder, true);
            }
        }
    }
}