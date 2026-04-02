using Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime;
using Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Runtime.PowerShell;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Cmdlets
{
    public partial class GetAzPolicyMetadata_List
    {
        /// <summary>
        /// Holds amount returned from call(s) to check against Top parameter value.
        /// </summary>
        private long totalResponseCount = 0;

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyMetadataCollection">Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyMetadataCollection</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>
        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyMetadataCollection> response, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            // implementing this override in order to:
            // - prevent the nextLink from being called when we've reached the "Top" amount

            // if "Top" not present, return immediately
            if(!this.InvocationInformation.BoundParameters.ContainsKey("Top"))
            {
                return;
            }

            // else, check the amount returned 
            var result = response.GetAwaiter().GetResult();

            if (null == result.Value) 
            {
                return;
            }

            int responseCount = result.Value.Count;
            this.totalResponseCount += responseCount;

            // if totalResponseCount is less than Top then onOk will process the data and the next call will check the count
            if(this.totalResponseCount < this.Top)
            {
                return;
            }

            // if here, totalResponseCount must be greater than or equal to Top, so set the ref variable to true and process the objects
            returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(true);

            // also must make the nextLink null or the method may get caught in a loop
            _nextLink = null;

            var values = new System.Collections.Generic.List<System.Management.Automation.PSObject>();
            foreach (var value in result.Value)
            {
                values.Add(value.AddMultipleTypeNameIntoPSObject());
            }
            WriteObject(values, true);
        }
    }
}
