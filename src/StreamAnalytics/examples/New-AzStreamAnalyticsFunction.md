### Example 1: Create a Stream Analytics function
```powershell
New-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name function-01 -File .\test\template-json\Function_JavascriptUdf.json
```
```output
Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 7bbd6ccd-c7a4-4910-b2ae-a3eae19d9b18

```

This command creates a function from the file Function_JavascriptUdf.json.

(below is an example for "Function_JavascriptUdf.json")
{
  "properties": {
    "type": "Scalar",
    "properties": {
      "inputs": [
        {
          "dataType": "any"
        },
        {
          "dataType": "any"
        }
      ],
      "output": {
        "dataType": "any"
      },
      "binding": {
        "type": "Microsoft.StreamAnalytics/JavascriptUdf",
        "properties": {
          "script": "// Sample UDF which returns sum of two values.\nfunction main(arg3, arg4) {\n    return arg1 + arg2;\n}"
        }
      }
    }
  }
}

### Example 2: Create a Stream Analytics function
```powershell
New-AzStreamAnalyticsFunction -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name function-01 -File .\test\template-json\MachineLearningServices.json
```
```output
Name        Type                                              ETag
----        ----                                              ----
function-01 Microsoft.StreamAnalytics/streamingjobs/functions 7bbd6ccd-c7a4-4910-b2ae-a3eae19d9b18
```

This command creates a function from the file MachineLearningServices.json.

(below is an example for "MachineLearningServices.json")
{
  "properties": {
    "type": "Scalar",
    "properties": {
      "inputs": [
        {
          "dataType": "record"
        }
      ],
      "output": {
        "dataType": "bigint"
      },
      "binding": {
        "type": "Microsoft.MachineLearningServices",
        "properties": {
          "endpoint": "http://xxxxxxxxxxxxxxxxxxx.eastus.azurecontainer.io/score",
          "inputs": [
            {
              "name": "data",
              "dataType": "object",
              "mapTo": 0
            }
          ],
          "outputs": [
            {
              "name": "output",
              "dataType": "int64",
              "mapTo": 0
            }
          ],
          "batchSize": 10000,
          "numberOfParallelRequests": 1
        }
      }
    }
  }
}