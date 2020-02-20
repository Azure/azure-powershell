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

namespace Microsoft.Azure.Commands.DeploymentManager.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Custom Convertor for deserializing JSON
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        ///     Gets a value indicating whether this Newtonsoft.Json.JsonConverter can write JSON
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(
            Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        /// <summary>
        ///     Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The Newtonsoft.Json.JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>the type of object</returns>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            // Load JObject from stream 
            var jObject = JObject.Load(reader);

            // Create target object based on JObject 
            var target = this.Create(
                objectType,
                jObject);

            // Populate the object properties 
            serializer.Populate(
                jObject.CreateReader(),
                target);

            return target;
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Create an instance of objectType, based on properties in the JSON object
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="jObject">Contents of JSON object that will be deserialized.</param>
        /// <returns>Returns object of type.</returns>
        protected abstract T Create(
            Type objectType,
            JObject jObject);
    }

    /// <summary>
    ///     Custom Convertor for deserializing RecoveryPlanActionDetails(RecoveryPlan) object
    /// </summary>
    [JsonConverter(typeof(PSHealthCheckStepAttributes))]
    public class HealthCheckAttributesConverter :
        JsonCreationConverter<PSHealthCheckStepAttributes>
    {
        /// <summary>
        ///     Gets a value indicating whether this Newtonsoft.Json.JsonConverter can write JSON
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        ///     Creates recovery plan action custom details.
        /// </summary>
        /// <param name="objectType">Object type.</param>
        /// <param name="jObject">JSON object that will be deserialized.</param>
        /// <returns>Returns recovery plan action custom details.</returns>
        protected override PSHealthCheckStepAttributes Create(
            Type objectType,
            JObject jObject)
        {
            PSHealthCheckStepAttributes outputType = null;
            var actionType = (PSHealthCheckType)Enum.Parse(
                typeof(PSHealthCheckType),
                jObject.Value<string>("type"));

            switch (actionType)
            {
                case PSHealthCheckType.REST:
                    outputType = new PSRestHealthCheckStepAttributes();
                    break;
            }

            return outputType;
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            string instanceType = null;
            if (value != null)
            {
                if (string.Compare(value.GetType().ToString(), typeof(PSRestHealthCheckStepAttributes).ToString()) == 0)
                {
                    instanceType = PSHealthCheckType.REST.ToString();
                }
            }

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

                o.AddFirst(new JProperty("type", instanceType));

                o.WriteTo(writer);
            }
        }
    }

    /// <summary>
    ///     Custom Convertor for deserializing RecoveryPlanActionDetails(RecoveryPlan) object
    /// </summary>
    [JsonConverter(typeof(PSRestRequestAuthentication))]
    public class RestRequestAuthenticationConverter :
        JsonCreationConverter<PSRestRequestAuthentication>
    {
        /// <summary>
        ///     Gets a value indicating whether this Newtonsoft.Json.JsonConverter can write JSON
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        ///     Creates recovery plan action custom details.
        /// </summary>
        /// <param name="objectType">Object type.</param>
        /// <param name="jObject">JSON object that will be deserialized.</param>
        /// <returns>Returns recovery plan action custom details.</returns>
        protected override PSRestRequestAuthentication Create(
            Type objectType,
            JObject jObject)
        {
            PSRestRequestAuthentication outputType = null;
            var actionType = (PSRestAuthType)Enum.Parse(
                typeof(PSRestAuthType),
                jObject.Value<string>("type"));

            switch (actionType)
            {
                case PSRestAuthType.ApiKey:
                    outputType = new PSApiKeyAuthentication();
                    break;

                case PSRestAuthType.RolloutIdentity:
                    outputType = new PSRolloutIdentityAuthentication();
                    break;
            }

            return outputType;
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            string instanceType = null;
            if (value != null)
            {
                if (string.Compare(value.GetType().ToString(), typeof(PSApiKeyAuthentication).ToString()) == 0)
                {
                    instanceType = PSRestAuthType.ApiKey.ToString();
                }
                else if (string.Compare(value.GetType().ToString(), typeof(PSRolloutIdentityAuthentication).ToString()) == 0)
                {
                    instanceType = PSRestAuthType.RolloutIdentity.ToString();
                }
            }

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

                o.AddFirst(new JProperty("type", instanceType));

                o.WriteTo(writer);
            }
        }
    }
}
