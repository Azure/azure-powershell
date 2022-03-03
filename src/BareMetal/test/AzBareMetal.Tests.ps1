if(($null -eq $TestName) -or ($TestName -contains 'AzBareMetal'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzBareMetal.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzBareMetal' {
    It 'List' {
        {
            $config = Get-AzBareMetal
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzBareMetal -Name $env.BareMetalName1 -ResourceGroupName $env.ResourceGroupName
            $config.Name | Should  -Be $env.BareMetalName1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzBareMetal -ResourceGroupName $env.ResourceGroupName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzBareMetal -Name $env.BareMetalName1 -ResourceGroupName $env.ResourceGroupName -Tag @{"env"="test"}
            $config.Name | Should  -Be $env.BareMetalName1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzBareMetal -Name $env.BareMetalName2 -ResourceGroupName $env.ResourceGroupName
            $config = Update-AzBareMetal -InputObject $config -Tag @{"env"="test"}
            $config.Name | Should  -Be $env.BareMetalName2
        } | Should -Not -Throw
    }
}
