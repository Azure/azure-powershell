### Example 1: Create Entity Query
```powershell
PS C:\> $template = Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myEntityQueryTemplateId"
PS C:\> New-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" [-EntityQueryId <String>] -Kind Activity -Title ($template.title) -InputEntityType ($template.inputEntityType) -TemplateName ($template.Name)

{{ Add output here }}
```

This command creates an Entity Query by using a Template.

### Example 2: Create Entity Query
```powershell
PS C:\> New-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityQueryId ((New-Guid).Guid) -Kind Activity -Title 'An account was deleted on this host' -InputEntityType 'Host' -Content "On '{{Computer}}' the account '{{TargetAccount}}' was deleted by '{{AddedBy}}'" -Description "Account deleted on host" -QueryDefinitionQuery 'let GetAccountActions = (v_Host_Name:string, v_Host_NTDomain:string, v_Host_DnsDomain:string, v_Host_AzureID:string, v_Host_OMSAgentID:string){\nSecurityEvent\n| where EventID in (4725, 4726, 4767, 4720, 4722, 4723, 4724)\n// parsing for Host to handle variety of conventions coming from data\n| extend Host_HostName = case(\nComputer has ''@'', tostring(split(Computer, ''@'')[0]),\nComputer has ''\\'', tostring(split(Computer, ''\\'')[1]),\nComputer has ''.'', tostring(split(Computer, ''.'')[0]),\nComputer\n)\n| extend Host_NTDomain = case(\nComputer has ''\\'', tostring(split(Computer, ''\\'')[0]), \nComputer has ''.'', tostring(split(Computer, ''.'')[-2]), \nComputer\n)\n| extend Host_DnsDomain = case(\nComputer has ''\\'', tostring(split(Computer, ''\\'')[0]), \nComputer has ''.'', strcat_array(array_slice(split(Computer,''.''),-2,-1),''.''), \nComputer\n)\n| where (Host_HostName =~ v_Host_Name and Host_NTDomain =~ v_Host_NTDomain) \nor (Host_HostName =~ v_Host_Name and Host_DnsDomain =~ v_Host_DnsDomain) \nor v_Host_AzureID =~ _ResourceId \nor v_Host_OMSAgentID == SourceComputerId\n| project TimeGenerated, EventID, Activity, Computer, TargetAccount, TargetUserName, TargetDomainName, TargetSid, SubjectUserName, SubjectUserSid, _ResourceId, SourceComputerId\n| extend AddedBy = SubjectUserName\n// Future support for Activities\n| extend timestamp = TimeGenerated, HostCustomEntity = Computer, AccountCustomEntity = TargetAccount\n};\nGetAccountActions(''{{Host_HostName}}'', ''{{Host_NTDomain}}'', ''{{Host_DnsDomain}}'', ''{{Host_AzureID}}'', ''{{Host_OMSAgentID}}'')\n \n| where EventID == 4726' -RequiredInputFieldsSet @(@("Host_HostName","Host_NTDomain"),@("Host_HostName","Host_DnsDomain"),@("Host_AzureID"),@("Host_OMSAgentID")) -EntitiesFilter @{"Host_OsFamily" = @("Windows")}

{{ Add output here }}
```

This command creates an Entity Query.

