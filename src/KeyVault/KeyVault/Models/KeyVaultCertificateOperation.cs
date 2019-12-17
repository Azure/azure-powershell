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

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultCertificateOperation
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

        internal static KeyVaultCertificateOperation FromCertificateOperation(CertificateOperation certificateOperation)
        {
            if (certificateOperation == null)
            {
                return null;
            }

            var kvCertificateOperation = new KeyVaultCertificateOperation
            {
                Id = certificateOperation.Id,
                Status = certificateOperation.Status,
                StatusDetails = certificateOperation.StatusDetails,
                RequestId = certificateOperation.RequestId,
                Target = certificateOperation.Target,
                Issuer = certificateOperation.IssuerParameters.Name,
                CancellationRequested = certificateOperation.CancellationRequested,
            };

            if (certificateOperation.Csr != null && certificateOperation.Csr.Length != 0)
            {
                kvCertificateOperation.CertificateSigningRequest = Convert.ToBase64String(certificateOperation.Csr);
            }

            if (certificateOperation.Error != null)
            {
                kvCertificateOperation.ErrorCode = certificateOperation.Error.Code;
                kvCertificateOperation.ErrorMessage = certificateOperation.Error.Message;
            }

            return kvCertificateOperation;
        }
    }
}
