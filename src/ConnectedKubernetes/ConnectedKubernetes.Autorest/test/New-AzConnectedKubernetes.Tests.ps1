if(($null -eq $TestName) -or ($TestName -contains 'New-AzConnectedKubernetes'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConnectedKubernetes.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
  # !!PDS: Better way to do this?
  . "$PSScriptRoot/../custom/helpers/ConfigDPHelper.ps1"
}

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
    }

    It 'Env access token' {
        $env:AZURE_ACCESS_TOKEN = "This is an access token"
        Mock Invoke-RestMethod {
            $Script:StatusCode = 200
            return 
        }
        { Invoke-ConfigDPHealthCheck } | Should -Not -Throw
    }

    It 'Unhealthy (not 200 response)' {
        Mock Invoke-RestMethod {
            $Script:StatusCode = 500
            return 
        }
        { Invoke-ConfigDPHealthCheck } | Should -Throw "Error while performing DP health check, StatusCode: 500"
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
            $uriParameters = [ordered]@{"key1"="value1"; "key2"="value2"}

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
                authentication = [PSCustomobject]@{
                    loginEndpoint = "https://login.microsoftonline.com"
               }
           }
           $script:configDpEndpoint = Get-ConfigDpDefaultEndpoint `
                -Location "eastus2" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw
        $configDpEndpoint | Should -Be "https://eastus2.dp.kubernetesconfiguration.azure.com"
    }

    # !!PDS: How do we validate this?  Need to check endpoint on a sovereign cloud.
    It 'Soveregn cloud' {
        {
           $cloudMetadata = [PSCustomObject]@{
                authentication = [PSCustomobject]@{
                    loginEndpoint = "https://login.microsoftonline.sovereign.com"
               }
           }
           $script:configDpEndpoint = Get-ConfigDpDefaultEndpoint `
                -Location "westus3" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw
        $configDpEndpoint | Should -Be "https://westus3.dp.kubernetesconfiguration.azure.sovereign.com"
    }
}

Describe 'Get-ConfigDpEndpoint' {
    It 'Golden path' {
        {
            $cloudMetadata = [PSCustomObject]@{
                authentication = [PSCustomobject]@{
                    loginEndpoint = "https://login.microsoftonline.com"
                    audiences = @(
                        "https://management.core.windows.net/"
                        "https://management.azure.com/"
                    )
                }
            }
           $script:configDpEndpoint = Get-ConfigDpEndpoint `
                -Location "eastus2" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw

        $configDpEndpoint.ConfigDpEndpoint | Should -Be "https://eastus2.dp.kubernetesconfiguration.azure.com"
        $configDpEndpoint.ReleaseTrain | Should -Be $null
        $configDpEndpoint.ADResourceId | Should -Be "https://management.core.windows.net/"
    }

    It 'Read ARM metadata' {
        {
            $cloudMetadata = [PSCustomObject]@{
                authentication = [PSCustomobject]@{
                    loginEndpoint = "https://login.microsoftonline.com"
                    audiences = @(
                        "https://management.core.windows.net/"
                        "https://management.azure.com/"
                    )
                }
            }
           $script:configDpEndpoint = Get-ConfigDpEndpoint `
                -Location "eastus2" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw

        $configDpEndpoint.ConfigDpEndpoint | Should -Be "https://eastus2.dp.kubernetesconfiguration.azure.com"
        $configDpEndpoint.ReleaseTrain | Should -Be $null
        $configDpEndpoint.ADResourceId | Should -Be "https://management.core.windows.net/"
    }

    It 'DataPlaneEndpoints, no ArcconfigEndpoints' {
        {
            $cloudMetadata = [PSCustomObject]@{
                dataPlaneEndpoints = [PSCustomobject]@{
                    something = "random"
                }
                authentication = [PSCustomobject]@{
                    loginEndpoint = "https://login.microsoftonline.com"
                    audiences = @(
                        "https://management.core.windows.net/"
                        "https://management.azure.com/"
                    )
                }
            }
           $script:configDpEndpoint = Get-ConfigDpEndpoint `
                -Location "eastus2" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw

        $configDpEndpoint.ConfigDpEndpoint | Should -Be "https://eastus2.dp.kubernetesconfiguration.azure.com"
        $configDpEndpoint.ReleaseTrain | Should -Be $null
        $configDpEndpoint.ADResourceId | Should -Be "https://management.core.windows.net/"
    }

    It 'DataPlaneEndpoints and ArcConfigEndpoint' {
        {
            $cloudMetadata = [PSCustomObject]@{
                dataPlaneEndpoints = [PSCustomobject]@{
                    arcConfigEndpoint = "https://xanadu.dp.kubernetesconfiguration.azure.pleasuredome.com"
                }
                authentication = [PSCustomobject]@{
                    loginEndpoint = "https://login.microsoftonline.com"
                    audiences = @(
                        "https://management.core.windows.net/"
                        "https://management.azure.com/"
                    )
                }
            }
            $script:configDpEndpoint = Get-ConfigDpEndpoint `
                -Location "eastus2" `
                -CloudMetadata $cloudMetadata
        } | Should -Not -Throw

        $configDpEndpoint.ConfigDpEndpoint | Should -Be "https://xanadu.dp.kubernetesconfiguration.azure.pleasuredome.com"
        $configDpEndpoint.ReleaseTrain | Should -Be $null
        $configDpEndpoint.ADResourceId | Should -Be "https://management.core.windows.net/"
    }
}

Describe 'Get-MetaData' {
    It 'Golden path' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Error response' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Exception during REST API.' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

Describe 'Get-ValuesFile' {
    It 'Golden path' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'No values filename' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'No values file' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Starts/ends with quote or double-quote' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

Describe 'Get-HelmValues' {
    It 'Golden path' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Custom release train' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Env access token' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Empty content' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Exception reading content' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}

Describe 'Get-ChartPath' {
    It 'Golden Path' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Cannot clean-up existing chart path' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Pre-onboarding' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }   
}

Describe 'Get-HelmChart' {
    It 'Golden path' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Agent older than 1.14.0' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'NewPath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Has KubeConfig' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Has KubeContext' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Requires retry' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
