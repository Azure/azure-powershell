### Example 1: Create an in-memory object for ResponseBasedOriginErrorDetectionParameters
```powershell
New-AzCdnResponseBasedOriginErrorDetectionParametersObject -ResponseBasedDetectedErrorType testDetctedError -ResponseBasedFailoverThresholdPercentage 6 
```

```output
ResponseBasedDetectedErrorType ResponseBasedFailoverThresholdPercentage
------------------------------ ----------------------------------------
testDetctedError               6
```

Create an in-memory object for ResponseBasedOriginErrorDetectionParameters