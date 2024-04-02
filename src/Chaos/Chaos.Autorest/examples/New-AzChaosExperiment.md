### Example 1: {{ Add title here }}
```powershell
$actionObj = New-AzChaosActionObject -Name "urn:csci:microsoft:virtualMachine:shutdown/1.0" -Type "continuous"
$branchObj = New-AzChaosBranchObject -Action $actionObj -Name "branch1"
$stepObj = New-AzChaosStepObject -Branch $branchObj -Name "step1"
$selectObj = New-AzChaosSelectorObject -Id "selector1" -Type List
New-AzChaosExperiment -Name chaos-experiment -ResourceGroupName azps_test_group_chaos -Location eastus -Selector $selectObj -Step $stepObj
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

{
  "location": "eastus",
  "properties": {
    "steps": [
      {
        "name": "step1",
        "branches": [
          {
            "name": "branch1",
            "actions": [
              {
                "type": "continuous",
                "name": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                "selectorId": "selector1",
                "duration": "PT10M",
                "parameters": [
                  {
                    "key": "abruptShutdown",
                    "value": "false"
                  }
                ]
              }
            ]
          }
        ]
      }
    ],
    "selectors": [
      {
        "type": "List",
        "id": "selector1",
        "targets": [
          {
            "type": "ChaosTarget",
            "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microsoft.Chaos/targets/Microsoft-VirtualMachine"
          }
      }
    ]
  }
}