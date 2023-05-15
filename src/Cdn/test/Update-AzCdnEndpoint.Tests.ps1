if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnEndpoint'  {
    It 'UpdateExpanded' {
        $tags = @{
            Tag1 = 11
            Tag2 = 22
        }
        Update-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -Tag $tags
        $updatedEndpoint = Get-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName

        $updatedEndpoint.Tag["Tag1"] | Should -Be "11"
        $updatedEndpoint.Tag["Tag2"] | Should -Be "22"
    }

    It 'UpdateViaIdentityExpanded' {
        $PSDefaultParameterValues['Disabled'] = $true
        $tags = @{
            Tag1 = 33
            Tag2 = 44
        }
        Get-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName | Update-AzCdnEndpoint -Tag $tags
        $updatedEndpoint = Get-AzCdnEndpoint -Name $env.ClassicEndpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName

        $updatedEndpoint.Tag["Tag1"] | Should -Be "33"
        $updatedEndpoint.Tag["Tag2"] | Should -Be "44"
    }
}
