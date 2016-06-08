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
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer
{
    /// <summary>
    /// A collection of all sessions availiable for a series of tests.
    /// </summary>
    [CollectionDataContract(Name = "HttpSessionCollection", ItemName = "HttpSession")]
    public class HttpSessionCollection : List<HttpSession>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpSessionCollection" /> class.
        /// </summary>
        public HttpSessionCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpSessionCollection" /> class with
        /// pre-existing sessions.
        /// </summary>
        /// <param name="sessions">Pre-existing sessions.</param>
        public HttpSessionCollection(IEnumerable<HttpSession> sessions)
            : base(sessions)
        {
        }

        /// <summary>
        /// Loads Http message sessions from a file, or create an empty collection if load fails.
        /// </summary>
        /// <param name="filename">The file that stores the session information.</param>
        /// <returns>An instance of the <see cref="HttpSession"/> object.</returns>
        public static HttpSessionCollection Load(string filename)
        {
            try
            {
                DataContractSerializer serializer =
                    new DataContractSerializer(typeof(HttpSessionCollection));
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    return (HttpSessionCollection)serializer.ReadObject(stream);
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine("The session file did not load correctly.");
                return new HttpSessionCollection();
            }
        }

        /// <summary>
        /// Stores Http message sessions to a file.
        /// </summary>
        /// <param name="filename">The file that stores the session information.</param>
        public void Save(string filename)
        {
            DataContractSerializer serializer =
                new DataContractSerializer(typeof(HttpSessionCollection));
            using (XmlWriter xmlWriter = XmlWriter.Create(
                filename,
                new XmlWriterSettings { Indent = true }))
            {
                serializer.WriteObject(xmlWriter, this);
            }
        }

        /// <summary>
        /// Retrieves the session with the given <paramref name="sessionName"/>, or an empty session
        /// if it's not found.
        /// </summary>
        /// <param name="sessionName">The name of the session to retrieve.</param>
        /// <returns>
        /// The session with the given <paramref name="sessionName"/>, or an empty session if it's
        /// not found.
        /// </returns>
        public HttpSession GetSession(string sessionName)
        {
            HttpSession foundSession = this
                .Where((session) => session.Name == sessionName)
                .FirstOrDefault();

            if (foundSession == null)
            {
                foundSession = new HttpSession();
                foundSession.Name = sessionName;
                foundSession.Messages = new HttpMessageCollection();
                this.Add(foundSession);
            }

            // Create a the new session properties dictionary
            foundSession.SessionProperties = new Dictionary<string, string>();

            // Reset the messages to start at the begining
            foundSession.Messages.Reset();

            return foundSession;
        }
    }
}
