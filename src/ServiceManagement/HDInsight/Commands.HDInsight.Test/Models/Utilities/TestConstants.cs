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
namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities
{
    /// <summary>
    ///     Provides Hard codes for key values.
    /// </summary>
    internal static class TestConstants
    {
        /// <summary>
        ///     The interval to use when polling a Hadoop cluster.
        /// </summary>
        public const int PollingInterval = 5000;

        /// <summary>
        ///     The number of times to retry when communicating with a Hadoop cluster.
        /// </summary>
        public const int RetryCount = 5;

        /// <summary>
        ///     The protocol string to use when using a Microsoft Azure Blob Storage account.
        /// </summary>
        public const string WabsProtocol = "wasb";

        /// <summary>
        ///     The protocol scheme name to use when using a Microsoft Azure Blob Storage account.
        /// </summary>
        public const string WabsProtocolSchemeName = "wasb://";
    }
}
