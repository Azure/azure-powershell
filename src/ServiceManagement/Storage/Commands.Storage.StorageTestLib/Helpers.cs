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
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using MS.Test.Common.MsTestLib;

namespace StorageTestLib
{
    /// <summary>
    /// this is a static helper class
    /// </summary>
    public static class Helper
    {
        
        public static void CreateContainer()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(Test.Data.Get("StorageConnectionString"));

            CloudBlobHelper blobHelper = new CloudBlobHelper(account);

            string containerName = Test.Data.Get("containerName");

            if (blobHelper.CreateContainer(containerName))
            {
                Console.WriteLine("Cloud Blob {0} is successfully created.", containerName);
            }
            else
            {
                Console.WriteLine("Cloud Blob {0} already exists.", containerName);
            }

            return;

        }


        
        public static void DeleteContainer()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(Test.Data.Get("StorageConnectionString"));

            CloudBlobHelper blobHelper = new CloudBlobHelper(account);

            string containerName = Test.Data.Get("containerName");

            if (blobHelper.DeleteContainer(containerName))
            {
                Console.WriteLine("Cloud Blob {0} is successfully deleted.", containerName);
            }
            else
            {
                Console.WriteLine("Cloud Blob {0} not found.", containerName);
            }

            return;
        }


        public static void GenerateSmallFile(string filename, int sizeKB)
        {
            byte[] data = new byte[sizeKB * 1024];
            Random r = new Random(123456);
            r.NextBytes(data);
            File.WriteAllBytes(filename, data);
            return;
        }


        public static void GenerateTinyFile(string filename, int sizeB)
        {
            byte[] data = new byte[sizeB];
            Random r = new Random(123456);
            r.NextBytes(data);
            File.WriteAllBytes(filename, data);
            return;
        }


        public static void AggregateFile(string filename, int times)
        {
            using (FileStream outputStream = new FileStream(filename, FileMode.Create))
            {
                using (FileStream inputStream = new FileStream("abc.txt", FileMode.Open))
                {
                    for (int i = 0; i < times; i++)
                    {
                        inputStream.CopyTo(outputStream);
                        inputStream.Seek(0, SeekOrigin.Begin);
                    }
                }

            }

        }



        public static void CompressFile(string filename, int times)
        {
            using (FileStream outputStream = new FileStream(filename, FileMode.Create))
            {
                using (GZipStream compress = new GZipStream(outputStream, CompressionMode.Compress))
                {

                    using (FileStream inputStream = new FileStream("abc.txt", FileMode.Open))
                    {
                        for (int i = 0; i < times; i++)
                        {
                            inputStream.CopyTo(compress);
                            inputStream.Seek(0, SeekOrigin.Begin);
                        }
                    }
                }

            }

        }


        //it takes around 74 seconds to generate a 5G file
        public static void GenerateMediumFile(string filename, int sizeMB)
        {
            byte[] data = new byte[1024 * 1024];
            Random r = new Random(123456);
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                for (int i = 0; i < sizeMB; i++)
                {
                    r.NextBytes(data);
                    stream.Write(data, 0, data.Length);
                }
            }
            return;

        }


        // the buffer is too large, better to use GenerateMediumFile
        public static void GenerateBigFile(string filename, int sizeGB)
        {
            byte[] data = new byte[1024 * 1024 * 1024];
            Random r = new Random(123456);
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                for (int i = 0; i < sizeGB; i++)
                {
                    r.NextBytes(data);
                    stream.Write(data, 0, data.Length);
                }
            }
            return;

        }

        //this is only for small data 
        public static byte[] GetMD5(byte[] data)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(data);
        }


        public static void GenerateRandomTestFile(string filename, int sizeKB)
        {
            byte[] data = new byte[sizeKB * 1024];
            Random r = new Random();
            r.NextBytes(data);
            File.WriteAllBytes(filename, data);
        }

        public static void DeleteFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

        }

        public static void DeleteFolder(string foldername)
        {
            if (Directory.Exists(foldername))
            {
                Directory.Delete(foldername, true);
            }
        }

        public static void DeletePattern(string pathPattern)
        {
            DirectoryInfo folder = new DirectoryInfo(".");
            foreach (FileInfo fi in folder.GetFiles(pathPattern, SearchOption.TopDirectoryOnly))
            {
                fi.Delete();
            }
            foreach (DirectoryInfo di in folder.GetDirectories(pathPattern, SearchOption.TopDirectoryOnly))
            {
                di.Delete(true);
            }
        }


        public static void CreateNewFolder(string foldername)
        {
            if (Directory.Exists(foldername))
            {
                Directory.Delete(foldername, true);
            }
            Directory.CreateDirectory(foldername);
        }

        // for a 5G file, this can be done in 20 seconds
        public static string GetFileMD5Hash(string filename)
        {

            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                MD5 md5 = MD5.Create();
                byte[] md5Hash = md5.ComputeHash(fs);


                StringBuilder sb = new StringBuilder();
                foreach (byte b in md5Hash)
                {
                    sb.Append(b.ToString("x2").ToLower());
                }

                return sb.ToString();

            }

        }


        public static string GetFileContentMD5(string filename)
        {
            using (FileStream fs = File.Open(filename, FileMode.Open))
            {
                MD5 md5 = MD5.Create();
                byte[] md5Hash = md5.ComputeHash(fs);


                return Convert.ToBase64String(md5Hash);

            }

        }


        public static void GenerateFixedTestTree(string filename, string foldername, string currentFolder, int size, int layer)
        {
            for (int i = 0; i < size; i++)
            {
                GenerateRandomTestFile(currentFolder + "\\" + filename + "_" + i, i);
            }
            
            if (layer > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    Directory.CreateDirectory(currentFolder + "\\" + foldername + "_" + i);
                    GenerateFixedTestTree(filename, foldername, currentFolder + "\\" + foldername + "_" + i, size, layer - 1);
                }
                            
            }

        }

        public static bool CompareTwoFiles(string filename, string filename2)
        {
            FileInfo fi = new FileInfo(filename);
            FileInfo fi2= new FileInfo(filename2);
            return CompareTwoFiles(fi, fi2);
        }

        public static bool CompareTwoFiles(FileInfo fi, FileInfo fi2)
        {
            if (!fi.Exists || !fi2.Exists)
            {
                return false;
            }
            if (fi.Length != fi.Length)
            {
                return false;
            }

            long fileLength = fi.Length;
            // 200M a chunk
            const int ChunkSizeByte = 200 * 1024 * 1024;
            using (FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fs2 = new FileStream(fi2.FullName, FileMode.Open, FileAccess.Read))
                {

                    BinaryReader reader = new BinaryReader(fs);
                    BinaryReader reader2 = new BinaryReader(fs2);

                    long comparedLength = 0;
                    do
                    {

                        byte[] bytes = reader.ReadBytes(ChunkSizeByte);
                        byte[] bytes2 = reader2.ReadBytes(ChunkSizeByte);

                        MD5 md5 = MD5.Create();
                        byte[] md5Hash = md5.ComputeHash(bytes);
                        byte[] md5Hash2 = md5.ComputeHash(bytes2);

                        if (!md5Hash.SequenceEqual(md5Hash2))
                        {
                            return false;
                        }

                        comparedLength += bytes.Length;

                    }
                    while (comparedLength < fileLength);

                }
            }

            return true;
        }

        
        public static bool CompareTwoFolders(string foldername, string foldername2)
        {
            DirectoryInfo folder = new DirectoryInfo(foldername);
            DirectoryInfo folder2 = new DirectoryInfo(foldername2);

            IEnumerable<FileInfo> list = folder.GetFiles("*.*", SearchOption.AllDirectories);
            IEnumerable<FileInfo> list2 = folder2.GetFiles("*.*", SearchOption.AllDirectories);
            
            FileCompare fc = new FileCompare();

            return list.SequenceEqual(list2, fc);
        }

        public static bool CompareFolderWithBlob(string foldername, string containerName)
        {
            return true;
        }

        public static bool CompareTwoBlobs(string containerName, string containerName2)
        {
            return false; //todo: implement
        }

        public static void verifyFilesExistinBlobDirectory(int fileNumber, CloudBlobDirectory blobDirectory, string FileName, String blobType)
        {

            for (int i = 0; i < fileNumber; i++)
            {
                if (blobType == BlobType.Block)
                {
                    CloudBlockBlob blob = blobDirectory.GetBlockBlobReference(FileName + "_" + i);
                    if (null == blob || !blob.Exists())
                        Test.Error("the file {0}_{1} in the blob virtual directory does not exist:", FileName, i);
                }
                else if (blobType == BlobType.Page)
                {
                    CloudPageBlob blob = blobDirectory.GetPageBlobReference(FileName + "_" + i);
                    if (null == blob || !blob.Exists())
                        Test.Error("the file {0}_{1} in the blob virtual directory does not exist:", FileName, i);
                }
            }
        }

        public static void writePerfLog(string log)
        {
            if (!File.Exists(perfLogName))
            {
                Test.Info("The perflog name is: {0}", perfLogName);
                FileStream fs1 = File.Create(perfLogName);
                fs1.Close();
            }
            StreamWriter fs = File.AppendText(perfLogName);
            fs.WriteLine(log);
            fs.Close();
        }

        private static string perfLogName = @".\perf_" + DateTime.Now.ToString().Replace('\\', '-').Replace('/', '-').Replace(':', '-') + ".csv";



        public static bool killProcess(string processName)
        {
            try
            {
                Process[] procs = Process.GetProcessesByName(processName);
                if (procs.Length == 0)
                {
                    Test.Info("No {0} process exist, so no process will be killed", processName);
                    return false;
                }
                foreach (Process p in procs)
                {
                    Test.Info("Try to kill {0} process : {1}", processName, p.Id);
                    p.Kill();
                    p.WaitForExit();
                }
                return true;
            }
            catch (Exception e)
            {
                Test.Warn("Exception happen when kill {0}: {1}", processName, e.ToString());
                return false;
            }
        }

        public delegate bool StopProcess(Process p);
        public static bool StopProcessByBreakNetwork(Process p)
        {
            String processName = Path.GetFileNameWithoutExtension(p.MainModule.FileName);
            Test.Info("Stop {0} by BreakNetwork.", processName);
            try
            {
                int i = 0;
                Helper.StartProcess("ipconfig", "/release");
                System.Threading.Thread.Sleep(5000);
                try //Send Ctrl+c so only need to for 1 round of 900s, or need to wait for filenumber/thread *900s
                {
                    Test.Info("Send ctrl+C.");
                    Test.Assert(SetConsoleCtrlHandler(null, true), "SetConsoleCtrlHandler should success");
                    System.Threading.Thread.Sleep(5000);
                    Test.Assert(GenerateConsoleCtrlEvent(ConsoleCtrlEvent.CTRL_C_EVENT, 0), "GenerateConsoleCtrlEvent should success");
                    System.Threading.Thread.Sleep(2000);
                    Test.Assert(SetConsoleCtrlHandler(null, false), "SetConsoleCtrlHandler should success");
                }
                catch (Exception e)
                {
                    Test.Warn("can't send ctrl+c to {0}: {1}", processName, e.ToString());
                } 
                for (i = 0; i < 100; i++)
                {
                    if (p.HasExited)
                    {
                        Helper.StartProcess("ipconfig", "/renew");
                        System.Threading.Thread.Sleep(5000); //wait 5s for IP to restore
                        return true;
                    }
                    Test.Info("wait 10 s for {0} finish. Time: {1}", processName, i);
                    System.Threading.Thread.Sleep(10000);//As need 900s for process to exist, so wait up to 1000s.
                }
                Test.Warn("{0} doesn't stop successfully by Break Network. it's killed", processName);
                p.Kill();
                Helper.StartProcess("ipconfig", "/renew");
                return false;
            }
            catch (Exception)
            {
                Helper.StartProcess("ipconfig", "/renew");
                System.Threading.Thread.Sleep(5000);//wait 5s for IP to restore
                return false;
            }
        }

        public static bool StopProcessByCtrlC(Process p)
        {
            String processName = Path.GetFileNameWithoutExtension(p.MainModule.FileName);
            Test.Info("Stop {0} by Ctrl+c.", processName);
            int i = 0;
            try
            {
                Test.Info("Send ctrl+C.");
                Test.Assert(SetConsoleCtrlHandler(null, true), "SetConsoleCtrlHandler should success");
                System.Threading.Thread.Sleep(5000);
                Test.Assert(GenerateConsoleCtrlEvent(ConsoleCtrlEvent.CTRL_C_EVENT, 0), "GenerateConsoleCtrlEvent should success");
                System.Threading.Thread.Sleep(2000);
                Test.Assert(SetConsoleCtrlHandler(null, false), "SetConsoleCtrlHandler should success");
            }
            catch (Exception e)
            {
                Test.Warn("{0} doesn't stop successfully by ctrl+c. it's killed: {1}", processName, e.ToString());
                System.Threading.Thread.Sleep(10000);
                p.Kill();
                return false;
            }
            for (i = 0; i < 100; i++)
            {
                if (p.HasExited) return true;
                Test.Info("wait 10 s for {0} finish. Time: {1}", processName, i);
                System.Threading.Thread.Sleep(10000);//As need 900s for process to exist, so wait up to 1000s.
            }
            Test.Warn("{0} doesn't stop successfully by ctrl+c. it's killed", processName);
            p.Kill();
            return false;
        }

        public static bool StopProcessByKill(Process p)
        {
            String processName = Path.GetFileNameWithoutExtension(p.MainModule.FileName);
            Test.Info("Stop {0} by kill.", processName);
            p.Kill();
            return true;
        }

        public static Process StartProcess(string cmd, string args)
        {
            Test.Info("Running: {0} {1}", cmd, args);
            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            Process p = Process.Start(psi);
            return p;
        }

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        static extern bool GenerateConsoleCtrlEvent(ConsoleCtrlEvent sigevent, int dwProcessGroupId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
        public delegate bool HandlerRoutine(ConsoleCtrlEvent CtrlType);

        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum ConsoleCtrlEvent
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        public static Process StartProcess(string cmd, string args, out StreamReader stdout, out StreamReader stderr, out StreamWriter stdin)
        {
            Test.Logger.Verbose("Running: {0} {1}", cmd, args);
            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            Process p = Process.Start(psi);
            stdout = p.StandardOutput;
            stderr = p.StandardError;
            stdin = p.StandardInput;
            return p;
        }
    }


    public class FileCompare : IEqualityComparer<FileInfo>
    {
        public FileCompare() { }

        public bool Equals(FileInfo f1, FileInfo f2)
        {
            if (f1.Name != f2.Name)
            {
                Test.Verbose("file name {0}:{1} not equal {2}:{3}", f1.FullName, f1.Name, f2.FullName, f2.Name);
                return false;
            }
            
            if (f1.Length != f2.Length)
            {
                Test.Verbose("file length {0}:{1} not equal {2}:{3}", f1.FullName, f1.Length, f2.FullName, f2.Length);
                return false;
            }

            if (f1.Length < 200 * 1024 * 1024)
            {
                string f1MD5Hash = f1.MD5Hash();
                string f2MD5Hash = f2.MD5Hash();
                if (f1MD5Hash != f2MD5Hash)
                {
                    Test.Verbose("file MD5 mismatch {0}:{1} not equal {2}:{3}", f1.FullName, f1MD5Hash,f2.FullName, f2MD5Hash);
                    return false;
                }
            }
            else
            {
                if (!Helper.CompareTwoFiles(f1, f2))
                {
                    Test.Verbose("file MD5 mismatch {0} not equal {1}", f1.FullName, f2.FullName);
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(FileInfo fi)
        {
            string s = String.Format("{0}{1}", fi.Name, fi.Length);
            return s.GetHashCode();
        }
    }

    public static class FileOp
    {
        public static string MD5Hash(this FileInfo fi)
        {
            return Helper.GetFileMD5Hash(fi.FullName);
        }

        public static string NextString(Random Randomint)
        {
            int length = Randomint.Next(1, 100);
            return NextString(Randomint, length);
        }

        public static string NextString(Random Randomint, int length)
        {
            return new String(
                Enumerable.Repeat(0, length)
                    .Select(p => (char)Randomint.Next(0x20, 0xD7FF))
                    .ToArray());
        }


        public static void SetFileAttribute(string Filename, FileAttributes attribute)
        {
            FileAttributes fa = File.GetAttributes(Filename);
            if ((fa & attribute) == attribute)
            {
                Test.Info("Attribute {0} is already in file{1}. Don't need to add again.", attribute.ToString(), Filename);
                return;
            }
        
            switch (attribute)
            {
                case FileAttributes.Encrypted:
                    File.Encrypt(Filename);
                    break;
                case FileAttributes.Normal:
                    RemoveFileAttribute(Filename, FileAttributes.Encrypted);
                    RemoveFileAttribute(Filename, FileAttributes.Compressed);
                    fa = fa & ~fa | FileAttributes.Normal;
                    File.SetAttributes(Filename, fa);
                    break;
                case FileAttributes.Compressed:
                    compress(Filename);
                    break;
                default:
                    fa = fa | attribute;
                    File.SetAttributes(Filename, fa);
                    break;
            }
            Test.Info("Attribute {0} is added to file{1}.", attribute.ToString(), Filename);
        }

        public static void RemoveFileAttribute(string Filename, FileAttributes attribute)
        {
            FileAttributes fa = File.GetAttributes(Filename);
            if ((fa & attribute) != attribute)
            {
                Test.Info("Attribute {0} is NOT in file{1}. Don't need to remove.", attribute.ToString(), Filename);
                return;
            }

            switch (attribute)
            {
                case FileAttributes.Encrypted:
                    File.Decrypt(Filename);
                    break;
                case FileAttributes.Normal:
                    fa = fa | FileAttributes.Archive;
                    File.SetAttributes(Filename, fa);
                    break;
                case FileAttributes.Compressed:
                    uncompress(Filename);
                    break;
                default:
                    fa = fa & ~attribute;
                    File.SetAttributes(Filename, fa);
                    break;
            }
            Test.Info("Attribute {0} is removed from file{1}.", attribute.ToString(), Filename);
        }
        [DllImport("kernel32.dll")]
        public static extern int DeviceIoControl(IntPtr hDevice, int
        dwIoControlCode, ref short lpInBuffer, int nInBufferSize, IntPtr
        lpOutBuffer, int nOutBufferSize, ref int lpBytesReturned, IntPtr
        lpOverlapped);

        private static int FSCTL_SET_COMPRESSION = 0x9C040;
        private static short COMPRESSION_FORMAT_DEFAULT = 1;
        private static short COMPRESSION_FORMAT_NONE = 0;

        #pragma warning disable 612, 618
        public static void compress(string filename)
        {
            if ((File.GetAttributes(filename) & FileAttributes.Encrypted) == FileAttributes.Encrypted)
            {
                Test.Info("Decrypt File {0} to prepare for compress.", filename);
                File.Decrypt(filename);
            }
            int lpBytesReturned = 0;
            FileStream f = File.Open(filename, System.IO.FileMode.Open,
            System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
            int result = DeviceIoControl(f.Handle, FSCTL_SET_COMPRESSION,
            ref COMPRESSION_FORMAT_DEFAULT, 2 /*sizeof(short)*/, IntPtr.Zero, 0,
            ref lpBytesReturned, IntPtr.Zero);
            f.Close();
        }

        public static void uncompress(string filename)
        {
            int lpBytesReturned = 0;
            FileStream f = File.Open(filename, System.IO.FileMode.Open,
            System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
            int result = DeviceIoControl(f.Handle, FSCTL_SET_COMPRESSION,
            ref COMPRESSION_FORMAT_NONE, 2 /*sizeof(short)*/, IntPtr.Zero, 0,
            ref lpBytesReturned, IntPtr.Zero);
            f.Close();
        }
        #pragma warning restore 612, 618

    }


    /// <summary>
    /// This class helps to do operations on cloud blobs
    /// </summary>
    public class CloudBlobHelper
    {
        private CloudStorageAccount account;
        /// <summary>
        /// The storage account
        /// </summary>
        public CloudStorageAccount Account
        {
            get { return account; }
            private set { account = value; }
        }

        private CloudBlobClient blobClient;
        /// <summary>
        /// The blob client
        /// </summary>
        public CloudBlobClient BlobClient
        {
            get { return blobClient; }
            set { blobClient = value; }
        }

        /// <summary>
        /// Construct the helper with the storage account
        /// </summary>
        /// <param name="account"></param>
        public CloudBlobHelper(CloudStorageAccount account)
        {
            Account = account;
            BlobClient = account.CreateCloudBlobClient();
            BlobClient.DefaultRequestOptions.RetryPolicy = new LinearRetry(TimeSpan.Zero, 3);
        }


        /// <summary>
        /// Create a container for blobs
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <returns>Return true on success, false if already exists, throw exception on error</returns>
        public bool CreateContainer(string containerName)
        {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                return container.CreateIfNotExists(); 
        }

        /// <summary>
        /// Delete the container for the blobs
        /// </summary>
        /// <param name="containerName">the name of container</param>
        /// <returns>Return true on success (or the container was deleted before), false if the container doesnot exist, throw exception on error</returns>
        public bool DeleteContainer(string containerName)
        {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                return container.DeleteIfExists();
        }

        /// <summary>
        /// Set the specific container to the accesstype
        /// </summary>
        /// <param name="containerName">container Name</param>
        /// <param name="accesstype">the accesstype the contain will be set</param>
        /// <returns>the container 's permission before set, so can be set back when test case finish</returns>
        public BlobContainerPermissions SetContainerAccessType(string containerName, BlobContainerPublicAccessType accesstype)
        {
            try
            {
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                container.CreateIfNotExists();
                BlobContainerPermissions oldPerm = container.GetPermissions();
                BlobContainerPermissions blobPermissions = new BlobContainerPermissions();
                blobPermissions.PublicAccess = accesstype;
                container.SetPermissions(blobPermissions);
                return oldPerm;
            }
            catch (StorageException e)
            {
                if (null == e ||
                       null == e.RequestInformation ||
                       404 == e.RequestInformation.HttpStatusCode ||
                       null == e.RequestInformation.ExtendedErrorInformation ||
                       BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return null;
                }
                throw;
            }
        }


        /// <summary>
        /// list blobs in a container, TODO: implement this for batch operations on blobs
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobList"></param>
        /// <returns></returns>
        public bool ListBlobs(string containerName, out List<ICloudBlob> blobList)
        {
            blobList = new List<ICloudBlob>();

            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                IEnumerable<IListBlobItem> blobs = container.ListBlobs(null, true, BlobListingDetails.All);
                if (blobs != null)
                {
                    foreach (ICloudBlob blob in blobs)
                    {
                        blobList.Add(blob);
                    }
                }
                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                       null == e.RequestInformation ||
                       404 == e.RequestInformation.HttpStatusCode ||
                       null == e.RequestInformation.ExtendedErrorInformation ||
                       BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }

        /// <summary>
        /// Validate the uploaded tree which is created by Helper.GenerateFixedTestTree()
        /// </summary>
        /// <param name="filename">the file prefix of the tree</param>
        /// <param name="foldername">the folder prefix of the tree</param>
        /// <param name="currentFolder">current folder to validate</param>
        /// <param name="size">how many files in each folder</param>
        /// <param name="layer">how many folder level to verify</param>
        /// <param name="containerName">the container which contain the uploaded tree</param>
        /// <param name="empty">true means should verify the folder not exist. false means verify the folder exist.</param>
        /// <returns>true if verify pass, false mean verify fail</returns>
        public bool ValidateFixedTestTree(string filename, string foldername, string currentFolder, int size, int layer, string containerName, bool empty = false)
        {
            Test.Info("Verify the folder {0}...", currentFolder);
            for (int i = 0; i < size; i++)
            {
                string sourcefilename = currentFolder + "\\" + filename + "_" + i;
                string destblobname = currentFolder + "\\" + filename + "_" + i;
                ICloudBlob blob =  this.QueryBlob(containerName, destblobname);
                if (!empty)
                {
                    if (blob == null)
                    {
                        Test.Error("Blob {0} not exist.", destblobname);
                        return false;
                    }
                    string source_MD5 = Helper.GetFileContentMD5(sourcefilename);
                    string Dest_MD5 = blob.Properties.ContentMD5;
                    if (source_MD5 != Dest_MD5)
                    {
                        Test.Error("sourcefile:{0}: {1} == destblob:{2}:{3}", sourcefilename, source_MD5, destblobname, Dest_MD5);              
                        return false;
                    }
                }
                else
                {
                    if (blob != null && blob.Properties.Length !=0)
                    {
                        Test.Error("Blob {0} should not exist.", destblobname);
                        return false;
                    }
                }
            }
            if (layer > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    if (! ValidateFixedTestTree(filename, foldername, currentFolder + "\\" + foldername + "_" + i, size, layer - 1, containerName, empty))
                        return false;
                }

            }
            return true;

        }

        /// <summary>
        /// Get SAS of a container with specific permission and period
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <param name="sap">the permission of the SAS</param>
        /// <param name="validatePeriod">How long the SAS will be valid before expire, in second</param>
        /// <returns>the SAS</returns>
        public string GetSASofContainer(string containerName, SharedAccessBlobPermissions SAB, int validatePeriod, bool UseSavedPolicy = true, string PolicySignedIdentifier = "PolicyIdentifier")
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                string SAS = string.Empty;
                SharedAccessBlobPolicy sap = new SharedAccessBlobPolicy();
                sap.Permissions = SAB;
                sap.SharedAccessStartTime = DateTimeOffset.Now.AddMinutes(-5);
                sap.SharedAccessExpiryTime = DateTimeOffset.Now.AddSeconds(validatePeriod);
                if (UseSavedPolicy)
                {
                    BlobContainerPermissions bp = container.GetPermissions();
                    bp.SharedAccessPolicies.Clear();
                    bp.SharedAccessPolicies.Add(PolicySignedIdentifier, sap);
                    container.SetPermissions(bp);
                    SAS = container.GetSharedAccessSignature(new SharedAccessBlobPolicy(), PolicySignedIdentifier);
                }
                else
                {
                    SAS = container.GetSharedAccessSignature(sap);
                }
                Test.Info("The SAS is {0}", SAS);
                return SAS;
            }
            catch (StorageException e)
            {
                if (null == e ||
                       null == e.RequestInformation ||
                       404 == e.RequestInformation.HttpStatusCode ||
                       null == e.RequestInformation.ExtendedErrorInformation ||
                       BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return string.Empty;
                }
                throw;
            }
        }

        /// <summary>
        /// Clear the SAS policy set to a container, used to revoke the SAS
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <returns>True for success</returns>
        public bool ClearSASPolicyofContainer(string containerName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                BlobContainerPermissions bp = container.GetPermissions();
                bp.SharedAccessPolicies.Clear();
                container.SetPermissions(bp);
                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                       null == e.RequestInformation ||
                       404 == e.RequestInformation.HttpStatusCode ||
                       null == e.RequestInformation.ExtendedErrorInformation ||
                       BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }


        public bool CleanupContainer(string containerName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                IEnumerable<IListBlobItem> blobs = container.ListBlobs(null, true, BlobListingDetails.All);
                if (blobs != null)
                {
                    foreach (ICloudBlob blob in blobs)
                    {
                        if (blob == null) continue;
                        if (!blob.Exists())
                        {
                            try
                            {
                                blob.Delete(DeleteSnapshotsOption.IncludeSnapshots);
                                continue;
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                        blob.Delete(DeleteSnapshotsOption.IncludeSnapshots);
                    }
                }
                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                       null == e.RequestInformation ||
                       404 == e.RequestInformation.HttpStatusCode ||
                       null == e.RequestInformation.ExtendedErrorInformation ||
                       BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }

        public bool CleanupContainerByRecreateIt(string containerName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                if (container == null || !container.Exists()) return false;
                
                BlobRequestOptions bro = new BlobRequestOptions();
                bro.RetryPolicy = new LinearRetry(new TimeSpan(0,1,0),3);
                try
                {
                    container.Delete(null, bro);
                }
                catch (StorageException e)
                {
                    if (null == e ||
                        null == e.RequestInformation ||
                        404 == e.RequestInformation.HttpStatusCode ||
                        null == e.RequestInformation.ExtendedErrorInformation ||
                        BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                    {
                        throw;
                    }      
                }
                Console.WriteLine("container deleted");
                bro.RetryPolicy = new LinearRetry(new TimeSpan(0, 3, 0),3);

                bool createSuccess = false;
                while (!createSuccess)
                {
                    try
                    {
                        container.Create(bro);
                        createSuccess = true;
                    }
                    catch (StorageException e)
                    {
                        if (null == e ||
                            null == e.RequestInformation ||
                            null == e.RequestInformation.ExtendedErrorInformation ||
                            BlobErrorCodeStrings.ContainerAlreadyExists == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                        {
                            Thread.Sleep(3000);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    throw;
                }
                return false;
            }
        }


        /// <summary>
        /// Query the blob
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public ICloudBlob QueryBlob(string containerName, string blobName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
                //since GetBlobReference method return no null value even if blob is not exist.
                //use FetchAttributes method to confirm the existence of the blob
                blob.FetchAttributes();
                return blob;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return null;
                }
                throw;
            }
        }


        public BlobProperties QueryBlobProperties(string containerName, string blobName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
                if (blob == null)
                {
                    return null;
                }
                blob.FetchAttributes();
                return blob.Properties;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return null;
                }
                throw;
            }
        }


        /// <summary>
        /// Query the blob virtual directory
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public CloudBlobDirectory QueryBlobDirectory(string containerName, string blobDirectoryName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                if (container == null || !container.Exists()) return null;
                CloudBlobDirectory blobDirectory = container.GetDirectoryReference(blobDirectoryName);
                return blobDirectory;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return null;
                }
                throw;
            }
        }


        /// <summary>
        /// Create or update a blob by its name
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <param name="blobName">the name of the blob</param>
        /// <param name="content">the content to the blob</param>
        /// <returns>Return true on success, false if unable to create, throw exception on error</returns>
        public bool PutBlob(string containerName, string blobName, string content)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                if (container == null || !container.Exists()) return false;
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
                MemoryStream MStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(content));
                blob.UploadFromStream(MStream);
                MStream.Close();
                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }

        /// <summary>
        /// change an exist Blob MD5 hash
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <param name="blobName">the name of the blob</param>
        /// <param name="MD5Hash">the MD5 hash to set, must be a base 64 string</param>
        /// <returns>Return true on success, false if unable to set</returns>
        public bool SetMD5Hash(string containerName, string blobName, string MD5Hash)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
                blob.FetchAttributes();
                blob.Properties.ContentMD5 = MD5Hash;
                blob.SetProperties();
                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }


        /// <summary>
        /// put block list. TODO: implement this for large files
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <param name="blockIds"></param>
        /// <returns></returns>
        public bool PutBlockList(string containerName, string blobName, string[] blockIds)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                if (container == null || !container.Exists()) return false;
                CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

                blob.PutBlockList(blockIds);

                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }

        /// <summary>
        /// Download Blob text by the blob name
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <param name="blobName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool GetBlob(string containerName, string blobName, out string content)
        {
            content = null;

            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
                string tempfile = "temp.txt";
                using (FileStream fileStream = new FileStream(tempfile, FileMode.Create))
                {
                    blob.DownloadToStream(fileStream);
                    fileStream.Close();
                }
                content = File.ReadAllText(tempfile);
                File.Delete(tempfile);

                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }

       


        /// <summary>
        /// Delete a blob by its name
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <param name="blobName">the name of the blob</param>
        /// <returns>Return true on success, false if blob not found, throw exception on error</returns>
        public bool DeleteBlob(string containerName, string blobName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
                return blob.DeleteIfExists();
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }

        public bool DeleteBlobDirectory(string containerName, string blobDirectoryName, bool recursive)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                CloudBlobDirectory blobDirectory = container.GetDirectoryReference(blobDirectoryName);

                if (recursive)
                {
                    foreach (ICloudBlob blob in blobDirectory.ListBlobs(recursive, BlobListingDetails.All))
                    {
                        blob.Delete();
                    }
                }
                else
                {
                    foreach (ICloudBlob blob in blobDirectory.ListBlobs(recursive))
                    {
                        blob.Delete();
                    }
                }

                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }

        private void deleteBlobDirRecursive(CloudBlobDirectory cbd)
        {
            if (cbd == null) return;
            foreach (ICloudBlob blob in cbd.ListBlobs(true, BlobListingDetails.All))
            {
                blob.Delete();
            }

        }

        
        public bool UploadFileToBlockBlob(string containerName, string blobName, string filePath)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);                
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                BlobRequestOptions bro = new BlobRequestOptions();
                bro.RetryPolicy = new LinearRetry(new TimeSpan(0, 0, 30),3);
                bro.ServerTimeout = new TimeSpan(1, 30, 0);
                bro.MaximumExecutionTime = new TimeSpan(1, 30, 0);
                
                using (FileStream fileStream = new FileStream(Path.Combine(filePath), FileMode.Open))
                {
                    blockBlob.UploadFromStream(fileStream, null, bro);
                    fileStream.Close();
                }
                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }
        
        public bool UploadFileToPageBlob(string containerName, string blobName, string filePath)
        {
            try
            {
                FileInfo fi = new FileInfo(filePath);
                if (!fi.Exists)
                {
                    return false;
                }
                long fileLength = fi.Length;
                
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                CloudPageBlob pageBlob = container.GetPageBlobReference(blobName);
                BlobRequestOptions bro = new BlobRequestOptions();
                bro.RetryPolicy = new LinearRetry(new TimeSpan(0, 0, 30),3);
                bro.ServerTimeout = new TimeSpan(1, 30, 0);
                bro.MaximumExecutionTime = new TimeSpan(1, 30, 0);
                MD5CryptoServiceProvider md5CSP = new MD5CryptoServiceProvider();

                long offset = 0;
                const int pageBlobPageSize = 512;
                const int maxPageBlobWriteSize= 4*1024*1024;
                long blobSize = (fileLength + pageBlobPageSize - 1) & ~(pageBlobPageSize - 1);
                pageBlob.Create(blobSize);

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    while (offset < fileLength)
                    {
                        byte[] range = br.ReadBytes(maxPageBlobWriteSize);
                        md5CSP.TransformBlock(range, 0, range.Length, null, 0);
                        if (range.Length % pageBlobPageSize > 0)
                        {
                            int pad = pageBlobPageSize - (range.Length % pageBlobPageSize);
                            Array.Resize(ref range, range.Length + pad);
                        }
                        MemoryStream ms = new MemoryStream(range, false);
                        pageBlob.WritePages(ms, offset, null, null, bro);
                        offset += range.Length;
                    }
                    md5CSP.TransformFinalBlock(new byte[0], 0, 0);
                }
                //update the page blob contentMD5
                pageBlob.Properties.ContentMD5 = Convert.ToBase64String(md5CSP.Hash);
                pageBlob.SetProperties(null, bro);

                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }

        public bool DownloadFile(string containerName, string blobName, string filePath)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                BlobRequestOptions bro = new BlobRequestOptions();
                bro.RetryPolicy = new LinearRetry(new TimeSpan(0, 0, 30),3);
                bro.ServerTimeout = new TimeSpan(1, 30, 0);
                bro.MaximumExecutionTime = new TimeSpan(1, 30, 0);
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    blob.DownloadToStream(fileStream, null, bro);
                    fileStream.Close();
                }

                return true;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return false;
                }
                throw;
            }
        }
        /// <summary>
        /// Creates a snapshot of the blob
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <param name="blobName">the name of blob</param>
        /// <returns>blob snapshot</returns>
        public ICloudBlob CreateSnapshot(string containerName, string blobName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
                if (blob.Properties.BlobType == Microsoft.WindowsAzure.Storage.Blob.BlobType.BlockBlob)
                {
                    CloudBlockBlob BBlock = blob as CloudBlockBlob;
                    return BBlock.CreateSnapshot();
                }
                else
                {
                    CloudPageBlob BBlock = blob as CloudPageBlob;
                    return BBlock.CreateSnapshot();
                }

            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return null;
                }
                throw;
            }
        }

        /// <summary>
        /// delete snapshot of the blob (DO NOT delete blob)
        /// </summary>
        /// <param name="containerName">the name of the container</param>
        /// <param name="blobName">the name of blob</param>
        /// <returns></returns>
        public void DeleteSnapshotOnly(string containerName, string blobName)
        {
            try
            {
                CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
                ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);

                //Indicate that any snapshots should be deleted.
                blob.Delete(DeleteSnapshotsOption.DeleteSnapshotsOnly);
                return;
            }
            catch (StorageException e)
            {
                if (null == e ||
                    null == e.RequestInformation ||
                    404 == e.RequestInformation.HttpStatusCode ||
                    null == e.RequestInformation.ExtendedErrorInformation ||
                    BlobErrorCodeStrings.ContainerNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode ||
                    BlobErrorCodeStrings.BlobNotFound == e.RequestInformation.ExtendedErrorInformation.ErrorCode)
                {
                    return;
                }
                throw;
            }
        }
        /// <summary>
        /// return name of snapshot
        /// </summary>
        /// <param name="fileName">the name of blob</param>
        /// <param name="snapShot">A blob snapshot</param>
        /// <returns>name of snapshot</returns>
        public string GetNameOfSnapshot(string fileName, ICloudBlob snapshot)
        {
            string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string timeStamp = string.Format("{0:u}", snapshot.SnapshotTime.Value);
            return string.Format("{0} ({1}){2}",
                    fileNameNoExt, timeStamp.Replace(":", string.Empty).TrimEnd(new char[] { 'Z' }), extension);
        }
    }

}
