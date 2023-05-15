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

Describe 'Update-AzCdnProfile'  {
    It 'UpdateExpanded' {
        $tags = @{
            Tag1 = 11
            Tag2  = 22
        }
        Update-AzCdnProfile -Name $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -Tag $tags
        $updatedProfile = Get-AzCdnProfile -Name $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        
        $updatedProfile.Tag["Tag1"] | Should -Be "11"
        $updatedProfile.Tag["Tag2"] | Should -Be "22"
    }

    It 'UpdateViaIdentityExpanded' {
            $PSDefaultParameterValues['Disabled'] = $true
            $tags = @{
                Tag1 = 33
                Tag2  = 44
            }
            Get-AzCdnProfile -Name $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Update-AzCdnProfile -Tag $tags
            $updatedProfile = Get-AzCdnProfile -Name $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
            
            $updatedProfile.Tag["Tag1"] | Should -Be "33"
            $updatedProfile.Tag["Tag2"] | Should -Be "44"
    }
}
