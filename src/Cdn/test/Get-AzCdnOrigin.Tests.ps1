if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnOrigin'  {
    It 'List' {
        $origins = Get-AzCdnOrigin -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
        
        $origins.Count | Should -Be 1
    }

    It 'Get' {
        $originName = "origin1"
        $originHostName = "host1.hello.com"
        
        $origin = Get-AzCdnOrigin -Name $originName -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
        
        $origin.Name | Should -Be $originName
        $origin.HostName | Should -Be $originHostName
        $origin.HttpsPort | Should -Be $null
    }

    It 'GetViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $originName = "origin1"
        $originHostName = "host1.hello.com"
        
        $origin = Get-AzCdnOrigin -Name $originName -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName | Get-AzCdnOrigin
        
        $origin.Name | Should -Be $originName
        $origin.HostName | Should -Be $originHostName
        $origin.HttpsPort | Should -Be $null
    }
}
