if(($null -eq $TestName) -or ($TestName -contains 'Import-AzCdnEndpointContent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Import-AzCdnEndpointContent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Import-AzCdnEndpointContent' -Tag 'LiveOnly' {
    It 'LoadExpanded' {
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
                $contentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg") 

                # Load content on endpoint should succeed
                Import-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentPath $contentPath
                # Load content on non-existing endpoint should fail
                { Import-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentPath $contentPath } | Should -Throw
                # Load content on endpoint with invalid content paths should fail
                { Import-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentPath "/movies/*" } | Should -Throw
                # Load content on stopped endpoint should fail
                Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName 
                { Import-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentPath $contentPath } | Should -Throw
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'Load' {
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
                $contentPath = @{ ContentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg") }

                # Load content on endpoint should succeed
                Import-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentFilePath $contentPath
                # Load content on non-existing endpoint should fail
                { Import-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentFilePath $contentPath } | Should -Throw
                # Load content on endpoint with invalid content paths should fail
                { Import-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentFilePath @{ ContentPath = "/movies/*" } } | Should -Throw
                # Load content on stopped endpoint should fail
                Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName 
                { Import-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -ContentFilePath $contentPath } | Should -Throw
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'LoadViaIdentityExpanded' {
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
                $contentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg") 

                # Load content on endpoint should succeed
                $endpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
                $endpoint | Import-AzCdnEndpointContent -ContentPath $contentPath
                # Load content on endpoint with invalid content paths should fail
                { $endpoint | Import-AzCdnEndpointContent -ContentPath "/movies/*" } | Should -Throw
                # Load content on stopped endpoint should fail
                Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName 
                { $endpoint | Import-AzCdnEndpointContent -ContentPath $contentPath } | Should -Throw
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'LoadViaIdentity' {
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
                $contentPath = @{ ContentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg") }

                # Load content on endpoint should succeed
                $endpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName
                $endpoint | Import-AzCdnEndpointContent -ContentFilePath $contentPath
                # Load content on endpoint with invalid content paths should fail
                { $endpoint | Import-AzCdnEndpointContent -ContentFilePath @{ ContentPath = "/movies/*" } } | Should -Throw
                # Load content on stopped endpoint should fail
                Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName 
                { $endpoint | Import-AzCdnEndpointContent -ContentFilePath $contentPath } | Should -Throw
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
