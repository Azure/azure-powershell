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

namespace Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Interface representing a WhatIf resource change.
    /// Implemented by RP-specific classes to provide change information.
    /// </summary>
    public interface IWhatIfChange
    {
        /// <summary>
        /// The scope of the change (e.g., subscription, resource group).
        /// </summary>
        string Scope { get; }

        /// <summary>
        /// The relative resource ID (without scope prefix).
        /// </summary>
        string RelativeResourceId { get; }

        /// <summary>
        /// The fully qualified resource ID.
        /// </summary>
        string FullyQualifiedResourceId { get; }

        /// <summary>
        /// The type of change (Create, Delete, Modify, etc.).
        /// </summary>
        ChangeType ChangeType { get; }

        /// <summary>
        /// The API version of the resource.
        /// </summary>
        string ApiVersion { get; }

        /// <summary>
        /// Reason if the resource is unsupported.
        /// </summary>
        string UnsupportedReason { get; }

        /// <summary>
        /// The resource state before the change.
        /// </summary>
        JToken Before { get; }

        /// <summary>
        /// The resource state after the change.
        /// </summary>
        JToken After { get; }

        /// <summary>
        /// The list of property changes.
        /// </summary>
        IList<IWhatIfPropertyChange> Delta { get; }
    }
}
