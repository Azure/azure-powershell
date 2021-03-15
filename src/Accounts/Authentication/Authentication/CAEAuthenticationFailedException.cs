using Azure.Identity;
using System;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class CAEAuthenticationFailedException : AuthenticationFailedException
    {
        CAEAuthenticationFailedException(string message)
            : base(message)
        {
        }

        CAEAuthenticationFailedException(string message, Exception e)
            : base(message, e)
        {
        }

        public static CAEAuthenticationFailedException FromExceptionAndAdditionalMessage(AuthenticationFailedException e, string additonal)
        {
            var errorMessage = new StringBuilder(e.Message);
            errorMessage.Append(Environment.NewLine).Append("-").Append(additonal);
            return new CAEAuthenticationFailedException(errorMessage.ToString(), e);
        }
    }
}
