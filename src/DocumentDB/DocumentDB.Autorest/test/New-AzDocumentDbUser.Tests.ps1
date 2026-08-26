if(($null -eq $TestName) -or ($TestName -contains 'New-AzDocumentDbUser'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDocumentDbUser.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDocumentDBUser' {
    BeforeAll {
        $rg = $env.userRg
        $cluster = $env.userCluster
        $userOid = $env.userObjectId
        $loc = $env.location
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
        # Entra auth must be enabled at create time to add Entra users.
        New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc `
            -AuthConfigAllowedMode NativeAuth, MicrosoftEntraID | Out-Null
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'MicrosoftEntraUser assign/show/list/remove' {
        # Grant a Microsoft Entra principal data-plane access (custom -Type wrapper).
        $assigned = New-AzDocumentDBUser -Name $userOid -MongoClusterName $cluster -ResourceGroupName $rg `
            -Type User -Role @(@{ Db = 'admin'; Role = 'root' })
        $assigned.Name | Should -Be $userOid
        $assigned.ProvisioningState | Should -Be 'Succeeded'
        $assigned.IdentityProviderType | Should -Be 'MicrosoftEntraID'

        # Read the user back.
        $show = Get-AzDocumentDBUser -Name $userOid -MongoClusterName $cluster -ResourceGroupName $rg
        $show.Name | Should -Be $userOid

        # The user shows up in the cluster's user listing.
        @(Get-AzDocumentDBUser -MongoClusterName $cluster -ResourceGroupName $rg | Where-Object { $_.Name -eq $userOid }).Count | Should -Be 1

        # Note: the service does not support updating an existing Microsoft Entra ID
        # user, so only assign/show/list/remove are exercised here.
        { Remove-AzDocumentDBUser -Name $userOid -MongoClusterName $cluster -ResourceGroupName $rg } | Should -Not -Throw
    }
}
