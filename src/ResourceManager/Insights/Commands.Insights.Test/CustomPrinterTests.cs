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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Insights.Test
{
    public class CustomPrinterTests
   {
        public CustomPrinterTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CustomPrinterTest_SimpleTypes()
        {
            const int x = 1;
            const double y = 1.2;
            const string s = "hello";
            const bool b = true;
            TimeSpan ts = TimeSpan.FromHours(13);
            DateTime dt = DateTime.Now;
            DateTime dtUtc = DateTime.UtcNow;

            // The following should remove the " : " and the "\r\n" in the future
            Assert.Equal($" : 1{Environment.NewLine}", OutputClasses.CustomPrinter.Print(x));
            Assert.Equal($" : 1.2{Environment.NewLine}", OutputClasses.CustomPrinter.Print(y));
            Assert.Equal($" : hello{Environment.NewLine}", OutputClasses.CustomPrinter.Print(s));
            Assert.Equal($" : True{Environment.NewLine}", OutputClasses.CustomPrinter.Print(b));
            Assert.Equal(" : " + XmlConvert.ToString(ts) + Environment.NewLine, OutputClasses.CustomPrinter.Print(ts));

            // Must be dt.ToUniversalTime().ToString("O")  in the future
            Assert.Equal(" : " + dt + Environment.NewLine, OutputClasses.CustomPrinter.Print(dt));

            // Must be dtUtc.ToString("O") in the future
            Assert.Equal(" : " + dtUtc + Environment.NewLine, OutputClasses.CustomPrinter.Print(dtUtc));

            // Both must be string.Empty in the future
            Assert.Equal($" :{Environment.NewLine}", OutputClasses.CustomPrinter.Print(null));
            Assert.Equal($" : {Environment.NewLine}", OutputClasses.CustomPrinter.Print(""));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CustomPrinterTest_ComplexTypes()
        {
            var stringList = new List<string>();
            var dictionarySS = new Dictionary<string, string>();
            var dictionarySO = new Dictionary<string, object>();
            var eventData = Test.Utilities.CreateFakeEvent(id: null, newDates: false);

            // Must be {} in the future
            Assert.Equal("", OutputClasses.CustomPrinter.Print(stringList));

            // Must be {} in the future
            Assert.Equal("", OutputClasses.CustomPrinter.Print(dictionarySS));

            // Must be {} in the future
            Assert.Equal("", OutputClasses.CustomPrinter.Print(dictionarySO));

            string result = OutputClasses.CustomPrinter.Print(eventData);
            Debug.WriteLine("EventData: ");
            Debug.WriteLine(result);

            var year = "2017";
#if NETSTANDARD
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                year = "17";
            }
#endif

            // Must be [\r\nAuthorization        : [\r\n                       Action : PUT\r\n                       Role   : Sender\r\n                       Scope  : None\r\n                       ]\r\nClaims               : {\r\n                       [aud, https://management.core.windows.net/]\r\n                       [iss, https://sts.windows.net/123456/]\r\n                       [iat, h123445]\r\n                       }\r\nCaller               : caller\r\nDescription          : fake event\r\nId                   : ac7d2ab5-698a-4c33-9c19-0a93d3d7f527\r\nEventDataId          : \r\nCorrelationId        : correlation\r\nEventName            : [\r\n                       Value          : Start request\r\n                       LocalizedValue : Start request\r\n                       ]\r\nCategory             : [\r\n                       Value          : Microsoft Resources\r\n                       LocalizedValue : Microsoft Resources\r\n                       ]\r\nHttpRequest          : [\r\n                       ClientRequestId : 1234\r\n                       ClientIpAddress : 123.123.123.123\r\n                       Method          : PUT\r\n                       Uri             : http://path/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy\r\n                       ]\r\nLevel                : Informational\r\nResourceGroupName    : Default-Web-EastUS\r\nResourceProviderName : [\r\n                       Value          : Microsoft Resources\r\n                       LocalizedValue : Microsoft Resources\r\n                       ]\r\nResourceId           : /subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/garyyang1\r\nResourceType         : \r\nOperationId          : c0f2e85f-efb0-47d0-bf90-f983ec8be91d\r\nOperationName        : [\r\n                       Value          : Microsoft.Resources/subscriptions/resourcegroups/deployments/write\r\n                       LocalizedValue : Microsoft.Resources/subscriptions/resourcegroups/deployments/write\r\n                       ]\r\nProperties           : {}\r\nStatus               : [\r\n                       Value          : Succeeded\r\n                       LocalizedValue : Succeeded\r\n                       ]\r\nSubStatus            : [\r\n                       Value          : Created\r\n                       LocalizedValue : Created\r\n                       ]\r\nEventTimestamp       : 2017-06-07T22:54:00.0000000Z\r\nSubmissionTimestamp  : 2017-06-07T22:54:00.0000000Z\r\nSubscriptionId       : \r\nTenantId             : \r\n] in the future
            Assert.Equal(
                expected: $"Authorization       {Environment.NewLine}Action : PUT{Environment.NewLine}Role   : Sender{Environment.NewLine}Scope  : None{Environment.NewLine}{Environment.NewLine}Claims              {Environment.NewLine}     : [aud, https://management.core.windows.net/]{Environment.NewLine}     : [iss, https://sts.windows.net/123456/]{Environment.NewLine}     : [iat, h123445]{Environment.NewLine}Caller               : caller{Environment.NewLine}Description          : fake event{Environment.NewLine}Id                   : ac7d2ab5-698a-4c33-9c19-0a93d3d7f527{Environment.NewLine}EventDataId          :{Environment.NewLine}CorrelationId        : correlation{Environment.NewLine}EventName           {Environment.NewLine}Value          : Start request{Environment.NewLine}LocalizedValue : Start request{Environment.NewLine}{Environment.NewLine}Category            {Environment.NewLine}Value          : Microsoft Resources{Environment.NewLine}LocalizedValue : Microsoft Resources{Environment.NewLine}{Environment.NewLine}HttpRequest         {Environment.NewLine}ClientRequestId : 1234{Environment.NewLine}ClientIpAddress : 123.123.123.123{Environment.NewLine}Method          : PUT{Environment.NewLine}Uri             : http://path/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy{Environment.NewLine}{Environment.NewLine}Level                : Informational{Environment.NewLine}ResourceGroupName    : Default-Web-EastUS{Environment.NewLine}ResourceProviderName{Environment.NewLine}Value          : Microsoft Resources{Environment.NewLine}LocalizedValue : Microsoft Resources{Environment.NewLine}{Environment.NewLine}ResourceId           : /subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/garyyang1{Environment.NewLine}ResourceType         :{Environment.NewLine}OperationId          : c0f2e85f-efb0-47d0-bf90-f983ec8be91d{Environment.NewLine}OperationName       {Environment.NewLine}Value          : Microsoft.Resources/subscriptions/resourcegroups/deployments/write{Environment.NewLine}LocalizedValue : Microsoft.Resources/subscriptions/resourcegroups/deployments/write{Environment.NewLine}{Environment.NewLine}Properties          {Environment.NewLine}Status              {Environment.NewLine}Value          : Succeeded{Environment.NewLine}LocalizedValue : Succeeded{Environment.NewLine}{Environment.NewLine}SubStatus           {Environment.NewLine}Value          : Created{Environment.NewLine}LocalizedValue : Created{Environment.NewLine}{Environment.NewLine}EventTimestamp       : 6/7/{year} 10:54:00 PM{Environment.NewLine}SubmissionTimestamp  : 6/7/{year} 10:54:00 PM{Environment.NewLine}SubscriptionId       :{Environment.NewLine}TenantId             :{Environment.NewLine}{Environment.NewLine}", 
                actual: result);

            dictionarySS.Add("k1", "v1");
            dictionarySS.Add("k2", "v2");
            result = OutputClasses.CustomPrinter.Print(dictionarySS);
            Debug.WriteLine("Dictionary<string, string>: ");
            Debug.WriteLine(result);

            // Must be "{\r\n[k1, v1]\r\n[k2, v2]\r\n}" in the future
            Assert.Equal(
                expected: $"     : [k1, v1]{Environment.NewLine}     : [k2, v2]{Environment.NewLine}",
                actual: result);

            dictionarySO.Add("k1", eventData);
            dictionarySO.Add("k2", Test.Utilities.CreateFakeEvent(id: "secondId", newDates: false));
            result = OutputClasses.CustomPrinter.Print(dictionarySO);
            Debug.WriteLine("Dictionary<string, object>: ");
            Debug.WriteLine(result);
            // Must be "{\r\n[k1, Microsoft.Azure.Management.Monitor.Models.EventData]\r\n[k2, Microsoft.Azure.Management.Monitor.Models.EventData]\r\n}" in the future
            Assert.Equal(
                expected: $"     : [k1, Microsoft.Azure.Management.Monitor.Models.EventData]{Environment.NewLine}     : [k2, Microsoft.Azure.Management.Monitor.Models.EventData]{Environment.NewLine}",
                actual: result);
        }
    }
}

