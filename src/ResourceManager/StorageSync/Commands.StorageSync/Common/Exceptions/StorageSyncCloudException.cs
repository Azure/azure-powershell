using Microsoft.Azure.Management.StorageSync.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Common.Exceptions
{
    public class StorageSyncCloudException : Rest.Azure.CloudException
    {
        protected const string RequestIdHeaderInResponse = "x-ms-request-id";

        public StorageSyncCloudException(Rest.Azure.CloudException ex)
            : base(GetErrorMessageWithRequestIdInfo(ex), ex)
        {
        }

        public StorageSyncCloudException(StorageSyncErrorException ex)
            : base(ex.Body?.Error?.Message ?? ex.Message, ex)
        {
        }

        protected static string GetErrorMessageWithRequestIdInfo(Rest.Azure.CloudException cloudException)
        {
            if (cloudException == null)
            {
                return "No information in the cloud exception.";
            }

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(cloudException.Message))
            {
                sb.Append(cloudException.Message);
            }

            if (cloudException.Response == null)
            {
                return sb.ToString();
            }

            if (cloudException.Response.Content != null)
            {
                StorageSyncError storageSyncError = JsonConvert.DeserializeObject<StorageSyncError>(cloudException.Response.Content);

                if (storageSyncError.Error != null)
                {
                    sb.AppendLine().AppendFormat("ErrorCode: {0}", storageSyncError.Error.Code);
                    sb.AppendLine().AppendFormat("ErrorMessage: {0}", storageSyncError.Error.Message);
                    sb.AppendLine().AppendFormat("ErrorTarget: {0}", storageSyncError.Error.Target);
                }

            }

            if (!cloudException.Response.StatusCode.Equals(HttpStatusCode.OK))
            {
                sb.AppendLine().AppendFormat("StatusCode: {0}", cloudException.Response.StatusCode.GetHashCode());
                sb.AppendLine().AppendFormat("ReasonPhrase: {0}", cloudException.Response.ReasonPhrase);
                if (cloudException.Response.Headers == null
                    || !cloudException.Response.Headers.ContainsKey(RequestIdHeaderInResponse))
                {
                    return sb.ToString();
                }

                sb.AppendLine().AppendFormat($"OperationID : {cloudException.RequestId}");
            }

            return sb.ToString();
        }
    }
}
