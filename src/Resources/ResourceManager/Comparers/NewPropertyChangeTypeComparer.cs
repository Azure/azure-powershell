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


//This class is identical to Comparers.PropertyChangeTypeComparer with the only difference being the import of Management.Resources instead of Management.ResourceManager.
//The reason for this is this module has both cmdlets that use the old sdk version and cmdlets that use the new one, so this one acts as the class to be used by the cmdlets using the newer bits for the time being
namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.NewComparers
{
    using Management.Resources.Models;
    using System.Collections.Generic;

    public class PropertyChangeTypeComparer : IComparer<PropertyChangeType>
    {
        private static readonly IReadOnlyDictionary<PropertyChangeType, int> WeightsByPropertyChangeType =
            new Dictionary<PropertyChangeType, int>
            {
                [PropertyChangeType.Delete] = 0,
                [PropertyChangeType.Create] = 1,
                // Modify and Array are set to have the same weight by intention.
                [PropertyChangeType.Modify] = 2,
                [PropertyChangeType.Array] = 2,
                [PropertyChangeType.NoEffect] = 3,
            };

        public int Compare(PropertyChangeType first, PropertyChangeType second)
        {
            return WeightsByPropertyChangeType[first] - WeightsByPropertyChangeType[second];
        }
    }
}


