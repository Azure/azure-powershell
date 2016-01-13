#!/bin/env/bash
set -e
printf "\n=== Managing Role Assignments in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az resourcemanager group create --name "$groupName" --location "$location"

printf "\n2. Creating a new Role Assignment.\n"
export MSYS_NO_PATHCONV=1
users=$(az activedirectory users ls)
userId=$(echo $users | cat | jq '.[0].Id' -s --raw-output)
echo "UserID: $userId"
roleDefinitions=$(az networksecurityrole definition ls)
roleDefinitionId=$(echo $roleDefinitions | cat | jq '.[0].Id' -s --raw-output)
echo "RoleDefinitionId: $roleDefinitionId"
subsciptions=$(az subscription ls)
subscriptionId=$(echo $subsciptions | cat | jq '.[0].SubscriptionId' -s --raw-output)
scope="/subscriptions/$subscriptionId/resourceGroups/$groupName"
echo "Scope: $scope"
az networksecurityrole assignment create --ObjectId "$userId" --RoleDefinitionId "$roleDefinitionId" --Scope "$scope"

printf "\n3. Delete last created Role Assignment.\n"
assignments=$(az networksecurityrole assignment ls)
assignmentId=$(echo $assignments | cat | jq '.[-1:][0].ObjectId' -s --raw-output)
echo "Deleting assignment: $assignmentId"
az networksecurityrole assignment rm --ObjectId "$assignmentId" --Scope "$scope" --RoleDefinitionId "$roleDefinitionId" -f
export MSYS_NO_PATHCONV=