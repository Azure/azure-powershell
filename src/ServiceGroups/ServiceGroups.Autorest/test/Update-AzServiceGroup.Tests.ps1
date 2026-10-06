if(($null -eq $TestName) -or ($TestName -contains 'Update-AzServiceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzServiceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzServiceGroup' {
    It 'UpdateExpanded' {
        $serviceGroup = Update-AzServiceGroup -Name $env.ServiceGroupNameToUpdate -DisplayName 'Updated Display Name' -Tag @{"env"="test"} -AttributeCriticality 1
        $serviceGroup | Should -Not -BeNullOrEmpty
        $serviceGroup.DisplayName | Should -Be 'Updated Display Name'
        $serviceGroup.AttributeCriticality | Should -Be 1
        $serviceGroup.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateViaIdentityExpanded' {
        $sgObj = Get-AzServiceGroup -Name $env.ServiceGroupNameToUpdate
        $serviceGroup = $sgObj | Update-AzServiceGroup -DisplayName 'Updated Via Identity' -AttributeCriticality 2
        $serviceGroup | Should -Not -BeNullOrEmpty
        $serviceGroup.DisplayName | Should -Be 'Updated Via Identity'
        $serviceGroup.AttributeCriticality | Should -Be 2
    }

    It 'UpdateViaJsonString' {
        $jsonString = '{"properties":{"displayName":"Updated Via JSON","attributes":{"criticality":3}}}'
        $serviceGroup = Update-AzServiceGroup -Name $env.ServiceGroupNameToUpdate -JsonString $jsonString
        $serviceGroup | Should -Not -BeNullOrEmpty
        $serviceGroup.DisplayName | Should -Be 'Updated Via JSON'
        $serviceGroup.AttributeCriticality | Should -Be 3
    }

    It 'UpdateViaJsonFilePath' {
        $jsonContent = '{"properties":{"displayName":"Updated Via JSON File","attributes":{"criticality":4}}}'
        $jsonFilePath = Join-Path -Path $PSScriptRoot -ChildPath 'Update-AzServiceGroup-Params.json'
        $jsonContent | Out-File -FilePath $jsonFilePath -Encoding utf8
        try {
            $serviceGroup = Update-AzServiceGroup -Name $env.ServiceGroupNameToUpdate -JsonFilePath $jsonFilePath
            $serviceGroup | Should -Not -BeNullOrEmpty
            $serviceGroup.DisplayName | Should -Be 'Updated Via JSON File'
            $serviceGroup.AttributeCriticality | Should -Be 4
        } finally {
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        }
    }
}
