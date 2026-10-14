Describe 'ApiUpgrade.Unit' {
    It 'Exposes and serializes custom server TLS groups including PQC' {
        $tls = New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject `
            -CertificateType ManagedCertificate -ServerTlsGroupPolicy Custom `
            -ServerTlsGroup X25519MLKEM768, SecP256r1MLKEM768
        $json = $tls.ToJsonString() | ConvertFrom-Json
        $json.serverTlsGroupPolicy | Should Be 'Custom'
        $json.serverTlsGroups.Count | Should Be 2
        $json.serverTlsGroups[0] | Should Be 'X25519MLKEM768'
        $json.serverTlsGroups[1] | Should Be 'SecP256r1MLKEM768'
    }

    It 'Preserves mTLS creation and update parameters and serialization' {
        foreach ($name in @('New-AzFrontDoorCdnCustomDomain', 'Update-AzFrontDoorCdnCustomDomain')) {
            (Get-Command $name).Parameters.ContainsKey('MtlSettingScenario') | Should Be $true
        }
        $mtls = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AfdDomainMtlsParameters]::new()
        $mtls.Scenario = 'ClientCertificateRequiredAndValidated'
        ($mtls.ToJsonString() | ConvertFrom-Json).scenario | Should Be 'ClientCertificateRequiredAndValidated'
    }

    It 'Preserves MSI token destination headers in origin authentication' {
        foreach ($name in @('New-AzFrontDoorCdnOriginGroup', 'Update-AzFrontDoorCdnOriginGroup')) {
            (Get-Command $name).Parameters.ContainsKey('AuthenticationTokenDestinationHeader') | Should Be $true
        }
        $authentication = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.OriginAuthenticationProperties]::new()
        $authentication.Type = 'SystemAssignedIdentity'
        $authentication.Scope = 'https://storage.azure.com/.default'
        $authentication.TokenDestinationHeader = 'X-Origin-Authorization'
        $json = $authentication.ToJsonString() | ConvertFrom-Json
        $json.type | Should Be 'SystemAssignedIdentity'
        $json.tokenDestinationHeader | Should Be 'X-Origin-Authorization'
        $json.scope | Should Be 'https://storage.azure.com/.default'
    }

    It 'Preserves profile-level and route-level WAF policy settings' {
        $route = New-AzFrontDoorCdnResourceReferenceObject -Id '/subscriptions/offline/resourceGroups/offline/providers/Microsoft.Cdn/profiles/offline/afdEndpoints/endpoint/routes/route'
        $association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject `
            -PatternsToMatch '/*' -Route $route
        $parameters = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject `
            -IsProfileLevel $true -Association $association `
            -WafPolicyId '/subscriptions/offline/resourceGroups/offline/providers/Microsoft.Network/frontDoorWebApplicationFirewallPolicies/offline'
        $json = $parameters.ToJsonString() | ConvertFrom-Json
        $json.isProfileLevel | Should Be $true
        $json.associations[0].routes[0].id | Should Be $route.Id
        $json.associations[0].patternsToMatch[0] | Should Be '/*'
        $json.wafPolicy.id | Should Match '/frontDoorWebApplicationFirewallPolicies/offline$'
    }

    It 'Exposes and serializes origin certificate subject validation' {
        foreach ($name in @('New-AzFrontDoorCdnOrigin', 'Update-AzFrontDoorCdnOrigin')) {
            $command = Get-Command $name
            $command.Parameters.ContainsKey('CertificateNameCheckValidationMode') | Should Be $true
            $command.Parameters.ContainsKey('CustomCertificateSubject') | Should Be $true
        }
        $origin = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AfdOrigin]::new()
        $origin.HostName = 'origin.contoso.com'
        $origin.EnforceCertificateNameCheck = $true
        $origin.CertificateNameCheckValidationMode = 'CustomCertificateSubject'
        $origin.CustomCertificateSubject = @('origin.contoso.com', '*.contoso.com')
        $json = $origin.ToJsonString() | ConvertFrom-Json
        $json.properties.enforceCertificateNameCheck | Should Be $true
        $json.properties.certificateNameCheckValidationMode | Should Be 'CustomCertificateSubject'
        $json.properties.customCertificateSubjects.Count | Should Be 2
        $json.properties.customCertificateSubjects[1] | Should Be '*.contoso.com'
    }

    It 'Retains URL signing object cmdlets' {
        foreach ($name in @('New-AzCdnUrlSigningActionObject',
                'New-AzFrontDoorCdnRuleUrlSigningActionObject',
                'New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject')) {
            (Get-Command $name -Module Az.Cdn -ErrorAction Stop).Name | Should Be $name
        }
    }

    It 'Retains all standalone EdgeAction cmdlets in the preview module' {
        @(Get-Command -Module Az.Cdn | Where-Object Name -Match '-AzCdnEdgeAction').Count | Should Be 16
    }

    It 'Exposes gRPC in all expanded route creation parameter sets' {
        $command = Get-Command New-AzFrontDoorCdnRoute
        foreach ($setName in @('CreateExpanded', 'CreateViaIdentityAfdEndpointExpanded', 'CreateViaIdentityProfileExpanded')) {
            $set = $command.ParameterSets | Where-Object Name -EQ $setName
            $set.Parameters.Name -contains 'GrpcState' | Should Be $true
        }
        (Get-Command Update-AzFrontDoorCdnRoute).Parameters.ContainsKey('GrpcState') | Should Be $true
        $route = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Route]::new()
        $route.GrpcState = 'Enabled'
        ($route.ToJsonString() | ConvertFrom-Json).properties.grpcState | Should Be 'Enabled'
    }

    It 'Serializes gRPC health probes through both public object helpers' {
        foreach ($name in @('New-AzCdnHealthProbeParametersObject', 'New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject')) {
            $probe = & $name -ProbeProtocol Grpc -ProbePath '/grpc.health.v1.Health/Check'
            $json = $probe.ToJsonString() | ConvertFrom-Json
            $json.probeProtocol | Should Be 'Grpc'
            $json.probePath | Should Be '/grpc.health.v1.Health/Check'
        }
    }

    It 'Serializes capacity-based load balancing through the public object helper' {
        $settings = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject `
            -CapacityDistributionSetting @{ DistributionType = 'DynamicWeights'; CapacityConsciousThreshold = 80 }
        $json = $settings.ToJsonString() | ConvertFrom-Json
        $json.capacityDistributionSettings.distributionType | Should Be 'DynamicWeights'
        $json.capacityDistributionSettings.capacityConsciousThreshold | Should Be 80
    }

    Context 'Custom route parameter forwarding' {
        $parseErrors = $null
        $wrapperAst = [System.Management.Automation.Language.Parser]::ParseFile(
            (Join-Path $PSScriptRoot '../custom/New-AzFrontDoorCdnRoute.ps1'), [ref]$null, [ref]$parseErrors)
        if ($parseErrors) { throw $parseErrors[0] }
        $functionAst = $wrapperAst.Find({
            param($node)
            $node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and
                $node.Name -eq 'New-AzFrontDoorCdnRoute'
        }, $true)
        $forwardingCall = 'Az.Cdn.internal\New-AzFrontDoorCdnRoute @PSBoundParameters'
        if (-not $functionAst.Extent.Text.Contains($forwardingCall)) {
            throw 'The route wrapper no longer uses the expected forwarding call.'
        }
        $wrapper = $functionAst.Extent.Text.Replace(
            'function New-AzFrontDoorCdnRoute', 'function Invoke-TestRouteForwarding').Replace(
            $forwardingCall, '@{} + $PSBoundParameters')
        . ([scriptblock]::Create($wrapper))

        It 'Forwards explicit gRPC values through every expanded parameter set' {
            foreach ($path in @(
                    @{ ResourceGroupName = 'offline'; ProfileName = 'profile'; EndpointName = 'endpoint' },
                    @{ AfdEndpointInputObject = @{ Id = '/subscriptions/offline/resourceGroups/offline/providers/Microsoft.Cdn/profiles/profile/afdEndpoints/endpoint' } },
                    @{ ProfileInputObject = @{ Id = '/subscriptions/offline/resourceGroups/offline/providers/Microsoft.Cdn/profiles/profile' }; EndpointName = 'endpoint' })) {
                foreach ($value in @('Enabled', 'Disabled')) {
                    $parameters = Invoke-TestRouteForwarding @path -Name route -GrpcState $value
                    $parameters['GrpcState'] | Should Be $value
                    $parameters['Name'] | Should Be 'route'
                }
            }
        }

        It 'Preserves compression defaults while forwarding gRPC' {
            $parameters = Invoke-TestRouteForwarding -ResourceGroupName offline -ProfileName profile `
                -EndpointName endpoint -Name route -GrpcState Enabled -CompressionSettingIsCompressionEnabled
            $parameters['GrpcState'] | Should Be 'Enabled'
            $parameters['CompressionSettingContentTypesToCompress'] -contains 'application/json' | Should Be $true
        }

        It 'Does not add a gRPC value when the caller omits it' {
            $parameters = Invoke-TestRouteForwarding -ResourceGroupName offline -ProfileName profile `
                -EndpointName endpoint -Name route
            $parameters.ContainsKey('GrpcState') | Should Be $false
        }
    }
}
