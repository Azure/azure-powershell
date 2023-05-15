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

Describe 'New-AzCdnEndpoint'  {
    It 'CreateExpanded' {
            $endpointName = 'e-' + (RandomString -allChars $false -len 6);
            $origin = @{
                Name = "origin1"
                HostName = "host1.hello.com"
            };
            $location = "westus"
            Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

            $endpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location -Origin $origin
            
            $endpoint.Name | Should -Be $endpointName
            $endpoint.Location | Should -Be $location
            $endpoint.Origin.Name | Should -Be $origin.Name
            $endpoint.Origin.HostName | Should -Be $origin.HostName
    }
}
