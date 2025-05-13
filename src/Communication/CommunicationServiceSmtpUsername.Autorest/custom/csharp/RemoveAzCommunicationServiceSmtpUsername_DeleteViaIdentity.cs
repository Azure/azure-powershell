// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Cmdlets
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>Operation to delete a single SmtpUsername resource.</summary>
    /// <remarks>
    /// [OpenAPI] Delete=>DELETE:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Communication/communicationServices/{communicationServiceName}/smtpUsernames/{smtpUsername}"
    /// </remarks>
    public partial class RemoveAzCommunicationServiceSmtpUsername_DeleteViaIdentity
    {
        /// <summary>
        /// This method is called when an unexpected or default status code is received.
        /// It handles cases where the HTTP response is not 200 OK or 204 No Content.
        /// The method writes the response status code and an error indicating an invalid resource group or communication service name.
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onDefault method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>
        partial void overrideOnDefault(HttpResponseMessage responseMessage,
             global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.IErrorResponse> response,
             ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            WriteError(
                new global::System.Management.Automation.ErrorRecord(
                    new global::System.Exception("Unexpected error: Please make sure resource group and communication service are valid."),
                    responseMessage.StatusCode.ToString(),
                    global::System.Management.Automation.ErrorCategory.InvalidData,
                    null
                )
            );
            returnNow = global::System.Threading.Tasks.Task.FromResult(true);
        }

        /// <summary>
        /// This method is invoked when a 204 No Content response is received.
        /// It indicates that the SMTP Username deletion operation was successful or no content is available.
        /// The method writes a success message to the user and sets the returnNow flag to true, signaling that the operation is complete.
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="returnNow">/// Determines if the rest of the onNoContent method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>
        partial void overrideOnNoContent(global::System.Net.Http.HttpResponseMessage responseMessage, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            // Handle 204 No Content response
            WriteObject("The Smtp Username deleted successfully");
            returnNow = global::System.Threading.Tasks.Task.FromResult(true);
        }

        /// <summary>
        /// This method handles a 200 OK response.
        /// It indicates that the SMTP Username deletion was successfully completed.
        /// The method writes a success message and sets the returnNow flag to true, indicating successful completion.
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>
        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            // Handle 200 OK response
            WriteObject("The Smtp Username deleted successfully");
            returnNow = global::System.Threading.Tasks.Task.FromResult(true);
        }
    }
}
