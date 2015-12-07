using System.Collections;
using System.Linq;

namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateCountAttribute : ValidateArgumentsAttribute
    {
        public ValidateCountAttribute(int minLength, int maxLength) { MaxLength = maxLength; MinLength = minLength; }

        public int MaxLength { get; private set; }
        public int MinLength { get; private set; }

        internal protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var len = 0;
            if (arguments != null)
            {
                len = 1;
                if (arguments is IEnumerable)
                {
                    len = 0;
                    foreach (var element in (arguments as IEnumerable))
                    {
                        len += 1;
                    }
                }
            }

            if (len > MaxLength || len < MinLength)
            {
                throw new ValidationException("lies outside the valid range");
            }
        }
    }
}
