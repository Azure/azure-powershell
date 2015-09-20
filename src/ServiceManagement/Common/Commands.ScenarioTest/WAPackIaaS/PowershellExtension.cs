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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    internal static class PowershellExtension
    {
        internal static Collection<PSObject> InvokeAndAssertForNoErrors(this System.Management.Automation.PowerShell powershell)
        {
            return powershell.InvokeAndAssertForErrors(null);
        }

        internal static Collection<PSObject> InvokeAndAssertForErrors(this System.Management.Automation.PowerShell powershell, string expectedErrorMsg = null)
        {
            powershell.Streams.ClearStreams();
            var result = powershell.Invoke();

            if (string.IsNullOrEmpty(expectedErrorMsg))
                Assert.IsFalse(powershell.HadErrors, powershell.GetPowershellErrorMessage());
            else
                Assert.IsTrue(powershell.HadErrors);
            
            Assert.AreEqual(expectedErrorMsg, powershell.GetPowershellErrorMessage());
            return result;
        }

        

        internal static string GetPowershellErrorMessage(this System.Management.Automation.PowerShell powershell)
        {
            bool hadErrors = powershell.HadErrors;
            IList<ErrorRecord> errors = powershell.Streams.Error;
            
            if (hadErrors)
            {
                if (errors != null && errors.Count > 0 && errors[0].Exception != null)
                {
                    return errors[0].Exception.Message;
                }
            }

            return null;
        }

    }
}
