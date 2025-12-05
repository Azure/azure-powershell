if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryPolicy' {
    It 'CreateExpanded' {
        $policyTestParams = $env.policyTests.createTests.CreateExpanded
        
        $policy = New-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup `
            -Location $env.policyTests.location
        
        $policy.Name | Should -Be $policyTestParams.policyName
        $policy.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }

    It 'CreateViaJsonFilePath' -skip {
        $policyTestParams = $env.policyTests.createTests.CreateViaJsonFilePath
        $jsonFilePath = (Join-Path $PSScriptRoot $policyTestParams.jsonFilePath)
        
        $policy = New-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup `
            -JsonFilePath $jsonFilePath
        
        $policy.Name | Should -Be $policyTestParams.policyName
        $policy.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }

    It 'CreateViaJsonString' -skip {
        $policyTestParams = $env.policyTests.createTests.CreateViaJsonString
        $jsonFilePath = (Join-Path $PSScriptRoot $policyTestParams.jsonFilePath)
        $jsonString = Get-Content -Path $jsonFilePath -Raw
        
        $policy = New-AzDeviceRegistryPolicy `
            -Name $policyTestParams.policyName `
            -NamespaceName $env.policyTests.namespaceName `
            -ResourceGroupName $env.policyTests.resourceGroup `
            -JsonString $jsonString
        
        $policy.Name | Should -Be $policyTestParams.policyName
        $policy.ResourceGroupName | Should -Be $env.policyTests.resourceGroup
    }
}
