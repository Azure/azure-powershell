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

using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public static class PSCmdletExtensions
    {
        private static MethodInfo GetProtectedMethod(string name)
        {
            MethodInfo m = typeof(PSCmdlet).GetMethod(
                name,
                BindingFlags.Instance | BindingFlags.NonPublic,
                Type.DefaultBinder,
                new Type[] { },
                null);

            return m;
        }

        public static void ExecuteCmdlet(this PSCmdlet cmdlet)
        {
            try
            {
                GetProtectedMethod("ProcessRecord").Invoke(cmdlet, new object[] { });
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}
