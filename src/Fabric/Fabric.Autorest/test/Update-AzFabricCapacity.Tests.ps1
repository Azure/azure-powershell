if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFabricCapacity'))
{
  $fabricCommonPath = Join-Path $PSScriptRoot 'common.ps1'
    . ($fabricCommonPath)
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFabricCapacity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFabricCapacity' {
    It 'UpdateExpanded' {
        $newSkuName = "F4"
        Update-AzFabricCapacity -CapacityName $env.CapacityName -ResourceGroupName $env.ResourceGroupName -SkuName $newSkuName
        $result = Get-AzFabricCapacity -CapacityName $env.CapacityName -ResourceGroupName $env.ResourceGroupName
        Validate_Capacity $result $env.CapacityName $env.CapacityId $env.Location "Active" "Succeeded" $newSkuName

        Update-AzFabricCapacity -CapacityName $env.CapacityName -ResourceGroupName $env.ResourceGroupName -SkuName $env.SkuName
        $result = Get-AzFabricCapacity -CapacityName $env.CapacityName -ResourceGroupName $env.ResourceGroupName
        Validate_Capacity $result $env.CapacityName $env.CapacityId $env.Location "Active" "Succeeded" $env.SkuName
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
