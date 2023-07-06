
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------


function New-AzRecoveryServicesReplicationVmNicIPConfig {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPConfigInputDetails])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # IP config name
        ${IPConfigName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${IsPrimary},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Whether an existing IP config is selected for test failover/failover.
        ${IsSelectedForFailover},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The name of the recovery subnet.
        ${RecoverySubnetName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNull()]
        # The IP address of the recovery IP config.
        ${RecoveryStaticIPAddress},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNull()]
        # The ID of the public IP address associated with the recovery IP config.
        ${RecoveryPublicIPAddressId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String[]]
        [ValidateNotNull()]
        # The IDs of backend address pools for the recovery IP config.
        ${RecoveryLBBackendAddressPoolId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The name of the test failover subnet.
        ${TfoSubnetName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNull()]
        # The IP address of the test failover IP config.
        ${TfoStaticIPAddress},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNull()]
        # The ID of the public IP address associated with the test failover IP config.
        ${TfoPublicIPAddressId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String[]]
        [ValidateNotNull()]
        # The IDs of backend address pools for the test failover IP config.
        ${TfoLBBackendAddressPoolId}
    )

    process {
        try {
            $ipConfig = $null

            if($RecoverySubnetName -eq $null -and $RecoveryStaticIPAddress -ne $null) {
                throw "Recovery Subnet Information is missing"
            }

            if($TfoSubnetName -eq $null -and $TfoStaticIPAddress -ne $null) {
                throw "TFO Subnet Information is missing"
            }

            $ipConfig = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPConfigInputDetails]::new()
            $ipConfig.IPConfigName = $IPConfigName
            $ipConfig.IsPrimary = $IsPrimary
            $ipConfig.IsSeletedForFailover = $IsSelectedForFailover
            $ipConfig.RecoverySubnetName = $RecoverySubnetName
            $ipConfig.RecoveryStaticIPAddress = $RecoveryStaticIPAddress
            $ipConfig.RecoveryPublicIPAddressId = $RecoveryPublicIPAddressId
            $ipConfig.RecoveryLbBackendAddressPoolId = @($RecoveryLBBackendAddressPoolId)
            $ipConfig.TfoSubnetName = $TfoSubnetName
            $ipConfig.TfoStaticIPAddress = $TfoStaticIPAddress
            $ipConfig.TfoPublicIPAddressId = $TfoPublicIPAddressId
            $ipConfig.TfoLbBackendAddressPoolId = @($TfoLBBackendAddressPoolId)

            return $ipConfig
        } catch {
            throw
        }
    }
}
