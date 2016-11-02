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
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.VisualStudio.EtwListener.Common
{
    /// <summary>
    /// Simple certificate validator which validates the thumbprint
    /// </summary>
    internal class CertificateValidator : X509CertificateValidator
    {
        private string allowedThumbprint;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="allowedThumbprint">Thumbprint this validator will validate</param>
        public CertificateValidator(string allowedThumbprint)
        {
            this.allowedThumbprint = allowedThumbprint;
        }

        /// <summary>
        /// Validates an X.509 certificate.
        /// </summary>
        /// <param name="certificate">The certificate to validate</param>
        public override void Validate(X509Certificate2 certificate)
        {
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate cannot be null.");
            }

            if (!string.Equals(certificate.Thumbprint, this.allowedThumbprint, StringComparison.OrdinalIgnoreCase))
            {
                throw new SecurityTokenValidationException("Invalid certificate.");
            }
        }
    }
}
