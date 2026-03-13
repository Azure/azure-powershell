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
    /// Interface representing a WhatIf property change.
    /// Implemented by RP-specific classes to provide property change information.
    /// </summary>
    public interface IWhatIfPropertyChange
    {
        /// <summary>
        /// The JSON path of the property.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// The type of property change (Create, Delete, Modify, Array, NoEffect).
        /// </summary>
        PropertyChangeType PropertyChangeType { get; }

        /// <summary>
        /// The property value before the change.
        /// </summary>
        JToken Before { get; }

        /// <summary>
        /// The property value after the change.
        /// </summary>
        JToken After { get; }

        /// <summary>
        /// Child property changes (for nested objects/arrays).
        /// </summary>
        IList<IWhatIfPropertyChange> Children { get; }
    }
}
