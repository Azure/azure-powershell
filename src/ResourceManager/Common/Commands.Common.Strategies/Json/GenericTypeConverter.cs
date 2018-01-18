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
    abstract class GenericTypeConverter : IConverter
    {
        public object Deserialize(Converters converters, Type type, JToken token)
            => CreateConverter(type).Deserialize(converters, token);

        public bool Match(Type type)
            => GetGenericArguments(type) != null;

        public JToken Serialize(Converters converters, Type type, object value)
            => CreateConverter(type).Serialize(converters, value);

        protected abstract Type ConverterGenericType { get; }

        protected abstract Type[] GetGenericArguments(Type type);

        IConverter CreateConverter(Type type)
            => Activator.CreateInstance(
                    ConverterGenericType.MakeGenericType(GetGenericArguments(type)))
                as IConverter;

        protected interface IConverter
        {
            JToken Serialize(Converters converters, object value);
            object Deserialize(Converters converters, JToken value);
        }

        protected abstract class ConverterBase<T> : IConverter
        {
            JToken IConverter.Serialize(Converters converters, object value)
                => Serialize(converters, (T)value);

            object IConverter.Deserialize(Converters converters, JToken value)
                => Deserialize(converters, value);

            public abstract JToken Serialize(Converters converters, T value);

            public abstract T Deserialize(Converters converters, JToken value);
        }
    }
}
