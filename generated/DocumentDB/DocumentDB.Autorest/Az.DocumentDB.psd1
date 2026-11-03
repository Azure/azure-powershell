@{
  GUID = 'f798be56-e963-4fc2-8ebe-5f5b53cb3fbb'
  RootModule = './Az.DocumentDB.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DocumentDB cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DocumentDB.private.dll'
  FormatsToProcess = './Az.DocumentDB.format.ps1xml'
  FunctionsToExport = 'Get-AzDocumentDBFirewallRule', 'Get-AzDocumentDBMongoCluster', 'Get-AzDocumentDBMongoClusterConnectionString', 'Get-AzDocumentDBReplica', 'Get-AzDocumentDBUser', 'New-AzDocumentDBFirewallRule', 'New-AzDocumentDBMongoCluster', 'New-AzDocumentDBReplica', 'New-AzDocumentDBUser', 'Remove-AzDocumentDBFirewallRule', 'Remove-AzDocumentDBMongoCluster', 'Remove-AzDocumentDBUser', 'Reset-AzDocumentDBMongoClusterPassword', 'Restore-AzDocumentDBMongoCluster', 'Switch-AzDocumentDBMongoCluster', 'Test-AzDocumentDBMongoClusterNameAvailability', 'Update-AzDocumentDBFirewallRule', 'Update-AzDocumentDBMongoCluster'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DocumentDB'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
