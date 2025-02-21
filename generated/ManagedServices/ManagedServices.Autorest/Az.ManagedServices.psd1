@{
  GUID = 'f3c1cabd-ba4d-4158-b4f3-9e037b7a2d62'
  RootModule = './Az.ManagedServices.psm1'
  ModuleVersion = '2.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ManagedServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ManagedServices.private.dll'
  FormatsToProcess = './Az.ManagedServices.format.ps1xml'
  FunctionsToExport = 'Get-AzManagedServicesAssignment', 'Get-AzManagedServicesDefinition', 'Get-AzManagedServicesMarketplaceDefinition', 'New-AzManagedServicesAssignment', 'New-AzManagedServicesAuthorizationObject', 'New-AzManagedServicesDefinition', 'New-AzManagedServicesEligibleApproverObject', 'New-AzManagedServicesEligibleAuthorizationObject', 'Remove-AzManagedServicesAssignment', 'Remove-AzManagedServicesDefinition', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ManagedServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
