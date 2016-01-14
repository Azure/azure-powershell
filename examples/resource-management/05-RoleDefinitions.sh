#!/bin/env/bash
set -e
printf "\n=== Managing Role Definitions in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az resourcemanager group create --name "$groupName" --location "$location"

printf "\n2. Creating a new Role Definition.\n"
roleDefinition=$(az networksecurityrole definition create --inputfile $BASEDIR/roleDefinition.json)

printf "\n3. Get information about Role Definitions.\n"
roleDefinitionName=$(echo $roleDefinition | jq '.Name' --raw-output)
az networksecurityrole definition ls -n $roleDefinitionName

printf "\n4. Update Role Definition.\n"
export MSYS_NO_PATHCONV=1
updatedRoleDefinition=$(echo $roleDefinition | jq '.Actions |= .+ ["Microsoft.Authorization/*/write"]')
az networksecurityrole definition set --Role "$updatedRoleDefinition"

printf "\n5. Delete Role Definition.\n"
roleDefinitionId=$(echo $roleDefinition | jq '.Id' --raw-output)
az networksecurityrole definition rm --Id $roleDefinitionId --PassThru -f 
export MSYS_NO_PATHCONV=
