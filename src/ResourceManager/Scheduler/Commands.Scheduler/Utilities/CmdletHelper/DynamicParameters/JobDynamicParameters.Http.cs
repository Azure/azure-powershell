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

namespace Microsoft.Azure.Commands.Scheduler.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Management.Automation;

    public partial class JobDynamicParameters
    {
        /// <summary>
        /// Pfx path for client certificate authentication.
        /// </summary>
        private RuntimeDefinedParameter _clientCertificatePfx;

        /// <summary>
        /// Pfx password for client certificate authentication.
        /// </summary>
        private RuntimeDefinedParameter _clientCertificatePassword;

        /// <summary>
        /// Basic authentication username.
        /// </summary>
        private RuntimeDefinedParameter _basicUsername;

        /// <summary>
        /// Basic authentication password.
        /// </summary>
        private RuntimeDefinedParameter _basicPassword;

        /// <summary>
        /// OAuth authentication tenant.
        /// </summary>
        private RuntimeDefinedParameter _oAuthTenant;

        /// <summary>
        /// OAuth authentication audience.
        /// </summary>
        private RuntimeDefinedParameter _oAuthAudience;

        /// <summary>
        /// OAuth authentication client id.
        /// </summary>
        private RuntimeDefinedParameter _oAuthClientId;

        /// <summary>
        /// OAuth authentication secret.
        /// </summary>
        private RuntimeDefinedParameter _oAuthSecret;

        /// <summary>
        /// The error action method for Http and Https Action types (GET, PUT, POST, HEAD or DELETE).
        /// </summary>
        private RuntimeDefinedParameter _errorActionMethod;

        /// <summary>
        /// The Uri for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionUri;

        /// <summary>
        /// The request body for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionRequestBody;

        /// <summary>
        /// The headers for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionHeaders;

        /// <summary>
        /// Authententication type for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionHttpAuthenticationType;

        /// <summary>
        /// Client certificate pfx path for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionClientCertificatePfx;

        /// <summary>
        /// Client certificate pfx password for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionClientCertificatePassword;

        /// <summary>
        /// Basic authentication user name for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionBasicUsername;

        /// <summary>
        /// Basic authentication password for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionBasicPassword;

        /// <summary>
        /// OAuth authentication tenant for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionOAuthTenant;

        /// <summary>
        /// OAuth authentication audience for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionOAuthAudience;

        /// <summary>
        /// OAuth authentication client id for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionOAuthClientId;

        /// <summary>
        /// OAuth authentication secret for http error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionOAuthSecret;

        /// <summary>
        /// Gets client certificate pfx path.
        /// </summary>
        internal string ClientCertificatePfx
        {
            get
            {
                return this._clientCertificatePfx == null ? null : (string)this._clientCertificatePfx.Value;
            }
        }

        /// <summary>
        /// Gets client certificate password.
        /// </summary>
        internal string ClientCertificatePassword
        {
            get
            {
                return this._clientCertificatePassword == null ? null : (string)this._clientCertificatePassword.Value;
            }
        }

        /// <summary>
        /// Gets basic authencation user name.
        /// </summary>
        internal string BasicUsername
        {
            get
            {
                return this._basicUsername == null ? null : (string)this._basicUsername.Value;
            }
        }

        /// <summary>
        /// Gets basic authentication password.
        /// </summary>
        internal string BasicPassword
        {
            get
            {
                return this._basicPassword == null ? null : (string)this._basicPassword.Value;
            }
        }

        /// <summary>
        /// Gets OAuth authentication tenant.
        /// </summary>
        internal string OAuthTenant
        {
            get
            {
                return this._oAuthTenant == null ? null : (string)this._oAuthTenant.Value;
            }
        }

        /// <summary>
        /// Gets OAuth authentication audience.
        /// </summary>
        internal string OAuthAudience
        {
            get
            {
                return this._oAuthAudience == null ? null : (string)this._oAuthAudience.Value;
            }
        }

        /// <summary>
        /// Gets OAuth authentication client id.
        /// </summary>
        internal string OAuthClientId
        {
            get
            {
                return this._oAuthClientId == null ? null : (string)this._oAuthClientId.Value;
            }
        }

        /// <summary>
        /// Gets OAuth authentication secret.
        /// </summary>
        internal string OAuthSecret
        {
            get
            {
                return this._oAuthSecret == null ? null : (string)this._oAuthSecret.Value;
            }
        }

        /// <summary>
        /// Gets http method for http error action.
        /// </summary>
        internal string ErrorActionMethod
        {
            get
            {
                return this._errorActionMethod == null ? null : (string)this._errorActionMethod.Value;
            }
        }

        /// <summary>
        /// Gets uri for http error action.
        /// </summary>
        internal Uri ErrorActionUri
        {
            get
            {
                return this._errorActionUri == null ? null : (Uri)this._errorActionUri.Value;
            }
        }

        /// <summary>
        /// Gets request body for http error action.
        /// </summary>
        internal string ErrorActionRequestBody
        {
            get
            {
                return this._errorActionRequestBody == null ? null : (string)this._errorActionRequestBody.Value;
            }
        }

        /// <summary>
        /// Gets headers for http error action.
        /// </summary>
        internal Hashtable ErrorActionHeaders
        {
            get
            {
                return this._errorActionHeaders == null ? null : (Hashtable)this._errorActionHeaders.Value;
            }
        }

        /// <summary>
        /// Gets authentication type for http error action.
        /// </summary>
        internal string ErrorActionHttpAuthenticationType
        {
            get
            {
                return this._errorActionHttpAuthenticationType == null ? null : (string)this._errorActionHttpAuthenticationType.Value;
            }
        }

        /// <summary>
        /// Gets client certificate pfx path for http error action.
        /// </summary>
        internal string ErrorActionClientCertificatePfx
        {
            get
            {
                return this._errorActionClientCertificatePfx == null ? null : (string)this._errorActionClientCertificatePfx.Value;
            }
        }

        /// <summary>
        /// Gets client certificate password for http error action.
        /// </summary>
        internal string ErrorActionClientCertificatePassword
        {
            get
            {
                return this._errorActionClientCertificatePassword == null ? null : (string)this._errorActionClientCertificatePassword.Value;
            }
        }

        /// <summary>
        /// Gets basic authentication username for http error action.
        /// </summary>
        internal string ErrorActionBasicUsername
        {
            get
            {
                return this._errorActionBasicUsername == null ? null : (string)this._errorActionBasicUsername.Value;
            }
        }

        /// <summary>
        /// Gets basic authentication password for http error action.
        /// </summary>
        internal string ErrorActionBasicPassword
        {
            get
            {
                return this._errorActionBasicPassword == null ? null : (string)this._errorActionBasicPassword.Value;
            }
        }

        /// <summary>
        /// Gets OAuth authencation tenant for http error action.
        /// </summary>
        internal string ErrorActionOAuthTenant
        {
            get
            {
                return this._errorActionOAuthTenant == null ? null : (string)this._errorActionOAuthTenant.Value;
            }
        }

        /// <summary>
        /// Gets OAuth authentication audience for http error action.
        /// </summary>
        internal string ErrorActionOAuthAudience
        {
            get
            {
                return this._errorActionOAuthAudience == null ? null : (string)this._errorActionOAuthAudience.Value;
            }
        }

        /// <summary>
        /// Gets OAuth authentication client id for http error action.
        /// </summary>
        internal string ErrorActionOAuthClientId
        {
            get
            {
                return this._errorActionOAuthClientId == null ? null : (string)this._errorActionOAuthClientId.Value;
            }
        }

        /// <summary>
        /// Gets OAuth authentication secret for http error action.
        /// </summary>
        internal string ErrorActionOAuthSecret
        {
            get
            {
                return this._errorActionOAuthSecret == null ? null : (string)this._errorActionOAuthSecret.Value;
            }
        }

        /// <summary>
        /// Adds client certificate authentication parameters to PowerShell.
        /// </summary>
        /// <param name="create">true if parameters added for create scenario and false for update scenario.</param>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddHttpClientCertificateAuthenticationTypeParameters(bool create = true)
        {
            var clientCertificatePfxAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The pfx of client certificate.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var clientCertificatePasswordAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The password for the pfx.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._clientCertificatePfx = new RuntimeDefinedParameter("ClientCertificatePfx", typeof(object), clientCertificatePfxAttributes);
            this._clientCertificatePassword = new RuntimeDefinedParameter("ClientCertificatePassword", typeof(string), clientCertificatePasswordAttributes);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runtimeDefinedParameterDictionary.Add("ClientCertificatePfx", this._clientCertificatePfx);
            runtimeDefinedParameterDictionary.Add("ClientCertificatePassword", this._clientCertificatePassword);

            return runtimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Adds basic authentication parameters to PowerShell.
        /// </summary>
        /// <param name="create">true if parameters added for create scenario and false for update scenario.</param>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddHttpBasicAuthenticationTypeParameters(bool create = true)
        {
            var basicUsernameAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = true,
                    HelpMessage = "The user name.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var basicPasswordAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = true,
                    HelpMessage = "The password.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._basicUsername = new RuntimeDefinedParameter("Username", typeof(string), basicUsernameAttributes);
            this._basicPassword = new RuntimeDefinedParameter("Password", typeof(string), basicPasswordAttributes);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runtimeDefinedParameterDictionary.Add("Username", this._basicUsername);
            runtimeDefinedParameterDictionary.Add("Password", this._basicPassword);

            return runtimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Adds OAuth authentication parameters to PowerShell.
        /// </summary>
        /// <param name="create">true if parameters added for create scenario and false for update scenario.</param>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddHttpActiveDirectoryOAuthAuthenticationTypeParameters(bool create = true)
        {
            var oAuthTenantAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The tenant Id.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var oAuthAudienceAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The audience.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var oAuthClientIdAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The client id.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var oAuthSecretAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The secret.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._oAuthTenant = new RuntimeDefinedParameter("Tenant", typeof(string), oAuthTenantAttributes);
            this._oAuthAudience = new RuntimeDefinedParameter("Audience", typeof(string), oAuthAudienceAttributes);
            this._oAuthClientId = new RuntimeDefinedParameter("ClientId", typeof(string), oAuthClientIdAttributes);
            this._oAuthSecret = new RuntimeDefinedParameter("Secret", typeof(string), oAuthSecretAttributes);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runtimeDefinedParameterDictionary.Add("Tenant", this._oAuthTenant);
            runtimeDefinedParameterDictionary.Add("Audience", this._oAuthAudience);
            runtimeDefinedParameterDictionary.Add("ClientId", this._oAuthClientId);
            runtimeDefinedParameterDictionary.Add("Secret", this._oAuthSecret);

            return runtimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Adds http error action parameters to PowerShell.
        /// </summary>
        /// <param name="create">true if parameters added for create scenario and false for update scenario.</param>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddHttpErrorActionParameters(bool create = true)
        {
            var errorActionMethodAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The Method for Http and Https Action types (GET, PUT, POST, HEAD or DELETE).",
                },
                new ValidateSetAttribute(Constants.HttpMethodGET, Constants.HttpMethodPUT, Constants.HttpMethodPOST, Constants.HttpMethodDELETE)
                {
                    IgnoreCase = true,
                }
            };

            var errorActionUriAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The Uri for error job action.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionRequestBodyAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The Body for PUT and POST job actions.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionHeadersAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The header collection."
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionHttpAuthenticationTypeAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The Http Authentication type."
                },
                new ValidateSetAttribute(Constants.HttpAuthenticationNone, Constants.HttpAuthenticationClientCertificate, Constants.HttpAuthenticationActiveDirectoryOAuth, Constants.HttpAuthenticationBasic)
                {
                    IgnoreCase = true
                }
            };

            this._errorActionMethod = new RuntimeDefinedParameter("ErrorActionMethod", typeof(string), errorActionMethodAttributes);
            this._errorActionUri = new RuntimeDefinedParameter("ErrorActionUri", typeof(Uri), errorActionUriAttributes);
            this._errorActionRequestBody = new RuntimeDefinedParameter("ErrorActionRequestBody", typeof(string), errorActionRequestBodyAttributes);
            this._errorActionHeaders = new RuntimeDefinedParameter("ErrorActionHeaders", typeof(Hashtable), errorActionHeadersAttributes);
            this._errorActionHttpAuthenticationType = new RuntimeDefinedParameter("ErrorActionHttpAuthenticationType", typeof(string), errorActionHttpAuthenticationTypeAttributes);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runtimeDefinedParameterDictionary.Add("ErrorActionMethod", this._errorActionMethod);
            runtimeDefinedParameterDictionary.Add("ErrorActionUri", this._errorActionUri);
            runtimeDefinedParameterDictionary.Add("ErrorActionRequestBody", this._errorActionRequestBody);
            runtimeDefinedParameterDictionary.Add("ErrorActionHeaders", this._errorActionHeaders);
            runtimeDefinedParameterDictionary.Add("ErrorActionHttpAuthenticationType", this._errorActionHttpAuthenticationType);

            runtimeDefinedParameterDictionary.AddRange(this.AddHttpErrorActionClientCertificateAuthenticationTypeParameters());
            runtimeDefinedParameterDictionary.AddRange(this.AddHttpErrorActionBasicAuthenticationTypeParameters());
            runtimeDefinedParameterDictionary.AddRange(this.AddHttpErrorActionActiveDirectoryOAuthAuthenticationTypeParameters());

            return runtimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Adds client certificate authentication parameters for http error action.
        /// </summary>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddHttpErrorActionClientCertificateAuthenticationTypeParameters()
        {
            var errorActionClientCertificatePfxAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The file name of client certificate.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionClientCertificatePasswordAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The password for the pfx.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._errorActionClientCertificatePfx = new RuntimeDefinedParameter("ErrorActionClientCertificatePfx", typeof(object), errorActionClientCertificatePfxAttributes);
            this._errorActionClientCertificatePassword = new RuntimeDefinedParameter("ErrorActionClientCertificatePassword", typeof(string), errorActionClientCertificatePasswordAttributes);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runtimeDefinedParameterDictionary.Add("ErrorActionClientCertificatePfx", this._errorActionClientCertificatePfx);
            runtimeDefinedParameterDictionary.Add("ErrorActionClientCertificatePassword", this._errorActionClientCertificatePassword);

            return runtimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Adds basic authentication parameters for http error action.
        /// </summary>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddHttpErrorActionBasicAuthenticationTypeParameters()
        {
            var errorActionBasicUsernameAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The user name.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionBasicPasswordAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The password.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._errorActionBasicUsername = new RuntimeDefinedParameter("ErrorActionUsername", typeof(string), errorActionBasicUsernameAttributes);
            this._errorActionBasicPassword = new RuntimeDefinedParameter("ErrorActionPassword", typeof(string), errorActionBasicPasswordAttributes);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runtimeDefinedParameterDictionary.Add("ErrorActionUsername", this._errorActionBasicUsername);
            runtimeDefinedParameterDictionary.Add("ErrorActionPassword", this._errorActionBasicPassword);

            return runtimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Adds OAuth authentication parameters for http error action.
        /// </summary>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddHttpErrorActionActiveDirectoryOAuthAuthenticationTypeParameters()
        {
            var errorActionOAuthTenantAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The tenant Id.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionOAuthAudienceAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The audience.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionOAuthClientIdAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The client id.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionOAuthSecretAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = false,
                    HelpMessage = "The secret.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._errorActionOAuthTenant = new RuntimeDefinedParameter("ErrorActionTenant", typeof(string), errorActionOAuthTenantAttributes);
            this._errorActionOAuthAudience = new RuntimeDefinedParameter("ErrorActionAudience", typeof(string), errorActionOAuthAudienceAttributes);
            this._errorActionOAuthClientId = new RuntimeDefinedParameter("ErrorActionClientId", typeof(string), errorActionOAuthClientIdAttributes);
            this._errorActionOAuthSecret = new RuntimeDefinedParameter("ErrorActionSecret", typeof(string), errorActionOAuthSecretAttributes);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runtimeDefinedParameterDictionary.Add("ErrorActionTenant", this._errorActionOAuthTenant);
            runtimeDefinedParameterDictionary.Add("ErrorActionAudience", this._errorActionOAuthAudience);
            runtimeDefinedParameterDictionary.Add("ErrorActionClientId", this._errorActionOAuthClientId);
            runtimeDefinedParameterDictionary.Add("ErrorActionSecret", this._errorActionOAuthSecret);

            return runtimeDefinedParameterDictionary;
        }
    }
}
