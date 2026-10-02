@{
  GUID = '68730c39-64d4-48ba-9f80-c2df17008592'
  RootModule = './Az.Relationships.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Relationships cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Relationships.private.dll'
  FormatsToProcess = './Az.Relationships.format.ps1xml'
  FunctionsToExport = 'Get-AzRelationshipsContainsRelationship', 'Get-AzRelationshipsDependencyOfRelationship', 'Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup', 'Get-AzRelationshipsServiceGroupMemberRelationship', 'New-AzRelationshipsDependencyOfRelationship', 'New-AzRelationshipsDependencyOfRelationshipsByServiceGroup', 'New-AzRelationshipsServiceGroupMemberRelationship', 'Remove-AzRelationshipsDependencyOfRelationship', 'Remove-AzRelationshipsDependencyOfRelationshipsByServiceGroup', 'Remove-AzRelationshipsServiceGroupMemberRelationship', 'Update-AzRelationshipsDependencyOfRelationship', 'Update-AzRelationshipsDependencyOfRelationshipsByServiceGroup', 'Update-AzRelationshipsServiceGroupMemberRelationship'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Relationships'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
