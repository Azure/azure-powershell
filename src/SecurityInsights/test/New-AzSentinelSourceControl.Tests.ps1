if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelSourceControl'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelSourceControl.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelSourceControl' {
    It 'CreateExpanded' {
        $contentTypes = @("Parser","AnalyticsRule","AutomationRule","HuntingQuery","Playbook","Workbook")
        $sourceControl = New-AzSentinelSourceControl -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id ((New-Guid).Guid) -ContentType $contentTypes -DisplayName "NewSourceControlPSTest" -RepoType GitHub -RepositoryBranch master `
            -RepositoryUrl "https://github.com/dicolanl/newpstest"
        $sourceControl.RepositoryUrl | Should -Be "https://github.com/dicolanl/newpstest"
{
