if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnProfile'  {
    It 'Delete' {
        $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"
        $profileSku = "Standard_Microsoft"

        New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        Remove-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName
    }

    It 'DeleteViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"
        $profileSku = "Standard_Microsoft"
        
        New-AzCdnProfile -SubscriptionId $env.SubscriptionId -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $cdnProfileName | Remove-AzCdnProfile
    }
}
