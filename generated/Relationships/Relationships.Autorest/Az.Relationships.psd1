@{
  GUID = '00c583a5-5d9a-479b-aec9-196f4ce3bd0e'
  RootModule = './Az.Relationships.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Relationships cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Relationships.private.dll'
  FormatsToProcess = './Az.Relationships.format.ps1xml'
  FunctionsToExport = 'Get-AzRelationshipsDependencyOfRelationship', 'Get-AzRelationshipsServiceGroupMemberRelationship', 'New-AzRelationshipsDependencyOfRelationship', 'New-AzRelationshipsServiceGroupMemberRelationship', 'Remove-AzRelationshipsDependencyOfRelationship', 'Remove-AzRelationshipsServiceGroupMemberRelationship', 'Update-AzRelationshipsDependencyOfRelationship', 'Update-AzRelationshipsServiceGroupMemberRelationship'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Relationships'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
