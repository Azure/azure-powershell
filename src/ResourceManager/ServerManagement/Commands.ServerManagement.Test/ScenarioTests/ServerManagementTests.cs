// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.ServiceProcess;
    using WindowsAzure.Commands.ScenarioTest;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Azure.Test.HttpRecorder;
    using Xunit;
    using Xunit.Abstractions;
    using ServiceManagemenet.Common.Models;

    public class ServerManagementTests : RMTestBase
    {
        private static string _nodename;
        private static string _nodeusername;
        private static string _location;
        private static Dictionary<int,string> _gatewayNames = new Dictionary<int, string>();
        private static string _sessionId;

        public ServerManagementTests(ITestOutputHelper output) { 
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }
        
        /// <summary>
        /// checks for admin access
        /// </summary>
        public static bool IsAdmin
        {
            get
            {
                try
                {
                    return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
                }
                catch
                {
                }
                return false;
            }
        }

        /// <summary>
        /// Verifies that the gateway service is installed.
        /// </summary>
        public static bool GatewayServiceInstalled
        {
            get
            {
                try
                {
                    // check if the service is installed on this machine.
                    using (var sc = new ServiceController("ServerManagementToolsGateway"))
                    {
                        return true;
                    }
                }
                catch
                {
                }
                return false;
            }
        }


        /// <summary>
        /// the username to use when creating the SMT NODE and Session for that node
        /// </summary>
        public static string NodeUserName
        {
            get
            {
                return _nodeusername ??
                       (_nodeusername =
                           HttpMockServer.GetVariable("SMT_NODE_USERNAME",
                               Environment.GetEnvironmentVariable("SMT_NODE_USERNAME") ?? "gsAdmin"));
            }
        }

        /// <summary>
        ///  The location to use when creating resources.
        /// </summary>
        public static string Location
        {
            get
            {
                return _location ??
                       (_location =
                           HttpMockServer.GetVariable("SMT_TEST_LOCATION",
                               Environment.GetEnvironmentVariable("SMT_TEST_LOCATION") ?? "centralus"));
            }
        }

        /// <summary>
        ///  the gateway name to use when creating the gateway 
        /// </summary>
        public static string GatewayName(int index)
        {
            if (!_gatewayNames.ContainsKey(index))
            {
                _gatewayNames[index] = HttpMockServer.GetVariable("SMT_GATEWAY_" + index,
                    Environment.GetEnvironmentVariable("SMT_GATEWAY_" + index) ??
                    "test_gateway_" + new Random().Next(0, int.MaxValue));
            }
            return _gatewayNames[index];
        }


        /// <summary>
        ///  the session id to use when creating a session
        /// </summary>
        public static string SessionId
        {
            get
            {
                return _sessionId ??
                       (_sessionId = HttpMockServer.GetVariable("SMT_SESSION_ID", Guid.NewGuid().ToString()));
            }
        }

        /// <summary>
        ///  the password to use when connecting to the node
        /// </summary>
        public static string NodePassword
        {
            // does not store actual password; on playback we don't need the real password anyway, we can just use a dummy password
            get { return Environment.GetEnvironmentVariable("SMT_NODE_PASSWORD") ?? "S0meP@sswerd!"; }
        }

        public static bool Recording
        {
            get { return HttpMockServer.Mode == HttpRecorderMode.Record; }
        }

        /// <summary>
        ///  the name of the SMT node to create 
        /// </summary>
        public static string NodeName
        {
            get
            {
                return _nodename ??
                       (_nodename =
                           HttpMockServer.GetVariable("SMT_NODE_NAME",
                               Environment.GetEnvironmentVariable("SMT_NODE_NAME") ?? "saddlebags"));
            }
        }


        [Fact]
        public void TestGateway()
        {
            ServerManagementTestController.NewInstance.RunPsTest("Test-Gateway");
        }

        [Fact]
        public void TestNode()
        {
            ServerManagementTestController.NewInstance.RunPsTest("Test-Node");
        }

        [Fact]
        public void TestSession()
        {
            ServerManagementTestController.NewInstance.RunPsTest("Test-Session");
        }
    }
}