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

namespace Commands.StorageSync.Interop.Interfaces
{
    /// <summary>
    /// Function performs server certificate rollover
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ISyncServerCertificateRollover : IDisposable
    {
        /// <summary>
        /// Function performs server certificate rollover
        /// </summary>
        /// <param name="certificateProviderName">Certificate Provider Name</param>
        /// <param name="certificateHashAlgorithm">Certificate Hash Algorithm</param>
        /// <param name="certificateKeyLength">Certificate Key Length</param>
        /// <param name="TriggerServiceRollover">The trigger service rollover.</param>
        /// <param name="tracelog">The tracelog.</param>
        /// <returns>Registered Server Resource</returns>
        void RolloverServerCertificate(
            string certificateProviderName, 
            string certificateHashAlgorithm, 
            uint certificateKeyLength, 
            Action<string, Guid> TriggerServiceRollover,
            Action<string> tracelog
            );
    }
}
