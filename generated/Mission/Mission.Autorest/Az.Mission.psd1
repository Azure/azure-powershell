@{
  GUID = 'f88df206-0fab-467e-a98a-166766c96b7e'
  RootModule = './Az.Mission.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Mission cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Mission.private.dll'
  FormatsToProcess = './Az.Mission.format.ps1xml'
  FunctionsToExport = 'Get-AzMissionApproval', 'Get-AzMissionCommunity', 'Get-AzMissionCommunityEndpoint', 'Get-AzMissionDedicatedHub', 'Get-AzMissionEnclaveConnection', 'Get-AzMissionEnclaveEndpoint', 'Get-AzMissionTransitHub', 'Get-AzMissionVirtualEnclave', 'Get-AzMissionWorkload', 'Invoke-AzMissionHandleCommunityEndpointApprovalCreation', 'Invoke-AzMissionHandleCommunityEndpointApprovalDeletion', 'Invoke-AzMissionHandleEnclaveConnectionApprovalCreation', 'Invoke-AzMissionHandleEnclaveConnectionApprovalDeletion', 'Invoke-AzMissionHandleEnclaveEndpointApprovalCreation', 'Invoke-AzMissionHandleEnclaveEndpointApprovalDeletion', 'Invoke-AzMissionHandleVirtualEnclaveApprovalCreation', 'Invoke-AzMissionHandleVirtualEnclaveApprovalDeletion', 'New-AzMissionApproval', 'New-AzMissionCommunity', 'New-AzMissionCommunityEndpoint', 'New-AzMissionDedicatedHub', 'New-AzMissionEnclaveConnection', 'New-AzMissionEnclaveEndpoint', 'New-AzMissionTransitHub', 'New-AzMissionVirtualEnclave', 'New-AzMissionWorkload', 'Remove-AzMissionApproval', 'Remove-AzMissionCommunity', 'Remove-AzMissionCommunityEndpoint', 'Remove-AzMissionDedicatedHub', 'Remove-AzMissionEnclaveConnection', 'Remove-AzMissionEnclaveEndpoint', 'Remove-AzMissionTransitHub', 'Remove-AzMissionVirtualEnclave', 'Remove-AzMissionWorkload', 'Send-AzMissionApprovalInitiator', 'Set-AzMissionApproval', 'Set-AzMissionCommunity', 'Set-AzMissionCommunityEndpoint', 'Set-AzMissionDedicatedHub', 'Set-AzMissionEnclaveConnection', 'Set-AzMissionEnclaveEndpoint', 'Set-AzMissionTransitHub', 'Set-AzMissionVirtualEnclave', 'Set-AzMissionWorkload', 'Test-AzMissionCommunityAddressSpaceAvailability', 'Update-AzMissionApproval', 'Update-AzMissionCommunity', 'Update-AzMissionCommunityEndpoint', 'Update-AzMissionDedicatedHub', 'Update-AzMissionEnclaveConnection', 'Update-AzMissionEnclaveEndpoint', 'Update-AzMissionTransitHub', 'Update-AzMissionVirtualEnclave', 'Update-AzMissionWorkload'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Mission'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
