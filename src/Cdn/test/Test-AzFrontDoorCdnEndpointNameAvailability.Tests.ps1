if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFrontDoorCdnEndpointNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFrontDoorCdnEndpointNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFrontDoorCdnEndpointNameAvailability' -Tag 'LiveOnly' {
    It 'CheckExpanded' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

                $profileSku = "Standard_AzureFrontDoor";
                New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'end-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"

                $resourceType = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ResourceType]::MicrosoftCdnProfilesAfdEndpoints
                
                $nameAvailability = Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName $ResourceGroupName -Name $endpointName -Type $resourceType
                $nameAvailability.NameAvailable | Should -BeTrue
                New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $nameAvailability = Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName $ResourceGroupName -Name $endpointName -Type $resourceType
                $nameAvailability.NameAvailable | Should -BeFalse
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'Check' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

                $profileSku = "Standard_AzureFrontDoor";
                New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'end-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"

                $resourceType = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ResourceType]::MicrosoftCdnProfilesAfdEndpoints
                $checkNameAvailabilityInput = @{
                    Name = $endpointName
                    Type = $resourceType
                }
                
                $nameAvailability = Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName $ResourceGroupName -CheckEndpointNameAvailabilityInput $checkNameAvailabilityInput
                $nameAvailability.NameAvailable | Should -BeTrue
                New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $nameAvailability = Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName $ResourceGroupName -CheckEndpointNameAvailabilityInput $checkNameAvailabilityInput
                $nameAvailability.NameAvailable | Should -BeFalse
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
