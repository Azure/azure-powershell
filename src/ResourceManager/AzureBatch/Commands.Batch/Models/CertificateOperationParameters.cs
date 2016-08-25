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

using Microsoft.Azure.Batch;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class CertificateOperationParameters : BatchClientParametersBase
    {
        public CertificateOperationParameters(BatchAccountContext context, string thumbprintAlgorithm, string thumbprint,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(thumbprintAlgorithm))
            {
                throw new ArgumentNullException("thumbprintAlgorithm");
            }

            if (string.IsNullOrWhiteSpace(thumbprint))
            {
                throw new ArgumentNullException("thumbprint");
            }

            this.ThumbprintAlgorithm = thumbprintAlgorithm;
            this.Thumbprint = thumbprint;
        }

        /// <summary>
        /// The algorithm used to derive the Thumbprint parameter. This must be sha1.
        /// </summary>
        public string ThumbprintAlgorithm { get; private set; }

        /// <summary>
        /// The thumbprint of the certificate
        /// </summary>
        public string Thumbprint { get; private set; }
    }
}
