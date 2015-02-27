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

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    using Microsoft.Azure.Management.RemoteApp;
    using Microsoft.Azure.Management.RemoteApp.Models;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Threading;

    [Cmdlet(VerbsCommon.New, "AzureRemoteAppTemplateImage", DefaultParameterSetName = uploadLocalVhd), OutputType(typeof(TemplateImageResult))]

    public class NewAzureRemoteAppTemplateImage : GoldImage
    {
        private const string uploadLocalVhd = "UploadLocalVhd";
        private const string azureVmUpload = "AzureVmUpload";

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
            ParameterSetName = azureVmUpload,
            HelpMessage = "Sysprep-generalized VM image name in Azure")]
        public string AzureVmImageName { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = uploadLocalVhd,
            HelpMessage = "Local path to the RemoteApp vhd")]
        public string Path { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = uploadLocalVhd,
            HelpMessage = "Resumes disrupted upload of an in-progress image")]
        public SwitchParameter Resume { get; set; }

        private LongRunningTask<NewAzureRemoteAppTemplateImage> task = null;


        private void UploadVhd(TemplateImage image)
        {
            UploadScriptResult response = null;
            response = CallClient_ThrowOnError(() => Client.TemplateImages.GetUploadScript());

            if (response != null && response.Script != null)
            {
                RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
                Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
                string uploadFilePath = string.Concat(Environment.GetEnvironmentVariable("temp"), "\\uploadScript.ps1");
                File.WriteAllText(uploadFilePath, response.Script);

                Pipeline pipeline = runspace.CreatePipeline();
                Command myCommand = new Command(uploadFilePath);

                myCommand.Parameters.Add(new CommandParameter("sas", image.Sas));
                myCommand.Parameters.Add(new CommandParameter("uri", image.Uri));
                myCommand.Parameters.Add(new CommandParameter("vhdPath", Path));

                pipeline.Commands.Add(myCommand);

                runspace.Open();
                Collection<PSObject> results = pipeline.Invoke();
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

            if (ParameterSetName == uploadLocalVhd)
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

                if (ParameterSetName == azureVmUpload)
                {
                    details.SourceImageSasUri = GetAzureVmSasUri(AzureVmImageName);
                }

                response = CallClient_ThrowOnError(() => Client.TemplateImages.Set(details));

                templateImage = response.TemplateImage;
                if (templateImage == null)
                {
                    throw new RemoteAppServiceException("Unable to find template by this name in that region", ErrorCategory.ObjectNotFound);
                }
            }

            return templateImage;
        }

        private void ImportTemplateImage()
        {
            TemplateImageResult response = null;
            TemplateImageDetails details = null;

            var features = Client.Account.GetEnabledFeatures();

            EnsureStorageInRegion(Region);
            FilterTemplateImage(ImageName, Operation.Create);

            details = new TemplateImageDetails()
            {
                Name = ImageName,
                Region = Region,
                SourceImageSasUri = GetAzureVmSasUri(AzureVmImageName)
            };

            response = CallClient(() => Client.TemplateImages.Set(details), Client.TemplateImages);

            if (response != null)
            {
                WriteObject(response.TemplateImage);
            }
        }

        private string GetAzureVmSasUri(string vmImageName)
        {
            ComputeManagementClient computeClient = new ComputeManagementClient(this.Client.Credentials, this.Client.BaseUri);
            VirtualMachineOSImageListResponse imageListResponse = computeClient.VirtualMachineOSImages.List();
            VirtualMachineOSImageListResponse.VirtualMachineOSImage vmImage = null;

            if (imageListResponse.Images == null || imageListResponse.Images.Count == 0)
            {
                ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                     "Invalid Argument: No OS Image is found.",
                                     String.Empty,
                                     Client.TemplateImages,
                                     ErrorCategory.InvalidArgument
                                     );

                ThrowTerminatingError(er);
            }

            foreach (VirtualMachineOSImageListResponse.VirtualMachineOSImage Image in imageListResponse.Images)
            {
                if (string.Compare(Image.Name, vmImageName, true) == 0)
                {
                    if (string.Compare(Image.OperatingSystemType, "Windows", true) != 0)
                    {
                        ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                             String.Format("Invalid Argument: OS Image type is {0}. It must be Windows.", Image.OperatingSystemType),
                                             String.Empty,
                                             Client.TemplateImages,
                                             ErrorCategory.InvalidArgument
                                             );

                        ThrowTerminatingError(er);
                    }
                    else if (Image.MediaLinkUri == null || string.IsNullOrEmpty(Image.MediaLinkUri.AbsoluteUri))
                    {
                        ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                             String.Format("Invalid Argument: Cannot use {0} because it is an Azure Gallery image. Only uploaded images can be used.", vmImageName),
                                             String.Empty,
                                             Client.TemplateImages,
                                             ErrorCategory.InvalidArgument
                                             );

                        ThrowTerminatingError(er);
                    }
                    else
                    {
                        vmImage = Image;
                        break;
                    }
                }
            }

            if (vmImage != null)
            {
                Uri uri = new Uri(vmImage.MediaLinkUri.AbsoluteUri);
                StorageManagementClient storageClient = new StorageManagementClient(this.Client.Credentials, this.Client.BaseUri);
                string storageAccountName = uri.Authority.Split('.')[0];
                StorageAccountGetKeysResponse getKeysResponse = storageClient.StorageAccounts.GetKeys(storageAccountName);

                if (getKeysResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    StorageCredentials credentials = new StorageCredentials(storageAccountName, getKeysResponse.SecondaryKey);
                    SharedAccessBlobPolicy accessPolicy = new SharedAccessBlobPolicy();
                    CloudPageBlob pageBlob = null;
                    string sas = null;

                    pageBlob = new CloudPageBlob(uri, credentials);

                    accessPolicy.Permissions = SharedAccessBlobPermissions.Read;
                    accessPolicy.SharedAccessStartTime = DateTime.Now;
                    accessPolicy.SharedAccessExpiryTime = DateTime.Now.AddHours(12);

                    sas = pageBlob.GetSharedAccessSignature(accessPolicy);

                    if (sas != null)
                    {
                        return vmImage.MediaLinkUri.AbsoluteUri + sas;
                    }
                }
            }

            return null;
        }

        public override void ExecuteCmdlet()
        {
            // register the subscription for this service if it has not been before
            // sebsequent call to register is redundent
            RegisterSubscriptionWithRdfeForRemoteApp();

            switch (ParameterSetName)
            {
                case uploadLocalVhd:
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
                case azureVmUpload:
                    {
                        ImportTemplateImage();

                        break;
                    }
            }
        }
    }
}
