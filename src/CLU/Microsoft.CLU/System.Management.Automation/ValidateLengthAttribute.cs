namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateLengthAttribute : ValidateEnumeratedArgumentsAttribute
    {
        public ValidateLengthAttribute(int minLength, int maxLength) { MaxLength = maxLength; MinLength = minLength; }

        public int MaxLength { get; private set; }
        public int MinLength { get; private set; }

        protected override void ValidateElement(object element)
        {
            if (!(element is string))
                throw new InvalidOperationException("ValidateLength only makes sense for string arugments.");

            var len = 0;
            if (element != null)
            {
                len = (element as string).Length;
            }

            if (len > MaxLength || len < MinLength)
            {
                throw new ValidationException("does not have the right length.");
            }
        }
    }
}
