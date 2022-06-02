@{
  GUID = '1d339b1c-5a86-4fbd-9a2e-d0497c39b397'
  RootModule = './Az.NetworkFunction.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NetworkFunction.private.dll'
  FormatsToProcess = './Az.NetworkFunction.format.ps1xml'
  FunctionsToExport = 'Get-AzNetworkFunctionOperation', 'Get-AzNetworkFunctionTrafficCollector', 'Get-AzNetworkFunctionTrafficCollectorPolicy', 'New-AzNetworkFunctionTrafficCollector', 'New-AzNetworkFunctionTrafficCollectorPolicy', 'Remove-AzNetworkFunctionTrafficCollector', 'Remove-AzNetworkFunctionTrafficCollectorPolicy', 'Set-AzNetworkFunctionTrafficCollector', 'Set-AzNetworkFunctionTrafficCollectorPolicy', 'Update-AzNetworkFunctionTrafficCollectorTag', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = ''
      LicenseUri = ''
      ProjectUri = ''
      ReleaseNotes = ''
    }
  }
}
