if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnEndpoint' {
    BeforeAll {
        $script:endpointName = 'e-clipstest310-new'
        $script:location = "westus"
        $script:origin = @{ Name = "origin1"; HostName = "host1.hello.com" }
    }

    AfterAll {
        Remove-AzCdnEndpoint -Name $script:endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $endpoint = New-AzCdnEndpoint -Name $script:endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $script:location -Origin $script:origin
        $endpoint.Name | Should -Be $script:endpointName
        $endpoint.Location | Should -Be $script:location
        $endpoint.Origin.Name | Should -Be $script:origin.Name
        $endpoint.Origin.HostName | Should -Be $script:origin.HostName
    }
}