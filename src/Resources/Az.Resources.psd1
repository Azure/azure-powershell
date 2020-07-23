@{
  GUID = '1bb10716-570a-45be-88c4-84927b145b93'
  RootModule = './Az.Resources.psm1'
  ModuleVersion = '4.0.2'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Resources cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Resources.private.dll'
  FormatsToProcess = './Az.Resources.format.ps1xml'
  CmdletsToExport = 'Add-AzADApplicationOwner', 'Add-AzADGroupMember', 'Add-AzADGroupOwner', 'Export-AzDeploymentTemplate', 'Export-AzResourceGroup', 'Get-AzADApplication', 'Get-AzADApplicationKeyCredential', 'Get-AzADApplicationOwner', 'Get-AzADApplicationPasswordCredential', 'Get-AzADDomain', 'Get-AzADGroup', 'Get-AzADGroupMember', 'Get-AzADGroupMemberGroup', 'Get-AzADServicePrincipal', 'Get-AzADServicePrincipalKeyCredential', 'Get-AzADServicePrincipalOwner', 'Get-AzADServicePrincipalPasswordCredential', 'Get-AzADUser', 'Get-AzADUserMemberGroup', 'Get-AzDenyAssignment', 'Get-AzDeployment', 'Get-AzDeploymentOperation', 'Get-AzLocation', 'Get-AzManagedApplication', 'Get-AzManagedApplicationDefinition', 'Get-AzManagementGroup', 'Get-AzManagementGroupDescendant', 'Get-AzPolicyAssignment', 'Get-AzPolicyDefinition', 'Get-AzPolicySetDefinition', 'Get-AzProviderFeature', 'Get-AzProviderOperationsMetadata', 'Get-AzResource', 'Get-AzResourceGroup', 'Get-AzResourceLock', 'Get-AzResourceProvider', 'Get-AzResourceProviderOperationDetail', 'Get-AzRoleAssignment', 'Get-AzRoleDefinition', 'Get-AzTag', 'Invoke-AzElevateGlobalAdministratorAccess', 'Move-AzResource', 'New-AzADApplication', 'New-AzADApplicationKeyCredential', 'New-AzADApplicationPasswordCredential', 'New-AzADGroup', 'New-AzADServicePrincipal', 'New-AzADServicePrincipalKeyCredential', 'New-AzADServicePrincipalPasswordCredential', 'New-AzADUser', 'New-AzDeployment', 'New-AzManagedApplication', 'New-AzManagedApplicationDefinition', 'New-AzManagementGroup', 'New-AzManagementGroupSubscription', 'New-AzPolicyAssignment', 'New-AzPolicyDefinition', 'New-AzPolicySetDefinition', 'New-AzResource', 'New-AzResourceGroup', 'New-AzResourceLock', 'New-AzRoleAssignment', 'New-AzRoleDefinition', 'New-AzTag', 'Register-AzProviderFeature', 'Register-AzResourceProvider', 'Remove-AzADApplication', 'Remove-AzADApplicationKeyCredential', 'Remove-AzADApplicationOwner', 'Remove-AzADApplicationPasswordCredential', 'Remove-AzADGroup', 'Remove-AzADGroupMember', 'Remove-AzADGroupOwner', 'Remove-AzADServicePrincipal', 'Remove-AzADServicePrincipalKeyCredential', 'Remove-AzADServicePrincipalPasswordCredential', 'Remove-AzADUser', 'Remove-AzDeployment', 'Remove-AzManagedApplication', 'Remove-AzManagedApplicationDefinition', 'Remove-AzManagementGroup', 'Remove-AzManagementGroupSubscription', 'Remove-AzPolicyAssignment', 'Remove-AzPolicyDefinition', 'Remove-AzPolicySetDefinition', 'Remove-AzResource', 'Remove-AzResourceGroup', 'Remove-AzResourceLock', 'Remove-AzRoleAssignment', 'Remove-AzRoleDefinition', 'Remove-AzTag', 'Restore-AzADDeletedApplication', 'Set-AzManagedApplication', 'Set-AzManagedApplicationDefinition', 'Set-AzManagementGroup', 'Set-AzPolicyDefinition', 'Set-AzPolicySetDefinition', 'Set-AzResource', 'Set-AzResourceGroup', 'Set-AzResourceLock', 'Set-AzRoleDefinition', 'Stop-AzDeployment', 'Test-AzADGroupMember', 'Test-AzDeployment', 'Test-AzNameAvailability', 'Test-AzResourceGroup', 'Test-AzResourceMove', 'Unregister-AzResourceProvider', 'Update-AzADApplication', 'Update-AzADServicePrincipal', 'Update-AzADUser', 'Update-AzManagedApplication', 'Update-AzManagementGroup', 'Update-AzResource', 'Update-AzResourceGroup', '*'
  AliasesToExport = 'Save-AzDeploymentTemplate', 'Save-AzResourceGroupDeploymentTemplate', 'Export-AzResourceGroupTemplate', 'Get-AzResourceGroupDeployment', 'Get-AzResourceGroupDeploymentOperation', 'Remove-AzResourceGroupDeployment', 'Stop-AzResourceGroupDeployment', 'Test-AzResourceGroupDeployment', 'Test-AzResourceGroupExistence', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Resources'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
}
