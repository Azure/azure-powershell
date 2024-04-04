if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFunctionCollectorPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFunctionCollectorPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFunctionCollectorPolicy' {
    It 'CreateExpanded' {
        { 
            { New-AzNetworkFunctionCollectorPolicy -collectorpolicyname $env.collectorPolicyName -azuretrafficcollectorname $env.azureTrafficCollectorName -resourcegroupname $env.resourceGroup -location $env.location -IngestionPolicyIngestionSource @{ResourceId = $env.ResourceId1G} -IngestionPolicyIngestionType $env.IngestionType } | Should -Not -Throw
        } 
    }

    It 'CreateExpanded1' {
        { 
            { New-AzNetworkFunctionCollectorPolicy -collectorpolicyname $env.collectorPolicyName -azuretrafficcollectorname $env.azureTrafficCollectorName -resourcegroupname $env.resourceGroup -location $env.location -IngestionPolicyIngestionSource @{ResourceId = $env.ResourceIdLessThan1G} -IngestionPolicyIngestionType $env.IngestionType } | Should -Throw -ExpectedMessage "CollectorPolicy can not be updated because circuit has bandwidth less than 1G. Circuit size with a bandwidth of 1G or more is supported."
        } 
    }

    It 'Create' {
        { 
            { New-AzNetworkFunctionCollectorPolicy -collectorpolicyname $env.collectorPolicyName -azuretrafficcollectorname $env.azureTrafficCollectorName -resourcegroupname $env.resourceGroup -location $env.location -IngestionPolicyIngestionSource @{ResourceId = $env.ResourceId1G} -IngestionPolicyIngestionType $env.IngestionType } | Should -Not -Throw
        }
    }

    It 'CreateViaIdentityExpanded' {
        { 
            { New-AzNetworkFunctionCollectorPolicy -collectorpolicyname $env.collectorPolicyName -azuretrafficcollectorname $env.azureTrafficCollectorName -resourcegroupname $env.resourceGroup -location $env.location -IngestionPolicyIngestionSource @{ResourceId = $env.ResourceId1G} -IngestionPolicyIngestionType $env.IngestionType } | Should -Not -Throw
        }
    }

    It 'CreateViaIdentity' {
        {
            { New-AzNetworkFunctionCollectorPolicy -collectorpolicyname $env.collectorPolicyName -azuretrafficcollectorname $env.azureTrafficCollectorName -resourcegroupname $env.resourceGroup -location $env.location -IngestionPolicyIngestionSource @{ResourceId = $env.ResourceId1G} -IngestionPolicyIngestionType $env.IngestionType } | Should -Not -Throw
        }
    }
}
