if(($null -eq $TestName) -or ($TestName -contains 'Request-AzRedHatOpenShiftHcpClusterAdminCredential'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Request-AzRedHatOpenShiftHcpClusterAdminCredential.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Request-AzRedHatOpenShiftHcpClusterAdminCredential' {
    # Custom cmdlet (C1): generates an RSA key + CSR locally, calls the hidden generated cmdlet with the CSR,
    # decodes the returned SecureString kubeconfig, splices in the private key, and writes it to -OutFile with
    # 0600 perms. Each run makes a fresh keypair, but the CSR is in the request BODY (not the match key), so
    # playback replays the recorded kubeconfig response regardless.
    It 'RequestExpanded' {
        $out = Join-Path ([System.IO.Path]::GetTempPath()) ("hcp-admin-$PID.config")
        if (Test-Path $out) { Remove-Item $out -Force }
        try {
            $cred = Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName $env.ResourceGroupName `
                -HcpOpenShiftClusterName $env.ClusterName -OutFile $out -Force -PassThru

            Test-Path $out | Should -Be $true
            (Get-Content $out -Raw) | Should -Match 'current-context'
            $cred | Should -Not -BeNullOrEmpty

            # Secret hygiene: the kubeconfig must be written owner-only (0600) on non-Windows.
            if ([System.Environment]::OSVersion.Platform -eq [System.PlatformID]::Unix) {
                ([int][System.IO.File]::GetUnixFileMode($out)) | Should -Be 384   # 0o600 = UserRead,UserWrite
            }
        }
        finally {
            if (Test-Path $out) { Remove-Item $out -Force }
        }
    }
}
