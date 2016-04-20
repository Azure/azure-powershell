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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    public class SecurityPrincipals : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The user type"
            )]
        public PrincipalProviderType Type { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipeline = false,
            HelpMessage = "One or more user UPNs to add to the RemoteApp collection.")]
        [ValidatePattern(UserPrincipalValdatorString)]
        public string[] UserUpn { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Published program alias (applicable only in per-app publishing mode)")]
        [ValidateNotNullOrEmpty()]
        public string Alias { get; set; }

        protected enum Operation
        {
            Add,
            Remove
        }

        protected void AddUsers(string CollectionName, string[] users, PrincipalProviderType userIdType, string appAlias)
        {
            SecurityPrincipalOperationsResult response = null;
            SecurityPrincipalList spAdd = null;

            if (!String.IsNullOrWhiteSpace(CollectionName))
            {
                spAdd = BuildUserList(users, userIdType);

                if (String.IsNullOrEmpty(appAlias))
                {
                    response = CallClient(() => Client.Principals.Add(CollectionName, spAdd), Client.Principals);
                }
                else
                {
                    response = CallClient(() => Client.Principals.AddToApp(CollectionName, appAlias, spAdd), Client.Principals);
                }
            }

            if (response != null)
            {
                ProcessResult(response, CollectionName, Operation.Add);
            }
        }

        protected void RemoveUsers(string CollectionName, string[] users, PrincipalProviderType userIdType, string appAlias)
        {
            SecurityPrincipalOperationsResult response = null;
            SecurityPrincipalList spRemove = null;

            if (!String.IsNullOrWhiteSpace(CollectionName))
            {
                spRemove = BuildUserList(users, userIdType);

                if (String.IsNullOrEmpty(appAlias))
                {
                    response = CallClient(() => Client.Principals.Delete(CollectionName, spRemove), Client.Principals);
                }
                else
                {
                    response = CallClient(() => Client.Principals.DeleteFromApp(CollectionName, appAlias, spRemove), Client.Principals);
                }
            }

            if (response != null)
            {
                ProcessResult(response, CollectionName, Operation.Remove);
            }
        }

        protected SecurityPrincipalList BuildUserList(string[] Users, PrincipalProviderType userIdType)
        {
            SecurityPrincipalList userList = new SecurityPrincipalList();
            List<SecurityPrincipal> spList = new List<SecurityPrincipal>();

            foreach (string user in Users)
            {
                SecurityPrincipal principal = new SecurityPrincipal()
                {
                    AadObjectId = null,
                    Description = null,
                    Name = user,
                    SecurityPrincipalType = PrincipalType.User,
                    UserIdType = userIdType
                };

                spList.Add(principal);
            }

            userList.SecurityPrincipals = spList;

            return userList;
        }

        protected void ProcessResult( SecurityPrincipalOperationsResult result, string collectionName, Operation operation)
        {
            ErrorRecord er = null;
            ErrorCategory category = ErrorCategory.NotImplemented;
            String errorMessageFormat = String.Empty;

            if (result.Errors != null)
            {
                switch (operation)
                {
                    case Operation.Add:
                        errorMessageFormat = "Could not add {0} to collection {1} because of error: {2} [{3}].";
                        break;
                    case Operation.Remove:
                        errorMessageFormat = "Could not remove {0} from collection {1} because of error: {2} [{3}].";
                        break;
                    default:
                        errorMessageFormat = "Unknown error.";
                        break;
                }

                foreach (SecurityPrincipalOperationErrorDetails errorDetails in result.Errors)
                {

                    switch (errorDetails.Error)
                    {
                        case SecurityPrincipalOperationError.NotSupported:
                        case SecurityPrincipalOperationError.AlreadyExists:
                        case SecurityPrincipalOperationError.AssignedToAnotherCollection:
                            {
                                category = ErrorCategory.InvalidOperation;
                                break;
                            }

                        case SecurityPrincipalOperationError.NotFound:
                        case SecurityPrincipalOperationError.CouldNotBeResolved:
                        case SecurityPrincipalOperationError.NotDirsynced:
                            {
                                category = ErrorCategory.ObjectNotFound;
                                break;
                            }
                    }

                    er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                        String.Format(errorMessageFormat,
                            errorDetails.SecurityPrincipal,
                            collectionName,
                            errorDetails.Error.ToString(),
                            errorDetails.ErrorDetails
                            ),
                        String.Empty,
                        Client.Principals,
                        category
                    );

                    WriteError(er);
                }
            }
            else
            {
                WriteObject(result);
            }
        }
    }

}
