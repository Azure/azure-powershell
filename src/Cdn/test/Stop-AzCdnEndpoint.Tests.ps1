if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzCdnEndpoint'  {
    BeforeAll {
        $endpointName = 'e-ndpstest100'
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        };
        $location = "westus"
        Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

        New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location -Origin $origin
    }
    It 'Stop' {
        Stop-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $res = Get-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName 
        
        $res.ResourceState | Should -Be "Stopped"
    }

    It 'StopViaIdentity' {
        $endpoint1 =  Start-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName 
        Write-Host -ForegroundColor Green "Endpoint status: $($endpoint1.ResourceState)" 
        $resObject = Get-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName
        $res = Stop-AzCdnEndpoint -InputObject $resObject

        $res.ResourceState | Should -Be "Stopped"
    }
}
