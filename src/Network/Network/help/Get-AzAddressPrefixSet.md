---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azaddressprefixset
schema: 2.0.0
---

# Get-AzAddressPrefixSet

## SYNOPSIS
Gets address prefix sets associated with an application security group.

## SYNTAX

### ByApplicationSecurityGroupName (Default)
```
Get-AzAddressPrefixSet -ResourceGroupName <String> -ApplicationSecurityGroupName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByApplicationSecurityGroupObject
```
Get-AzAddressPrefixSet -ApplicationSecurityGroup <PSApplicationSecurityGroup> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByApplicationSecurityGroupResourceId
```
Get-AzAddressPrefixSet -ApplicationSecurityGroupResourceId <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets a specific address prefix set, or lists all address prefix sets under an application security group when `Name` is omitted.

## EXAMPLES

### Example 1: Get an address prefix set by name
```powershell
Get-AzAddressPrefixSet -ResourceGroupName "test-rg" -ApplicationSecurityGroupName "test-asg" -Name "test-prefix-set"
```

Gets the address prefix set named `test-prefix-set` from the specified application security group.

### Example 2: List address prefix sets by using an application security group object
```powershell
$asg = Get-AzApplicationSecurityGroup -ResourceGroupName "test-rg" -Name "test-asg"
$asg | Get-AzAddressPrefixSet
```

Lists all address prefix sets under the application security group.

## PARAMETERS

### -ApplicationSecurityGroup
The application security group.

```yaml
Type: PSApplicationSecurityGroup
Parameter Sets: ByApplicationSecurityGroupObject
Aliases: ParentObject

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ApplicationSecurityGroupName
The application security group name.

```yaml
Type: String
Parameter Sets: ByApplicationSecurityGroupName
Aliases: ParentName, ParentResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationSecurityGroupResourceId
The application security group resource ID.

```yaml
Type: String
Parameter Sets: ByApplicationSecurityGroupResourceId
Aliases: ParentResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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
The address prefix set name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName, AddressPrefixSetName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByApplicationSecurityGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationSecurityGroup

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAddressPrefixSet

## NOTES

## RELATED LINKS
