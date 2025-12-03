if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryPolicy' {
    $policyName = $env.policyTests.getTests.Get.policyName
    It 'Get' {
        $policyTestParams = $env.policyTests.getTests.Get
        
        $policy = Get-AzDeviceRegistryPolicy `
            -Name $policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup
        
        $policy.Name | Should -Be $policyTestParams.policyName
        $policy.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }

    It 'List' {
        $policyList = Get-AzDeviceRegistryPolicy `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup
        
        $policyList.Count | Should -BeGreaterThan 0
    }

    It 'GetViaIdentity' {
        $policyTestParams = $env.policyTests.getTests.GetViaIdentity
        
        $policy = Get-AzDeviceRegistryPolicy `
            -Name $policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup
        
        $policyViaIdentity = Get-AzDeviceRegistryPolicy -InputObject $policy
        
        $policyViaIdentity.Name | Should -Be $policyName
        $policyViaIdentity.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }
}
