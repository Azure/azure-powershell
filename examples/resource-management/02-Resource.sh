#!/bin/env/bash
set -e
printf "\n=== Managing Resources in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
az resource group create --name "$groupName" --location "$location"
destinationGroupName=$groupName"Destination"

printf "\n2. Registering Resource Provider Namespace.\n"
providerNamespace="Providers.Test"
az resource provider register --ProviderNamespace $providerNamespace --Force

printf "\n3. Creating a new Resource: %s.\n" "$resourceName"
resourceType="$providerNamespace/statefulResources"
tags='[{"Name": "testtag", "Value": "testvalue"}]'
properties='{"administratorLogin": "adminuser", "administratorLoginPassword": "P@ssword1"}'
apiversion="2014-04-01"
az resource create --Name $resourceName --Location $location --Tags "$tags" --ResourceGroupName $groupName --ResourceType $resourceType --PropertyObject "$properties" --ApiVersion $apiversion --Force

printf "\n4. Get information about Resource : %s.\n" "$resourceName"
resourceInfo=$(az resource ls -n $resourceName)
printf "\nValidating Resource name is: %s\n" "$resourceName"
[ $(echo $resourceInfo | jq '.Name' --raw-output) == "$resourceName" ]

printf "\n5. Find Resource with name '%s' and type '%s'.\n" "$resourceName" "$resourceType"
foundResource=$(az resource find -n "$resourceName" -t $resourceType)
printf "\nValidating Resource name is: %s.\n" "$resourceName"
[ $(echo $foundResource | jq '.Name' --raw-output) == "$resourceName" ]

printf "\n6. Update Resource.\n" 
tagsUpdate='[{"Name": "testtagUpdated", "Value": "testvalueUpdated"}]'
az resource set --ResourceGroupName $groupName --ResourceName $resourceName --ResourceType $resourceType --Tags "$tagsUpdate" -f

printf "\n7. Move Resource to resource group: %s.\n" "$destinationGroupName"
az resource group create --name "$destinationGroupName" --location "$location"
resourceId=$(echo $resourceInfo | jq '.ResourceId')
arrayId="[$resourceId]"
az resource mv -g "$destinationGroupName" --ResourceId "$arrayId" -f

printf "\n8. Removing resource: %s.\n" "$resourceName"
foundResource=$(az resource find -n "$resourceName" -t $resourceType)
resourceId=$(echo $foundResource | jq '.ResourceId' --raw-output)
echo $resourceId
export MSYS_NO_PATHCONV=1
az resource rm --Id "$resourceId" -f
export MSYS_NO_PATHCONV=