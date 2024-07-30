if(($null -eq $TestName) -or ($TestName -contains "AzNginxTestAll"))
{
  $loadEnvPath = Join-Path $PSScriptRoot "loadEnv.ps1"
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot "..\loadEnv.ps1"
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot "AzNginxTestAll.Recording.json"
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include "HttpPipelineMocking.ps1" -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe "AzNginxTestAll" {
    It "CreateExpanded" {
        # create resource group for testing
        $rg = New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

        # create user assigned managed identity
        $identity = New-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userAssignedMI -Location $env.location

        # create key vault
        $keyvault = New-AzKeyVault -Name $env.keyvault -ResourceGroupName $env.resourceGroup -Location $env.location
        $Policy = New-AzKeyVaultCertificatePolicy -SecretContentType "application/x-pkcs12" -SubjectName "CN=nginxpwshtesting.com" -IssuerName "Self" -ValidityInMonths 6 -ReuseKeyOnRenewal
        $certKV = Add-AzKeyVaultCertificate -VaultName $env.keyvault -Name $env.nginxCert -CertificatePolicy $Policy

        # create public ip
        $ip = @{
            Name = $env.pubip
            ResourceGroupName = $env.resourceGroup
            Location = $env.location
            Sku = "Standard"
            AllocationMethod = "Static"
            IpAddressVersion = "IPv4"
            Zone = 2
        }
        $publicIp = New-AzPublicIpAddress @ip -Force

        # create virtual network
        $vnet = @{
            Name = $env.vnet
            ResourceGroupName = $env.resourceGroup
            Location = $env.location
            AddressPrefix = "10.0.0.0/16"
        }
        $virtualNetwork = New-AzVirtualNetwork @vnet -Force

        # create subnet
        $subnet = @{
            Name = $env.subnet
            VirtualNetwork = $virtualNetwork
            AddressPrefix = "10.0.0.0/24"
        }
        $subnetConfig = Add-AzVirtualNetworkSubnetConfig @subnet
        $virtualNetwork | Set-AzVirtualNetwork

        # delegate the subnet to NGINX.NGINXPLUS/nginxDeployments
        $vnet = Get-AzVirtualNetwork -Name $env.vnet -ResourceGroupName $env.resourceGroup
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.subnet -VirtualNetwork $vnet
        $subnet = Add-AzDelegation -Name "delegation" -ServiceName $env.delegation -Subnet $subnet
        Set-AzVirtualNetwork -VirtualNetwork $vnet

        # create the nginxaas resource
        $publicIp = New-AzNginxPublicIPAddressObject -Id $publicIp.Id
        $networkProfile = New-AzNginxNetworkProfileObject -FrontEndIPConfiguration @{PublicIPAddress=@($publicIp)} -NetworkInterfaceConfiguration @{SubnetId=$subnet.Id}
        $nginxDeployment = New-AzNginxDeployment -Name $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup -Location $env.location -NetworkProfile $networkProfile -SkuName standard_Monthly_gmz7xq9ge3py -IdentityType "SystemAssigned" 
        $nginxDeployment.ProvisioningState | Should -Be "Succeeded"
        $nginxDeployment.Name | Should -Be $env.nginxDeployment1
        

        # assigning role
        $keyVaultId = $keyVault.ResourceId
        $roleDefinition = Get-AzRoleDefinition -Name "Key Vault Administrator"
        $roleAssignment = New-AzRoleAssignment -ObjectId $nginxDeployment.IdentityPrincipalId  -RoleDefinitionId $roleDefinition.Id -Scope $keyVaultId


        # enabling monitoring
        $nginx = Update-AzNginxDeployment -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup -EnableDiagnosticsSupport
        $nginx.EnableDiagnosticsSupport | Should -Be True

        $confFile = New-AzNginxConfigurationFileObject -VirtualPath $env.nginxFilePath -Content $env.nginxFileContent
        
        # configuration analysis
        $confAnalysis = Invoke-AzNginxAnalysisConfiguration -ConfigurationName default -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup  -ConfigFile $confFile -ConfigRootFile $env.nginxFilePath 
        # adding nginx configuration
        $conf = New-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name default -ResourceGroupName $env.resourceGroup -File $confFile -RootFile $env.nginxFilePath
        $conf.ProvisioningState | Should -Be 'Succeeded'

        # checking added configuration
        $confList = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $confList.Count | Should -Be 1

        $conf = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup
        $conf.Name | Should -Be $env.nginxConf

        $conf = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup
        $conf = Get-AzNginxConfiguration -InputObject  $conf
        $conf.Name | Should -Be $env.nginxConf

        # add certificate
        $certVersion = "/" + (Get-AzKeyVaultcertificate -VaultName $env.keyvault -name $env.nginxCert).version 
        $kvcertsecretid = (Get-AzKeyVaultcertificate -VaultName $env.keyvault -name $env.nginxCert).secretid.Replace(":443", "").Replace($certVersion, "")
        $cert = New-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxCert -ResourceGroupName $env.resourceGroup -CertificateVirtualPath "/etc/nginx/test.cert" -KeyVirtualPath "/etc/nginx/test.key" -KeyVaultSecretId $kvcertsecretid
        $cert.ProvisioningState | Should -Be 'Succeeded'


        # delete deployment
        Remove-AzNginxDeployment -Name $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $deploymentList = Get-AzNginxDeployment -ResourceGroupName $env.resourceGroup
        $deploymentList.Name | Should -Not -Contain $env.nginxDeployment1
        
    }

}