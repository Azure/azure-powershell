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

namespace Microsoft.Azure.Commands.Resources.Models.ActiveDirectory
{
    public class CreatePSApplicationParameters
    {
        public string DisplayName { get; set; }

        public string HomePage { get; set; }

        public string[] IdentifierUris { get; set; }

        public string[] ReplyUrls { get; set; }

        public bool AvailableToOtherTenants { get; set; }

        public PSADKeyCredential[] KeyCredentials { get; set; }

        public PSADPasswordCredential[] PasswordCredentials { get; set; }
    }
}
