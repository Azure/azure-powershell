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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Text;
using Commands.Storage.ScenarioTest.Util;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;

namespace Commands.Storage.ScenarioTest
{
    class PowerShellAgent: Agent
    {
        private static string ContextParameterName = "Context";
        private static object AgentContext;
        private static string CmdletLogFormat = "{0} : {1}";

        public static object Context
        {
            get
            {
                return AgentContext;
            }
        }

        // add this member for importing module
        private static InitialSessionState _InitState = InitialSessionState.CreateDefault();

        private static PowerShell PowerShellInstance = null;
        private static PSCommand InitCommand = null;

        private PowerShell GetPowerShellInstance()
        {
            if (PowerShellInstance != null)
            {
                PowerShellAgent.PowerShellInstance.Commands = PowerShellAgent.InitCommand;
                PowerShellAgent.PowerShellInstance.Streams.Error.Clear();
                PowerShellAgent.PowerShellInstance.AddScript("$ErrorActionPreference='Continue'");
                PowerShellAgent.PowerShellInstance.AddStatement();
                return PowerShellAgent.PowerShellInstance;
            }
            else
            {
                return PowerShell.Create(_InitState);
            }
        }

        public static void SetPowerShellInstance(PowerShell instance)
        {
            PowerShellAgent.PowerShellInstance = instance;
            PowerShellAgent.InitCommand = instance.Commands;
        }

        public static void ImportModule(string ModuleFilePath)
        {
            if (string.IsNullOrEmpty(ModuleFilePath))
            {
                Test.Info("Skip importing powershell module");
                return;
            }

            if (File.Exists(ModuleFilePath))
            {
                Test.Info("Import-Module {0}", ModuleFilePath);
                _InitState.ImportPSModule(new string[] { ModuleFilePath });
            }
            else
                throw new Exception(String.Format("Module file path : {0} not found!", ModuleFilePath));
        }

        /// <summary>
        /// Import azure subscription
        /// </summary>
        /// <param name="filePath">Azure subscription file path</param>
        public static void ImportAzureSubscriptionAndSetStorageAccount(string filePath, string subscriptionName, string storageAccountName)
        {
            PowerShell ps = PowerShell.Create(_InitState);
            //TODO add tests for positional parameter
            ps.AddCommand("Import-AzurePublishSettingsFile");
            ps.BindParameter("PublishSettingsFile", filePath);
            ps.AddStatement();
            ps.AddCommand("Set-AzureSubscription");
            ps.BindParameter("SubscriptionName", subscriptionName);
            ps.BindParameter("CurrentStorageAccountName", storageAccountName);
            Test.Info("set current storage account in subscription, Cmdline: {0}", GetCommandLine(ps));
            ps.Invoke();

            if(ps.Streams.Error.Count > 0)
            {
                Test.Error("Can't set current storage account to {0} in subscription {1}. Exception: {2}", storageAccountName, subscriptionName, ps.Streams.Error[0].Exception.Message);
            }
        }

        public static string AddRandomAzureEnvironment(string endpoint, string prefix = "") 
        {
            string envName = Utility.GenNameString(prefix);
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("Add-AzureEnvironment");
            ps.BindParameter("Name", envName);
            ps.BindParameter("PublishSettingsFileUrl", Utility.GenNameString("PublishSettingsFileUrl"));
            ps.BindParameter("ServiceEndpoint", Utility.GenNameString("ServiceEndpoint"));
            ps.BindParameter("ManagementPortalUrl", Utility.GenNameString("ManagementPortalUrl"));
            ps.BindParameter("StorageEndpoint", endpoint);
            Test.Info("Add Azure Environment, Cmdline: {0}", GetCommandLine(ps));
            ps.Invoke();

            if (ps.Streams.Error.Count > 0)
            {
                Test.Error("Can't add azure envrionment. Exception: {0}", ps.Streams.Error[0].Exception.Message);
            }
            return envName;
        }

        public static void RemoveAzureEnvironment(string name)
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("Remove-AzureEnvironment");
            ps.BindParameter("Name", name);
            Test.Info("Remove Azure Environment, Cmdline: {0}", GetCommandLine(ps));
            ps.Invoke();

            if (ps.Streams.Error.Count > 0)
            {
                Test.Error("Can't add azure envrionment. Exception: {0}", ps.Streams.Error[0].Exception.Message);
            }
        }

