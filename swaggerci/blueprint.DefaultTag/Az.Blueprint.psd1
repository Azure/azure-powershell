@{
  GUID = 'a5dd1866-6b9e-4ab0-ae9c-235e85529ccf'
  RootModule = './Az.Blueprint.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Blueprint cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Blueprint.private.dll'
  FormatsToProcess = './Az.Blueprint.format.ps1xml'
  FunctionsToExport = 'Get-AzBlueprint', 'Get-AzBlueprintArtifact', 'Get-AzBlueprintAssignment', 'Get-AzBlueprintAssignmentOperation', 'Get-AzBlueprintPublishedArtifact', 'Get-AzBlueprintPublishedBlueprint', 'New-AzBlueprint', 'New-AzBlueprintArtifact', 'New-AzBlueprintAssignment', 'New-AzBlueprintPublishedBlueprint', 'Remove-AzBlueprint', 'Remove-AzBlueprintArtifact', 'Remove-AzBlueprintAssignment', 'Remove-AzBlueprintPublishedBlueprint', 'Test-AzBlueprintAssignment', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Blueprint'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
