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
  public static class Events
    {
        public const string AfterValidation = nameof(AfterValidation);
        public const string BeforeCall = nameof( BeforeCall);
        public const string BeforeResponseDispatch = nameof( BeforeResponseDispatch);
        public const string BodyContentSet = nameof( BodyContentSet);
        public const string CmdletAfterAPICall =  nameof(CmdletAfterAPICall);
        public const string CmdletBeforeAPICall = nameof(CmdletBeforeAPICall);
        public const string CmdletBeginProcessing = nameof(CmdletBeginProcessing);
        public const string CmdletEndProcessing = nameof(CmdletEndProcessing);
        public const string CmdletException = nameof(CmdletException);
        public const string CmdletGetPipeline = nameof(CmdletGetPipeline);
        public const string CmdletProcessRecordAsyncEnd = nameof(CmdletProcessRecordAsyncEnd);
        public const string CmdletProcessRecordAsyncStart = nameof(CmdletProcessRecordAsyncStart);
        public const string CmdletProcessRecordEnd = nameof(CmdletProcessRecordEnd);
        public const string CmdletProcessRecordStart = nameof(CmdletProcessRecordStart);
        public const string Debug = nameof(Debug);
        public const string DelayBeforePolling = nameof(DelayBeforePolling);
        public const string Error = nameof(Error);
        public const string Finally = nameof(Finally);
        public const string FollowingNextLink = nameof(FollowingNextLink);
        public const string HeaderParametersAdded = nameof( HeaderParametersAdded);
        public const string Information = nameof(Information);
        public const string Log = nameof(Log);
        public const string Polling = nameof(Polling);
        public const string RequestCreated = nameof(RequestCreated);
        public const string ResponseCreated = nameof(ResponseCreated);
        public const string URLCreated = nameof(URLCreated);
        public const string Validation = nameof(Validation);
        public const string ValidationWarning = nameof(ValidationWarning);
        public const string Verbose = nameof(Verbose);
        public const string Warning = nameof(Warning);
    }

}