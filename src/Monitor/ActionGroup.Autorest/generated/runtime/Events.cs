/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime
{
    public static partial class Events
    {
        public const string Log = nameof(Log);
        public const string Validation = nameof(Validation);
        public const string ValidationWarning = nameof(ValidationWarning);
        public const string AfterValidation = nameof(AfterValidation);
        public const string RequestCreated = nameof(RequestCreated);
        public const string ResponseCreated = nameof(ResponseCreated);
        public const string URLCreated = nameof(URLCreated);
        public const string Finally = nameof(Finally);
        public const string HeaderParametersAdded = nameof(HeaderParametersAdded);
        public const string BodyContentSet = nameof(BodyContentSet);
        public const string BeforeCall = nameof(BeforeCall);
        public const string BeforeResponseDispatch = nameof(BeforeResponseDispatch);
        public const string FollowingNextLink = nameof(FollowingNextLink);
        public const string DelayBeforePolling = nameof(DelayBeforePolling);
        public const string Polling = nameof(Polling);
        public const string Progress = nameof(Progress);
    }
}
