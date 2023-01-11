using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Comparers
{
    public class ChangeTypeComparer : IComparer<ChangeType>
    {
        public static readonly IReadOnlyDictionary<ChangeType, int> WeightsByChangeType =
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
