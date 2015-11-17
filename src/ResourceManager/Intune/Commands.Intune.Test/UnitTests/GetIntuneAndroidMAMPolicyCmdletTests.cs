using System;
using System.Management.Automation;
using Microsoft.Azure.Management.Intune.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Rest.Azure;
using Moq;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Intune.Test
{  
    public class GetIntuneAndroidMAMPolicyCmdletTests
    {
        private Mock<IIntuneResourceManagementClientWrapper> intuneClientWrapperMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private GetIntuneAndroidMAMPolicyCmdlet cmdlet;
        private Location mockLocation;

        public GetIntuneAndroidMAMPolicyCmdletTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientWrapperMock = new Mock<IIntuneResourceManagementClientWrapper>();

            cmdlet = new GetIntuneAndroidMAMPolicyCmdlet();
            this.cmdlet.CommandRuntime = commandRuntimeMock.Object;
            this.cmdlet.IntuneClientWrapper = intuneClientWrapperMock.Object;

            // Set-up mock Location and mock the underlying service API method
            mockLocation = new Location() { HostName = "mockHostName" };
            intuneClientWrapperMock.Setup(f => f.GetLocationByHostName())
                .Returns(mockLocation);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAndroidPolicies_ReturnsNoItem_Test()
        {
            // Set up the expected Policy
            IPage<AndroidMAMPolicy> expectedResultPage = new Page<AndroidMAMPolicy>();
            
            AndroidMAMPolicy expectedMAMPolicy = new AndroidMAMPolicy()
            {
                FriendlyName = "expectedPolicyFriendlyName",
                OfflineWipeTimeout = TimeSpan.FromDays(100),
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(2),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(3),
            };
            
            // Set up the mock methods
            intuneClientWrapperMock.Setup(f => f.GetAndroidMAMPolicies(mockLocation.HostName, null, null, null))
                .Returns(expectedResultPage);

            intuneClientWrapperMock.Setup(f => f.GetAndroidMAMPoliciesNext(null))
              .Returns(expectedResultPage);

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and Execute the cmdlet
            this.cmdlet.ExecuteCmdlet();

            // Verify the result
            commandRuntimeMock.Verify(f => f.WriteObject("0 items returned"), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAndroidPolicies_ReturnsValidItem_Test()
        {
            // Set up the expected Policy
            string expectedPolicy = "{\r\n  \"value\": [\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/androidPolicies/05207a60-6afd-4fd0-a8a8-e4e54bc11aa5\",\r\n      \"name\": \"05207a60-6afd-4fd0-a8a8-e4e54bc11aa5\",\r\n      \"type\": \"Microsoft.Intune/locations/androidPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneAndroidPolicy4872\",\r\n        \"description\": \"New Android Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:29:48.0885169\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/androidPolicies/0f85f3de-172b-4867-9c8c-61dcf8798515\",\r\n      \"name\": \"0f85f3de-172b-4867-9c8c-61dcf8798515\",\r\n      \"type\": \"Microsoft.Intune/locations/androidPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneAndroidPolicy542\",\r\n        \"description\": \"New Android Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:30:56.7433738\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/androidPolicies/1e5326cd-1d14-45df-a2b6-217e89a51b84\",\r\n      \"name\": \"1e5326cd-1d14-45df-a2b6-217e89a51b84\",\r\n      \"type\": \"Microsoft.Intune/locations/androidPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneAndroidPolicy2587\",\r\n        \"description\": \"New Android Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:29:50.5728801\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/androidPolicies/485cacb6-4c14-4530-b9eb-319f380201de\",\r\n      \"name\": \"485cacb6-4c14-4530-b9eb-319f380201de\",\r\n      \"type\": \"Microsoft.Intune/locations/androidPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneAndroidPolicy3818\",\r\n        \"description\": \"New Android Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:31:02.853748\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/androidPolicies/ab511ef4-fae7-4b88-8de1-ebfe8b89775c\",\r\n      \"name\": \"ab511ef4-fae7-4b88-8de1-ebfe8b89775c\",\r\n      \"type\": \"Microsoft.Intune/locations/androidPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneAndroidPolicy3156\",\r\n        \"description\": \"New Android Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T20:11:28.8676537\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/androidPolicies/b4a51113-0c80-48f8-a1ec-f18ebff0a4b0\",\r\n      \"name\": \"b4a51113-0c80-48f8-a1ec-f18ebff0a4b0\",\r\n      \"type\": \"Microsoft.Intune/locations/androidPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneAndroidPolicy8044\",\r\n        \"description\": \"New Android Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T23:53:00.7365543\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.dmsua01/androidPolicies/e3059837-8d02-4dbd-a166-4c620950db3a\",\r\n      \"name\": \"e3059837-8d02-4dbd-a166-4c620950db3a\",\r\n      \"type\": \"Microsoft.Intune/locations/androidPolicies\",\r\n      \"properties\": {\r\n        \"screenCapture\": \"allow\",\r\n        \"fileEncryption\": \"required\",\r\n        \"friendlyName\": \"IntuneAndroidPolicy67\",\r\n        \"description\": \"New Android Policy\",\r\n        \"accessRecheckOfflineTimeout\": \"P0DT12H00M\",\r\n        \"accessRecheckOnlineTimeout\": \"P0DT00H30M\",\r\n        \"appSharingFromLevel\": \"none\",\r\n        \"appSharingToLevel\": \"none\",\r\n        \"authentication\": \"required\",\r\n        \"clipboardSharingLevel\": \"blocked\",\r\n        \"dataBackup\": \"allow\",\r\n        \"deviceCompliance\": \"enable\",\r\n        \"managedBrowser\": \"required\",\r\n        \"fileSharingSaveAs\": \"allow\",\r\n        \"offlineWipeTimeout\": \"P1D\",\r\n        \"pin\": \"required\",\r\n        \"pinNumRetry\": 15,\r\n        \"numOfApps\": 0,\r\n        \"groupStatus\": \"notTargeted\",\r\n        \"lastModifiedTime\": \"2015-11-12T23:53:01.1428402\"\r\n      }\r\n    }\r\n  ]\r\n}";
            IPage<AndroidMAMPolicy> expectedResultPage = new Page<AndroidMAMPolicy>();
            expectedResultPage = JsonConvert.DeserializeObject<Page<AndroidMAMPolicy>>(expectedPolicy, intuneClientWrapperMock.Object.GetDeserializationSettings());

            intuneClientWrapperMock.Setup(f => f.GetAndroidMAMPolicies(mockLocation.HostName, null, null, null))
                .Returns(expectedResultPage);

            intuneClientWrapperMock.Setup(f => f.GetAndroidMAMPoliciesNext("nextLink"))
              .Returns(expectedResultPage);

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            this.cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(expectedResultPage, true), Times.Once());
        }
    }
}