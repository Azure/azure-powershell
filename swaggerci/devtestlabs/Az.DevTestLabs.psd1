@{
  GUID = 'c1890734-b992-4104-a071-4f8e42fe8395'
  RootModule = './Az.DevTestLabs.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DevTestLabs cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DevTestLabs.private.dll'
  FormatsToProcess = './Az.DevTestLabs.format.ps1xml'
  FunctionsToExport = 'Add-AzDevTestLabsDisk', 'Add-AzDevTestLabsVirtualMachineArtifact', 'Add-AzDevTestLabsVirtualMachineDataDisk', 'Export-AzDevTestLabsLabResourceUsage', 'Get-AzDevTestLabsArmTemplate', 'Get-AzDevTestLabsArtifact', 'Get-AzDevTestLabsArtifactSource', 'Get-AzDevTestLabsCost', 'Get-AzDevTestLabsCustomImage', 'Get-AzDevTestLabsDisk', 'Get-AzDevTestLabsEnvironment', 'Get-AzDevTestLabsFormula', 'Get-AzDevTestLabsGalleryImage', 'Get-AzDevTestLabsGlobalSchedule', 'Get-AzDevTestLabsLab', 'Get-AzDevTestLabsLabVhd', 'Get-AzDevTestLabsNotificationChannel', 'Get-AzDevTestLabsPolicy', 'Get-AzDevTestLabsProviderOperation', 'Get-AzDevTestLabsSchedule', 'Get-AzDevTestLabsScheduleApplicable', 'Get-AzDevTestLabsSecret', 'Get-AzDevTestLabsServiceFabric', 'Get-AzDevTestLabsServiceFabricApplicableSchedule', 'Get-AzDevTestLabsServiceFabricSchedule', 'Get-AzDevTestLabsServiceRunner', 'Get-AzDevTestLabsUser', 'Get-AzDevTestLabsVirtualMachine', 'Get-AzDevTestLabsVirtualMachineApplicableSchedule', 'Get-AzDevTestLabsVirtualMachineRdpFileContent', 'Get-AzDevTestLabsVirtualMachineSchedule', 'Get-AzDevTestLabsVirtualNetwork', 'Import-AzDevTestLabsLabVirtualMachine', 'Invoke-AzDevTestLabsClaimLabAnyVM', 'Invoke-AzDevTestLabsClaimVirtualMachine', 'Invoke-AzDevTestLabsClaimVirtualMachineUn', 'Invoke-AzDevTestLabsDetachDisk', 'Invoke-AzDevTestLabsDetachVirtualMachineDataDisk', 'Invoke-AzDevTestLabsExecuteGlobalSchedule', 'Invoke-AzDevTestLabsExecuteSchedule', 'Invoke-AzDevTestLabsExecuteServiceFabricSchedule', 'Invoke-AzDevTestLabsExecuteVirtualMachineSchedule', 'Invoke-AzDevTestLabsRedeployVirtualMachine', 'Move-AzDevTestLabsVirtualMachineDisk', 'New-AzDevTestLabsArtifactArmTemplate', 'New-AzDevTestLabsArtifactSource', 'New-AzDevTestLabsCost', 'New-AzDevTestLabsCustomImage', 'New-AzDevTestLabsDisk', 'New-AzDevTestLabsEnvironment', 'New-AzDevTestLabsFormula', 'New-AzDevTestLabsGlobalSchedule', 'New-AzDevTestLabsLab', 'New-AzDevTestLabsLabEnvironment', 'New-AzDevTestLabsLabUploadUri', 'New-AzDevTestLabsNotificationChannel', 'New-AzDevTestLabsPolicy', 'New-AzDevTestLabsSchedule', 'New-AzDevTestLabsSecret', 'New-AzDevTestLabsServiceFabric', 'New-AzDevTestLabsServiceFabricSchedule', 'New-AzDevTestLabsServiceRunner', 'New-AzDevTestLabsUser', 'New-AzDevTestLabsVirtualMachine', 'New-AzDevTestLabsVirtualMachineSchedule', 'New-AzDevTestLabsVirtualNetwork', 'Remove-AzDevTestLabsArtifactSource', 'Remove-AzDevTestLabsCustomImage', 'Remove-AzDevTestLabsDisk', 'Remove-AzDevTestLabsEnvironment', 'Remove-AzDevTestLabsFormula', 'Remove-AzDevTestLabsGlobalSchedule', 'Remove-AzDevTestLabsLab', 'Remove-AzDevTestLabsNotificationChannel', 'Remove-AzDevTestLabsPolicy', 'Remove-AzDevTestLabsSchedule', 'Remove-AzDevTestLabsSecret', 'Remove-AzDevTestLabsServiceFabric', 'Remove-AzDevTestLabsServiceFabricSchedule', 'Remove-AzDevTestLabsServiceRunner', 'Remove-AzDevTestLabsUser', 'Remove-AzDevTestLabsVirtualMachine', 'Remove-AzDevTestLabsVirtualMachineSchedule', 'Remove-AzDevTestLabsVirtualNetwork', 'Resize-AzDevTestLabsVirtualMachine', 'Restart-AzDevTestLabsVirtualMachine', 'Send-AzDevTestLabsNotificationChannel', 'Start-AzDevTestLabsServiceFabric', 'Start-AzDevTestLabsVirtualMachine', 'Stop-AzDevTestLabsServiceFabric', 'Stop-AzDevTestLabsVirtualMachine', 'Test-AzDevTestLabsPolicySetPolicy', 'Update-AzDevTestLabsArtifactSource', 'Update-AzDevTestLabsCustomImage', 'Update-AzDevTestLabsDisk', 'Update-AzDevTestLabsEnvironment', 'Update-AzDevTestLabsFormula', 'Update-AzDevTestLabsGlobalSchedule', 'Update-AzDevTestLabsLab', 'Update-AzDevTestLabsNotificationChannel', 'Update-AzDevTestLabsPolicy', 'Update-AzDevTestLabsSchedule', 'Update-AzDevTestLabsSecret', 'Update-AzDevTestLabsServiceFabric', 'Update-AzDevTestLabsServiceFabricSchedule', 'Update-AzDevTestLabsUser', 'Update-AzDevTestLabsVirtualMachine', 'Update-AzDevTestLabsVirtualMachineSchedule', 'Update-AzDevTestLabsVirtualNetwork', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DevTestLabs'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
