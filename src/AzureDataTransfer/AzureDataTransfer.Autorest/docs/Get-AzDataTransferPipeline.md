---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/get-azdatatransferpipeline
schema: 2.0.0
---

# Get-AzDataTransferPipeline

## SYNOPSIS
Gets pipeline resource.

## SYNTAX

### List1 (Default)
```
Get-AzDataTransferPipeline [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataTransferPipeline -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataTransferPipeline -InputObject <IDataTransferIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzDataTransferPipeline -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets pipeline resource.

## EXAMPLES

### Example 1: Get a specified pipeline
```powershell
$pipeline01 = Get-AzDataTransferPipeline -ResourceGroupName ResourceGroup01 -Name Pipeline01
```

```output
Name              : Pipeline01
ResourceGroupName : ResourceGroup01
Status            : Active
```

This example retrieves a specific pipeline named `Pipeline01` within the resource group `ResourceGroup01`.

---

### Example 2: Get a list of pipelines in a resource group
```powershell
$pipelinesInResourceGroup = Get-AzDataTransferPipeline -ResourceGroupName ResourceGroup01
```

```output
Name              : Pipeline01
ResourceGroupName : ResourceGroup01
Status            : Active

Name              : Pipeline02
ResourceGroupName : ResourceGroup01
Status            : Inactive
```

This example retrieves all pipelines in the resource group `ResourceGroup01`.

---

### Example 3: Get a list of pipelines in a subscription
```powershell
$pipelinesInSubscription = Get-AzDataTransferPipeline -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Name              : Pipeline01
ResourceGroupName : ResourceGroup01
Status            : Active

Name              : Pipeline02
ResourceGroupName : ResourceGroup02
Status            : Inactive
```

This example retrieves all pipelines in the subscription with the ID `00000000-0000-0000-0000-000000000000`.

---

## PARAMETERS

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
Type: PrivateADT.Models.IDataTransferIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name for the pipeline that is to be requested.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PipelineName

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List, List1
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

### PrivateADT.Models.IDataTransferIdentity

## OUTPUTS

### PrivateADT.Models.IPipeline

## NOTES

## RELATED LINKS

