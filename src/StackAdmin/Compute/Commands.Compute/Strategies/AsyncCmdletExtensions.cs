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

using Microsoft.Azure.Commands.Common.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    static class AsyncCmdletExtensions
    {
        /// <summary>
        /// Note: the function must be called in the main PowerShell thread.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="createAndStartTask"></param>
        public static void StartAndWait<T>(
            this T cmdlet, Func<IAsyncCmdlet, Task> createAndStartTask)
            where T : PSCmdlet
            => new CmdletWrap<T>(cmdlet).CmdletStartAndWait(createAndStartTask);

        sealed class CmdletWrap<T> : ICmdlet
            where T : PSCmdlet
        {
            readonly T _Cmdlet;

            public string VerbsNew => VerbsCommon.New;

            public CmdletWrap(T cmdlet)
            {
                _Cmdlet = cmdlet;
            }

            public IEnumerable<KeyValuePair<string, object>> Parameters
            {
                get
                {
                    var psName = _Cmdlet.ParameterSetName;
                    return typeof(T)
                        .GetProperties()
                        .Where(p => p
                            .GetCustomAttributes(false)
                            .OfType<ParameterAttribute>()
                            .Any(a => a.ParameterSetName == psName
                                || a.ParameterSetName == null))
                        .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(_Cmdlet)));
                }
            }

            public void WriteVerbose(string message)
                => _Cmdlet.WriteVerbose(message);

            public bool ShouldProcess(string target, string action)
                => _Cmdlet.ShouldProcess(target, action);

            public void WriteObject(object value)
                => _Cmdlet.WriteObject(value);

            public void WriteProgress(
                string activity,
                string statusDescription,
                string currentOperation,
                int percentComplete)
                => _Cmdlet.WriteProgress(
                    new ProgressRecord(
                        0,
                        activity,
                        statusDescription)
                    {
                        CurrentOperation = currentOperation,
                        PercentComplete = percentComplete,
                    });

            public void WriteWarning(string message)
                => _Cmdlet.WriteWarning(message);
        }
    }
}