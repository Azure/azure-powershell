### Example 1: support info for rulestack.
```powershell
Get-AzPaloAltoNetworksLocalRulestackSupportInfo -LocalRulestackName azps-panlr -ResourceGroupName azps_test_group_pan
```

```output
AccountId AccountRegistered FreeTrial FreeTrialCreditLeft FreeTrialDaysLeft HelpUrl                ProductSerial ProductSku  RegisterUrl
--------- ----------------- --------- ------------------- ----------------- -------                ------------- ----------  -----------
          FALSE             FALSE     0                   0                 https://live.paloalto… PAN-CLOUD-NGFW-AZURE-PAYG https://support.palo…
```

support info for rulestack.