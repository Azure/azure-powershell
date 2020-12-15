namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Application properties that can be patched.</summary>
    public partial class ApplicationPatchProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject into a new instance of <see cref="ApplicationPatchProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ApplicationPatchProperties(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;}
            {_friendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("friendlyName"), out var __jsonFriendlyName) ? (string)__jsonFriendlyName : (string)FriendlyName;}
            {_filePath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("filePath"), out var __jsonFilePath) ? (string)__jsonFilePath : (string)FilePath;}
            {_commandLineSetting = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("commandLineSetting"), out var __jsonCommandLineSetting) ? (string)__jsonCommandLineSetting : (string)CommandLineSetting;}
            {_commandLineArgument = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("commandLineArguments"), out var __jsonCommandLineArguments) ? (string)__jsonCommandLineArguments : (string)CommandLineArgument;}
            {_showInPortal = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonBoolean>("showInPortal"), out var __jsonShowInPortal) ? (bool?)__jsonShowInPortal : ShowInPortal;}
            {_iconPath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("iconPath"), out var __jsonIconPath) ? (string)__jsonIconPath : (string)IconPath;}
            {_iconIndex = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber>("iconIndex"), out var __jsonIconIndex) ? (int?)__jsonIconIndex : IconIndex;}
            {_msixPackageFamilyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("msixPackageFamilyName"), out var __jsonMsixPackageFamilyName) ? (string)__jsonMsixPackageFamilyName : (string)MsixPackageFamilyName;}
            {_msixPackageApplicationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("msixPackageApplicationId"), out var __jsonMsixPackageApplicationId) ? (string)__jsonMsixPackageApplicationId : (string)MsixPackageApplicationId;}
            {_applicationType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("applicationType"), out var __jsonApplicationType) ? (string)__jsonApplicationType : (string)ApplicationType;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IApplicationPatchProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json ? new ApplicationPatchProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ApplicationPatchProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ApplicationPatchProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)this._friendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._friendlyName.ToString()) : null, "friendlyName" ,container.Add );
            AddIf( null != (((object)this._filePath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._filePath.ToString()) : null, "filePath" ,container.Add );
            AddIf( null != (((object)this._commandLineSetting)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._commandLineSetting.ToString()) : null, "commandLineSetting" ,container.Add );
            AddIf( null != (((object)this._commandLineArgument)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._commandLineArgument.ToString()) : null, "commandLineArguments" ,container.Add );
            AddIf( null != this._showInPortal ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonBoolean((bool)this._showInPortal) : null, "showInPortal" ,container.Add );
            AddIf( null != (((object)this._iconPath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._iconPath.ToString()) : null, "iconPath" ,container.Add );
            AddIf( null != this._iconIndex ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber((int)this._iconIndex) : null, "iconIndex" ,container.Add );
            AddIf( null != (((object)this._msixPackageFamilyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._msixPackageFamilyName.ToString()) : null, "msixPackageFamilyName" ,container.Add );
            AddIf( null != (((object)this._msixPackageApplicationId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._msixPackageApplicationId.ToString()) : null, "msixPackageApplicationId" ,container.Add );
            AddIf( null != (((object)this._applicationType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._applicationType.ToString()) : null, "applicationType" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}