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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.Azure;
using System.Data.Services.Client;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// Struct that parse and store exception information from the Management Service.
    /// </summary>
    public struct ManagementServiceExceptionInfo
    {
        private const char EscapeChar = '\\';
        private const char KeyValueSeparatorChar = '=';
        private const char PairSeparatorChar = ',';

        private static readonly Regex errorCodeParser = new Regex(@"(?<ErrorType>.*):(?<ActivityId>[0-9a-f\-]+)(\[(?<KeyValuePairs>.*)\])?", RegexOptions.Singleline | RegexOptions.Compiled);

        private readonly string errorType;
        private readonly Guid activityId;
        private readonly IDictionary propertyBag;

        private ManagementServiceExceptionInfo(string errorType, Guid activityId, IDictionary propertyBag)
        {
            this.errorType = errorType;
            this.activityId = activityId;
            this.propertyBag = propertyBag;
        }

        /// <summary>
        /// Gets the error type for the exception
        /// </summary>
        public string ErrorType
        {
            get { return this.errorType; }
        }

        /// <summary>
        /// Gets the activity Id for the exception
        /// </summary>
        public Guid ActivityId
        {
            get { return this.activityId; }
        }

        /// <summary>
        /// Gets the property bag for the exception
        /// </summary>
        public IDictionary PropertyBag
        {
            get { return this.propertyBag; }
        }      

        /// <summary>
        /// Tries to convert the given exception message to a <see cref="ManagementServiceExceptionInfo"/>.
        /// </summary>
        /// <param name="message">The message containing the xml serialized error information.</param>
        /// <param name="info">The converted <see cref="ManagementServiceExceptionInfo"/> containing errors from the exception.</param>
        /// <returns><c>true</c> if parsing succeeded.</returns>
        public static bool TryParse(string message, out ManagementServiceExceptionInfo info)
        {
            string errorType;
            Guid activityId;
            IDictionary propertyBag;

            if (string.IsNullOrEmpty(message))
            {
                // Empty message
                info = default(ManagementServiceExceptionInfo);
                return false;
            }

            XDocument errorDocument;
            try
            {
                errorDocument = XDocument.Parse(message);
            }
            catch (XmlException)
            {
                // Invalid xml
                info = default(ManagementServiceExceptionInfo);
                return false;
            }

            if (errorDocument == null)
            {
                // Invalid xml
                info = default(ManagementServiceExceptionInfo);
                return false;
            }

            // Attempt to get error information from the standard location in a DataServiceException.
            XElement errorMessage;
            errorMessage = errorDocument.Descendants().Where(x => x.Name.LocalName == "code").FirstOrDefault();            

            if (errorMessage == null)
            {
                // Attempt to get error information from the exception Message.  This happens in the case of a WebServiceAuthenticationException
                // being thrown by Management Service.              
                errorMessage = errorDocument.Descendants().Where(x => x.Name.LocalName == "Message").FirstOrDefault();

                if (errorMessage == null)
                {
                    // Unable to find an error message.
                    info = default(ManagementServiceExceptionInfo);
                    return false;
                }
            }

            // Use Regex to parse the message
            Match code = errorCodeParser.Match(errorMessage.Value);
            if (code == null)
            {
                // Regex parsing failed
                info = default(ManagementServiceExceptionInfo);
                return false;
            }

            errorType = code.Groups["ErrorType"].Value;

            try
            {
                activityId = new Guid(code.Groups["ActivityId"].Value);
            }
            catch (FormatException)
            {
                // Guid parsing failed
                info = default(ManagementServiceExceptionInfo);
                return false;
            }

            // Only parse the property bag if it exists
            if (code.Groups["KeyValuePairs"].Success)
            {
                try
                {
                    string dataStr = code.Groups["KeyValuePairs"].Value;
                    propertyBag = (IDictionary)Deserialize(dataStr);
                }
                catch (Exception)
                {
                    // Invalid property bag
                    info = default(ManagementServiceExceptionInfo);
                    return false;
                }
            }
            else
            {
                // create an empty property bag
                propertyBag = (IDictionary)new Dictionary<string, string>();
            }

            info = new ManagementServiceExceptionInfo(errorType, activityId, propertyBag);
            return true;
        }        

        /// <summary>
        /// Converts the given exception message to a <see cref="ManagementServiceExceptionInfo"/>.
        /// </summary>
        /// <param name="message">The message containing the xml serialized error information.</param>
        /// <returns>The converted <see cref="ManagementServiceExceptionInfo"/> containing errors from the exception</returns>
        public static ManagementServiceExceptionInfo Parse(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("message");
            }

            ManagementServiceExceptionInfo info;
            if (ManagementServiceExceptionInfo.TryParse(message, out info))
            {
                return info;
            }
            else
            {
                throw new FormatException(Resources.InvalidExceptionMessageFormat);
            }
        }

        /// <summary>
        /// Tries to convert the given exception response to a <see cref="ManagementServiceExceptionInfo"/>.
        /// </summary>
        /// <param name="response">The response containing the xml serialized error information.</param>
        /// <param name="info">The converted <see cref="ManagementServiceExceptionInfo"/> containing errors from the exception.</param>
        /// <returns><c>true</c> if parsing succeeded.</returns>
        public static bool TryParse(OperationResponse response, out ManagementServiceExceptionInfo info)
        {
            if (response != null && response.Error != null)
            {
                return ManagementServiceExceptionInfo.TryParse(response.Error.Message, out info);
            }

            info = default(ManagementServiceExceptionInfo);
            return false;
        }

        /// <summary>
        /// Converts the given exception response to a <see cref="ManagementServiceExceptionInfo"/>.
        /// </summary>
        /// <param name="response">The response containing the xml serialized error information.</param>
        /// <returns>The converted <see cref="ManagementServiceExceptionInfo"/> containing errors from the exception.</returns>
        public static ManagementServiceExceptionInfo Parse(OperationResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            if (response.Error == null)
            {
                throw new ArgumentException(Resources.InvalidErrorInResponse, "response");
            }

            ManagementServiceExceptionInfo info;
            if (ManagementServiceExceptionInfo.TryParse(response, out info))
            {
                return info;
            }
            else
            {
                throw new FormatException(Resources.InvalidExceptionMessageFormat);
            }
        }

        /// <summary>
        /// De-serializes a <c>string</c> representation of an exception data key/vlaue pairs.
        /// </summary>
        /// <param name="str">The <c>string</c> to de-serialize.</param>
        /// <returns>A dictionary that contains the key/value pairs.</returns>
        private static IDictionary<string, string> Deserialize(string str)
        {
            IDictionary<string, string> data = new Dictionary<string, string>(4);

            StringBuilder builder = new StringBuilder(str.Length);

            bool escaped = false;

            string key = null;
            string value = null;

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (escaped)
                {
                    // the character is escaped so we add it to the string that we build
                    builder.Append(c);
                    escaped = false;
                }
                else
                {
                    switch (c)
                    {
                        case EscapeChar:
                            escaped = true;
                            break;

                        case KeyValueSeparatorChar:
                            // we here identified a key
                            key = builder.ToString();
                            builder.Length = 0;
                            break;

                        case PairSeparatorChar:
                            // we here identified a key/value pair
                            value = builder.ToString();
                            builder.Length = 0;

                            // add a new key/value pair and reset their values
                            data[key] = value;
                            key = null;
                            value = null;
                            break;

                        default:
                            // add all other characters to the string the we build
                            builder.Append(c);
                            break;
                    }
                }
            }

            if (key != null)
            {
                value = builder.ToString();
                data[key] = value;
            }

            return data;
        }        
    }
}
