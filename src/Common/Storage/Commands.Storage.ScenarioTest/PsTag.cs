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


namespace Commands.Storage.ScenarioTest
{
    /// <summary>
    /// powershell test tags
    /// </summary>
    public struct PsTag
    {
        public const string Container = "container";
        public const string GetContainer = "getcontainer";
        public const string NewContainer = "newcontainer";
        public const string RemoveContainer = "removecontainer";
        public const string SetContainerAcl = "setcontaineracl";

        public const string Blob = "blob";
        public const string GetBlob = "getblob";
        public const string RemoveBlob = "removeblob";

        public const string GetBlobContent = "getblobcontent";
        public const string SetBlobContent = "setblobcontent";
        
        public const string StartCopyBlob = "startcopyblob";
        public const string GetBlobCopyState = "getblobcopystate";
        public const string StopCopyBlob = "stopcopyblob";

        public const string Queue = "queue";
        public const string GetQueue = "getqueue";
        public const string NewQueue = "newqueue";
        public const string RemoveQueue = "removequeue";

        public const string Table = "table";
        public const string GetTable = "gettable";
        public const string NewTable = "newtable";
        public const string RemoveTable = "removetable";

        public const string StorageContext = "storagecontext";

        /// <summary>
        /// test tag for run the fast bvt cases for different environments
        /// </summary>
        public const string FastEnv = "fastenv";
    }
}
