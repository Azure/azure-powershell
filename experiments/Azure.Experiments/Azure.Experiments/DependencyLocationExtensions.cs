using System;

namespace Microsoft.Azure.Experiments
{
    public static class DependencyLocationExtensions
    {
        public static DependencyLocation Best(this DependencyLocation a, DependencyLocation b)
        {
            if (a == null)
            {
                return b;
            }
            if (b == null)
            {
                return a;
            }

            // a != null
            // b != null
            if (!a.IsCommon)
            {
                return b;
            }
            if (!b.IsCommon)
            {
                return a;
            }

            // a.IsCommon == true
            // b.IsCommon == true
            if (a.Location != b.Location)
            {
                throw new Exception("dependent resources have different locations");
            }
            return a;
        }
    }
}
