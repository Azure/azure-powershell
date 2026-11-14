// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>
    /// Low-level API implementation for the AIInfraOptimization service.
    /// Microsoft.AIInfraOptimization Resource Provider management API.
    /// </summary>
    public partial class AiInfraOptimization
    {

        /// <summary>List the operations for the provider</summary>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task OperationsList(global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/providers/Microsoft.AIInfraOptimization/operations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.OperationsList_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List the operations for the provider</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task OperationsListViaIdentity(global::System.String viaIdentity, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/providers/Microsoft.AIInfraOptimization/operations$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/providers/Microsoft.AIInfraOptimization/operations'");
                }

                // replace URI parameters with values from identity
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/providers/Microsoft.AIInfraOptimization/operations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.OperationsList_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>List the operations for the provider</summary>
        /// <param name="viaIdentity"></param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult> OperationsListViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/providers/Microsoft.AIInfraOptimization/operations$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/providers/Microsoft.AIInfraOptimization/operations'");
                }

                // replace URI parameters with values from identity
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/providers/Microsoft.AIInfraOptimization/operations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.OperationsListWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>List the operations for the provider</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult> OperationsListWithResult(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/providers/Microsoft.AIInfraOptimization/operations"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Get, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.OperationsListWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>Actual wire call for <see cref= "OperationsListWithResult" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult> OperationsListWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.OperationListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>(_response, await _result);
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
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "OperationsList" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task OperationsList_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IOperationListResult>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.OperationListResult.FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="OperationsList" /> method. Call this like the actual call, but you will get validation
        /// events back.
        /// </summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task OperationsList_Validate(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {

            }
        }

        /// <summary>
        /// Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="location">The name of the Azure region.</param>
        /// <param name="body">The request body</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task RecommendationsRecommendVMSku(string subscriptionId, string location, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest body, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/providers/Microsoft.AIInfraOptimization/locations/"
                        + global::System.Uri.EscapeDataString(location)
                        + "/recommendVmSku"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.RecommendationsRecommendVMSku_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>
        /// Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.
        /// </summary>
        /// <param name="viaIdentity"></param>
        /// <param name="body">The request body</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task RecommendationsRecommendVMSkuViaIdentity(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest body, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/providers/Microsoft.AIInfraOptimization/locations/(?<location>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/providers/Microsoft.AIInfraOptimization/locations/{location}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var location = _match.Groups["location"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/providers/Microsoft.AIInfraOptimization/locations/"
                        + location
                        + "/recommendVmSku"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.RecommendationsRecommendVMSku_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>
        /// Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.
        /// </summary>
        /// <param name="viaIdentity"></param>
        /// <param name="body">The request body</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse> RecommendationsRecommendVMSkuViaIdentityWithResult(global::System.String viaIdentity, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest body, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // verify that Identity format is an exact match for uri

                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/providers/Microsoft.AIInfraOptimization/locations/(?<location>[^/]+)$", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(viaIdentity);
                if (!_match.Success)
                {
                    throw new global::System.Exception("Invalid identity for URI '/subscriptions/{subscriptionId}/providers/Microsoft.AIInfraOptimization/locations/{location}'");
                }

                // replace URI parameters with values from identity
                var subscriptionId = _match.Groups["subscriptionId"].Value;
                var location = _match.Groups["location"].Value;
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + subscriptionId
                        + "/providers/Microsoft.AIInfraOptimization/locations/"
                        + location
                        + "/recommendVmSku"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.RecommendationsRecommendVMSkuWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="location">The name of the Azure region.</param>
        /// <param name="jsonString">Json string supplied to the RecommendationsRecommendVMSku operation</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task RecommendationsRecommendVMSkuViaJsonString(string subscriptionId, string location, global::System.String jsonString, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/providers/Microsoft.AIInfraOptimization/locations/"
                        + global::System.Uri.EscapeDataString(location)
                        + "/recommendVmSku"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(jsonString, global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return; }
                // make the call
                await this.RecommendationsRecommendVMSku_Call (request, onOk,onDefault,eventListener,sender);
            }
        }

        /// <summary>
        /// Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="location">The name of the Azure region.</param>
        /// <param name="jsonString">Json string supplied to the RecommendationsRecommendVMSku operation</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse> RecommendationsRecommendVMSkuViaJsonStringWithResult(string subscriptionId, string location, global::System.String jsonString, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/providers/Microsoft.AIInfraOptimization/locations/"
                        + global::System.Uri.EscapeDataString(location)
                        + "/recommendVmSku"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(jsonString, global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.RecommendationsRecommendVMSkuWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="location">The name of the Azure region.</param>
        /// <param name="body">The request body</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse> RecommendationsRecommendVMSkuWithResult(string subscriptionId, string location, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest body, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode serializationMode = Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeUpdate)
        {
            var apiVersion = @"2026-06-01-preview";
            // Constant Parameters
            using( NoSynchronizationContext )
            {
                // construct URL
                var pathAndQuery = global::System.Text.RegularExpressions.Regex.Replace(
                        "/subscriptions/"
                        + global::System.Uri.EscapeDataString(subscriptionId)
                        + "/providers/Microsoft.AIInfraOptimization/locations/"
                        + global::System.Uri.EscapeDataString(location)
                        + "/recommendVmSku"
                        + "?"
                        + "api-version=" + global::System.Uri.EscapeDataString(apiVersion)
                        ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2");

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.URLCreated, pathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                // generate request object
                var _url = new global::System.Uri($"https://management.azure.com{pathAndQuery}");
                var request =  new global::System.Net.Http.HttpRequestMessage(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Method.Post, _url);
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.RequestCreated, request.RequestUri.PathAndQuery); if( eventListener.Token.IsCancellationRequested ) { return null; }

                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.HeaderParametersAdded); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // set body content
                request.Content = new global::System.Net.Http.StringContent(null != body ? body.ToJson(null, serializationMode).ToString() : @"{}", global::System.Text.Encoding.UTF8);
                request.Content.Headers.ContentType = global::System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BodyContentSet); if( eventListener.Token.IsCancellationRequested ) { return null; }
                // make the call
                return await this.RecommendationsRecommendVMSkuWithResult_Call (request, eventListener,sender);
            }
        }

        /// <summary>
        /// Actual wire call for <see cref= "RecommendationsRecommendVMSkuWithResult" /> method.
        /// </summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse>"
        /// /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse> RecommendationsRecommendVMSkuWithResult_Call(global::System.Net.Http.HttpRequestMessage request, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return null; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(body.Result)) );
                            return await _result;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return null; }
                            var _result = _response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(body.Result)) );
                            // Error Response : default
                            var code = (await _result)?.Code;
                            var message = (await _result)?.Message;
                            if ((null == code || null == message))
                            {
                                // Unrecognized Response. Create an error record based on what we have.
                                var ex = new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>(_response, await _result);
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
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>Actual wire call for <see cref= "RecommendationsRecommendVMSku" /> method.</summary>
        /// <param name="request">the prepared HttpRequestMessage to send.</param>
        /// <param name="onOk">a delegate that is called when the remote service returns 200 (OK).</param>
        /// <param name="onDefault">a delegate that is called when the remote service returns default (any response code not handled
        /// elsewhere).</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <param name="sender">an instance of an Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync pipeline to use to make the request.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task RecommendationsRecommendVMSku_Call(global::System.Net.Http.HttpRequestMessage request, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse>, global::System.Threading.Tasks.Task> onOk, global::System.Func<global::System.Net.Http.HttpResponseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>, global::System.Threading.Tasks.Task> onDefault, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.ISendAsync sender)
        {
            using( NoSynchronizationContext )
            {
                global::System.Net.Http.HttpResponseMessage _response = null;
                try
                {
                    var sendTask = sender.SendAsync(request, eventListener);
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeCall, request); if( eventListener.Token.IsCancellationRequested ) { return; }
                    _response = await sendTask;
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.ResponseCreated, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Progress, "intentional placeholder", 100); if( eventListener.Token.IsCancellationRequested ) { return; }
                    var _contentType = _response.Content.Headers.ContentType?.MediaType;

                    switch ( _response.StatusCode )
                    {
                        case global::System.Net.HttpStatusCode.OK:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onOk(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                        default:
                        {
                            await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.BeforeResponseDispatch, _response); if( eventListener.Token.IsCancellationRequested ) { return; }
                            await onDefault(_response,_response.Content.ReadAsStringAsync().ContinueWith( body => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.ErrorResponse.FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(body.Result)) ));
                            break;
                        }
                    }
                }
                finally
                {
                    // finally statements
                    await eventListener.Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Finally, request, _response);
                    _response?.Dispose();
                    request?.Dispose();
                }
            }
        }

        /// <summary>
        /// Validation method for <see cref="RecommendationsRecommendVMSku" /> method. Call this like the actual call, but you will
        /// get validation events back.
        /// </summary>
        /// <param name="subscriptionId">The ID of the target subscription. The value must be an UUID.</param>
        /// <param name="location">The name of the Azure region.</param>
        /// <param name="body">The request body</param>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> instance that will receive events.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the response is completed.
        /// </returns>
        internal async global::System.Threading.Tasks.Task RecommendationsRecommendVMSku_Validate(string subscriptionId, string location, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest body, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener eventListener)
        {
            using( NoSynchronizationContext )
            {
                await eventListener.AssertNotNull(nameof(subscriptionId),subscriptionId);
                await eventListener.AssertMinimumLength(nameof(subscriptionId),subscriptionId,1);
                await eventListener.AssertNotNull(nameof(location),location);
                await eventListener.AssertMinimumLength(nameof(location),location,1);
                await eventListener.AssertNotNull(nameof(body), body);
                await eventListener.AssertObjectIsValid(nameof(body), body);
            }
        }
    }
}