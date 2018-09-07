<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.

Manually created custom quota object class
#>

function ConvertTo-ComputeQuota {

    [OutputType([ComputeQuotaObject])]
    param(
        [Parameter(Mandatory = $true)]
        [Microsoft.AzureStack.Management.Compute.Admin.Models.Quota]
        $Quota
    )

    [ComputeQuotaObject] $result = @{}

    Get-Member -InputObject $Quota -MemberType Properties | ForEach-Object {
        $property = $_.Name
        $value = Select-Object -InputObject $Quota -ExpandProperty "$property"

        if($property -eq 'MaxAllocationStandardManagedDisksAndSnapshots') {
            $result.StandardManagedDiskAndSnapshotSize = $value
        } elseif($property -eq 'MaxAllocationPremiumManagedDisksAndSnapshots') {
            $result.PremiumManagedDiskAndSnapshotSize = $value
        } elseif($property -eq 'CoresLimit' -or $property -eq 'CoresCount' ) {
            $result.CoresLimit = $value
        } else {
            $result."$property" = $value
        }
    }

    return $result
}

