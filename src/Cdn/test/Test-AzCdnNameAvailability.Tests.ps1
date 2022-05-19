if(($null -eq $TestName) -or ($TestName -contains 'Test-AzCdnNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzCdnNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzCdnNameAvailability' -Tag 'LiveOnly' {
    It 'CheckExpanded' {
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
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                $resourceType = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ResourceType]::MicrosoftCdnProfilesEndpoints
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
                
                $nameAvailability = Test-AzCdnNameAvailability -Name $endpointName -Type $resourceType
                $nameAvailability.NameAvailable | Should -BeTrue

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin
                $nameAvailability = Test-AzCdnNameAvailability -Name $endpointName -Type $resourceType
                $nameAvailability.NameAvailable | Should -BeFalse
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'CheckExpanded1' {
        { 
            $subId = $env.SubscriptionId
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
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                $resourceType = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ResourceType]::MicrosoftCdnProfilesEndpoints
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
                
                $nameAvailability = Test-AzCdnNameAvailability -Name $endpointName -Type $resourceType -SubscriptionId $subId
                $nameAvailability.NameAvailable | Should -BeTrue

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin
                $nameAvailability = Test-AzCdnNameAvailability -Name $endpointName -Type $resourceType -SubscriptionId $subId
                $nameAvailability.NameAvailable | Should -BeFalse
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
