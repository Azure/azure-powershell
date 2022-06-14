@{
  GUID = '8344b0d3-a750-45cd-9290-00e5cdc879c3'
  RootModule = './Az.Subscription.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Subscription cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Subscription.private.dll'
  FormatsToProcess = './Az.Subscription.format.ps1xml'
  FunctionsToExport = 'Add-AzSubscriptionPolicyUpdatePolicy', 'Enable-AzSubscription', 'Get-AzSubscription', 'Get-AzSubscriptionAlias', 'Get-AzSubscriptionBillingAccountPolicy', 'Get-AzSubscriptionLocation', 'Get-AzSubscriptionPolicy', 'Get-AzSubscriptionTenant', 'Invoke-AzSubscriptionAcceptSubscriptionOwnership', 'Invoke-AzSubscriptionAcceptSubscriptionOwnershipStatus', 'New-AzSubscriptionAlias', 'Remove-AzSubscriptionAlias', 'Rename-AzSubscription', 'Stop-AzSubscription', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Subscription'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
