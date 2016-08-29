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

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test
{
    using Common;
    using Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Xunit;

    // Get-AzureRemoteAppResetVpnSharedKey, Get-AzureRemoteAppVpnDeviceConfigScript, Reset-AzureRemoteAppVpnSharedKey
    public class NewAzureRemoteAppTemplateImageTest : NewAzureRemoteAppTemplateImage
    {
        /// <summary>
        /// Sets the parameter set name to return
        /// </summary>
        public string ParameterSetOverride { get; set; }

        /// <summary>
        /// Determines the parameter set name based on the <see cref="ParameterSetOverride"/> property
        /// </summary>
        public override string DetermineParameterSetName()
        {
            return this.ParameterSetOverride;
        }
    }

    public class RemoteAppTemplateTest : RemoteAppClientTest
    {
        private string templateId = "1111";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppTemplateImage returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<TemplateImage> templates = MockObject.ConvertList<TemplateImage>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(templates);

            Assert.True(templates.Count == countOfExpectedTemplates,
                String.Format("The expected number of templates returned {0} does not match the actual {1}",
                    countOfExpectedTemplates,
                    templates.Count
                )
            );

            Assert.True(MockObject.ContainsExpectedTemplate(MockObject.mockTemplates, templates),
                "The actual result does not match the expected"
            );
            Log("The test for Get-AzureRemoteAppTemplateImage with {0} templates completed successfully", countOfExpectedTemplates);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppTemplateImage returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<TemplateImage> templates = MockObject.ConvertList<TemplateImage>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(templates);

            Assert.True(templates.Count == countOfExpectedTemplates,
                String.Format("The expected number of templates returned {0} does not match the actual {1}",
                    countOfExpectedTemplates,
                    templates.Count
                )
            );

            Assert.True(MockObject.HasExpectedResults<TemplateImage>(templates, MockObject.ContainsExpectedTemplate),
                 "The actual result does not match the expected"
            );

            Log("The test for Get-AzureRemoteAppTemplateImage with {0} templates completed successfully", countOfExpectedTemplates);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
                Assert.True(false,
                    String.Format("Rename-AzureRemoteAppTemplate returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<TemplateImage> templates = MockObject.ConvertList<TemplateImage>(mockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(templates);

            Assert.True(MockObject.HasExpectedResults<TemplateImage>(templates, MockObject.ContainsExpectedTemplate),
                 "The actual result does not match the expected"
            );

            Log("The test for Rename-AzureRemoteAppTemplate completed successfully");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
                Assert.True(false,
                    String.Format("Remove-AzureRemoteAppTemplate returned the following error {0}",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            Log("The test for Remove-AzureRemoteAppTemplate completed successfully");
        }
    }
}
