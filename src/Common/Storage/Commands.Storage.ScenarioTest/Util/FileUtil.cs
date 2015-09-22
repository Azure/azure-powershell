// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Util
{
    class FileUtil
    {
        private static string[] specialNames = { "pageabc", "blockabc ", "pagea b", "block abc", "page中文", 
            "block中 文", "page 中文", "block中文 ", "page.abc", "block.a bc", "page .abc", "block .abc ", string.Empty };
        private static Random random = new Random();

        public static string GetSpecialFileName()
        {
            int nameCount = specialNames.Count() - 1;
            int specialIndex = random.Next(0, nameCount);
            string prefix = specialNames[specialIndex];
            return Utility.GenNameString(prefix);
        }

        /// <summary>
        /// generate temp files using StorageTestLib helper
        /// </summary>
        /// <param name="rootPath">the root dir path</param>
        /// <param name="relativePath">the relative dir path</param>
        /// <param name="depth">sub dir depth</param>
        /// <param name="files">a list of created files</param>
        private static void GenerateTempFiles(string rootPath, string relativePath, int depth, List<string> files)
        {
            //minEntityCount should not be 0 after using parallel uploading and downloading. refer to bug#685185
            int minEntityCount = 1;
            int maxEntityCount = 5;
            int maxFileSize = 10; //KB

            int fileCount = random.Next(minEntityCount, maxEntityCount);
            

            for (int i = 0; i < fileCount; i++)
            {
                int fileSize = random.Next(1, maxFileSize);
                string fileName = Path.Combine(relativePath, GetSpecialFileName());
                string filePath = Path.Combine(rootPath, fileName);
                files.Add(fileName);
                Helper.GenerateRandomTestFile(filePath, fileSize);
                Test.Info("Create a {0}kb test file '{1}'", fileSize, filePath);
            }

            int dirCount = random.Next(minEntityCount, maxEntityCount);
            for (int i = 0; i < dirCount; i++)
            {
                string prefix = GetSpecialFileName();
                string dirName = Path.Combine(relativePath, Utility.GenNameString(string.Format("dir{0}", prefix)));
                //TODO dir name should contain space
                dirName = dirName.Replace(" ", "");
                string absolutePath = Path.Combine(rootPath, dirName);
                Directory.CreateDirectory(absolutePath);
                Test.Info("Create directory '{0}'", absolutePath);

                if (depth >= 1)
                {
                    GenerateTempFiles(rootPath, dirName, depth - 1, files);
                }
            }
        }

        /// <summary>
        /// Create directory if not exists
        /// </summary>
        /// <param name="dirPath"></param>
        public static void CreateDirIfNotExits(string dirPath)
        {
            Directory.CreateDirectory(dirPath);
        }

        /// <summary>
        /// create temp dirs and files
        /// </summary>
        /// <param name="rootPath">the destination dir</param>
        /// <param name="depth">sub dir depth</param>
        /// <returns>a list of created files</returns>
        public static List<string> GenerateTempFiles(string rootPath, int depth)
        {
            List<string> files = new List<string>();
            files.Clear();
            GenerateTempFiles(rootPath, string.Empty, depth, files);
            files.Sort();
            return files;
        }

        /// <summary>
        /// clean the specified dir
        /// </summary>
        /// <param name="directory">the destination dir</param>
        public static void CleanDirectory(string directory)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);

            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                CleanDirectory(subdir.FullName);
                subdir.Delete();
            }

            Test.Info("Clean directory {0}", directory);
        }

        /// <summary>
        /// Remove the specified file
        /// </summary>
        /// <param name="filePath">File Path</param>
        public static void RemoveFile(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            file.Delete();
        }

        /// <summary>
        /// Generate a temp local file for testing
        /// </summary>
        /// <returns>The temp local file path</returns>
        public static string GenerateOneTempTestFile()
        {
            string fileName = GetSpecialFileName();
            string uploadDirRoot = Test.Data.Get("UploadDir");
            string filePath = Path.Combine(uploadDirRoot, fileName);
            int minFileSize = 1; //KB
            int maxFileSize = 10 * 1024; //KB
            int fileSize = random.Next(minFileSize, maxFileSize);
            Helper.GenerateRandomTestFile(filePath, fileSize);
            return filePath;
        }
    }
}
