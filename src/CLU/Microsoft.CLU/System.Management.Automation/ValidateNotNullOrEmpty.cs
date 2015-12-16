using System.Collections;

namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateNotNullOrEmptyAttribute : ValidateArgumentsAttribute
    {
        public ValidateNotNullOrEmptyAttribute() { }

        internal protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (arguments == null)
                throw new ValidationException("must not be null");
            if (arguments is string && string.IsNullOrEmpty(arguments as string))
                throw new ValidationException("must not be empty");
            if (arguments is ICollection && (arguments as ICollection).Count == 0)
                throw new ValidationException("must not be empty");
            if (arguments is IEnumerable)
                foreach (var element in (arguments as IEnumerable))
                    Validate(element, engineIntrinsics);
        }
    }
}
