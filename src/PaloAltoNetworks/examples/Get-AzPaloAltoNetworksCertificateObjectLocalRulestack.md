### Example 1: List CertificateObjectLocalRulestackResource by LocalRulestackName.
```powershell
Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr
```

```output
CertificateSelfSigned Name        ProvisioningState ResourceGroupName
--------------------- ----        ----------------- -----------------
TRUE                  azps-pancor Succeeded         azps_test_group_pan
```

List CertificateObjectLocalRulestackResource by LocalRulestackName.

### Example 2: Get a CertificateObjectLocalRulestackResource by name.
```powershell
Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -Name azps-pancor
```

```output
CertificateSelfSigned Name        ProvisioningState ResourceGroupName
--------------------- ----        ----------------- -----------------
TRUE                  azps-pancor Succeeded         azps_test_group_pan
```

Get a CertificateObjectLocalRulestackResource by name.