if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAlbFrontend'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAlbFrontend.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAlbFrontend' {
    It 'Delete' {
        {
            New-AzAlb -Name $env.albName -ResourceGroupName $env.resourceGroup -Location $env.Region
            Remove-AzAlbFrontend -Name $env.albFrontendName -AlbName $env.albName -ResourceGroupName $env.resourceGroup
            $albFe = Get-AzAlbFrontend -Name $env.albFrontendName -AlbName $env.albName -ResourceGroupName $env.resourceGroup
            $albFe.name | Should -Not -Contain $env.albName
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
