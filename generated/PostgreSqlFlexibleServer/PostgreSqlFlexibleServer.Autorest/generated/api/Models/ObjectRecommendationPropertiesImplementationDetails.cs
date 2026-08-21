// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Implementation details for the recommended action.</summary>
    public partial class ObjectRecommendationPropertiesImplementationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetails,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetailsInternal
    {

        /// <summary>Backing field for <see cref="Method" /> property.</summary>
        private string _method;

        /// <summary>Method of implementation for recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Method { get => this._method; set => this._method = value; }

        /// <summary>Backing field for <see cref="Script" /> property.</summary>
        private string _script;

        /// <summary>Implementation script for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Script { get => this._script; set => this._script = value; }

        /// <summary>
        /// Creates an new <see cref="ObjectRecommendationPropertiesImplementationDetails" /> instance.
        /// </summary>
        public ObjectRecommendationPropertiesImplementationDetails()
        {

        }
    }
    /// Implementation details for the recommended action.
    public partial interface IObjectRecommendationPropertiesImplementationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Method of implementation for recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Method of implementation for recommended action.",
        SerializedName = @"method",
        PossibleTypes = new [] { typeof(string) })]
        string Method { get; set; }
        /// <summary>Implementation script for the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Implementation script for the recommended action.",
        SerializedName = @"script",
        PossibleTypes = new [] { typeof(string) })]
        string Script { get; set; }

    }
    /// Implementation details for the recommended action.
    internal partial interface IObjectRecommendationPropertiesImplementationDetailsInternal

    {
        /// <summary>Method of implementation for recommended action.</summary>
        string Method { get; set; }
        /// <summary>Implementation script for the recommended action.</summary>
        string Script { get; set; }

    }
}