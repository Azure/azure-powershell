@{
  GUID = '7c220d70-27ec-4403-aedd-429aa925a6a6'
  RootModule = './Az.BillingBenefits.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: BillingBenefits cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.BillingBenefits.private.dll'
  FormatsToProcess = './Az.BillingBenefits.format.ps1xml'
  FunctionsToExport = 'Get-AzBillingBenefitsReservationOrderAlias', 'Get-AzBillingBenefitsSavingsPlan', 'Get-AzBillingBenefitsSavingsPlanList', 'Get-AzBillingBenefitsSavingsPlanOrder', 'Get-AzBillingBenefitsSavingsPlanOrderAlias', 'Invoke-AzBillingBenefitsElevateSavingPlanOrder', 'Invoke-AzBillingBenefitsSavingsPlanPurchaseValidation', 'Invoke-AzBillingBenefitsSavingsPlanUpdateValidation', 'New-AzBillingBenefitsReservationOrderAlias', 'New-AzBillingBenefitsSavingsPlanOrderAlias', 'Update-AzBillingBenefitsSavingsPlan', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'BillingBenefits'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
