if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFabricCapacity'))
{
  $fabricCommonPath = Join-Path $PSScriptRoot 'common.ps1'
    . ($fabricCommonPath)
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFabricCapacity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFabricCapacity' {
    It 'Delete' {
        $newCapacityName = "azpowershellfabriccapacity"
        $newCapacityId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Fabric/capacities/$($newCapacityName)"

        $result = New-AzFabricCapacity `
            -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupName `
            -CapacityName $newCapacityName `
            -Location $env.Location `
            -AdministrationMember $env.AdministrationMembers `
            -SkuName $env.SkuName
        Validate_Capacity $result $newCapacityName $newCapacityId $env.Location "Active" "Succeeded" $env.SkuName

        Remove-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $newCapacityName 

        { Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $newCapacityName } | Should -Throw
    }
}
