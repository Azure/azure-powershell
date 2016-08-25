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
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Intune;
using Microsoft.Azure.Management.Intune.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Intune.Test
{
    /// <summary>
    ///  Unit Tests for the GetIntuneAndroidMAMPolicy Cmdlet.
    /// </summary>
    public class GetIntuneAndroidMAMPolicyCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private GetIntuneAndroidMAMPolicyCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for GetIntuneAndroidMAMPolicyCmdletTests class.
        /// </summary>
        public GetIntuneAndroidMAMPolicyCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new GetIntuneAndroidMAMPolicyCmdlet();
            this.cmdlet.CommandRuntime = commandRuntimeMock.Object;
            this.cmdlet.IntuneClient = intuneClientMock.Object;

            // Set-up mock Location and mock the underlying service API method       
            AzureOperationResponse<Location> resLocation = new AzureOperationResponse<Location>();
            expectedLocation = new Location("mockHostName");
            resLocation.Body = expectedLocation;

            intuneClientMock.Setup(f => f.GetLocationByHostNameWithHttpMessagesAsync(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(resLocation));
        }

        /// <summary>
        /// Test to return valid item.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAndroidPolicies_ReturnsValidItem_Test()
        {
            // Set up the expected Policy            
            string expectedPolicyResBody = "{\r\n  \"value\": [\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/05207a60-6afd-4fd0-a8a8-e4e54bc11aa5\",\r\n      \"name\": \"05207a60-6afd-4fd0-a8a8-e4e54bc11aa5\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy4872\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:29:48.0885169\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/0f85f3de-172b-4867-9c8c-61dcf8798515\",\r\n      \"name\": \"0f85f3de-172b-4867-9c8c-61dcf8798515\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy542\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:30:56.7433738\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/1e5326cd-1d14-45df-a2b6-217e89a51b84\",\r\n      \"name\": \"1e5326cd-1d14-45df-a2b6-217e89a51b84\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy2587\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:29:50.5728801\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/485cacb6-4c14-4530-b9eb-319f380201de\",\r\n      \"name\": \"485cacb6-4c14-4530-b9eb-319f380201de\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy3818\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:31:02.853748\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/ab511ef4-fae7-4b88-8de1-ebfe8b89775c\",\r\n      \"name\": \"ab511ef4-fae7-4b88-8de1-ebfe8b89775c\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy3156\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:11:28.8676537\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/b4a51113-0c80-48f8-a1ec-f18ebff0a4b0\",\r\n      \"name\": \"b4a51113-0c80-48f8-a1ec-f18ebff0a4b0\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy8044\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T23:53:00.7365543\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/e3059837-8d02-4dbd-a166-4c620950db3a\",\r\n      \"name\": \"e3059837-8d02-4dbd-a166-4c620950db3a\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy67\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T23:53:01.1428402\"\r\n      }\r\n    }\r\n  ]\r\n}";

            var expectedRespose = new AzureOperationResponse<IPage<AndroidMAMPolicy>>();
            var expectedResultPage = new Page<AndroidMAMPolicy>();
            
            expectedResultPage = JsonConvert.DeserializeObject<Page<AndroidMAMPolicy>>(expectedPolicyResBody, intuneClientMock.Object.DeserializationSettings);

            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.Android.GetMAMPoliciesWithHttpMessagesAsync(
                    expectedLocation.HostName, 
                    It.IsAny<string>(), 
                    It.IsAny<int?>(), 
                    It.IsAny<string>(), 
                    It.IsAny<Dictionary<string, List<string>>>(), 
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.Android.GetMAMPoliciesNextWithHttpMessagesAsync(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and execute the cmdlet
            this.cmdlet.ExecuteCmdlet();

            // Verify the result
            commandRuntimeMock.Verify(f => f.WriteObject(expectedResultPage, true), Times.Once());
        }
       
        /// <summary>
        /// Test to return 0 item.
        /// </summary>   
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAndroidPolicies_ReturnsNoItem_Test()
        {
            // Set up the expected Policy
            string expectedPolicyResBody = "{\r\n  \"value\": [\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/05207a60-6afd-4fd0-a8a8-e4e54bc11aa5\",\r\n      \"name\": \"05207a60-6afd-4fd0-a8a8-e4e54bc11aa5\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy4872\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:29:48.0885169\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/0f85f3de-172b-4867-9c8c-61dcf8798515\",\r\n      \"name\": \"0f85f3de-172b-4867-9c8c-61dcf8798515\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy542\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:30:56.7433738\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/1e5326cd-1d14-45df-a2b6-217e89a51b84\",\r\n      \"name\": \"1e5326cd-1d14-45df-a2b6-217e89a51b84\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy2587\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:29:50.5728801\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/485cacb6-4c14-4530-b9eb-319f380201de\",\r\n      \"name\": \"485cacb6-4c14-4530-b9eb-319f380201de\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy3818\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:31:02.853748\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/ab511ef4-fae7-4b88-8de1-ebfe8b89775c\",\r\n      \"name\": \"ab511ef4-fae7-4b88-8de1-ebfe8b89775c\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy3156\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:11:28.8676537\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/b4a51113-0c80-48f8-a1ec-f18ebff0a4b0\",\r\n      \"name\": \"b4a51113-0c80-48f8-a1ec-f18ebff0a4b0\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy8044\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T23:53:00.7365543\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/IosPolicies/e3059837-8d02-4dbd-a166-4c620950db3a\",\r\n      \"name\": \"e3059837-8d02-4dbd-a166-4c620950db3a\",\r\n      \"type\": \"Microsoft.Intune/locations/IosPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneIosPolicy67\",\r\n        \"description\": \"New Ios Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T23:53:01.1428402\"\r\n      }\r\n    }\r\n  ]\r\n}";

            var expectedRespose = new AzureOperationResponse<IPage<AndroidMAMPolicy>>();

            IPage<AndroidMAMPolicy> expectedResultPage = new Page<AndroidMAMPolicy>();
            expectedResultPage = JsonConvert.DeserializeObject<Page<AndroidMAMPolicy>>(expectedPolicyResBody, intuneClientMock.Object.DeserializationSettings);

            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.Android.GetMAMPoliciesWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    It.IsAny<string>(),
                    It.IsAny<int?>(),
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.Android.GetMAMPoliciesNextWithHttpMessagesAsync(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and execute the cmdlet
            this.cmdlet.ExecuteCmdlet();

            // Verify the result
            commandRuntimeMock.Verify(f => f.WriteObject(expectedResultPage, true), Times.Once());
        }
    }
}