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
using Microsoft.Azure.Commands.Attestation.Properties;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    /// <summary>
    /// Thrown when a token returned by the attestation service fails validation, for example because it is not signed
    /// by the provider, was issued by another provider, or is outside its validity period.
    /// </summary>
    internal class ServiceTokenValidationException : InvalidOperationException
    {
        public ServiceTokenValidationException(string reason, Exception innerException = null)
            : base(string.Format(Resources.InvalidServiceToken, reason).TrimEnd(), innerException)
        {
        }
    }
}
