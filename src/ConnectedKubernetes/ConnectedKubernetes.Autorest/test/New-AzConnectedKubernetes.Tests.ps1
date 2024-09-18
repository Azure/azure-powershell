if (($null -eq $TestName) -or ($TestName -contains 'New-AzConnectedKubernetes')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
    . "$PSScriptRoot/../custom/helpers/HelmHelper.ps1"
    . "$PSScriptRoot/../custom/helpers/ConfigDPHelper.ps1"
    . "$PSScriptRoot/../custom/helpers/AzCloudMetadataHelper.ps1"
}

# The custom tests make helm requests and the framework does not mock these so
# record/replay will not work.
Describe 'New-AzConnectedKubernetes' {
    It 'CreateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

Describe 'Invoke-ConfigDPHealthCheck' {
    # Note that we Mock Invoke-RestMethod and not Invoke-RestMethodWithUriParameters
    # because it appears that Pester has a problem handling ordered hashtable
    # as a parameter to Mock. This is a workaround.
    It 'Golden path' {
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return
        }
        { Invoke-ConfigDPHealthCheck } | Should -Not -Throw
        Assert-MockCalled "Invoke-RestMethod" -Times 1
        Assert-VerifiableMock
    }

    It 'Env access token' {
        $env:AZURE_ACCESS_TOKEN = "This is an access token"
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return
        }
        { Invoke-ConfigDPHealthCheck } | Should -Not -Throw
        Assert-MockCalled "Invoke-RestMethod" -Times 1
        Assert-VerifiableMock
    }

    It 'Unhealthy (not 200 response)' {
        Mock Invoke-RestMethod {
            $Script:StatusCode = 500
            return
        }
        { Invoke-ConfigDPHealthCheck } | Should -Throw "Error while performing DP health check, StatusCode: 500"
        Assert-MockCalled "Invoke-RestMethod" -Times 1
        Assert-VerifiableMock
    }
}

Describe 'Invoke-RestMethodWithUriParameters' {
    It 'Golden path' {
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return
        }
        {
            $uriParameters = [ordered]@{}
            Invoke-RestMethodWithUriParameters `
                -Method "POST" `
                -Uri "https://invalid.invalid/some/page/nowhere" `
                -Headers @{} `
                -UriParameters $uriParameters `
                -RequestBody @{} `
                -MaximumRetryCount 5 `
                -RetryIntervalSec 2 `
                -StatusCodeVariable YesOrNo
        } | Should -Not -Throw
        Assert-MockCalled "Invoke-RestMethod" -Times 1 -ParameterFilter { $Uri.AbsoluteUri -eq "https://invalid.invalid/some/page/nowhere" }
        Assert-VerifiableMock
        $YesOrNo | Should -Be 200
    }

    It 'URI parameters' {
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return
        }

        {
            # Create a hashtable with sample key-value pairs
            $uriParameters = [ordered]@{"key1" = "value1"; "key2" = "value2" }

            Invoke-RestMethodWithUriParameters `
                -Method "POST" `
                -Uri "https://invalid.invalid/some/page/nowhere" `
                -Headers @{} `
                -UriParameters $uriParameters `
                -RequestBody @{} `
                -MaximumRetryCount 5 `
                -RetryIntervalSec 2 `
                -StatusCodeVariable YesOrNo
        } | Should -Not -Throw
        Assert-MockCalled "Invoke-RestMethod" -Times 1 -ParameterFilter { $Uri.AbsoluteUri -eq "https://invalid.invalid/some/page/nowhere?key1=value1&key2=value2" }
        Assert-VerifiableMock
        $YesOrNo | Should -Be 200
    }

    It 'request failed' {
        Mock Invoke-RestMethod {
            $Script:StatusCode = 500
            return
        }
        {
            Invoke-RestMethodWithUriParameters `
                -Method "POST" `
                -Uri "https://invalid.invalid/some/page/nowhere" `
                -Headers @{} `
                -UriParameters @{} `
                -RequestBody @{} `
                -MaximumRetryCount 5 `
                -RetryIntervalSec 2 `
                -StatusCodeVariable YesOrNo
        } | Should -Not -Throw
        Assert-VerifiableMock
        $YesOrNo | Should -Be 500
    }
}

