### Example 1: Update a Windows Virtual Desktop HostPool by name
```powershell
Update-AzWvdHostPool -ResourceGroupName ResourceGroupName `
                            -Name HostPoolName `
                            -LoadBalancerType 'BreadthFirst' `
                            -Description 'Description' `
                            -FriendlyName 'Friendly Name' `
                            -MaxSessionLimit 6 `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false `
                            -AgentUpdateMaintenanceWindow @(
                                @{
                                    'offPeakStartTime'  = @{
                                                            'hour' = 18
                                                            'minute' = 0
                                                        }
                                }
                            ) `
                            -AgentUpdateMaintenanceWindowTimeZone 'Alaskan Standard Time' `
                            -AgentUpdateType 'Scheduled' `
                            -useSessionHostLocalTime $false
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools
```

This command updates a Windows Virtual Desktop HostPool in a Resource Group.

