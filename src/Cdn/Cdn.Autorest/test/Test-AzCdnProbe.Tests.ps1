if(($null -eq $TestName) -or ($TestName -contains 'Test-AzCdnProbe'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzCdnProbe.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzCdnProbe'  {
    It 'ValidateExpanded' {
        { 
            $probeUrl = "https://azurecdn-files.azureedge.net/dsa-test/probe-v.txt"	
            $validateProbeUrlResult = Test-AzCdnProbe -ProbeUrl $probeUrl
        
            $validateProbeUrlResult.IsValid | Should -BeTrue
        
            $probeUrl = "https://www.notexist.com/notexist/notexist.txt"
            $validateProbeUrlResult = Test-AzCdnProbe -ProbeUrl $probeUrl    

            $validateProbeUrlResult.IsValid | Should -BeFalse
        } | Should -Not -Throw
    }
}
