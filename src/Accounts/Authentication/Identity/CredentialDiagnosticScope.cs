// Copyright (c) Microsoft Corporation. All rights reserved.
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
//

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.PowerShell.Authenticators.Identity.Core;

using System;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal readonly struct CredentialDiagnosticScope : IDisposable
    {
        private readonly string _name;
        private readonly DiagnosticScope _scope;
        private readonly TokenRequestContext _context;
        private readonly IScopeHandler _scopeHandler;

        public CredentialDiagnosticScope(ClientDiagnostics diagnostics, string name, TokenRequestContext context, IScopeHandler scopeHandler)
        {
            _name = name;
            _scope = scopeHandler.CreateScope(diagnostics, name);
            _context = context;
            _scopeHandler = scopeHandler;
        }

        public void Start()
        {
            AzureIdentityEventSource.Singleton.GetToken(_name, _context);
            _scopeHandler.Start(_name, _scope);
        }

        public AccessToken Succeeded(AccessToken token)
        {
            AzureIdentityEventSource.Singleton.GetTokenSucceeded(_name, _context, token.ExpiresOn);
            return token;
        }

        public Exception FailWrapAndThrow(Exception ex, string additionalMessage = null, bool isCredentialUnavailable = false)
        {
            var wrapped = TryWrapException(ref ex, additionalMessage);
            RegisterFailed(ex);

            if (!wrapped)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            throw ex;
        }

        private void RegisterFailed(Exception ex)
        {
            AzureIdentityEventSource.Singleton.GetTokenFailed(_name, _context, ex);
            _scopeHandler.Fail(_name, _scope, ex);
        }

        private bool TryWrapException(ref Exception exception, string additionalMessageText = null, bool isCredentialUnavailable = false)
        {
            if (exception is OperationCanceledException || exception is AuthenticationFailedException)
            {
                return false;
            }

            if (exception is AggregateException aex)
            {
                CredentialUnavailableException firstCredentialUnavailable = aex.Flatten().InnerExceptions.OfType<CredentialUnavailableException>().FirstOrDefault();
                if (firstCredentialUnavailable != default)
                {
                    exception = new CredentialUnavailableException(firstCredentialUnavailable.Message, aex);
                    return true;
                }
            }
            string exceptionMessage = $"{_name.Substring(0, _name.IndexOf('.'))} authentication failed: {exception.Message}";
            if (additionalMessageText != null)
            {
                exceptionMessage = exceptionMessage + $"\n{additionalMessageText}";
            }
            exception = isCredentialUnavailable ?
                new CredentialUnavailableException(exceptionMessage, exception) :
                new AuthenticationFailedException(exceptionMessage, exception);
            return true;
        }

        public void Dispose() => _scopeHandler.Dispose(_name, _scope);
    }
}
