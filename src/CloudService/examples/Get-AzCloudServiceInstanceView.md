### Example 1: Get cloud service instance view

TODO: Update output

```powershell
PS C:\> Get-AzCloudServiceInstanceView -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS" | Format-List

RoleInstanceStatusesSummary : {{
                                "code": "ProvisioningState/succeeded",
                                "count": 4
                              }, {
                                "code": "PowerState/started",
                                "count": 4
                              }}
Statuses                    : {{
                                "code": "ProvisioningState/succeeded",
                                "displayStatus": "Provisioning succeeded",
                                "level": "Info",
                                "time": "2020-10-20T13:13:45.0067685Z"
                              }, {
                                "code": "PowerState/started",
                                "displayStatus": "Started",
                                "level": "Info",
                                "time": "2020-10-20T13:13:45.0067685Z"
                              }, {
                                "code": "CurrentUpgradeDomain/-1",
                                "displayStatus": "Current Upgrade Domain of cloud service is -1.",
                                "level": "Info"
                              }, {
                                "code": "MaxUpgradeDomain/1",
                                "displayStatus": "Max Upgrade Domain of cloud service is 1.",
                                "level": "Info"
                              }}
```

This cmdlet gets the instance view of the cloud service named ContosoCS that belongs to the resource group named ContosOrg.