Describe 'Get-ConfigDpDefaultEndpoint' {
    It 'Golden path' {
        {
            $cloudMetadata = [PSCustomObject]@{
                ActiveDirectoryAuthority = "https://login.microsoftonline.com/"
            }
            $script:configDpEndpoint = Get-ConfigDpDefaultEndpoint `
                -Location "eastus2" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw
        $configDpEndpoint | Should -Be "https://eastus2.dp.kubernetesconfiguration.azure.com"
    }

    It 'Sovereign cloud' {
        {
            $cloudMetadata = [PSCustomObject]@{
                ActiveDirectoryAuthority = "https://login.sovereign.invalid/"
            }
            $script:configDpEndpoint = Get-ConfigDpDefaultEndpoint `
                -Location "westus3" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw
        $configDpEndpoint | Should -Be "https://westus3.dp.kubernetesconfiguration.azure.invalid"
    }
}

Describe 'Get-ConfigDpEndpoint' {
    It 'Golden Path' {
        {
            $cloudMetadata = [PSCustomObject]@{
                ActiveDirectoryAuthority = "https://login.microsoftonline.com"
            }
            $script:configDpEndpoint = Get-ConfigDpEndpoint `
                -Location "eastus2" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw

        $configDpEndpoint.ConfigDpEndpoint | Should -Be "https://eastus2.dp.kubernetesconfiguration.azure.com"
        $configDpEndpoint.ReleaseTrain | Should -Be $null
    }
}

Describe 'Get-AzCloudMetadata' {
    # For some reason Pester fails to "see" Get-AzureEnvirnomment so we create
    # and empty instance here that we can the mock.
    BeforeEach {
        Function Get-AzureEnvironment {
        }
    }

    It 'Golden path' {
        Mock Get-AzContext {
            return [PSCustomObject]@{
                Environment = [PSCustomObject]@{
                    Name = "SovereignAzureCloud"
                }
            }
        }
        Mock Get-AzureEnvironment {
            $context = [PSCustomObject]@{
                Name = "AzureCloud"
            }
            return $context
        }
        { $Script:cloud = Get-AzCloudMetadata } | Should -Not -Throw
        Assert-MockCalled "Get-AzContext" -Times 1
        Assert-MockCalled "Get-AzureEnvironment" -Times 1
        # Ref: https://github.com/pester/Pester/issues/2556
        # Assert-MockCalled "Get-AzureEnvironment" -Times 1 -ParameterFilter { $Local:Name -eq "SovereignAzureCloud" }
        Assert-VerifiableMock
        $cloud.name | Should -Be "AzureCloud"
    }

    It 'Get-AzContext fails' {
        Mock Get-AzContext {
            throw "Some error!"
        }
        { Get-AzCloudMetadata } | Should -Throw "Failed to get the current Azure context. Error: Some error!"
        Assert-MockCalled "Get-AzContext" -Times 1
        Assert-VerifiableMock
    }

    It 'Get-AzureEnvironment fails' {
        Mock Get-AzContext {
            return [PSCustomObject]@{
                Environment = [PSCustomObject]@{
                    Name = "SovereignAzureCloud"
                }
            }
        }
        Mock Get-AzureEnvironment {
            throw "Some error!"
        }
        { Get-AzCloudMetadata } | Should -Throw "Failed to request ARM metadata. Error: Some error!"
        Assert-MockCalled "Get-AzContext" -Times 1
        Assert-VerifiableMock
    }
}

Describe 'Get-HelmValuesFromConfigDP' {
    It 'Golden path' {
        $rq = {
            identity = @{
                tenantId    = "1234"
                principalId = "5678"
            }
            id = "abcd"
        }
        $rsp = [PSObject]@{
            Frank = "Sinatra"
            Dean  = "Martin"
        }
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return $rsp
        }
        {
            $Script:helmValues = Get-HelmValuesFromConfigDP `
                -ConfigDpEndpoint "https://helm.azure.com" `
                -ReleaseTrainCustom $null `
                -RequestBody $rq
        } | Should -Not -Throw
        $helmValues.Frank | Should -Be "Sinatra"
        $helmValues.Dean | Should be "Martin"
        Assert-MockCalled "Invoke-RestMethod" -Times 1  -ParameterFilter {
            $Uri.AbsoluteUri -eq "https://helm.azure.com/azure-arc-k8sagents/GetHelmSettings?api-version=2024-07-01-preview&releaseTrain=stable"
        }
        Assert-VerifiableMock
    }

    It 'Custom release train' {
        $rq = @{
            identity = @{
                tenantId    = "1234"
                principalId = "5678"
            }
            id       = "abcd"
        }
        $rsp = @{
            Frank = "Sinatra"
            Dean  = "Martin"
        }
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return $rsp
        }
        {
            $Script:helmValues = Get-HelmValuesFromConfigDP `
                -ConfigDpEndpoint "https://helm.azure.com" `
                -ReleaseTrainCustom "all-aboard"`
                -RequestBody $rq
        } | Should -Not -Throw
        $helmValues.Frank | Should -Be "Sinatra"
        $helmValues.Dean | Should be "Martin"
        Assert-MockCalled "Invoke-RestMethod" -Times 1  -ParameterFilter {
            $Uri.AbsoluteUri -eq "https://helm.azure.com/azure-arc-k8sagents/GetHelmSettings?api-version=2024-07-01-preview&releaseTrain=all-aboard"
        }
        Assert-VerifiableMock
    }

    It 'Env access token' {
        $env:AZURE_ACCESS_TOKEN = "Tell nobody!"
        $rq = @{
            identity = @{
                tenantId    = "1234"
                principalId = "5678"
            }
            id       = "abcd"
        }
        $rsp = @{
            Frank = "Sinatra"
            Dean  = "Martin"
        }
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return $rsp
        }
        {
            $Script:helmValues = Get-HelmValuesFromConfigDP `
                -ConfigDpEndpoint "https://helm.azure.com" `
                -ReleaseTrainCustom $null `
                -RequestBody $rq
        } | Should -Not -Throw
        $helmValues.Frank | Should -Be "Sinatra"
        $helmValues.Dean | Should be "Martin"
        Assert-MockCalled "Invoke-RestMethod" -Times 1 -ParameterFilter {
            $Headers["Authorization"] -eq "Bearer Tell nobody!"
        }
        Assert-VerifiableMock
    }

    It 'REST call failed' {
        $rq = @{
            identity = @{
                tenantId    = "1234"
                principalId = "5678"
            }
            id       = "abcd"
        }
        $rsp = $null
        Mock Invoke-RestMethod {
            $Script:StatusCode = 500
            return $rsp
        }
        {
            $Script:helmValues = Get-HelmValuesFromConfigDP `
                -ConfigDpEndpoint "https://helm.azure.com" `
                -ReleaseTrainCustom $null `
                -RequestBody $rq
        } | Should -Throw "No content was found in helm registry path response, StatusCode: 500."
        Assert-MockCalled "Invoke-RestMethod" -Times 1
        Assert-VerifiableMock
    }

    It 'Empty content' {
        $rq = @{
            identity = @{
                tenantId    = "1234"
                principalId = "5678"
            }
            id       = "abcd"
        }
        $rsp = $null
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return $rsp
        }
        {
            $Script:helmValues = Get-HelmValuesFromConfigDP `
                -ConfigDpEndpoint "https://helm.azure.com" `
                -ReleaseTrainCustom $null `
                -RequestBody $rq
        } | Should -Throw "No content was found in helm registry path response, StatusCode: 200."
        Assert-MockCalled "Invoke-RestMethod" -Times 1
        Assert-VerifiableMock
    }

    It 'Exception reading content' {
        $rq = @{
            identity = @{
                tenantId    = "1234"
                principalId = "5678"
            }
            id       = "abcd"
        }
        Mock Invoke-RestMethod {
            throw "Failed!"
        }
        {
            $Script:helmValues = Get-HelmValuesFromConfigDP `
                -ConfigDpEndpoint "https://helm.azure.com" `
                -ReleaseTrainCustom $null `
                -RequestBody $rq
        } | Should -Throw "Error while fetching helm values from DP from JSON response: Failed!"
        Assert-MockCalled "Invoke-RestMethod" -Times 1
        Assert-VerifiableMock
    }
}

Describe 'Get-HelmChartPath' {

    BeforeAll {
        # No user profile if running in the 'autorest' Docker container.
        if (-not $env:USERPROFILE) {
            $env:USERPROFILE = '/tmp'
        }
    }

    It 'Golden Path' {
        Mock Get-HelmChart {
        }
        {
            $Script:ChartPath = Get-HelmChartPath `
                -RegistryPath "Dummy" `
                -HelmClientLocation "fake-helm-client.exe"
        } | Should -Not -Throw
        Assert-MockCalled "Get-HelmChart" -Times 1
        Assert-VerifiableMock
        $ExpectedChartPath = Join-Path `
            -Path $env:USERPROFILE `
            -ChildPath ".azure" `
            -AdditionalChildPath "AzureArcCharts", "azure-arc-k8sagents"
        # Write-Error -Message "ChartPath: $ChartPath" -ErrorAction Continue
        # Write-Error -Message "ExpectedChartPath: $ExpectedChartPath" -ErrorAction Continue
        $ChartPath | Should -eq $ExpectedChartPath
    }

    It 'Environment helm chart name' {
        $helmChartName = "c:\\somewhere\\this-is-my-helm-chart"
        $env:HELMCHART = $helmChartName
        Mock Get-HelmChart {
        }
        {
            $Script:ChartPath = Get-HelmChartPath `
                -RegistryPath "Dummy" `
                -HelmClientLocation "fake-helm-client.exe"
        } | Should -Not -Throw
        Assert-MockCalled "Get-HelmChart" -Times 1
        Assert-VerifiableMock
        $ChartPath | Should -eq $helmChartName
    }

    It 'Pre-onboarding' {
        $helmChartName = "c:\\somewhere\\this-is-my-helm-chart"
        $env:HELMCHART = $helmChartName
        Mock Get-HelmChart {
        }
        {
            $Script:ChartPath = Get-HelmChartPath `
                -RegistryPath "Dummy" `
                -HelmClientLocation "fake-helm-client.exe" `
                -ChartFolderName "PreOnboardingChecksCharts"
        } | Should -Not -Throw
        Assert-MockCalled "Get-HelmChart" -Times 1
        Assert-VerifiableMock

        # For Pre-onboarding we ignore environment variables.
        $ExpectedChartPath = Join-Path `
            -Path $env:USERPROFILE `
            -ChildPath ".azure" `
            -AdditionalChildPath "PreOnboardingChecksCharts", "azure-arc-k8sagents"
        # Write-Error -Message "ChartPath: $ChartPath" -ErrorAction Continue
        # Write-Error -Message "ExpectedChartPath: $ExpectedChartPath" -ErrorAction Continue
        $ChartPath | Should -eq $ExpectedChartPath
        $env:HELMCHART = $null
    }

    It 'Cannot clean-up existing chart path' {
        Mock Get-HelmChart {
        }
        Mock Remove-Item {
            throw "Mock Remote-Item failure"
        }
        # Mock this just so that we can confirm that it is called.
        Mock Write-Warning {
        }
        # Create a folder path to try and remove.
        $folderPath = Join-Path -Path $env:USERPROFILE -ChildPath ".azure" -AdditionalChildPath "AzureArcCharts"
        New-Item -Path $folderPath -ItemType Directory

        {           
            $Script:ChartPath = Get-HelmChartPath `
                -RegistryPath "Dummy" `
                -HelmClientLocation "fake-helm-client.exe"
        } | Should -Not -Throw
        Assert-MockCalled "Remove-Item" -Times 1
        Assert-MockCalled "Write-Warning" -Times 1
        Assert-MockCalled "Get-HelmChart" -Times 1
        Assert-VerifiableMock
        $ExpectedChartPath = Join-Path `
            -Path $env:USERPROFILE `
            -ChildPath ".azure" `
            -AdditionalChildPath "AzureArcCharts", "azure-arc-k8sagents"
        $ChartPath | Should -eq $ExpectedChartPath
    }
}

Describe 'Get-HelmChart' {
    It 'Golden path' {
        Mock Invoke-ExternalCommand {
        }
        {
            Get-HelmChart `
                -RegistryPath "SomePath/ImageName:1.20.3" `
                -ChartExportPath "c:\temp" `
                -HelmClientLocation "fake-helm-client.exe"
        } | Should -Not -Throw
        Assert-MockCalled "Invoke-ExternalCommand" -Times 1 -ParameterFilter { $Arguments -contains "oci://SomePath/ImageName" }
        Assert-VerifiableMock
    }

    It 'NewPath' {
        Mock Invoke-ExternalCommand {
        }
        {
            Get-HelmChart `
                -RegistryPath "SomePath/ImageName:1.20.3" `
                -ChartExportPath "c:\temp" `
                -HelmClientLocation "fake-helm-client.exe" `
                -NewPath $true
        } | Should -Not -Throw
        Assert-MockCalled "Invoke-ExternalCommand" -Times 1 -ParameterFilter { $Arguments -contains "oci://SomePath/v2/ImageName" }
        Assert-VerifiableMock
    }

    It 'Agent older than 1.14.0' {
        {
            Get-HelmChart `
                -RegistryPath "SomePath/ImageName:1.2.3" `
                -ChartExportPath "c:\temp" `
                -NewPath $true `
                -HelmClientLocation "fake-helm-client.exe"
        } | Should -Throw "Operation not supported on older Agents: This CLI version does not support upgrading to Agents versions older than v1.14"
    }

    It 'Has KubeConfig' {
        Mock Invoke-ExternalCommand {
        }
        {
            Get-HelmChart `
                -RegistryPath "SomePath:1.2.3" `
                -ChartExportPath "c:\temp" `
                -HelmClientLocation "fake-helm-client.exe" `
                -KubeConfig "Some-kube-setting" `
        } | Should -Not -Throw
        Assert-MockCalled "Invoke-ExternalCommand" -Times 1 -ParameterFilter { $Command -contains "fake-helm-client.exe" }
        Assert-MockCalled "Invoke-ExternalCommand" -Times 1 -ParameterFilter { $Arguments -contains "--kubeconfig" }
        Assert-MockCalled "Invoke-ExternalCommand" -Times 1 -ParameterFilter { $Arguments -contains "some-kube-setting" }
        Assert-VerifiableMock
    }

    It 'Has KubeContext' {
        Mock Invoke-ExternalCommand {
        }
        {
            Get-HelmChart `
                -RegistryPath "SomePath:1.2.3" `
                -ChartExportPath "c:\temp" `
                -HelmClientLocation "fake-helm-client.exe" `
                -KubeContext "some-kube-context"
        } | Should -Not -Throw
        Assert-MockCalled "Invoke-ExternalCommand" -Times 1 -ParameterFilter { $Command -contains "fake-helm-client.exe" }
        Assert-MockCalled "Invoke-ExternalCommand" -Times 1 -ParameterFilter { $Arguments -contains "--kube-context" }
        Assert-MockCalled "Invoke-ExternalCommand" -Times 1 -ParameterFilter { $Arguments -contains "some-kube-context" }
        Assert-VerifiableMock
    }

    It 'Requires retry' {
        $Script:RetryCount = 2
        Mock Invoke-ExternalCommand {
            if ($Script:RetryCount -gt 0) {
                $Script:RetryCount--
                throw "Failed"
            }
        }
        {
            Get-HelmChart `
                -RegistryPath "SomePath:1.2.3" `
                -ChartExportPath "c:\temp" `
                -HelmClientLocation "fake-helm-client.exe"
            # -KubeConfig `
            # -KubeContext `
            # -NewPath
            # -ChartName = 'azure-arc-k8sagents' `
            # -RetryCount = 5 `
            # -RetryDelay = 3
        } | Should -Not -Throw
        Assert-MockCalled "Invoke-ExternalCommand" -Times 3
        Assert-VerifiableMock
    }

    It 'Fails after retry' {
        Mock Invoke-ExternalCommand {
            throw "Failed"
        }
        {
            Get-HelmChart `
                -RegistryPath "SomePath:1.20.3" `
                -ChartExportPath "c:\temp" `
                -HelmClientLocation "fake-helm-client.exe"
            # -KubeConfig `
            # -KubeContext `
            # -NewPath
            # -ChartName = 'azure-arc-k8sagents' `
            # -RetryCount = 5 `
            # -RetryDelay = 3
        } | Should -Throw "Unable to pull 'azure-arc-k8sagents' helm chart from the registry 'SomePath:1.20.3'."
        Assert-MockCalled "Invoke-ExternalCommand" -Times 5
        Assert-VerifiableMock
    }
}
