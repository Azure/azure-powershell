<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.

Manually created custom quota object class
#>

class QuotaCustomObject {
        [int32]
        $AvailabilitySetCount

        [string]
        $Id

        [string]
        $Type

        [int32]
        $CoresCount

        [int32]
        $VmScaleSetCount

        [int32]
		$StandardManagedDiskAndSnapshotSize

        [int32]
		$PremiumManagedDiskAndSnapshotSize

        [string]
        $Name

        [int32]
        $VirtualMachineCount

        [string]
        $Location
}

function New-QuotaCustomObject
{    [OutputType([QuotaCustomObject])]
    param(
        [Parameter(Mandatory = $true)]
        [Microsoft.AzureStack.Management.Compute.Admin.Models.Quota]
        $Quota
    )

	[QuotaCustomObject] $result = @{}

    Get-Member -InputObject $Quota -MemberType Properties | ForEach-Object {
		$property = $_.Name
        $value = Select-Object -InputObject $Quota -ExpandProperty "$property"

		if($property -eq 'MaxAllocationStandardManagedDisksAndSnapshots') {
			$result.StandardManagedDiskAndSnapshotSize = $value
		} elseif($property -eq 'MaxAllocationPremiumManagedDisksAndSnapshots') {
			$result.PremiumManagedDiskAndSnapshotSize = $value
		} elseif($property -eq 'CoresLimit') {
			$result.CoresCount = $value
		} else {
			$result."$property" = $value
		}
    }

    return $result
}

function Convert-CustomQuotaToSDKObject
{    [OutputType([Microsoft.AzureStack.Management.Compute.Admin.Models.Quota])]
    param(
        [Parameter(Mandatory = $true)]
        [QuotaCustomObject]
        $CustomQuota
    )

	        # Create object
            $flattenedParameters = @('AvailabilitySetCount', 'CoresLimit', 'VmScaleSetCount', 'VirtualMachineCount', 'MaxAllocationStandardManagedDisksAndSnapshots', 'MaxAllocationPremiumManagedDisksAndSnapshots', 'Location' )
            $utilityCmdParams = @{}
            $flattenedParameters | ForEach-Object {

				if($_ -eq 'MaxAllocationStandardManagedDisksAndSnapshots') {
					$utilityCmdParams[$_] = $CustomQuota.StandardManagedDiskAndSnapshotSize
				} elseif($_ -eq 'MaxAllocationPremiumManagedDisksAndSnapshots') {
					$utilityCmdParams[$_] = $CustomQuota.PremiumManagedDiskAndSnapshotSize
				} elseif($_ -eq 'CoresLimit') {
					$utilityCmdParams[$_] = $CustomQuota.CoresCount
				} else {
					$property = $_
					$value = Select-Object -InputObject $CustomQuota -ExpandProperty "$property"
					$utilityCmdParams[$_] = $value
				}
				
            }
            $NewQuota = New-QuotaObject @utilityCmdParams
<#
    Get-Member -InputObject $CustomQuota -MemberType Properties | ForEach-Object {
		$property = $_.Name
        $value = Select-Object -InputObject $CustomQuota -ExpandProperty "$property"

		if($property -eq 'StandardManagedDiskAndSnapshotSize') {
			$result.MaxAllocationStandardManagedDisksAndSnapshots = $value
		} elseif($property -eq 'PremiumManagedDiskAndSnapshotSize') {
			$result.MaxAllocationPremiumManagedDisksAndSnapshots = $value
		} elseif($property -eq 'CoresCount') {
			$result.CoresLimit = $value
		} else {
			$result."$property" = $value
		}
    }
	$test = New-QuotaObject @result 
	#>
    return $NewQuota
}


