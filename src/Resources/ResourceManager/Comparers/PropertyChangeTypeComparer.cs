namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Comparers
{
    using Management.ResourceManager.Models;
    using System.Collections.Generic;

    public class PropertyChangeTypeComparer : IComparer<PropertyChangeType>
    {
        private static readonly IReadOnlyDictionary<PropertyChangeType, int> WeightsByPropertyChangeType =
            new Dictionary<PropertyChangeType, int>
            {
                [PropertyChangeType.Delete] = 0,
                [PropertyChangeType.Create] = 1,
                [PropertyChangeType.Modify] = 2,
                [PropertyChangeType.Array] = 2
            };

        public int Compare(PropertyChangeType first, PropertyChangeType second)
        {
            return WeightsByPropertyChangeType[first] - WeightsByPropertyChangeType[second];
        }
    }
}

