@{
  GUID = '6bb9f5b6-6948-424c-b7b3-faba33be0aef'
  RootModule = './Az.Dns.psm1'
  ModuleVersion = '2.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Dns cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Dns.private.dll'
  FormatsToProcess = './Az.Dns.format.ps1xml'
  FunctionsToExport = 'Get-AzDnsDnssecConfig', 'Get-AzDnsRecordSet', 'Get-AzDnsResourceReference', 'Get-AzDnsZone', 'New-AzDnsDnssecConfig', 'New-AzDnsRecordSet', 'New-AzDnsZone', 'Remove-AzDnsDnssecConfig', 'Remove-AzDnsRecordSet', 'Remove-AzDnsZone', 'Update-AzDnsRecordSet', 'Update-AzDnsZone', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Dns'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
