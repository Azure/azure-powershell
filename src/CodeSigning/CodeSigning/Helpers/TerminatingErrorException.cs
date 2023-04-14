using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
{
    internal class TerminatingErrorException : Exception
    {
        public TerminatingErrorException(Exception innerException, ErrorCategory category)
            : base(innerException.Message, innerException)
        {
            Category = category;
        }

        public ErrorCategory Category { get; }
    }
}
