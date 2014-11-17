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

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation
{
    /// <summary>
    ///     Provides services to override a service location for a single test.
    /// </summary>
    internal interface IServiceLocationIndividualTestManager
    {
        /// <summary>
        ///     Override default interface-to-implementation association.
        /// </summary>
        /// <typeparam name="T"> Interface to override. </typeparam>
        /// <param name="overrideValue"> Value to override with. </param>
        void Override<T>(T overrideValue);

        /// <summary>
        ///     Override default interface-to-implementation association.
        /// </summary>
        /// <param name="type"> Interface to override. </param>
        /// <param name="overrideValue"> Value to override with. </param>
        void Override(Type type, object overrideValue);

        /// <summary>
        ///     Resets the overrides.
        /// </summary>
        void Reset();
    }
}
