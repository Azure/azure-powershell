
<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

class ComputeQuotaObject {

    # Resource Properties
    [string]$Id
    [string]$Location
    [string]$Name
    [string]$Type

    #Compute Quota Properties
    [int32]$AvailabilitySetCount
    [int32]$CoresLimit
    [int32]$VmScaleSetCount
    [int32]$VirtualMachineCount
    [int32]$StandardManagedDiskAndSnapshotSize
    [int32]$PremiumManagedDiskAndSnapshotSize
}
