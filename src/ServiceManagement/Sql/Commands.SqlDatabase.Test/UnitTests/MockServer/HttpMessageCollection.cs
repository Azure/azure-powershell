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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer
{
    /// <summary>
    /// A collection of all Http messages in a session.
    /// </summary>
    [CollectionDataContract(Name = "HttpMessageCollection", ItemName = "HttpMessage")]
    public class HttpMessageCollection : List<HttpMessage>
    {
        /// <summary>
        /// Stores the current index for response recording.
        /// </summary>
        private int recordIndex;

        /// <summary>
        /// Stores the current index for response playback.
        /// </summary>
        private int playbackIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMessageCollection" /> class.
        /// </summary>
        public HttpMessageCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMessageCollection" /> class with
        /// pre-existing messages.
        /// </summary>
        /// <param name="messages">Pre-existing responses.</param>
        public HttpMessageCollection(IEnumerable<HttpMessage> messages)
            : base(messages)
        {
        }

        /// <summary>
        /// Resets the record and playback session.
        /// </summary>
        public void Reset()
        {
            this.recordIndex = 0;
            this.playbackIndex = 0;
        }

        /// <summary>
        /// Records the given message into the session.
        /// </summary>
        /// <param name="message">The response object associated with this request.</param>
        public void RecordMessage(HttpMessage message)
        {
            // Save the current index.
            message.Index = this.recordIndex;

            // Remove existing item with this index.
            HttpMessage itemToReplace = this
                .Where((info) => info.Index == this.recordIndex)
                .FirstOrDefault();
            if (itemToReplace != null)
            {
                this.Remove(itemToReplace);
            }

            // Add the new response to the list.
            this.Add(message);

            this.recordIndex++;
        }

        /// <summary>
        /// Retrieves a message for the given <paramref name="requestUri"/> for playback.
        /// </summary>
        /// <param name="requestUri">The request for which to retrieve the response.</param>
        /// <returns>The response object associated with this request.</returns>
        public HttpMessage GetMessage(Uri requestUri)
        {
            HttpMessage returnVal;

            IEnumerable<HttpMessage> foundRequests = this
                .Where((info) => info.RequestInfo.RequestUri == requestUri);
            IEnumerable<HttpMessage> foundRequestsWithMatchingIndex = foundRequests
                .Where((info) => info.Index == this.playbackIndex);

            if (foundRequestsWithMatchingIndex.Count() > 1)
            {
                Console.Error.WriteLine("Warning: Found more than one response with same index!");
                Console.Error.WriteLine("{0}, Uri: {1}", this.playbackIndex, requestUri);
                returnVal = foundRequestsWithMatchingIndex.First();
            }
            else if (foundRequestsWithMatchingIndex.Count() == 1)
            {
                returnVal = foundRequestsWithMatchingIndex.Single();
            }
            else
            {
                Console.Error.WriteLine("Warning: Found no response with matching index!");
                Console.Error.WriteLine("{0}, Uri: {1}", this.playbackIndex, requestUri);
                returnVal = foundRequests.FirstOrDefault();
            }

            if (returnVal == null)
            {
                string exceptionMessage = string.Format(
                    CultureInfo.InvariantCulture,
                    "No response found for {0}",
                    requestUri);
                throw new Exception(exceptionMessage);
            }

            this.playbackIndex++;
            return returnVal;
        }
    }
}
