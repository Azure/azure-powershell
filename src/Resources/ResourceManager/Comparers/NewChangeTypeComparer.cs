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

//This class is identical to Comparers.ChangeTypeComparer with the only difference being the import of Management.Resources instead of Management.ResourceManager.
//The reason for this is this module has both cmdlets that use the old sdk version and cmdlets that use the new one, so this one acts as the class to be used by the cmdlets using the newer bits for the time being

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.NewComparers
{
    using Management.Resources.Models;
    using System.Collections.Generic;

    public class ChangeTypeComparer : IComparer<ChangeType>
    {
        private static readonly IReadOnlyDictionary<ChangeType, int> WeightsByChangeType =
            new Dictionary<ChangeType, int>
            {
                [ChangeType.Delete] = 0,
                [ChangeType.Create] = 1,
                [ChangeType.Deploy] = 2,
                [ChangeType.Modify] = 3,
                [ChangeType.Unsupported] = 4,
                [ChangeType.NoChange] = 5,
                [ChangeType.Ignore] = 6,
            };

        public int Compare(ChangeType first, ChangeType second)
        {
            return WeightsByChangeType[first] - WeightsByChangeType[second];
        }
    }
}



