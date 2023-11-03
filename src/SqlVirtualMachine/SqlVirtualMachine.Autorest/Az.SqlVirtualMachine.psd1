@{
  GUID = 'b0fb9454-c75f-4eb7-ab6a-aaae12f8bde3'
  RootModule = './Az.SqlVirtualMachine.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SqlVirtualMachine cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SqlVirtualMachine.private.dll'
  FormatsToProcess = './Az.SqlVirtualMachine.format.ps1xml'
  FunctionsToExport = 'Get-AzAvailabilityGroupListener', 'Get-AzSqlVM', 'Get-AzSqlVMGroup', 'Invoke-AzRedeploySqlVM', 'Invoke-AzSqlVMTroubleshoot', 'New-AzAvailabilityGroupListener', 'New-AzSqlVirtualMachineAgReplicaObject', 'New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject', 'New-AzSqlVM', 'New-AzSqlVMGroup', 'Remove-AzAvailabilityGroupListener', 'Remove-AzSqlVM', 'Remove-AzSqlVMGroup', 'Start-AzSqlVMAssessment', 'Update-AzSqlVM', 'Update-AzSqlVMGroup', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SqlVirtualMachine'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
