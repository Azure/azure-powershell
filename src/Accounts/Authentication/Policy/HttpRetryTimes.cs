using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Policy
{
    internal class HttpRetryTimes
    {
        private const string maxRetriesVariableName = "AZURE_PS_HTTP_MAX_RETRIES";
        private const string maxRetriesFor429VariableName = "AZURE_PS_HTTP_MAX_RETRIES_FOR_429";

        public static int? AzurePsHttpMaxRetries
        {
            get
            {
                return TryGetAzurePsHttpMaxRetries();
            }
        }
        public static int? AzurePsHttpMaxRetriesFor429
        {
            get
            {
                return TryGetAzurePsHttpMaxRetriesFor429();
            }
        }

        private static int? TryGetValue(string environmentVariable)
        {
            int? retries = null;
            var value = Environment.GetEnvironmentVariable(environmentVariable);
            if (value != null)
            {
                int valueParsed = int.MinValue;
                if (int.TryParse(value, out valueParsed))
                {
                    retries = valueParsed;
                }
            }
            return retries;
        }

        private static int? TryGetAzurePsHttpMaxRetries()
        {
            return TryGetValue(maxRetriesVariableName);
        }

        private static int? TryGetAzurePsHttpMaxRetriesFor429()
        {
            return TryGetValue(maxRetriesFor429VariableName);
        }
    }
}
