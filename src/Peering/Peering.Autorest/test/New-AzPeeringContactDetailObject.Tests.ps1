if(($null -eq $TestName) -or ($TestName -contains 'New-AzPeeringContactDetailObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPeeringContactDetailObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPeeringContactDetailObject' {
    It '__AllParameterSets' {
        {
            $contactDetail = New-AzPeeringContactDetailObject -Email "abc@xyz.com" -Phone 1234567890 -Role "Noc"
            $contactDetail.Email | Should -Be "abc@xyz.com"
        } | Should -Not -Throw
    }
}
