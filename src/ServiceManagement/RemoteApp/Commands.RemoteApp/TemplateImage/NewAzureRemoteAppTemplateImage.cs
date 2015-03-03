﻿// ----------------------------------------------------------------------------------
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

    [Cmdlet(VerbsCommon.New, "AzureRemoteAppTemplateImage", DefaultParameterSetName = UploadLocalVhd), OutputType(typeof(TemplateImageResult))]

    public class NewAzureRemoteAppTemplateImage : GoldImage
    {
        private const string UploadLocalVhd = "UploadLocalVhd";
        private const string AzureVmUpload = "AzureVmUpload";

        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Template image name")]
        public string ImageName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location in which the template image will be stored")]
        public string Location { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureVmUpload,
            HelpMessage = "Sysprep-generalized VM image name in Azure")]
        public string AzureVmImageName { get; set; }

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
            response = CallClient_ThrowOnError(() => Client.TemplateImages.GetUploadScript());

            if (response != null && response.Script != null)
            {
                RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
                Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
                string uploadFilePath = string.Concat(Environment.GetEnvironmentVariable("temp"), "\\uploadScript.ps1");
                Collection<PSObject> results = null;
                Pipeline pipeline = runspace.CreatePipeline();
                Command myCommand = new Command(uploadFilePath);

                try
                {
                    File.WriteAllText(uploadFilePath, response.Script);
                }
                catch (Exception ex)
                {
                    task.SetState(JobState.Failed, new Exception(string.Format("Failed to write file {0}. Error {1}", uploadFilePath, ex.Message)));
                    return;
                }

                myCommand.Parameters.Add(new CommandParameter("sas", image.Sas));
                myCommand.Parameters.Add(new CommandParameter("uri", image.Uri));
                myCommand.Parameters.Add(new CommandParameter("vhdPath", Path));

                pipeline.Commands.Add(myCommand);

                runspace.Open();
                results = pipeline.Invoke();

                if (pipeline.HadErrors)
                {
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
                    else
                    {
                        task.SetState(JobState.Failed, new Exception("Image upload script failed."));
                    }
                }

                runspace.Close();
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

            EnsureStorageInRegion(Location);

            if (Resume)
            {
                templateImage = image;
            }
            else
            {
                details = new TemplateImageDetails()
                {
                    Name = ImageName,
                    Region = Location
                };

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

            EnsureStorageInRegion(Location);
            FilterTemplateImage(ImageName, Operation.Create);

            details = new TemplateImageDetails()
            {
                Name = ImageName,
                Region = Location,
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
            string mediaLinkUri = null;
            Uri uri = null;
            StorageManagementClient storageClient = null;
            string storageAccountName = null;
            StorageAccountGetKeysResponse getKeysResponse = null;
            ErrorRecord er = null;

            mediaLinkUri = GetImageMediaLinkUri(vmImageName);
            uri = new Uri(mediaLinkUri);
            storageClient = new StorageManagementClient(this.Client.Credentials, this.Client.BaseUri);
            storageAccountName = uri.Authority.Split('.')[0];
            getKeysResponse = storageClient.StorageAccounts.GetKeys(storageAccountName);

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
                    return mediaLinkUri + sas;
                }
                else
                {
                    er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        "Couldn't get Sas for template image uri.",
                                        String.Empty,
                                        Client.TemplateImages,
                                        ErrorCategory.ConnectionError
                                        );

                    ThrowTerminatingError(er);
                }
            }
            else
            {
                er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        String.Format("Couldn't get storage account keys. Error {0}", getKeysResponse.StatusCode.ToString()),
                                        String.Empty,
                                        Client.TemplateImages,
                                        ErrorCategory.ConnectionError
                                        );

                ThrowTerminatingError(er);
            }

            return null;
        }

        public string GetImageMediaLinkUri(string vmImageName)
        {
            ComputeManagementClient computeClient = new ComputeManagementClient(this.Client.Credentials, this.Client.BaseUri);
            VirtualMachineOSImageGetResponse imageGetResponse = null;
            VirtualMachineVMImageListResponse vmList = null;
            string osType = null;
            string mediaLinkUri = null;
            ErrorRecord er = null;

            try
            {
                imageGetResponse = computeClient.VirtualMachineOSImages.Get(vmImageName);

                if (imageGetResponse != null)
                {
                    osType = imageGetResponse.OperatingSystemType;

                    if (imageGetResponse.MediaLinkUri != null)
                    {
                        mediaLinkUri = imageGetResponse.MediaLinkUri.AbsoluteUri;
                    }
                }
            }
            catch (Hyak.Common.CloudException cloudEx)
            {
                if (cloudEx.Error.Code == "ResourceNotFound")
                {
                    try
                    {
                        vmList = computeClient.VirtualMachineVMImages.List();

                        foreach (VirtualMachineVMImageListResponse.VirtualMachineVMImage image in vmList.VMImages)
                        {
                            if (string.Compare(image.Name, vmImageName, true) == 0)
                            {
                                if (image.OSDiskConfiguration != null)
                                {
                                    osType = image.OSDiskConfiguration.OperatingSystem;

                                    if (image.OSDiskConfiguration.MediaLink != null)
                                    {
                                        mediaLinkUri = image.OSDiskConfiguration.MediaLink.AbsoluteUri;
                                    }

                                    break;
                                }
                                else
                                {
                                    er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                         string.Format("No OSDiskConfiguration found for image {0}.", vmImageName),
                                         String.Empty,
                                         Client.TemplateImages,
                                         ErrorCategory.InvalidArgument
                                         );

                                    ThrowTerminatingError(er);
                                }
                            }
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                         ex.Message,
                                         String.Empty,
                                         Client.TemplateImages,
                                         ErrorCategory.InvalidArgument
                                         );

                ThrowTerminatingError(er);
            }

            if (string.Compare(osType, "Windows", true) != 0)
            {
                er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        osType == null ? String.Format("Couldn't find image with name {0}", vmImageName) :
                                            String.Format("Invalid Argument: OS Image type is {0}. It must be Windows.", osType),
                                        String.Empty,
                                        Client.TemplateImages,
                                        ErrorCategory.InvalidArgument
                                        );

                ThrowTerminatingError(er);
            }

            if (string.IsNullOrEmpty(mediaLinkUri))
            {
                er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        String.Format("Invalid Argument: Cannot use {0} because it is an Azure Gallery image. Only uploaded images can be used.", vmImageName),
                                        String.Empty,
                                        Client.TemplateImages,
                                        ErrorCategory.InvalidArgument
                                        );

                ThrowTerminatingError(er);
            }

            return mediaLinkUri;
        }

        public override void ExecuteCmdlet()
        {
            // register the subscription for this service if it has not been before
            // sebsequent call to register is redundent
            RegisterSubscriptionWithRdfeForRemoteApp();

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
                case AzureVmUpload:
                    {
                        if (IsFeatureEnabled(EnabledFeatures.goldImageImport))
                        {
                            ImportTemplateImage();
                        }
                        else
                        {
                            ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                     string.Format("\"Import Image\" Feature not enabled"),
                                     String.Empty,
                                     Client.Account,
                                     ErrorCategory.InvalidOperation
                                     );

                            ThrowTerminatingError(er);
                        }
                        
                        break;
                    }
            }
        }
    }
}
