/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime
{
    public static partial class Events
    {
        public const string CmdletProcessRecordStart = nameof(CmdletProcessRecordStart);
        public const string CmdletProcessRecordAsyncStart = nameof(CmdletProcessRecordAsyncStart);
        public const string CmdletException = nameof(CmdletException);
        public const string CmdletGetPipeline = nameof(CmdletGetPipeline);
        public const string CmdletBeforeAPICall = nameof(CmdletBeforeAPICall);
        public const string CmdletBeginProcessing = nameof(CmdletBeginProcessing);
        public const string CmdletEndProcessing = nameof(CmdletEndProcessing);
        public const string CmdletProcessRecordEnd = nameof(CmdletProcessRecordEnd);
        public const string CmdletProcessRecordAsyncEnd = nameof(CmdletProcessRecordAsyncEnd);
        public const string CmdletAfterAPICall = nameof(CmdletAfterAPICall);

        public const string Verbose = nameof(Verbose);
        public const string Debug = nameof(Debug);
        public const string Information = nameof(Information);
        public const string Error = nameof(Error);
        public const string Warning = nameof(Warning);
    }

}