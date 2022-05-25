if(($null -eq $TestName) -or ($TestName -contains 'Clear-AzFrontDoorCdnEndpointContent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Clear-AzFrontDoorCdnEndpointContent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Clear-AzFrontDoorCdnEndpointContent' -Tag 'LiveOnly' {
    It 'PurgeExpanded' {
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

            Clear-AzFrontDoorCdnEndpointContent -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
            -ContentPath "/a"
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }

    It 'Purge' {
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

            $afdPurgeParameters = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdPurgeParameters]::new()
            $afdPurgeParameters.ContentPath = @("/a")

            Clear-AzFrontDoorCdnEndpointContent -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
            -Content $afdPurgeParameters
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }

    It 'PurgeViaIdentityExpanded' {
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

            Get-AzFrontdoorCdnEndpoint -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName `
            | Clear-AzFrontDoorCdnEndpointContent -ContentPath "/a"
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }

    It 'PurgeViaIdentity' {
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

            $afdPurgeParameters = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdPurgeParameters]::new()
            $afdPurgeParameters.ContentPath = @("/a")

            Get-AzFrontdoorCdnEndpoint -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName `
            | Clear-AzFrontDoorCdnEndpointContent -Content $afdPurgeParameters
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }
}
