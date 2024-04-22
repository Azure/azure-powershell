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

using Microsoft.Azure.KeyVault.Models;

using System;

using Track2Sdk = Azure.Security.KeyVault.Certificates;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultCertificateOperation
    {
        public string Id { get; private set; }
        public string Status { get; private set; }
        public string StatusDetails { get; private set; }
        public string RequestId { get; private set; }
        public string Target { get; private set; }
        public string Issuer { get; private set; }
        public bool? CancellationRequested { get; private set; }
        public string CertificateSigningRequest { get; private set; }
        public string ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public string Name { get; set; }
        public string VaultName { get; set; }

        public PSKeyVaultCertificateOperation(){}

        internal PSKeyVaultCertificateOperation(Track2Sdk.CertificateOperation certificateOperation)
        {
            if (certificateOperation == null) return;

            Id = certificateOperation.Id;
            Status = certificateOperation.Properties?.Status;
            StatusDetails = certificateOperation.Properties?.StatusDetails;
            RequestId = certificateOperation.Properties.RequestId;
            Target = certificateOperation.Properties?.Target;
            Issuer = certificateOperation.Properties?.IssuerName;
            CancellationRequested = certificateOperation.Properties?.CancellationRequested;

            if (certificateOperation.Properties?.Csr != null && certificateOperation.Properties?.Csr?.Length != 0)
            {
                CertificateSigningRequest = Convert.ToBase64String(certificateOperation.Properties?.Csr);
            }

            if (certificateOperation.Properties?.Error != null)
            {
                ErrorCode = certificateOperation.Properties?.Error.Code;
                ErrorMessage = certificateOperation.Properties?.Error.Message;
            }
        }

        internal PSKeyVaultCertificateOperation(CertificateOperation certificateOperation)
        {
            if (certificateOperation == null) return;

            Id = certificateOperation.Id;
            Status = certificateOperation.Status;
            StatusDetails = certificateOperation.StatusDetails;
            RequestId = certificateOperation.RequestId;
            Target = certificateOperation.Target;
            Issuer = certificateOperation.IssuerParameters.Name;
            CancellationRequested = certificateOperation.CancellationRequested;

            if (certificateOperation.Csr != null && certificateOperation.Csr.Length != 0)
            {
                CertificateSigningRequest = Convert.ToBase64String(certificateOperation.Csr);
            }

            if (certificateOperation.Error != null)
            {
                ErrorCode = certificateOperation.Error.Code;
                ErrorMessage = certificateOperation.Error.Message;
            }
        }

        internal static PSKeyVaultCertificateOperation FromCertificateOperation(CertificateOperation certificateOperation)
        {
            return new PSKeyVaultCertificateOperation(certificateOperation);
        }
    }
}
