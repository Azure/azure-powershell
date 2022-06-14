@{
  GUID = '6d4d51c3-c57d-4cee-adfa-d95ae09c02db'
  RootModule = './Az.ResourceMoverServiceApi.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ResourceMoverServiceApi cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ResourceMoverServiceApi.private.dll'
  FormatsToProcess = './Az.ResourceMoverServiceApi.format.ps1xml'
  FunctionsToExport = 'Get-AzResourceMoverServiceApiMoveCollection', 'Get-AzResourceMoverServiceApiMoveCollectionRequired', 'Get-AzResourceMoverServiceApiMoveResource', 'Get-AzResourceMoverServiceApiOperationsDiscovery', 'Get-AzResourceMoverServiceApiUnresolvedDependency', 'Invoke-AzResourceMoverServiceApiBulkMoveCollectionRemove', 'Invoke-AzResourceMoverServiceApiCommitMoveCollection', 'Invoke-AzResourceMoverServiceApiInitiateMoveCollectionMove', 'Invoke-AzResourceMoverServiceApiPrepareMoveCollection', 'New-AzResourceMoverServiceApiMoveCollection', 'New-AzResourceMoverServiceApiMoveResource', 'Remove-AzResourceMoverServiceApiMoveCollection', 'Remove-AzResourceMoverServiceApiMoveResource', 'Resolve-AzResourceMoverServiceApiMoveCollectionDependency', 'Update-AzResourceMoverServiceApiMoveCollection', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ResourceMoverServiceApi'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
