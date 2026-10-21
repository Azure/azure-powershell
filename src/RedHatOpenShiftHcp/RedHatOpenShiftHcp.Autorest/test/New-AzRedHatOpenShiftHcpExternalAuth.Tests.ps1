if(($null -eq $TestName) -or ($TestName -contains 'New-AzRedHatOpenShiftHcpExternalAuth'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRedHatOpenShiftHcpExternalAuth.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Throwaway external auth exercised by the New/Update/Remove lifecycle tests. Fixed name so the recorded
# request URIs match on playback.
$authName = 'eatest-ps'
# Synthetic (non-real) audience/client id so no real app registration is committed; it only has to be
# internally consistent (ClientId must appear in IssuerAudience).
$audience = '11111111-1111-1111-1111-111111111111'

Describe 'New-AzRedHatOpenShiftHcpExternalAuth' {
    It 'CreateExpanded (console client is Confidential -> AwaitingSecret)' {
        # Issuer uses the real tenant at record time, masked env.Tenant on playback. It is in the request
        # BODY (not the match key), so the value only needs to be real when actually calling Azure.
        $tenant = if ($env:AzPSAutorestTestPlaybackMode) { $env.Tenant } else { (Get-AzContext).Tenant.Id }
        $issuer = "https://login.microsoftonline.com/$tenant/v2.0"

        # The OpenShift web console MUST be a Confidential OIDC client (RP rule). Its secret is supplied
        # in-cluster (not via ARM), so a fresh resource provisions to AwaitingSecret.
        $clientProfile = @(
            @{
                ComponentName                = 'console'
                ComponentAuthClientNamespace = 'openshift-console'
                ClientId                     = $audience
                Type                         = 'Confidential'
            }
        )

        $ea = New-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName $env.ResourceGroupName `
            -HcpOpenShiftClusterName $env.ClusterName -Name $authName `
            -IssuerUrl $issuer -IssuerAudience @($audience) -ClientProfile $clientProfile `
            -UsernameClaim 'email' -GroupClaim 'groups'

        $ea.Name | Should -Be $authName
        @('AwaitingSecret', 'Succeeded') | Should -Contain $ea.ProvisioningState
    }

    It 'rejects a second external auth (only one per cluster)' {
        # The RP allows a single external auth per cluster; a second create must be refused.
        $tenant = if ($env:AzPSAutorestTestPlaybackMode) { $env.Tenant } else { (Get-AzContext).Tenant.Id }
        $issuer = "https://login.microsoftonline.com/$tenant/v2.0"
        $clientProfile = @(
            @{
                ComponentName                = 'console'
                ComponentAuthClientNamespace = 'openshift-console'
                ClientId                     = $audience
                Type                         = 'Confidential'
            }
        )
        { New-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName $env.ResourceGroupName `
            -HcpOpenShiftClusterName $env.ClusterName -Name 'eatest-ps2' `
            -IssuerUrl $issuer -IssuerAudience @($audience) -ClientProfile $clientProfile `
            -UsernameClaim 'email' } | Should -Throw 'Only one external auth is allowed'
    }
}
