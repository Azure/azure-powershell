@{
  GUID = '16846b06-e1a9-4928-95ad-8a030e6c28e5'
  RootModule = './Az.KubernetesRuntime.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: KubernetesRuntime cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.KubernetesRuntime.private.dll'
  FormatsToProcess = './Az.KubernetesRuntime.format.ps1xml'
  FunctionsToExport = 'Disable-AzKubernetesRuntimeLoadBalancer', 'Disable-AzKubernetesRuntimeStorageClass', 'Enable-AzKubernetesRuntimeLoadBalancer', 'Enable-AzKubernetesRuntimeStorageClass', 'Get-AzKubernetesRuntimeBgpPeer', 'Get-AzKubernetesRuntimeLoadBalancer', 'Get-AzKubernetesRuntimeService', 'Get-AzKubernetesRuntimeStorageClass', 'New-AzKubernetesRuntimeBgpPeer', 'New-AzKubernetesRuntimeBlobStorageClassTypePropertiesObject', 'New-AzKubernetesRuntimeLoadBalancer', 'New-AzKubernetesRuntimeNativeStorageClassTypePropertiesObject', 'New-AzKubernetesRuntimeNfsStorageClassTypePropertiesObject', 'New-AzKubernetesRuntimeRwxStorageClassTypePropertiesObject', 'New-AzKubernetesRuntimeService', 'New-AzKubernetesRuntimeSmbStorageClassTypePropertiesObject', 'New-AzKubernetesRuntimeStorageClass', 'Remove-AzKubernetesRuntimeBgpPeer', 'Remove-AzKubernetesRuntimeLoadBalancer', 'Remove-AzKubernetesRuntimeService', 'Remove-AzKubernetesRuntimeStorageClass', 'Update-AzKubernetesRuntimeBgpPeer', 'Update-AzKubernetesRuntimeLoadBalancer', 'Update-AzKubernetesRuntimeService', 'Update-AzKubernetesRuntimeStorageClass'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'KubernetesRuntime'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
