if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFrontDoorCdnEndpointCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFrontDoorCdnEndpointCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFrontDoorCdnEndpointCustomDomain' -Tag 'LiveOnly' {
    It 'ValidateExpanded' {
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
                New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $hostName = "test.dev.cdn.azure.cn"
                Test-AzFrontDoorCdnEndpointCustomDomain -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -HostName $hostName
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
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
                New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $hostName = "test.dev.cdn.azure.cn"
                Get-AzFrontdoorCdnEndpoint -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName `
                | Test-AzFrontDoorCdnEndpointCustomDomain -HostName $hostName
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
