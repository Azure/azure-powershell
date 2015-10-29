using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

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
