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
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer
{
    /// <summary>
    /// Stores information about a Http Web Response.
    /// </summary>
    [DataContract(Name = "HttpMessage")]
    public class HttpMessage : IExtensibleDataObject
    {
        [DataMember(Order = 0)]
        public int Index { get; set; }

        [DataMember(Order = 1)]
        public Request RequestInfo { get; set; }

        [DataMember(Order = 2)]
        public Response ResponseInfo { get; set; }

        [DataContract(Name = "RequestInfo")]
        public class Request : IExtensibleDataObject
        {
            [DataMember(Order = 0)]
            public Uri RequestUri { get; set; }

            [DataMember(Order = 1)]
            public string Method { get; set; }

            [DataMember(Order = 2)]
            public string UserAgent { get; set; }

            [DataMember(Order = 3)]
            public HeaderCollection Headers { get; set; }

            [DataMember(Order = 4)]
            public CookieCollection Cookies { get; set; }

            [DataMember(Order = 5)]
            public string RequestText { get; set; }

            [DataMember(Order = 6)]
            public string ContentType { get; set; }

            [DataMember(Order = 7)]
            public string Accept { get; set; }

            public X509Certificate2 Certificate { get; set; }

            public ExtensionDataObject ExtensionData { get; set; }

            /// <summary>
            /// Do a deep copy clone of this object.
            /// </summary>
            /// <returns>A clone of this object.</returns>
            public Request Clone()
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Request));
                    serializer.WriteObject(stream, this);
                    stream.Position = 0;
                    Request request = (Request)serializer.ReadObject(stream);
                    request.Certificate = this.Certificate;
                    return request;
                }
            }
        }

        [DataContract(Name = "ResponseInfo")]
        public class Response : IExtensibleDataObject
        {
            [DataMember(Order = 0)]
            public HttpStatusCode StatusCode { get; set; }

            [DataMember(Order = 1)]
            public HeaderCollection Headers { get; set; }

            [DataMember(Order = 2)]
            public CookieCollection Cookies { get; set; }

            [DataMember(Order = 3)]
            public string ResponseText { get; set; }

            public ExtensionDataObject ExtensionData { get; set; }
        }

        public ExtensionDataObject ExtensionData { get; set; }

        /// <summary>
        /// Collection of cookies.
        /// </summary>
        [CollectionDataContract(Name = "Cookies", ItemName = "Cookie")]
        public class CookieCollection : List<Cookie>
        {
            public CookieCollection()
            {
            }

            public CookieCollection(IEnumerable<Cookie> cookies)
                : base(cookies)
            {
            }

            public string this[string name]
            {
                get
                {
                    return this.Where((c) => c.Name == name).Single().Value;
                }
            }

            public bool Contains(string name)
            {
                return this.Where((c) => c.Name == name).Count() > 0;
            }
        }

        /// <summary>
        /// Stores information about a cookie.
        /// </summary>
        [DataContract(Name = "Cookie")]
        public class Cookie : IExtensibleDataObject
        {
            [DataMember(Order = 0)]
            public string Name { get; set; }

            [DataMember(Order = 1)]
            public string Value { get; set; }

            [DataMember(Order = 2)]
            public Uri RelativeUri { get; set; }

            public ExtensionDataObject ExtensionData { get; set; }
        }

        /// <summary>
        /// Collection of headers.
        /// </summary>
        [CollectionDataContract(Name = "Headers", ItemName = "Header")]
        public class HeaderCollection : List<Header>
        {
            public HeaderCollection()
            {
            }

            public HeaderCollection(IEnumerable<Header> headers)
                : base(headers)
            {
            }

            public string this[string name]
            {
                get
                {
                    return this.Where((h) => h.Name == name).Single().Value;
                }
                set
                {
                    this.Where((h) => h.Name == name).Single().Value = value;
                }
            }

            public bool Contains(string name)
            {
                return this.Where((c) => c.Name == name).Count() > 0;
            }
        }

        /// <summary>
        /// Stores information about a header.
        /// </summary>
        [DataContract(Name = "Header")]
        public class Header : IExtensibleDataObject
        {
            [DataMember(Order = 0)]
            public string Name { get; set; }

            [DataMember(Order = 1)]
            public string Value { get; set; }

            public ExtensionDataObject ExtensionData { get; set; }
        }
    }
}
