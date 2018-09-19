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
    using System.Collections.ObjectModel;
    using System.Management.Automation;

    public partial class JobDynamicParameters
    {
        /// <summary>
        /// Storage account for Storage error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionStorageAccount;

        /// <summary>
        /// Storage queue name for Storage error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionStorageQueue;

        /// <summary>
        /// Storage SAS token for Storage error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionStorageSASToken;

        /// <summary>
        /// Storage message for Storage error action.
        /// </summary>
        private RuntimeDefinedParameter _errorActionStorageQueueMessageBody;

        /// <summary>
        /// Gets Storage account error action.
        /// </summary>
        internal string ErrorActionStorageAccount
        {
            get
            {
                return this._errorActionStorageAccount == null ? null : (string)this._errorActionStorageAccount.Value;
            }
        }

        /// <summary>
        /// Gets Storage queue name for Storage error action.
        /// </summary>
        internal string ErrorActionStorageQueue
        {
            get
            {
                return this._errorActionStorageQueue == null ? null : (string)this._errorActionStorageQueue.Value;
            }
        }

        /// <summary>
        /// Gets Storage SAS token for Storage error action.
        /// </summary>
        internal string ErrorActionStorageSASToken
        {
            get
            {
                return this._errorActionStorageSASToken == null ? null : (string)this._errorActionStorageSASToken.Value;
            }
        }

        /// <summary>
        /// Gets Storage message for Stroage error action.
        /// </summary>
        internal string ErrorActionQueueMessageBody
        {
            get
            {
                return this._errorActionStorageQueueMessageBody == null ? null : (string)this._errorActionStorageQueueMessageBody.Value;
            }
        }

        /// <summary>
        /// Adds Storage queue error action parameters.
        /// </summary>
        /// <param name="create">true if parameters added for create scenario and false for update scenario.</param>
        /// <returns>PowerShell parameters.</returns>
        internal RuntimeDefinedParameterDictionary AddStorageQueueErrorActionParameters(bool create = true)
        {
            var errorActionStorageAccountAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The Storage account name.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionStorageQueueAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The Storage Queue name.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionStorageSASTokenAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The SAS token for storage queue.",
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            var errorActionStorageQueueMessageBodyAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    Mandatory = create ? true : false,
                    HelpMessage = "The Body for Storage job actions."
                },
                new ValidateNotNullOrEmptyAttribute()
            };

            this._errorActionStorageAccount = new RuntimeDefinedParameter("ErrorActionStorageAccount", typeof(string), errorActionStorageAccountAttributes);
            this._errorActionStorageQueue = new RuntimeDefinedParameter("ErrorActionStorageQueue", typeof(string), errorActionStorageQueueAttributes);
            this._errorActionStorageSASToken = new RuntimeDefinedParameter("ErrorActionStorageSASToken", typeof(string), errorActionStorageSASTokenAttributes);
            this._errorActionStorageQueueMessageBody = new RuntimeDefinedParameter("ErrorActionStorageQueueMessageBody", typeof(string), errorActionStorageQueueMessageBodyAttributes);

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();
            runtimeDefinedParameterDictionary.Add("ErrorActionStorageAccount", this._errorActionStorageAccount);
            runtimeDefinedParameterDictionary.Add("ErrorActionStorageQueue", this._errorActionStorageQueue);
            runtimeDefinedParameterDictionary.Add("ErrorActionStorageSASToken", this._errorActionStorageSASToken);
            runtimeDefinedParameterDictionary.Add("ErrorActionStorageQueueMessageBody", this._errorActionStorageQueueMessageBody);

            return runtimeDefinedParameterDictionary;
        }
    }
}
