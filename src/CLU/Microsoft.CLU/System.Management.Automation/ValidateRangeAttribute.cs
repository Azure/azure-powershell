namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateRangeAttribute : ValidateEnumeratedArgumentsAttribute
    {
        public ValidateRangeAttribute(object minRange, object maxRange) { MaxRange = maxRange; MinRange = minRange; }

        public object MaxRange { get; private set; }
        public object MinRange { get; private set; }

        protected override void ValidateElement(object element)
        {
            var elem = (IComparable)element;
            var min = (IComparable)MinRange;
            var max = (IComparable)MaxRange;

            if (elem.CompareTo(min) < 0 || elem.CompareTo(max) > 0)
                throw new ValidationException("lies outside the specified range.");

        }
    }
}