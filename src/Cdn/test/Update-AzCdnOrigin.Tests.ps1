if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnOrigin'  {
    BeforeAll {
        $originName = "origin1"
        $originHostName = "host1.hello.com"
        $origin = @{
            Name = $originName
            HostName = $originHostName
        };
    }

    It 'UpdateExpanded' {
        $origin = Get-AzCdnOrigin -Name $originName -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $origin.Name | Should -Be $originName
        $origin.HostName | Should -Be $originHostName
        $origin.HttpsPort | Should -Be $null

        $origin = Update-AzCdnOrigin -Name $originName -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HostName "www.azure.com" -HttpPort 456 -HttpsPort 789

        $origin.Name | Should -Be $originName
        $origin.HostName | Should -Be "www.azure.com"
        $origin.HttpPort | Should -Be 456
        $origin.HttpsPort | Should -Be 789
    }

    It 'UpdateViaIdentityExpanded' {
        $PSDefaultParameterValues['Disabled'] = $true
        $origin = Get-AzCdnOrigin -Name $originName -EndpointName $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $origin.Name | Should -Be $originName
        $origin.HostName | Should -Be "www.azure.com"
        $origin.HttpPort | Should -Be 456
        $origin.HttpsPort | Should -Be 789

        $origin = $origin | Update-AzCdnOrigin -HostName "www.azure.com" -HttpPort 123 -HttpsPort 666

        $origin.Name | Should -Be $originName
        $origin.HostName | Should -Be "www.azure.com"
        $origin.HttpPort | Should -Be 123
        $origin.HttpsPort | Should -Be 666
    }
}
