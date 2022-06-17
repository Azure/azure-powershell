if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOperationalInsightsWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOperationalInsightsWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzOperationalInsightsWorkspace' {
    BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "dabenham-PSH2"
        $workspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName
        $worksapceRetention = $workspace.RetentionInDay
    }
    It 'UpdateExpanded' {
        $workspaceUpdate =  Update-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName -RetentionInDay ($worksapceRetention +1)
        $workspaceUpdate.RetentionInDay | Should Be ($worksapceRetention +1)
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
