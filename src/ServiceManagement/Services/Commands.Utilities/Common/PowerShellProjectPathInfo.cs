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

using System.IO;
using Microsoft.WindowsAzure.Commands.Common.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    public class PowerShellProjectPathInfo : CloudProjectPathInfo
    {
        public PowerShellProjectPathInfo(string rootPath) : base(rootPath)
        {
            Definition = Path.Combine(rootPath, Resources.ServiceDefinitionFileName);
            CloudConfiguration = Path.Combine(rootPath, Resources.CloudServiceConfigurationFileName);
            LocalConfiguration = Path.Combine(rootPath, Resources.LocalServiceConfigurationFileName);
            Settings = Path.Combine(rootPath, Resources.SettingsFileName);
            CloudPackage = Path.Combine(rootPath, Resources.CloudPackageFileName);
            LocalPackage = Path.Combine(rootPath, Resources.LocalPackageFileName);
            RolesPath = RootPath;
        }
    }
}