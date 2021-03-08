namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Subscriber detail</summary>
    public partial class UserDetail
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail FromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json ? new UserDetail(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="UserDetail" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="UserDetail" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._firstName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._firstName.ToString()) : null, "firstName" ,container.Add );
            AddIf( null != (((object)this._lastName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._lastName.ToString()) : null, "lastName" ,container.Add );
            AddIf( null != (((object)this._emailAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._emailAddress.ToString()) : null, "emailAddress" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject into a new instance of <see cref="UserDetail" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal UserDetail(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_firstName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("firstName"), out var __jsonFirstName) ? (string)__jsonFirstName : (string)FirstName;}
            {_lastName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("lastName"), out var __jsonLastName) ? (string)__jsonLastName : (string)LastName;}
            {_emailAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("emailAddress"), out var __jsonEmailAddress) ? (string)__jsonEmailAddress : (string)EmailAddress;}
            AfterFromJson(json);
        }
    }
}