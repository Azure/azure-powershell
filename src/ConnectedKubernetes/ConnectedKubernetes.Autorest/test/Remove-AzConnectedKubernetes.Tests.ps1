if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzConnectedKubernetes'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedKubernetes.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzConnectedKubernetes' {
    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

Describe 'Invoke-HelmDelete' {
    It 'Treats output on stderr as diagnostic output when Helm succeeds' {
        Mock Invoke-ExternalCommand {
            return [PSCustomObject]@{
                ExitCode = 0
                Output   = @('release "azure-arc" uninstalled')
            }
        }

        {
            Invoke-HelmDelete `
                -ReleaseName 'azure-arc' `
                -ReleaseNamespace 'azure-arc-release' `
                -KubeConfig 'test-kubeconfig' `
                -KubeContext 'test-context'
        } | Should -Not -Throw

        Assert-MockCalled Invoke-ExternalCommand -Times 1 -ParameterFilter {
            $PassThruResult -and
            $Arguments -contains 'delete' -and
            $Arguments -contains 'azure-arc-release' -and
            $Arguments -contains 'test-context'
        }
    }

    It 'Reports Helm diagnostics and recovery command when Helm fails' {
        Mock Invoke-ExternalCommand {
            return [PSCustomObject]@{
                ExitCode = 1
                Output   = @('timed out waiting for the condition')
            }
        }

        $errorRecord = $null
        try {
            Invoke-HelmDelete `
                -ReleaseName 'azure-arc' `
                -ReleaseNamespace 'azure-arc-release' `
                -KubeConfig 'test-kubeconfig' `
                -KubeContext 'test-context'
        }
        catch {
            $errorRecord = $_
        }

        $errorRecord | Should -Not -BeNullOrEmpty
        $errorRecord.FullyQualifiedErrorId | Should -Match '^HelmUninstallFailed'
        $errorRecord.Exception.Message | Should -Match 'Helm cleanup failed after the Azure connected cluster resource was deleted'
        $errorRecord.Exception.Message | Should -Match 'Helm exit code: 1'
        $errorRecord.Exception.Message | Should -Match 'timed out waiting for the condition'
        $errorRecord.Exception.Message | Should -Match 'helm uninstall azure-arc'
    }
}
