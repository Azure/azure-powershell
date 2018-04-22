<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Parameters of container migration job.

.DESCRIPTION
    Parameters of container migration job.

.PARAMETER ContainerName
    The name of the container to be migrated.

.PARAMETER StorageAccountName
    The name of storage account where the container locates.

.PARAMETER DestinationShareUncPath
    The UNC path of the destination share for migration.

#>
function New-MigrationParametersObject
{
    param(
        [Parameter(Mandatory = $true)]
        [string]
        $ContainerName,

        [Parameter(Mandatory = $true)]
        [string]
        $StorageAccountName,

        [Parameter(Mandatory = $true)]
        [string]
        $DestinationShareUncPath
    )

    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Storage.Admin.Models.MigrationParameters

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

