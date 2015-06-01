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

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test.Common
{
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Moq;
    using Moq.Language.Flow;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class MockObject
    {
        public static int SetUpDefaultRemoteAppTemplates(Mock<IRemoteAppManagementClient> clientMock, string imageName, string id)
        {
            TemplateImageListResult response = new TemplateImageListResult()
            {
                RequestId = "122-13342",
                StatusCode = System.Net.HttpStatusCode.Accepted,
            };

            response.RemoteAppTemplateImageList = new List<TemplateImage>()
            {
                new TemplateImage()
                {
                    Name = imageName,
                    Status = TemplateImageStatus.Ready,
                    Id = id,
                    NumberOfLinkedCollections = 2,
                    Type = TemplateImageType.PlatformImage,
                    RegionList = new List<string>(){
                        "West US"
                    }
                },

                new TemplateImage()
                {
                    Name = "a",
                    Status = TemplateImageStatus.Ready,
                    Id = "2222",
                    NumberOfLinkedCollections = 2,
                    Type = TemplateImageType.PlatformImage,
                    RegionList = new List<string>(){
                        "West US"
                    }
                },

                new TemplateImage()
                {
                    Name = "ztestImage",
                    Status = TemplateImageStatus.Ready,
                    Id = "4444",
                    NumberOfLinkedCollections = 2,
                    Type = TemplateImageType.CustomerImage,
                    RegionList = new List<string>(){
                        "West US"
                    }
                },

                new TemplateImage()
                {
                    Name = "atestImage",
                    Status = TemplateImageStatus.Ready,
                    Id = "3333",
                    NumberOfLinkedCollections = 1,
                    Type = TemplateImageType.CustomerImage,
                    RegionList = new List<string>(){
                        "West US"
                    }
                }
            };

            mockTemplates = new List<TemplateImage>();
            foreach (TemplateImage image in response.RemoteAppTemplateImageList)
            {
                TemplateImage mockImage = new TemplateImage()
                {
                    Name = image.Name,
                    Status = image.Status,
                    Id = image.Id,
                    NumberOfLinkedCollections = image.NumberOfLinkedCollections,
                    Type = image.Type,
                    RegionList = image.RegionList
                };
                mockTemplates.Add(mockImage);
            }

            ISetup<IRemoteAppManagementClient, Task<TemplateImageListResult>> Setup = clientMock.Setup(c => c.TemplateImages.ListAsync(It.IsAny<CancellationToken>()));
            Setup.Returns(Task.Factory.StartNew(() => response));

            return mockTemplates.Count;
        }

        public static int SetUpDefaultRemoteAppTemplatesByName(Mock<IRemoteAppManagementClient> clientMock, string imageName)
        {
            TemplateImageResult response = new TemplateImageResult()
            {
                RequestId = "222-1234-9999",
                StatusCode = System.Net.HttpStatusCode.OK,
                TemplateImage = new TemplateImage()
                {
                    Name = imageName,
                    Status = TemplateImageStatus.Ready,
                    Id = "1111",
                    NumberOfLinkedCollections = 2,
                    Type = TemplateImageType.PlatformImage,
                    RegionList = new List<string>(){
                        "West US"
                    }
                }
            };

            mockTemplates = new List<TemplateImage>()
            {
                new TemplateImage()
                {
                    Name = response.TemplateImage.Name,
                    Status = response.TemplateImage.Status,
                    Id = response.TemplateImage.Id,
                    NumberOfLinkedCollections = response.TemplateImage.NumberOfLinkedCollections,
                    Type = response.TemplateImage.Type,
                    RegionList = response.TemplateImage.RegionList
                }
            };

            ISetup<IRemoteAppManagementClient, Task<TemplateImageResult>> Setup = clientMock.Setup(c => c.TemplateImages.GetAsync(It.IsAny<String>(), It.IsAny<CancellationToken>()));
            Setup.Returns(Task.Factory.StartNew(() => response));

            return mockTemplates.Count;
        }

        public static void SetUpDefaultRemoteAppRenameTemplate(Mock<IRemoteAppManagementClient> clientMock, string newName, string id)
        {
            TemplateImageResult response = new TemplateImageResult()
            {
                 StatusCode = System.Net.HttpStatusCode.Accepted,
                 RequestId = "12345",
                 TemplateImage = new TemplateImage()
                 {
                     Id = id,
                     Name = newName,
                     RegionList = new List<string>(){
                        "West US"
                     }
                 }
            };

            mockTemplates = new List<TemplateImage>()
            {
                new TemplateImage()
                {
                    Id = response.TemplateImage.Id,
                    Name = response.TemplateImage.Name,
                    RegionList = response.TemplateImage.RegionList
                }
            };

            ISetup<IRemoteAppManagementClient, Task<TemplateImageResult>> setup = clientMock.Setup(c => c.TemplateImages.SetAsync(It.IsAny<TemplateImageDetails>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return;
        }

        public static void SetUpDefaultRemoteAppRemoveTemplate(Mock<IRemoteAppManagementClient> clientMock, string imageName, string id)
        {
            AzureOperationResponse response = new AzureOperationResponse()
            {
                 RequestId = "12345",
                 StatusCode = System.Net.HttpStatusCode.Accepted
            };

            ISetup<IRemoteAppManagementClient, Task<AzureOperationResponse>> setup = clientMock.Setup(c => c.TemplateImages.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return;
        }

        public static int SetUpDefaultRemoteAppTemplateCreate(Mock<IRemoteAppManagementClient> clientMock, string imageName, string id, string region, string vhdPath)
        {
            const int numberOfTemplatesCreated = 1;

            TemplateImageResult response = new TemplateImageResult()
            {
                RequestId = "1111-33444",
                StatusCode = System.Net.HttpStatusCode.Accepted,
                TemplateImage = new TemplateImage()
                {
                    Name = imageName,
                    Status = TemplateImageStatus.UploadPending,
                    Type = TemplateImageType.PlatformImage,
                    RegionList = new List<string>(){
                        region
                    }
                }
            };

            mockTemplates = new List<TemplateImage>()
            {
                new TemplateImage()
                {
                    Name = response.TemplateImage.Name,
                    Status = response.TemplateImage.Status,
                    Id = response.TemplateImage.Id,
                    NumberOfLinkedCollections = response.TemplateImage.NumberOfLinkedCollections,
                    Type = response.TemplateImage.Type,
                    RegionList = response.TemplateImage.RegionList
                }
            };

            OperationResultWithTrackingId responseWithTrackingId = new OperationResultWithTrackingId()
            {
                RequestId = "2222-1111-33424",
                StatusCode = System.Net.HttpStatusCode.OK
            };

            UploadScriptResult responseUpload = new UploadScriptResult()
            {
                 RequestId = "1111-33333-5",
                 StatusCode = System.Net.HttpStatusCode.OK,
                Script = "$i = 1; foreach ($arg in $Args) { echo \"The $i parameter is $arg\"; $i++ }; return $true", // mock script just prints out arguments 
            };

            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> SetupStorageTemplate = clientMock.Setup(c => c.TemplateImages.EnsureStorageInRegionAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()));
            SetupStorageTemplate.Returns(Task.Factory.StartNew(() => responseWithTrackingId));

            ISetup<IRemoteAppManagementClient, Task<TemplateImageResult>> SetupSetTemplate = clientMock.Setup(c => c.TemplateImages.SetAsync(It.IsAny<TemplateImageDetails>(), It.IsAny<CancellationToken>()));
            SetupSetTemplate.Returns(Task.Factory.StartNew(() => response));

            ISetup<IRemoteAppManagementClient, Task<UploadScriptResult>> SetupUploadTemplate = clientMock.Setup(c => c.TemplateImages.GetUploadScriptAsync(It.IsAny<CancellationToken>()));
            SetupUploadTemplate.Returns(Task.Factory.StartNew(() => responseUpload));

            return numberOfTemplatesCreated;
        }

        public static void SetUpDefaultRemoteAppUploadScriptTemplate(Mock<IRemoteAppManagementClient> clientMock)
        {

            UploadScriptResult response = new UploadScriptResult()
            {
                RequestId = "1111-33333-5",
                StatusCode = System.Net.HttpStatusCode.OK,
                Script = "Write-Output 'Mock Script'"
            };

            mockTemplateScript = new string(response.Script.ToCharArray());

            ISetup<IRemoteAppManagementClient, Task<UploadScriptResult>> SetupUploadTemplate = clientMock.Setup(c => c.TemplateImages.GetUploadScriptAsync(It.IsAny<CancellationToken>()));
            SetupUploadTemplate.Returns(Task.Factory.StartNew(() => response));
        }

        public static bool ContainsExpectedTemplate(IList<TemplateImage> expectedResult, IList<TemplateImage> templateList)
        {
            bool isIdentical = false;
            IList<TemplateImage> actualResult = new List<TemplateImage>(templateList);

            foreach (TemplateImage expected in expectedResult)
            {
                int i = 0;

                while (i < actualResult.Count)
                {
                    bool found = false;
                    TemplateImage actual = actualResult[i];
                    found = expected.Name == actual.Name;
                    found &= expected.Status == actual.Status;
                    found &= expected.Id == actual.Id;
                    found &= expected.NumberOfLinkedCollections == actual.NumberOfLinkedCollections;
                    found &= expected.Type == actual.Type;
                    if (found)
                    {
                        isIdentical = found;
                        break;
                    }

                    i++;
                }

                if (isIdentical && actualResult.Count > 0)
                {
                    actualResult.RemoveAt(i);
                }
                else
                {
                    return false;
                }
            }

            return isIdentical;
        }

        public static bool ContainsExpectedTemplate(List<TemplateImage> expectedResult, TemplateImage operationResult)
        {
            bool isIdentical = false;
            foreach (TemplateImage expected in expectedResult)
            {
                isIdentical = expected.Name == operationResult.Name;
                isIdentical &= expected.Status == operationResult.Status;
                isIdentical &= expected.Id == operationResult.Id;
                isIdentical &= expected.NumberOfLinkedCollections == operationResult.NumberOfLinkedCollections;
                isIdentical &= expected.Type == operationResult.Type;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }

        public static bool ContainsExpectedResult(List<TemplateImageResult> expectedResult, TemplateImageResult operationResult)
        {
            bool isIdentical = false;
            foreach (TemplateImageResult expected in expectedResult)
            {
                isIdentical = expected.RequestId == operationResult.RequestId;
                isIdentical &= expected.StatusCode == operationResult.StatusCode;
                isIdentical &= expected.TemplateImage.Name == operationResult.TemplateImage.Name;
                isIdentical &= expected.TemplateImage.Status == operationResult.TemplateImage.Status;
                isIdentical &= expected.TemplateImage.Id == operationResult.TemplateImage.Id;
                isIdentical &= expected.TemplateImage.NumberOfLinkedCollections == operationResult.TemplateImage.NumberOfLinkedCollections;
                isIdentical &= expected.TemplateImage.Type == operationResult.TemplateImage.Type;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }
    }
}
