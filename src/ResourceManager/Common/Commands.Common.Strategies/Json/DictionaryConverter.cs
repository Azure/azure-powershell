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
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies.Json
{
    class DictionaryConverter : GenericTypeConverter
    {
        protected override Type ConverterGenericType => typeof(Converter<>);

        protected override Type[] GetGenericArguments(Type type)
            => type.GetGenericArguments(
                typeof(IDictionary<,>),
                i => 
                {
                    var a = i.GetGenericArguments();
                    return a[0] == typeof(string) ? new[] { a[1] } : null;
                });

        sealed class Converter<T> : ConverterBase<IDictionary<string, T>>
        {
            public override IDictionary<string, T> Deserialize(Converters converters, JToken value)
                => (value as JObject)
                    .Properties()
                    .ToDictionary(j => j.Name, j => converters.Deserialize<T>(j.Value));

            public override JToken Serialize(Converters converters, IDictionary<string, T> value)
            {
                var result = new JObject();
                foreach (var kv in value)
                {
                    result[kv.Key] = converters.Serialize(kv.Value);
                }
                return result;
            }
        }
    }
}
