if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzSpringTestEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzSpringTestEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzSpringTestEndpoint' {
    It 'Enable' -skip {
        { Enable-AzSpringTestEndpoint -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01 } | Should -Not -Throw
    }

    It 'EnableViaIdentity' -skip { 
        {
            $spring = Get-AzSpringService -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Enable-AzSpringTestEndpoint -InputObject $spring
        } | Should -Not -Throw
    } 
}
