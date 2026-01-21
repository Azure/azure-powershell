// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>
    /// Low-level API implementation for the disconnected operations service service.
    /// Disconnected operations service API.
    /// </summary>
    public partial class DisconnectedOperationsService
    {

        /// <summary>Get the resource</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="artifactName">The name of the Artifact</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ArtifactsGet(string subscriptionId, string resourceGroupName, string name, string imageName, string artifactName, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "/artifacts/"
                        + global::System.Uri.EscapeDataString(artifactName)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ArtifactsGet_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get the resource</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ArtifactsGetViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)/artifacts/(?<artifactName>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}/artifacts/{artifactName}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                var artifactName = _match.Groups["artifactName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "/artifacts/"
                        + artifactName
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ArtifactsGet_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get the resource</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact> ArtifactsGetViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)/artifacts/(?<artifactName>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}/artifacts/{artifactName}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                var artifactName = _match.Groups["artifactName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "/artifacts/"
                        + artifactName
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ArtifactsGetWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Get the resource</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="artifactName">The name of the Artifact</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact> ArtifactsGetWithResult(string subscriptionId, string resourceGroupName, string name, string imageName, string artifactName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "/artifacts/"
                        + global::System.Uri.EscapeDataString(artifactName)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ArtifactsGetWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref= "ArtifactsGetWithResult" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact> ArtifactsGetWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.Artifact.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "ArtifactsGet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ArtifactsGet_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.Artifact.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="ArtifactsGet" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="artifactName">The name of the Artifact</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ArtifactsGet_Validate(string subscriptionId, string resourceGroupName, string name, string imageName, string artifactName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
                await eventListener.AssertNotNull(nameof(imageName),imageName);
                await eventListener.AssertRegEx(nameof(imageName), imageName, @"^[a-zA-Z0-9-]{3,24}$");
                await eventListener.AssertNotNull(nameof(artifactName),artifactName);
                await eventListener.AssertRegEx(nameof(artifactName), artifactName, @"^[a-zA-Z0-9-]{3,24}$");
            }
        }

        /// <summary>List by parent</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ArtifactsListByParent(string subscriptionId, string resourceGroupName, string name, string imageName, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "/artifacts"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ArtifactsListByParent_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List by parent</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ArtifactsListByParentViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)/artifacts$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}/artifacts'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "/artifacts"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ArtifactsListByParent_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List by parent</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult> ArtifactsListByParentViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)/artifacts$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}/artifacts'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "/artifacts"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ArtifactsListByParentWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>List by parent</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult> ArtifactsListByParentWithResult(string subscriptionId, string resourceGroupName, string name, string imageName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "/artifacts"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ArtifactsListByParentWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref= "ArtifactsListByParentWithResult" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult> ArtifactsListByParentWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ArtifactListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "ArtifactsListByParent" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ArtifactsListByParent_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ArtifactListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="ArtifactsListByParent" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ArtifactsListByParent_Validate(string subscriptionId, string resourceGroupName, string name, string imageName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
                await eventListener.AssertNotNull(nameof(imageName),imageName);
                await eventListener.AssertRegEx(nameof(imageName), imageName, @"^[a-zA-Z0-9-]{3,24}$");
            }
        }

        /// <summary>Get artifact download link.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="artifactName">The name of the Artifact</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ArtifactsListDownloadUri(string subscriptionId, string resourceGroupName, string name, string imageName, string artifactName, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "/artifacts/"
                        + global::System.Uri.EscapeDataString(artifactName)
                        + "/listDownloadUri"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ArtifactsListDownloadUri_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get artifact download link.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ArtifactsListDownloadUriViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)/artifacts/(?<artifactName>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}/artifacts/{artifactName}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                var artifactName = _match.Groups["artifactName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "/artifacts/"
                        + artifactName
                        + "/listDownloadUri"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ArtifactsListDownloadUri_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get artifact download link.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult> ArtifactsListDownloadUriViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)/artifacts/(?<artifactName>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}/artifacts/{artifactName}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                var artifactName = _match.Groups["artifactName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "/artifacts/"
                        + artifactName
                        + "/listDownloadUri"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ArtifactsListDownloadUriWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Get artifact download link.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="artifactName">The name of the Artifact</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult> ArtifactsListDownloadUriWithResult(string subscriptionId, string resourceGroupName, string name, string imageName, string artifactName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "/artifacts/"
                        + global::System.Uri.EscapeDataString(artifactName)
                        + "/listDownloadUri"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ArtifactsListDownloadUriWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref= "ArtifactsListDownloadUriWithResult" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult> ArtifactsListDownloadUriWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ArtifactDownloadResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "ArtifactsListDownloadUri" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ArtifactsListDownloadUri_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ArtifactDownloadResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="ArtifactsListDownloadUri" /> method. Call this like the actual call, but you will get
        /// validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="artifactName">The name of the Artifact</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ArtifactsListDownloadUri_Validate(string subscriptionId, string resourceGroupName, string name, string imageName, string artifactName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
                await eventListener.AssertNotNull(nameof(imageName),imageName);
                await eventListener.AssertRegEx(nameof(imageName), imageName, @"^[a-zA-Z0-9-]{3,24}$");
                await eventListener.AssertNotNull(nameof(artifactName),artifactName);
                await eventListener.AssertRegEx(nameof(artifactName), artifactName, @"^[a-zA-Z0-9-]{3,24}$");
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="body">Resource create parameters.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsCreateOrUpdate(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation body, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsCreateOrUpdate_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="body">Resource create parameters.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsCreateOrUpdateViaIdentity(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation body, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsCreateOrUpdate_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="body">Resource create parameters.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsCreateOrUpdateViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation body, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsCreateOrUpdateWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="jsonString">Json string supplied to the DisconnectedOperationsCreateOrUpdate operation</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsCreateOrUpdateViaJsonString(string subscriptionId, string resourceGroupName, string name, global::System.String jsonString, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(jsonString, global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsCreateOrUpdate_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="jsonString">Json string supplied to the DisconnectedOperationsCreateOrUpdate operation</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsCreateOrUpdateViaJsonStringWithResult(string subscriptionId, string resourceGroupName, string name, global::System.String jsonString, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(jsonString, global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsCreateOrUpdateWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="body">Resource create parameters.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsCreateOrUpdateWithResult(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation body, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Put, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsCreateOrUpdateWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsCreateOrUpdateWithResult" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsCreateOrUpdateWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    // this operation supports x-ms-long-running-operation
                    var _originalUri = request.RequestUri.AbsoluteUri;
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 0); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    // declared final-state-via: azure-async-operation
                    var asyncOperation = _response.GetFirstHeader(@"Azure-AsyncOperation");
                    var location = _response.GetFirstHeader(@"Location");
                    var operationLocation = _response.GetFirstHeader(@"Operation-Location");
                    while (request.Method == System.Net.Http.HttpMethod.Put && _response.StatusCode == global::System.Net.HttpStatusCode.OK || _response.StatusCode == global::System.Net.HttpStatusCode.Created || _response.StatusCode == global::System.Net.HttpStatusCode.Accepted )
                    {
                        // delay before making the next polling request
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.DelayBeforePolling, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }

                        // while we wait, let's grab the headers and get ready to poll.
                        if (!System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Azure-AsyncOperation"))) {
                            asyncOperation = _response.GetFirstHeader(@"Azure-AsyncOperation");
                        }
                        if (!global::System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Location"))) {
                            location = _response.GetFirstHeader(@"Location");
                        }
                        if (!global::System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Operation-Location"))) {
                            operationLocation = _response.GetFirstHeader(@"Operation-Location");
                        }
                        var _uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? global::System.String.IsNullOrEmpty(operationLocation) ? _originalUri : operationLocation : location : asyncOperation;
                        request = request.CloneAndDispose(new global::System.Uri(_uri), Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get);

                        // and let's look at the current response body and see if we have some information we can give back to the listener
                        var content = await _response.Content.ReadAsStringAsync();

                        // drop the old response
                        _response?.Dispose();

                        // make the polling call
                        _response = await sender.SendAsync(request, eventListener);
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Polling, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }

                          // if we got back an OK, take a peek inside and see if it's done
                          if( _response.StatusCode == global::System.Net.HttpStatusCode.OK)
                          {
                              var error = false;
                              try {
                                  if( Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(await _response.Content.ReadAsStringAsync()) is Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json)
                                  {
                                      var state = json.Property("properties")?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("provisioningState") ?? json.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("status");
                                      if( state is null )
                                      {
                                          // the body doesn't contain any information that has the state of the LRO
                                          // we're going to just get out, and let the consumer have the result
                                          break;
                                      }

                                      switch( state?.ToString()?.ToLower() )
                                      {
                                        case "failed":
                                            error = true;
                                            break;
                                        case "succeeded":
                                        case "canceled":
                                          // we're done polling.
                                          break;

                                        default:
                                          // need to keep polling!
                                          _response.StatusCode = global::System.Net.HttpStatusCode.Created;
                                          continue;
                                      }
                                  }
                              } catch {
                                  // if we run into a problem peeking into the result,
                                  // we really don't want to do anything special.
                              }
                              if (error) {
                                  throw new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.UndeclaredResponseException(_response);
                              }
                          }

                        // check for terminal status code
                        if (_response.StatusCode == global::System.Net.HttpStatusCode.Created || _response.StatusCode == global::System.Net.HttpStatusCode.Accepted )
                        {
                            continue;
                        }
                        // we are done polling, do a request on final target?
                        // create a new request with the final uri
                        request = request.CloneAndDispose(new global::System.Uri(_originalUri), Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get);

                        // drop the old response
                        _response?.Dispose();

                        // make the final call
                        _response = await sender.SendAsync(request,  eventListener);
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Polling, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                        break;
                    }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperation.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsCreateOrUpdate" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsCreateOrUpdate_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    // this operation supports x-ms-long-running-operation
                    var _originalUri = request.RequestUri.AbsoluteUri;
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 0); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    // declared final-state-via: azure-async-operation
                    var asyncOperation = _response.GetFirstHeader(@"Azure-AsyncOperation");
                    var location = _response.GetFirstHeader(@"Location");
                    var operationLocation = _response.GetFirstHeader(@"Operation-Location");
                    while (request.Method == System.Net.Http.HttpMethod.Put && _response.StatusCode == global::System.Net.HttpStatusCode.OK || _response.StatusCode == global::System.Net.HttpStatusCode.Created || _response.StatusCode == global::System.Net.HttpStatusCode.Accepted )
                    {
                        // delay before making the next polling request
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.DelayBeforePolling, _response); if( eventListener.Token.IsCancellationRequested ) { return; }

                        // while we wait, let's grab the headers and get ready to poll.
                        if (!System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Azure-AsyncOperation"))) {
                            asyncOperation = _response.GetFirstHeader(@"Azure-AsyncOperation");
                        }
                        if (!global::System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Location"))) {
                            location = _response.GetFirstHeader(@"Location");
                        }
                        if (!global::System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Operation-Location"))) {
                            operationLocation = _response.GetFirstHeader(@"Operation-Location");
                        }
                        var _uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? global::System.String.IsNullOrEmpty(operationLocation) ? _originalUri : operationLocation : location : asyncOperation;
                        request = request.CloneAndDispose(new global::System.Uri(_uri), Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get);

                        // and let's look at the current response body and see if we have some information we can give back to the listener
                        var content = await _response.Content.ReadAsStringAsync();

                        // drop the old response
                        _response?.Dispose();

                        // make the polling call
                        _response = await sender.SendAsync(request, eventListener);
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Polling, _response); if( eventListener.Token.IsCancellationRequested ) { return; }

                          // if we got back an OK, take a peek inside and see if it's done
                          if( _response.StatusCode == global::System.Net.HttpStatusCode.OK)
                          {
                              var error = false;
                              try {
                                  if( Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(await _response.Content.ReadAsStringAsync()) is Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json)
                                  {
                                      var state = json.Property("properties")?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("provisioningState") ?? json.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("status");
                                      if( state is null )
                                      {
                                          // the body doesn't contain any information that has the state of the LRO
                                          // we're going to just get out, and let the consumer have the result
                                          break;
                                      }

                                      switch( state?.ToString()?.ToLower() )
                                      {
                                        case "failed":
                                            error = true;
                                            break;
                                        case "succeeded":
                                        case "canceled":
                                          // we're done polling.
                                          break;

                                        default:
                                          // need to keep polling!
                                          _response.StatusCode = global::System.Net.HttpStatusCode.Created;
                                          continue;
                                      }
                                  }
                              } catch {
                                  // if we run into a problem peeking into the result,
                                  // we really don't want to do anything special.
                              }
                              if (error) {
                                  throw new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.UndeclaredResponseException(_response);
                              }
                          }

                        // check for terminal status code
                        if (_response.StatusCode == global::System.Net.HttpStatusCode.Created || _response.StatusCode == global::System.Net.HttpStatusCode.Accepted )
                        {
                            continue;
                        }
                        // we are done polling, do a request on final target?
                        // create a new request with the final uri
                        request = request.CloneAndDispose(new global::System.Uri(_originalUri), Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get);

                        // drop the old response
                        _response?.Dispose();

                        // make the final call
                        _response = await sender.SendAsync(request,  eventListener);
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Polling, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                        break;
                    }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperation.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="DisconnectedOperationsCreateOrUpdate" /> method. Call this like the actual call, but
        /// you will get validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="body">Resource create parameters.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsCreateOrUpdate_Validate(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation body, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }

        /// <summary>Delete a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="onNoContent">a delegate that is called when the remote service returns 204 (NoContent).</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsDelete(string subscriptionId, string resourceGroupName, string name, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task> onNoContent, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Delete, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsDelete_Call (request, onNoContent,onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Delete a DisconnectedOperation</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onNoContent">a delegate that is called when the remote service returns 204 (NoContent).</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsDeleteViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task> onNoContent, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Delete, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsDelete_Call (request, onNoContent,onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref= "DisconnectedOperationsDelete" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onNoContent">a delegate that is called when the remote service returns 204 (NoContent).</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsDelete_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task> onNoContent, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    // this operation supports x-ms-long-running-operation
                    var _originalUri = request.RequestUri.AbsoluteUri;
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 0); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    // declared final-state-via: location
                    var _finalUri = _response.GetFirstHeader(@"Location");
                    var asyncOperation = _response.GetFirstHeader(@"Azure-AsyncOperation");
                    var location = _response.GetFirstHeader(@"Location");
                    var operationLocation = _response.GetFirstHeader(@"Operation-Location");
                    while (request.Method == System.Net.Http.HttpMethod.Put && _response.StatusCode == global::System.Net.HttpStatusCode.OK || _response.StatusCode == global::System.Net.HttpStatusCode.Created || _response.StatusCode == global::System.Net.HttpStatusCode.Accepted )
                    {
                        // delay before making the next polling request
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.DelayBeforePolling, _response); if( eventListener.Token.IsCancellationRequested ) { return; }

                        // while we wait, let's grab the headers and get ready to poll.
                        if (!System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Azure-AsyncOperation"))) {
                            asyncOperation = _response.GetFirstHeader(@"Azure-AsyncOperation");
                        }
                        if (!global::System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Location"))) {
                            location = _response.GetFirstHeader(@"Location");
                        }
                        if (!global::System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Operation-Location"))) {
                            operationLocation = _response.GetFirstHeader(@"Operation-Location");
                        }
                        var _uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? global::System.String.IsNullOrEmpty(operationLocation) ? _originalUri : operationLocation : location : asyncOperation;
                        request = request.CloneAndDispose(new global::System.Uri(_uri), Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get);

                        // and let's look at the current response body and see if we have some information we can give back to the listener
                        var content = await _response.Content.ReadAsStringAsync();

                        // drop the old response
                        _response?.Dispose();

                        // make the polling call
                        _response = await sender.SendAsync(request, eventListener);
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Polling, _response); if( eventListener.Token.IsCancellationRequested ) { return; }

                          // if we got back an OK, take a peek inside and see if it's done
                          if( _response.StatusCode == global::System.Net.HttpStatusCode.OK)
                          {
                              var error = false;
                              try {
                                  if( Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(await _response.Content.ReadAsStringAsync()) is Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json)
                                  {
                                      var state = json.Property("properties")?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("provisioningState") ?? json.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("status");
                                      if( state is null )
                                      {
                                          // the body doesn't contain any information that has the state of the LRO
                                          // we're going to just get out, and let the consumer have the result
                                          break;
                                      }

                                      switch( state?.ToString()?.ToLower() )
                                      {
                                        case "failed":
                                            error = true;
                                            break;
                                        case "succeeded":
                                        case "canceled":
                                          // we're done polling.
                                          break;

                                        default:
                                          // need to keep polling!
                                          _response.StatusCode = global::System.Net.HttpStatusCode.Created;
                                          continue;
                                      }
                                  }
                              } catch {
                                  // if we run into a problem peeking into the result,
                                  // we really don't want to do anything special.
                              }
                              if (error) {
                                  throw new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.UndeclaredResponseException(_response);
                              }
                          }

                        // check for terminal status code
                        if (_response.StatusCode == global::System.Net.HttpStatusCode.Created || _response.StatusCode == global::System.Net.HttpStatusCode.Accepted )
                        {
                            continue;
                        }
                        // we are done polling, do a request on final target?
                        // create a new request with the final uri
                        request = request.CloneAndDispose(new global::System.Uri(_finalUri), Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get);

                        // drop the old response
                        _response?.Dispose();

                        // make the final call
                        _response = await sender.SendAsync(request,  eventListener);
                        await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Polling, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                        break;
                    }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response);
                            break;
                        }
                        case global::System.Net.HttpStatusCode.NoContent:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onNoContent(_response);
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="DisconnectedOperationsDelete" /> method. Call this like the actual call, but you will
        /// get validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsDelete_Validate(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
            }
        }

        /// <summary>Get a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsGet(string subscriptionId, string resourceGroupName, string name, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsGet_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get a DisconnectedOperation</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsGetViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsGet_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get a DisconnectedOperation</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsGetViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsGetWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Get a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsGetWithResult(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsGetWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsGetWithResult" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsGetWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperation.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "DisconnectedOperationsGet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsGet_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperation.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="DisconnectedOperationsGet" /> method. Call this like the actual call, but you will get
        /// validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsGet_Validate(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
            }
        }

        /// <summary>List DisconnectedOperation resources by resource group</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsListByResourceGroup(string subscriptionId, string resourceGroupName, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsListByResourceGroup_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List DisconnectedOperation resources by resource group</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsListByResourceGroupViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsListByResourceGroup_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List DisconnectedOperation resources by resource group</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult> DisconnectedOperationsListByResourceGroupViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsListByResourceGroupWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>List DisconnectedOperation resources by resource group</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult> DisconnectedOperationsListByResourceGroupWithResult(string subscriptionId, string resourceGroupName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsListByResourceGroupWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsListByResourceGroupWithResult" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult> DisconnectedOperationsListByResourceGroupWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsListByResourceGroup" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsListByResourceGroup_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="DisconnectedOperationsListByResourceGroup" /> method. Call this like the actual call,
        /// but you will get validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsListByResourceGroup_Validate(string subscriptionId, string resourceGroupName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
            }
        }

        /// <summary>List DisconnectedOperation resources by subscription ID</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsListBySubscription(string subscriptionId, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/providers/Microsoft.Edge/disconnectedOperations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsListBySubscription_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List DisconnectedOperation resources by subscription ID</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsListBySubscriptionViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/providers/Microsoft.Edge/disconnectedOperations$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/providers/Microsoft.Edge/disconnectedOperations'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/providers/Microsoft.Edge/disconnectedOperations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsListBySubscription_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List DisconnectedOperation resources by subscription ID</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult> DisconnectedOperationsListBySubscriptionViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/providers/Microsoft.Edge/disconnectedOperations$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/providers/Microsoft.Edge/disconnectedOperations'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/providers/Microsoft.Edge/disconnectedOperations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsListBySubscriptionWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>List DisconnectedOperation resources by subscription ID</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult> DisconnectedOperationsListBySubscriptionWithResult(string subscriptionId, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/providers/Microsoft.Edge/disconnectedOperations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsListBySubscriptionWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsListBySubscriptionWithResult" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult> DisconnectedOperationsListBySubscriptionWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsListBySubscription" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsListBySubscription_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="DisconnectedOperationsListBySubscription" /> method. Call this like the actual call,
        /// but you will get validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsListBySubscription_Validate(string subscriptionId, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
            }
        }

        /// <summary>get deployment manifest.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsListDeploymentManifest(string subscriptionId, string resourceGroupName, string name, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/listDeploymentManifest"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsListDeploymentManifest_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>get deployment manifest.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsListDeploymentManifestViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/listDeploymentManifest"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsListDeploymentManifest_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>get deployment manifest.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest> DisconnectedOperationsListDeploymentManifestViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/listDeploymentManifest"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsListDeploymentManifestWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>get deployment manifest.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest> DisconnectedOperationsListDeploymentManifestWithResult(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/listDeploymentManifest"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsListDeploymentManifestWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsListDeploymentManifestWithResult" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest> DisconnectedOperationsListDeploymentManifestWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsListDeploymentManifest" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsListDeploymentManifest_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationDeploymentManifest.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="DisconnectedOperationsListDeploymentManifest" /> method. Call this like the actual call,
        /// but you will get validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsListDeploymentManifest_Validate(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="body">The resource properties to be updated.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsUpdate(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdate body, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Patch, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsUpdate_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="body">The resource properties to be updated.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsUpdateViaIdentity(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdate body, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Patch, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsUpdate_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="body">The resource properties to be updated.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsUpdateViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdate body, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Patch, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsUpdateWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="jsonString">Json string supplied to the DisconnectedOperationsUpdate operation</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task DisconnectedOperationsUpdateViaJsonString(string subscriptionId, string resourceGroupName, string name, global::System.String jsonString, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Patch, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(jsonString, global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.DisconnectedOperationsUpdate_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="jsonString">Json string supplied to the DisconnectedOperationsUpdate operation</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsUpdateViaJsonStringWithResult(string subscriptionId, string resourceGroupName, string name, global::System.String jsonString, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Patch, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(jsonString, global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsUpdateWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>update a DisconnectedOperation</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="body">The resource properties to be updated.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsUpdateWithResult(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdate body, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Patch, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.DisconnectedOperationsUpdateWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "DisconnectedOperationsUpdateWithResult" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation> DisconnectedOperationsUpdateWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperation.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "DisconnectedOperationsUpdate" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsUpdate_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperation.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="DisconnectedOperationsUpdate" /> method. Call this like the actual call, but you will
        /// get validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="body">The resource properties to be updated.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task DisconnectedOperationsUpdate_Validate(string subscriptionId, string resourceGroupName, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdate body, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }

        /// <summary>Get the resource.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ImagesGet(string subscriptionId, string resourceGroupName, string name, string imageName, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ImagesGet_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get the resource.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ImagesGetViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ImagesGet_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get the resource.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage> ImagesGetViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ImagesGetWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Get the resource.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage> ImagesGetWithResult(string subscriptionId, string resourceGroupName, string name, string imageName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ImagesGetWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref= "ImagesGetWithResult" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage> ImagesGetWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.Image.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "ImagesGet" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ImagesGet_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.Image.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="ImagesGet" /> method. Call this like the actual call, but you will get validation events
        /// back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ImagesGet_Validate(string subscriptionId, string resourceGroupName, string name, string imageName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
                await eventListener.AssertNotNull(nameof(imageName),imageName);
                await eventListener.AssertRegEx(nameof(imageName), imageName, @"^[a-zA-Z0-9-]{3,24}$");
            }
        }

        /// <summary>List by disconnected operation.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="Filter">Filter the result list using the given expression.</param>
        /// <param name="Top">The number of result items to return.</param>
        /// <param name="Skip">The number of result items to skip.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ImagesListByDisconnectedOperation(string subscriptionId, string resourceGroupName, string name, string Filter, int? Top, int? Skip, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        + "&"
                        + (string.IsNullOrEmpty(Filter) ? global::System.String.Empty : "$filter=" + global::System.Uri.EscapeDataString(Filter))
                        + "&"
                        + (null == Top ? global::System.String.Empty : "$top=" + global::System.Uri.EscapeDataString(Top.ToString()))
                        + "&"
                        + (null == Skip ? global::System.String.Empty : "$skip=" + global::System.Uri.EscapeDataString(Skip.ToString()))
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ImagesListByDisconnectedOperation_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List by disconnected operation.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="Filter">Filter the result list using the given expression.</param>
        /// <param name="Top">The number of result items to return.</param>
        /// <param name="Skip">The number of result items to skip.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ImagesListByDisconnectedOperationViaIdentity(global::System.String viaIdentity, string Filter, int? Top, int? Skip, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        + "&"
                        + (string.IsNullOrEmpty(Filter) ? global::System.String.Empty : "$filter=" + global::System.Uri.EscapeDataString(Filter))
                        + "&"
                        + (null == Top ? global::System.String.Empty : "$top=" + global::System.Uri.EscapeDataString(Top.ToString()))
                        + "&"
                        + (null == Skip ? global::System.String.Empty : "$skip=" + global::System.Uri.EscapeDataString(Skip.ToString()))
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ImagesListByDisconnectedOperation_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List by disconnected operation.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="Filter">Filter the result list using the given expression.</param>
        /// <param name="Top">The number of result items to return.</param>
        /// <param name="Skip">The number of result items to skip.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult> ImagesListByDisconnectedOperationViaIdentityWithResult(global::System.String viaIdentity, string Filter, int? Top, int? Skip, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        + "&"
                        + (string.IsNullOrEmpty(Filter) ? global::System.String.Empty : "$filter=" + global::System.Uri.EscapeDataString(Filter))
                        + "&"
                        + (null == Top ? global::System.String.Empty : "$top=" + global::System.Uri.EscapeDataString(Top.ToString()))
                        + "&"
                        + (null == Skip ? global::System.String.Empty : "$skip=" + global::System.Uri.EscapeDataString(Skip.ToString()))
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ImagesListByDisconnectedOperationWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>List by disconnected operation.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="Filter">Filter the result list using the given expression.</param>
        /// <param name="Top">The number of result items to return.</param>
        /// <param name="Skip">The number of result items to skip.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult> ImagesListByDisconnectedOperationWithResult(string subscriptionId, string resourceGroupName, string name, string Filter, int? Top, int? Skip, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        + "&"
                        + (string.IsNullOrEmpty(Filter) ? global::System.String.Empty : "$filter=" + global::System.Uri.EscapeDataString(Filter))
                        + "&"
                        + (null == Top ? global::System.String.Empty : "$top=" + global::System.Uri.EscapeDataString(Top.ToString()))
                        + "&"
                        + (null == Skip ? global::System.String.Empty : "$skip=" + global::System.Uri.EscapeDataString(Skip.ToString()))
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ImagesListByDisconnectedOperationWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "ImagesListByDisconnectedOperationWithResult" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult> ImagesListByDisconnectedOperationWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "ImagesListByDisconnectedOperation" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ImagesListByDisconnectedOperation_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="ImagesListByDisconnectedOperation" /> method. Call this like the actual call, but you
        /// will get validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="Filter">Filter the result list using the given expression.</param>
        /// <param name="Top">The number of result items to return.</param>
        /// <param name="Skip">The number of result items to skip.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ImagesListByDisconnectedOperation_Validate(string subscriptionId, string resourceGroupName, string Filter, int? Top, int? Skip, string name, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(Filter),Filter);
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
            }
        }

        /// <summary>Get the URI to download the image.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ImagesListDownloadUri(string subscriptionId, string resourceGroupName, string name, string imageName, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "/listDownloadUri"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ImagesListDownloadUri_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get the URI to download the image.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task ImagesListDownloadUriViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "/listDownloadUri"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.ImagesListDownloadUri_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>Get the URI to download the image.</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult> ImagesListDownloadUriViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Edge/disconnectedOperations/(?<name>[^/]+)/images/(?<imageName>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/images/{imageName}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var resourceGroupName = _match.Groups["resourceGroupName"].Value;
                var name = _match.Groups["name"].Value;
                var imageName = _match.Groups["imageName"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/resourceGroups/"
                        + resourceGroupName
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + name
                        + "/images/"
                        + imageName
                        + "/listDownloadUri"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ImagesListDownloadUriWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Get the URI to download the image.</summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult> ImagesListDownloadUriWithResult(string subscriptionId, string resourceGroupName, string name, string imageName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2025-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/resourceGroups/"
                        + global::System.Uri.EscapeDataString(resourceGroupName)
                        + "/providers/Microsoft.Edge/disconnectedOperations/"
                        + global::System.Uri.EscapeDataString(name)
                        + "/images/"
                        + global::System.Uri.EscapeDataString(imageName)
                        + "/listDownloadUri"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.ImagesListDownloadUriWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref= "ImagesListDownloadUriWithResult" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult> ImagesListDownloadUriWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageDownloadResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(_response, await _result);
                                throw ex;
                            }
                            else
                            {
                                throw new global::System.Exception($"[{code}] : {message}");
                            }
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "ImagesListDownloadUri" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ImagesListDownloadUri_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageDownloadResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="ImagesListDownloadUri" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="resourceGroupName">The name of the resource group. The name is case insensitive.</param>
        /// <param name="name">Name of the resource</param>
        /// <param name="imageName">The name of the Image</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task ImagesListDownloadUri_Validate(string subscriptionId, string resourceGroupName, string name, string imageName, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(resourceGroupName),resourceGroupName);
                await eventListener.AssertMinimumLength(nameof(resourceGroupName),resourceGroupName,1);
                await eventListener.AssertMaximumLength(nameof(resourceGroupName),resourceGroupName,90);
                await eventListener.AssertRegEx(nameof(resourceGroupName), resourceGroupName, @"^[-\w\._\(\)]+$");
                await eventListener.AssertNotNull(nameof(name),name);
                await eventListener.AssertRegEx(nameof(name), name, @"^[a-zA-Z0-9][a-zA-Z0-9-_]{2,22}[a-zA-Z0-9]$");
                await eventListener.AssertNotNull(nameof(imageName),imageName);
                await eventListener.AssertRegEx(nameof(imageName), imageName, @"^[a-zA-Z0-9-]{3,24}$");
            }
        }
    }
}