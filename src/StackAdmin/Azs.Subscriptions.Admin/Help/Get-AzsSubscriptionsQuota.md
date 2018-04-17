---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Get-AzsSubscriptionsQuota

## SYNOPSIS
Get the list of subscription resource provider quotas at a location.

## SYNTAX

### List (Default)
```
Get-AzsSubscriptionsQuota [-Location <String>] [<CommonParameters>]
```

### Get
```
Get-AzsSubscriptionsQuota -Name <String> [-Location <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsSubscriptionsQuota -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Get the list of quotas at a location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsSubscriptionsQuota
```

AllowCustomPortalBranding : False
Id                        : /subscriptions/0a823c45-d9e7-4812-a138-74e22213693a/providers/Microsoft.Subscriptions.Admin/locations/local/quotas/delegatedProviderQuota
Name                      : local/delegatedProviderQuota
Type                      : Microsoft.Subscriptions.Admin/locations/quotas
Location                  : local
Tags                      :
...

Get the list of subscription resource provider quotas at a location.

## PARAMETERS

### -Location
The AzureStack location.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the quota.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Quota

## NOTES

## RELATED LINKS

