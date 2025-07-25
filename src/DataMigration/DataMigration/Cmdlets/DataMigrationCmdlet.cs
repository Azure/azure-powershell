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

using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using ErrorCategory = System.Management.Automation.ErrorCategory;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Base class for all Dms cmdlets
    /// </summary>
    public abstract class DataMigrationCmdlet : AzureRMCmdlet
    {
        protected DmsClient _dmsClient;

        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string ComponentNameParameterSet = "ComponentNameParameterSet";
        protected const string ComponentObjectParameterSet = "ComponentObjectParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";

        /// <summary>
        /// DMS client that is used inside all cmdlets for testing
        /// </summary>
        public DmsClient DmsClient
        {
            get
            {
                if (_dmsClient == null)
                {
                    _dmsClient = new DmsClient(DefaultProfile.DefaultContext);

                }
                return _dmsClient;
            }

            set { _dmsClient = value; }
        }

        public IDataMigrationServiceClient DataMigrationClient
        {
            get
            {
                return DmsClient.DataMigrationServiceClient;
            }
        }
        /// <summary>
        /// Helper method to return the error message of an ApiErrorException
        /// </summary>
        /// <param name="ex">the ApiErrorException for which to return the message</param>
        /// <returns>
        /// Error message of an ApiErrorException
        /// </returns>
        public static string ReturnApiErrorMessage(ApiErrorException ex)
        {
            string errorContent = null;
            if (ex.Body != null && ex.Body.Error != null)
            {
                errorContent = ex.Body.Error.Message;
            }

            if (errorContent == null)
            {
                ODataError error = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<ODataError>(ex.Response.Content);
                if (error != null)
                {
                    errorContent = error.Message;
                }
            }

            return errorContent;
        }

        /// <summary>
        /// Helper method to throw the appropriate exception based on the error returned by the SDK
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="customObjects"></param>
        protected void ThrowAppropriateException(ApiErrorException ex, List<string> customObjects = null)
        {
            string message = "DMS API Error " + ReturnApiErrorMessage(ex);

            HttpStatusCode statusCode = ex.Response.StatusCode;
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new BadRequestException(message, ex),
                            "Bad Request",
                            ErrorCategory.InvalidData,
                            null));
                    break;

                case HttpStatusCode.Forbidden:
                    ThrowTerminatingError(
                        new ErrorRecord(
                            ex,
                            "The server refuses to fulfill this request.",
                            ErrorCategory.InvalidOperation,
                            null));
                    break;

                case HttpStatusCode.NotFound:
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new NotFoundException(message, ex),
                            "Not found",
                            ErrorCategory.ObjectNotFound,
                            null));
                    break;

                //TODO: not sure what this looks like 
                case HttpStatusCode.ServiceUnavailable:
                    ThrowTerminatingError(
                        new ErrorRecord(
                            ex,
                            "The service or resource is not available.",
                            ErrorCategory.ResourceUnavailable,
                            null));
                    break;

                //TODO: not sure what this looks like 
                case HttpStatusCode.Unauthorized:
                    ThrowTerminatingError(
                        new ErrorRecord(
                            ex,
                            "You are not authorized to perform this operation.",
                            ErrorCategory.PermissionDenied,
                            null));
                    break;

                case HttpStatusCode.PreconditionFailed:
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new PreConditionFailedException(message, ex),
                            "PreConditionFailed",
                            ErrorCategory.InvalidOperation,
                            null));
                    break;

                default:
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new DataMigrationServiceExceptionBase(message, ex),
                            "Error",
                            ErrorCategory.InvalidOperation,
                            null));
                    break;
            }
        }
    }
}