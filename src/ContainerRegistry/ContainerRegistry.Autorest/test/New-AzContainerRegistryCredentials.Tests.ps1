if(($null -eq $TestName) -or ($TestName -contains 'New-AzContainerRegistryCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerRegistryCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzContainerRegistryCredentials' {
    It 'GenerateExpanded' {
        {   
            $token = Get-AzContainerRegistryToken -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.rstr4
            New-AzContainerRegistryCredentials -RegistryName  $env.rstr1 -ResourceGroupName $env.ResourceGroup -TokenId $token.Id
         } | Should -Not -Throw
    }

    It 'GenerateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
