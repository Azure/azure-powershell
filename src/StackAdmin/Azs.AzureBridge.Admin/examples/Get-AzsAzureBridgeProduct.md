## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsAzureBridgeProduct -ActivationName 'myActivation' -ResourceGroupName 'activationRG'
```

Get a list of Products available for download from Azure Marketplace.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsAzureBridgeProduct -ActivationName 'myActivation' -ResourceGroupName 'activationRG' -Name 'microsoft.docker-arm.1.1.0'
```

Get a product info available for download from Azure Marketplace by Name.