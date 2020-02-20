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

using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Test.ScenarioTests
{
    public static class UnitTestHelper
    {
        public static void CheckConfirmImpact(Type cmdlet, ConfirmImpact confirmImpact)
        {
            object[] cmdletAttributes = cmdlet.GetCustomAttributes(typeof(CmdletAttribute), true);
            Assert.Single(cmdletAttributes);
            CmdletAttribute attribute = (CmdletAttribute)cmdletAttributes[0];
            if(attribute.SupportsShouldProcess)
            {
                Assert.Equal(confirmImpact, attribute.ConfirmImpact);
            }else
            {
                Assert.Equal(ConfirmImpact.None, attribute.ConfirmImpact);
            }
        }

        public static void CheckCmdletModifiesData(Type cmdlet, bool supportsShouldProcess)
        {
            // If the Cmdlet modifies data, SupportsShouldProcess should be set to true.
            object[] cmdletAttributes = cmdlet.GetCustomAttributes(typeof(CmdletAttribute), true);
            Assert.Single(cmdletAttributes);
        }

        public static void CheckCmdletParameterAttributes(Type cmdlet, string parameterName, bool? isMandatory, bool valueFromPipelineByName, string parameterSet)
        {
            CheckCmdletParameterAttributes(cmdlet, parameterName, isMandatory, valueFromPipelineByName, new HashSet<String>() { parameterSet });
        }

        public static void CheckCmdletParameterAttributes(Type cmdlet, string parameterName, bool? isMandatory, bool valueFromPipelineByName, HashSet<String> parameterSet = null)
        {
            PropertyInfo property = cmdlet.GetProperty(parameterName);
            Assert.NotNull(property);

            foreach (ParameterAttribute paramAttr in property.GetCustomAttributes(typeof(ParameterAttribute), true))
            {
                Assert.NotNull(paramAttr);
                if (isMandatory != null)
                {
                    Assert.Equal(isMandatory, paramAttr.Mandatory);
                }
                Assert.Equal(valueFromPipelineByName, paramAttr.ValueFromPipelineByPropertyName);
                Assert.NotNull(paramAttr.HelpMessage);
                if (parameterSet != null)
                {
                    CheckCmdletParameterSet(cmdlet, parameterName, parameterSet);
                }
            }
        }

        public static void CheckCmdletParameterSet(Type cmdlet, string parameterName, HashSet<String> parameterSet)
        {
            PropertyInfo property = cmdlet.GetProperty(parameterName);
            Assert.NotNull(property);
            HashSet<string> set = new HashSet<string>();
            foreach (ParameterAttribute paramAttr in property.GetCustomAttributes(typeof(ParameterAttribute), true))
            {
                Assert.Contains(paramAttr.ParameterSetName, parameterSet);
                Assert.DoesNotContain(paramAttr.ParameterSetName, set);
                set.Add(paramAttr.ParameterSetName);
            }
            Assert.Equal(parameterSet.Count, set.Count);
        }

        
    }
}
