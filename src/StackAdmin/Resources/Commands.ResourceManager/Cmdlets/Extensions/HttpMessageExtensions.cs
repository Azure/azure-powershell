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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Class containing HTTP message extension methods.
    /// </summary>
    public static class HttpMessageExtensions
    {
        /// <summary>
        /// Reads the JSON content from the http response message.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the JSON.</typeparam>
        /// <param name="message">The response message to be read.</param>
        /// <param name="rewindContentStream">Rewind content stream if set to true.</param>
        /// <returns>An object of type T instantiated from the response message's body.</returns>
        public static async Task<T> ReadContentAsJsonAsync<T>(this HttpResponseMessage message, bool rewindContentStream = false)
        {
            using (var stream = await message.Content
                .ReadAsStreamAsync()
                .ConfigureAwait(continueOnCapturedContext: false))
            {
                var streamPosition = stream.Position;
                try
                {
                    return stream.FromJson<T>();
                }
                finally
                {
                    if (stream.CanSeek && streamPosition != stream.Position && rewindContentStream)
                    {
                        stream.Seek(streamPosition, SeekOrigin.Begin);
                    }
                }
            }
        }

        /// <summary>
        /// Reads the JSON content from the http response message.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the JSON.</typeparam>
        /// <param name="message">The response message to be read.</param>
        /// <param name="rewindContentStream">Rewind content stream if set to true.</param>
        /// <returns>An object of type T instantiated from the response message's body.</returns>
        public static async Task<string> ReadContentAsStringAsync(this HttpResponseMessage message, bool rewindContentStream = false)
        {
            using (var stream = await message.Content
                .ReadAsStreamAsync()
                .ConfigureAwait(continueOnCapturedContext: false))
            using (var streamReader = new StreamReader(stream))
            {
                var streamPosition = stream.Position;
                try
                {

                    return streamReader.ReadToEnd();
                }
                finally
                {
                    if (stream.CanSeek && streamPosition != stream.Position && rewindContentStream)
                    {
                        stream.Seek(streamPosition, SeekOrigin.Begin);
                    }
                }
            }
        }
    }
}
