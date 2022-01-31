if(($null -eq $TestName) -or ($TestName -contains 'New-AzOperationalInsightsWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOperationalInsightsWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOperationalInsightsWorkspace' {
        BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "danielKukuPsh"
        $location = "EastUS"
    }
    It 'CreateExpanded' {
        Write-Host -ForegroundColor Yellow "Creating a test workspace: $($wsName)"
        $workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName -Location $location
        Write-Host -ForegroundColor Yellow "Workspace: $($wsName) was created"
        $workspace.Count | Should BeGreaterThan 0
    }
}
