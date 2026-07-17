@{
  GUID = '14e3f478-140d-42df-9823-58a499329981'
  RootModule = './Az.FrontDoor.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: FrontDoor cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.FrontDoor.private.dll'
  FormatsToProcess = './Az.FrontDoor.format.ps1xml'
  FunctionsToExport = 'Disable-AzFrontDoorCustomDomainHttps', 'Enable-AzFrontDoorCustomDomainHttps', 'Get-AzFrontDoor', 'Get-AzFrontDoorFrontendEndpoint', 'Get-AzFrontDoorRulesEngine', 'Get-AzFrontDoorWafManagedRuleSetDefinition', 'Get-AzFrontDoorWafPolicy', 'New-AzFrontDoor', 'New-AzFrontDoorBackendObject', 'New-AzFrontDoorBackendPoolObject', 'New-AzFrontDoorBackendPoolsSettingObject', 'New-AzFrontDoorCacheConfigurationObject', 'New-AzFrontDoorForwardingConfigurationObject', 'New-AzFrontDoorFrontendEndpointObject', 'New-AzFrontDoorHeaderActionObject', 'New-AzFrontDoorHealthProbeSettingObject', 'New-AzFrontDoorLoadBalancingSettingObject', 'New-AzFrontDoorPolicySettingsObject', 'New-AzFrontDoorRedirectConfigurationObject', 'New-AzFrontDoorRoutingRuleObject', 'New-AzFrontDoorRulesEngine', 'New-AzFrontDoorRulesEngineActionObject', 'New-AzFrontDoorRulesEngineMatchConditionObject', 'New-AzFrontDoorRulesEngineRuleObject', 'New-AzFrontDoorWafCustomRuleGroupByVariableObject', 'New-AzFrontDoorWafCustomRuleObject', 'New-AzFrontDoorWafLogScrubbingRuleObject', 'New-AzFrontDoorWafLogScrubbingSettingObject', 'New-AzFrontDoorWafManagedRuleExclusionObject', 'New-AzFrontDoorWafManagedRuleObject', 'New-AzFrontDoorWafManagedRuleOverrideObject', 'New-AzFrontDoorWafMatchConditionObject', 'New-AzFrontDoorWafPolicy', 'New-AzFrontDoorWafRuleGroupOverrideObject', 'Remove-AzFrontDoor', 'Remove-AzFrontDoorContent', 'Remove-AzFrontDoorRulesEngine', 'Remove-AzFrontDoorWafPolicy', 'Set-AzFrontDoor', 'Set-AzFrontDoorRulesEngine', 'Update-AzFrontDoorWafPolicy'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'FrontDoor'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
