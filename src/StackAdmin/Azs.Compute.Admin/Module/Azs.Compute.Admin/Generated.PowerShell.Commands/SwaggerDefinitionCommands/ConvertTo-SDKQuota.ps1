<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.

Manually created custom quota object class
#>

function ConvertTo-SdkQuota
{   [OutputType([Microsoft.AzureStack.Management.Compute.Admin.Models.Quota])]
    param(
        [Parameter(Mandatory = $true)]
        [ComputeQuotaObject]
        $CustomQuota
    )

    # Create object
    # This object should not set "Name" as its a read only property
    $flattenedParameters = @('AvailabilitySetCount', 'CoresLimit', 'VmScaleSetCount', 'VirtualMachineCount', 'MaxAllocationStandardManagedDisksAndSnapshots', 'MaxAllocationPremiumManagedDisksAndSnapshots', 'Location')
    $utilityCmdParams = @{}
    $flattenedParameters | ForEach-Object {

        if($_ -eq 'MaxAllocationStandardManagedDisksAndSnapshots') {
            $utilityCmdParams[$_] = $CustomQuota.StandardManagedDiskAndSnapshotSize
        } elseif($_ -eq 'MaxAllocationPremiumManagedDisksAndSnapshots') {
            $utilityCmdParams[$_] = $CustomQuota.PremiumManagedDiskAndSnapshotSize
        } elseif($_ -eq 'CoresLimit' ) {
            $utilityCmdParams['CoresLimit'] = $CustomQuota.CoresLimit
        } elseif($_ -eq 'CoresCount' ) {
            $utilityCmdParams['CoresLimit'] = $CustomQuota.CoresCount

        } else {
            $property = $_
            $value = Select-Object -InputObject $CustomQuota -ExpandProperty "$property"
            $utilityCmdParams[$_] = $value
        }
    }

    New-QuotaObject @utilityCmdParams
}
