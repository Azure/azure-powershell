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
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient
{
    internal class JsonNumericConverter : JsonConverter
    {
        //We use this converter only for writing longs properly, not for reading them back
        public override bool CanRead
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
                writer.WriteValue(value.ToString()); // adds quotes around the number
            else
                writer.WriteNull();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(long) || objectType == typeof(long?)
                    || objectType == typeof(ulong) || objectType == typeof(ulong?)
                    || objectType == typeof(float) || objectType == typeof(float?)
                    || objectType == typeof(double) || objectType == typeof(double?));
        }
    }
}
