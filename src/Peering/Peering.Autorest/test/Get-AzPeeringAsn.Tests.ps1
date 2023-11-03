if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeeringAsn'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeeringAsn.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeeringAsn' {
    It 'List' {
        {
            $peeringAsns = Get-AzPeeringAsn
            $peeringAsns.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $asn = Get-AzPeeringAsn -Name ContosoEdgeTest
            $asn.Name | Should -Be "ContosoEdgeTest"
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $asn = Get-AzPeeringAsn -Name ContosoEdgeTest
            $asnIdentity = Get-AzPeeringAsn -InputObject $asn
            $asnIdentity.Name | Should -Be "ContosoEdgeTest"
        } | Should -Not -Throw
    }
}
