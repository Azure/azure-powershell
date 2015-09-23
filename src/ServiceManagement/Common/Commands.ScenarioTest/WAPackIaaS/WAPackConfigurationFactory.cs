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

using System.Management.Automation;
using System.Security;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    public class WAPackConfigurationFactory
    {
        // --------Template----------
        // For New-WAPackVM & Get-WAPackVMOSDisk
        public const string Win7_64TemplateName = "template_Windows7_x64";
        public const string LinuxUbuntu_64TemplateName = "template_linux_ubuntu_x64";
        public const int TotalTemplateCount = 7;

        // --------OSDisk----------
        // For Get-WAPackVMRole
        public const string LinuxOSVirtualHardDiskImage = "ubun12v4x64_NA_40G.vhdx:1.0.0.0";
        // For New-WAPackVM
        public const string BlankOSDiskName = "Blank Disk - Small.vhdx";
        // For New-WAPackVM & Get-WAPackVMOSDisk
        public const string Ws2k8R2OSDiskName = "st-ws2k8r2entx64-net4.vhdx";
        public const string LinuxOSDiskName = "ubun12v4x64_NA_40G.vhdx";
        
        public const int TotalOSDiskCount = 9;

        // --------VMSizeProfile----------
        // For New-WAPackVM & Get-WAPackVMOSDisk
        public const string VMSizeProfileName = "hwp_staticIP";
        public const int TotalVMSizeProfileCount = 3;

        // --------VNet----------
        // For New-WAPackVM & Get-WAPackVMOSDisk
        public const string AvenzVnetName = "AvezLNVMNetwork";
        public const string ExternalVnetName = "EXTERNAL";
        public const int TotalVnetCount = 5;

        // --------LogicalNetwork----------
        public const string AvezLogicalNetworkName = "AvezLN";

        public const string userName = "SomeTestUser";
        public const string password = "SomeTestPassword";


        public static SecureString securePassword = ConvertToSecureString(password);
        public static PSCredential WindowsVMCredential = new PSCredential(userName, securePassword);
        public static PSCredential LinuxVMCredential = new PSCredential("root", securePassword);
        public const string vmNameToCreate = "TestWindowsVM_VMFromTemplate5";


        private static SecureString ConvertToSecureString(string value)
        {
            SecureString secureString = new SecureString();
            foreach (char c in value.ToCharArray())
            {
                secureString.AppendChar(c);
            }

            return secureString;
        }
    }
}
