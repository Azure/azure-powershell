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


namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Interface IConverter
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Converts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>System.Object.</returns>
        object Convert(object resource);
    }

    /// <summary>
    /// Interface IConverter
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.IConverter" />
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.IConverter" />
    public interface IConverter<P, T> : IConverter
        where P : class, new()
        where T : class, new()

        //where P : PSResourceBase
        //where T : StorageSyncModels.Resource
    {
        /// <summary>
        /// Converts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>P.</returns>
        P Convert(T resource);

        /// <summary>
        /// Converts the specified ps resource.
        /// </summary>
        /// <param name="psResource">The ps resource.</param>
        /// <returns>T.</returns>
        T Convert(P psResource);

    }
}
