using System.Collections;

namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public abstract class ValidateEnumeratedArgumentsAttribute : ValidateArgumentsAttribute
    {
        protected ValidateEnumeratedArgumentsAttribute()
        {
        }

        internal protected sealed override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (arguments != null)
            {
                if (!(arguments is string) && arguments is IEnumerable)
                {
                    foreach (var element in (arguments as IEnumerable))
                        Validate(element, engineIntrinsics);
                }
                else
                {
                    ValidateElement(arguments);
                }
            }
        }

        protected abstract void ValidateElement(object element);
    }
}
