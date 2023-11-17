### Example 1: Create a CertificateObjectLocalRulestackResource.
```powershell
New-AzPaloAltoNetworksCertificateObjectLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -Name azps-pancor -CertificateSelfSigned 'TRUE'
```

```output
CertificateSelfSigned Name        ProvisioningState ResourceGroupName
--------------------- ----        ----------------- -----------------
TRUE                  azps-pancor Succeeded         azps_test_group_pan
```

Create a CertificateObjectLocalRulestackResource.