#!/bin/env/bash
set -e
printf "\n=== Managing Role Definitions in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az resource group create --name "$groupName" --location "$location"

printf "\n2. Creating a new Role Definition.\n"
roleDefinition=$(az resource role definition create --inputfile $BASEDIR/roleDefinition.json)

printf "\n3. Get information about Role Definitions.\n"
roleDefinitionName=$(echo $roleDefinition | jq '.Name' --raw-output)
az resource role definition ls -n $roleDefinitionName

printf "\n4. Update Role Definition.\n"
export MSYS_NO_PATHCONV=1
updatedRoleDefinition=$(echo $roleDefinition | jq '.Actions |= .+ ["Microsoft.Authorization/*/write"]')
az resource role definition set --Role "$updatedRoleDefinition"

printf "\n5. Delete Role Definition.\n"
roleDefinitionId=$(echo $roleDefinition | jq '.Id' --raw-output)
az resource role definition rm --Id $roleDefinitionId --PassThru -f 
export MSYS_NO_PATHCONV=
