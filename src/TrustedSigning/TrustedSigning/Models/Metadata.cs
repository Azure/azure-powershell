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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CodeSigning.Models
{
    public class Metadata
    {
        public string Endpoint { get; set; }
        public string CodeSigningAccountName { get; set; }
        public string CertificateProfileName { get; set; }
        public List<string> ExcludeCredentials { get; set; } = new List<string>();
        public string AccessToken { get; set; }
    }
}
