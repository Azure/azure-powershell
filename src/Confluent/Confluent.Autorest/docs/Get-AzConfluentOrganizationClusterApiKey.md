---
external help file:
Module Name: Az.Confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/get-azconfluentorganizationclusterapikey
schema: 2.0.0
---

# Get-AzConfluentOrganizationClusterApiKey

## SYNOPSIS
Get API key details of a kafka or schema registry cluster

## SYNTAX

### Get (Default)
```
Get-AzConfluentOrganizationClusterApiKey -ApiKeyId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConfluentOrganizationClusterApiKey -InputObject <IConfluentIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzConfluentOrganizationClusterApiKey -ApiKeyId <String> -OrganizationInputObject <IConfluentIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get API key details of a kafka or schema registry cluster

## EXAMPLES

### Example 1: List all cluster API keys
```powershell
Get-AzConfluentOrganizationClusterApiKey -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -ClusterId lkc-abc123
```

```output
Id          Name              ClusterId    Owner
--          ----              ---------    -----
key-123     prod-api-key      lkc-abc123   User:u-123
key-456     staging-api-key   lkc-abc123   User:u-456
```

This command lists all API keys for the specified Kafka cluster.

### Example 2: Get specific API key by cluster
```powershell
Get-AzConfluentOrganizationClusterApiKey -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -ClusterId lkc-abc123
```

This command retrieves API keys associated with a specific cluster.

## PARAMETERS

### -ApiKeyId
Confluent API Key id

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
Parameter Sets: GetViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IApiKeyRecord

## NOTES

## RELATED LINKS

