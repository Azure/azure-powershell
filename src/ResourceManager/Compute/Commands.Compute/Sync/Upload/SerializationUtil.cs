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

using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Sync.Upload
{
    internal class SerializationUtil
    {
        public static T GetObjectFromSerializedString<T>(string data)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                return (T)serializer.ReadObject(memoryStream);
            }
        }

        public static string GetSerializedString<T>(T localMetaData)
        {
            var serializer = new DataContractSerializer(typeof(T));
            string serializedString;
            using (var memoryStream = new MemoryStream())
            {
                serializer.WriteObject(memoryStream, localMetaData);
                memoryStream.Flush();
                byte[] bytes = memoryStream.ToArray();
                serializedString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            }
            return serializedString;
        }
    }
}