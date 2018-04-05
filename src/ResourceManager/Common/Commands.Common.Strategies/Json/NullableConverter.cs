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

namespace Microsoft.Azure.Commands.Common.Strategies.Json
{
    class NullableConverter : GenericTypeConverter
    {
        protected override Type[] GetGenericArguments(Type type)
            => type.IsGenericType(typeof(Nullable<>)) ? type.GetGenericArguments() : null;

        protected override Type ConverterGenericType => typeof(Converter<>);

        class Converter<T> : ConverterBase<T?>
            where T : struct
        {
            public override T? Deserialize(Converters converters, JToken token)
                => token.Type == JTokenType.Null ? new T?() : converters.Deserialize<T>(token);

            public override JToken Serialize(Converters converters, T? value)
                => value.HasValue ? converters.Serialize(value.Value) : null;
        }
    }
}
