---
external help file: Microsoft.Azure.Commands.ResourceManager.Automation.dll-Help.xml
ms.assetid: 32CF9BF7-519F-4B5D-9F2B-3CC556A77A48
online version: 
schema: 2.0.0
---

# Start-AzureRmAutomationDscNodeConfigurationDeployment

## SYNOPSIS
Deploys a DSC Node configuration in Automation.

## SYNTAX

```
Start-AzureRmAutomationDscNodeConfigurationDeployment -NodeConfigurationName <String> -NodeNames <Array> [-ResourceGroupName] <String> [-AutomationAccountName] <String> [-Schedule <Schedule>] [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureRmAutomationDscNodeConfigurationDeployment** cmdlet deployes a Desired State Configuration (DSC) node configuration in Azure Automation.

## EXAMPLES

### Example 1: Deploy an Azure DSC node configuration in Automation 
```
PS C:\> $pilot = @("WebServerPilot1", "WebServerPilot2")
PS C:\> $prod = @("WebServerProd1", "WebServerProd2")
PS C:\> $nodes = @($pilot, $prod)
PS C:\> Start-AzureRmAutomationDscNodeConfigurationDeployment `
            -NodeConfigurationName "Config01.Node1" `
            -AutomationAccountName "Contoso01"  `
            -ResourceGroupName "ResourceGroup01" `
            -NodeName $nodes `

Starting a node configuration deployment.
Starting a node configuration deployment. It will override any existing node configurations assigned to the node.
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): Yes

ResourceGroupName     : ResourceGroup01
AutomationAccountName : Contoso01
JobId                 : 35b14eb4-52b7-4a1d-ad62-8e9f84adc657
Job                   : Microsoft.Azure.Commands.Automation.Model.Job
JobStatus             : New
NodeStatus            :
NodeConfigurationName : Config01.Node1
JobSchedule           :
JobScheduleId         : 00000000-0000-0000-0000-000000000000
```

The above command deploys the DSC node configuration named "Config01.Node1" to the given two-dimensional array of Node Names. The deployment happens in a staged manner.

### Example 2: Schedule an Azure DSC node configuration deployment in Automation
```
PS C:\> $sched = New-AzureRmAutomationSchedule -AutomationAccountName "Contoso01" `
            -ResourceGroupName "ResourceGroup01" `
            -Name "TestSchedule" `
            -StartTime "23:00" `
            -OneTime
PS C:\> $pilot = @("WebServerPilot1", "WebServerPilot2")
PS C:\> $prod = @("WebServerProd1", "WebServerProd2")
PS C:\> $nodes = @($pilot, $prod)
PS C:\> Start-AzureRmAutomationDscNodeConfigurationDeployment `
            -NodeConfigurationName "Config01.Node1" `
            -AutomationAccountName "Contoso01"  `
            -ResourceGroupName "ResourceGroup01" `
            -NodeName $nodes `
            -Schedule $sched

Starting a node configuration deployment.
Starting a node configuration deployment. It will override any existing node configurations assigned to the node.
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): Y

ResourceGroupName     : ResourceGroup01
AutomationAccountName : Contoso01
JobId                 : 00000000-0000-0000-0000-000000000000
Job                   :
JobStatus             :
NodeStatus            :
NodeConfigurationName : Config01.Node1
JobSchedule           : Microsoft.Azure.Commands.Automation.Model.JobSchedule
JobScheduleId         : 2b1d7738-093d-4ff7-b87b-e4b2321319e5

```

The above command schedules a deployment of a DSC node configuration named "Config01.Node1" to the given two-dimensional array of Node Names. The deployment happens in a staged manner and will be executed based on the schedule.

## PARAMETERS

### -ResourceGroupName
Specifies the name of a resource group in which this cmdlet compiles a configuration.

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

### -AutomationAccountName
Specifies the name of the Automation account that contains the DSC configuration that this cmdlet compiles.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByInputObject)
Accept wildcard characters: False
```

### -NodeConfigurationName
Specifies the name of the DSC node configuration that this cmdlet deploys.

```yaml
Type: String
Parameter Sets: (All, ByInputObject)
Aliases: Name

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NodeName
Specifies the names of the nodes to which the Node Configuration would be deployed to.

```yaml
Type: Array
Parameter Sets: (All, ByInputObject)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Schedule
Automation Schedule object to schedule the deployment job.

```yaml
Type: Schedule
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
ps_force

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.NodeConfigurationDeployment

## NOTES

## RELATED LINKS

[Start-AzureRmAutomationDscCompilationJob](./Start-AzureRmAutomationDscCompilationJob.md)

[Import-AzureRmAutomationDscNodeConfiguration](./Import-AzureRmAutomationDscNodeConfiguration.md)

[Stop-AzureRmAutomationDscNodeConfigurationDeployment](./Stop-AzureRmAutomationDscNodeConfigurationDeployment.md)

[Get-AzureRmAutomationDscNodeConfigurationDeployment](./Get-AzureRmAutomationDscNodeConfigurationDeployment.md)

[Get-AzureRmAutomationDscNodeConfigurationDeploymentSchedule](./Get-AzureRmAutomationDscNodeConfigurationDeploymentSchedule.md)

[New-AzureRmAutomationSchedule](./New-AzureRmAutomationSchedule.md)