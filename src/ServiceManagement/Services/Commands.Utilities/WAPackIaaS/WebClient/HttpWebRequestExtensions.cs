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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient
{
    internal static class HttpWebResponseExtensions
    {
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        internal static String ResponseToString(this WebResponse response)
        {
            //check for null
            if (response == null)
                return null;

            //Read the response body of the request
            using (Stream responseStream = response.GetResponseStream())
            {
                using (var responseStreamReader = new StreamReader(responseStream, true))
                {
                    //return the response body as a string
                    var responseString = responseStreamReader.ReadToEnd();
                    return responseString;
                }
            }

        }
    }
}
