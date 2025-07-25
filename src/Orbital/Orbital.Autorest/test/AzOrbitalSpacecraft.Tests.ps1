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
    It 'CreateExpanded' {
        {
            $linkObject = New-AzOrbitalSpacecraftLinkObject -BandwidthMHz 15 -CenterFrequencyMHz 8160 -Direction 'Downlink' -Name spacecraftlink -Polarization 'RHCP'
            $config = New-AzOrbitalSpacecraft -Name $env.spacecraftName -ResourceGroupName $env.resourceGroup -Location $env.location -Link $linkObject -NoradId 27424 -TitleLine "AQUA" -TleLine1 "1 27424U 02022A   21259.45143715  .00000131  00000-0  39210-4 0  9998" -TleLine2 "2 27424  98.2138 199.4906 0001886  51.3958  60.0011 14.57112434 30322"
            $config.Name | Should -Be $env.spacecraftName
        } | Should -Not -Throw
    }
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
            $config = Update-AzOrbitalSpacecraft -InputObject $spacecraftObject -Tag @{"456"="def"}
            $config.Name | Should -Be $env.spacecraftName
        } | Should -Not -Throw
    }
    It 'Delete' {
        Remove-AzOrbitalSpacecraft -ResourceGroupName $env.resourceGroup -Name $env.spacecraftName
    }
}
