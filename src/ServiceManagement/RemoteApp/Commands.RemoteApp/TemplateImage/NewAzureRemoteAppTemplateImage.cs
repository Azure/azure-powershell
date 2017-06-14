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

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    using Microsoft.WindowsAzure.Commands.RemoteApp;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Management.Automation;
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

        public virtual string DetermineParameterSetName()
        {
            return this.ParameterSetName;
        }

        private LongRunningTask<NewAzureRemoteAppTemplateImage> task = null;

        private void UploadVhd(TemplateImage image)
        {
            UploadScriptResult response = null;
            Collection<PSObject> scriptResult = null;
            string command = null;

            task.SetStatus(Commands_RemoteApp.TemplateImageUploadingStatusMessage);
            response = CallClient_ThrowOnError(() => Client.TemplateImages.GetUploadScript());

            if (response != null && response.Script != null)
            {
                string uploadFilePath = string.Concat(Environment.GetEnvironmentVariable("temp"), "\\uploadScript.ps1");
                try
                {
                    File.WriteAllText(uploadFilePath, response.Script);
                }
                catch (Exception ex)
                {
                    task.SetState(JobState.Failed, new Exception(string.Format(Commands_RemoteApp.FailedToWriteToFileErrorFormat, uploadFilePath, ex.Message)));
                    return;
                }

                command = String.Format("{0} -Uri \"{1}\" -Sas \"{2}\" -VhdPath \"{3}\"", uploadFilePath, image.Uri, image.Sas, Path);

                scriptResult = CallPowershell(command);
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
                task.SetStatus(Commands_RemoteApp.WaitingForStorageVerificationToCompleteMessage);

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
                    throw new RemoteAppServiceException(Commands_RemoteApp.StorageCreationFailedError, ErrorCategory.OperationTimeout);
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
                    throw new RemoteAppServiceException(String.Format(
                        System.Globalization.CultureInfo.InvariantCulture,
                        Commands_RemoteApp.TemplateImageCreationFailedErrorFormat,
                        ImageName,
                        Location)
                        , ErrorCategory.InvalidResult);
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
            StorageCredentials credentials = null;
            SharedAccessBlobPolicy accessPolicy = null;
            CloudPageBlob pageBlob = null;
            string sas = null;

            mediaLinkUri = GetImageUri(vmImageName);
            uri = new Uri(mediaLinkUri);
            storageClient = new StorageManagementClient(this.Client.Credentials, this.Client.BaseUri);
            storageAccountName = uri.Authority.Split('.')[0];
            getKeysResponse = storageClient.StorageAccounts.GetKeys(storageAccountName);

            if (getKeysResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        String.Format(Commands_RemoteApp.GettingStorageAccountKeyErrorFormat, getKeysResponse.StatusCode.ToString()),
                                        String.Empty,
                                        Client.TemplateImages,
                                        ErrorCategory.ConnectionError
                                        );

                ThrowTerminatingError(er);
            }

            credentials = new StorageCredentials(storageAccountName, getKeysResponse.SecondaryKey);
            accessPolicy = new SharedAccessBlobPolicy();
            pageBlob = new CloudPageBlob(uri, credentials);

            accessPolicy.Permissions = SharedAccessBlobPermissions.Read;
            // Sometimes the clocks are 2-3 seconds fast and the SAS is not yet valid when the service tries to use it.
            accessPolicy.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
            accessPolicy.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(12);

            sas = pageBlob.GetSharedAccessSignature(accessPolicy);

            if (sas == null)
            {
                er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                    Commands_RemoteApp.FailedToGetSasUriError,
                                    String.Empty,
                                    Client.TemplateImages,
                                    ErrorCategory.ConnectionError
                                    );

                ThrowTerminatingError(er);
            }

            return mediaLinkUri + sas;
        }

        private void ValidateImageOsType(string osType)
        {
            if (string.Compare(osType, "Windows", true) != 0)
            {
                ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                            String.Format(Commands_RemoteApp.InvalidOsTypeErrorFormat, osType),
                                            String.Empty,
                                            Client.TemplateImages,
                                            ErrorCategory.InvalidArgument
                                            );

                ThrowTerminatingError(er);
            }
        }

        private void ValidateImageMediaLink(Uri mediaLink)
        {
            if (mediaLink == null || string.IsNullOrEmpty(mediaLink.AbsoluteUri))
            {
                ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        Commands_RemoteApp.InvalidVmImageNameSpecifiedError,
                                        String.Empty,
                                        Client.TemplateImages,
                                        ErrorCategory.InvalidArgument
                                        );

                ThrowTerminatingError(er);
            }
        }

        private string GetOsImageUri(string imageName)
        {
            ComputeManagementClient computeClient = new ComputeManagementClient(this.Client.Credentials, this.Client.BaseUri);
            VirtualMachineOSImageGetResponse imageGetResponse = null;
            ErrorRecord er = null;

            try
            {
                imageGetResponse = computeClient.VirtualMachineOSImages.Get(imageName);
            }
            catch (Hyak.Common.CloudException cloudEx)
            {
                // If the image was created in azure with Vm capture, GetOsImageUri won't find that. Don't terminate in this case
                if (cloudEx.Error.Code != "ResourceNotFound")
                {
                    er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                        cloudEx.Message,
                                        String.Empty,
                                        Client.TemplateImages,
                                        ErrorCategory.InvalidArgument
                                        );

                    ThrowTerminatingError(er);
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

            if (imageGetResponse != null)
            {
                ValidateImageOsType(imageGetResponse.OperatingSystemType);
                ValidateImageMediaLink(imageGetResponse.MediaLinkUri);

                return imageGetResponse.MediaLinkUri.AbsoluteUri;
            }
            else
            {
                return null;
            }
        }

        private string GetVmImageUri(string imageName)
        {
            ComputeManagementClient computeClient = new ComputeManagementClient(this.Client.Credentials, this.Client.BaseUri);
            VirtualMachineVMImageListResponse vmList = null;
            ErrorRecord er = null;
            string imageUri = null;

            try
            {
                vmList = computeClient.VirtualMachineVMImages.List();
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

            foreach (VirtualMachineVMImageListResponse.VirtualMachineVMImage image in vmList.VMImages)
            {
                if (string.Compare(image.Name, imageName, true) == 0)
                {
                    if (image.OSDiskConfiguration != null)
                    {
                        ValidateImageOsType(image.OSDiskConfiguration.OperatingSystem);
                        ValidateImageMediaLink(image.OSDiskConfiguration.MediaLink);

                        imageUri = image.OSDiskConfiguration.MediaLink.AbsoluteUri;
                        break;
                    }
                    else
                    {
                        er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                string.Format(Commands_RemoteApp.NoOsDiskFoundErrorFormat, imageName),
                                String.Empty,
                                Client.TemplateImages,
                                ErrorCategory.InvalidArgument
                                );

                        ThrowTerminatingError(er);
                    }
                }
            }

            if (imageUri == null)
            {
                er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                    string.Format(Commands_RemoteApp.NoVmImageFoundErrorFormat, imageName),
                                    String.Empty,
                                    Client.TemplateImages,
                                    ErrorCategory.InvalidArgument
                                    );

                ThrowTerminatingError(er);
            }

            return imageUri;
        }

        private string GetImageUri(string imageName)
        {
            string mediaLinkUri = null;

            // Try to get Uri for uploaded image with given name
            mediaLinkUri = GetOsImageUri(imageName);
            if (mediaLinkUri == null)
            {
                // If the image was created in azure with Vm capture, GetOsImageUri won't find that. Try GetVmImageUri
                mediaLinkUri = GetVmImageUri(imageName);
            }

            return mediaLinkUri;
        }

        public override void ExecuteCmdlet()
        {
            // register the subscription for this service if it has not been before
            // sebsequent call to register is redundent
            RegisterSubscriptionWithRdfeForRemoteApp();

            switch (DetermineParameterSetName())
            {
                case UploadLocalVhd:
                    {
                        string scriptBlock = "Test-Path -Path " + Path;
                        Collection<bool> pathValid = CallPowershellWithReturnType<bool>(scriptBlock);
                        TemplateImage image = null;

                        if (pathValid[0] == false)
                        {
                            throw new RemoteAppServiceException(Commands_RemoteApp.FailedToValidateVhdPathError, ErrorCategory.ObjectNotFound);
                        }

                        task = new LongRunningTask<NewAzureRemoteAppTemplateImage>(this, "RemoteAppTemplateImageUpload", Commands_RemoteApp.UploadTemplateImageJobDescriptionMessage);

                        task.ProcessJob(() =>
                        {
                            image = VerifyPreconditions();
                            image = StartTemplateUpload(image);
                            UploadVhd(image);
                            task.SetStatus(Commands_RemoteApp.JobCompletionStatusMessage);
                        });

                        WriteObject(task);

                        break;
                    }
                case AzureVmUpload:
                    {
                        ImportTemplateImage();
                        break;
                    }
            }
        }
    }
}
