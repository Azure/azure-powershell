## 11.3.0 - February 2024
#### Az.KeyVault 5.2.0 
* Modified cmdlet `Backup-AzKeyVault`
   - Added parameter `-UseUserManagedIdentity`
* Modified cmdlet `Restore-AzKeyVault`
   - Added parameter `-UseUserManagedIdentity`
#### Az.Migrate 2.3.0 
* Modified cmdlet `Get-AzMigrateDiscoveredServer`
   - Added parameter `-SourceMachineType`
* Added cmdlet `Get-AzMigrateHCIJob`, `Get-AzMigrateHCIReplicationFabric`, `Get-AzMigrateHCIServerReplication`, `Initialize-AzMigrateHCIReplicationInfrastructure`, `New-AzMigrateHCIDiskMappingObject`, `New-AzMigrateHCINicMappingObject`, `New-AzMigrateHCIServerReplication`, `Remove-AzMigrateHCIServerReplication`, `Set-AzMigrateHCIServerReplication`, `Start-AzMigrateHCIServerMigration`
#### Az.Network 7.4.0 
* Modified cmdlet `New-AzApplicationGateway`
   - Added parameters `-EnableRequestBuffering`, `-EnableResponseBuffering`
* Modified cmdlet `New-AzFirewallPolicyIntrusionDetection`
   - Added parameter `-Profile`
* Modified cmdlet `New-AzNetworkVirtualAppliance`
   - Added parameter `-InternetIngressIp`
* Added cmdlet `Invoke-AzFirewallPacketCapture`, `New-AzFirewallPacketCaptureParameter`, `New-AzFirewallPacketCaptureRule`, `New-AzVirtualApplianceInternetIngressIpsProperty`, `Update-AzNetworkVirtualApplianceConnection`
#### Az.Resources 6.15.0 
* Modified cmdlet `Get-AzRoleAssignment`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Get-AzRoleDefinition`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `New-AzRoleAssignment`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `New-AzRoleDefinition`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Remove-AzRoleAssignment`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Remove-AzRoleDefinition`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Set-AzRoleAssignment`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Set-AzRoleDefinition`
   - Added parameter `-SkipClientSideScopeValidation`
#### Az.Sql 4.14.0 
* Modified cmdlet `New-AzSqlInstance`
   - Added parameters `-DatabaseFormat`, `-PricingModel`
* Modified cmdlet `Set-AzSqlInstance`
   - Added parameters `-DatabaseFormat`, `-PricingModel`
* Added cmdlet `Invoke-AzSqlInstanceExternalGovernanceStatusRefresh`
#### Az.SqlVirtualMachine 2.2.0 
* Modified cmdlet `New-AzSqlVM`
   - Removed parameter `-VirtualMachineResourceId`
#### Az.StackHCI 2.3.0 
* Modified cmdlet `Unregister-AzStackHCI`
   - Added parameter `-IsWAC`


