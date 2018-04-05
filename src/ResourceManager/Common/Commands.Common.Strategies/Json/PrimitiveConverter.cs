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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Common.Strategies.Json
{
    class PrimitiveConverter : IConverter
    {
        readonly static JsonSerializer _Serializer = JsonSerializer.CreateDefault();

        public bool Match(Type type)
            => type == typeof(string) || type.IsPrimitive || type.IsEnum;

        public object Deserialize(Converters converters, Type type, JToken token)
            // Because of the bug in Newtonsoft.Json 6.0
            // https://github.com/JamesNK/Newtonsoft.Json/issues/616
            // we can't use just `token.ToObject(type)`.
            => token.ToObject(type, _Serializer);

        public JToken Serialize(Converters converters, Type type, object value)
            => JToken.FromObject(value, _Serializer);
    }
}
