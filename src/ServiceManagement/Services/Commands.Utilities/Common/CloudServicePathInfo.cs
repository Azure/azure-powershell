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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService
{
    public abstract class CloudProjectPathInfo
    {
        public string Definition { get; protected set; }

        public string CloudConfiguration { get; protected set; }
        
        public string LocalConfiguration { get; protected set; }
        
        public string Settings { get; protected set; }
        
        public string CloudPackage { get; protected set; }
        
        public string LocalPackage { get; protected set; }
        
        public string RootPath { get; protected set; }

        public string RolesPath { get; protected set; }

        public CloudProjectPathInfo(string rootPath)
        {
            Validate.ValidateStringIsNullOrEmpty(rootPath, "rootPath");
            Validate.ValidatePathName(rootPath, Resources.InvalidRootNameMessage);

            RootPath = rootPath;
        }
    }
}
