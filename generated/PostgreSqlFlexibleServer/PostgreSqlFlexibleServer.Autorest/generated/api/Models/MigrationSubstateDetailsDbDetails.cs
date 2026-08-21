// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    public partial class MigrationSubstateDetailsDbDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetailsInternal
    {

        /// <summary>Creates an new <see cref="MigrationSubstateDetailsDbDetails" /> instance.</summary>
        public MigrationSubstateDetailsDbDetails()
        {

        }
    }
    public partial interface IMigrationSubstateDetailsDbDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState>
    {

    }
    internal partial interface IMigrationSubstateDetailsDbDetailsInternal

    {

    }
}