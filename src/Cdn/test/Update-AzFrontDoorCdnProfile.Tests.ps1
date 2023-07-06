if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnProfile' {
    BeforeAll {
        $subId = $env.SubscriptionId
        $frontDoorCdnProfileName = 'fdp-pstest050'
        Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

        $profileSku = "Standard_AzureFrontDoor"
        $tags = @{
            Tag1 = 1
            Tag2  = 2
        }
        New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global -Tag $tags
    }

    It 'UpdateExpanded' {
        $tags = @{
            Tag1 = 11
            Tag2  = 22
        }

        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnProfile"
        $profileObject = Update-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Tag $tags -OriginResponseTimeoutSecond 30

        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnProfile"
        $updatedProfile = Get-AzFrontDoorCdnProfile -InputObject $profileObject
        
        $updatedProfile.Tag["Tag1"] | Should -Be "11"
        $updatedProfile.Tag["Tag2"] | Should -Be "22"
        $updatedProfile.OriginResponseTimeoutSecond | Should -Be "30"
    }

    It 'UpdateExpanded' {
        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnProfile: Enable managed identity"
        $profileObject = Update-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -IdentityType SystemAssigned

        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnProfile"
        $updatedProfile = Get-AzFrontDoorCdnProfile -InputObject $profileObject

        $updatedProfile.IdentityType | Should -Be "SystemAssigned"
    }

    It 'UpdateViaIdentityExpanded' {
        $tags = @{
            Tag1 = 33
            Tag2  = 44
        }

        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnProfile"
        $profileObject = Get-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName

        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnProfile"
        Update-AzFrontDoorCdnProfile -Tag $tags -OriginResponseTimeoutSecond 30 -InputObject $profileObject

        Write-Host -ForegroundColor Green "get AzFrontDoorCdnProfile"
        $updatedProfile = Get-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $updatedProfile.Tag["Tag1"] | Should -Be "33"
        $updatedProfile.Tag["Tag2"] | Should -Be "44"
        $updatedProfile.OriginResponseTimeoutSecond | Should -Be "30"
    }
}