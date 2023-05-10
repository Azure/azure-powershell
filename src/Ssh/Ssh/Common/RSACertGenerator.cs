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

namespace Microsoft.Azure.Commands.Ssh
{
    internal class RSACertGenerator
    {
        private const string RsaOpenSshPrefix = "ssh-rsa-cert-v01@openssh.com";

        private string certBytes;
        private string certFileContents;

        public string CertificateContents
        {
            get
            {
                if (string.IsNullOrEmpty(certFileContents))
                {
                    certFileContents = GetContents(certBytes);
                }

                return certFileContents;
            }
        }

        public RSACertGenerator(string certBytes)
        {
            this.certBytes = certBytes;
        }

        private string GetContents(string certBytes)
        {
            return string.Format("{0} {1}", RsaOpenSshPrefix, certBytes);
        }
    }
}
