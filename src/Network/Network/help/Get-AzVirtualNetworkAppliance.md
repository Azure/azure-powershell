---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# Get-AzVirtualNetworkAppliance

## SYNOPSIS
Gets a Virtual Network Appliance (VNA) resource.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Get-AzVirtualNetworkAppliance [-Name <String>] [-ResourceGroupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzVirtualNetworkAppliance -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzVirtualNetworkAppliance cmdlet retrieves a Virtual Network Appliance resource. 
You can get a specific VNA by name and resource group, by resource ID, or list all VNAs in a resource group or subscription.

## EXAMPLES

### Example 1: Get a VNA by name
```powershell
Get-AzVirtualNetworkAppliance -Name "myVNA" -ResourceGroupName "myResourceGroup"
```

Gets a Virtual Network Appliance named "myVNA" in the resource group "myResourceGroup".

### Example 2: List all VNAs in a resource group
```powershell
Get-AzVirtualNetworkAppliance -ResourceGroupName "myResourceGroup"
```

Lists all Virtual Network Appliances in the specified resource group.

### Example 3: Get a VNA by resource ID
```powershell
Get-AzVirtualNetworkAppliance -ResourceId "/subscriptions/xxx/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworkAppliances/myVNA"
```

Gets a Virtual Network Appliance by its Azure resource ID.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: ResourceNameParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource Id.

```yaml
Type: String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkAppliance

## NOTES

## RELATED LINKS
