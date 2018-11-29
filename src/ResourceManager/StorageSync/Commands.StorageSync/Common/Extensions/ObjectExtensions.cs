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

using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    /// <summary>
    /// Object extensions class
    /// </summary>
    public static class ObjectExtensions
    {

        /// <summary>
        /// This function will transform an object to json formatted string.
        /// </summary>
        /// <param name="currentObject">current object</param>
        /// <returns>Json formatted string</returns>
        public static string ToJson(this object currentObject)
        {
#if !NETSTANDARD
            using (var stream = new System.IO.MemoryStream())
            {
                new JsonFormatter().WriteToStreamAsync(currentObject.GetType(), currentObject, stream, null, null).Wait();
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
#else
            return JsonConvert.SerializeObject(currentObject);
#endif
        }
    }
}
