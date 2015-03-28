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

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockCommandRuntime : ICommandRuntime
    {
        public List<ErrorRecord> ErrorStream = new List<ErrorRecord>();
        public List<object> OutputPipeline = new List<object>();
        public List<string> WarningStream = new List<string>();
        public List<string> VerboseStream = new List<string>();
        public List<string> DebugStream = new List<string>();

        public override string ToString()
        {
            return "MockCommand";
        }

        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations", 
            Justification = "Tests should not access this property")]
        public PSTransactionContext CurrentPSTransaction
        {
            get { throw new System.NotImplementedException(); }
        }

        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations",
            Justification = "Tests should not access this property")]
        public System.Management.Automation.Host.PSHost Host
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            return true;
        }

        public bool ShouldContinue(string query, string caption)
        {
            return true;
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason)
        {
            throw new System.NotImplementedException();
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            return true;
        }

        public bool ShouldProcess(string target, string action)
        {
            return true;
        }

        public bool ShouldProcess(string target)
        {
            return true;
        }

        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            throw new System.NotImplementedException();
        }

        public bool TransactionAvailable()
        {
            throw new System.NotImplementedException();
        }

        public void WriteCommandDetail(string text)
        {
            throw new System.NotImplementedException();
        }

        public void WriteDebug(string text)
        {
            DebugStream.Add(text);
        }

        public void WriteError(ErrorRecord errorRecord)
        {
            ErrorStream.Add(errorRecord);
        }

        public void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            System.Collections.IEnumerable enumerable = LanguagePrimitives.GetEnumerable(sendToPipeline);
            if (enumerable != null && enumerateCollection)
            {
                foreach (object o in enumerable)
                {
                    OutputPipeline.Add(o);
                }
            }
            else
            {
                OutputPipeline.Add(sendToPipeline);
            }
        }

        public void WriteObject(object sendToPipeline)
        {
            OutputPipeline.Add(sendToPipeline);
        }

        public void WriteProgress(long sourceId, ProgressRecord progressRecord)
        {
            // Do nothing
        }

        public void WriteProgress(ProgressRecord progressRecord)
        {
            // Do nothing
        }

        public void WriteVerbose(string text)
        {
            VerboseStream.Add(text);
        }

        public void WriteWarning(string text)
        {
            this.WarningStream.Add(text);
        }

        /// <summary>
        /// Clears all command runtime pipelines.
        /// </summary>
        public void ResetPipelines()
        {
            ErrorStream.Clear();
            OutputPipeline.Clear();
            WarningStream.Clear();
            VerboseStream.Clear();
        }
    }
}
