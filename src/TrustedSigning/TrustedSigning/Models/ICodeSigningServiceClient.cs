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

namespace Microsoft.Azure.Commands.CodeSigning.Models
{
    public interface ICodeSigningServiceClient
    {
        string[] GetCodeSigningEku(string accountName, string profileName, string endpoint);

        string[] GetCodeSigningEku(string metadataPath);

        Stream GetCodeSigningRootCert(string accountName, string profileName, string endpoint);

        Stream GetCodeSigningRootCert(string metadataPath);

        Stream GetCodeSigningCertChain(string accountName, string profileName, string endpoint);

        Stream GetCodeSigningCertChain(string metadataPath);

        void SubmitCIPolicySigning(string accountName, string profileName, string endpoint,
                string unsignedCIFilePath, string signedCIFilePath, string timeStamperUrl);
        void SubmitCIPolicySigning(string metadataPath,
                string unsignedCIFilePath, string signedCIFilePath, string timeStamperUrl);

    }
}
