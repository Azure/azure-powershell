if(($null -eq $TestName) -or ($TestName -contains 'Resume-AzFabricCapacity'))
{
  $fabricCommonPath = Join-Path $PSScriptRoot 'common.ps1'
    . ($fabricCommonPath)
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Resume-AzFabricCapacity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Resume-AzFabricCapacity' {
<<<<<<< HEAD
    It 'Resume' {
        Suspend-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        Validate_Capacity $result $env.CAPACITY_NAME $env.CAPACITY_ID $env.LOCATION "Paused" "Succeeded" $env.SKU_NAME

        Resume-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        Validate_Capacity $result $env.CAPACITY_NAME $env.CAPACITY_ID $env.LOCATION "Active" "Succeeded" $env.SKU_NAME
=======
    It 'Resume' -skip {
        Suspend-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        Validate_Capacity $result $newCapacityName $newCapacityId $env.LOCATION "Suspended" "Succeeded" $env.SKU_NAME

        Resume-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CAPACITY_NAME
        Validate_Capacity $result $newCapacityName $newCapacityId $env.LOCATION "Active" "Succeeded" $env.SKU_NAME
    }

    It 'ResumeViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
>>>>>>> 4ad88641e3d17effff8ed003b8f9d3532053ae5c
    }
}
