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

namespace AzDev.Models.Inventory
{
    internal class SwaggerReference
    {
        public string Uri { get; }
        public string RawUri { get; }
        public string Commit { get; }

        public SwaggerReference(string uri, string commit)
        {
            RawUri = uri;
            Commit = commit;
            Uri = ParseUri(uri);
        }

        private string ParseUri(string uri)
        {
            return uri.Replace("$(repo)", $"https://github.com/Azure/azure-rest-api-specs/blob/{Commit}");
        }

        public override string ToString()
        {
            return RawUri;
        }
    }
}
