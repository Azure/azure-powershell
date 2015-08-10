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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsData.Publish, "AzureRemoteAppProgram", DefaultParameterSetName = AppId), OutputType(typeof(PublishingOperationResult), typeof(Job))]
    public class PublishAzureRemoteAppProgram : RdsCmdlet
    {
        private const string AppPath = "App Path";
        private const string AppId = "App Id";

        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = AppPath,
            HelpMessage = "Virtual file path of the program to be published.")]
        public string FileVirtualPath { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AppId,
            HelpMessage = "Start menu program ID of the program to be published.")]
        public string StartMenuAppId { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Command-line argument for the program to be published.")]
        [ValidateNotNullOrEmpty()]
        public string CommandLine { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Display name of the program to be published.")]
        [ValidateNotNullOrEmpty()]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Allows to run the cmdlet in the background as a PS job.")]
        SwitchParameter AsJob { get; set; }

        private LongRunningTask<PublishAzureRemoteAppProgram> task = null;

        private ApplicationDetailsListParameter VerifyPreconditions()
        {
            ApplicationDetailsListParameter appDetails = new ApplicationDetailsListParameter()
            {
                DetailsList = new System.Collections.Generic.List<PublishedApplicationDetails>()
                {
                    new PublishedApplicationDetails()
                }
            };

            string appName = null;
            string appPath = null;
            string iconURI = null;
            IconPngUrisType iconPngUris = new IconPngUrisType();

            switch (ParameterSetName)
            {
                case AppPath:
                {
                    appName = Path.GetFileNameWithoutExtension(FileVirtualPath);
                    appPath = FileVirtualPath;
                    
                    break;
                }
                case AppId:
                {
                    GetStartMenuApplicationResult startMenu = Client.Publishing.StartMenuApplication(CollectionName, StartMenuAppId);
                    appName = startMenu.Result.Name;
                    appPath = startMenu.Result.VirtualPath;
                    iconURI = startMenu.Result.IconUri;
                    iconPngUris = new IconPngUrisType()
                    {
                        IconPngUris = startMenu.Result.IconPngUris,
                    };
                    break;
                }
            }

            appDetails.DetailsList[0].Name = String.IsNullOrWhiteSpace(DisplayName) ? appName : DisplayName;
            appDetails.DetailsList[0].VirtualPath = appPath;

            appDetails.DetailsList[0].IconUri = iconURI;
            appDetails.DetailsList[0].IconPngUris = iconPngUris;

            appDetails.DetailsList[0].Alias = "";

            appDetails.DetailsList[0].CommandLineArguments = CommandLine;

            appDetails.DetailsList[0].AvailableToUsers = true; 

            return appDetails;
        }

        private void StartApplicationPublishing(ApplicationDetailsListParameter appDetails)
        {
            PublishApplicationsResult response = CallClient(() => Client.Publishing.PublishApplications(CollectionName, appDetails), Client.Publishing);

            WriteObject(response.ResultList, true);
        }

        public override void ExecuteCmdlet()
        {
            if (AsJob.IsPresent)
            {
                task = new LongRunningTask<PublishAzureRemoteAppProgram>(this, "RemoteAppBackgroundTask", Commands_RemoteApp.Publish);

                task.ProcessJob(() =>
                {
                    task.SetStatus(Commands_RemoteApp.Publishing);
                    PublishAction();
                    task.SetStatus(Commands_RemoteApp.JobComplete);
                });

                WriteObject(task);
            }
            else
            {
                PublishAction();
            }
        }

        private void PublishAction()
        {
            ApplicationDetailsListParameter appDetails = VerifyPreconditions();
            StartApplicationPublishing(appDetails);
        }

    }
}
