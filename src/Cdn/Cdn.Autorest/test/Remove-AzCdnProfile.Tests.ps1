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
        $cdnProfileName = 'p-psName010'
        Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"
        $profileSku = "Standard_Microsoft"
        
        Write-Host -ForegroundColor Green "New cdnProfileName"
        New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        Write-Host -ForegroundColor Green "Remove cdnProfileName"
        $res = Remove-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName
        $res | Should -BeNullOrEmpty
    }

    # Use "PassThru" parameter to test
    It 'Delete' {
        $cdnProfileName = 'p-psName010'
        Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"
        $profileSku = "Standard_Microsoft"
        
        Write-Host -ForegroundColor Green "New cdnProfileName"
        New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        Write-Host -ForegroundColor Green "Remove cdnProfileName"
        $res = Remove-AzCdnProfile -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -PassThru
        $res | Should -Be "True"
    }

    It 'DeleteViaIdentity' {
        $cdnProfileName = 'p-psName020'
        Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"
        $profileSku = "Standard_Microsoft"
        
        Write-Host -ForegroundColor Green "New cdnProfileName"
        New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        Write-Host -ForegroundColor Green "Get cdnProfileName"
        $profileObject = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $cdnProfileName

        Write-Host -ForegroundColor Green "Remove cdnProfileName"
        Remove-AzCdnProfile -InputObject $profileObject
    }
}
