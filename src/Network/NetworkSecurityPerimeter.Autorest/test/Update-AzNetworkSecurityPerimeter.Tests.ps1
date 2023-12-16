if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkSecurityPerimeter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkSecurityPerimeter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkSecurityPerimeter' {
    It 'PatchExpanded' {
        {
            $nspName = $env.randomStr + '-' + $env.nsp1
            New-AzNetworkSecurityPerimeter -ResourceGroupName $env.rgname -Name $nspName -Location $env.location
        } | Should -Not -Throw
    }

    It 'PatchViaIdentityExpanded' {
        {
           $nspName = $env.randomStr + '-' + $env.nsp1
           $GETObj = Get-AzNetworkSecurityPerimeter -Name $nspName -ResourceGroupName $env.rgname
           $UpdateObj = Update-AzNetworkSecurityPerimeter -InputObject $GETObj
        } | Should -Not -Throw
    }
}
