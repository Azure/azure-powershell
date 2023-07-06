function ConvertToPSIPConfig {
	[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IIPConfigInputDetails]
        # The IP configurations to be used by NIC during test failover and failover.
        ${ipConfig}
    ) 

	process {
        $ipConfigObj = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPConfigInputDetails]::new()
        $ipConfigObj.IPConfigName = $ipConfig.IPConfigName
        $ipConfigObj.IsPrimary = $ipConfig.IsPrimary
        $ipConfigObj.IsSeletedForFailover = $ipConfig.IsSelectedForFailover
        $ipConfigObj.RecoverySubnetName = $ipConfig.RecoverySubnetName
        $ipConfigObj.RecoveryStaticIPAddress = $ipConfig.RecoveryStaticIPAddress
        $ipConfigObj.RecoveryPublicIPAddressId = $ipConfig.RecoveryPublicIPAddressId
        $ipConfigObj.RecoveryLbBackendAddressPoolId = $ipConfig.RecoveryLBBackendAddressPoolId
        $ipConfigObj.TfoSubnetName = $ipConfig.TfoSubnetName
        $ipConfigObj.TfoStaticIPAddress = $ipConfig.TfoStaticIPAddress
        $ipConfigObj.TfoPublicIPAddressId = $ipConfig.TfoPublicIPAddressId
        $ipConfigObj.TfoLbBackendAddressPoolId = $ipConfig.TfoLBBackendAddressPoolId

        return $ipConfigObj
    }
}