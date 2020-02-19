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


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Shares
{
    internal class HelpMessageShare
    {
        internal const string StorageAccountCredentialHelpMessage =
            "Provide existing StorageAccountCredential's Resource Name";

        internal const string AccessProtocolHelpMessage = "AccessProtocol in the case of creating Share";

        internal const string SetUserAccessRightsHelpMessage =
            @"provide access right along with existing usernames to access SMB Share types, For ex: " +
            "@(" +
            "@{\"Username\"=\"user-name-1\";\"AccessRight\"=\"Read\"}, " +
            "@{\"Username\"=\"user-name-2\";\"AccessRight\"=\"Read\"}, " +
            "@{\"Username\"=\"user-name-3\";\"AccessRight\"=\"Custom\"}" +
            ")";

        internal const string SetClientAccessRightsHelpMessage = @"Read/Write Access for clientIds, For ex:" +
                                                                 "@(" +
                                                                 "@{\"ClientId\"=\"192.168.10.10\";\"AccessRight\"=\"NoAccess\"}, " +
                                                                 "@{\"ClientId\"=\"192.168.10.11\";\"AccessRight\"=\"ReadOnly\"}" +
                                                                 ")";

        internal const string NameHelpMessage = "Name of the Share";
        internal const string DataFormatHelpMessage = "Set Data Format ex: PageBlob, BlobBlob";
        internal const string ObjectName = "Share";

        internal const string ContainerName =
            "Container name (Based on the data format specified, this represents " +
            "the name of Azure Files/Pageblob/Block blob)";

        internal const string RefreshDataHelpMessage = "Refresh Share Metadata with the data from the cloud";

        //Aliases
        internal const string NameAlias = "EdgeShareName";
        internal const string InputObjectAlias = "EdgeShare";

    }
}