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

Describe 'Update-AzCdnOrigin' -Tag 'LiveOnly' {
    It 'UpdateExpanded' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $originName = "origin1"
                $originHostName = "host1.hello.com"
                $originHttpPort = 80
                $origin = @{
                    Name = $originName
                    HostName = $originHostName
                    HttpPort = $originHttpPort
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin
                $origin = Get-AzCdnOrigin -Name $originName -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
                
                $origin.Name | Should -Be $originName
                $origin.HostName | Should -Be $originHostName
                $origin.HttpPort | Should -Be $originHttpPort
                $origin.HttpsPort | Should -Be $null

                $origin = Update-AzCdnOrigin -Name $originName -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName `
                    -HostName "www.azure.com" -HttpPort 456 -HttpsPort 789

                $origin.Name | Should -Be $originName
                $origin.HostName | Should -Be "www.azure.com"
                $origin.HttpPort | Should -Be 456
                $origin.HttpsPort | Should -Be 789
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $originName = "origin1"
                $originHostName = "host1.hello.com"
                $originHttpPort = 80
                $origin = @{
                    Name = $originName
                    HostName = $originHostName
                    HttpPort = $originHttpPort
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin
                $origin = Get-AzCdnOrigin -Name $originName -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
                
                $origin.Name | Should -Be $originName
                $origin.HostName | Should -Be $originHostName
                $origin.HttpPort | Should -Be $originHttpPort
                $origin.HttpsPort | Should -Be $null

                $origin = $origin | Update-AzCdnOrigin -HostName "www.azure.com" -HttpPort 456 -HttpsPort 789

                $origin.Name | Should -Be $originName
                $origin.HostName | Should -Be "www.azure.com"
                $origin.HttpPort | Should -Be 456
                $origin.HttpsPort | Should -Be 789
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
