if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzSpringTestEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzSpringTestEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Disable-AzSpringTestEndpoint' {
    It 'Disable' {
        { 
            Enable-AzSpringTestEndpoint -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Disable-AzSpringTestEndpoint -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        } | Should -Not -Throw
    }

    It 'DisableViaIdentity' {
        { 
            $spring = Get-AzSpring -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Enable-AzSpringTestEndpoint -InputObject $spring.Id
            Disable-AzSpringTestEndpoint -InputObject $spring.Id
        } | Should -Not -Throw
    }
}
