@{
  GUID = 'de6f0bb1-4329-4515-9334-da214c66c970'
  RootModule = './Az.MachineLearningWorkspaces.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MachineLearningWorkspaces cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MachineLearningWorkspaces.private.dll'
  FormatsToProcess = './Az.MachineLearningWorkspaces.format.ps1xml'
  FunctionsToExport = 'Get-AzMachineLearningWorkspacesCompute', 'Get-AzMachineLearningWorkspacesComputeKey', 'Get-AzMachineLearningWorkspacesComputeNode', 'Get-AzMachineLearningWorkspacesPrivateEndpointConnection', 'Get-AzMachineLearningWorkspacesPrivateLinkResource', 'Get-AzMachineLearningWorkspacesQuota', 'Get-AzMachineLearningWorkspacesUsage', 'Get-AzMachineLearningWorkspacesVirtualMachineSize', 'Get-AzMachineLearningWorkspacesWorkspace', 'Get-AzMachineLearningWorkspacesWorkspaceConnection', 'Get-AzMachineLearningWorkspacesWorkspaceFeature', 'Get-AzMachineLearningWorkspacesWorkspaceKey', 'Get-AzMachineLearningWorkspacesWorkspaceNotebookAccessToken', 'Get-AzMachineLearningWorkspacesWorkspaceNotebookKey', 'Get-AzMachineLearningWorkspacesWorkspaceOutboundNetworkDependencyEndpoint', 'Get-AzMachineLearningWorkspacesWorkspaceSku', 'Get-AzMachineLearningWorkspacesWorkspaceStorageAccountKey', 'Invoke-AzMachineLearningWorkspacesDiagnoseWorkspace', 'Invoke-AzMachineLearningWorkspacesPrepareWorkspaceNotebook', 'Invoke-AzMachineLearningWorkspacesResyncWorkspaceKey', 'New-AzMachineLearningWorkspacesCompute', 'New-AzMachineLearningWorkspacesPrivateEndpointConnection', 'New-AzMachineLearningWorkspacesWorkspace', 'New-AzMachineLearningWorkspacesWorkspaceConnection', 'Remove-AzMachineLearningWorkspacesCompute', 'Remove-AzMachineLearningWorkspacesPrivateEndpointConnection', 'Remove-AzMachineLearningWorkspacesWorkspace', 'Remove-AzMachineLearningWorkspacesWorkspaceConnection', 'Restart-AzMachineLearningWorkspacesCompute', 'Start-AzMachineLearningWorkspacesCompute', 'Stop-AzMachineLearningWorkspacesCompute', 'Update-AzMachineLearningWorkspacesCompute', 'Update-AzMachineLearningWorkspacesQuota', 'Update-AzMachineLearningWorkspacesWorkspace', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MachineLearningWorkspaces'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
