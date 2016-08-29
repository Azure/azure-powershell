//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.AzureStack.Commands.Security
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Authentication context extension methods.
    /// </summary>
    public static class AuthenticationContextExtensions
    {
        /// <summary>
        /// The endpoint template URI
        /// </summary>
        private static readonly UriTemplate EndpointTemplateUri = new UriTemplate("/oauth2/{endpoint}");

        /// <summary>
        /// The token endpoint bindings
        /// </summary>
        private static readonly NameValueCollection TokenEndpointBindings = new NameValueCollection()
        {
            { "endpoint", "token" }
        };

        /// <summary>
        /// Acquires token via non-interactive flow.
        /// </summary>
        /// <param name="authority">The authority.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="userCredential">The user credential.</param>
        /// <remarks>
        /// We use reflection to call ADAL.NET internals to handle token acquisition, since the library does not support ADFS yet.
        /// </remarks>
        public static AuthenticationResult AcquireTokenForAdfs(string authority, string resource, string clientId, UserCredential userCredential)
        {
            // BUG: 2384273 - [PowerShell]: Remove AuthenticationContextExtensions class and integrate support of non-interactive flow via legitimate APIs of ADAL.NET
            var context = new AuthenticationContext(authority: authority, validateAuthority: false, tokenCache: TokenCache.DefaultShared);
            var parameters = GetNewInstanceOfRequestParameters(resource, clientId, userCredential);
            var handler = GetNewInstanceOfNonInteractiveHandler(context, resource, clientId, userCredential);
            return handler.SendHttpMessage(parameters: parameters);
        }

        /// <summary>
        /// Sends the HTTP message.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="parameters">The parameters.</param>
        private static AuthenticationResult SendHttpMessage(this object handler, object parameters)
        {
            var handlerType = handler.GetType();
            var methodInfo = handlerType.BaseType.GetMethod("SendHttpMessageAsync", BindingFlags.NonPublic | BindingFlags.Instance);
            var taskResult = (Task<AuthenticationResult>)methodInfo.Invoke(obj: handler, parameters: new object[] { parameters });
            var result = taskResult.Result;
            return result;
        }

        /// <summary>
        /// Authenticators the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        private static object Authenticator(this AuthenticationContext context)
        {
            return context.GetInstanceFieldValue("Authenticator", BindingFlags.NonPublic);
        }

        /// <summary>
        /// Sets the token URI.
        /// </summary>
        /// <param name="authenticator">The authenticator.</param>
        /// <param name="uriString">The URI string.</param>
        private static void TokenUri(this object authenticator, string uriString)
        {
            authenticator.SetInstancePropertyValue("TokenUri", uriString, BindingFlags.Public);
        }

        /// <summary>
        /// Adds the secure parameter.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="key">The key.</param>
        /// <param name="secureString">The secure string.</param>
        private static void AddSecureParameter(this Dictionary<string, string> instance, string key, object secureString)
        {
            var typeOfInstance = instance.GetType();
            var methodInfo = typeOfInstance.GetMethod("AddSecureParameter", BindingFlags.Instance | BindingFlags.Public);
            var parameters = new object[] { key, secureString };
            methodInfo.Invoke(obj: instance, parameters: parameters);
        }

        /// <summary>
        /// Secures the password.
        /// </summary>
        /// <param name="credential">The credential.</param>
        private static object SecurePassword(this UserCredential credential)
        {
            return credential.GetInstancePropertyValue("SecurePassword", BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets the new instance of request parameters.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="userCredential">The user credential.</param>
        private static object GetNewInstanceOfRequestParameters(string resource, string clientId, UserCredential userCredential)
        {
            var builder = new StringBuilder();
            var typeOfParameters = Type.GetType("Microsoft.IdentityModel.Clients.ActiveDirectory.RequestParameters, Microsoft.IdentityModel.Clients.ActiveDirectory");
            var arguments = new object[] { builder };
            var instanceOfParameters = (Dictionary<string, string>)Activator.CreateInstance(type: typeOfParameters, args: arguments);

            // Prepare request parameters to be sent over the wire
            instanceOfParameters.Add("grant_type", "password");
            instanceOfParameters.Add("resource", resource);
            instanceOfParameters.Add("username", userCredential.UserName);
            instanceOfParameters.AddSecureParameter("password", userCredential.SecurePassword());
            instanceOfParameters.Add("client_id", clientId);

            return instanceOfParameters;
        }

        /// <summary>
        /// Gets the new instance of non interactive handler.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="userCredential">The user credential.</param>
        private static object GetNewInstanceOfNonInteractiveHandler(AuthenticationContext context, string resource, string clientId, UserCredential userCredential)
        {
            var uriString = EndpointTemplateUri.BindByName(new Uri(context.Authority), TokenEndpointBindings).OriginalString;
            var cache = context.TokenCache;
            var callAsync = false;

            // Retrieve and configure authenticator
            var authenticator = context.Authenticator();
            authenticator.TokenUri(uriString);

            var typeOfObject = Type.GetType("Microsoft.IdentityModel.Clients.ActiveDirectory.AcquireTokenNonInteractiveHandler, Microsoft.IdentityModel.Clients.ActiveDirectory");
            var ctorArguments = new object[] { authenticator, cache, resource, clientId, userCredential, callAsync };
            var instanceOfHandler = Activator.CreateInstance(type: typeOfObject, args: ctorArguments);
            return instanceOfHandler;
        }

        /// <summary>
        /// Gets the instance field value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name.</param>
        /// <param name="visibility">The visibility.</param>
        private static object GetInstanceFieldValue(this object instance, string name, BindingFlags visibility)
        {
            var typeOfInstance = instance.GetType();
            var fieldInfo = typeOfInstance.GetField(name, BindingFlags.Instance | visibility);
            return fieldInfo.GetValue(instance);
        }

        /// <summary>
        /// Gets the instance property value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name.</param>
        /// <param name="visibility">The visibility.</param>
        private static object GetInstancePropertyValue(this object instance, string name, BindingFlags visibility)
        {
            var typeOfInstance = instance.GetType();
            var propertyInfo = typeOfInstance.GetProperty(name, BindingFlags.Instance | visibility);
            return propertyInfo.GetValue(instance);
        }

        /// <summary>
        /// Sets the instance property value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="visibility">The visibility.</param>
        private static void SetInstancePropertyValue(this object instance, string name, object value, BindingFlags visibility)
        {
            var typeOfInstance = instance.GetType();
            var propertyInfo = typeOfInstance.GetProperty(name, BindingFlags.Instance | visibility);
            propertyInfo.SetValue(instance, value);
        }
    }
}
