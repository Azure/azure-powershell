### Example 1: Add Tags to a custom Provider
```powershell
Update-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type -Tag @{MyTag="MyValue"} | Format-List
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

Update the tags of a custom provider.

### Example 2: Update custom provider with piping
```powershell
Get-AzCustomProvider -ResourceGroupName myRg -Name Namespace.Type | Update-AzCustomProvider -Tag @{MyTag="MyValue"}
```

```output
Location  Name             Type
--------  ----             ----
West US 2 Namespace.Type   Microsoft.CustomProviders/resourceproviders
```

Update a custom provider using piping.

