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
        $frontDoorCdnProfileName = 'fdp-pstest020'
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor"
        Write-Host -ForegroundColor Green "New frontDoorCdnProfileName"
        New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        Write-Host -ForegroundColor Green "Remove frontDoorCdnProfileName"
        $res = Remove-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $res | Should -BeNullOrEmpty
    }

    # Use "PassThru" parameter to test
    It 'Delete' {
        $frontDoorCdnProfileName = 'fdp-pstest020'
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor"
        Write-Host -ForegroundColor Green "New frontDoorCdnProfileName"
        New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        Write-Host -ForegroundColor Green "Remove frontDoorCdnProfileName"
        $res = Remove-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -PassThru
        $res | Should -Be "True"
    }

    It 'DeleteViaIdentity' {
        $frontDoorCdnProfileName = 'fdp-pstest021'
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor"
        Write-Host -ForegroundColor Green "New frontDoorCdnProfileName"
        New-AzFrontDoorCdnProfile -SubscriptionId $env.SubscriptionId -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        Write-Host -ForegroundColor Green "Get frontDoorCdnProfileName"
        $profileObject = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $frontDoorCdnProfileName

        Write-Host -ForegroundColor Green "Remove frontDoorCdnProfileName"
        Remove-AzFrontDoorCdnProfile -InputObject $profileObject
    }
}
