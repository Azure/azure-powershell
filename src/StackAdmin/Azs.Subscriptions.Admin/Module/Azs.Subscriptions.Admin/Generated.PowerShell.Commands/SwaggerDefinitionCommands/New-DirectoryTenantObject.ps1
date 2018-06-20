<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Directory tenant.

.DESCRIPTION
    Directory tenant.

.PARAMETER Id
    URI of the resource.

.PARAMETER Type
    Type of resource.

.PARAMETER Tags
    List of key-value pairs.

.PARAMETER Name
    Name of the resource.

.PARAMETER TenantId
    Tenant unique identifier.

.PARAMETER Location
    Location of the resource.

#>
function New-DirectoryTenantObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $Id,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Type,
    
        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string],[string]]]
        $Tags,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Name,
    
        [Parameter(Mandatory = $false)]
        [string]
        $TenantId,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Location
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Subscriptions.Admin.Models.DirectoryTenant -ArgumentList @($id,$name,$type,$location,$tags,$tenantId)

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

