if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOperationalInsightsWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOperationalInsightsWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOperationalInsightsWorkspace' {

    BeforeAll { 
        $subscriptionId = "57947cb5-aadd-4b6c-9e8e-27f545bb7bf5"
        $rgName = "dabenham-dev"
        $wsName = "dabenham-PSH2"
    }

    It 'List'  {
        $workspaces = Get-AzOperationalInsightsWorkspace
        $workspaces.Count | Should BeGreaterThan 0
    }

    It 'Get'  {
        $singleWorkspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName
        $singleWorkspace.Count | Should BeGreaterThan 0
    }

    It 'List1' -skip {
        $workspaces = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName
        $workspaces.Count | Should BeGreaterThan 0
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
