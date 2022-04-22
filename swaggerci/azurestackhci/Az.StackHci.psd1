@{
  GUID = 'c0b212e4-5bec-4478-a859-7caa860bdade'
  RootModule = './Az.StackHci.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StackHci cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StackHci.private.dll'
  FormatsToProcess = './Az.StackHci.format.ps1xml'
  FunctionsToExport = 'Get-AzStackHciArcSetting', 'Get-AzStackHciCluster', 'Get-AzStackHciExtension', 'Invoke-AzStackHciUploadClusterCertificate', 'New-AzStackHciArcSetting', 'New-AzStackHciArcSettingPassword', 'New-AzStackHciCluster', 'New-AzStackHciExtension', 'Remove-AzStackHciArcSetting', 'Remove-AzStackHciCluster', 'Remove-AzStackHciExtension', 'Update-AzStackHciCluster', 'Update-AzStackHciExtension', '*'
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
