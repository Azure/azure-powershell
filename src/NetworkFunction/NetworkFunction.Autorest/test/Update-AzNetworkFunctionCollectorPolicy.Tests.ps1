if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkFunctionCollectorPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkFunctionCollectorPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkFunctionCollectorPolicy' {
    It 'UpdateExpanded' {
        { 
            { Update-AzNetworkFunctionCollectorPolicy -collectorpolicyname $env.collectorPolicyName -azuretrafficcollectorname $env.azureTrafficCollectorName -resourcegroupname $env.resourceGroup -location $env.location -IngestionPolicyIngestionSource @{ResourceId = $env.ResourceId1G} -IngestionPolicyIngestionType $env.IngestionType } | Should Not Throw
        }
    }

    It 'UpdateExpanded1' {
        { 
            { Update-AzNetworkFunctionCollectorPolicy -collectorpolicyname $env.collectorPolicyName -azuretrafficcollectorname $env.azureTrafficCollectorName -resourcegroupname $env.resourceGroup -location $env.location -IngestionPolicyIngestionSource @{ResourceId = $env.ResourceIdLessThan1G} -IngestionPolicyIngestionType $env.IngestionType } | Should Throw -ExpectedMessage "CollectorPolicy can not be updated because circuit has bandwidth less than 1G. Circuit size with a bandwidth of 1G or more is supported."
        }
    }

    It 'UpdateExpanded2' {
        { 
            { Update-AzNetworkFunctionCollectorPolicy -collectorpolicyname $env.collectorPolicyName -azuretrafficcollectorname $env.azureTrafficCollectorName -resourcegroupname $env.resourceGroup -location $env.location -IngestionPolicyIngestionSource @{ResourceId = $env.ResourceIdLessThan1G}, @{ResourceId = $env.ResourceId1G} -IngestionPolicyIngestionType $env.IngestionType } | Should Throw -ExpectedMessage "CollectorPolicy can not be updated because circuit has bandwidth less than 1G. Circuit size with a bandwidth of 1G or more is supported."
        }
    }
}