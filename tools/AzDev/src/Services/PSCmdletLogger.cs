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
        private ILogger _logger = NoopLogger.Instance;

        public PSCmdletLogger()
        {
        }

        public void SetCmdlet(PSCmdlet cmdlet)
        {
            _logger = new PSCmdletLoggerAdapter(cmdlet ?? throw new ArgumentNullException(nameof(cmdlet)));
        }

        public void UnsetCmdlet()
        {
            _logger = NoopLogger.Instance;
        }


        public void Debug(string message) => _logger.Debug(PrependTimeStamp(message));

        public void Verbose(string message) => _logger.Verbose(PrependTimeStamp(message));

        public void Warning(string message) => _logger.Warning(PrependTimeStamp(message));

        public void Information(string message) => _logger.Information(PrependTimeStamp(message));

        private class PSCmdletLoggerAdapter : ILogger
        {
            private readonly PSCmdlet _cmdlet;

            public PSCmdletLoggerAdapter(PSCmdlet cmdlet)
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
                _cmdlet.WriteInformation(new HostInformationMessage { Message = message }, ["PSHOST"]);
            }
        }

        private static string PrependTimeStamp(string message)
        {
            return $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {message}";
        }
    }
}
