if(($null -eq $TestName) -or ($TestName -contains 'Test-AzCdnEndpointCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzCdnEndpointCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzCdnEndpointCustomDomain'  {
    It 'ValidateExpanded' {
        { 
            $subId = "27cafca8-b9a4-4264-b399-45d0c9cca1ab"
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location -SubscriptionId $subId

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global -SubscriptionId $subId
                
                # Hard-coding host and endpoint names due to requirement for DNS CNAME
                $endpointName = 'e-20220418-sec26q'
                $customDomainHostName = 'e-20220418-sec26q.ps.cdne2e.azfdtest.xyz'
                $customDomainInvalidHostName = 'e-20220418-sec26w.ps.cdne2e.azfdtest.xyz'
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin -SubscriptionId $subId
                $validateResult = Test-AzCdnEndpointCustomDomain -EndpointName $endpointName -HostName $customDomainHostName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -SubscriptionId $subId

                $validateResult.CustomDomainValidated | Should -BeTrue

                $validateResult = Test-AzCdnEndpointCustomDomain -EndpointName $endpointName -HostName $customDomainInvalidHostName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -SubscriptionId $subId

                $validateResult.CustomDomainValidated | Should -BeFalse
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -SubscriptionId $subId -NoWait
            }
        } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $subId = "27cafca8-b9a4-4264-b399-45d0c9cca1ab"
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location -SubscriptionId $subId

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global -SubscriptionId $subId
                
                # Hard-coding host and endpoint names due to requirement for DNS CNAME
                $endpointName = 'e-20220418-ems6vw'
                $customDomainHostName = 'e-20220418-ems6vw.ps.cdne2e.azfdtest.xyz'
                $customDomainInvalidHostName = 'e-20220418-ems5vw.ps.cdne2e.azfdtest.xyz'
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                $endpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin -SubscriptionId $subId
                $validateResult = $endpoint | Test-AzCdnEndpointCustomDomain -HostName $customDomainHostName 

                $validateResult.CustomDomainValidated | Should -BeTrue

                $validateResult = $endpoint | Test-AzCdnEndpointCustomDomain -HostName $customDomainInvalidHostName 

                $validateResult.CustomDomainValidated | Should -BeFalse
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -SubscriptionId $subId -NoWait
            }
        } | Should -Not -Throw
    }
}
