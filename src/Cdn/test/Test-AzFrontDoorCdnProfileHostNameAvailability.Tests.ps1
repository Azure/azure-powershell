if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFrontDoorCdnProfileHostNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFrontDoorCdnProfileHostNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFrontDoorCdnProfileHostNameAvailability' {
    It 'CheckExpanded' {
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        try
        {
            Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
            New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

            $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

            $profileSku = "Standard_AzureFrontDoor";
            New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
            $hostName = "hello1.dev.cdn.azure.cn";
            $result = Test-AzFrontDoorCdnProfileHostNameAvailability -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -HostName $hostName
            $result.NameAvailable | Should -Be $true
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }

    It 'Check' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentityExpanded' {
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
            $hostName = "hello1.dev.cdn.azure.cn";
            $result = Get-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName | `
            Test-AzFrontDoorCdnProfileHostNameAvailability -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -HostName $hostName
            $result.NameAvailable | Should -Be $true
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }

    It 'CheckViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
