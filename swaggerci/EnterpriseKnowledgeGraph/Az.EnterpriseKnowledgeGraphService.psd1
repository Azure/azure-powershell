@{
  GUID = '5f5ee29c-c77c-4dda-a13c-a19e0d153009'
  RootModule = './Az.EnterpriseKnowledgeGraphService.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EnterpriseKnowledgeGraphService cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EnterpriseKnowledgeGraphService.private.dll'
  FormatsToProcess = './Az.EnterpriseKnowledgeGraphService.format.ps1xml'
  FunctionsToExport = 'Get-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph', 'New-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph', 'Remove-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph', 'Update-AzEnterpriseKnowledgeGraphServiceEnterpriseKnowledgeGraph', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EnterpriseKnowledgeGraphService'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
