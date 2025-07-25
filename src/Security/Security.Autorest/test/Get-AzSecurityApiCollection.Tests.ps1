if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityApiCollection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityApiCollection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityApiCollection' {
    It 'List' {
        $rg = $env.ApiCollectionsResourceGroupName
        $collections = Get-AzSecurityApiCollection -ResourceGroupName $rg
        $collections.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $rg = $env.ApiCollectionsResourceGroupName
        $collection = Get-AzSecurityApiCollection -ResourceGroup $rg -ServiceName "demoapimservice2" -ApiId "echo-api"
        $collection | Should -Not -Be $null
        $collection.Name.Contains('echo-api') | Should -Be $true
    }

    It 'ListBySubscription' {
        $collections = Get-AzSecurityApiCollection
        $collections.Count | Should -BeGreaterThan 0
    }

    It 'ListByService' {
        $rg = $env.ApiCollectionsResourceGroupName
        $collections = Get-AzSecurityApiCollection -ResourceGroup $rg -ServiceName "demoapimservice2"
        $collections.Count | Should -BeGreaterThan 0
    }

    It 'GetViaIdentity' {
        $rg = $env.ApiCollectionsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourceGroups/$rg/providers/Microsoft.ApiManagement/service/demoapimservice2/providers/Microsoft.Security/apiCollections/echo-api" }
        $collection = Get-AzSecurityApiCollection -InputObject $InputObject
        $collection.Count | Should -Be 1
        $collection.Name.Contains('echo-api') | Should -Be $true
    }
}
