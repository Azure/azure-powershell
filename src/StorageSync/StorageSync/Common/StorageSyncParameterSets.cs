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

using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    /// <summary>
    /// Class StorageSyncParameterSets.
    /// </summary>
    public class StorageSyncParameterSets
    {
        /// <summary>
        /// The resource identifier parameter set
        /// </summary>
        public const string ResourceIdParameterSet = "ResourceIdParameterSet";
        /// <summary>
        /// The string parameter set
        /// </summary>
        public const string StringParameterSet = "StringParameterSet";
        /// <summary>
        /// The object parameter set
        /// </summary>
        public const string ObjectParameterSet = "ObjectParameterSet";
        /// <summary>
        /// The parent string parameter set
        /// </summary>
        public const string ParentStringParameterSet = "ParentStringParameterSet";
        /// <summary>
        /// The input object parameter set
        /// </summary>
        public const string InputObjectParameterSet = "InputObjectParameterSet";
        /// <summary>
        /// The default parameter set
        /// </summary>
        public const string DefaultParameterSet = "DefaultParameterSet";
    }
}
