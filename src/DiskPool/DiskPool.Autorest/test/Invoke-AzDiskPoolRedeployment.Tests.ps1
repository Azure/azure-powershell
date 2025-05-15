if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDiskPoolRedeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDiskPoolRedeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDiskPoolRedeployment' {
    It 'Redeploy' {
        {Invoke-AzDiskPoolRedeployment -DiskPoolName $env.diskPool5 -ResourceGroupName $env.resourceGroup} | Should -Not -Throw
    }

    It 'RedeployViaIdentity' {
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool5
        {Invoke-AzDiskPoolRedeployment -InputObject $diskPool} | Should -Not -Throw
    }
}
