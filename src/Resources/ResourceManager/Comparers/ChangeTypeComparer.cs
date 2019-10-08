namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Comparers
{
    using Management.ResourceManager.Models;
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
                [ChangeType.Ignore] = 4,
                [ChangeType.NoChange] = 5,
            };

        public int Compare(ChangeType first, ChangeType second)
        {
            return WeightsByChangeType[first] - WeightsByChangeType[second];
        }
    }
}


