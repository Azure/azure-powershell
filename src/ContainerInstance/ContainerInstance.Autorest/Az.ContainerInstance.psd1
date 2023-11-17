@{
  GUID = '78f5cd97-9a2c-4258-bf37-7a8820083684'
  RootModule = './Az.ContainerInstance.psm1'
  ModuleVersion = '1.0.3'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ContainerInstance cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ContainerInstance.private.dll'
  FormatsToProcess = './Az.ContainerInstance.format.ps1xml'
  FunctionsToExport = 'Add-AzContainerInstanceOutput', 'Get-AzContainerGroup', 'Get-AzContainerInstanceCachedImage', 'Get-AzContainerInstanceCapability', 'Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint', 'Get-AzContainerInstanceLog', 'Get-AzContainerInstanceUsage', 'Invoke-AzContainerInstanceCommand', 'New-AzContainerGroup', 'New-AzContainerGroupImageRegistryCredentialObject', 'New-AzContainerGroupPortObject', 'New-AzContainerGroupVolumeObject', 'New-AzContainerInstanceEnvironmentVariableObject', 'New-AzContainerInstanceHttpHeaderObject', 'New-AzContainerInstanceInitDefinitionObject', 'New-AzContainerInstanceObject', 'New-AzContainerInstancePortObject', 'New-AzContainerInstanceVolumeMountObject', 'Remove-AzContainerGroup', 'Remove-AzContainerInstanceSubnetServiceAssociationLink', 'Restart-AzContainerGroup', 'Start-AzContainerGroup', 'Stop-AzContainerGroup', 'Update-AzContainerGroup', '*'
  AliasesToExport = 'Get-AzContainerGroupOutboundNetworkDependencyEndpoint', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ContainerInstance'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
