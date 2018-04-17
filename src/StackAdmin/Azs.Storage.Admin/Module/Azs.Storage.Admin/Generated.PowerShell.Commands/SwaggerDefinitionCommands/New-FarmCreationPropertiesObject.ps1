<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Storage farm properties.

.DESCRIPTION
    Storage farm properties.

.PARAMETER Id
    Resource ID.

.PARAMETER Type
    Resource type.

.PARAMETER SettingAccessString
    Setting access string.

.PARAMETER Tags
    Resource tags.

.PARAMETER Name
    Resource Name.

.PARAMETER Location
    Resource location.

#>
function New-FarmCreationPropertiesObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $Id,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Type,
    
        [Parameter(Mandatory = $false)]
        [string]
        $SettingAccessString,
    
        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[string],[string]]]
        $Tags,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Name,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Location
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Storage.Admin.Models.FarmCreationProperties

    $PSBoundParameters.GetEnumerator() | ForEach-Object { 
        if(Get-Member -InputObject $Object -Name $_.Key -MemberType Property)
        {
            $Object.$($_.Key) = $_.Value
        }
    }

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

