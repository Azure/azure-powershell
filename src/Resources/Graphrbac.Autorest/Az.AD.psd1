@{
  GUID = 'ecee7ffa-8cb2-4a3f-ae68-22e87f3f29fd'
  RootModule = './Az.AD.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Ad cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AD.private.dll'
  FormatsToProcess = './Az.AD.format.ps1xml'
  FunctionsToExport = 'Add-AzADApplicationOwner', 'Add-AzADGroupMember', 'Add-AzADGroupOwner', 'Add-AzADServicePrincipalOwner', 'Get-AzADApplication', 'Get-AzADApplicationKeyCredentials', 'Get-AzADApplicationNext', 'Get-AzADApplicationOwner', 'Get-AzADApplicationPasswordCredentials', 'Get-AzADApplicationServicePrincipalId', 'Get-AzADDeletedApplication', 'Get-AzADDeletedApplicationNext', 'Get-AzADDomain', 'Get-AzADGroup', 'Get-AzADGroupMember', 'Get-AzADGroupMemberGroup', 'Get-AzADGroupMemberNext', 'Get-AzADGroupNext', 'Get-AzADGroupOwner', 'Get-AzADOAuth2PermissionGrant', 'Get-AzADOAuth2PermissionGrantNext', 'Get-AzADObject', 'Get-AzADServicePrincipal', 'Get-AzADServicePrincipalAppRoleAssignedTo', 'Get-AzADServicePrincipalAppRoleAssignment', 'Get-AzADServicePrincipalKeyCredentials', 'Get-AzADServicePrincipalNext', 'Get-AzADServicePrincipalOwner', 'Get-AzADServicePrincipalPasswordCredentials', 'Get-AzADSignedInUser', 'Get-AzADSignedInUserOwnedObject', 'Get-AzADSignedInUserOwnedObjectNext', 'Get-AzADUser', 'Get-AzADUserMemberGroup', 'Get-AzADUserNext', 'New-AzADApplication', 'New-AzADGroup', 'New-AzADOAuth2PermissionGrant', 'New-AzADServicePrincipal', 'New-AzADUser', 'Remove-AzADApplication', 'Remove-AzADApplicationOwner', 'Remove-AzADDeletedApplicationHard', 'Remove-AzADGroup', 'Remove-AzADGroupMember', 'Remove-AzADGroupOwner', 'Remove-AzADOAuth2PermissionGrant', 'Remove-AzADServicePrincipal', 'Remove-AzADServicePrincipalOwner', 'Remove-AzADUser', 'Restore-AzADDeletedApplication', 'Test-AzADGroupMember', 'Update-AzADApplication', 'Update-AzADApplicationKeyCredentials', 'Update-AzADApplicationPasswordCredentials', 'Update-AzADServicePrincipal', 'Update-AzADServicePrincipalKeyCredentials', 'Update-AzADServicePrincipalPasswordCredentials', 'Update-AzADUser', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Ad'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
