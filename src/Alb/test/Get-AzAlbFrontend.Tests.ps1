if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAlbFrontend'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAlbFrontend.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAlbFrontend' {
    It 'List' {
        {
            (Get-AzAlbFrontend -AlbName $env.albName -ResourceGroupName $env.resourceGroup).Count | Should -BeGreaterThan 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $alb = Get-AzAlbFrontend -Name ($env.albFrontendName+"1") -AlbName $env.albName -ResourceGroupName $env.resourceGroup
            $alb.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
