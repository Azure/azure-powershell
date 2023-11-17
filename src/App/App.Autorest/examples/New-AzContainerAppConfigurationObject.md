### Example 1: Create an in-memory object for Configuration.
```powershell
$customDomain = New-AzContainerAppCustomDomainObject -Name "www.my-name.com" -BindingType "SniEnabled" -CertificateId "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/managedEnvironments/{manageEnvName}/certificates/{testcert}"
$trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -RevisionName "testcontainerApp0-ab1234" -Weight 100
$iPSecurityRestrictionRule = New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"

New-AzContainerAppConfigurationObject -IngressCustomDomain $customDomain -IngressIPSecurityRestriction $iPSecurityRestrictionRule -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 3000 -IngressClientCertificateMode "accept" -CorPolicyAllowedOrigin "https://a.test.com","https://b.test.com" -CorPolicyAllowedMethod "GET","POST" -CorPolicyAllowedHeader "HEADER1","HEADER2" -CorPolicyExposeHeader "HEADER3","HEADER4" -CorPolicyMaxAge 1234 -CorPolicyAllowCredentials:$True -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -IngressTransport "http"
```

```output
ActiveRevisionsMode MaxInactiveRevision
------------------- -------------------
                    10
```

Create an in-memory object for Configuration.