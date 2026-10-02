if(($null -eq $TestName) -or ($TestName -contains 'Invoke-ExternalCommand'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-ExternalCommand.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-ExternalCommand' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Captures native output and exit code' {
        $powerShellExecutable = (Get-Process -Id $PID).Path
        $arguments = @(
            '-NoProfile',
            '-NonInteractive',
            '-Command',
            '[Console]::Out.WriteLine("standard output"); [Console]::Error.WriteLine("standard error"); exit 7'
        )

        $result = Invoke-ExternalCommand `
            -Command $powerShellExecutable `
            -Arguments $arguments `
            -PassThruResult

        $result.ExitCode | Should -eq 7
        ($result.Output -join "`n") | Should -Match 'standard output'
        ($result.Output -join "`n") | Should -Match 'standard error'
    }
}
