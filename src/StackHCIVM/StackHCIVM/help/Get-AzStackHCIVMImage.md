---
external help file: Az.StackHCIVM-help.xml
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmimage
schema: 2.0.0
---

# Get-AzStackHCIVMImage

## SYNOPSIS
Gets a gallery image

## SYNTAX

### BySubscription (Default)
```
Get-AzStackHCIVMImage [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-NoWait]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByName
```
Get-AzStackHCIVMImage [-SubscriptionId <String[]>] -Name <String> -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [-NoWait] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByResourceGroup
```
Get-AzStackHCIVMImage [-SubscriptionId <String[]>] -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [-NoWait] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzStackHCIVMImage [-SubscriptionId <String[]>] -ResourceId <String> [-DefaultProfile <PSObject>] [-NoWait]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets a gallery image

## EXAMPLES

### Example 1:  Get an Image
```powershell
Get-AzStackHCIVMImage -Name "testimage" -ResourceGroupName "test-rg"
```

```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```

This command gets a specific image in the specified resource group.

### Example 2: List all Images in a Resource Group
```powershell
Get-AzStackHCIVMImage -ResourceGroupName 'test-rg'
```

```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```

This command lists all images in the specified resource group.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Name
Name of the image

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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
Parameter Sets: ByName, ByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM Resource Id of the Image

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImages

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImages

## NOTES

## RELATED LINKS
