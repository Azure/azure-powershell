@{
  GUID = 'eb2b1078-bf0a-448a-8314-def7d506b75b'
  RootModule = './Az.ServiceFabricMesh.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ServiceFabricMesh cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ServiceFabricMesh.private.dll'
  FormatsToProcess = './Az.ServiceFabricMesh.format.ps1xml'
  FunctionsToExport = 'Get-AzServiceFabricMeshApplication', 'Get-AzServiceFabricMeshCodePackageContainerLog', 'Get-AzServiceFabricMeshGateway', 'Get-AzServiceFabricMeshNetwork', 'Get-AzServiceFabricMeshSecret', 'Get-AzServiceFabricMeshSecretValue', 'Get-AzServiceFabricMeshService', 'Get-AzServiceFabricMeshServiceReplica', 'Get-AzServiceFabricMeshVolume', 'New-AzServiceFabricMeshApplication', 'New-AzServiceFabricMeshGateway', 'New-AzServiceFabricMeshNetwork', 'New-AzServiceFabricMeshSecret', 'New-AzServiceFabricMeshSecretValue', 'New-AzServiceFabricMeshVolume', 'Remove-AzServiceFabricMeshApplication', 'Remove-AzServiceFabricMeshGateway', 'Remove-AzServiceFabricMeshNetwork', 'Remove-AzServiceFabricMeshSecret', 'Remove-AzServiceFabricMeshSecretValue', 'Remove-AzServiceFabricMeshVolume', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ServiceFabricMesh'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
