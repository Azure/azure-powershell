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
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class NewCertificateParameters : BatchClientParametersBase
    {
        public NewCertificateParameters(BatchAccountContext context, string filePath, byte[] rawData,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(filePath) && rawData == null)
            {
                throw new ArgumentException(Resources.NoCertificateData);
            }

            this.FilePath = filePath;
            this.RawData = rawData;
        }

        /// <summary>
        /// The path to the certificate file. The certificate must be in either .cer or .pfx format.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// The raw certificate data in either .cer or .pfx format.
        /// </summary>
        public byte[] RawData { get; private set; }

        /// <summary>
        /// The password to access the certificate private key for .pfx certificates.
        /// </summary>
        public string Password { get; set; }
    }
}
