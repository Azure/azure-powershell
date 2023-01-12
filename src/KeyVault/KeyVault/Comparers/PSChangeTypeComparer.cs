using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Comparers
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
