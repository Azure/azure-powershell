if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityConnectorActionableRemediationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityConnectorActionableRemediationObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityConnectorActionableRemediationObject' {
    It '__AllParameterSets' {
        $config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled `
            -BranchConfiguration @{AnnotateDefaultBranch="Enabled"; branchName=@("main", "hotfix")} -CategoryConfiguration @( @{category="First"; minimumSeverityLevel="High"}, @{category="Second"; minimumSeverityLevel="Low"})
        $config.State | Should -Be "Enabled"
        $config.InheritFromParentState | Should -Be "Disabled"
        $config.CategoryConfiguration.Count | Should -Be 2
        $config.BranchConfiguration.BranchName.Count | Should -Be 2
    }
}
