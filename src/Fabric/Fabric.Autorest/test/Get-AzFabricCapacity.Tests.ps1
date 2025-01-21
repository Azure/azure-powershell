if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFabricCapacity'))
{
  $fabricCommonPath = Join-Path $PSScriptRoot 'common.ps1'
    . ($fabricCommonPath)
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFabricCapacity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFabricCapacity' {
    It 'List' {
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId
        $result.Count | Should -BeGreaterOrEqual 1
        Validate_Capacity_Exists_In_Array $result    
    }

    It 'Get' {
        $result = Get-AzFabricCapacity -CapacityName $env.CapacityName -ResourceGroupName $env.ResourceGroupName
        Validate_Capacity $result $env.CapacityName $env.CapacityId $env.Location "Active" "Succeeded" $env.SkuName
    }

    It 'List1' {
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName
        $result.Count | Should -BeGreaterOrEqual 1
        Validate_Capacity_Exists_In_Array $result
    }
}
