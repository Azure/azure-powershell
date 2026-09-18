using Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime;
using Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.PowerShell;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Cmdlets
{
    public partial class GetAzPolicyRemediationDeployment_List2
    {
        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediationDeploymentsListResult">Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediationDeploymentsListResult</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>
        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediationDeploymentsListResult> response, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            // implementing this override in order to:
            // - change the request method from GET to POST on subsquent paging calls, as the API expects a POST request for this cmdlet

            // set this immediately so the generated paging client call is never made - the get request is incorrect, it needs to be a post request
            returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(true);

            var result = response.GetAwaiter().GetResult();
            // response should be returning an array of some kind. +Pageable
            // pageable / value / nextLink
            if (null != result.Value)
            {
                if (0 == _responseSize && 1 == result.Value.Count)
                {
                    _firstResponse = result.Value[0];
                    _responseSize = 1;
                }
                else
                {
                    if (1 == _responseSize)
                    {
                        // Flush buffer
                        WriteObject(_firstResponse.AddMultipleTypeNameIntoPSObject());
                    }
                    var values = new System.Collections.Generic.List<System.Management.Automation.PSObject>();
                    foreach (var value in result.Value)
                    {
                        values.Add(value.AddMultipleTypeNameIntoPSObject());
                    }
                    WriteObject(values, true);
                    _responseSize = 2;
                }
            }
            _nextLink = result.NextLink;
            if (_isFirst)
            {
                _isFirst = false;
                while (!String.IsNullOrEmpty(_nextLink))
                {
                    if (responseMessage.RequestMessage is System.Net.Http.HttpRequestMessage requestMessage)
                    {
                        requestMessage = requestMessage.Clone(new global::System.Uri(_nextLink), Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Method.Post);
                        ((Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.Events.FollowingNextLink).Wait(); 
                        if (((Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.IEventListener)this).Token.IsCancellationRequested) { return; }
                        this.Client.RemediationsListDeploymentsAtResourceGroup_Call(requestMessage, onOk, onDefault, this, Pipeline).Wait();
                    }
                }
            }
        }
    }
}