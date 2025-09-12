if (($null -eq $TestName) -or ($TestName -contains "AzNginxTestAll")) {
    $loadEnvPath = Join-Path $PSScriptRoot "loadEnv.ps1"
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot "..\loadEnv.ps1"
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot "AzNginxTestAll.Recording.json"
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include "HttpPipelineMocking.ps1" -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe "AzNginxTestAll" {
    It "CreateExpanded" {
        Write-Host "testing nginx scenarios"

        # enabling monitoring
        $nginx = Update-AzNginxDeployment -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup -EnableDiagnosticsSupport
        $nginx.EnableDiagnosticsSupport | Should -Be True

        $confFile = New-AzNginxConfigurationFileObject -VirtualPath $env.nginxFilePath -Content $env.nginxFileContent
        
        # configuration analysis
        $confAnalysis = Invoke-AzNginxAnalysisConfiguration -ConfigurationName default -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup  -ConfigFile $confFile -ConfigRootFile $env.nginxFilePath 
        # adding nginx configuration
        $conf = New-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name default -ResourceGroupName $env.resourceGroup -File $confFile -RootFile $env.nginxFilePath
        $conf.ProvisioningState | Should -Be 'Succeeded'
        $conf.File.Content | Should -Be $env.nginxFileContent

        # checking added configuration
        $confList = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $confList.Count | Should -Be 1

        $conf = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup
        $conf.Name | Should -Be $env.nginxConf
        
        # add certificate
        $cert = New-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxCert -ResourceGroupName $env.resourceGroup -CertificateVirtualPath "/etc/nginx/test.cert" -KeyVirtualPath "/etc/nginx/test.key" -KeyVaultSecretId $env.kvcertsecretid
        $cert.ProvisioningState | Should -Be 'Succeeded'
        $cert.CertificateVirtualPath | Should -Be "/etc/nginx/test.cert"
        $cert.KeyVirtualPath | Should -Be "/etc/nginx/test.key"
        $cert.KeyVaultSecretId | Should -Be $env.kvcertsecretid
        
        $updatecert = Update-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxCert -ResourceGroupName $env.resourceGroup -CertificateVirtualPath "/etc/nginx/testnew.cert" -KeyVirtualPath "/etc/nginx/testnew.key" -KeyVaultSecretId $env.kvcertsecretid
        $updatecert.ProvisioningState | Should -Be 'Succeeded'
        $updatecert.CertificateVirtualPath | Should -Be "/etc/nginx/testnew.cert"
        $updatecert.KeyVirtualPath | Should -Be "/etc/nginx/testnew.key"
        $updatecert.KeyVaultSecretId | Should -Be $env.kvcertsecretid

        $content = 'cHJveHlfc2V0X2hlYWRlciBIb3N0ICRob3N0Owpwcm94eV9zZXRfaGVhZGVyIFgtUmVhbC1JUCAkcmVtb3RlX2FkZHI7CnByb3h5X3NldF9oZWFkZXIgWC1Qcm94eS1BcHAgYXBwOwpwcm94eV9zZXRfaGVhZGVyIEdpdGh1Yi1SdW4tSWQgMDAwMDAwOwpwcm94eV9idWZmZXJpbmcgb247CnByb3h5X2J1ZmZlcl9zaXplIDRrOwpwcm94eV9idWZmZXJzIDggOGs7CnByb3h5X3JlYWRfdGltZW91dCA2MHM7'
        $newConfFile = New-AzNginxConfigurationFileObject -Content $content -VirtualPath 'conf.d/proxy.conf'
        $updateConf = Update-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup -File $confFile,$newConfFile -RootFile $env.nginxFilePath
        $updateConf.File[1].Content | Should -Be $content
        $updateConf.File[0].Content | Should -Be $env.nginxFileContent
        $conf = Get-AzNginxConfiguration -InputObject $updateConf
        $conf.Name | Should -Be $env.nginxConf
        
        # delete deployment
        Remove-AzNginxDeployment -Name $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $deploymentList = Get-AzNginxDeployment -ResourceGroupName $env.resourceGroup
        $deploymentList.Name | Should -Not -Contain $env.nginxDeployment1
        Write-Host "finished testing nginx scenarios"
    }

}