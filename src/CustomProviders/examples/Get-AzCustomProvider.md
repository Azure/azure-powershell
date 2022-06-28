### Example 1: List all Custom Providers in a subscription
```powershell
Get-AzCustomProvider
```

```output
Location  Name             Type
--------  ----             ----
West US 2 Namespace.Type   Microsoft.CustomProviders/resourceproviders
East US 2 Namespace2.Type  Microsoft.CustomProviders/resourceproviders
```

Lists all the custom providers in a subscription

### Example 2: Get a single custom provider
```powershell
Get-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type | Format-List
```

```output
Action            :
Id                : /subscriptions/xxxxx-yyyyy-xxxx-yyyy/resourceGroups/mc-cp01/providers/Microsoft.CustomProviders/resourceproviders/Namespace.Type
Location          : West US 2
Name              : Namespace.Type
ProvisioningState : Succeeded
ResourceType      : {CustomRoute1, associations}
Tag               : Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ResourceTags
Type              : Microsoft.CustomProviders/resourceproviders
Validation        :

```

Gets details for a single custom provider.  Use Format-List to show object details on the screen.

