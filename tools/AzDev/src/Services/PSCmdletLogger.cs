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