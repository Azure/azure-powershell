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
    /// Thrown when a successful response from the attestation service does not contain a valid token.
    /// </summary>
    internal class MissingServiceTokenException : InvalidOperationException
    {
        public MissingServiceTokenException(Exception innerException = null)
            : base(Resources.MissingServiceToken, innerException)
        {
        }
    }

    /// <summary>
    /// Thrown when the attestation service accepted a change to a policy or to the policy signers, but the result
    /// could not be confirmed, for example because the token in the response is not valid. The change may already
    /// have been applied.
    /// </summary>
    internal class UnconfirmedChangeException : InvalidOperationException
    {
        public UnconfirmedChangeException(Exception innerException)
            : base(string.Format(Resources.UnconfirmedChange, innerException?.Message), innerException)
        {
        }
    }
}
