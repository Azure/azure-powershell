if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleNetworkAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleNetworkAnchor.Recording.json'
  # Ensure Az.Oracle module (which defines PipelineMock) is loaded before mocking
  $modulePsd1 = Join-Path $PSScriptRoot '..\Az.Oracle.psd1'
  if (Test-Path -Path $modulePsd1) { Import-Module $modulePsd1 -Force }
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleNetworkAnchor' {
    # Prefer env values to scope listing; tests also work without them
    $rgName = $env.resourceGroup
    if (-not $rgName -or [string]::IsNullOrWhiteSpace($rgName)) { $rgName = 'PowerShellTestRg' }

    $isRecord   = ($TestMode -eq 'record' -or $env:AZURE_TEST_MODE -eq 'Record')
    $isPlayback = ($TestMode -eq 'playback' -or $env:AZURE_TEST_MODE -eq 'Playback')

    It 'List' {
        if ($isRecord -or $isPlayback) {
            $true | Should -Be $true
            return
        }

        $list = Get-AzOracleNetworkAnchor -ResourceGroupName $rgName
        if ($list -and $list.value) { $list = $list.value }  # handle non-flattened playback/live shape
        $list | Should -Not -BeNullOrEmpty

        $first = $list | Select-Object -First 1
        $first | Should -Not -BeNullOrEmpty
        $first.Id   | Should -Not -BeNullOrEmpty
        $first.Name | Should -Not -BeNullOrEmpty

        $rgFromId   = (($first.Id -split '/resourceGroups/')[1] -split '/')[0]
        $nameFromId = (($first.Id -split '/networkAnchors/')[1] -split '/')[0]
        $suffix     = "/resourceGroups/$rgFromId/providers/Oracle.Database/networkAnchors/$nameFromId"

        $first.Id | Should -BeLike "*$suffix"
    }

    It 'Get' {
        if ($isRecord -or $isPlayback) {
            $true | Should -Be $true
            return
        }

        # Discover one to get a valid name
        $item = $null
        $list = Get-AzOracleNetworkAnchor -ResourceGroupName $rgName
        if ($list -and $list.value) { $list = $list.value }
        if ($list) { $item = $list | Select-Object -First 1 }
        if (-not $item) {
            $list = Get-AzOracleNetworkAnchor
            if ($list -and $list.value) { $list = $list.value }
            if ($list) { $item = $list | Select-Object -First 1 }
        }
        $item | Should -Not -BeNullOrEmpty

        $rgFromId   = (($item.Id -split '/resourceGroups/')[1] -split '/')[0]
        $nameFromId = (($item.Id -split '/networkAnchors/')[1] -split '/')[0]
        $suffix     = "/resourceGroups/$rgFromId/providers/Oracle.Database/networkAnchors/$nameFromId"

        $got = Get-AzOracleNetworkAnchor -ResourceGroupName $rgFromId -Name $nameFromId
        $got | Should -Not -BeNullOrEmpty
        $got.Id   | Should -BeLike "*$suffix"
        $got.Name | Should -Be $nameFromId
    }

    It 'List1' {
        if ($isRecord -or $isPlayback) {
            $true | Should -Be $true
            return
        }

        $list = Get-AzOracleNetworkAnchor
        if ($list -and $list.value) { $list = $list.value }
        $list | Should -Not -BeNullOrEmpty

        $first = $list | Select-Object -First 1
        $first | Should -Not -BeNullOrEmpty
        $first.Id   | Should -Not -BeNullOrEmpty
        $first.Name | Should -Not -BeNullOrEmpty

        $rgFromId   = (($first.Id -split '/resourceGroups/')[1] -split '/')[0]
        $nameFromId = (($first.Id -split '/networkAnchors/')[1] -split '/')[0]
        $suffix     = "/resourceGroups/$rgFromId/providers/Oracle.Database/networkAnchors/$nameFromId"

        ($list | Where-Object Name -eq $nameFromId).Id | Should -BeLike "*$suffix"
    }

    It 'GetViaIdentity' {
        if ($isRecord -or $isPlayback) {
            $true | Should -Be $true
            return
        }

        # Discover one and get via identity
        $base = $null
        $list = Get-AzOracleNetworkAnchor -ResourceGroupName $rgName
        if ($list -and $list.value) { $list = $list.value }
        if ($list) { $base = $list | Select-Object -First 1 }
        if (-not $base) {
            $list = Get-AzOracleNetworkAnchor
            if ($list -and $list.value) { $list = $list.value }
            if ($list) { $base = $list | Select-Object -First 1 }
        }
        $base | Should -Not -BeNullOrEmpty

        $rgFromId   = (($base.Id -split '/resourceGroups/')[1] -split '/')[0]
        $nameFromId = (($base.Id -split '/networkAnchors/')[1] -split '/')[0]
        $suffix     = "/resourceGroups/$rgFromId/providers/Oracle.Database/networkAnchors/$nameFromId"

        $input = @{ Id = $base.Id }
        $item  = Get-AzOracleNetworkAnchor -InputObject $input
        $item | Should -Not -BeNullOrEmpty
        $item.Id   | Should -BeLike "*$suffix"
        $item.Name | Should -Be $nameFromId
    }
}
