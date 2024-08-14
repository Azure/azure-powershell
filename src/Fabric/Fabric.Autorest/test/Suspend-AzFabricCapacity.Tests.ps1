if(($null -eq $TestName) -or ($TestName -contains 'Suspend-AzFabricCapacity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Suspend-AzFabricCapacity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Suspend-AzFabricCapacity' -skip {
    It 'Suspend' -skip {
        Suspend-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        Validate_Capacity $result $newCapacityName $newCapacityId $env.LOCATION "Suspended" "Succeeded" $env.SKU_NAME

        Resume-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        Validate_Capacity $result $newCapacityName $newCapacityId $env.LOCATION "Active" "Succeeded" $env.SKU_NAME
    }

    It 'SuspendViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
