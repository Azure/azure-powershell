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
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services
{
    /// <summary>
    /// Data contract used for the serialization of the Error Information
    /// </summary>
    [DataContract(Name = "Error", Namespace = Constants.WebServicesNamespace)]
    public class ServiceResourceError : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }

        [DataMember(Order = 2)]
        public ServiceResourceError InnerError { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }

        /// <summary>
        /// Tries to deserialized instance of <see cref="ServiceResourceError"/> to its object equivalent.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="input">A stream that contains a serialized instance of <see cref="ServiceResourceError"/> to convert.</param>
        /// <param name="result">When the method returns, contains the deserialized <see cref="ServiceResourceError"/> object,
        /// if the conversion succeeded, or <c>null</c>, if the conversion failed.</param>
        /// <returns><c>true</c> if the input parameter is successfully converted; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string input, out ServiceResourceError result)
        {
            result = null;

            if (input == null)
            {
                return false;
            }

            // Deserialize the stream using DataContractSerializer.
            try
            {
                using (XmlDictionaryReader xmlReader = XmlDictionaryReader.CreateTextReader(
                    Encoding.UTF8.GetBytes(input),
                    new XmlDictionaryReaderQuotas()))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ServiceResourceError));
                    result = (ServiceResourceError)serializer.ReadObject(xmlReader, true);
                    return true;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }
    }
}
