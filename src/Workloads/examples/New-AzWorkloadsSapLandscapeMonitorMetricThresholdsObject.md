### Example 1: Create a new Metrics Threshold for SAP Landscape Monitor
```powershell
New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject -Green 90 -Name X00 -Red 50 -Yellow 80
```

```output
Green Name Red Yellow
----- ---- --- ------
90    X00  50  80

```

Create a new Metrics Threshold object to be used for creating a SAP Landscape Monitor
