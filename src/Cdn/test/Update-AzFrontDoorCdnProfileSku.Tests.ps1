if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnProfileSku'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnProfileSku.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnProfileSku' -Tag 'LiveOnly' {
    It 'Upgrade' {
        $frontDoorCdnProfileName = 'fdp-pstest060'
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor";
        New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $updatedProfile = Update-AzFrontDoorCdnProfileSku -ProfileName $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -ProfileUpgradeParameter @{}
        $updatedProfile.SkuName | Should -Be "Premium_AzureFrontDoor"
    }
}
