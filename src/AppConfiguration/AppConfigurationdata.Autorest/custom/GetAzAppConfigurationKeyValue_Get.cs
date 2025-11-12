namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Runtime.PowerShell;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>Custom partial implementation to fix pagination with relative @nextLink URLs</summary>
    public partial class GetAzAppConfigurationKeyValue_Get
    {
        /// <summary>
        /// Override the onOk hook to implement custom pagination logic that handles relative @nextLink URLs
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IKeyValueListResult">Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IKeyValueListResult</see> from the remote call</param>
        /// <param name="returnNow">Determines if the rest of the onOk processing should be processed, or if the method should return instantly.</param>
        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.IKeyValueListResult> response, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            var result = response.GetAwaiter().GetResult();
            if (!string.IsNullOrEmpty(result.NextLink) && responseMessage?.RequestMessage != null)
            {
                // Check if nextLink is relative and convert to absolute
                if (!Uri.IsWellFormedUriString(result.NextLink, UriKind.Absolute))
                {
                    var baseUri = new Uri(responseMessage.RequestMessage.RequestUri.GetLeftPart(UriPartial.Authority));
                    var absoluteUri = new Uri(baseUri, result.NextLink);
                    
                    // Modify the result's NextLink 
                    if (result is Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.KeyValueListResult mutableResult)
                    {
                        mutableResult.NextLink = absoluteUri.ToString();
                    }
                }
            }
        }
    }
}