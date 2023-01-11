using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Comparers
{
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
