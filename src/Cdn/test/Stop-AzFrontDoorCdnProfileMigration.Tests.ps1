if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzFrontDoorCdnProfileMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzFrontDoorCdnProfileMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzFrontDoorCdnProfileMigration'  {
    It 'Delete' {
        $subId = $env.SubscriptionId
        $Name = 'fdp-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use frontDoorName : $($Name)"

        $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor";
        New-AzFrontDoorCdnProfile -SubscriptionId $subId -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        Stop-AzFrontDoorCdnProfileMigration -SubscriptionId $subId -ResourceGroupName $env.ResourceGroupName -ProfileName $frontDoorCdnProfileName
    }
}