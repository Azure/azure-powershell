// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using NewAzureRmVmss = Microsoft.Azure.Commands.Compute.Automation.NewAzureRmVmss;
using NewAzureRmVmssConfigCommand = Microsoft.Azure.Commands.Compute.Automation.NewAzureRmVmssConfigCommand;
using NewAzureVMCommand = Microsoft.Azure.Commands.Compute.NewAzureVMCommand;
using NewAzureVMConfigCommand = Microsoft.Azure.Commands.Compute.NewAzureVMConfigCommand;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class CmdletPriorityTests
    {
        public CmdletPriorityTests(Xunit.Abstractions.ITestOutputHelper output)
        {
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(typeof(NewAzureVMCommand))]
        [InlineData(typeof(NewAzureVMConfigCommand))]
        [InlineData(typeof(NewAzureRmVmss))]
        [InlineData(typeof(NewAzureRmVmssConfigCommand))]
        public void PriorityArgumentCompleterIncludesSpotPlus(Type cmdletType)
        {
            IReadOnlyList<string> priorityValues = GetArgumentCompleterValues(cmdletType, "Priority");

            Assert.Contains(VirtualMachinePriorityTypes.Regular, priorityValues);
            Assert.Contains(VirtualMachinePriorityTypes.SpotPlus, priorityValues);
            Assert.Contains(VirtualMachinePriorityTypes.Spot, priorityValues);
        }

        private static IReadOnlyList<string> GetArgumentCompleterValues(Type cmdletType, string propertyName)
        {
            PropertyInfo property = cmdletType.GetProperty(propertyName);
            Assert.NotNull(property);

            IEnumerable<CustomAttributeData> matchingAttributes = property.GetCustomAttributesData()
                .Where(attribute => attribute.AttributeType.Name == "PSArgumentCompleterAttribute");
            CustomAttributeData argumentCompleterAttribute = Assert.Single(matchingAttributes);

            CustomAttributeTypedArgument argumentList = Assert.Single(argumentCompleterAttribute.ConstructorArguments);
            IEnumerable<CustomAttributeTypedArgument> argumentValues = Assert.IsAssignableFrom<IEnumerable<CustomAttributeTypedArgument>>(argumentList.Value);

            return argumentValues.Select(argumentValue => (string)argumentValue.Value).ToList();
        }
    }
}
