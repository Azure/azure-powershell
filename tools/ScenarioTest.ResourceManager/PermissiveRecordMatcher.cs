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

using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public class PermissiveRecordMatcher : IRecordMatcher
    {
        public string GetMatchingKey(System.Net.Http.HttpRequestMessage request)
        {
            var path = request.RequestUri.PathAndQuery;
            if (path.Contains("?&"))
            {
                path = path.Replace("?&", "?");
            }

            var encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));
            return string.Format("{0} {1}", request.Method, encodedPath);
        }

        public string GetMatchingKey(RecordEntry recordEntry)
        {
            var encodedPath = recordEntry.EncodedRequestUri;
            if (recordEntry.RequestUri.Contains("?&"))
            {
                var updatedPath = recordEntry.RequestUri.Replace("?&", "?");
                encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(updatedPath));
            }

            return string.Format("{0} {1}", recordEntry.RequestMethod, encodedPath);
        }
    }
}
