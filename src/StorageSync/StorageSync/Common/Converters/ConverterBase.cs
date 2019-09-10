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
    /// Class ConverterBase.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.IConverter{P, T}" />
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.IConverter{P, T}" />
    public abstract class ConverterBase<P, T> : IConverter<P, T>
        //where P : PSResourceBase, new()
        //where T : StorageSyncModels.Resource, new()
        where P : class, new()
        where T : class, new()
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterBase{P, T}" /> class.
        /// </summary>
        public ConverterBase()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>T.</returns>
        protected abstract T Transform(P source);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>P.</returns>
        protected abstract P Transform(T source);

        /// <summary>
        /// Converts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>P.</returns>
        public P Convert(T resource)
        {
            if (resource != null)
            {
                return Transform(resource);
            }

            return default(P);

        }

        /// <summary>
        /// Converts the specified ps resource.
        /// </summary>
        /// <param name="psResource">The ps resource.</param>
        /// <returns>T.</returns>
        public T Convert(P psResource)
        {
            if (psResource != null)
            {
                return Transform(psResource);
            }

            return default(T);

        }

        /// <summary>
        /// Converts the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>System.Object.</returns>
        public object Convert(object resource)
        {
            if (resource is P)
            {
                return Convert(resource as P);
            }

            return Convert(resource as T);
        }
    }
}
