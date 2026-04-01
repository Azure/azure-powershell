if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnProfile' {
    It 'CreateExpanded' {
        $cdnProfileName = 'cdnpps01'
        $profileSku = "Standard_Microsoft"

        # New
        Write-Host -ForegroundColor Green "New AzCdnProfile: $cdnProfileName"
        $cdnProfile = New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        $cdnProfile.Name | Should -Be $cdnProfileName
        $cdnProfile.SkuName | Should -Be $profileSku
        $cdnProfile.Location | Should -Be "Global"

        # Get - List
        Write-Host -ForegroundColor Green "Get AzCdnProfile - List"
        $cdnProfiles = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName
        $cdnProfiles.Count | Should -BeGreaterOrEqual 1

        # Get - by name
        Write-Host -ForegroundColor Green "Get AzCdnProfile - by name"
        $getProfile = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $cdnProfileName
        $getProfile.Name | Should -Be $cdnProfileName
        $getProfile.SkuName | Should -Be $profileSku

        # Get - ViaIdentity
        Write-Host -ForegroundColor Green "Get AzCdnProfile - ViaIdentity"
        $getProfile2 = Get-AzCdnProfile -InputObject $getProfile
        $getProfile2.Name | Should -Be $cdnProfileName

        # Update
        Write-Host -ForegroundColor Green "Update AzCdnProfile"
        Update-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Tag @{ Tag1 = 11; Tag2 = 22 }
        $updatedProfile = Get-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updatedProfile.Tag["Tag1"] | Should -Be "11"
        $updatedProfile.Tag["Tag2"] | Should -Be "22"

        # Update - ViaIdentity
        Write-Host -ForegroundColor Green "Update AzCdnProfile - ViaIdentity"
        Update-AzCdnProfile -Tag @{ Tag1 = 33 } -InputObject $updatedProfile
        $updatedProfile2 = Get-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updatedProfile2.Tag["Tag1"] | Should -Be "33"

        # Remove
        Write-Host -ForegroundColor Green "Remove AzCdnProfile: $cdnProfileName"
        $res = Remove-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -PassThru
        $res | Should -Be "True"
    }
}
