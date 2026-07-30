@{
  GUID = '87464890-8f5f-414e-8c7b-124988f140dd'
  RootModule = './Az.Napster.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Napster cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Napster.private.dll'
  FormatsToProcess = './Az.Napster.format.ps1xml'
  FunctionsToExport = 'Get-AzNapsterOrganization', 'Initialize-AzNapsterSaaSOperationGroupResource', 'Invoke-AzNapsterLatestOrganizationLinkedSaaS', 'Invoke-AzNapsterLinkOrganizationSaaS', 'New-AzNapsterOrganization', 'Remove-AzNapsterOrganization', 'Update-AzNapsterOrganization'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Napster'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
