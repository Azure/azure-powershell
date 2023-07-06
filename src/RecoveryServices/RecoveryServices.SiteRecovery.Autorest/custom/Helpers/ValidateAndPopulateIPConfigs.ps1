function ValidateAndPopulateIPConfigs {
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IVMNicDetails]
        # Vm Nic Details
        ${VmNic},

        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IIPConfigInputDetails]
        # The IP configurations to be used by NIC during test failover and failover.
        ${IPConfig},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The ID of the recovery virtual network.
        ${RecoveryVMNetworkId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [System.String]
        [ValidateNotNullOrEmpty()]
        # The ID of the test failover virtual network.
        ${TfoVMNetworkId}
    ) 

	process {
        $isTfoNetworkRequired = $false
        $isRecoveryNetworkRequired = $false

        foreach($ipConfig in $IPConfig) {
            if($ipConfig.TfoSubnetName -ne $null) {
                $isTfoNetworkRequired = $true
            }

            if($ipConfig.RecoverySubnetName -ne $null) {
                $isRecoveryNetworkRequired = $true
            }

            $vmNicIPConfig = $VmNic.IPConfig | ForEach-Object {
                if($_.Name -eq $ipConfig.IPConfigName){
                    return $_
                }
            }

            if($vmNicIPConfig -eq $null) {
                throw "IPConfig not found in VmNic"
            }

            $ipConfig.IsPrimary = $vmNicIPConfig.IsPrimary
            if($ipConfig.TfoSubnetName -eq $null) {
                $ipConfig.RecoverySubnetName = $vmNicIPConfig.RecoverySubnetName
            }

            if($ipConfig.RecoveryStaticIPAddress -eq $null) {
                $ipConfig.RecoveryStaticIPAddress = $vmNicIPConfig.RecoveryStaticIPAddress
            }

            if($ipConfig.RecoveryPublicIPAddressId -eq $null) {
                $ipConfig.RecoveryPublicIPAddressId = $vmNicIPConfig.RecoveryPublicIPAddressId
            }

            if($ipConfig.RecoveryLBBackendAddressPoolId -eq $null) {
                $ipConfig.RecoveryLBBackendAddressPoolId = $vmNicIPConfig.RecoveryLbBackendAddressPoolId
            }

            if($ipConfig.TfoSubnetName -eq $null) {
                $ipConfig.TfoSubnetName = $vmNicIPConfig.TfoSubnetName
            }

            if($ipConfig.TfoStaticIPAddress -eq $null) {
                $ipConfig.TfoStaticIPAddress = $vmNicIPConfig.TfoStaticIPAddress
            }

            if($ipConfig.TfoPublicIPAddressId -eq $null) {
                $ipConfig.TfoPublicIPAddressId = $vmNicIPConfig.TfoPublicIPAddressId
            }

            if($ipConfig.TfoLBBackendAddressPoolId -eq $null) {
                $ipConfig.TfoLBBackendAddressPoolId = $vmNicIPConfig.TfoLbBackendAddressPoolId
            }
        }

        if($isTfoNetworkRequired -and $TfoVMNetworkId -eq $null) {
            throw "Tfo Network information missing"
        }
        
        if($isRecoveryNetworkRequired -and $RecoveryVMNetworkId -eq $null) {
            throw "Tfo Network information missing"
        }

        return $ipConfig
    }
}