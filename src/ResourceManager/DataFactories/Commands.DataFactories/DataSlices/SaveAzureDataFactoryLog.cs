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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Security.AccessControl;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsData.Save, Constants.RunLog, DefaultParameterSetName = ByFactoryName), OutputType(typeof(PSRunLogInfo))]
    public class SaveAzureDataFactoryLog : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data slice run id.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Download logs using the SAS url.")]
        public SwitchParameter DownloadLogs { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Directory to download the log. Default is current directory.")]
        public string Output { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByFactoryObject)
            {
                if (DataFactory == null)
                {
                    throw new PSArgumentNullException(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryArgumentInvalid));
                }

                DataFactoryName = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            Uri runLogUri =
                DataFactoryClient.GetDataSliceRunLogsSharedAccessSignature(
                    ResourceGroupName, DataFactoryName, Id);
            if (DownloadLogs.IsPresent)
            {
                string directory = string.IsNullOrWhiteSpace(Output)
                    ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    : Output;

                if (!HaveWriteAccess(directory))
                {
                    throw new IOException(string.Format(CultureInfo.InvariantCulture, Resources.NoWriteAccessToDirectory, directory));
                }

                try
                {
                    DataFactoryClient.DownloadFileToBlob(new BlobDownloadParameters()
                    {
                        Directory = directory,
                        SasUri = runLogUri,
                    });
                }
                catch
                {
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, Resources.DownloadFailed, directory));
                }

                WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.DownloadLogCompleted, directory));
            }

            WriteObject(new PSRunLogInfo(runLogUri));
        }

        private bool HaveWriteAccess(string directory)
        {
            bool writeAllow = false;
            bool writeDeny = false;
            try
            {
                DirectorySecurity accessControlList = Directory.GetAccessControl(directory);
                if (accessControlList == null)
                {
                    return false;
                }

                var rules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                if (rules == null)
                {
                    return false;
                }

                foreach (FileSystemAccessRule rule in rules)
                {
                    if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write)
                    {
                        continue;
                    }

                    if (rule.AccessControlType == AccessControlType.Allow)
                    {
                        writeAllow = true;
                    }

                    else if (rule.AccessControlType == AccessControlType.Deny)
                    {
                        writeDeny = true;
                    }
                }

                return writeAllow && !writeDeny;
            }
            catch
            {
                return false;
            }
        }
    }
}