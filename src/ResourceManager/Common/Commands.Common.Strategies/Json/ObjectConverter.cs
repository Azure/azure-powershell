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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies.Json
{
    class ObjectConverter : IConverter
    {
        public object Deserialize(Converters converters, Type type, JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Array:
                    return converters.Deserialize<List<object>>(token);
                case JTokenType.String:
                    return converters.Deserialize<string>(token);
                case JTokenType.Boolean:
                    return converters.Deserialize<bool>(token);
                case JTokenType.Float:
                case JTokenType.Integer:
                    return converters.Deserialize<double>(token);
                case JTokenType.Object:
                    return converters.Deserialize<Dictionary<string, object>>(token);
                default:
                    return null;
            }
        }

        public bool Match(Type type)
            => type == typeof(object);

        public JToken Serialize(Converters converters, Type type, object value)
            => converters.Serialize(value.GetType(), value);
    }
}
