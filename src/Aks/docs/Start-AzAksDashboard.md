---
external help file:
Module Name: Az.Aks
online version: https://docs.microsoft.com/en-us/powershell/module/az.aks/start-azaksdashboard
schema: 2.0.0
---

# Start-AzAksDashboard

## SYNOPSIS
Create a Kubectl SSH tunnel to the managed cluster's dashboard.

## SYNTAX

### IdParameterSet (Default)
```
Start-AzAksDashboard [-Id] <String> [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [-DisableBrowser] [-ListenPort <Int32>] [-PassThru] [<CommonParameters>]
```

### InputObjectParameterSet
```
Start-AzAksDashboard [-InputObject] <IAksIdentity> [-SubscriptionId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-DisableBrowser] [-ListenPort <Int32>] [-PassThru]
 [<CommonParameters>]
```

### NameParameterSet
```
Start-AzAksDashboard [-ResourceGroupName] <String> [-Name] <String> [-SubscriptionId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-DisableBrowser] [-ListenPort <Int32>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Kubectl SSH tunnel to the managed cluster's dashboard.

## EXAMPLES

### Example 1: 
```powershell
PS C:\> Start-AzAksDashboard -ResourceGroupName group -Name myCluster

```

Start an SSH tunnel and open a browser to the Kubernetes dashboard

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DisableBrowser
Do not pop open a browser after establishing the kubectl port-forward.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Id of a managed Kubernetes cluster

```yaml
Type: System.String
Parameter Sets: IdParameterSet
Aliases: ResourceId

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
A IAksIdentity object, normally passed through the pipeline.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ListenPort
The listening port for the dashboard.
Default value is 8003.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of your managed Kubernetes cluster

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Resource group name

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.custom.KubeTunnelJob

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IAksIdentity>: A IAksIdentity object, normally passed through the pipeline.
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[Id <String>]`: Resource identity path
  - `[Name <String>]`: The name of the managed cluster resource.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[RoleName <String>]`: The name of the role for managed cluster accessProfile resource.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

