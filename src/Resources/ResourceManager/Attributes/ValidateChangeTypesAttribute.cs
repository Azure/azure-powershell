namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    public class ValidateChangeTypesAttribute : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var changeTypeNames = arguments.Cast<string[]>();
            List<string> invalidChangeTypeNames = changeTypeNames.Distinct()
                .Where(name => !Enum.TryParse(name, true, out ChangeType _)).ToList();

            if (invalidChangeTypeNames.Count > 0)
            {
                string word = invalidChangeTypeNames.Count > 1 ? "types" : "type";
                string invalidChangeTypeNameList = string.Join(", ", invalidChangeTypeNames);

                string[] validChangeTypeNames = Enum.GetNames(typeof(ChangeType));
                string validChangeTypeNameList = string.Join(", ", validChangeTypeNames);

                throw new ParameterBindingException(
                    string.Format(Resources.InvalidChangeType, word, invalidChangeTypeNameList, validChangeTypeNameList));
            }
        }
    }
}
