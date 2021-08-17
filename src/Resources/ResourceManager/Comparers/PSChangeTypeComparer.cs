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

using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Comparers
{
    public class PSChangeTypeComparer : IComparer<PSChangeType>
    {
        private static readonly IReadOnlyDictionary<PSChangeType, int> WeightsByPSChangeType =
            new Dictionary<PSChangeType, int>
            {
                [PSChangeType.Delete] = 0,
                [PSChangeType.Create] = 1,
                [PSChangeType.Deploy] = 2,
                [PSChangeType.Modify] = 3,
                [PSChangeType.Unsupported] = 4,
                [PSChangeType.NoEffect] = 5,
                [PSChangeType.NoChange] = 6,
                [PSChangeType.Ignore] = 7,
            };

        public int Compare(PSChangeType first, PSChangeType second)
        {
            return WeightsByPSChangeType[first] - WeightsByPSChangeType[second];
        }
    }
}
