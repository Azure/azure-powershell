if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDnsDnssecConfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsDnssecConfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
  $null = [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.PipelineMock]::Blacklist.Add('x-ms-policy-external-evaluations')
}

Describe 'Remove-AzDnsDnssecConfig' {
    It 'Delete' {          
        # SETUP
        New-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName3

        # TEST
        { Remove-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName3 } | Should -Not -Throw

        # VERIFY
        { Get-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName3 } | Should -Throw
    }

    It 'Delete-AcquirePolicyToken-Identity:<UseIdentity>' -TestCases @(
        @{ UseIdentity = $false }
        @{ UseIdentity = $true }
    ) {
        param($UseIdentity)
        $config = New-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName3
        $observation = @{ Writes = 0 }
        $observer = New-DnsTestPolicyTokenObserver $observation
        $parameters = @{
            AcquirePolicyToken = $true
            HttpPipelineAppend = $observer
            Confirm = $false
        }
        if ($UseIdentity) {
            $parameters.InputObject = @{ Id = $config.Id }
        } else {
            $parameters.ResourceGroupName = $env.ResourceGroup
            $parameters.ZoneName = $env.ZoneName3
        }
        Remove-AzDnsDnssecConfig @parameters
        { Get-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName3 } | Should -Throw
        if ($TestMode -ne 'playback') {
            $observation.Writes | Should -BeGreaterThan 0
        }
    }
}
