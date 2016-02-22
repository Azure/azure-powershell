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
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCmdlet : PSCmdlet
    {
        /// <summary>
        ///     Gets or sets the progress record.
        /// </summary>
        protected ProgressRecord ProgressRecord { get; set; }

        // TODO: progress handler when necessary
        //protected void ProgressHandler(object sender, ProgressEventArgs e)
        //{
        //}

        /// <summary>
        ///     Gets the name of the cmdlet
        /// </summary>
        protected string CmdletName
        {
            get
            {
                return MyInvocation.MyCommand.Name;
            }
        }

        /// <summary>
        ///     Process record for this cmdlet.
        /// </summary>
        /// <remarks>
        ///     We will catch all exceptions here so we can log them in our event provider.
        /// </remarks>
        protected override void ProcessRecord()
        {
            Execute();
        }

        /// <summary>
        ///     Execute this cmdlet.
        /// </summary>
        /// <remarks>
        ///     Descendant classes must override this methods instead of Cmdlet.ProcessRecord, so
        ///     we can have a unique place where log all errors.
        /// </remarks>
        protected abstract void Execute();

        /// <summary>
        ///     Send an error event to the current event source
        /// </summary>
        /// <param name="operation">The operation</param>
        /// <param name="message">The message</param>
        /// <param name="exception">The exception</param>
        protected abstract void TraceError(string operation, string message, Exception exception);

        /// <summary>
        ///     Send a warning event to the current event source
        /// </summary>
        /// <param name="operation">The operation</param>
        /// <param name="message">The message</param>
        protected abstract void TraceWarning(string operation, string message);

        /// <summary>
        ///     Send an informational event to the current event source
        /// </summary>
        /// <param name="operation">The operation</param>
        /// <param name="message">The message</param>
        protected abstract void TraceInformational(string operation, string message);

        /// <summary>
        ///     Send a verbose event to the current event source
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="message">The message.</param>
        protected abstract void TraceVerbose(string operation, string message);

        /// <summary>
        ///     Override the WriteError method to log the error on our event provider.
        /// </summary>
        /// <param name="errorRecord">The error to write</param>
        public new void WriteError(ErrorRecord errorRecord)
        {
            if (errorRecord == null)
                throw new ArgumentNullException("errorRecord");
            base.WriteError(errorRecord);
            TraceError(CmdletName, errorRecord.Exception.Message, errorRecord.Exception);
        }

        /// <summary>
        ///     Override the WriteWarning method to log the warning on our event provider.
        /// </summary>
        /// <param name="text">The text to write</param>
        public new void WriteWarning(string text)
        {
            base.WriteWarning(text);
            TraceWarning(CmdletName, text);
        }
    }
}
