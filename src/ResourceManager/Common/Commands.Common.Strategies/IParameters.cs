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

using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// Describes Azure operation parameter and a target resource.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IParameters<TModel>
        where TModel : class
    {
        /// <summary>
        /// Azure location. For example, "eastus".
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Default location. It's used if Location is null and it can't be infered.
        /// </summary>
        string DefaultLocation { get; }

        /// <summary>
        /// Create an Azure resource configuration according to the parameters.
        /// </summary>
        /// <returns></returns>
        Task<ResourceConfig<TModel>> CreateConfigAsync();
    }
}
