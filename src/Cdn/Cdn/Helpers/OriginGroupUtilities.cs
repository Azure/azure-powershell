using System;

namespace Microsoft.Azure.Commands.Cdn.Helpers
{
    public static class OriginGroupUtilities
    {
        public static Management.Cdn.Models.ProbeProtocol NormalizeProbeProtocol(string probeProtocol)
        {
            if (String.IsNullOrWhiteSpace(probeProtocol))
            {
                return Management.Cdn.Models.ProbeProtocol.NotSet;
            }
            else
            {
                string normalizedProbeProtocol = probeProtocol.ToLower();

                switch (normalizedProbeProtocol)
                {
                    case "http":
                        return Management.Cdn.Models.ProbeProtocol.Http;
                    case "https":
                        return Management.Cdn.Models.ProbeProtocol.Https;
                    default:
                        throw new Exception($"{probeProtocol} is not a valid protocol. Only Http or Https are allowed.");
                }
            }
        }

        public static Management.Cdn.Models.HealthProbeRequestType NormalizeProbeRequestType(string probeRequestType)
        {
            if (String.IsNullOrWhiteSpace(probeRequestType))
            {
                return Management.Cdn.Models.HealthProbeRequestType.NotSet;
            }
            else
            {
                string normalizedProbeRequestType = probeRequestType.ToLower();

                switch (normalizedProbeRequestType)
                {
                    case "get":
                        return Management.Cdn.Models.HealthProbeRequestType.GET;
                    case "head":
                        return Management.Cdn.Models.HealthProbeRequestType.HEAD;
                    default:
                        throw new Exception($"{probeRequestType} is not a valid request type. Only GET or HEAD are allowed.");
                }
            }
        }
    }
}
