# EXAMPLES

## Example 1: Get quota information for a specific resource provider
```
Get-AzQuota -ResourceProviderName "Microsoft.Compute" -Location "eastus"
```
This command gets the quota information for the Microsoft.Compute resource provider in the eastus location.

## Example 2: Get quota information for all resource providers in a location
```
Get-AzQuota -Location "eastus"
```
This command gets the quota information for all resource providers in the eastus location.
```

```output
Name            NameLocalizedValue Unit  ETag
----            ------------------ ----  ----
VirtualNetworks Virtual Networks   Count
```

This command gets the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.