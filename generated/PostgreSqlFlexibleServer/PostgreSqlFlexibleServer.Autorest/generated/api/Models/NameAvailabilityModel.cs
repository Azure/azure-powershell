// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Availability of a name.</summary>
    public partial class NameAvailabilityModel :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INameAvailabilityModel,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INameAvailabilityModelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponse"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponse __checkNameAvailabilityResponse = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.CheckNameAvailabilityResponse();

        /// <summary>Detailed reason why the given name is not available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponseInternal)__checkNameAvailabilityResponse).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponseInternal)__checkNameAvailabilityResponse).Message = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INameAvailabilityModelInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INameAvailabilityModelInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name for which validity and availability was checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Indicates if the resource name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public bool? NameAvailable { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponseInternal)__checkNameAvailabilityResponse).NameAvailable; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponseInternal)__checkNameAvailabilityResponse).NameAvailable = value ?? default(bool); }

        /// <summary>The reason why the given name is not available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponseInternal)__checkNameAvailabilityResponse).Reason; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponseInternal)__checkNameAvailabilityResponse).Reason = value ?? null; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>
        /// Type of resource. It can be 'Microsoft.DBforPostgreSQL/flexibleServers' or 'Microsoft.DBforPostgreSQL/flexibleServers/virtualendpoints'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="NameAvailabilityModel" /> instance.</summary>
        public NameAvailabilityModel()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__checkNameAvailabilityResponse), __checkNameAvailabilityResponse);
            await eventListener.AssertObjectIsValid(nameof(__checkNameAvailabilityResponse), __checkNameAvailabilityResponse);
        }
    }
    /// Availability of a name.
    public partial interface INameAvailabilityModel :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponse
    {
        /// <summary>Name for which validity and availability was checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Name for which validity and availability was checked.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>
        /// Type of resource. It can be 'Microsoft.DBforPostgreSQL/flexibleServers' or 'Microsoft.DBforPostgreSQL/flexibleServers/virtualendpoints'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Type of resource. It can be 'Microsoft.DBforPostgreSQL/flexibleServers' or 'Microsoft.DBforPostgreSQL/flexibleServers/virtualendpoints'.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Availability of a name.
    internal partial interface INameAvailabilityModelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICheckNameAvailabilityResponseInternal
    {
        /// <summary>Name for which validity and availability was checked.</summary>
        string Name { get; set; }
        /// <summary>
        /// Type of resource. It can be 'Microsoft.DBforPostgreSQL/flexibleServers' or 'Microsoft.DBforPostgreSQL/flexibleServers/virtualendpoints'.
        /// </summary>
        string Type { get; set; }

    }
}