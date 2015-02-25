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

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
    using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
    using System.Management.Automation.Runspaces;
using System.Threading;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureRemoteAppTemplateImage", DefaultParameterSetName = UploadLocalVhd), OutputType(typeof(TemplateImageResult))]
 
    public class NewAzureRemoteAppTemplateImage : GoldImage
    {
        private const string UploadLocalVhd = "UploadLocalVhd";

        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Template image name")]
        public string ImageName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Region in which the template image will be stored")]
        public string Region { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = UploadLocalVhd,
            HelpMessage = "Local path to the RemoteApp vhd")]
        public string Path { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = UploadLocalVhd,
            HelpMessage = "Resumes disrupted upload of an in-progress image")]
        public SwitchParameter Resume { get; set; }

        private LongRunningTask<NewAzureRemoteAppTemplateImage> task = null;


        private void UploadVhd(TemplateImage image)
        {
            UploadScriptResult response = null;

            task.SetStatus("Calling the RemoteApp script to upload the " + ImageName + " to your storage " + image.Sas);

            response = CallClient_ThrowOnError(() => Client.TemplateImages.GetUploadScript());

            if (response != null && response.Script != null)
            {
                RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
                Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
                string uploadFilePath = string.Concat(Environment.GetEnvironmentVariable("temp"), "\\uploadScript.ps1");
                Pipeline pipeline = runspace.CreatePipeline();
                Command myCommand = new Command(uploadFilePath);
                Collection<PSObject> results;

                File.WriteAllText(uploadFilePath, response.Script);

                myCommand.Parameters.Add(new CommandParameter("sas", image.Sas));
                myCommand.Parameters.Add(new CommandParameter("uri", image.Uri));
                myCommand.Parameters.Add(new CommandParameter("vhdPath", Path));

                pipeline.Commands.Add(myCommand);

                runspace.Open();
                results = pipeline.Invoke();

                if (pipeline.Error.Count > 0)
                {
                    Collection<ErrorRecord> errors = pipeline.Error.Read() as Collection<ErrorRecord>;

                    if (errors != null)
                    {
                        foreach(ErrorRecord error in errors)
                        {
                            task.Error.Add(error);
                        }

                        task.SetState(JobState.Failed, new Exception("Upload script failed"));
                    }
                }
            }
            else
            {
                throw new RemoteAppServiceException("Failed to get upload script", ErrorCategory.ConnectionError);
            }
        }


        private void EnsureStorageInRegion(string region)
        {
            OperationResultWithTrackingId responseWithTrackingId = null;
            RemoteAppOperationStatusResult operationalResponse = null;
            const int waitPeriodMilliseconds = 5 * 1000;
            const int maxIterations = 60;
            int counter = 0;
            responseWithTrackingId = CallClient_ThrowOnError(() => Client.TemplateImages.EnsureStorageInRegion(region));

            if (responseWithTrackingId.TrackingId != null)
            {
                task.SetStatus("Waiting for Storage verification to complete");
                do
                {
                    Thread.Sleep(waitPeriodMilliseconds);
                    counter++;
                    operationalResponse = CallClient_ThrowOnError(() => Client.OperationResults.Get(responseWithTrackingId.TrackingId));
                }
                while ((operationalResponse.RemoteAppOperationResult.Status == RemoteAppOperationStatus.Pending ||
                          operationalResponse.RemoteAppOperationResult.Status == RemoteAppOperationStatus.InProgress) &&
                          counter < maxIterations);

                if (counter >= maxIterations || operationalResponse.RemoteAppOperationResult.Status != RemoteAppOperationStatus.Success)
                {
                    throw new RemoteAppServiceException("Failed to create storage for collection", ErrorCategory.OperationTimeout);
                }
            }
        }

        private TemplateImage VerifyPreconditions()
        {
            TemplateImage matchingTemplate = null;
            Operation op = Operation.Create;

            if (Resume)
            {
                op = Operation.Resume;
            }

            if (ParameterSetName == UploadLocalVhd)
            {
                VerifySessionIsElevated();
            }

            matchingTemplate = FilterTemplateImage(ImageName, op);

            return matchingTemplate;
        }

        private TemplateImage StartTemplateUpload(TemplateImage image)
        {
            TemplateImageResult response = null;
            TemplateImageDetails details = null;
            TemplateImage templateImage = null;

            EnsureStorageInRegion(Region);
            
            if (Resume)
            {
                templateImage = image;
            }
            else
            {
                details = new TemplateImageDetails()
                {
                    Name = ImageName,
                    Region = Region
                };

                response = CallClient_ThrowOnError(() => Client.TemplateImages.Set(details));

                if (response.StatusCode != System.Net.HttpStatusCode.OK || response.TemplateImage == null)
                {
                    throw new RemoteAppServiceException("Unable to find template by this name in that region", ErrorCategory.ObjectNotFound);
                }

                templateImage = response.TemplateImage;
            }

            return templateImage;
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case UploadLocalVhd:
                {
                    string scriptBlock = "Test-Path -Path " + Path;
                    Collection<bool> pathValid = CallPowershellWithReturnType<bool>(scriptBlock);
                    TemplateImage image = null;

                    if (pathValid[0] == false)
                    {
                        throw new RemoteAppServiceException("Could not validate path to VHD", ErrorCategory.ObjectNotFound);
                    }

                    image = VerifyPreconditions();
                    image = StartTemplateUpload(image);

                    task = new LongRunningTask<NewAzureRemoteAppTemplateImage>(this, "RemoteAppTemplateImageUpload", "Upload RemoteApp Template Image");

                    task.ProcessJob(() =>
                    {
                        UploadVhd(image);
                        task.SetStatus("ProcessJob completed");
                    });

                    WriteObject(task);

                    break;
                }
            }
        }
    }
}
