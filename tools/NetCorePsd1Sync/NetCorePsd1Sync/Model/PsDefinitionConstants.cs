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

namespace NetCorePsd1Sync.Model
{
    internal static class PsDefinitionConstants
    {
        public const string CommentToken = "#";
        public const string CommentPrefix = CommentToken + " ";
        public const string ElementPrefix = "'";
        public const string ElementPostfix = "'";
        public const string ObjectListPrefix = "@(";
        public const string ObjectListPostfix = ")";
        public const string ObjectPrefix = "@{";
        public const string ObjectPostfix = "}";
        public const string NameValueDelimiter = " = ";
        public const string NameValuePostfix = "; ";
        public const string Indent = "    ";
        public const string HeaderDelimiter = ": ";
    }
}
