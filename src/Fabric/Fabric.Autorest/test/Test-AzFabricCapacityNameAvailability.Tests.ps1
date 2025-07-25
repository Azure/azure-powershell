if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFabricCapacityNameAvailability'))
{
  $fabricCommonPath = Join-Path $PSScriptRoot 'common.ps1'
    . ($fabricCommonPath)
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFabricCapacityNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFabricCapacityNameAvailability' {
    It 'CheckExpanded' {
        $newCapacityName = RandomString -allChars $true -len 12
        $result = Test-AzFabricCapacityNameAvailability -Location $env.Location -Name $newCapacityName -Type "Microsoft.Fabric/capacities"
        $result.NameAvailable | Should -Be $true

        $result = Test-AzFabricCapacityNameAvailability -Location $env.Location -Name $env.CapacityName -Type "Microsoft.Fabric/capacities"
        $result.NameAvailable | Should -Be $false 
        $result.Reason | Should -Be "AlreadyExists"
    }

    It 'CheckViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Check' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
