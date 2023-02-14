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
using Microsoft.Azure.DataLake.Store;
using Microsoft.Azure.DataLake.Store.Acl;
using Microsoft.Azure.DataLake.Store.AclTools;
using Microsoft.Azure.DataLake.Store.FileTransfer;
using Microsoft.Azure.DataLake.Store.MockAdlsFileSystem;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
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

        /// <summary>
        /// The lock object
        /// </summary>
        private static readonly object ConsoleOutputLock = new object();

        private readonly IAzureContext _context;
        private readonly Random _uniqueActivityIdGenerator;
        private const int MaxConnectionLimit = 1000;
        private const long NeverExpireValue = 253402300800000;
        internal const int ImportExportMaxThreads = 128;
        private readonly LoggingConfiguration _adlsLoggerConfig;
        private readonly bool _isDebugEnabled;
        private const int DebugMessageFlushThreshold = 500;
        #region Constructors

        static DataLakeStoreFileSystemClient()
        {
            // Registering the custom target class
            Target.Register<AdlsLoggerTarget>("AdlsLogger"); //generic
            LogManager.ReconfigExistingLoggers();
        }

        public DataLakeStoreFileSystemClient(IAzureContext context)
        {
            if (context != null)
            {
                _context = context;
            }
            else
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }
            _uniqueActivityIdGenerator = new Random();

            // We need to override the default .NET value for max connections to a host to our number of threads, if necessary.
            // Otherwise we won't achieve the parallelism we want.
            // This is also required before the first call on the data lake store client.
            ServicePointManager.DefaultConnectionLimit = Math.Max(MaxConnectionLimit,
                ServicePointManager.DefaultConnectionLimit);
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
        }

        public DataLakeStoreFileSystemClient(IAzureContext context, DataLakeStoreFileSystemCmdletBase cmdlet) : this(context)
        {
            bool containsDebug = cmdlet.MyInvocation.BoundParameters.ContainsKey("Debug");
            if (containsDebug)
            {
                _isDebugEnabled = ((SwitchParameter) cmdlet.MyInvocation.BoundParameters["Debug"]).ToBool();
            }
            else
            {
                // The return type of cmdlet.GetVariableValue("DebugPreference") is string when run from a script
                // return type is System.Management.Automation.ActionPreference when run from commandline
                var debugPreference = cmdlet.GetVariableValue("DebugPreference").ToString();
                if (debugPreference != null)
                {
                    _isDebugEnabled = !debugPreference.Equals("SilentlyContinue");
                }
            }

            // Keep this outside if block because it is also used for diagnostic file loggind for BulkCopy
            _adlsLoggerConfig = new LoggingConfiguration();
            if (_isDebugEnabled)
            {
                // Custom target that logs the debug messages from the SDK to the powershell framework's debug message queue
                var adlsTarget = new AdlsLoggerTarget
                {
                    DebugMessageQueue = cmdlet.DebugMessages
                };
                // Add the target to the configuration
                _adlsLoggerConfig.AddTarget("logger", adlsTarget);

                //Logs all patterns of debug messages
                var rule = new LoggingRule("adls.dotnet.*", NLog.LogLevel.Debug, adlsTarget);
                _adlsLoggerConfig.LoggingRules.Add(rule);

               var powershellLoggingRule =
                    new LoggingRule("adls.powershell.WebTransport", NLog.LogLevel.Debug, adlsTarget);
                _adlsLoggerConfig.LoggingRules.Add(powershellLoggingRule);

                // Enable the NLog configuration to use this
                LogManager.Configuration = _adlsLoggerConfig;
            }
        }

        #endregion

        #region File and Folder Permissions Operations
        /// <summary>
        ///  Checks if file or folder exists and also returns the type of the path
        /// </summary>
        /// <param name="path">Full path of file or directory</param>
        /// <param name="accountName">Account name</param>
        /// <param name="itemType">Type of the directory entry</param>
        /// <returns>True of the path exists else false</returns>
        public bool TestFileOrFolderExistence(string path, string accountName, out DirectoryEntryType itemType)
        {
            try
            {
                var entry = AdlsClientFactory.GetAdlsClient(accountName, _context).GetDirectoryEntry(path);
                itemType = entry.Type;
                return true;

            }
            catch (AdlsException e)
            {
                if (e.HttpStatus == HttpStatusCode.NotFound)
                {
                    itemType = DirectoryEntryType.FILE;
                    return false;
                }
                throw e;
            }
        }
        /// <summary>
        /// Sets the permission
        /// </summary>
        /// <param name="path">Path name</param>
        /// <param name="accountName">Account name</param>
        /// <param name="permissionsToSet">Permission to set</param>
        public void SetPermission(string path, string accountName, string permissionsToSet)
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).SetPermission(path, permissionsToSet);
        }
        /// <summary>
        /// Sets the owner of the path
        /// </summary>
        /// <param name="path">Path name</param>
        /// <param name="accountName">Account name</param>
        /// <param name="owner">Owner</param>
        /// <param name="group">Group</param>
        public void SetOwner(string path, string accountName, string owner, string group)
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).SetOwner(path, owner, group);
        }

        /// <summary>
        /// Sets specific Acl entries
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="accountName">Account</param>
        /// <param name="aclToSet">Acl list specifying acls to set</param>
        public void SetAcl(string path, string accountName, List<AclEntry> aclToSet)
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).SetAcl(path, aclToSet);
        }

        /// <summary>
        /// Changes Acl recursively
        /// </summary>
        /// <param name="path">Input path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="aclToSet">List of acl to set</param>
        /// <param name="aclChangeType">Type of al change- Modify, Set, Remove</param>
        /// <param name="concurrency">Concurrency- number of parallel operations</param>
        /// <param name="aclCmdlet">Cmdlet for acl change. This is only for printing progress. If passed null, then no progress tracking is done</param>
        /// <param name="trackProgress"></param>
        /// <param name="cmdletCancellationToken">Cancellationtoken for cmdlet</param>
        public AclProcessorStats ChangeAclRecursively(string path, string accountName, List<AclEntry> aclToSet,
            RequestedAclType aclChangeType, int concurrency, Cmdlet aclCmdlet, bool trackProgress, CancellationToken cmdletCancellationToken )
        {
            var client = AdlsClientFactory.GetAdlsClient(accountName, _context);
            // Currently mockadlsclient signature is different, once that gets fixed, we can remove this
            if (client.GetType() != typeof(MockAdlsClient))
            {
                System.Progress<AclProcessorStats> progressTracker = null;
                ProgressRecord progress = null;
                // If passing null, then we do not want progreess tracking
                if (trackProgress)
                {
                    progress = new ProgressRecord(_uniqueActivityIdGenerator.Next(0, 10000000),
                        string.Format($"Recursive acl change for path {path}"),
                        $"Type of Acl Change: {aclChangeType}")
                    {
                        PercentComplete = 0
                    };
                    // On update from the Data Lake store uploader, capture the progress.
                    progressTracker = new System.Progress<AclProcessorStats>();
                    progressTracker.ProgressChanged += (s, e) =>
                    {
                        lock (ConsoleOutputLock)
                        {
                            progress.PercentComplete = 0;
                            progress.Activity =
                                $"Files enumerated: {e.FilesProcessed} Directories enumerated:{e.DirectoryProcessed}";

                        }
                    };
                }

                AclProcessorStats status = null;
                Task aclTask = Task.Run(() =>
                {
                    cmdletCancellationToken.ThrowIfCancellationRequested();
                    status = client.ChangeAcl(path, aclToSet, aclChangeType, concurrency, progressTracker,
                        cmdletCancellationToken);
                }, cmdletCancellationToken);

                if (trackProgress || _isDebugEnabled)
                {
                    TrackTaskProgress(aclTask, aclCmdlet, progress, cmdletCancellationToken);

                    if (trackProgress && !cmdletCancellationToken.IsCancellationRequested)
                    {
                        progress.PercentComplete = 100;
                        progress.RecordType = ProgressRecordType.Completed;
                        UpdateProgress(progress, aclCmdlet);

                    }
                }
                else
                {
                    WaitForTask(aclTask, cmdletCancellationToken);
                }


                return status;
            }

            return client.ChangeAcl(path, aclToSet, aclChangeType, concurrency);
        }
        /// <summary>
        /// Add specific Acl entries
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="accountName">Account</param>
        /// <param name="aclToModify">Acl list specifying acls to modify</param>
        public void ModifyAcl(string path, string accountName, List<AclEntry> aclToModify)
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).ModifyAclEntries(path, aclToModify);
        }
        /// <summary>
        /// Remove all the default ACLs
        /// </summary>
        /// <param name="path">Path name</param>
        /// <param name="accountName">Account name</param>
        public void RemoveDefaultAcl(string path, string accountName)
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).RemoveDefaultAcls(path);
        }
        /// <summary>
        /// Removes specific Acl entries
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="accountName">Account</param>
        /// <param name="aclsToRemove">Acl list specifying acls to remove</param>
        public void RemoveAclEntries(string path, string accountName, List<AclEntry> aclsToRemove)
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).RemoveAclEntries(path, aclsToRemove);
        }

        /// <summary>
        /// Remove all the ACLs
        /// </summary>
        /// <param name="path">Path name</param>
        /// <param name="accountName">Account name</param>
        public void RemoveAcl(string path, string accountName)
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).RemoveAllAcls(path);
        }
        /// <summary>
        /// Retrieves the Acl status of the path
        /// </summary>
        /// <param name="filePath">File or directory Path</param>
        /// <param name="accountName">Account name</param>
        /// <returns>Acl Status</returns>
        public AclStatus GetAclStatus(string filePath, string accountName)
        {
            return GetFullAcl(AdlsClientFactory.GetAdlsClient(accountName, _context).GetAclStatus(filePath));
        }

        #endregion

        #region File and Folder Operations
        /// <summary>
        /// Sets the expiry time of the file. If expiry option is not specified then tries to guess the option based on timeToSet value.
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="timeToSet">Time to set</param>
        /// <param name="exop">ExpiryOption</param>
        /// <returns>FileStatus after setting the expiry</returns>
        public DirectoryEntry SetExpiry(string path, string accountName, long timeToSet, ExpiryOption? exop = null)
        {
            var client = AdlsClientFactory.GetAdlsClient(accountName, _context);
            if (exop == null)
            {
                if (timeToSet <= 0 || timeToSet >= NeverExpireValue)
                {
                    exop = ExpiryOption.NeverExpire;
                }
                else
                {
                    exop = ExpiryOption.Absolute;
                }
            }
            client.SetExpiryTime(path, exop.Value, timeToSet);
            return GetFileStatus(path, accountName);
        }
        /// <summary>
        /// Renames a file or directory
        /// </summary>
        /// <param name="sourcePath">Source Path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="destinationPath">Destination path</param>
        /// <returns>True if rename is successful else fale</returns>
        public bool RenameFileOrDirectory(string sourcePath, string accountName, string destinationPath)
        {
            return AdlsClientFactory.GetAdlsClient(accountName, _context).Rename(sourcePath, destinationPath);
        }
        /// <summary>
        /// Reads the lines, updates the number of lines and returns the last positio of \r or \n in the byte buffer.
        /// If a combined newline (\r\n), the index returned is that of the first character in the sequence.
        /// </summary>
        /// <param name="buffer">The buffer to search in.</param>
        /// <param name="lengthData">Length of data in buffer</param>
        /// <param name="encoding">Encoding type</param>
        /// <param name="totalRows">Total number of rows to read</param>
        /// <param name="toReturn">Linkedlist to add to</param>
        /// <param name="totLinesRead">Number of lines read</param>
        /// <returns>The index of the closest newline character in the sequence (based on direction) that was found. Returns -1 if not found or reached required number of rows. </returns>
        private static int ReadNewLinesReverse(byte[] buffer, int lengthData, Encoding encoding, int totalRows, ref LinkedList<string> toReturn, ref int totLinesRead)
        {
            // define the bytes per character to use
            int bytesPerChar;
            switch (encoding.CodePage)
            {
                // Big Endian Unicode (UTF-16)
                case 1201:
                // Unicode (UTF-16)
                case 1200:
                    bytesPerChar = 2;
                    break;
                // UTF-32
                case 12000:
                    bytesPerChar = 4;
                    break;
                // ASCII case 20127:
                // UTF-8 case 65001:
                // UTF-7 case 65000:
                // Default to UTF-8
                default:
                    bytesPerChar = 1;
                    break;
            }
            int charPos;
            int prevPos = charPos = lengthData - 1;
            // charPos always points to last byte of a character
            while (charPos >= 0)
            {
                char c = bytesPerChar == 1 ? (char)buffer[charPos] : encoding.GetString(buffer, charPos - bytesPerChar + 1, bytesPerChar).ToCharArray()[0];
                charPos -= bytesPerChar;//charPos points to last byte of previous character now
                if (c == '\r' || c == '\n')
                {

                    int retrieveEndIndx = charPos + bytesPerChar + 1;//retrieve points to first byte of character after \n or \r now
                    if (retrieveEndIndx <= prevPos)
                    {
                        toReturn.AddFirst(
                            encoding.GetString(buffer, retrieveEndIndx, prevPos - retrieveEndIndx + 1));
                        totLinesRead++;
                        if (totLinesRead >= totalRows)
                        {
                            return -1;
                        }
                    }
                    // Check if it is \r\n
                    if (c == '\n' && charPos >= 0)
                    {
                        char beforeCh = bytesPerChar == 1
                            ? (char)buffer[charPos]
                            : encoding.GetString(buffer, charPos - bytesPerChar + 1, bytesPerChar).ToCharArray()[0];
                        if (beforeCh == '\r')
                        {
                            charPos -= bytesPerChar;
                        }
                    }
                    // prevPos will always point to the last byte of the charcter previous to \n or \r
                    prevPos = charPos;
                }
            }
            // Didnt find a new line
            if (prevPos == lengthData - 1)
            {
                return -1;
            }
            return prevPos < 0 ? 0 : prevPos + 1;
        }
        /// <summary>
        /// Get rows from the HEAD
        /// </summary>
        /// <param name="client">Adls Client</param>
        /// <param name="streamPath">Stream path</param>
        /// <param name="numRows">Number of rows to display from head</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>List of rows</returns>
        private IEnumerable<string> GetStreamRowsHead(AdlsClient client, string streamPath, int numRows,
            Encoding encoding)
        {
            var toReturn = new List<string>();
            using (var reader = new StreamReader(client.GetReadStream(streamPath), encoding))
            {
                string line;
                int rows = 0;
                while (rows++ < numRows && (line = reader.ReadLine()) != null)
                {
                    toReturn.Add(line);
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Gets the rows from head or tail
        /// </summary>
        /// <param name="streamPath">File path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="numRows">Number of rows user wants to see</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="reverse">True if we are reading from tail else </param>
        /// <returns>List of lines</returns>
        public IEnumerable<string> GetStreamRows(string streamPath, string accountName, int numRows, Encoding encoding, bool reverse = false)
        {
            var client = AdlsClientFactory.GetAdlsClient(accountName, _context);
            if (!reverse)
            {
                return GetStreamRowsHead(client, streamPath, numRows, encoding);
            }

            var toReturn = new LinkedList<string>();

            using (Stream readerAdl = client.GetReadStream(streamPath))
            {
                // read data 4MB at a time
                // when reading backwards, this may change to ensure that we don't re-read data as we approach the beginning of the file.
                var dataPerRead = 4 * 1024 * 1024;
                bool doneAfterRead = false;
                var fileLength = readerAdl.Length;
                if (fileLength <= dataPerRead)
                {
                    doneAfterRead = true;
                }
                long initialOffset = fileLength - dataPerRead;
                // while we haven't finished loading all the rows, keep grabbing content
                var readRows = 0;
                byte[] buffer = new byte[dataPerRead];
                do
                {
                    if (initialOffset < 0)
                    {
                        initialOffset = 0;
                        doneAfterRead = true;
                    }
                    readerAdl.Seek(initialOffset, SeekOrigin.Begin);

                    int dataActuallyRead = readerAdl.Read(buffer, 0, dataPerRead);
                    // Reads the lines, updates the number of lines and returns the last poisiotn of \r or \n
                    int newLineOffset = ReadNewLinesReverse(buffer, dataActuallyRead, encoding, numRows, ref toReturn, ref readRows);
                    if (newLineOffset != -1)
                    {
                        initialOffset += newLineOffset;
                        initialOffset -= dataPerRead;
                    }
                    // this denotes that we did not get as many rows as desired but we ran out of file.
                    if (doneAfterRead)
                    {
                        break;
                    }
                } while (readRows < numRows);
            }
            return toReturn;
        }
        /// <summary>
        /// Returns the ADL read stream
        /// </summary>
        /// <param name="filePath">File Path</param>
        /// <param name="accountName">Account name</param>
        /// <returns>AdlReadStream</returns>
        public Stream ReadFromFile(string filePath, string accountName)
        {
            return AdlsClientFactory.GetAdlsClient(accountName, _context).GetReadStream(filePath);
        }

        public string GetHomeDirectory(string accountName)
        {
            // return _client.FileSystem.GetHomeDirectory(accountName).Path;
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns an ienumerable of directoryentry
        /// </summary>
        /// <param name="folderPath">Full directory path</param>
        /// <param name="accountName">Account name</param>
        /// <returns>IEnumerable of directory entry</returns>
        public IEnumerable<DirectoryEntry> GetFileStatuses(string folderPath, string accountName)
        {
            return AdlsClientFactory.GetAdlsClient(accountName, _context).EnumerateDirectory(folderPath);
        }
        /// <summary>
        /// Gets the properties of the file or directory
        /// </summary>
        /// <param name="filePath">Full path of the file or directory</param>
        /// <param name="accountName">Account Name</param>
        /// <returns>Instance encapsulating the properties of the path</returns>
        public DirectoryEntry GetFileStatus(string filePath, string accountName)
        {
            return AdlsClientFactory.GetAdlsClient(accountName, _context).GetDirectoryEntry(filePath);
        }

        /// <summary>
        /// Obtains the content summary recursively
        /// </summary>
        /// <param name="path">File Path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="numThreads">Concurrency</param>
        /// <param name="cancelToken">Cancelation token</param>
        /// <returns></returns>
        public ContentSummary GetContentSummary(string path, string accountName, int numThreads, CancellationToken cancelToken)
        {
            return AdlsClientFactory.GetAdlsClient(accountName, _context).GetContentSummary(path, numThreads, cancelToken);
        }
        /// <summary>
        ///  Deletes the file or folder.
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="isRecursive">For directories if we want recursive delete</param>
        /// <returns>True if the delete is successful else false</returns>
        public bool DeleteFileOrFolder(string path, string accountName, bool isRecursive)
        {
            var client = AdlsClientFactory.GetAdlsClient(accountName, _context);
            return isRecursive ? client.DeleteRecursive(path) : client.Delete(path);
        }

        public void CreateSymLink(string sourcePath, string accountName, string destinationPath,
            bool createParent = false)
        {
            // _client.FileSystem.CreateSymLink(accountName, sourcePath, destinationPath, createParent);
            throw new NotImplementedException();
        }
        /// <summary>
        /// Concats the files
        /// </summary>
        /// <param name="destinationPath">Destination path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="filesToConcatenate">List of files to concatenate</param>
        public void ConcatenateFiles(string destinationPath, string accountName, List<string> filesToConcatenate)
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).ConcatenateFiles(destinationPath, filesToConcatenate);
        }
        /// <summary>
        /// Creates a file in ADL store
        /// </summary>
        /// <param name="filePath">File Path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="contents">Contents</param>
        /// <param name="overwrite">True if we are overwriting the file if it exists, false if we want to fail if the file exists</param>
        public void CreateFile(string filePath, string accountName, byte[] contents = null, IfExists overwrite = IfExists.Overwrite)
        {
            using (Stream createStream = AdlsClientFactory.GetAdlsClient(accountName, _context).CreateFile(filePath, overwrite))
            {
                if (contents != null)
                {
                    createStream.Write(contents, 0, contents.Length);
                }
            }
        }
        /// <summary>
        /// Creates a directory in the store
        /// </summary>
        /// <param name="dirPath">Directory Path</param>
        /// <param name="accountName">Account name</param>
        /// <returns>True if the directory is created successfully else false</returns>
        public bool CreateDirectory(string dirPath, string accountName)
        {
            var boolean = AdlsClientFactory.GetAdlsClient(accountName, _context).CreateDirectory(dirPath);
            return boolean;
        }
        /// <summary>
        /// Appends contents to a file
        /// </summary>
        /// <param name="filePath">Full path of the file</param>
        /// <param name="accountName">Account name</param>
        /// <param name="contents">Contents in byte array</param>
        public void AppendToFile(string filePath, string accountName, byte[] contents)
        {
            using (Stream appendStream = AdlsClientFactory.GetAdlsClient(accountName, _context).GetAppendStream(filePath))
            {
                appendStream.Write(contents, 0, contents.Length);
            }
        }
        /// <summary>
        /// Setsup Nlog logging to a file
        /// </summary>
        /// <param name="level">Logging level- debug or error</param>
        /// <param name="fileName">Path of file where logging will be done</param>
        public void SetupFileLogging(LogLevel level, string fileName)
        {
            var fileTarget = new FileTarget();
            _adlsLoggerConfig.AddTarget("file", fileTarget);

            fileTarget.FileName = fileName;
            
            var rule = new LoggingRule("adls.dotnet.*", NLog.LogLevel.Debug, fileTarget);
            _adlsLoggerConfig.LoggingRules.Add(rule);

            //Re-enable the configuration
            LogManager.Configuration = _adlsLoggerConfig;
        }
        /// <summary>
        /// Performs the bulk copy and tracks the progress
        /// </summary>
        /// <param name="destinationFolderPath">Destination folder path</param>
        /// <param name="accountName">Account name</param>
        /// <param name="sourcePath">Source folder or file path</param>
        /// <param name="cmdletCancellationToken">Commandlet cancellation token</param>
        /// <param name="fileThreadCount">PerFileThreadCount</param>
        /// <param name="recursive">If true then Enumeration of the subdirectories are done recursively</param>
        /// <param name="overwrite">True if we want to overwrite existing destinations</param>
        /// <param name="resume">Indicates that the file(s) being copied are a continuation of a previous file transfer</param>
        /// <param name="isDownload">True if it is download else upload</param>
        /// <param name="cmdletRunningRequest">Current Commandlet</param>
        /// <param name="isBinary">Indicates that the file(s) being uploaded should be copied with no concern for new line preservation across appends</param>
        public void BulkCopy(string destinationFolderPath, string accountName, string sourcePath, CancellationToken cmdletCancellationToken,
            int fileThreadCount = -1, bool recursive = false, bool overwrite = false, bool resume = false, bool isDownload = false,
            Cmdlet cmdletRunningRequest = null, bool isBinary = false)
        {
            var client = AdlsClientFactory.GetAdlsClient(accountName, _context);
            var progress = new ProgressRecord(_uniqueActivityIdGenerator.Next(0, 10000000),
                string.Format("Copying Folder: {0}{1}. Enumerating the source and preparing the copy.",
                sourcePath, recursive ? " recursively" : string.Empty), "Copy in progress...")
            {
                PercentComplete = 0
            };
            // On update from the Data Lake store uploader, capture the progress.
            var progressTracker = new System.Progress<TransferStatus>();
            progressTracker.ProgressChanged += (s, e) =>
            {
                lock (ConsoleOutputLock)
                {
                    var toSet = (int)(1.0 * (e.ChunksTransfered + e.FilesTransfered + e.DirectoriesTransferred) / (e.TotalChunksToTransfer + e.TotalFilesToTransfer + e.TotalDirectoriesToTransfer) * 100);
                    // powershell defect protection. If, through some defect in
                    // our progress tracking, the number is outside of 0 - 100,
                    // powershell will crash if it is set to that value. Instead
                    // just ke ep the value unchanged in that case.
                    if (toSet < 0 || toSet > 100)
                    {
                        progress.PercentComplete = progress.PercentComplete;
                    }
                    else
                    {
                        progress.PercentComplete = toSet;
                    }
                    progress.Activity =
                        $"Copying Folder: {sourcePath}{(recursive ? " recursively" : string.Empty)}. Bytes remaining: {e.TotalSizeToTransfer - e.SizeTransfered}{(e.TotalChunksToTransfer > 0 ? $", Chunks remaining: {e.TotalChunksToTransfer - e.ChunksTransfered}" : "")}{(e.TotalNonChunkedFileToTransfer > 0 ? $", Non-chunked files remaining: {e.TotalNonChunkedFileToTransfer - e.NonChunkedFileTransferred}" : "")}" +
                        $"{(e.TotalDirectoriesToTransfer > 0 ? $", Directories remaining: {e.TotalDirectoriesToTransfer - e.DirectoriesTransferred}" : "")}.";

                }
            };
            TransferStatus status=null;
            Task transferTask = Task.Run(() =>
                {
                    cmdletCancellationToken.ThrowIfCancellationRequested();
                    if (isDownload)
                    {
                        status = client.BulkDownload(sourcePath, destinationFolderPath, fileThreadCount,
                            overwrite ? IfExists.Overwrite : IfExists.Fail, progressTracker, !recursive, resume, cmdletCancellationToken);
                    }
                    else
                    {
                        status = client.BulkUpload(sourcePath, destinationFolderPath, fileThreadCount,
                            overwrite ? IfExists.Overwrite : IfExists.Fail, progressTracker, !recursive, resume, isBinary,cmdletCancellationToken);
                    }
                }, cmdletCancellationToken);


            TrackTaskProgress(transferTask, cmdletRunningRequest, progress, cmdletCancellationToken);

            if (!cmdletCancellationToken.IsCancellationRequested)
            {
                progress.PercentComplete = 100;
                progress.RecordType = ProgressRecordType.Completed;
                UpdateProgress(progress, cmdletRunningRequest);
                if (status != null && cmdletRunningRequest != null)
                {
                    foreach (var failedEntry in status.EntriesFailed)
                    {
                        cmdletRunningRequest.WriteObject($"FailedTransfer: {failedEntry.EntryName} {failedEntry.Errors}");
                    }
                }
            }

        }

        /// <summary>
        /// Get file properties
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <param name="path">Path</param>
        /// <param name="getAclUsage">Get Acl usage</param>
        /// <param name="dumpFileName">Dump file name</param>
        /// <param name="getDiskUsage">GetDisk usage</param>
        /// <param name="saveToLocal">Save to local</param>
        /// <param name="numThreads">Number of threads</param>
        /// <param name="displayFiles">Display files</param>
        /// <param name="hideConsistentAcl">Hide consistent Acl</param>
        /// <param name="maxDepth">Maximum depth</param>
        /// <param name="cmdlet">ExportFileProperties Commandlet</param>
        /// <param name="cmdletCancellationToken">CancellationToken</param>
        public void GetFileProperties(string accountName, string path, bool getAclUsage, string dumpFileName, bool getDiskUsage , bool saveToLocal, int numThreads, bool displayFiles, bool hideConsistentAcl , long maxDepth, Cmdlet cmdlet, CancellationToken cmdletCancellationToken)
        {
            var client = AdlsClientFactory.GetAdlsClient(accountName, _context);
            Task exportTask = Task.Run(() => client
                    .GetFileProperties(
                        path, getAclUsage, dumpFileName,
                        getDiskUsage, saveToLocal, numThreads, displayFiles, hideConsistentAcl, maxDepth,
                        cmdletCancellationToken), cmdletCancellationToken);

            if (_isDebugEnabled)
            {
                TrackTaskProgress(exportTask, cmdlet, null, cmdletCancellationToken);
            }
            else
            {
                WaitForTask(exportTask, cmdletCancellationToken);
            }
        }

        #endregion

        #region Deleted item operations
        /// <summary>
        /// Get items in trash matching query string
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <param name="filter">Query to match items in trash</param>
        /// <param name="count">Minimum number of entries to search for</param>
        /// <param name="cmdlet"></param>
        /// <param name="cmdletCancellationToken">CancellationToken</param>
        public IEnumerable<TrashEntry> EnumerateDeletedItems(string accountName, string filter, int count, Cmdlet cmdlet, CancellationToken cmdletCancellationToken = default(CancellationToken))
        {
            var client = AdlsClientFactory.GetAdlsClient(accountName, _context);
            if (_isDebugEnabled)
            {
                IEnumerable<TrashEntry> result = null;
                // Api call below consists of multiple rest calls so multiple debug statements will be posted
                // so since we want to the debug lines to be updated while the command runs, we have to flush the debug statements in queue and thats why we want to do it this way
                var enumerateTask = Task.Run(() => {
                result = client.EnumerateDeletedItems(filter, "", count, null, cmdletCancellationToken);
                }, cmdletCancellationToken);
                TrackTaskProgress(enumerateTask, cmdlet, null, cmdletCancellationToken);
                return result;
            }
            else
            {
                return client.EnumerateDeletedItems(filter, "", count, null, cmdletCancellationToken);
            }
        }

        /// <summary>
        /// Restore a stream or directory from trash to user space. This is a synchronous operation.
        /// Not threadsafe when Restore is called for same path from different threads. 
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <param name="path">The trash directory path in enumeratedeleteditems response</param>
        /// <param name="destination">Path to where the entry should be restored</param>
        /// <param name="type">Type of the entry which is being restored. "file" or "folder"</param>
        /// <param name="restoreAction">Action to take during destination name conflicts - "overwrite" or "copy"</param>
        /// <param name="cmdletCancellationToken">CancellationToken</param>
        public void RestoreDeletedItem(string accountName, string path, string destination, string type, string restoreAction, CancellationToken cmdletCancellationToken = default(CancellationToken))
        {
            AdlsClientFactory.GetAdlsClient(accountName, _context).RestoreDeletedItems(path, destination, type, restoreAction, cmdletCancellationToken);
        }

        #endregion


        #region private helpers
        /// <summary>
        /// Tracks the task and shows the task progress or debug nessages after a regular interval in the PowerShell console.
        /// Call this method only if you want to do something for a task - like show progress, show debug messages
        /// </summary>
        /// <param name="task">The task that tracks the upload.</param>
        /// <param name="commandToUpdateProgressFor">Commandlet to write to</param>
        /// <param name="taskProgress">The upload progress that will be displayed in the console.</param>
        /// <param name="token">Cancellation token</param>
        private void TrackTaskProgress(Task task, Cmdlet commandToUpdateProgressFor, ProgressRecord taskProgress, CancellationToken token)
        {
            var pscommandToUpdateProgressFor = (DataLakeStoreFileSystemCmdletBase) commandToUpdateProgressFor;
            // Update the UI with the progress.
            var lastUpdate = DateTime.Now.Subtract(TimeSpan.FromSeconds(2));
            while (!task.IsCompleted && !task.IsCanceled)
            {
                if (token.IsCancellationRequested)
                {
                    // we are done tracking progress and will just break and let the task clean itself up.
                    WaitForTask(task, token);
                    break;
                }

                if (DateTime.Now - lastUpdate > TimeSpan.FromSeconds(1))
                {
                    if (taskProgress != null && !token.IsCancellationRequested &&
                        !commandToUpdateProgressFor.Stopping) 
                    {
                        lock (ConsoleOutputLock)
                        {
                            commandToUpdateProgressFor.WriteProgress(taskProgress);
                        }
                    }
                }

                // If debug is enabled then flush debug messages 
                if (_isDebugEnabled)
                {
                    if (!token.IsCancellationRequested &&
                        !commandToUpdateProgressFor.Stopping && pscommandToUpdateProgressFor.DebugMessages.Count > DebugMessageFlushThreshold)
                    {
                        lock (ConsoleOutputLock)
                        {
                            FlushDebugMessages(DebugMessageFlushThreshold, pscommandToUpdateProgressFor);
                        }
                    }
                }
                TestMockSupport.Delay(250);
                
            }

            if (taskProgress != null && (task.IsCanceled || token.IsCancellationRequested))
            {
                taskProgress.RecordType = ProgressRecordType.Completed;
            }
            else if (task.IsFaulted && task.Exception != null)
            {
                // If there are errors, raise them to the user.
                if (task.Exception.InnerException != null)
                {
                    // we only go three levels deep. This is the Inception rule.
                    if (task.Exception.InnerException.InnerException != null)
                    {
                        throw task.Exception.InnerException.InnerException;
                    }

                    throw task.Exception.InnerException;
                }

                throw task.Exception;
            }
            else if (taskProgress != null)
            {
                // finally execution is finished, set progress state to completed.
                taskProgress.PercentComplete = 100;
                taskProgress.RecordType = ProgressRecordType.Completed;

                commandToUpdateProgressFor?.WriteProgress(taskProgress);
            }
        }

        /// <summary>
        /// Flushes the debug messages to debug stream
        /// </summary>
        /// <param name="numDebugMessagesToFlush">number of debug messages to flush</param>
        /// <param name="cmdlet">Instance of AzurePSCCmdlet</param>
        private void FlushDebugMessages(int numDebugMessagesToFlush, AzurePSCmdlet cmdlet)
        {
            string message;
            int count = 0;
            while ((count++ < numDebugMessagesToFlush) && cmdlet.DebugMessages.TryDequeue(out message))
            {
                cmdlet.WriteDebug(message);
            }
        }

        /// <summary>
        /// Waits for the task to finish
        /// </summary>
        /// <param name="task">Task</param>
        /// <param name="token">Cancellation token</param>
        private void WaitForTask(Task task, CancellationToken token)
        {
            try
            {
                task.Wait(token);
            }
            catch (OperationCanceledException)
            {
                if (task.IsCanceled)
                {
                    task.Dispose();
                }
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.OfType<OperationCanceledException>().Any())
                {
                    if (task.IsCanceled)
                    {
                        task.Dispose();
                    }
                }
                else
                {
                    throw;
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
            if (date == DateTimeOffset.MaxValue)
            {
                return -1;
            }

            // NOTE: This assumes the date being passed in is already UTC.
            return (long)(date.UtcDateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        private AclStatus GetFullAcl(AclStatus acl)
        {
            if (acl.Entries != null && acl.Permission != null && acl.Permission.Length >= 3)
            {
                var permissionString = acl.Permission;
                var permissionLength = permissionString.Length;
                var ownerOctal = permissionString.ElementAt(permissionLength - 3).ToString();
                var groupOctal = permissionString.ElementAt(permissionLength - 2).ToString();
                var otherOctal = permissionString.ElementAt(permissionLength - 1).ToString();

                acl.Entries.Add(new AclEntry(AclType.user, string.Empty, AclScope.Access, (AclAction)int.Parse(ownerOctal)));
                acl.Entries.Add(new AclEntry(AclType.other, string.Empty, AclScope.Access, (AclAction)int.Parse(otherOctal)));

                if (acl.Entries.FirstOrDefault(e => e.Type == AclType.group && string.IsNullOrEmpty(e.UserOrGroupId)) != null)
                {
                    acl.Entries.Add(new AclEntry(AclType.mask, string.Empty, AclScope.Access, (AclAction)int.Parse(groupOctal)));
                }
                else
                {
                    acl.Entries.Add(new AclEntry(AclType.group, string.Empty, AclScope.Access, (AclAction)int.Parse(groupOctal)));
                }
            }

            return acl;
        }
        #endregion
    }
}