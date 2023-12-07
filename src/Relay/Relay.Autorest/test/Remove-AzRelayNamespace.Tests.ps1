if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRelayNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRelayNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzRelayNamespace' {
    It 'Delete' {
        { 
            Remove-AzRelayNamespace -ResourceGroupName $env.resourceGroupName -Name $env.namespaceName02
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $namespace = Get-AzRelayNamespace -ResourceGroupName $env.resourceGroupName -Name $env.namespaceName03
            Remove-AzRelayNamespace -InputObject $namespace
        } | Should -Not -Throw
    }
}
