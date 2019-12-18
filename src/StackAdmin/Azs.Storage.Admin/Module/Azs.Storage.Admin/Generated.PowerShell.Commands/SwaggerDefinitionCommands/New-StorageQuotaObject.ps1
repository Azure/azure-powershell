<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Storage quota properties.

.DESCRIPTION
    Storage quota properties.

.PARAMETER NumberOfStorageAccounts
    Total number of storage accounts.

.PARAMETER CapacityInGb
    Maxium capacity (GB).

#>
function New-StorageQuotaObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [int32]
        $NumberOfStorageAccounts,
    
        [Parameter(Mandatory = $false)]
        [int32]
        $CapacityInGb
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota -ArgumentList @()

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

