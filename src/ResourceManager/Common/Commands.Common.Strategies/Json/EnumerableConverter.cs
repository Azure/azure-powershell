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
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Json
{
    class EnumerableConverter : GenericTypeConverter
    {
        protected override Type ConverterGenericType => typeof(Converter<>);

        protected override Type[] GetGenericArguments(Type type)
            => type.GetGenericArguments(typeof(IEnumerable<>), i => i.GetGenericArguments());

        class Converter<T> : ConverterBase<IEnumerable<T>>
        {
            public override IEnumerable<T> Deserialize(Converters converters, JToken token)
                => (token as JArray).Select(converters.Deserialize<T>).ToList();

            public override JToken Serialize(Converters converters, IEnumerable<T> value)
            {
                var array = new JArray();
                foreach (var item in value)
                {
                    array.Add(converters.Serialize(item));
                }
                return array;
            }
        }
    }
}
