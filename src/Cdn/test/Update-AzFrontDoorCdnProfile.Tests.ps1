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

Describe 'Update-AzFrontDoorCdnProfile'  {
    BeforeAll {
        $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
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
        Update-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Tag $tags
        $updatedProfile = Get-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $updatedProfile.Tag["Tag1"] | Should -Be "11"
        $updatedProfile.Tag["Tag2"] | Should -Be "22"
    }

    It 'UpdateViaIdentityExpanded' {
        $PSDefaultParameterValues['Disabled'] = $true
        $tags = @{
            Tag1 = 33
            Tag2  = 44
        }
        Get-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName | Update-AzFrontDoorCdnProfile -Tag $tags
        $updatedProfile = Get-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $updatedProfile.Tag["Tag1"] | Should -Be "33"
        $updatedProfile.Tag["Tag2"] | Should -Be "44"
    }
}
