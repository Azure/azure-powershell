if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get/List NSPConfig, and Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration' {
    It 'Reconcile' {        
        ## before run the test, need create storage account and NSP and assiciate NSP with storage account    
        # New-AzStorageAccount -ResourceGroupName $env.NspResourceGroup -Name $env.NspAccount-SkuName Standard_LRS -Location eastus 
        # $account = Get-AzStorageAccount -ResourceGroupName $env.NspResourceGroup -Name $env.NspAccount
        # $accountId = $account.Id
        # $nsp = New-AzNetworkSecurityPerimeter -Name $nspName -ResourceGroupName $env.NspResourceGroup -Location eastus 
        # $profileNSP=New-AzNetworkSecurityPerimeterProfile -Name $nspProfileName -ResourceGroupName $env.NspResourceGroup -SecurityPerimeterName $nspName
        # $aso = New-AzNetworkSecurityPerimeterAssociation -AssociationName weitest -ResourceGroupName $env.NspResourceGroup -SecurityPerimeterName $nspName -AccessMode Learning -ProfileId $profileNSP.Id -PrivateLinkResourceId $accountId

        # List
        $nspconfig = Get-AzStorageNetworkSecurityPerimeterConfiguration -ResourceGroupName $env.NspResourceGroup -AccountName $env.NspAccount
        $nspConfigName = $nspconfig[0].Name
        $nspconfig.Count| Should -Be 1
        $nspconfig[0].ResourceGroupName | Should -Be $env.NspResourceGroup
        $nspconfig[0].ProfileName | Should -not -Be $null
        $nspconfig[0].ProvisioningState  | Should -Be "Succeeded"
        $nspconfig[0].Name.contains($nspconfig[0].NetworkSecurityPerimeterGuid ) | Should -Be $true

        # Get
        $nspconfig2 = Get-AzStorageNetworkSecurityPerimeterConfiguration -ResourceGroupName $env.NspResourceGroup -AccountName $env.NspAccount -Name $nspConfigName
        $nspconfig.Count| Should -Be 1
        $nspconfig2[0].ResourceGroupName | Should -Be $nspconfig[0].ResourceGroupName
        $nspconfig2[0].ProfileName | Should -Be $nspconfig[0].ProfileName
        $nspconfig2[0].ProvisioningState  | Should -Be $nspconfig[0].ProvisioningState
        $nspconfig2[0].Name | Should -Be $nspconfig[0].Name
        $nspconfig2[0].Id | Should -Be $nspconfig[0].Id

        # Reconcile
        Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration -ResourceGroupName $env.NspResourceGroup -AccountName $env.NspAccount -NetworkSecurityPerimeterConfigurationName $nspConfigName 
    }

    It 'ReconcileViaIdentityStorageAccount' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReconcileViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
