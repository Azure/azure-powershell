if(($null -eq $TestName) -or ($TestName -contains 'Clear-AzCdnEndpointContent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Clear-AzCdnEndpointContent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Clear-AzCdnEndpointContent' -Tag 'LiveOnly' {
    It 'PurgeExpanded' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location;

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"    

                $profileSku = "Standard_Verizon";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -IsHttpAllowed -IsHttpsAllowed `
                    -Location $location -Origin $origin -IsCompressionEnabled -ContentTypesToCompress "text/html","text/css" `
                    -OriginHostHeader "www.bing.com" -OriginPath "/photos" -QueryStringCachingBehavior "IgnoreQueryString"
                $contentPath = @("/movies/*","/pictures/pic1.jpg") 

                # Purge content on endpoint should succeed
                Clear-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentPath $contentPath
                # Purge content on non-existing endpoint should fail
                { Clear-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentPath $contentPath } | Should -Throw
                # Purge content on endpoint with invalid content paths should fail
                { Clear-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentPath "invalidpath!" } | Should -Throw
                # Purge content on stopped endpoint should fail
                Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName 
                { Clear-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentPath $contentPath } | Should -Throw
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'Purge' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location;

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)" 

                $profileSku = "Standard_Verizon";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -IsHttpAllowed -IsHttpsAllowed `
                    -Location $location -Origin $origin -IsCompressionEnabled -ContentTypesToCompress "text/html","text/css" `
                    -OriginHostHeader "www.bing.com" -OriginPath "/photos" -QueryStringCachingBehavior "IgnoreQueryString"
                $contentPath = @{ ContentPath = @("/movies/*","/pictures/pic1.jpg") }

                # Purge content on endpoint should succeed
                Clear-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentFilePath $contentPath
                # Purge content on non-existing endpoint should fail
                { Clear-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentFilePath $contentPath } | Should -Throw
                # Purge content on endpoint with invalid content paths should fail
                { Clear-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentFilePath @{ ContentPath = "invalidpath!" } } | Should -Throw
                # Purge content on stopped endpoint should fail
                Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName 
                { Clear-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentFilePath $contentPath } | Should -Throw
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'PurgeViaIdentityExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location;

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Verizon";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -IsHttpAllowed -IsHttpsAllowed `
                    -Location $location -Origin $origin -IsCompressionEnabled -ContentTypesToCompress "text/html","text/css" `
                    -OriginHostHeader "www.bing.com" -OriginPath "/photos" -QueryStringCachingBehavior "IgnoreQueryString"
                $contentPath = @("/movies/*","/pictures/pic1.jpg") 

                # Purge content on endpoint should succeed
                $endpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
                $endpoint | Clear-AzCdnEndpointContent -ContentPath $contentPath
                # Purge content on endpoint with invalid content paths should fail
                { $endpoint | Clear-AzCdnEndpointContent -ContentPath "invalidpath!" } | Should -Throw
                # Purge content on stopped endpoint should fail
                Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName 
                { $endpoint | Clear-AzCdnEndpointContent -ContentPath $contentPath } | Should -Throw
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'PurgeViaIdentity' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location;

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Verizon";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -IsHttpAllowed -IsHttpsAllowed `
                    -Location $location -Origin $origin -IsCompressionEnabled -ContentTypesToCompress "text/html","text/css" `
                    -OriginHostHeader "www.bing.com" -OriginPath "/photos" -QueryStringCachingBehavior "IgnoreQueryString"
                $contentPath = @{ ContentPath = @("/movies/*","/pictures/pic1.jpg") }

                # Purge content on endpoint should succeed
                $endpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
                $endpoint | Clear-AzCdnEndpointContent -ContentFilePath $contentPath
                # Purge content on endpoint with invalid content paths should fail
                { $endpoint | Clear-AzCdnEndpointContent -ContentFilePath @{ ContentPath = "invalidpath!" } } | Should -Throw
                # Purge content on stopped endpoint should fail
                Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName 
                { $endpoint | Clear-AzCdnEndpointContent -ContentFilePath $contentPath } | Should -Throw
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
