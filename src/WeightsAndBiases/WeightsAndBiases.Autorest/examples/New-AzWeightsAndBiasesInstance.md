### Example 1: {{ Add title here }}
```powershell
New-AzWeightsAndBiasesInstance -Name "test-cli-instance-1" -Location "East US" -ResourceGroupName "clitest" -SubscriptionId "fc35d936-3b89-41f8-8110-a24b56826c37" -MarketplaceSubscriptionId  "fc35d936-3b89-41f8-8110-a24b56826c37" -OfferDetailOfferId "wandb_liftr" -OfferDetailPlanId "liftr0plan" -OfferDetailPlanName "WandB Liftr" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "weightsandbiasesinc1641502883483" -OfferDetailTermId "gmz7xq9ge3py" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "aggarwalsw@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "aggarwalsw@microsoft.com"
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

This command creates a new resource for Weights and Biases Instance.

