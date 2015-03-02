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

namespace Microsoft.Azure.Commands.Test.RemoteApp
{
    using Common;
    using Microsoft.Azure.Management.RemoteApp.Cmdlets;
    using Microsoft.Azure.Management.RemoteApp.Models;
    using System;
    using System.Collections.Generic;
    using VisualStudio.TestTools.UnitTesting;

    // Get-AzureRemoteAppResetVpnSharedKey, Get-AzureRemoteAppVpnDeviceConfigScript, Reset-AzureRemoteAppVpnSharedKey
    [TestClass]
    public class RemoteAppTemplateTest : RemoteAppClientTest
    {
        private string templateId = "1111";

        [TestMethod]
        [Ignore]
        public void GetAllTemplates()
        {
            int countOfExpectedTemplates = 0;
            GetAzureRemoteAppTemplateImage mockCmdlet = SetUpTestCommon<GetAzureRemoteAppTemplateImage>();

            // Setup the environment for testing this cmdlet
            countOfExpectedTemplates = MockObject.SetUpDefaultRemoteAppTemplates(remoteAppManagementClientMock, templateName, templateId);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppTemplateImage which should have {0} templates", countOfExpectedTemplates);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppTemplateImage returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<TemplateImage> templates = MockObject.ConvertList<TemplateImage>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(templates);

            Assert.IsTrue(templates.Count == countOfExpectedTemplates,
                String.Format("The expected number of templates returned {0} does not match the actual {1}",
                    countOfExpectedTemplates,
                    templates.Count
                )
            );

            Assert.IsTrue(MockObject.ContainsExpectedTemplate(MockObject.mockTemplates, templates),
                "The actual result does not match the expected"
            );
            Log("The test for Get-AzureRemoteAppTemplateImage with {0} templates completed successfully", countOfExpectedTemplates);
        }

        [TestMethod]
        public void GetTemplatesByName()
        {
            int countOfExpectedTemplates = 0;
            GetAzureRemoteAppTemplateImage mockCmdlet = SetUpTestCommon<GetAzureRemoteAppTemplateImage>();

            // Required parameters for this test
            mockCmdlet.ImageName = templateName;

            // Setup the environment for testing this cmdlet
            countOfExpectedTemplates = MockObject.SetUpDefaultRemoteAppTemplatesByName(remoteAppManagementClientMock, mockCmdlet.ImageName);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppTemplateImage which should have {0} templates", countOfExpectedTemplates);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppTemplateImage returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<TemplateImage> templates = MockObject.ConvertList<TemplateImage>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(templates);

            Assert.IsTrue(templates.Count == countOfExpectedTemplates,
                String.Format("The expected number of templates returned {0} does not match the actual {1}",
                    countOfExpectedTemplates,
                    templates.Count
                )
            );

            Assert.IsTrue(MockObject.HasExpectedResults<TemplateImage>(templates, MockObject.ContainsExpectedTemplate),
                 "The actual result does not match the expected"
            );

            Log("The test for Get-AzureRemoteAppTemplateImage with {0} templates completed successfully", countOfExpectedTemplates);
        }

        [TestMethod]
        [Ignore]
        public void AddTemplate()
        {
            int countOfExpectedTemplates = 0;
            NewAzureRemoteAppTemplateImage mockCmdlet = SetUpTestCommon<NewAzureRemoteAppTemplateImage>();


            // Required parameters for this test
            mockCmdlet.ImageName = templateName;
            mockCmdlet.Location = region;
            mockCmdlet.Path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;  // Need to specify a valid file otherwise the validation for this parameter will fail

            // Setup the environment for testing this cmdlet
            countOfExpectedTemplates = MockObject.SetUpDefaultRemoteAppTemplateCreate(remoteAppManagementClientMock, mockCmdlet.ImageName, templateId, mockCmdlet.Location, mockCmdlet.Path);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("New-AzureRemoteAppTemplate returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<TemplateImageResult> imageResults = MockObject.ConvertList<TemplateImageResult>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(imageResults);

            Assert.IsTrue(imageResults.Count == countOfExpectedTemplates,
                String.Format("The expected number of templates returned {0} does not match the actual {1}",
                    countOfExpectedTemplates,
                    imageResults.Count
                 )
            );

            Assert.IsTrue(MockObject.HasExpectedResults<TemplateImageResult>(imageResults, MockObject.ContainsExpectedResult),
                 "The actual result does not match the expected"
            );

            Log("The test for New-AzureRemoteAppTemplate completed successfully");
        }


        [TestMethod]
        public void RenameTemplate()
        {
            RenameAzureRemoteAppTemplateImage mockCmdlet = SetUpTestCommon<RenameAzureRemoteAppTemplateImage>();

            // Required parameters for this test
            mockCmdlet.ImageName = templateName;
            mockCmdlet.NewName = "UpdatedTemplateImage";

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppTemplates(remoteAppManagementClientMock, mockCmdlet.ImageName, templateId);
            MockObject.SetUpDefaultRemoteAppRenameTemplate(remoteAppManagementClientMock, mockCmdlet.NewName, templateId);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Rename-AzureRemoteAppTemplate returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<TemplateImage> templates = MockObject.ConvertList<TemplateImage>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(templates);

            Assert.IsTrue(MockObject.HasExpectedResults<TemplateImage>(templates, MockObject.ContainsExpectedTemplate),
                 "The actual result does not match the expected"
            );

            Log("The test for Rename-AzureRemoteAppTemplate completed successfully");
        }

        [TestMethod]
        public void RemoveTemplate()
        {
            RemoveAzureRemoteAppTemplateImage mockCmdlet = SetUpTestCommon<RemoveAzureRemoteAppTemplateImage>();

            // Required parameters for this test
            mockCmdlet.ImageName = templateName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppTemplates(remoteAppManagementClientMock, mockCmdlet.ImageName, templateId);
            MockObject.SetUpDefaultRemoteAppRemoveTemplate(remoteAppManagementClientMock, mockCmdlet.ImageName, templateId);
            mockCmdlet.ResetPipelines();

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Remove-AzureRemoteAppTemplate returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            Log("The test for Remove-AzureRemoteAppTemplate completed successfully");
        }
    }
}
