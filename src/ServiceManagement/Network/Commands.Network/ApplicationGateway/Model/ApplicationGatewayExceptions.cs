namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;

    public class ApplicationGatewayConfigurationValidationException : Exception
    {
        public ApplicationGatewayConfigurationValidationException(string message)
            :base(message)
        {
        }
    }

    public class ApplicationGatewayConfigurationException : Exception
    {
        public ApplicationGatewayConfigurationException(string message)
            : base(message)
        {
        }

        public ApplicationGatewayConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
