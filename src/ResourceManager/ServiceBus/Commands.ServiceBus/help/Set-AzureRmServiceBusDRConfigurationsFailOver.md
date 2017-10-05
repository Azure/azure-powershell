---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version: 
schema: 2.0.0
---

# Set-AzureRmServiceBusDRConfigurationsFailOver

## SYNOPSIS
Envokes GEO DR failover and reconfigure the alias to point to the secondary namespace

## SYNTAX

```
Set-AzureRmServiceBusDRConfigurationsFailOver [-ResourceGroupName] <String> [-NamespaceName] <String>
 [-Name] <String> [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The **Set-AzureRmServiceBusDRConfigurationsFailOver** cmdlet envokes GEO DR failover and reconfigure the alias to point to the secondary namespace

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmServiceBusDRConfigurationsFailOver -ResourceGroupName "SampleResourceGroup" -NamespaceName "SampleNamespace_Secondary" -Name "SampleDRCongifName"
```

Envokes the Failover over alias "SampleDRCongifName", reconfigures and point to Secondary namespace "SampleNamespace_Secondary"

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
DR Configuration Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NamespaceName
Namespace Name - Secondary Namespace

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

