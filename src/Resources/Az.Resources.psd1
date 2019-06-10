@{
# region definition 
  RootModule = './Az.Resources.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Resources cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Resources.private.dll'
  FormatsToProcess = './Az.Resources.format.ps1xml'
# endregion 

# region persistent data 
  GUID = 'f9b08cca-d391-4dba-4015-0d621d522b93'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Resources'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
# endregion 

# region exports
  CmdletsToExport = 'Add-AzADApplicationOwner', 'Add-AzADGroupMember', 'Add-AzADGroupOwner', 'Export-AzDeploymentTemplate', 'Export-AzResourceGroup', 'Get-AzADApplication', 'Get-AzADApplicationOwner', 'Get-AzADDeletedApplication', 'Get-AzADGroup', 'Get-AzADGroupMember', 'Get-AzADGroupMemberGroup', 'Get-AzADGroupOwner', 'Get-AzADObject', 'Get-AzADServicePrincipal', 'Get-AzADServicePrincipalOwner', 'Get-AzADUser', 'Get-AzADUserMemberGroup', 'Get-AzApplicationKeyCredentials', 'Get-AzApplicationPasswordCredentials', 'Get-AzAuthorizationOperation', 'Get-AzClassicAdministrator', 'Get-AzDenyAssignment', 'Get-AzDeployment', 'Get-AzDeploymentOperation', 'Get-AzDomain', 'Get-AzEntity', 'Get-AzManagedApplication', 'Get-AzManagedApplicationDefinition', 'Get-AzManagementGroup', 'Get-AzManagementLock', 'Get-AzOAuth2PermissionGrant', 'Get-AzPermission', 'Get-AzPolicyAssignment', 'Get-AzPolicyDefinition', 'Get-AzPolicySetDefinition', 'Get-AzProviderFeature', 'Get-AzProviderOperationsMetadata', 'Get-AzResource', 'Get-AzResourceGroup', 'Get-AzResourceLink', 'Get-AzResourceProvider', 'Get-AzResourceProviderOperationDetail', 'Get-AzRoleAssignment', 'Get-AzRoleDefinition', 'Get-AzSubscriptionLocation', 'Get-AzTag', 'Invoke-AzElevateAccess', 'Invoke-AzTenantBackfillStatus', 'Move-AzResource', 'New-AzADApplication', 'New-AzADGroup', 'New-AzADServicePrincipal', 'New-AzADUser', 'New-AzDeployment', 'New-AzManagedApplication', 'New-AzManagedApplicationDefinition', 'New-AzManagementGroup', 'New-AzManagementGroupSubscription', 'New-AzManagementLock', 'New-AzOAuth2PermissionGrant', 'New-AzPolicyAssignment', 'New-AzPolicyDefinition', 'New-AzPolicySetDefinition', 'New-AzResource', 'New-AzResourceGroup', 'New-AzResourceLink', 'New-AzRoleAssignment', 'New-AzRoleDefinition', 'New-AzTag', 'Register-AzProviderFeature', 'Register-AzResourceProvider', 'Remove-AzADApplication', 'Remove-AzADApplicationOwner', 'Remove-AzADDeletedApplicationHard', 'Remove-AzADGroup', 'Remove-AzADGroupMember', 'Remove-AzADGroupOwner', 'Remove-AzADServicePrincipal', 'Remove-AzADUser', 'Remove-AzDeployment', 'Remove-AzManagedApplication', 'Remove-AzManagedApplicationDefinition', 'Remove-AzManagementGroup', 'Remove-AzManagementGroupSubscription', 'Remove-AzManagementLock', 'Remove-AzOAuth2PermissionGrant', 'Remove-AzPolicyAssignment', 'Remove-AzPolicyDefinition', 'Remove-AzPolicySetDefinition', 'Remove-AzResource', 'Remove-AzResourceGroup', 'Remove-AzResourceLink', 'Remove-AzRoleAssignment', 'Remove-AzRoleDefinition', 'Remove-AzTag', 'Restore-AzADDeletedApplication', 'Set-AzDeployment', 'Set-AzManagedApplication', 'Set-AzManagedApplicationDefinition', 'Set-AzManagementGroup', 'Set-AzManagementLock', 'Set-AzPolicyDefinition', 'Set-AzPolicySetDefinition', 'Set-AzResource', 'Set-AzResourceGroup', 'Set-AzResourceLink', 'Set-AzRoleDefinition', 'Start-AzTenantBackfill', 'Stop-AzDeployment', 'Test-AzADGroupMember', 'Test-AzDeployment', 'Test-AzDeploymentExistence', 'Test-AzNameAvailability', 'Test-AzResource', 'Test-AzResourceGroup', 'Test-AzResourceMove', 'Unregister-AzResourceProvider', 'Update-AzADApplication', 'Update-AzADServicePrincipal', 'Update-AzADUser', 'Update-AzApplicationKeyCredentials', 'Update-AzApplicationPasswordCredentials', 'Update-AzManagedApplication', 'Update-AzManagementGroup', 'Update-AzResource', 'Update-AzResourceGroup', '*'
  AliasesToExport = 'Save-AzDeploymentTemplate', 'Save-AzResourceGroupDeploymentTemplate', 'Export-AzResourceGroupTemplate', 'Get-AzResourceGroupDeployment', 'Get-AzResourceGroupDeploymentOperation', 'New-AzResourceGroupDeployment', 'Remove-AzResourceGroupDeployment', 'Set-AzResourceGroupDeployment', 'Stop-AzResourceGroupDeployment', 'Test-AzResourceGroupDeployment', 'Test-AzResourceGroupDeploymentExistence', 'Test-AzResourceExistence', 'Test-AzResourceGroupExistence', '*'
# endregion

}