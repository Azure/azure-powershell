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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSSearchAdminKey
    {
        [Ps1Xml(Label = "Primary", Target = ViewControl.Table)]
        public string Primary { get; private set; }

        [Ps1Xml(Label = "Secondary", Target = ViewControl.Table)]
        public string Secondary { get; private set; }

        public PSSearchAdminKey(AdminKeyResult adminKeyResult)
        {
            Primary = adminKeyResult.PrimaryKey;
            Secondary = adminKeyResult.SecondaryKey;
        }

        public static PSSearchAdminKey Create(AdminKeyResult adminKeyResult)
        {
            return new PSSearchAdminKey(adminKeyResult);
        }
    }
}
