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

        # checking added configuration
        $confList = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $confList.Count | Should -Be 1

        $conf = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup
        $conf.Name | Should -Be $env.nginxConf

        $conf = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup
        $conf = Get-AzNginxConfiguration -InputObject  $conf
        $conf.Name | Should -Be $env.nginxConf

        # add certificate
        $cert = New-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxCert -ResourceGroupName $env.resourceGroup -CertificateVirtualPath "/etc/nginx/test.cert" -KeyVirtualPath "/etc/nginx/test.key" -KeyVaultSecretId $env.kvcertsecretid
        $cert.ProvisioningState | Should -Be 'Succeeded'


        # delete deployment
        Remove-AzNginxDeployment -Name $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $deploymentList = Get-AzNginxDeployment -ResourceGroupName $env.resourceGroup
        $deploymentList.Name | Should -Not -Contain $env.nginxDeployment1
        Write-Host "finished testing nginx scenarios"
    }

}