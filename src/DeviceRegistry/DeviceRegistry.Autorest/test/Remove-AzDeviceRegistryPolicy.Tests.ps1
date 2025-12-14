if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryPolicy' {
    It 'Delete' {
        $policyTestParams = $env.policyTests.deleteTests.Delete
        $policy = Get-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup
        
        $policy.Name | Should -Be $policyTestParams.policyName

        Remove-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup
        
        { Get-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup `
            -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' -skip {
        $policyTestParams = $env.policyTests.deleteTests.DeleteViaIdentity
        
        $policy = Get-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup
        
        Remove-AzDeviceRegistryPolicy -InputObject $policy
        
        { Get-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup `
            -ErrorAction Stop } | Should -Throw
    }
}
