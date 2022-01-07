if(($null -eq $TestName) -or ($TestName -contains 'Test-AzWebPubSubNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzWebPubSubNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzWebPubSubNameAvailability' {
    It 'CheckExpanded with existing name, returns False' {
        $result = Test-AzWebPubSubNameAvailability -Name $env.Wps1 -Location $env.Location
        $result.NameAvailable | Should -Be $false
    }

    It 'CheckExpanded with non-existing name, returns false' {
        $name = $(RandomString -allChars $False -len 3)
        $result = Test-AzWebPubSubNameAvailability -Name $name -Location $env.Location
        $result.NameAvailable | Should -Be $true
    }
}
