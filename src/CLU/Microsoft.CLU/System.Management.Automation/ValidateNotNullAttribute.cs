using System.Collections;

namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateNotNullAttribute : ValidateArgumentsAttribute
    {
        public ValidateNotNullAttribute() { }

        internal protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (arguments == null)
                throw new ValidationException("must not be null");
            if (arguments is IEnumerable)
                foreach (var element in (arguments as IEnumerable))
                    Validate(element, engineIntrinsics);
        }
    }
}
