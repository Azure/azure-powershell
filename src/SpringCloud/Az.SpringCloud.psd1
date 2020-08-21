@{
  GUID = '697e18d3-95de-4211-86a1-ec7c4e163874'
  RootModule = './Az.SpringCloud.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SpringCloud cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SpringCloud.private.dll'
  FormatsToProcess = './Az.SpringCloud.format.ps1xml'
  FunctionsToExport = 'Deploy-AzSpringCloudApp', 'Get-AzSpringCloud', 'Get-AzSpringCloudApp', 'Get-AzSpringCloudAppDeployment', 'New-AzSpringCloud', 'New-AzSpringCloudApp', 'New-AzSpringCloudAppDeployment', 'Remove-AzSpringCloud', 'Remove-AzSpringCloudApp', 'Remove-AzSpringCloudAppDeployment', 'Restart-AzSpringCloudAppDeployment', 'Start-AzSpringCloudAppDeployment', 'Stop-AzSpringCloudAppDeployment', 'Update-AzSpringCloud', 'Update-AzSpringCloudApp', 'Update-AzSpringCloudAppDeployment', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SpringCloud'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
