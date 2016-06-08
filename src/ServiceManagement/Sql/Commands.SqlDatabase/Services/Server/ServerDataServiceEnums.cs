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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    /// <summary>
    /// The database edition
    /// </summary>
    public enum DatabaseEdition
    {
        /// <summary>
        /// No database edition specified
        /// </summary>
        None = 0,

        /// <summary>
        /// A database business edition
        /// </summary>
        Business = 1,

        /// <summary>
        /// A database web edition
        /// </summary>
        Web = 2,

        /// <summary>
        /// A database premium edition
        /// </summary>
        Premium = 3,

        /// <summary>
        /// A database basic edition
        /// </summary>
        Basic = 4,

        /// <summary>
        /// A database standard edition
        /// </summary>
        Standard = 5
    }
}

