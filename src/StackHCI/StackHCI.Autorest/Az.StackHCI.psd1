@{
  GUID = '18e6b2a3-7e2d-4f6e-a8d2-09edaf462fd8'
  RootModule = './Az.StackHCI.psm1'
  ModuleVersion = '1.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StackHci cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StackHCI.private.dll'
  FormatsToProcess = './Az.StackHCI.format.ps1xml'
  FunctionsToExport = 'Add-AzStackHCIVMAttestation', 'Disable-AzStackHCIAttestation', 'Disable-AzStackHCIRemoteSupport', 'Enable-AzStackHCIAttestation', 'Enable-AzStackHCIRemoteSupport', 'Get-AzStackHciArcSetting', 'Get-AzStackHciCluster', 'Get-AzStackHciDeploymentSetting', 'Get-AzStackHciEdgeDevice', 'Get-AzStackHciExtension', 'Get-AzStackHCILogsDirectory', 'Get-AzStackHCIRemoteSupportAccess', 'Get-AzStackHCIRemoteSupportSessionHistory', 'Get-AzStackHciSecuritySetting', 'Get-AzStackHciUpdate', 'Get-AzStackHciUpdateRun', 'Get-AzStackHciUpdateSummary', 'Get-AzStackHCIVMAttestation', 'Install-AzStackHCIRemoteSupport', 'Invoke-AzStackHciConsentAndInstallDefaultExtension', 'Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit', 'Invoke-AzStackHciUpdate', 'New-AzStackHciArcSetting', 'New-AzStackHciCluster', 'New-AzStackHciDeploymentSetting', 'New-AzStackHciEdgeDevice', 'New-AzStackHciExtension', 'New-AzStackHciSecuritySetting', 'Register-AzStackHCI', 'Remove-AzStackHciArcSetting', 'Remove-AzStackHciCluster', 'Remove-AzStackHciDeploymentSetting', 'Remove-AzStackHciEdgeDevice', 'Remove-AzStackHciExtension', 'Remove-AzStackHCIRemoteSupport', 'Remove-AzStackHciSecuritySetting', 'Remove-AzStackHciUpdate', 'Remove-AzStackHciUpdateRun', 'Remove-AzStackHciUpdateSummary', 'Remove-AzStackHCIVMAttestation', 'Set-AzStackHCI', 'Set-AzStackHciDeploymentSetting', 'Set-AzStackHciEdgeDevice', 'Set-AzStackHciSecuritySetting', 'Set-AzStackHciUpdate', 'Set-AzStackHciUpdateRun', 'Set-AzStackHciUpdateSummary', 'Test-AzStackHciEdgeDevice', 'Unregister-AzStackHCI', 'Update-AzStackHciCluster', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StackHci'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
