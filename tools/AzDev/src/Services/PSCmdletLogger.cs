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

namespace AzDev.Services
{
    /// <summary>
    /// Implements ILogger using a PSCmdlet instance for logging.
    /// </summary>
    public class PSCmdletLogger : ILogger
    {
        private readonly PSCmdlet _cmdlet;

        public PSCmdletLogger(PSCmdlet cmdlet)
        {
            _cmdlet = cmdlet ?? throw new ArgumentNullException(nameof(cmdlet));
        }

        public void Debug(string message)
        {
            _cmdlet.WriteDebug(message);
        }

        public void Verbose(string message)
        {
            _cmdlet.WriteVerbose(message);
        }

        public void Warning(string message)
        {
            _cmdlet.WriteWarning(message);
        }

        public void Information(string message)
        {
            _cmdlet.WriteInformation(new InformationRecord(message, "AzDev"));
        }
    }
}
