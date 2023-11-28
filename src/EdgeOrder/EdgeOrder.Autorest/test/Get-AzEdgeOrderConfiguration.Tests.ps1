if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeOrderConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeOrderConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeOrderConfiguration' {
    It 'ListExpanded' {
        $filterableProperty = New-AzEdgeOrderFilterablePropertyObject -Type "ShipToCountries" -SupportedValue @("US")
        $HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
        Get-AzEdgeOrderConfiguration -SubscriptionId $env.SubscriptionId -ConfigurationFilter @(@{"HierarchyInformation"=$HierarchyInformation; "FilterableProperty"= @($filterableProperty)})
    }
}
