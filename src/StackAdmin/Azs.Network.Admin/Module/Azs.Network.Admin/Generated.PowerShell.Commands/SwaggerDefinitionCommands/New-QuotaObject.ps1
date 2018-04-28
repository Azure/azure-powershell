<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Network quota resource.

.DESCRIPTION
    Network quota resource.

.PARAMETER Tags
    List of key value pairs.

.PARAMETER Type
    Type of resource.

.PARAMETER MigrationPhase
    State of migration such as None, Prepare, Commit, and Abort.

.PARAMETER MaxNicsPerSubscription
    Maximum number of NICs a tenant subscription can provision.

.PARAMETER MaxPublicIpsPerSubscription
    Maximum number of public IP addresses a tenant subscription can provision.

.PARAMETER MaxVirtualNetworkGatewayConnectionsPerSubscription
    Maximum number of virtual network gateway Connections a tenant subscription can provision.

.PARAMETER Name
    Name of the resource.

.PARAMETER Id
    URI of the resource.

.PARAMETER MaxVnetsPerSubscription
    Maximum number of virtual networks a tenant subscription can provision.

.PARAMETER MaxVirtualNetworkGatewaysPerSubscription
    Maximum number of virtual network gateways a tenant subscription can provision.

.PARAMETER MaxSecurityGroupsPerSubscription
    Maximum number of security groups a tenant subscription can provision.

.PARAMETER Location
    Region location of resource.

.PARAMETER MaxLoadBalancersPerSubscription
    Maximum number of load balancers a tenant subscription can provision.

#>
function New-QuotaObject {
    param(
        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string], [string]]]
        $Tags,

        [Parameter(Mandatory = $false)]
        [string]
        $Type,

        [Parameter(Mandatory = $false)]
        [ValidateSet('None', 'Prepare', 'Commit', 'Abort')]
        [string]
        $MigrationPhase = 'None',

        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxNicsPerSubscription,

        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxPublicIpsPerSubscription,

        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxVirtualNetworkGatewayConnectionsPerSubscription,

        [Parameter(Mandatory = $false)]
        [string]
        $Name,

        [Parameter(Mandatory = $false)]
        [string]
        $Id,

        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxVnetsPerSubscription,

        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxVirtualNetworkGatewaysPerSubscription,

        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxSecurityGroupsPerSubscription,

        [Parameter(Mandatory = $false)]
        [string]
        $Location,

        [Parameter(Mandatory = $false)]
        [System.Nullable`1[long]]
        $MaxLoadBalancersPerSubscription
    )

    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Network.Admin.Models.Quota -ArgumentList @($id, $name, $type, $location, $tags, $null, $maxPublicIpsPerSubscription, $maxVnetsPerSubscription, $maxVirtualNetworkGatewaysPerSubscription, $maxVirtualNetworkGatewayConnectionsPerSubscription, $maxLoadBalancersPerSubscription, $maxNicsPerSubscription, $maxSecurityGroupsPerSubscription, $migrationPhase)

    if (Get-Member -InputObject $Object -Name Validate -MemberType Method) {
        $Object.Validate()
    }

    return $Object
}

