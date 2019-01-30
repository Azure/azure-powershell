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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class ListCertificateOptions : BatchClientParametersBase
    {
        public ListCertificateOptions(BatchAccountContext context, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, additionalBehaviors)
        { }

        /// <summary>
        /// The algorithm used to derive the Thumbprint parameter. This must be sha1.
        /// </summary>
        public string ThumbprintAlgorithm { get; set; }

        /// <summary>
        /// If specified, the single certificate with this thumbprint will be returned.
        /// </summary>
        public string Thumbprint { get; set; }

        /// <summary>
        /// The OData filter to use when querying for certificates.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// The OData select clause to use.
        /// </summary>
        public string Select { get; set; }

        /// <summary>
        /// The maximum number of certificates to return.
        /// </summary>
        public int MaxCount { get; set; }
    }
}
