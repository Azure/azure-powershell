@{
  GUID = '7417c0b6-55f6-4ee9-a3de-831752536106'
  RootModule = './Az.Dns.psm1'
  ModuleVersion = '4.0.2'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Dns cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Dns.private.dll'
  FormatsToProcess = './Az.Dns.format.ps1xml'
  CmdletsToExport = 'Get-AzDnsRecordSet', 'Get-AzDnsResourceReference', 'Get-AzDnsZone', 'New-AzDnsRecordSet', 'New-AzDnsZone', 'Remove-AzDnsRecordSet', 'Remove-AzDnsZone', 'Set-AzDnsRecordSet', 'Set-AzDnsZone', 'Update-AzDnsRecordSet', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Dns'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
}
