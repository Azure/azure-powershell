if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleResourceAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleResourceAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleResourceAnchor' {
    $rgName         = 'PowerShellTestRgMihr'
    $raName         = 'Create'  # avoid Pester's $Name
    $resourceSuffix = "/resourceGroups/$rgName/providers/Oracle.Database/resourceAnchors/$raName"

    It 'List' {
        $list = Get-AzOracleResourceAnchor -ResourceGroupName $rgName
        if ($list -and $list.value) { $list = $list.value }  # handle non-flattened playback
        $list | Should -Not -BeNullOrEmpty
        $target = ($list | Where-Object Name -eq $raName).Id
        $target | Should -Not -BeNullOrEmpty
        $target | Should -BeLike "*$resourceSuffix"
    }

    It 'Get' {
        $item = Get-AzOracleResourceAnchor -ResourceGroupName $rgName -Name $raName
        $item | Should -Not -BeNullOrEmpty
        $item.Id   | Should -BeLike "*$resourceSuffix"
        $item.Name | Should -Be $raName
    }

    It 'List1' {
        $list = Get-AzOracleResourceAnchor
        if ($list -and $list.value) { $list = $list.value }  # handle non-flattened playback
        $list | Should -Not -BeNullOrEmpty
        $target = ($list | Where-Object Name -eq $raName).Id
        $target | Should -Not -BeNullOrEmpty
        $target | Should -BeLike "*$resourceSuffix"
    }

    It 'GetViaIdentity' {
        $base  = Get-AzOracleResourceAnchor -ResourceGroupName $rgName -Name $raName
        $base  | Should -Not -BeNullOrEmpty
        $input = @{ Id = $base.Id }
        $item  = Get-AzOracleResourceAnchor -InputObject $input
        $item | Should -Not -BeNullOrEmpty
        $item.Id   | Should -BeLike "*$resourceSuffix"
        $item.Name | Should -Be $raName
    }
}
