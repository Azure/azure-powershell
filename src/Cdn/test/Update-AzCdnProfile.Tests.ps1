if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnProfile' {
    It 'UpdateExpanded' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                $tags = @{
                    Tag1 = 1
                    Tag2  = 2
                }
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global -Tag $tags
                $tags = @{
                    Tag1 = 11
                    Tag2  = 22
                }
                Update-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Tag $tags
                $updatedProfile = Get-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $ResourceGroupName
                
                $updatedProfile.Tag["Tag1"] | Should -Be "11"
                $updatedProfile.Tag["Tag2"] | Should -Be "22"
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                $tags = @{
                    Tag1 = 1
                    Tag2  = 2
                }
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global -Tag $tags
                $tags = @{
                    Tag1 = 11
                    Tag2  = 22
                }
                Get-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $ResourceGroupName | Update-AzCdnProfile -Tag $tags
                $updatedProfile = Get-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $ResourceGroupName
                
                $updatedProfile.Tag["Tag1"] | Should -Be "11"
                $updatedProfile.Tag["Tag2"] | Should -Be "22"
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
