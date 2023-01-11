using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    internal class CamelCasePropertyNamesWithOverridesContractResolver : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// Creates <c>JSON</c> property for the class member.
        /// </summary>
        /// <param name="member">The member to serialize.</param>
        /// <param name="memberSerialization">The type of member serialization.</param>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var result = base.CreateProperty(member, memberSerialization);

            var attributes = member.GetCustomAttributes(attributeType: typeof(JsonPropertyAttribute), inherit: true);
            if (!attributes.Any()) return result;

            var propertyName = attributes.Cast<JsonPropertyAttribute>().Single().PropertyName;
            if (!string.IsNullOrEmpty(propertyName))
            {
                result.PropertyName = propertyName;
            }

            return result;
        }

        /// <summary>
        /// Creates dictionary contract
        /// </summary>
        /// <param name="objectType">The object type.</param>
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var contract = base.CreateDictionaryContract(objectType);

            // TODO: Remove IfDef code
#if NETSTANDARD
            contract.DictionaryKeyResolver = keyName => keyName;
#else
            contract.PropertyNameResolver = propertyName => propertyName;
#endif
            return contract;
        }
    }
}
