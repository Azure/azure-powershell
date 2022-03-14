if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnEndpoint' {
    It 'UpdateExpanded'  {
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

            $endpoint = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName
            $endpoint.EnabledState | Should -Be "Enabled"

            Update-AzFrontdoorCdnEndpoint -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName -EnabledState "Disabled"
            $updatedEndpoint = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName
            $updatedEndpoint.EnabledState | Should -Be "Disabled"
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }

    It 'UpdateViaIdentityExpanded' {
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

            Get-AzFrontdoorCdnEndpoint -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName | Update-AzFrontdoorCdnEndpoint -EnabledState "Disabled"
            $updatedEndpoint = Get-AzFrontdoorCdnEndpoint -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName
            $updatedEndpoint.EnabledState | Should -Be "Disabled"
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }
}
