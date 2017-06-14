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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Security;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockCommandRuntime : ICommandRuntime
    {
        public List<ErrorRecord> ErrorStream = new List<ErrorRecord>();
        public List<object> OutputPipeline = new List<object>();
        public List<string> WarningStream = new List<string>();
        public List<string> VerboseStream = new List<string>();
        public List<string> DebugStream = new List<string>();
        PSHost _host = new MockPSHost();

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
            get
            {
                return _host;
            }
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
            shouldProcessReason = ShouldProcessReason.None;
            return true;
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

        class MockPSHost : PSHost
        {
            PSHostUserInterface _hostUI = new MockPSHostUI();
            Version _version = new Version(1, 0, 0);
            Guid _instanceId = Guid.NewGuid();
            public override CultureInfo CurrentCulture
            {
                get { return CultureInfo.CurrentCulture; }
            }

            public override CultureInfo CurrentUICulture
            {
                get
                {
                    return CultureInfo.CurrentUICulture;
                }
            }

            public override Guid InstanceId
            {
                get
                {
                    return _instanceId;
                }
            }

            public override string Name
            {
                get
                {
                    return "MockHost";
                }
            }

            public override PSHostUserInterface UI
            {
                get { return _hostUI; }
            }

            public override Version Version
            {
                get
                {
                    return new Version(1, 0, 0);
                }
            }

            public override void NotifyBeginApplication()
            {
                throw new NotImplementedException();
            }

            public override void NotifyEndApplication()
            {
                throw new NotImplementedException();
            }

            public override void EnterNestedPrompt()
            {
                throw new NotImplementedException();
            }

            public override void ExitNestedPrompt()
            {
                throw new NotImplementedException();
            }

            public override void SetShouldExit(int exitCode)
            {
                throw new NotImplementedException();
            }

            class MockPSHostUI : PSHostUserInterface
            {
                public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
                {
                    return new Dictionary<string, PSObject>();
                }

                public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
                {
                    return 0;
                }

                public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
                {
                    return new PSCredential("user@contoso.org", new SecureString());
                }

                public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName,
                    PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
                {
                    return new PSCredential("user@contoso.org", new SecureString());
                }

                public override string ReadLine()
                {
                    return null;
                }

                public override void Write(string value)
                {
                }

                public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
                {
                }

                public override void WriteDebugLine(string message)
                {
                }

                public override void WriteErrorLine(string value)
                {
                }

                public override void WriteLine(string value)
                {
                }

                public override void WriteProgress(long sourceId, ProgressRecord record)
                {
                }

                public override void WriteVerboseLine(string message)
                {
                }

                public override void WriteWarningLine(string message)
                {
                }

                public override SecureString ReadLineAsSecureString()
                {
                    throw new NotImplementedException();
                }

                public override PSHostRawUserInterface RawUI
                {
                    get { throw new NotImplementedException(); }
                }
            }
        }
    }
}
