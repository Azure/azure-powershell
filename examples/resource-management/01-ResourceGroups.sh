#!/bin/bash
set -e
printf "\n=== Managing Resource Groups in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
azure group create --name "$groupName" --location "$location"

printf "\n2. Updating the group %s with tags.\n" "$groupName"
azure group set --name "$groupName" --tags "[{\"Value\":\"testval\",\"Name\":\"testtag\"}]"

printf "\n3. Get information about resource group : %s.\n" "$groupName"
resourceGroupInfo=`azure group get --name $groupName`

printf "\nValidating resource group name is: %s\n" "$groupName"
[ $(echo $resourceGroupInfo | jq '.ResourceGroupName' --raw-output) == "$groupName" ]

printf "\n4. Listing all resource groups in the subscription.\n"
azure group get

printf "\n5. Removing resource group: %s.\n" "$groupName"
azure group remove --name "$groupName" --force