        /// <summary>
        /// Remove the current azure subscription
        /// </summary>
        public static void RemoveAzureSubscriptionIfExists()
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddScript("Get-AzureSubscription | Remove-AzureSubscription -Force");
            ps.Invoke();
        }

        public static void SetStorageContext(string StorageAccountName, string StorageAccountKey,
            bool useHttps = true, string endPoint = "")
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("StorageAccountName", StorageAccountName);
            ps.BindParameter("StorageAccountKey", StorageAccountKey);
            ps.BindParameter("EndPoint", endPoint.Trim());

            if (useHttps)
            {
                //TODO need tests to check whether it's ignore cases.
                ps.BindParameter("Protocol", "https");
            }
            else
            {
                ps.BindParameter("Protocol", "http");
            }

            Test.Info("Set PowerShell Storage Context using name and key, Cmdline: {0}", GetCommandLine(ps));
            SetStorageContext(ps);
        }

        public static void SetStorageContextWithAzureEnvironment(string StorageAccountName, string StorageAccountKey,
            bool useHttps = true, string azureEnvironmentName = "")
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("StorageAccountName", StorageAccountName);
            ps.BindParameter("StorageAccountKey", StorageAccountKey);
            ps.BindParameter("Environment", azureEnvironmentName.Trim());

            if (useHttps)
            {
                ps.BindParameter("Protocol", "https");
            }
            else
            {
                ps.BindParameter("Protocol", "http");
            }

            Test.Info("Set PowerShell Storage Context using name, key and azureEnvironment, Cmdline: {0}", GetCommandLine(ps));
            SetStorageContext(ps);
        }

        public static void SetStorageContext(string ConnectionString)
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("ConnectionString", ConnectionString);

            Test.Info("Set PowerShell Storage Context using connection string, Cmdline: {0}", GetCommandLine(ps));
            SetStorageContext(ps);
        }

        public static void SetLocalStorageContext()
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("Local");

            Test.Info("Set PowerShell Storage Context using local development storage account, Cmdline: {0}", GetCommandLine(ps));
            SetStorageContext(ps);
        }

        public static void SetAnonymousStorageContext(string StorageAccountName, bool useHttps, string endPoint = "")
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("StorageAccountName", StorageAccountName);
            ps.BindParameter("Anonymous");
            ps.BindParameter("EndPoint", endPoint.Trim());

            if (useHttps)
            {
                //TODO need tests to check whether it's ignore cases.
                ps.BindParameter("Protocol", "https");
            }
            else
            {
                ps.BindParameter("Protocol", "http");
            }

            Test.Info("Set PowerShell Storage Context using Anonymous storage account, Cmdline: {0}", GetCommandLine(ps));
            SetStorageContext(ps);
        }

        internal static void SetStorageContext(PowerShell ps)
        {
            AgentContext = null;

            foreach (PSObject result in ps.Invoke())
            {
                foreach (PSMemberInfo member in result.Members)
                {
                    if (member.Name.Equals("Context"))
                    {
                        AgentContext = member.Value;
                        return;
                    }
                }
            }
            // if we cannot find the Context field, we will throw an exception here
            throw new Exception("StorageContext not found!");
        }

        /// <summary>
        /// Clean storage context
        /// </summary>
        public static void CleanStorageContext()
        {
            AgentContext = null;
        }

        internal static object GetStorageContext(Collection<PSObject> objects)
        {
            foreach (PSObject result in objects)
            {
                foreach (PSMemberInfo member in result.Members)
                {
                    if (member.Name.Equals("Context"))
                    {
                        return member.Value;
                    }
                }
            }
            return null;
        }

        internal static object GetStorageContext(string ConnectionString)
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("ConnectionString", ConnectionString);

            Test.Info("{0} Test...\n{1}", MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            return GetStorageContext(ps.Invoke());
        }

        internal static object GetStorageContext(string StorageAccountName, string StorageAccountKey)
        {
            PowerShell ps = PowerShell.Create(_InitState);
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("StorageAccountName", StorageAccountName);
            ps.BindParameter("StorageAccountKey", StorageAccountKey);

            Test.Info("{0} Test...\n{1}", MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            return GetStorageContext(ps.Invoke());
        }

        public override bool NewAzureStorageContext(string StorageAccountName, string StorageAccountKey, string endPoint = "")
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("StorageAccountName", StorageAccountName);
            ps.BindParameter("StorageAccountKey", StorageAccountKey);

            if (string.IsNullOrEmpty(StorageAccountKey))
            {
                ps.BindParameter("Anonymous", true);
            }

            ps.BindParameter("EndPoint", endPoint);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            return NewAzureStorageContext(ps);
        }

        public override bool NewAzureStorageContext(string ConnectionString)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("New-AzureStorageContext");
            ps.BindParameter("ConnectionString", ConnectionString);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            return NewAzureStorageContext(ps);
        }

        internal bool NewAzureStorageContext(PowerShell ps)
        {
            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }


        public override bool NewAzureStorageContainer(string ContainerName)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("New-AzureStorageContainer");

            ps.BindParameter("Name", ContainerName);

            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool NewAzureStorageContainer(string[] ContainerNames)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddScript(FormatNameList(ContainerNames));
            ps.AddCommand("New-AzureStorageContainer");
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageContainer(string ContainerName)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Get-AzureStorageContainer");
            ps.BindParameter("Name", ContainerName);

            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageContainerByPrefix(string Prefix)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Get-AzureStorageContainer");
            ps.BindParameter("Prefix", Prefix);
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool SetAzureStorageContainerACL(string ContainerName, BlobContainerPublicAccessType PublicAccess, bool PassThru = true)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Set-AzureStorageContainerACL");
            ps.BindParameter("Name", ContainerName);
            ps.BindParameter("PublicAccess", PublicAccess);
            ps.BindParameter("PassThru", PassThru);

            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool RemoveAzureStorageContainer(string ContainerName, bool Force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Remove-AzureStorageContainer");
            ps.BindParameter("Name", ContainerName);

            AddCommonParameters(ps, Force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool RemoveAzureStorageContainer(string[] ContainerNames, bool Force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddScript(FormatNameList(ContainerNames));
            ps.AddCommand("Remove-AzureStorageContainer");
            AddCommonParameters(ps, Force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool NewAzureStorageQueue(string QueueName)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("New-AzureStorageQueue");
            ps.BindParameter("Name", QueueName);
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool NewAzureStorageQueue(string[] QueueNames)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddScript(FormatNameList(QueueNames));
            ps.AddCommand("New-AzureStorageQueue");
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageQueue(string QueueName)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Get-AzureStorageQueue");
            ps.BindParameter("Name", QueueName);

            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageQueueByPrefix(string Prefix)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Get-AzureStorageQueue");
            ps.BindParameter("Prefix", Prefix);
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool RemoveAzureStorageQueue(string QueueName, bool Force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Remove-AzureStorageQueue");
            ps.BindParameter("Name", QueueName);

            AddCommonParameters(ps, Force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool RemoveAzureStorageQueue(string[] QueueNames, bool Force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddScript(FormatNameList(QueueNames));
            ps.AddCommand("Remove-AzureStorageQueue");
            AddCommonParameters(ps, Force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool SetAzureStorageBlobContent(string FileName, string ContainerName, BlobType Type, string BlobName = "",
            bool Force = true, int ConcurrentCount = -1, Hashtable properties = null, Hashtable metadata = null)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Set-AzureStorageBlobContent");
            ps.BindParameter("File", FileName);
            ps.BindParameter("Blob", BlobName);
            ps.BindParameter("Container", ContainerName);
            ps.BindParameter("Properties", properties);
            ps.BindParameter("Metadata", metadata);

            if (Type == BlobType.BlockBlob)
            {
                ps.BindParameter("BlobType", "Block");
            }
            else if (Type == BlobType.PageBlob)
            {
                ps.BindParameter("BlobType", "Page");
            }

            if (ConcurrentCount != -1)
            {
                ps.BindParameter("ConcurrentCount", ConcurrentCount);
            }

            AddCommonParameters(ps, Force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseBlobCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageBlobContent(string Blob, string FileName, string ContainerName, 
            bool Force = true, int ConcurrentCount = -1)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Get-AzureStorageBlobContent");
            ps.BindParameter("Blob", Blob);
            ps.BindParameter("Destination", FileName);
            ps.BindParameter("Container", ContainerName);

            if (ConcurrentCount != -1)
            {
                ps.BindParameter("ConcurrentCount", ConcurrentCount);
            }

            AddCommonParameters(ps, Force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseBlobCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageBlob(string BlobName, string ContainerName)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Get-AzureStorageBlob");
            ps.BindParameter("Blob", BlobName);
            ps.BindParameter("Container", ContainerName);

            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseBlobCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageBlobByPrefix(string Prefix, string ContainerName)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Get-AzureStorageBlob");
            ps.BindParameter("Prefix", Prefix);
            ps.BindParameter("Container", ContainerName);
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseBlobCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool RemoveAzureStorageBlob(string BlobName, string ContainerName, bool onlySnapshot = false, bool force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Remove-AzureStorageBlob");
            ps.BindParameter("Blob", BlobName);
            ps.BindParameter("Container", ContainerName);
            ps.BindParameter("DeleteSnapshot", onlySnapshot);

            AddCommonParameters(ps, force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool NewAzureStorageTable(string TableName)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("New-AzureStorageTable");
            ps.BindParameter("Name", TableName);

            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool NewAzureStorageTable(string[] TableNames)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddScript(FormatNameList(TableNames));
            ps.AddCommand("New-AzureStorageTable");
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageTable(string TableName)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Get-AzureStorageTable");
            ps.BindParameter("Name", TableName);
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool GetAzureStorageTableByPrefix(string Prefix)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Get-AzureStorageTable");
            ps.BindParameter("Prefix", Prefix);
            AddCommonParameters(ps);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseContainerCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool RemoveAzureStorageTable(string TableName, bool Force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);
            ps.AddCommand("Remove-AzureStorageTable");
            ps.BindParameter("Name", TableName);

            AddCommonParameters(ps, Force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool RemoveAzureStorageTable(string[] TableNames, bool Force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddScript(FormatNameList(TableNames));
            ps.AddCommand("Remove-AzureStorageTable");
            AddCommonParameters(ps, Force);

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            ParseCollection(ps.Invoke());
            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        public override bool StartAzureStorageBlobCopy(string sourceUri, string destContainerName, string destBlobName, object destContext = null, bool force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Start-AzureStorageBlobCopy");
            ps.BindParameter("SrcUri", sourceUri);
            ps.BindParameter("DestContainer", destContainerName);
            ps.BindParameter("DestBlob", destBlobName);
            ps.BindParameter("Force", force);
            ps.BindParameter("DestContext", destContext);

            //Don't use context parameter for this cmdlet
            bool savedParameter = UseContextParam;
            UseContextParam = false;
            bool executeState = InvokeStoragePowerShell(ps);
            UseContextParam = savedParameter;
            return executeState;
        }

        public override bool StartAzureStorageBlobCopy(string srcContainerName, string srcBlobName, string destContainerName, string destBlobName, object destContext = null, bool force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Start-AzureStorageBlobCopy");
            ps.BindParameter("SrcContainer", srcContainerName);
            ps.BindParameter("SrcBlob", srcBlobName);
            ps.BindParameter("DestContainer", destContainerName);
            ps.BindParameter("Force", force);
            ps.BindParameter("DestBlob", destBlobName);
            ps.BindParameter("DestContext", destContext);

            return InvokeStoragePowerShell(ps);
        }

        public override bool StartAzureStorageBlobCopy(ICloudBlob srcBlob, string destContainerName, string destBlobName, object destContext = null, bool force = true)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Start-AzureStorageBlobCopy");
            ps.BindParameter("ICloudBlob", srcBlob);
            ps.BindParameter("DestContainer", destContainerName);
            ps.BindParameter("Force", force);
            ps.BindParameter("DestBlob", destBlobName);
            ps.BindParameter("DestContext", destContext);

            return InvokeStoragePowerShell(ps);
        }

        public override bool GetAzureStorageBlobCopyState(string containerName, string blobName, bool waitForComplete)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);

            ps.AddCommand("Get-AzureStorageBlobCopyState");

            ps.BindParameter("Container", containerName);
            ps.BindParameter("Blob", blobName);
            ps.BindParameter("WaitForComplete", waitForComplete);

            return InvokeStoragePowerShell(ps);
        }

        public override bool GetAzureStorageBlobCopyState(ICloudBlob blob, object context, bool waitForComplete)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("Get-AzureStorageBlobCopyState");
            ps.BindParameter("ICloudBlob", blob);
            ps.BindParameter("WaitForComplete", waitForComplete);

            return InvokeStoragePowerShell(ps, context);
        }

        public override bool StopAzureStorageBlobCopy(string containerName, string blobName, string copyId, bool force)
        {
            PowerShell ps = GetPowerShellInstance();
            AttachPipeline(ps);

            ps.AddCommand("Stop-AzureStorageBlobCopy");
            ps.BindParameter("Container", containerName);
            ps.BindParameter("Blob", blobName);
            ps.BindParameter("CopyId", copyId);
            ps.BindParameter("Force", force);

            return InvokeStoragePowerShell(ps);
        }

        private bool InvokeStoragePowerShell(PowerShell ps, object context = null)
        {
            if (context == null)
            {
                AddCommonParameters(ps);
            }
            else
            {
                ps.BindParameter(ContextParameterName, context);
            }

            Test.Info(CmdletLogFormat, MethodBase.GetCurrentMethod().Name, GetCommandLine(ps));

            //TODO We should add a time out for this invoke. Bad news, powershell don't support buildin time out for invoking.
            try
            {
                ParseCollection(ps.Invoke());
            }
            catch (Exception e)
            {
                Test.Info(e.Message);
            }

            ParseErrorMessages(ps);

            return !ps.HadErrors;
        }

        /// <summary>
        /// Add the common parameters
        ///     -Context ...
        ///     -Force ...
        /// </summary>        
        internal void AddCommonParameters(PowerShell ps, bool Force)
        {
            AddCommonParameters(ps);
            
            if (Force)
            {
                ps.BindParameter("Force");
            }
        }

        /// <summary>
        /// Add the common parameters
        ///     -Context ...
        /// </summary>        
        internal void AddCommonParameters(PowerShell ps)
        {
            if (UseContextParam && AgentContext != null)
            {
                ps.BindParameter(ContextParameterName, AgentContext);
            }
        }

        /// <summary>
        /// Get the command line string
        /// </summary>        
        static internal string GetCommandLine(PowerShell ps)
        {
            StringBuilder strCmdLine = new StringBuilder();
            bool bFirst = true;
            foreach (Command command in ps.Commands.Commands)
            {
                if (bFirst)
                {
                    bFirst = false;
                }
                else
                {
                    strCmdLine.Append(" | ");
                }

                strCmdLine.Append(command.CommandText);

                foreach (CommandParameter param in command.Parameters)
                {
                    if (param.Name != null)
                    {
                        strCmdLine.Append(" -" + param.Name);
                    }

                    if (param.Value != null)
                    {
                        strCmdLine.Append(" " + param.Value);
                    }
                }
            }
            return strCmdLine.ToString();
        }

        /// <summary>
        /// Parse the return values in the colletion
        /// </summary>     
        internal void ParseCollection(Collection<PSObject> Values)
        {
            _Output.Clear();

            foreach (PSObject result in Values)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (PSMemberInfo member in result.Members)
                {
                    if (member.Value != null)
                    {
                        // skip the PSMethod members
                        if (member.Value.GetType() != typeof(PSMethod))
                        {
                            dic.Add(member.Name, member.Value);
                        }
                    }
                    else
                    {
                        dic.Add(member.Name, member.Value);
                    }
                }
                _Output.Add(dic);
            }

            //clean pipeline when finished
            CleanPipeline();
        }

        /// <summary>
        /// Parse the return values of container operation
        /// </summary>     
        internal void ParseContainerCollection(Collection<PSObject> Values)
        {
            _Output.Clear();

            foreach (PSObject result in Values)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (PSMemberInfo member in result.Members)
                {
                    if (member.Value != null)
                    {
                        // skip the PSMethod members
                        if (member.Value.GetType() != typeof(PSMethod))
                        {
                            dic.Add(member.Name, member.Value);
                        }
                    }
                    else
                    {
                        dic.Add(member.Name, member.Value);
                    }

                    if (member.Name.Equals("Properties"))
                    {
                        BlobContainerProperties properties = (BlobContainerProperties)member.Value;
                        dic.Add("LastModified", properties.LastModified);
                    }
                }
                _Output.Add(dic);
            }

            //clean pipeline when finished
            CleanPipeline();
        }

        /// <summary>
        /// Parse the return values of blob operation
        /// </summary>     
        internal void ParseBlobCollection(Collection<PSObject> Values)
        {
            _Output.Clear();

            foreach (PSObject result in Values)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (PSMemberInfo member in result.Members)
                {
                    if (member.Value != null)
                    {
                        // skip the PSMethod members
                        if (member.Value.GetType() != typeof(PSMethod))
                        {
                            dic.Add(member.Name, member.Value);
                        }
                    }
                    else
                    {
                        dic.Add(member.Name, member.Value);
                    }

                    if (member.Name.Equals("Properties"))
                    {
                        BlobProperties properties = (BlobProperties)member.Value;
                        dic.Add("LastModified", properties.LastModified);
                        dic.Add("Length", properties.Length);
                        dic.Add("ContentType", properties.ContentType);
                    }
                }
                _Output.Add(dic);
            }

            //clean pipeline when finished
            CleanPipeline();
        }

        /// <summary>
        /// Parse the error messages in PowerShell
        /// </summary>     
        internal void ParseErrorMessages(PowerShell ps)
        {
            if (ps.HadErrors)
            {
                _ErrorMessages.Clear();
                foreach (ErrorRecord record in ps.Streams.Error)
                {
                    _ErrorMessages.Add(record.Exception.Message);
                    Test.Info(record.Exception.Message);

                    //Display the stack trace for storage exception in order to investigate the root cause of errors
                    if (record.Exception.GetType() == typeof(StorageException))
                    {
                        //Display the stack trace from where the exception is thrown
                        //Since we repack the storage exception, the following call stack may be inaccurate
                        Test.Info("[Exception Call Stack Trace]:{0}", record.Exception.StackTrace);

                        if (record.Exception.InnerException != null)
                        {
                            //Display the stack trace of innerException
                            Test.Info("[InnerException Call Stack Trace]:{0}", record.Exception.InnerException.StackTrace);
                        }
                    }
                    
                }
            }
        }

        /// <summary>
        /// Convert names to a string type name list 
        /// e.g.
        ///     names = new string[]{ "bbbb", "cccc", "dddd" }
        /// ConvertNameList(names) = "bbbb", "cccc", "dddd"
        /// </summary>   
        internal static string FormatNameList(string[] names)
        {
            StringBuilder builder = new StringBuilder();
            bool bFirst = true;

            foreach (string name in names)
            {
                if (bFirst)
                {
                    bFirst = false;
                }
                else
                {
                    builder.Append(",");
                }

                builder.Append(String.Format("\"{0}\"", name));
            }
            return builder.ToString(); 
        }

        ///-------------------------------------
        /// The following interface only used for PowerShell Agent, and they are not part of Agent
        ///-------------------------------------
        private List<string> pipeLine = new List<string>();

        public void AddPipelineScript(string cmd)
        {
            if (string.IsNullOrEmpty(cmd))
            {
                return;
            }
            
            pipeLine.Add(cmd);
        }

        public void CleanPipeline()
        {
            pipeLine.Clear();
        }

        /// <summary>
        /// Attach some script to the current PowerShell instance
        ///     Attach Rule :
        ///         1. If the script is start with "$", we directly add it to the pipeline
        ///         2. If the current script is storage cmdlet, we need to add the current storage context to it.
        ///         3. Otherwise, split the script into [CommandName] and many [-Parameter][Value] pairs, attach them using PowerShell command interface(AddParameter/AddCommand/etc)
        ///         //TODO update the step 3
        /// </summary>
        /// <param name="ps">PowerShell instance</param>
        private void AttachPipeline(PowerShell ps)
        {
            foreach (string cmd in pipeLine)
            {
                if (cmd.Length > 0 && cmd[0] == '$')
                {
                    ps.AddScript(cmd);
                }
                else
                {
                    string[] cmdOpts = cmd.Split(' ');
                    string cmdName = cmdOpts[0];
                    ps.AddCommand(cmdName);

                    string opts = string.Empty;
                    bool skip = false;
                    for (int i = 1; i < cmdOpts.Length; i++)
                    {
                        if (skip)
                        {
                            skip = false;
                            continue;
                        }

                        if (cmdOpts[i].IndexOf("-") != 0)
                        {
                            ps.AddArgument(cmdOpts[i]);
                        }
                        else
                        {
                            if (i + 1 < cmdOpts.Length && cmdOpts[i + 1].IndexOf("-") != 0)
                            {
                                ps.BindParameter(cmdOpts[i].Substring(1), cmdOpts[i + 1]);
                                skip = true;
                            }
                            else
                            {
                                ps.BindParameter(cmdOpts[i].Substring(1));
                                skip = false;
                            }
                        }
                    }

                    //add storage context for azure storage cmdlet 
                    //It make sure all the storage cmdlet in pipeline use the same storage context
                    if (cmdName.ToLower().IndexOf("-azurestorage") != -1)
                    {
                        AddCommonParameters(ps);
                    }
                }
            }
        }
    }
}
