The session integration account artifact is unique amongst the rest of the artifacts. It is a byproduct of connecting 2 partners with an agreement and sending a message from partner 1 to partner 2. The session is required for the ReceivedIcn and GeneratedIcn tests.

## Regenerate Sessions Using Existing Logic App
There should be a Logic App already in the location specified by the test constants. If it is still there, all you need to do is trigger the run and it should create everything that is needed. If it isn't there and the sessions don't exist, you'll need to create the Logic App yourself.

## How to Create a new Logic App to generate Sessions

1. Create an Integration Account
2. Create 2 partners. Use the ZZ qualifier and give each partner a different value. You can use "ZZ" for one and "AA" for the other as an example
3. Create an X12 agreement
4. Create an Edifact agreement
5. Create a Logic App in the same sub, resource group, and location to keep things tidy
6. Add a Request trigger
7. Add a "Add X12 Control Numbers" action (name might not be exact). You might need to recreate the connection as well. Fill out the data in the action to match the data expected in the test. You might want to rename the action to keep it clear which action is which. You need both a Send and Receive section and all should be type "Icn"
8. Add a "Add EDIFACT Control Numbers" action (name might not be exact). You might need to recreate the connection as well. Fill out the data in the action to match the data expected in the test. You might want to rename the action to keep it clear which action is which. You need both a Send and Receive section and all should be type "Icn"
9. Save and run. Check the results of the run. Don't just look to see if the actions succeeded, you need to actually check the output and see that the response says success.

## Sample Logic App Definition
This is for reference. You might be able to use this in code view, but you'd need to make the connections first and those were included here for security reasons

```json
"definition": {
	"$schema": "https://schema.management.azure.com/providers/Microsoft.Logic/schemas/2016-06-01/workflowdefinition.json#",
	"actions": {
		"Add_Edifact_Control_Numbers": {
			"inputs": {
				"body": [
					{
						"AgreementName": "PS-Edifact-Agreement",
						"ControlNumber": "1234",
						"ControlNumberType": "Icn",
						"IsAcknowledgement": false,
						"IsMessageProcessingFailed": false,
						"MessageDirection": "Receive"
					},
					{
						"AgreementName": "PS-Edifact-Agreement",
						"ControlNumber": "1234",
						"ControlNumberType": "Icn",
						"IsAcknowledgement": false,
						"IsMessageProcessingFailed": false,
						"MessageDirection": "Send"
					}
				],
				"host": {
					"connection": {
						"name": "@parameters('$connections')['edifact']['connectionId']"
					}
				},
				"method": "put",
				"path": "/controlnumbers"
			},
			"runAfter": {
				"Add_X12_Control_Numbers": [
					"Succeeded"
				]
			},
			"type": "ApiConnection"
		},
		"Add_X12_Control_Numbers": {
			"inputs": {
				"body": [
					{
						"AgreementName": "PS-X12-Agreement",
						"ControlNumber": "1234",
						"ControlNumberType": "Icn",
						"IsAcknowledgement": false,
						"IsMessageProcessingFailed": false,
						"MessageDirection": "Receive"
					},
					{
						"AgreementName": "PS-X12-Agreement",
						"ControlNumber": "1234",
						"ControlNumberType": "Icn",
						"IsAcknowledgement": false,
						"IsMessageProcessingFailed": false,
						"MessageDirection": "Send"
					}
				],
				"host": {
					"connection": {
						"name": "@parameters('$connections')['x12_1']['connectionId']"
					}
				},
				"method": "put",
				"path": "/controlNumbers"
			},
			"runAfter": {},
			"type": "ApiConnection"
		}
	},
	"contentVersion": "1.0.0.0",
	"outputs": {},
	"parameters": {
		"$connections": {
			"defaultValue": {},
			"type": "Object"
		}
	},
	"triggers": {
		"manual": {
			"inputs": {
				"schema": {}
			},
			"kind": "Http",
			"type": "Request"
		}
	}
}
```