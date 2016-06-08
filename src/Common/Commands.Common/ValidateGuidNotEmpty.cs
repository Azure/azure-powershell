using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Common
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ValidateGuidNotEmptyAttribute : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (arguments == null)
            {
                throw new ValidationMetadataException("Specify a parameter of type 'System.Guid' and try again.");
            }

            Guid param = (Guid)arguments;
            if (param == Guid.Empty)
            {
                throw new ValidationMetadataException("Specify a non empty value of type 'System.Guid' and try again.");
            }
        }
    }
}
