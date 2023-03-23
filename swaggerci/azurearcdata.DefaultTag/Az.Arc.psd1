@{
  GUID = '2f093b24-4ebc-4a60-b8f1-bef3aa1f4d7f'
  RootModule = './Az.Arc.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Arc cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Arc.private.dll'
  FormatsToProcess = './Az.Arc.format.ps1xml'
  FunctionsToExport = 'Get-AzArcActiveDirectoryConnector', 'Get-AzArcDataController', 'Get-AzArcFailoverGroup', 'Get-AzArcPostgreInstance', 'Get-AzArcPostgresInstance', 'Get-AzArcSqlAvailabilityGroup', 'Get-AzArcSqlAvailabilityGroupDatabase', 'Get-AzArcSqlAvailabilityGroupReplica', 'Get-AzArcSqlManagedInstance', 'Get-AzArcSqlServerAvailabilityGroup', 'Get-AzArcSqlServerDatabase', 'Get-AzArcSqlServerInstance', 'New-AzArcActiveDirectoryConnector', 'New-AzArcFailoverGroup', 'New-AzArcPostgresInstance', 'New-AzArcSqlAvailabilityGroup', 'New-AzArcSqlAvailabilityGroupDatabase', 'New-AzArcSqlAvailabilityGroupReplica', 'New-AzArcSqlManagedInstance', 'New-AzArcSqlServerAvailabilityGroup', 'New-AzArcSqlServerDatabase', 'New-AzArcSqlServerInstance', 'Remove-AzArcActiveDirectoryConnector', 'Remove-AzArcDataController', 'Remove-AzArcFailoverGroup', 'Remove-AzArcPostgresInstance', 'Remove-AzArcSqlAvailabilityGroup', 'Remove-AzArcSqlAvailabilityGroupDatabase', 'Remove-AzArcSqlAvailabilityGroupReplica', 'Remove-AzArcSqlManagedInstance', 'Remove-AzArcSqlServerAvailabilityGroup', 'Remove-AzArcSqlServerDatabase', 'Remove-AzArcSqlServerInstance', 'Update-AzArcDataController', 'Update-AzArcPostgresInstance', 'Update-AzArcSqlAvailabilityGroup', 'Update-AzArcSqlAvailabilityGroupDatabase', 'Update-AzArcSqlAvailabilityGroupReplica', 'Update-AzArcSqlManagedInstance', 'Update-AzArcSqlServerAvailabilityGroup', 'Update-AzArcSqlServerDatabase', 'Update-AzArcSqlServerInstance', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Arc'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
