if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSecurityApiCollectionApimOnboard'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSecurityApiCollectionApimOnboard.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSecurityApiCollectionApimOnboard' {
    It 'Azure' {
        $rg = $env.ApiCollectionsResourceGroupName
        try {
            $collection = Invoke-AzSecurityApiCollectionApimOnboard -ResourceGroupName $rg -ServiceName "demoapimservice2" -ApiId "echo-api-2"
            $collection.Name | Should -Be "echo-api-2"
            $collection.ProvisioningState | Should -Be "Succeeded"
        } finally {
            Invoke-AzSecurityApiCollectionApimOffboard -ResourceGroupName $rg -ServiceName "demoapimservice2" -ApiId "echo-api-2"
        }
    }

    It 'AzureViaIdentity' {
        $rg = $env.ApiCollectionsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourceGroups/$rg/providers/Microsoft.ApiManagement/service/demoapimservice2/providers/Microsoft.Security/apiCollections/echo-api-2" }

        try {
            $collection = Invoke-AzSecurityApiCollectionApimOnboard -InputObject $InputObject
            $collection.Name | Should -Be "echo-api-2"
            $collection.ProvisioningState | Should -Be "Succeeded"
        } finally {
            Invoke-AzSecurityApiCollectionApimOffboard -InputObject $InputObject
        }
    }
}
