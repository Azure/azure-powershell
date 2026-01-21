if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDisconnectedOperationsArtifactDownloadUri'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDisconnectedOperationsArtifactDownloadUri.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDisconnectedOperationsArtifactDownloadUri' {
    It 'List' {
        $result = Get-AzDisconnectedOperationsArtifactDownloadUri -ArtifactName $env.ArtifactName -ImageName $env.ImageName -Name $env.Name -ResourceGroupName $env.ResourceGroupName 
        # Assert that result is not null or empty
        $result | Should -Not -BeNullOrEmpty
        # Assert that the download URI is a valid URI
        $uri = [URI]$result.DownloadLink
        $uri | Should -Not -BeNullOrEmpty
        $uri.IsAbsoluteUri | Should -Be $true

        $result.LinkExpiry | Should -Not -BeNullOrEmpty
    }
}
