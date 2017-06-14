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
using System.Linq;
using System.Xml.Linq;

namespace StaticAnalysis
{
    public static class XmlExtensions
    {
        /// <summary>
        /// Get all child elements with the given name
        /// </summary>
        /// <param name="parent">The element to search</param>
        /// <param name="name">The child element name to search for</param>
        /// <returns>An enumeration of child elements with the given name, or null if none 
        /// are found.</returns>
        public static IEnumerable<XElement> GetChildElements(this XElement parent, string name)
        {
            return parent.Descendants().Where(e => String.Equals(e.Name.LocalName, name));
        }

        /// <summary>
        /// Get all child elements with the given name that satisfy the given predicate
        /// </summary>
        /// <param name="parent">The element to search</param>
        /// <param name="name">The child element name to search for</param>
        /// <param name="predicate">The additional condition to satisfy</param>
        /// <returns>An enumeration of child elements with the given name that satisfy the predicate, 
        /// or null if none are found.</returns>
        public static IEnumerable<XElement> GetChildElements(this XElement parent, string name, 
            Func<XElement, bool> predicate )
        {
            return parent.Descendants().Where(e => String.Equals(e.Name.LocalName, name) 
                && predicate(e));
        }

        /// <summary>
        /// Get the first child element with the given name
        /// </summary>
        /// <param name="parent">The element to search</param>
        /// <param name="name">The child element name to search for</param>
        /// <returns>The child element with the given name, or null if none are found.</returns>
        public static XElement GetChildElement(this XElement parent, string name)
        {
            return parent.Descendants().FirstOrDefault(e => String.Equals(e.Name.LocalName, name));
        }

        /// <summary>
        /// Get the first child element with the given name that satisfies the given predicate
        /// </summary>
        /// <param name="parent">The element to search</param>
        /// <param name="name">The child element name to search for</param>
        /// <param name="predicate">Additional conditions over the desired child element</param>
        /// <returns></returns>
        public static XElement GetChildElement(this XElement parent, string name, 
            Func<XElement, bool> predicate )
        {
            return parent.Descendants().FirstOrDefault(e => String.Equals(e.Name.LocalName, name) 
                && predicate(e));
        }

        /// <summary>
        /// Determines if the given element contains a child element of the given name
        /// </summary>
        /// <param name="element">The element to search</param>
        /// <param name="name">The child element name to search for</param>
        /// <returns>true if the given child element exists, otherwise false</returns>
        public static bool ContainsChildElement(this XElement element, string name)
        {
            return element.Descendants().Any(e => string.Equals(e.Name.LocalName, name));
        }

        /// <summary>
        /// Determines if the given element contains a child element of the given name that satisfies 
        /// the specified predicate
        /// </summary>
        /// <param name="element">The element to search</param>
        /// <param name="name">The child element name to search for</param>
        /// <param name="predicate">An additional condition on descendant elements</param>
        /// <returns>true if the given child element exists, otherwise false</returns>
        public static bool ContainsChildElement(this XElement element, string name, 
            Func<XElement, bool> predicate)
        {
            return element.Descendants().Any(e => string.Equals(e.Name.LocalName, name) 
                && predicate(e));
        }

        /// <summary>
        /// Determines if the given element contains a child element with any of the provided names
        /// </summary>
        /// <param name="element">The element to search</param>
        /// <param name="names">The child element names to search for</param>
        /// <returns>true if any of the given child elements exists, otherwise false</returns>
        public static bool ContainsChildElement(this XElement element, IEnumerable<string> names)
        {
            return names.Any(element.ContainsChildElement);
        }

        /// <summary>
        /// Determines if the given element contains a child element with any of the provided names that 
        /// satisfies the given predicate
        /// </summary>
        /// <param name="element">The element to search</param>
        /// <param name="names">The child element names to search for</param>
        /// <param name="predicate">An additional condition to check on descendant elements</param>
        /// <returns>True if any child element has the specified name and satisfies the specified 
        /// predicate.</returns>
        public static bool ContainsChildElement(this XElement element, IEnumerable<string> names, 
            Func<XElement, bool> predicate )
        {
            return names.Any( n => element.ContainsChildElement(n, predicate));
        }
    }
}
