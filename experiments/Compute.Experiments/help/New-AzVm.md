---
external help file: AzureRM.Compute.Experiments-help.xml
Module Name: AzureRM.Compute.Experiments
online version:
schema: 2.0.0
---

# New-AzVm

## SYNOPSIS
Creates a virtual machine and all required resources.

## SYNTAX

```
New-AzVm [-Name] <String> [[-Credential] <PSCredential>] [[-ImageName] <String>]
 [[-ResourceGroupName] <String>] [[-Location] <String>] [[-VirtualNetworkName] <String>]
 [[-PublicIpAddressName] <String>] [[-SecurityGroupName] <String>]
```

## DESCRIPTION
The cmdlet creates a virtual machine and all required resources in Azure.

## EXAMPLES

### Example 1
```
PS C:\> New-AzVm -Name MyCoolVM
```

Creates a virtual machine with name `MyCoolVM`.

## PARAMETERS

### -Credential
Specifies the user name and password for the virtual machine as a PSCredential object.

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageName
A name of virtual machine image.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Specifies a location for the virtual machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
A name of a virtual machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIpAddressName
Specifies a name of PublicIPAddress object to assign to a network interface.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityGroupName
Specifies a Network Security Group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkName
Specifies a Virtual Network name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

