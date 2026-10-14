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

    It 'Does not export the removed standalone EdgeAction cmdlets in the stable module' {
        @(Get-Command -Module Az.Cdn | Where-Object Name -Match '-AzCdnEdgeAction').Count | Should Be 0
    }
}
