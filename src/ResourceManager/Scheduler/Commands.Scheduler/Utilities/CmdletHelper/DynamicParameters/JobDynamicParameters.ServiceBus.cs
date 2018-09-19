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
        /// Service bus queue name for ServiceBusQueue error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionServiceBusQueueName;

        /// <summary>
        /// Service bus topic path for ServiceBusTopic error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionServiceBusTopicPath;

        /// <summary>
        /// Service bus namespace for ServiceBus error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionServiceBusNamespace;

        /// <summary>
        /// Service bus transport type for ServiceBus error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionServiceBusTransportType;

        /// <summary>
        /// Service bus message for ServiceBus error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionServiceBusMessage;

        /// <summary>
        /// Service bus SAS key name for ServiceBus error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionServiceBusSasKeyName;

        /// <summary>
        /// Service bus SAS key value for ServiceBus error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionServiceBusSasKeyValue;

        /// <summary>
        /// Gets service bus namespace for ServiceBus error action.
        /// </summary>
        internal string ErrorActionServiceBusNamespace
        {
            get
            {
                return this._errorActionServiceBusNamespace == null ? null : (string)this._errorActionServiceBusNamespace.Value;
            }
        }

        /// <summary>
        /// Gets service bus topic path for ServiceBusTopic error action.
        /// </summary>
        internal string ErrorActionServiceBusTopicPath
        {
            get
            {
                return this._errorActionServiceBusTopicPath == null ? null : (string)this._errorActionServiceBusTopicPath.Value;
            }
        }

        /// <summary>
        /// Gets service bus queue name for ServiceBusQueue error action.
        /// </summary>
        internal string ErrorActionServiceBusQueueName
        {
            get
            {
                return this._errorActionServiceBusQueueName == null ? null : (string)this._errorActionServiceBusQueueName.Value;
            }
        }

        /// <summary>
        /// Gets service bus transport type for ServiceBus error action.
        /// </summary>
        internal string ErrorActionServiceBusTransportType
        {
            get
            {
                return this._errorActionServiceBusTransportType == null ? null : (string)this._errorActionServiceBusTransportType.Value;
            }
        }

        /// <summary>
        /// Gets service bus message for ServiceBus error action.
        /// </summary>
        internal string ErrorActionServiceBusMessage
        {
            get
            {
                return this._errorActionServiceBusMessage == null ? null : (string)this._errorActionServiceBusMessage.Value;
            }
        }

        /// <summary>
        /// Gets service bus SAS key name for ServiceBus error action.
        /// </summary>
        internal string ErrorActionServiceBusSasKeyName
        {
            get
            {
                return this._errorActionServiceBusSasKeyName == null ? null : (string)this._errorActionServiceBusSasKeyName.Value;
            }
        }

        /// <summary>
        /// Gets service bus SAS key value for ServiceBus error action.
        /// </summary>
        internal string ErrorActionServiceBusSasKeyValue
        {
            get
            {
                return this._errorActionServiceBusSasKeyValue == null ? null : (string)this._errorActionServiceBusSasKeyValue.Value;
            }
        }

        /// <summary>
        /// Add service bus queue error action parameters.
        /// </summary>
        /// <param name="create">true if parameters added for create scenario and false for update scenario.</param>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddServiceBusQueueErrorActionParameters(bool create = true)
        {
            var errorActionServiceBusQueueNameAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "Service bus queue name.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._errorActionServiceBusQueueName = new RuntimeDefinedParameter("ErrorActionServiceBusQueueName", typeof(string), errorActionServiceBusQueueNameAttributes);

            var runTimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runTimeDefinedParameterDictionary.Add("ErrorActionServiceBusQueueName", this._errorActionServiceBusQueueName);
            runTimeDefinedParameterDictionary.AddRange(this.AddServiceBusErrorActionParameters(create));

            return runTimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Add service bus topic error action parameters.
        /// </summary>
        /// <param name="create">true if parameters added for create scenario and false for update scenario.</param>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddServiceBusTopicErrorActionParameters(bool create = true)
        {
            var errorActionServiceBusTopicPathAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "Service bus topic path.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._errorActionServiceBusTopicPath = new RuntimeDefinedParameter("ErrorActionServiceBusTopicPath", typeof(string), errorActionServiceBusTopicPathAttributes);

            var runTimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runTimeDefinedParameterDictionary.Add("ErrorActionServiceBusTopicPath", this._errorActionServiceBusTopicPath);
            runTimeDefinedParameterDictionary.AddRange(this.AddServiceBusErrorActionParameters(create));

            return runTimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Add service bus error action parameters.
        /// </summary>
        /// <param name="create">true if parameters added for create scenario and false for update scenario.</param>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddServiceBusErrorActionParameters(bool create)
        {
            var errorActionServiceBusNamespaceAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "Service bus namespace.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionServiceBusTransportTypeAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "Service bus transport type.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionServiceBusMessageAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "Service bus queue message.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionServiceBusSasKeyNameAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "Shared access signature key name.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionServiceBusSasKeyValueAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "Shared access signature key value.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._errorActionServiceBusNamespace = new RuntimeDefinedParameter("ErrorActionServiceBusNamespace", typeof(string), errorActionServiceBusNamespaceAttributes);
            this._errorActionServiceBusTransportType = new RuntimeDefinedParameter("ErrorActionServiceBusTransportType", typeof(string), errorActionServiceBusTransportTypeAttributes);
            this._errorActionServiceBusMessage = new RuntimeDefinedParameter("ErrorActionServiceBusMessage", typeof(string), errorActionServiceBusMessageAttributes);
            this._errorActionServiceBusSasKeyName = new RuntimeDefinedParameter("ErrorActionServiceBusSasKeyName", typeof(string), errorActionServiceBusSasKeyNameAttributes);
            this._errorActionServiceBusSasKeyValue = new RuntimeDefinedParameter("ErrorActionServiceBusSasKeyValue", typeof(string), errorActionServiceBusSasKeyValueAttributes);

            var runTimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runTimeDefinedParameterDictionary.Add("ErrorActionServiceBusNamespace", this._errorActionServiceBusNamespace);
            runTimeDefinedParameterDictionary.Add("ErrorActionServiceBusTransportType", this._errorActionServiceBusTransportType);
            runTimeDefinedParameterDictionary.Add("ErrorActionServiceBusMessage", this._errorActionServiceBusMessage);
            runTimeDefinedParameterDictionary.Add("ErrorActionServiceBusSasKeyName", this._errorActionServiceBusSasKeyName);
            runTimeDefinedParameterDictionary.Add("ErrorActionServiceBusSasKeyValue", this._errorActionServiceBusSasKeyValue);

            return runTimeDefinedParameterDictionary;
        }

    }
}
