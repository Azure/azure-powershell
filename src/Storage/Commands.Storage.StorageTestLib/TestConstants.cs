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


namespace StorageTestLib
{

    public struct Tag
    {
        public const string BVT = "bvt";
        public const string Function = "function";
        public const string Scenario = "scenario";
        public const string GB18030 = "GB18030";
    }

    public struct Protocol
    {
        public const string Http = "http";
        public const string Https = "https";
    }

    public struct BlobType
    {
        public const string Page = "page";
        public const string Block = "block";
    }
}
