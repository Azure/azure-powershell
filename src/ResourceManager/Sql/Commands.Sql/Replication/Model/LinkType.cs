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

namespace Microsoft.Azure.Commands.Sql.Replication.Model
{
    /// <summary>
    /// The link types enumeration
    /// </summary>
    public enum LinkType
    {
        /// <summary>
        /// NonReadable Offline Secondary
        /// </summary>
        NonReadableSecondary = 0,

        /// <summary>
        /// Readable Secondary
        /// </summary>
        Secondary = 1
    }
}

