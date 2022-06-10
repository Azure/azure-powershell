@{
  GUID = 'bd222d2c-2fee-4894-a72a-fa83922c217c'
  RootModule = './Az.ManagedNetwork.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ManagedNetwork cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ManagedNetwork.private.dll'
  FormatsToProcess = './Az.ManagedNetwork.format.ps1xml'
  FunctionsToExport = 'Get-AzManagedNetwork', 'Get-AzManagedNetworkGroup', 'Get-AzManagedNetworkPeeringPolicy', 'Get-AzManagedNetworkScopeAssignment', 'New-AzManagedNetwork', 'New-AzManagedNetworkGroup', 'New-AzManagedNetworkPeeringPolicy', 'New-AzManagedNetworkScopeAssignment', 'Remove-AzManagedNetwork', 'Remove-AzManagedNetworkGroup', 'Remove-AzManagedNetworkPeeringPolicy', 'Remove-AzManagedNetworkScopeAssignment', 'Update-AzManagedNetwork', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ManagedNetwork'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
