@{
  GUID = '97d87543-8eef-4574-a70d-7317ec4abe54'
  RootModule = './Az.ResourceMover.psm1'
  ModuleVersion = '1.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ResourceMover cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ResourceMover.private.dll'
  FormatsToProcess = './Az.ResourceMover.format.ps1xml'
  FunctionsToExport = 'Add-AzResourceMoverMoveResource', 'Get-AzResourceMoverMoveCollection', 'Get-AzResourceMoverMoveResource', 'Get-AzResourceMoverRequiredForResources', 'Get-AzResourceMoverUnresolvedDependency', 'Invoke-AzResourceMoverBulkRemove', 'Invoke-AzResourceMoverCommit', 'Invoke-AzResourceMoverDiscard', 'Invoke-AzResourceMoverInitiateMove', 'Invoke-AzResourceMoverPrepare', 'New-AzResourceMoverMoveCollection', 'Remove-AzResourceMoverMoveCollection', 'Remove-AzResourceMoverMoveResource', 'Resolve-AzResourceMoverMoveCollectionDependency', '*'
  AliasesToExport = 'Update-AzResourceMoverMoveResource', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ResourceMover'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
