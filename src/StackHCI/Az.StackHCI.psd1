@{
  GUID = '18e6b2a3-7e2d-4f6e-a8d2-09edaf462fd8'
  RootModule = './Az.StackHCI.psm1'
  ModuleVersion = '1.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StackHci cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StackHCI.private.dll'
  FormatsToProcess = './Az.StackHCI.format.ps1xml'
  FunctionsToExport = 'Add-AzStackHCIVMAttestation', 'Disable-AzStackHCIAttestation', 'Disable-AzStackHCIRemoteSupport', 'Enable-AzStackHCIAttestation', 'Enable-AzStackHCIRemoteSupport', 'Get-AzStackHciArcSetting', 'Get-AzStackHciCluster', 'Get-AzStackHciExtension', 'Get-AzStackHCIRemoteSupportAccess', 'Get-AzStackHCIRemoteSupportSessionHistory', 'Get-AzStackHCIVMAttestation', 'Install-AzStackHCIRemoteSupport', 'New-AzStackHciArcSetting', 'New-AzStackHciCluster', 'New-AzStackHciExtension', 'Register-AzStackHCI', 'Remove-AzStackHciArcSetting', 'Remove-AzStackHciCluster', 'Remove-AzStackHciExtension', 'Remove-AzStackHCIRemoteSupport', 'Remove-AzStackHCIVMAttestation', 'Set-AzStackHCI', 'Unregister-AzStackHCI', 'Update-AzStackHciCluster', '*'
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
