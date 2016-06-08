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
    ///     Locates services that ViewModels need.
    /// </summary>
    internal interface IServiceLocator
    {
        /// <summary>
        ///     Locates an instance that implements the specified interface.
        /// </summary>
        /// <typeparam name="T"> Interface to locate. </typeparam>
        /// <returns> Instance of the interface. </returns>
        T Locate<T>();

        /// <summary>
        ///     Locates an instance that implements the specified interface.
        /// </summary>
        /// <param name="type"> Interface to locate. </param>
        /// <returns> Instance of the interface. </returns>
        object Locate(Type type);
    }
}
