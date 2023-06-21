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

Describe 'New-AzCdnProfile'  {
    It 'CreateExpanded' {
        $cdnProfileName = 'cdnpps01'
        Write-Host -ForegroundColor Green "Use CdnProfileName : $($cdnProfileName)"

        $profileSku = "Standard_Microsoft";
        $frontDoorCdnProfile = New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $frontDoorCdnProfile.Name | Should -Be $cdnProfileName
        $frontDoorCdnProfile.SkuName | Should -Be $profileSku
        $frontDoorCdnProfile.Location | Should -Be "Global"
    }
}
