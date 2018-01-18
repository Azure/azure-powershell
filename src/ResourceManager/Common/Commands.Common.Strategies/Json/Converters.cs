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

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Json
{
    public class Converters
    {
        readonly List<IConverter> _List = new List<IConverter>
        {   
            // JToken         
            new JTokenConverter(),

            // object
            new ObjectConverter(),

            // bool, string, double, etc.
            new PrimitiveConverter(),
            
            // T?
            new NullableConverter(),
            
            // T : IDictionary<string, X>
            new DictionaryConverter(),

            // T : IEnumerable<X>
            new EnumerableConverter(),

            // T
            new TypedObjectConverter(),
        };

        public JToken Serialize(Type type, object value)
            => value == null ? null : Find(type).Serialize(this, type, value);

        public object Deserialize(Type type, JToken token)
            => token == null ? null : Find(type).Deserialize(this, type, token);

        public JToken Serialize<T>(T value)
            => Serialize(typeof(T), value);

        public T Deserialize<T>(JToken token)
        {
            var result = Deserialize(typeof(T), token);
            return result == null ? default(T): (T)result;
        }

        IConverter Find(Type type)
            => _List.First(v => v.Match(type));
    }
}
