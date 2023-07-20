if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAlb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAlb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAlb' {
    It 'Delete' {
        { 
            New-AzAlb -Name $env.albName -ResourceGroupName $env.resourceGroup -Location $env.Region
            Remove-AzAlb -Name $env.albName -ResourceGroupName $env.resourceGroup
            $alb = Get-AzAlb -Name $env.albName -ResourceGroupName $env.resourceGroup
            $alb.name | Should -Not -Contain $env.albName
         } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
