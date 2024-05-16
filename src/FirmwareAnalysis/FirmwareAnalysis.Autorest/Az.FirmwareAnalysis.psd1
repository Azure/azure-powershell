@{
  GUID = 'e097ff3f-acb2-48da-86fe-937d86006ea5'
  RootModule = './Az.FirmwareAnalysis.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: FirmwareAnalysis cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.FirmwareAnalysis.private.dll'
  FormatsToProcess = './Az.FirmwareAnalysis.format.ps1xml'
  FunctionsToExport = 'Get-AzFirmwareAnalysisBinaryHardening', 'Get-AzFirmwareAnalysisCryptoCertificate', 'Get-AzFirmwareAnalysisCryptoKey', 'Get-AzFirmwareAnalysisCve', 'Get-AzFirmwareAnalysisFirmware', 'Get-AzFirmwareAnalysisPasswordHash', 'Get-AzFirmwareAnalysisSbomComponent', 'Get-AzFirmwareAnalysisSummary', 'Get-AzFirmwareAnalysisWorkspace', 'New-AzFirmwareAnalysisFirmware', 'New-AzFirmwareAnalysisWorkspace', 'New-AzFirmwareAnalysisWorkspaceUploadUrl', 'Remove-AzFirmwareAnalysisFirmware', 'Remove-AzFirmwareAnalysisWorkspace', 'Update-AzFirmwareAnalysisFirmware', 'Update-AzFirmwareAnalysisWorkspace'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'FirmwareAnalysis'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
