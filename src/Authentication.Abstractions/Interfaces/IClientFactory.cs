// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// A factory for authenticated and configured Http, Hyak, and AutoRest clients
    /// </summary>
    public interface IClientFactory: IHyakClientFactory
    {

        /// <summary>
        /// Create a properly configured HttpEndpoint, using the given named target endpoint and http credentials
        /// </summary>
        /// <param name="endpoint">The named endpoint to target</param>
        /// <param name="credentials">The cerdentials to use with the client</param>
        /// <returns>An http client properly configured for use with Azure PowerShell</returns>
        HttpClient CreateHttpClient(string endpoint, ICredentials credentials);

        /// <summary>
        /// Create a properly configured HttpEndpoint, using the given named target endpoint and http base handler
        /// </summary>
        /// <param name="endpoint">The named endpoint to target</param>
        /// <param name="effectiveHandler">The handler at the base of the handler stack</param>
        /// <returns>An http client properly configured for use with Azure PowerShell</returns>
        HttpClient CreateHttpClient(string endpoint, HttpMessageHandler effectiveHandler);

        /// <summary>
        /// Add the given custom client configuration to all clients created through this factory
        /// </summary>
        /// <param name="action">The client configuration to add</param>
        void AddAction(IClientAction action);

        /// <summary>
        /// Remove the given custom client configuration, so it is no longer used with clients created using this factory
        /// </summary>
        /// <param name="actionType"></param>
        void RemoveAction(Type actionType);

        /// <summary>
        /// Add the given delegating handler to all clients created by this factory
        /// </summary>
        /// <typeparam name="T">The type of the handler</typeparam>
        /// <param name="handler">The type of the handler</param>
        void AddHandler<T>(T handler) where T : DelegatingHandler, ICloneable;

        /// <summary>
        /// Remove the given custom handler, so it is no longer used with clients created from this factory
        /// </summary>
        /// <param name="handlerType"></param>
        void RemoveHandler(Type handlerType);

        /// <summary>
        /// Adds user agent to UserAgents collection with empty version.
        /// </summary>
        /// <param name="productName">Product name.</param>
        void AddUserAgent(string productName);

        /// <summary>
        /// Gets the custom handlers.
        /// </summary>
        /// <returns>An array of custom handlers</returns>
        DelegatingHandler[] GetCustomHandlers();

        /// <summary>
        /// Adds user agent to UserAgents collection.
        /// </summary>
        /// <param name="productName">Product name.</param>
        /// <param name="productVersion">Product version.</param>
        void AddUserAgent(string productName, string productVersion);

        /// <summary>
        /// Remove the given user agent string
        /// </summary>
        /// <param name="name">Name</param>
        void RemoveUserAgent(string name);

        ProductInfoHeaderValue[] UserAgents { get; }
    }
}
