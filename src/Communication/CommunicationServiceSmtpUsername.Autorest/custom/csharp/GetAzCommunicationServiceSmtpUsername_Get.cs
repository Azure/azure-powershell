// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Runtime.PowerShell;
    using Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Runtime.Cmdlets;
    using System;
    using System.Threading.Tasks;

    /// <summary>Get a SmtpUsernameResource.</summary>
    /// <remarks>
    /// [OpenAPI] Get=>GET:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Communication/communicationServices/{communicationServiceName}/smtpUsernames/{smtpUsername}"
    /// </remarks>
    public partial class GetAzCommunicationServiceSmtpUsername_Get
    {
        /// <summary>
        /// <c>overrideOnOk</c> Custom implementation of the method that is triggered when a successful response is received.
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.ISmtpUsernameResource">Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.ISmtpUsernameResource</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>
        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.CommunicationServiceSmtpUsername.Models.ISmtpUsernameResource> response, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            var result = response.ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result, true);
            returnNow = global::System.Threading.Tasks.Task.FromResult(true);
        }
    }
}   