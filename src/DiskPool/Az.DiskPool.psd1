@{
  GUID = '6ee0ccda-b0ba-4017-92fe-6eb1cfacfc66'
  RootModule = './Az.DiskPool.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DiskPool cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DiskPool.private.dll'
  FormatsToProcess = './Az.DiskPool.format.ps1xml'
  FunctionsToExport = 'Get-AzDiskPool', 'Get-AzDiskPoolIscsiTarget', 'Get-AzDiskPoolOutboundNetworkDependencyEndpoint', 'Get-AzDiskPoolResourceSku', 'Get-AzDiskPoolZone', 'Invoke-AzDiskPoolRedeployment', 'New-AzDiskPool', 'New-AzDiskPoolAclObject', 'New-AzDiskPoolIscsiLunObject', 'New-AzDiskPoolIscsiTarget', 'Remove-AzDiskPool', 'Remove-AzDiskPoolIscsiTarget', 'Start-AzDiskPool', 'Stop-AzDiskPool', 'Update-AzDiskPool', 'Update-AzDiskPoolIscsiTarget', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DiskPool'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
