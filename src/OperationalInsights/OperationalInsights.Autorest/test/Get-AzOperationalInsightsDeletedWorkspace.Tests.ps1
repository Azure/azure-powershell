if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOperationalInsightsDeletedWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOperationalInsightsDeletedWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOperationalInsightsDeletedWorkspace' {

    BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "dabenham-PSH2"
    }

    It 'List' {
        $deletedWorkspaces = Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName $rgName
        Write-Host -ForegroundColor Yellow "Get-AzOperationalInsightsDeletedWorkspace List for rg:${rgName}, workspaces:${wsName} returned with: $($deletedWorkspaces.Count) results"
        Write-Host -ForegroundColor Yellow $deletedWorkspaces
        $singleWorkspace.Count | Should BeGreaterThan 0
    }

    It 'List1' {
        $deletedWorkspaces = Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName $rgName -Name $wsName
        Write-Host -ForegroundColor Yellow "Get-AzOperationalInsightsWorkspace List1 for rg:${rgName}, workspaces:${wsName} returned with: $($deletedWorkspaces.Count) results"
        Write-Host -ForegroundColor Yellow $deletedWorkspaces
        $singleWorkspace.Count | Should BeGreaterThan 0
    }
}
