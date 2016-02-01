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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    /// <summary>
    /// Provides factory class to build instances of TransferJobRunners.
    /// </summary>
    internal static class TransferManagerFactory
    {
        /// <summary>
        /// Stores the cached runner;
        /// </summary>
        private static ITransferManager cachedTransferManager;

        /// <summary>
        /// Creates a new instance of the runner.
        /// </summary>
        /// <param name="concurrency">Indicating the concurrency.</param>
        /// <returns>
        /// Returns the created instance or the cached one (if available).
        /// </returns>
        public static ITransferManager CreateTransferManager(int concurrency)
        {
            if (cachedTransferManager != null)
            {
                return cachedTransferManager;
            }

            return new DataManagementWrapper(concurrency);
        }

        /// <summary>
        /// Sets the cached runner. This is mainly for testing purpose.
        /// </summary>
        /// <param name="runner">
        /// Indicating the instance of the cached runner.
        /// </param>
        internal static void SetCachedTransferManager(ITransferManager transferManager)
        {
            cachedTransferManager = transferManager;
        }
    }
}
