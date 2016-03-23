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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Azure.Management.DataLake.StoreUploader;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class DataLakeStoreFileSystemClient
    {
        private const decimal MaximumBytesPerDownloadRequest = 32*1024*1024; //32MB

        /// <summary>
        /// The lock object
        /// </summary>
        private static readonly object ConsoleOutputLock = new object();

        private readonly DataLakeStoreFileSystemManagementClient _client;
        private readonly Random uniqueActivityIdGenerator;

        #region Constructors

        public DataLakeStoreFileSystemClient(AzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            _client = DataLakeStoreCmdletBase.CreateAdlsClient<DataLakeStoreFileSystemManagementClient>(context,
                AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix, true);

            uniqueActivityIdGenerator = new Random();
        }

        #endregion

        #region File and Folder Permissions Operations

        public bool TestFileOrFolderExistence(string path, string accountName, out FileType itemType)
        {
            try
            {
                var status = _client.FileSystem.GetFileStatus(path, accountName);
                itemType = status.FileStatus.Type ?? FileType.File;
                return true;
            }
            catch (CloudException)
            {
                // TODO test for a specific code (such as 404 and only return false on those)
                itemType = FileType.File;
                return false;
            }
        }

        public void SetPermission(string path, string accountName, string permissionsToSet)
        {
            _client.FileSystem.SetPermission(path, accountName, permissionsToSet);
        }

        public void SetOwner(string path, string accountName, string owner, string group)
        {
            _client.FileSystem.SetOwner(path, accountName, owner, group);
        }

        public void SetAcl(string path, string accountName, string aclToSet)
        {
            _client.FileSystem.SetAcl(path, aclToSet, accountName);
        }

        public void ModifyAcl(string path, string accountName, string aclToModify)
        {
            _client.FileSystem.ModifyAclEntries(path, aclToModify, accountName);
        }

        public void RemoveDefaultAcl(string path, string accountName)
        {
            // _client.FileSystem.RemoveDefaultAcl(path, accountName);
            throw new NotImplementedException();
        }

        public void RemoveAclEntries(string path, string accountName, string aclsToRemove)
        {
            _client.FileSystem.RemoveAclEntries(path, aclsToRemove, accountName);
        }

        public void RemoveAcl(string path, string accountName)
        {
            _client.FileSystem.RemoveAcl(path, accountName);
        }

        public void UpdateAclEntries(string path, string accountName, string newAclSpec)
        {
            _client.FileSystem.ModifyAclEntries(path, newAclSpec, accountName);
        }

        public AclStatus GetAclStatus(string filePath, string accountName)
        {
            return _client.FileSystem.GetAclStatus(filePath, accountName).AclStatus;
        }

        public bool CheckAccess(string path, string accountName, string permissionsToCheck)
        {
            try
            {
                _client.FileSystem.CheckAccess(path, accountName, permissionsToCheck);
                return true;
            }
            catch (CloudException)
            {
                // TODO: ensure specific error code for "false", and throw for all others.
                return false;
            }
        }

        #endregion

        #region File and Folder Operations

        public void SetTimes(string path, string accountName, DateTimeOffset modificationTime, DateTimeOffset accessTime)
        {
            //_client.FileSystem.SetTimes(path, accountName, modificationTime.ToFileTime(), accessTime.ToFileTime());
            throw new NotImplementedException();
        }

        public bool SetReplication(string filePath, string accountName, short replicationValue)
        {
            // var boolean = _client.FileSystem.SetReplication(filePath, accountName, replicationValue).Boolean;
            // return boolean != null && boolean.Value;
            throw new NotImplementedException();
        }

        public bool RenameFileOrDirectory(string sourcePath, string accountName, string destinationPath)
        {
            var boolean = _client.FileSystem.Rename(sourcePath, destinationPath, accountName).OperationResult;
            return boolean != null && boolean.Value;
        }

        public void DownloadFile(string filePath, string accountName, string destinationFilePath,
            CancellationToken cmdletCancellationToken, bool overwrite = false, Cmdlet cmdletRunningRequest = null)
        {
            if (File.Exists(destinationFilePath) && overwrite)
            {
                File.Delete(destinationFilePath);
            }

            if (File.Exists(destinationFilePath) && !overwrite)
            {
                throw new IOException(string.Format(Properties.Resources.LocalFileAlreadyExists, destinationFilePath));
            }
            // create all of the directories along the way.
            if (!Directory.Exists(Path.GetDirectoryName(destinationFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
            }

            var lengthToUse = GetFileStatus(filePath, accountName).Length.Value;
            var numRequests = Math.Ceiling(lengthToUse/MaximumBytesPerDownloadRequest);

            using (var fileStream = new FileStream(destinationFilePath, FileMode.CreateNew))
            {
                var progress = new ProgressRecord(
                    0,
                    "Download from DataLakeStore Store",
                    string.Format("Downloading File in DataLakeStore Store Location: {0} to destination path: {1}",
                        filePath, destinationFilePath));
                long currentOffset = 0;
                var bytesToRequest = (long) MaximumBytesPerDownloadRequest;
                
                //TODO: defect: 4259238 (located here: http://vstfrd:8080/Azure/RD/_workitems/edit/4259238) needs to be resolved or the tracingadapter work around needs to be put back in
                for (long i = 0; i < numRequests; i++)
                {
                    cmdletCancellationToken.ThrowIfCancellationRequested();
                    progress.PercentComplete = (int) Math.Ceiling((i/numRequests)*100);
                    UpdateProgress(progress, cmdletRunningRequest);
                    var responseStream =
                        ReadFromFile(
                            filePath,
                            accountName,
                            currentOffset,
                            bytesToRequest);
                        
                    responseStream.CopyTo(fileStream);
                    currentOffset += bytesToRequest;
                }

                // final update to 100% completion
                if (cmdletRunningRequest != null && !cmdletCancellationToken.IsCancellationRequested)
                {
                    progress.PercentComplete = 100;
                    progress.RecordType = ProgressRecordType.Completed;
                    cmdletRunningRequest.WriteProgress(progress);
                }
            }
        }

        public Stream PreviewFile(string filePath, string accountName, long bytesToPreview,
            CancellationToken cmdletCancellationToken, Cmdlet cmdletRunningRequest = null)
        {
            var lengthToUse = GetFileStatus(filePath, accountName).Length.Value;
            if (bytesToPreview <= lengthToUse && bytesToPreview > 0)
            {
                lengthToUse = bytesToPreview;
            }

            var numRequests = Math.Ceiling(lengthToUse/MaximumBytesPerDownloadRequest);

            var byteStream = new MemoryStream();
            var progress = new ProgressRecord(
                0,
                "Previewing a file from DataLakeStore Store",
                string.Format("Previewing file in DataLakeStore Store Location: {0}. Bytes to preview: {1}", filePath,
                    bytesToPreview));
            long currentOffset = 0;
            var bytesToRequest = (long) MaximumBytesPerDownloadRequest;

            //TODO: defect: 4259238 (located here: http://vstfrd:8080/Azure/RD/_workitems/edit/4259238) needs to be resolved or the tracingadapter work around needs to be put back in
            for (long i = 0; i < numRequests; i++)
            {
                cmdletCancellationToken.ThrowIfCancellationRequested();
                progress.PercentComplete = (int) Math.Ceiling((i/numRequests)*100);
                UpdateProgress(progress, cmdletRunningRequest);

                if (lengthToUse < bytesToRequest)
                {
                    bytesToRequest = lengthToUse;
                }
                else
                {
                    lengthToUse -= bytesToRequest;
                }

                var responseStream =
                    ReadFromFile(
                        filePath,
                        accountName,
                        currentOffset,
                        bytesToRequest);

                responseStream.CopyTo(byteStream);
                currentOffset += bytesToRequest;
            }

            // final update to 100% completion
            if (cmdletRunningRequest != null && !cmdletCancellationToken.IsCancellationRequested)
            {
                progress.PercentComplete = 100;
                progress.RecordType = ProgressRecordType.Completed;
                cmdletRunningRequest.WriteProgress(progress);
            }

            return byteStream;
        }

        public Stream ReadFromFile(string filePath, string accountName, long offset, long bytesToRead)
        {
            return _client.FileSystem.Open(filePath, accountName, bytesToRead, offset);   
        }

        public string GetHomeDirectory(string accountName)
        {
            // return _client.FileSystem.GetHomeDirectory(accountName).Path;
            throw new NotImplementedException();
        }

        public FileStatuses GetFileStatuses(string folderPath, string accountName)
        {
            return _client.FileSystem.ListFileStatus(folderPath, accountName).FileStatuses;
        }

        public FileStatusProperties GetFileStatus(string filePath, string accountName)
        {
            return _client.FileSystem.GetFileStatus(filePath, accountName).FileStatus;
        }

        public ContentSummary GetContentSummary(string path, string accountName)
        {
            return _client.FileSystem.GetContentSummary(path, accountName).ContentSummary;
        }

        public bool DeleteFileOrFolder(string path, string accountName, bool isRecursive)
        {
            var boolean = _client.FileSystem.Delete(path, accountName, isRecursive).OperationResult;
            return boolean != null && boolean.Value;
        }

        public void CreateSymLink(string sourcePath, string accountName, string destinationPath,
            bool createParent = false)
        {
            // _client.FileSystem.CreateSymLink(sourcePath, accountName, destinationPath, createParent);
            throw new NotImplementedException();
        }

        public void ConcatenateFiles(string destinationPath, string accountName, string[] filesToConcatenate,
            bool deleteDirectory = false)
        {
            _client.FileSystem.MsConcat(destinationPath,
                new MemoryStream(Encoding.UTF8.GetBytes("sources=" + string.Join(",", filesToConcatenate))), 
                accountName,
                deleteDirectory);
        }

        public void CreateFile(string filePath, string accountName, Stream contents = null, bool overwrite = false)
        {
            _client.FileSystem.Create(filePath, accountName, contents, overwrite: overwrite);
        }

        public bool CreateDirectory(string dirPath, string accountName)
        {
            var boolean = _client.FileSystem.Mkdirs(dirPath, accountName).OperationResult;
            return boolean != null && boolean.Value;
        }

        public void AppendToFile(string filePath, string accountName, Stream contents)
        {
            _client.FileSystem.Append(filePath, contents, accountName);
        }

        public void CopyFile(string destinationPath, string accountName, string sourcePath,
            CancellationToken cmdletCancellationToken, int threadCount = -1, bool overwrite = false, bool resume = false,
            bool isBinary = false, Cmdlet cmdletRunningRequest = null, ProgressRecord parentProgress = null)
        {
            FileType ignoredType;   
            if (!overwrite && TestFileOrFolderExistence(destinationPath, accountName, out ignoredType))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.LocalFileAlreadyExists, destinationPath));    
            }

            //TODO: defect: 4259238 (located here: http://vstfrd:8080/Azure/RD/_workitems/edit/4259238) needs to be resolved or the tracingadapter work around needs to be put back in
            // default the number of threads to use to the processor count
            if (threadCount < 1)
            {
                threadCount = Environment.ProcessorCount;
            }

            // Progress bar indicator.
            var description = string.Format("Copying File: {0} to DataLakeStore Location: {1} for account: {2}",
                sourcePath, destinationPath, accountName);
            var progress = new ProgressRecord(
                uniqueActivityIdGenerator.Next(0, 10000000),
                "Upload to DataLakeStore Store",
                description)
            {
                PercentComplete = 0
            };

            if (parentProgress != null)
            {
                progress.ParentActivityId = parentProgress.ActivityId;
            }

            // On update from the Data Lake store uploader, capture the progress.
            var progressTracker = new System.Progress<UploadProgress>();
            progressTracker.ProgressChanged += (s, e) =>
            {
                lock (ConsoleOutputLock)
                {
                    progress.PercentComplete = (int) (1.0*e.UploadedByteCount/e.TotalFileLength*100);
                }
            };

            var uploadParameters = new UploadParameters(sourcePath, destinationPath, accountName, threadCount,
                overwrite, resume, isBinary);
            var uploader = new DataLakeStoreUploader(uploadParameters,
                new DataLakeStoreFrontEndAdapter(accountName, _client, cmdletCancellationToken),
                cmdletCancellationToken,
                progressTracker);

            var previousExpect100 = ServicePointManager.Expect100Continue;
            try
            {
                ServicePointManager.Expect100Continue = false;

                // Execute the uploader.
                var uploadTask = Task.Run(() =>
                {
                    cmdletCancellationToken.ThrowIfCancellationRequested();
                    uploader.Execute();
                    cmdletCancellationToken.ThrowIfCancellationRequested();
                }, cmdletCancellationToken);

                TrackUploadProgress(uploadTask, progress, cmdletRunningRequest, cmdletCancellationToken);
            }
            finally
            {
                ServicePointManager.Expect100Continue = previousExpect100;
            }
        }

        public void CopyDirectory(
            string destinationFolderPath,
            string accountName,
            string sourceFolderPath,
            CancellationToken cmdletCancellationToken,
            int folderThreadCount = -1,
            int perFileThreadCount = -1,
            bool recursive = false,
            bool overwrite = false,
            bool resume = false,
            bool forceBinaryOrText = false,
            bool isBinary = false,
            Cmdlet cmdletRunningRequest = null)
        {
            var allDirectories = new Stack<string>();
            var allFailedFiles = new ConcurrentDictionary<string, string>();
            var allFailedDirs = new List<string>();
            var fileCount = 0;
            var testFileCountChanged = 0;
            var totalBytes = GetByteCountInDirectory(sourceFolderPath, recursive);
            var totalFiles = GetFileCountInDirectory(sourceFolderPath, recursive);
            var folderPathStartIndex = Path.GetDirectoryName(sourceFolderPath).Length;
            if (folderPathStartIndex < 1)
            {
                // this is the scenario where the user is copying from the root of a drive
                // such as C:\ or .\. In these cases, we simply indicate the "beginning" as the
                // end of the root.
                folderPathStartIndex = sourceFolderPath.Length;
            }

            allDirectories.Push(sourceFolderPath);

            var progress = new ProgressRecord(
                uniqueActivityIdGenerator.Next(0, 10000000),
                string.Format("Copying Folder: {0}{1}. Total bytes to be copied: {2}. Total files to be copied: {3}",
                    sourceFolderPath, recursive ? " recursively" : string.Empty, totalBytes, totalFiles),
                "Copy in progress...") {PercentComplete = 0};

            UpdateProgress(progress, cmdletRunningRequest);

            var internalFolderThreads = folderThreadCount <= 0 ? Environment.ProcessorCount : folderThreadCount;
            var internalFileThreads = perFileThreadCount <= 0 ? Environment.ProcessorCount : perFileThreadCount;

            // we need to override the default .NET value for max connections to a host to our number of threads, if necessary (otherwise we won't achieve the parallelism we want)
            var previousDefaultConnectionLimit = ServicePointManager.DefaultConnectionLimit;
            var previousExpect100 = ServicePointManager.Expect100Continue;
            try
            {
                ServicePointManager.DefaultConnectionLimit =
                    Math.Max((internalFolderThreads*internalFileThreads) + internalFolderThreads,
                        ServicePointManager.DefaultConnectionLimit);
                ServicePointManager.Expect100Continue = false;

                //TODO: defect: 4259238 (located here: http://vstfrd:8080/Azure/RD/_workitems/edit/4259238) needs to be resolved or the tracingadapter work around needs to be put back in
                while (allDirectories.Count > 0)
                {
                    var currentDir = allDirectories.Pop();
                    string[] files;

                    try
                    {
                        files = Directory.GetFiles(currentDir);
                        if (recursive)
                        {
                            // Push the subdirectories onto the stack for traversal. 
                            // This could also be done before handing the files. 
                            foreach (var str in Directory.GetDirectories(currentDir))
                            {
                                allDirectories.Push(str);
                            }
                        }
                    }
                    catch
                    {
                        // update the list of folders that could not be accessed
                        // for later reporting to the user.
                        allFailedDirs.Add(currentDir);
                        continue;
                    }

                    // Execute in parallel if there are enough files in the directory. 
                    // Otherwise, execute sequentially.Files are opened and processed 
                    // synchronously but this could be modified to perform async I/O. 
                    // NOTE: in order to write progress in a meaningful way, we have
                    // wrapped the parallel execution in a container task, which is
                    // then monitored from the main thread. 
                    // TODO: enable resumability in the event that copy fails somewhere in the middle
                    var folderOptions = new ParallelOptions
                    {
                        CancellationToken = cmdletCancellationToken
                    };

                    if (folderThreadCount > 0)
                    {
                        folderOptions.MaxDegreeOfParallelism = folderThreadCount;
                    }

                    var task = Task.Run(
                        () =>
                        {
                            Parallel.ForEach(
                                files,
                                folderOptions,
                                () => 0,
                                (file, loopState, localCount) =>
                                {
                                    cmdletCancellationToken.ThrowIfCancellationRequested();
                                    var dataLakeFilePath = string.Format(
                                        "{0}/{1}",
                                        destinationFolderPath,
                                        file.Substring(folderPathStartIndex).TrimStart('\\').Replace('\\', '/'));

                                    // for each file we will either honor a force conversion
                                    // to either binary or text, or attempt to determine
                                    // if the file is either binary or text, with a default
                                    // behavior of text.
                                    isBinary = forceBinaryOrText
                                        ? isBinary
                                        : GlobalMembers.BinaryFileExtension.Contains(
                                            Path.GetExtension(file).ToLowerInvariant());

                                    try
                                    {
                                        CopyFile(dataLakeFilePath, accountName, file, cmdletCancellationToken,
                                            internalFileThreads, overwrite, resume, isBinary, null, progress);
                                    }
                                    catch (Exception e)
                                    {
                                        allFailedFiles.GetOrAdd(file, e.Message);
                                    }

                                    // note: we will always increment the count, since the file was seen and attempted
                                    // this does not necessarily mean the file was successfully uploaded, as indicated by
                                    // the warning messages that can be written out.
                                    return ++localCount;
                                },
                                c => Interlocked.Add(ref fileCount, c));
                        }, cmdletCancellationToken);

                    while (!task.IsCompleted && !task.IsCanceled)
                    {
                        // if we somehow made it in here prior to the cancel, I want to issue a throw
                        cmdletCancellationToken.ThrowIfCancellationRequested();

                        // only update progress if the percentage has changed.
                        if ((int) Math.Ceiling((decimal) testFileCountChanged/totalFiles*100)
                            < (int) Math.Ceiling((decimal) fileCount/totalFiles*100))
                        {
                            testFileCountChanged = fileCount;
                            var percentComplete = (int) Math.Ceiling((decimal) fileCount/totalFiles*100);
                            if (percentComplete > 100)
                            {
                                // in some cases we can get 101 percent complete using ceiling, however we want to be
                                // able to round up to full percentage values, instead of down.
                                percentComplete = 100;
                            }

                            progress.PercentComplete = percentComplete;
                            UpdateProgress(progress, cmdletRunningRequest);
                        }

                        // sleep for a half of a second.
                        TestMockSupport.Delay(500);
                    }

                    if (task.IsFaulted && !task.IsCanceled)
                    {
                        var ae = task.Exception;
                        if (ae != null)
                        {
                            if (cmdletRunningRequest != null)
                            {
                                cmdletRunningRequest.WriteWarning(
                                    "The following errors were encountered during the copy:");
                            }
                            else
                            {
                                Console.WriteLine(@"The following errors were encountered during the copy:");
                            }

                            ae.Handle(
                                ex =>
                                {
                                    if (ex is AggregateException)
                                    {
                                        var secondLevel = ex as AggregateException;
                                        secondLevel.Handle(
                                            secondEx =>
                                            {
                                                if (cmdletRunningRequest != null)
                                                {
                                                    cmdletRunningRequest.WriteWarning(secondEx.ToString());
                                                }
                                                else
                                                {
                                                    Console.WriteLine(secondEx);
                                                }

                                                return true;
                                            });
                                    }
                                    else
                                    {
                                        if (cmdletRunningRequest != null)
                                        {
                                            cmdletRunningRequest.WriteWarning(ex.ToString());
                                        }
                                        else
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }

                                    return true;
                                });
                        }
                    }
                }

                if (allFailedDirs.Count > 0 && !cmdletCancellationToken.IsCancellationRequested)
                {
                    var errString =
                        "The following {0} directories could not be opened and their contents must be copied up with the single file copy command: {1}";
                    if (cmdletRunningRequest != null)
                    {
                        cmdletRunningRequest.WriteWarning(
                            string.Format(errString, allFailedDirs.Count, string.Join(",\r\n", allFailedDirs)));
                    }
                    else
                    {
                        Console.WriteLine(errString, allFailedDirs.Count, string.Join(",\r\n", allFailedDirs));
                    }
                }

                if (allFailedFiles.Count > 0 && !cmdletCancellationToken.IsCancellationRequested)
                {
                    var errString =
                        "The following {0} files could not be copied and must be copied up with the single file copy command: {1}";
                    if (cmdletRunningRequest != null)
                    {
                        cmdletRunningRequest.WriteWarning(
                            string.Format(errString, allFailedFiles.Count, string.Join(",\r\n", allFailedFiles)));
                    }
                    else
                    {
                        Console.WriteLine(errString, allFailedFiles.Count, string.Join(",\r\n", allFailedFiles));
                    }
                }

                if (!cmdletCancellationToken.IsCancellationRequested)
                {
                    progress.PercentComplete = 100;
                    progress.RecordType = ProgressRecordType.Completed;
                    UpdateProgress(progress, cmdletRunningRequest);
                }
            }
            finally
            {
                ServicePointManager.DefaultConnectionLimit = previousDefaultConnectionLimit;
                ServicePointManager.Expect100Continue = previousExpect100;
            }
        }

        #endregion

        #region private helpers

        /// <summary>
        /// Gets the file count in directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="recursive">
        /// if set to <c>true</c> gets the count of all files underneath a directory and all
        /// subdirectories.
        /// </param>
        /// <param name="byteCount">The byte count.</param>
        /// <returns>
        /// the total number of files in a directory
        /// </returns>
        private int GetFileCountInDirectory(string directory, bool recursive)
        {
            directory = directory.TrimEnd('\\');
            directory += "\\";
            var count = 0;
            foreach (var entry in Directory.GetFileSystemEntries(directory))
            {
                if (Directory.Exists(entry))
                {
                    if (recursive)
                    {
                        count += GetFileCountInDirectory(entry, true);
                    }
                }
                else
                {
                    count++;
                }
            }

            return count;
        }

        private long GetByteCountInDirectory(string directory, bool recursive)
        {
            directory = directory.TrimEnd('\\');
            directory += "\\";
            long count = 0;
            foreach (var entry in Directory.GetFileSystemEntries(directory))
            {
                if (Directory.Exists(entry))
                {
                    if (recursive)
                    {
                        count += GetByteCountInDirectory(entry, true);
                    }
                }
                else
                {
                    count += new FileInfo(entry).Length;
                }
            }

            return count;
        }

        /// <summary>
        /// Tracks the upload progress in the PowerShell console.
        /// </summary>
        /// <param name="uploadTask">The task that tracks the upload.</param>
        /// <param name="uploadProgress">The upload progress that will be displayed in the console.</param>
        private void TrackUploadProgress(Task uploadTask, ProgressRecord uploadProgress,
            Cmdlet commandToUpdateProgressFor, CancellationToken token)
        {
            // Update the UI with the progress.
            var lastUpdate = DateTime.Now.Subtract(TimeSpan.FromSeconds(2));
            while (!uploadTask.IsCompleted && !uploadTask.IsCanceled)
            {
                if (token.IsCancellationRequested)
                {
                    // we are done tracking progress and will just break and let the task clean itself up.
                    try
                    {
                        uploadTask.Wait();
                    }
                    catch (OperationCanceledException)
                    {
                        if (uploadTask.IsCanceled)
                        {
                            uploadTask.Dispose();
                        }
                    }
                    catch (AggregateException ex)
                    {
                        if (ex.InnerExceptions.OfType<OperationCanceledException>().Any())
                        {
                            if (uploadTask.IsCanceled)
                            {
                                uploadTask.Dispose();
                            }
                        }
                        else
                        {
                            throw;
                        }
                    }
                    break;
                }

                if (DateTime.Now - lastUpdate > TimeSpan.FromSeconds(1))
                {
                    lock (ConsoleOutputLock)
                    {
                        if (commandToUpdateProgressFor != null && !token.IsCancellationRequested &&
                            !commandToUpdateProgressFor.Stopping)
                        {
                            commandToUpdateProgressFor.WriteProgress(uploadProgress);
                        }
                    }
                }

                TestMockSupport.Delay(250);
            }

            if (uploadTask.IsCanceled || token.IsCancellationRequested)
            {
                uploadProgress.RecordType = ProgressRecordType.Completed;
            }
            else if (uploadTask.IsFaulted && uploadTask.Exception != null)
            {
                // If there are errors, raise them to the user.
                if (uploadTask.Exception.InnerException != null)
                {
                    // we only go three levels deep. This is the Inception rule.
                    if (uploadTask.Exception.InnerException.InnerException != null)
                    {
                        throw uploadTask.Exception.InnerException.InnerException;
                    }

                    throw uploadTask.Exception.InnerException;
                }

                throw uploadTask.Exception;
            }
            else
            {
                // finally execution is finished, set progress state to completed.
                uploadProgress.PercentComplete = 100;
                uploadProgress.RecordType = ProgressRecordType.Completed;

                if (commandToUpdateProgressFor != null)
                {
                    commandToUpdateProgressFor.WriteProgress(uploadProgress);
                }
            }
        }

        /// <summary>
        /// Updates the progress in a friendly way in the event that we are not running in PowerShell
        /// </summary>
        /// <param name="progress">The progress record to use when sending out the update.</param>
        /// <param name="cmdletRunningRequest">The command running the request, if any</param>
        private void UpdateProgress(ProgressRecord progress, Cmdlet cmdletRunningRequest = null)
        {
            if (cmdletRunningRequest != null)
            {
                cmdletRunningRequest.WriteProgress(progress);
            }
            else
            {
                Console.WriteLine(
                    @"Performing action: {0}. Details: {1}. Percent Complete: {2}%",
                    progress.Activity,
                    progress.StatusDescription,
                    progress.PercentComplete);
            }
        }

        #endregion
    }
}