if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAlbAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAlbAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAlbAssociation' {
    It 'List' {
        {
            (Get-AzAlbAssociation -AlbName $env.albName -ResourceGroupName $env.resourceGroup).Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $alb = Get-AzAlbAssociation -Name $env.albAssociationName -AlbName $env.albName -ResourceGroupName $env.resourceGroup
            $alb.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
