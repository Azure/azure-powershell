if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConnectedExtensionMetadataV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedExtensionMetadataV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConnectedExtensionMetadataV2' {
    It 'List' {
        $all = @(Get-AzConnectedExtensionMetadataV2 -ExtensionType "MDE.Windows" -Location "eastus" -Publisher "Microsoft.Azure.AzureDefenderForServers")
        $all | Should -Not -BeNullOrEmpty
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
