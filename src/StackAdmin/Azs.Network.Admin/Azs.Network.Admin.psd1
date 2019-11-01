@{
  GUID = 'eb604b4c-005c-4fb2-a304-7db65b127980'
  RootModule = 'Azs.Network.Admin.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Azs.Network.Admin.private.dll'
  FormatsToProcess = './Azs.Network.Admin.format.ps1xml'
  CmdletsToExport = 'Get-AzsLoadBalancer', 'Get-AzsNetworkQuota', 'Get-AzsPublicIPAddress', 'Get-AzsResourceProviderState', 'Get-AzsVirtualNetwork', 'New-AzsNetworkQuota', 'Remove-AzsNetworkQuota', 'Set-AzsNetworkQuota', '*'
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
