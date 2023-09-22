### Example 1: Get a diagnostics result of a Container App.
```powershell
Get-AzContainerAppDiagnosticDetector -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
```

```output
Name                                 ResourceGroupName
----                                 -----------------
AutoScalingErrors                    azps_test_group_app
clustersubnet                        azps_test_group_app
cappconfigandmanagement              azps_test_group_app
cappContainerAppAvailabilityDetector azps_test_group_app
cappcontainerappcpu                  azps_test_group_app
cappContainerAppAvailabilityMetrics  azps_test_group_app
cappcontainerappclustercreation      azps_test_group_app
cappcontainerappmemory               azps_test_group_app
cappcontainerappnetworkusage         azps_test_group_app
ContainerAppsRevisionComparsion      azps_test_group_app
ContainerAppEnvironmentEvents        azps_test_group_app
containerenvinsights                 azps_test_group_app
DaprInsights                         azps_test_group_app
cappdeploymentFailures               azps_test_group_app
EasyAuthConfigurationErrors          azps_test_group_app
cappcontainerapprevisions            azps_test_group_app
snatusage                            azps_test_group_app
cappcertificates                     azps_test_group_app
```

Get a diagnostics result of a Container App.