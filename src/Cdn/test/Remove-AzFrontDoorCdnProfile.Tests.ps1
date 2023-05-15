if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorCdnProfile'  {
    It 'Delete' {
        $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor"
        New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        Remove-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'DeleteViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor"
        New-AzFrontDoorCdnProfile -SubscriptionId $env.SubscriptionId -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $frontDoorCdnProfileName | Remove-AzFrontDoorCdnProfile
    }
}
