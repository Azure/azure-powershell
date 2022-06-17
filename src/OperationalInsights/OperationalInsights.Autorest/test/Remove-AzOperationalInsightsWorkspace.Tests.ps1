if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOperationalInsightsWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOperationalInsightsWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOperationalInsightsWorkspace' {
            
    BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "danielKukuPsh2"
        $location = "EastUS"

        # Create a test workspace:
        Write-Host -ForegroundColor Yellow "Creating a test workspace: $($wsName)"
        $workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName -Location $location
        Write-Host -ForegroundColor Yellow "Workspace: $($wsName) was created"
        $workspace.Count | Should BeGreaterThan 0
    }
    It 'Delete' {
        Write-Host -ForegroundColor Yellow "Deleting test workspace: $($wsName)"
        Remove-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName
        Write-Host -ForegroundColor Yellow "Workspace: $($wsName) was deleted"
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
