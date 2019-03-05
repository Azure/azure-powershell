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


using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Constants for the events defined in PowerShell Generated Cmdlets
    /// </summary>
    public static class Events
    {
        /// <summary>
        /// After parameter validation
        /// </summary>
        public const string AfterValidation = nameof(AfterValidation);

        /// <summary>
        /// Event just before an API call - all message properties should be finalized
        /// </summary>
        public const string BeforeCall = nameof(BeforeCall);

        /// <summary>
        /// Event after a response is received and before processing the response
        /// </summary>
        public const string BeforeResponseDispatch = nameof(BeforeResponseDispatch);

        /// <summary>
        /// Body content (if any) oif request set
        /// </summary>
        public const string BodyContentSet = nameof(BodyContentSet);

        /// <summary>
        /// Event just after API call completion
        /// </summary>
        public const string CmdletAfterAPICall = nameof(CmdletAfterAPICall);

        /// <summary>
        /// Event just before API call invocation
        /// </summary>
        public const string CmdletBeforeAPICall = nameof(CmdletBeforeAPICall);

        /// <summary>
        /// Start of the synchronous BeginProcessing method in cmdlet
        /// </summary>
        public const string CmdletBeginProcessing = nameof(CmdletBeginProcessing);

        /// <summary>
        /// Start of the synchronous EndProcessing event for a cmdlet
        /// </summary>
        public const string CmdletEndProcessing = nameof(CmdletEndProcessing);

        /// <summary>
        /// Event indicating an exception receive din cmdlet processing
        /// </summary>
        public const string CmdletException = nameof(CmdletException);

        /// <summary>
        /// Event indicating creation of an http pieline
        /// </summary>
        public const string CmdletGetPipeline = nameof(CmdletGetPipeline);

        /// <summary>
        /// Event indicating the end of the asynchronous ProcessRecord event - this occurs in both 
        /// foreground and background cmdlet execution
        /// </summary>
        public const string CmdletProcessRecordAsyncEnd = nameof(CmdletProcessRecordAsyncEnd);

        /// <summary>
        /// Event indicating the start of the asynchronous ProcessRecord event - this occurs in both 
        /// foreground and background cmdlet execution
        /// </summary>
        public const string CmdletProcessRecordAsyncStart = nameof(CmdletProcessRecordAsyncStart);

        /// <summary>
        /// Event indicating the end of the synchronous ProcessRecord method - in background execution, 
        /// this does not indicate completed processing (only PSJob creation
        /// </summary>
        public const string CmdletProcessRecordEnd = nameof(CmdletProcessRecordEnd);

        /// <summary>
        /// Event indicating the start of the synchronous ProcessRecord method
        /// </summary>
        public const string CmdletProcessRecordStart = nameof(CmdletProcessRecordStart);

        /// <summary>
        /// Event indicating a message sent to the debug stream
        /// </summary>
        public const string Debug = nameof(Debug);

        /// <summary>
        /// Event indicating waiting for the next poll in a long-running operation
        /// </summary>
        public const string DelayBeforePolling = nameof(DelayBeforePolling);

        /// <summary>
        /// Event indicating a message sent to the error stream
        /// </summary>
        public const string Error = nameof(Error);

        /// <summary>
        /// Event indicating the end of response dispatch (occurs in success and failure cases)
        /// </summary>
        public const string Finally = nameof(Finally);

        /// <summary>
        /// Event indicating the expansion of the next page of data in API calls that 
        /// return multiple data pages
        /// </summary>
        public const string FollowingNextLink = nameof(FollowingNextLink);

        /// <summary>
        /// Event indicating that request headers have been added to an outgoing request
        /// </summary>
        public const string HeaderParametersAdded = nameof(HeaderParametersAdded);

        /// <summary>
        /// Event indicating a message sent to the information stream
        /// </summary>
        public const string Information = nameof(Information);

        /// <summary>
        /// Event indicating message sent to the persistent log
        /// </summary>
        public const string Log = nameof(Log);

        /// <summary>
        /// Event indicating that polling for an LRO API is taking place
        /// </summary>
        public const string Polling = nameof(Polling);

        /// <summary>
        /// Event indicating creation of the outgoing request
        /// </summary>
        public const string RequestCreated = nameof(RequestCreated);

        /// <summary>
        /// Event indicating creation fo the response based on the server's http response
        /// </summary>
        public const string ResponseCreated = nameof(ResponseCreated);

        /// <summary>
        /// Event indicating the end of URL creation
        /// </summary>
        public const string URLCreated = nameof(URLCreated);

        /// <summary>
        /// Event indicating parameter validation
        /// </summary>
        public const string Validation = nameof(Validation);

        /// <summary>
        /// Event indicating a parameter validatio9n warning
        /// </summary>
        public const string ValidationWarning = nameof(ValidationWarning);

        /// <summary>
        /// Event indicating a message sent to the verbose stream
        /// </summary>
        public const string Verbose = nameof(Verbose);

        /// <summary>
        /// Event indicating a message sent to the warning stream
        /// </summary>
        public const string Warning = nameof(Warning);
    }

}