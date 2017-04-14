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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class DataLakeStoreFileSystemClient
    {
        private const decimal MaximumBytesPerDownloadRequest = 32 * 1024 * 1024; //32MB

        /// <summary>
        /// The lock object
        /// </summary>
        private static readonly object ConsoleOutputLock = new object();

        private readonly DataLakeStoreFileSystemManagementClient _client;
        private readonly Random uniqueActivityIdGenerator;
        private const int MaxConnectionLimit = 1000;
        private const long NeverExpireValue = 253402300800000;

        #region Constructors

        public DataLakeStoreFileSystemClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            _client = DataLakeStoreCmdletBase.CreateAdlsClient<DataLakeStoreFileSystemManagementClient>(context,
                AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix, true);

            uniqueActivityIdGenerator = new Random();

            // We need to override the default .NET value for max connections to a host to our number of threads, if necessary.
            // Otherwise we won't achieve the parallelism we want.
            // This is also required before the first call on the data lake store client.
            ServicePointManager.DefaultConnectionLimit = Math.Max(MaxConnectionLimit,
                ServicePointManager.DefaultConnectionLimit);
        }

        #endregion

        #region File and Folder Permissions Operations

        public bool TestFileOrFolderExistence(string path, string accountName, out FileType itemType)
        {
            try
            {
                var status = _client.FileSystem.GetFileStatus(accountName, path);
                itemType = status.FileStatus.Type ?? FileType.FILE;
                return true;
            }
            catch (AdlsErrorException ex)
            {
                if (ex.Body.RemoteException is AdlsFileNotFoundException || ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    itemType = FileType.FILE;
                    return false;
                }

                throw;
            }
        }

        public void SetPermission(string path, string accountName, string permissionsToSet)
        {
            _client.FileSystem.SetPermission(accountName, path, permissionsToSet);
        }

        public void SetOwner(string path, string accountName, string owner, string group)
        {
            _client.FileSystem.SetOwner(accountName, path, owner, group);
        }

        public void SetAcl(string path, string accountName, string aclToSet)
        {
            _client.FileSystem.SetAcl(accountName, path, aclToSet);
        }

        public void ModifyAcl(string path, string accountName, string aclToModify)
        {
            _client.FileSystem.ModifyAclEntries(accountName, path, aclToModify);
        }

        public void RemoveDefaultAcl(string path, string accountName)
        {
            _client.FileSystem.RemoveDefaultAcl(accountName, path);
        }

        public void RemoveAclEntries(string path, string accountName, string aclsToRemove)
        {
            _client.FileSystem.RemoveAclEntries(accountName, path, aclsToRemove);
        }

        public void RemoveAcl(string path, string accountName)
        {
            _client.FileSystem.RemoveAcl(accountName, path);
        }

        public void UpdateAclEntries(string path, string accountName, string newAclSpec)
        {
            _client.FileSystem.ModifyAclEntries(accountName, path, newAclSpec);
        }

        public AclStatus GetAclStatus(string filePath, string accountName)
        {
            return _client.FileSystem.GetAclStatus(accountName, filePath).AclStatus;
        }

        public bool CheckAccess(string path, string accountName, string permissionsToCheck)
        {
            try
            {
                _client.FileSystem.CheckAccess(accountName, path, permissionsToCheck);
                return true;
            }
            catch (AdlsErrorException ex)
            {
                // TODO: ensure specific error code for "false", and throw for all others.
                if (ex.Body.RemoteException is AdlsSecurityException || ex.Body.RemoteException is AdlsAccessControlException)
                {
                    return false;
                }

                throw;
            }
        }

        #endregion

        #region File and Folder Operations

        public FileStatusProperties SetExpiry(string path, string accountName, long timeToSet)
        {

            if (timeToSet <= 0 || timeToSet >= NeverExpireValue)
            {
                _client.FileSystem.SetFileExpiry(accountName, path, ExpiryOptionType.NeverExpire);
            }
            else
            {
                _client.FileSystem.SetFileExpiry(accountName, path, ExpiryOptionType.Absolute, timeToSet);
            }

            return GetFileStatus(path, accountName);
        }

        public void SetTimes(string path, string accountName, DateTimeOffset modificationTime, DateTimeOffset accessTime)
        {
            //_client.FileSystem.SetTimes(accountName, path, modificationTime.ToFileTime(), accessTime.ToFileTime());
            throw new NotImplementedException();
        }

        public bool SetReplication(string filePath, string accountName, short replicationValue)
        {
            // var boolean = _client.FileSystem.SetReplication(accountName, filePath, replicationValue).Boolean;
            // return boolean != null && boolean.Value;
            throw new NotImplementedException();
        }

        public bool RenameFileOrDirectory(string sourcePath, string accountName, string destinationPath)
        {
            var boolean = _client.FileSystem.Rename(accountName, sourcePath, destinationPath).OperationResult;
            return boolean != null && boolean.Value;
        }

        public Stream PreviewFile(string filePath, string accountName, long bytesToPreview, long offset,
            CancellationToken cmdletCancellationToken, Cmdlet cmdletRunningRequest = null)
        {
            var lengthToUse = GetFileStatus(filePath, accountName).Length.Value;
            if(offset > lengthToUse || offset < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.OffsetOutOfRange, offset, lengthToUse));
            }

            if (bytesToPreview <= lengthToUse + offset && bytesToPreview > 0)
            {
                lengthToUse = bytesToPreview;
            }
            else
            {
                // make sure that we are only previewing bytes after the specified offset
                lengthToUse -= offset;
            }

            var numRequests = Math.Ceiling(lengthToUse / MaximumBytesPerDownloadRequest);

            var byteStream = new MemoryStream();
            var progress = new ProgressRecord(
                0,
                "Previewing a file from DataLakeStore Store",
                string.Format("Previewing file in DataLakeStore Store Location: {0}. Bytes to preview: {1}, from Offset: {2}", filePath,
                    bytesToPreview, offset));
            long currentOffset = offset;
            var bytesToRequest = (long)MaximumBytesPerDownloadRequest;

            //TODO: defect: 4259238 (located here: http://vstfrd:8080/Azure/RD/_workitems/edit/4259238) needs to be resolved or the tracingadapter work around needs to be put back in
            for (long i = 0; i < numRequests; i++)
            {
                cmdletCancellationToken.ThrowIfCancellationRequested();
                progress.PercentComplete = (int)Math.Ceiling((i / numRequests) * 100);
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
            return _client.FileSystem.Open(accountName, filePath, bytesToRead, offset);
        }

        public string GetHomeDirectory(string accountName)
        {
            // return _client.FileSystem.GetHomeDirectory(accountName).Path;
            throw new NotImplementedException();
        }

        public FileStatuses GetFileStatuses(string folderPath, string accountName)
        {
            return _client.FileSystem.ListFileStatus(accountName, folderPath).FileStatuses;
        }

        public FileStatusProperties GetFileStatus(string filePath, string accountName)
        {
            return _client.FileSystem.GetFileStatus(accountName, filePath).FileStatus;
        }

        public ContentSummary GetContentSummary(string path, string accountName)
        {
            return _client.FileSystem.GetContentSummary(accountName, path).ContentSummary;
        }

        public bool DeleteFileOrFolder(string path, string accountName, bool isRecursive)
        {
            var boolean = _client.FileSystem.Delete(accountName, path, isRecursive).OperationResult;
            return boolean != null && boolean.Value;
        }

        public void CreateSymLink(string sourcePath, string accountName, string destinationPath,
            bool createParent = false)
        {
            // _client.FileSystem.CreateSymLink(accountName, sourcePath, destinationPath, createParent);
            throw new NotImplementedException();
        }

        public void ConcatenateFiles(string destinationPath, string accountName, string[] filesToConcatenate,
            bool deleteDirectory = false)
        {
            _client.FileSystem.MsConcat(accountName, destinationPath,
                new MemoryStream(Encoding.UTF8.GetBytes("sources=" + string.Join(",", filesToConcatenate))),
                deleteDirectory);
        }

        public void CreateFile(string filePath, string accountName, Stream contents = null, bool overwrite = false)
        {
            _client.FileSystem.Create(accountName, filePath, contents, overwrite: overwrite);
        }

        public bool CreateDirectory(string dirPath, string accountName)
        {
            var boolean = _client.FileSystem.Mkdirs(accountName, dirPath).OperationResult;
            return boolean != null && boolean.Value;
        }

        public void AppendToFile(string filePath, string accountName, Stream contents)
        {
            _client.FileSystem.Append(accountName, filePath, contents);
        }

        public void CopyFile(string destinationPath, string accountName, string sourcePath,
            CancellationToken cmdletCancellationToken, int threadCount = -1, bool overwrite = false, bool resume = false,
            bool isBinary = false, bool isDownload = false, Cmdlet cmdletRunningRequest = null, ProgressRecord parentProgress = null)
        {
            // Service client tracing is enabled, however issue: https://github.com/Azure/azure-powershell/issues/2499 is not yet resolved, so debug functionality can still potentially affect performance negatively.
            FileType ignoredType;
            if (!overwrite && (!isDownload && TestFileOrFolderExistence(destinationPath, accountName, out ignoredType) || (isDownload && File.Exists(destinationPath))))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.LocalFileAlreadyExists, destinationPath));
            }

            if (threadCount < 1)
            {
                threadCount = 10; // 10 is the default per our documentation.
            }

            // Progress bar indicator.
            var description = string.Format("Copying {0} File: {1} {2} Location: {3} for account: {4}",
                isDownload ? "Data Lake Store" : "Local",
                sourcePath,
                isDownload ? "to local" : "to Data Lake Store",
                destinationPath, accountName);
            var progress = new ProgressRecord(
                uniqueActivityIdGenerator.Next(0, 10000000),
                string.Format("{0} Data Lake Store Store", isDownload ? "Download from" : "Upload to"),
                description)
            {
                PercentComplete = 0
            };

            if (parentProgress != null)
            {
                progress.ParentActivityId = parentProgress.ActivityId;
            }

            // On update from the Data Lake store uploader, capture the progress.
            var progressTracker = new System.Progress<TransferProgress>();
            progressTracker.ProgressChanged += (s, e) =>
            {
                lock (ConsoleOutputLock)
                {
                    var toSet = (int)(1.0 * e.TransferredByteCount / e.TotalFileLength * 100);
                    // powershell defect protection. If, through some defect in
                    // our progress tracking, the number is outside of 0 - 100,
                    // powershell will crash if it is set to that value. Instead
                    // just keep the value unchanged in that case.
                    if (toSet < 0 || toSet > 100)
                    {
                        progress.PercentComplete = progress.PercentComplete;
                    }
                    else
                    {
                        progress.PercentComplete = toSet;
                    }
                }
            };

            Task transferTask;
            var previousExpect100 = ServicePointManager.Expect100Continue;
            try
            {
                ServicePointManager.Expect100Continue = false;
                if (isDownload)
                {
                    transferTask = Task.Run(() =>
                   {
                       cmdletCancellationToken.ThrowIfCancellationRequested();
                       _client.FileSystem.DownloadFile(
                         accountName,
                         sourcePath,
                         destinationPath,
                         threadCount,
                         resume,
                         overwrite,
                         progressTracker,
                         cmdletCancellationToken);
                       cmdletCancellationToken.ThrowIfCancellationRequested();
                   },
                    cmdletCancellationToken);
                }
                else
                {
                    transferTask = Task.Run(() =>
                    {
                        cmdletCancellationToken.ThrowIfCancellationRequested();
                        _client.FileSystem.UploadFile(
                          accountName,
                          sourcePath,
                          destinationPath,
                          threadCount,
                          resume,
                          overwrite,
                          isBinary,
                          progressTracker,
                          cmdletCancellationToken);
                        cmdletCancellationToken.ThrowIfCancellationRequested();
                    },
                    cmdletCancellationToken);
                }
                
                TrackUploadProgress(transferTask, progress, cmdletRunningRequest, cmdletCancellationToken);
            }
            catch (Exception e)
            {
                throw new CloudException(string.Format(Properties.Resources.UploadFailedMessage, e));
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
            int concurrentFileCount = -1,
            int perFileThreadCount = -1,
            bool recursive = false,
            bool overwrite = false,
            bool resume = false,
            bool forceBinaryOrText = false,
            bool isBinary = false,
            bool isDownload = false,
            Cmdlet cmdletRunningRequest = null)
        {
            long totalBytes;
            long totalFiles;
            if (isDownload)
            {
                var summary = _client.FileSystem.GetContentSummary(accountName, sourceFolderPath);
                totalBytes = summary.ContentSummary.SpaceConsumed.GetValueOrDefault();
                totalFiles = summary.ContentSummary.FileCount.GetValueOrDefault();
            }
            else
            {
                totalBytes = GetByteCountInDirectory(sourceFolderPath, recursive, accountName);
                totalFiles = GetFileCountInDirectory(sourceFolderPath, recursive, accountName);
            }

            var progress = new ProgressRecord(
                uniqueActivityIdGenerator.Next(0, 10000000),
                string.Format("Copying Folder: {0}{1}. Total bytes remaining: {2}. Total files remaining: {3}",
                    sourceFolderPath, recursive ? " recursively" : string.Empty, totalBytes, totalFiles),
                "Copy in progress...")
            { PercentComplete = 0 };

            UpdateProgress(progress, cmdletRunningRequest);

            var previousExpect100 = ServicePointManager.Expect100Continue;
            try
            {
                // Service client tracing is enabled, however issue: https://github.com/Azure/azure-powershell/issues/2499 is not yet resolved, so debug functionality can still potentially affect performance negatively.
                ServicePointManager.Expect100Continue = false;

                // On update from the Data Lake store uploader, capture the progress.
                var progressTracker = new System.Progress<TransferFolderProgress>();
                progressTracker.ProgressChanged += (s, e) =>
                {
                    lock (ConsoleOutputLock)
                    {
                        var toSet = (int)(1.0 * e.TransferredByteCount / e.TotalFileLength * 100);
                        // powershell defect protection. If, through some defect in
                        // our progress tracking, the number is outside of 0 - 100,
                        // powershell will crash if it is set to that value. Instead
                        // just keep the value unchanged in that case.
                        if (toSet < 0 || toSet > 100)
                        {
                            progress.PercentComplete = progress.PercentComplete;
                        }
                        else
                        {
                            progress.PercentComplete = toSet;
                        }
                        progress.Activity = string.Format("Copying Folder: {0}{1}. Total bytes remaining: {2}. Total files remaining: {3}",
                            sourceFolderPath, recursive ? " recursively" : string.Empty, e.TotalFileLength - e.TransferredByteCount, e.TotalFileCount - e.TransferredFileCount);
                    }
                };

                Task transferTask;
                if (isDownload)
                {
                    transferTask = Task.Run(() =>
                    {
                        cmdletCancellationToken.ThrowIfCancellationRequested();
                        _client.FileSystem.DownloadFolder(
                            accountName,
                            sourceFolderPath,
                            destinationFolderPath,
                            perFileThreadCount,
                            concurrentFileCount,
                            resume,
                            overwrite,
                            recursive,
                            progressTracker,
                            cmdletCancellationToken);
                        cmdletCancellationToken.ThrowIfCancellationRequested();
                    }, cmdletCancellationToken);
                }
                else
                {
                    transferTask = Task.Run(() =>
                    {
                        cmdletCancellationToken.ThrowIfCancellationRequested();
                        _client.FileSystem.UploadFolder(
                            accountName,
                            sourceFolderPath,
                            destinationFolderPath,
                            perFileThreadCount,
                            concurrentFileCount,
                            resume,
                            overwrite,
                            isBinary,
                            recursive,
                            progressTracker,
                            cmdletCancellationToken);
                        cmdletCancellationToken.ThrowIfCancellationRequested();
                    }, cmdletCancellationToken);
                }

                TrackUploadProgress(transferTask, progress, cmdletRunningRequest, cmdletCancellationToken);

                if (!cmdletCancellationToken.IsCancellationRequested)
                {
                    progress.PercentComplete = 100;
                    progress.RecordType = ProgressRecordType.Completed;
                    UpdateProgress(progress, cmdletRunningRequest);
                }
            }
            catch (Exception e)
            {
                throw new CloudException(string.Format(Properties.Resources.UploadFailedMessage, e));
            }
            finally
            {
                ServicePointManager.Expect100Continue = previousExpect100;
            }
        }

        #endregion

        #region private helpers

        /// <summary>
        /// Gets the file count in directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="recursive">if set to <c>true</c> gets the count of all files underneath a directory and all
        /// subdirectories.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <returns>
        /// the total number of files in a directory
        /// </returns>
        private int GetFileCountInDirectory(string directory, bool recursive, string accountName)
        {
            var count = 0;
            directory = directory.TrimEnd('\\');
            directory += "\\";
            foreach (var entry in Directory.GetFileSystemEntries(directory))
            {
                if (Directory.Exists(entry))
                {
                    if (recursive)
                    {
                        count += GetFileCountInDirectory(entry, true, accountName);
                    }
                }
                else
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Gets the byte count in directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <param name="accountName">Name of the account.</param>
        /// <returns>The total byte count of the directory</returns>
        private long GetByteCountInDirectory(string directory, bool recursive, string accountName)
        {
            long count = 0;
            
            directory = directory.TrimEnd('\\');
            directory += "\\";
            foreach (var entry in Directory.GetFileSystemEntries(directory))
            {
                if (Directory.Exists(entry))
                {
                    if (recursive)
                    {
                        count += GetByteCountInDirectory(entry, true, accountName);
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

        internal long ToUnixTimeStampMs(DateTimeOffset date)
        {
            if(date == null || date == DateTimeOffset.MaxValue)
            {
                return -1;
            }

            // NOTE: This assumes the date being passed in is already UTC.
            return (long)(date.UtcDateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        #endregion
    }
}