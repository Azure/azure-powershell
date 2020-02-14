namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using System.Collections.Generic;
    using Rest.Azure;

    public static class CloudExceptionExtensions
    {
        public static string GetRequestId(this CloudException ce)
        {
            if (!string.IsNullOrEmpty(ce.RequestId))
            {
                return ce.RequestId;
            }

            if (ce.Response?.Headers != null &&
                ce.Response.Headers.TryGetValue("x-ms-request-id", out IEnumerable<string> requestIdValues))
            {
                return string.Join(";", requestIdValues);
            }

            return string.Empty;
        }
    }
}
