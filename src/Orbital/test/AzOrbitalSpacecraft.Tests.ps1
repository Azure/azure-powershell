if(($null -eq $TestName) -or ($TestName -contains 'AzOrbitalSpacecraft'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzOrbitalSpacecraft.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzOrbitalSpacecraft' {
    It 'List' {
        {
            $config = Get-AzOrbitalSpacecraft
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzOrbitalSpacecraft -ResourceGroupName $env.resourceGroup -Name $env.spacecraftName
            $config.Name | Should -Be $env.spacecraftName
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzOrbitalSpacecraft -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzOrbitalSpacecraft -ResourceGroupName $env.resourceGroup -Name $env.spacecraftName -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.spacecraftName
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $spacecraftObject = Get-AzOrbitalSpacecraft -ResourceGroupName $env.resourceGroup -Name $env.spacecraftName
            $config = Update-AzOrbitalSpacecraft -InputObject $spacecraftObject -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.spacecraftName
        } | Should -Not -Throw
    }
}
