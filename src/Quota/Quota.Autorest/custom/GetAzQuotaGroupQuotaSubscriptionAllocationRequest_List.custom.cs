namespace Microsoft.Azure.PowerShell.Cmdlets.Quota.Cmdlets
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.PowerShell.Cmdlets.Quota.Runtime.Json;

    /// <summary>
    /// Custom partial class to handle non-JSON error responses
    /// </summary>
    public partial class GetAzQuotaGroupQuotaSubscriptionAllocationRequest_List
    {
        partial void overrideOnDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IErrorResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            // Read the response content
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            
            // Check if response is plain text (not JSON)
            if (!string.IsNullOrEmpty(content) && !content.TrimStart().StartsWith("{") && !content.TrimStart().StartsWith("["))
            {
                // Handle plain text response
                if (content.Trim() == "[]")
                {
                    // Empty array - output nothing (no allocation requests found)
                    returnNow = global::System.Threading.Tasks.Task.FromResult(true);
                }
                else
                {
                    // Plain text error message
                    var ex = new Exception(content);
                    WriteError(new ErrorRecord(ex, responseMessage.StatusCode.ToString(), ErrorCategory.InvalidOperation, null)
                    {
                        ErrorDetails = new ErrorDetails(content)
                    });
                    returnNow = global::System.Threading.Tasks.Task.FromResult(true);
                }
            }
        }
    }
}
