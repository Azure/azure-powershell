if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnProfile' {
    It 'CreateExpanded' {
        $profileSku = "Standard_AzureFrontDoor"
        $frontDoorCdnProfileName = 'fdp-pstest010'

        # New - with LogScrubbing (covers both create and LogScrubbing feature)
        Write-Host -ForegroundColor Green "New AzFrontDoorCdnProfile: $($frontDoorCdnProfileName)"
        $rule1 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -SelectorMatchOperator EqualsAny -State Enabled
        $rule2 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable QueryStringArgNames -SelectorMatchOperator EqualsAny -State Enabled
        $frontDoorCdnProfile = New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global -LogScrubbingRule @($rule1, $rule2) -LogScrubbingState Enabled
        $frontDoorCdnProfile.Name | Should -Be $frontDoorCdnProfileName
        $frontDoorCdnProfile.SkuName | Should -Be $profileSku
        $frontDoorCdnProfile.Location | Should -Be "Global"
        $frontDoorCdnProfile.LogScrubbingState | Should -Be "Enabled"
        $frontDoorCdnProfile.LogScrubbingRule.Count | Should -Be 2

        # Get - List
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnProfile - List"
        $frontDoorCdnProfiles = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName
        $frontDoorCdnProfiles.Count | Should -BeGreaterOrEqual 1

        # Get - by name
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnProfile - by name"
        $getProfile = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $frontDoorCdnProfileName
        $getProfile.Name | Should -Be $frontDoorCdnProfileName

        # Get - ViaIdentity
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnProfile - ViaIdentity"
        $getProfile2 = Get-AzFrontDoorCdnProfile -InputObject $getProfile
        $getProfile2.Name | Should -Be $frontDoorCdnProfileName

        # Update - Tags + Identity + LogScrubbing + ViaIdentity
        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnProfile"
        $rule3 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -SelectorMatchOperator EqualsAny -State Enabled
        Update-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Tag @{ Tag1 = 11 } -OriginResponseTimeoutSecond 30 -IdentityType SystemAssigned -LogScrubbingRule @($rule3) -LogScrubbingState Enabled
        $updatedProfile = Get-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updatedProfile.Tag["Tag1"] | Should -Be "11"
        $updatedProfile.OriginResponseTimeoutSecond | Should -Be "30"
        $updatedProfile.IdentityType | Should -Be "SystemAssigned"
        $updatedProfile.LogScrubbingRule.Count | Should -Be 1

        # Update - ViaIdentity
        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnProfile - ViaIdentity"
        Update-AzFrontDoorCdnProfile -Tag @{ Tag1 = 33 } -OriginResponseTimeoutSecond 60 -InputObject $updatedProfile
        $updatedProfile2 = Get-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updatedProfile2.Tag["Tag1"] | Should -Be "33"
        $updatedProfile2.OriginResponseTimeoutSecond | Should -Be "60"

        # Remove
        Write-Host -ForegroundColor Green "Remove AzFrontDoorCdnProfile: $($frontDoorCdnProfileName)"
        $res = Remove-AzFrontDoorCdnProfile -Name $frontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -PassThru
        $res | Should -Be "True"
    }
}
