#!/bin/bash
set -e
printf "\n=== Managing Resources in Azure ===\n"

printf "\n1. Creating a new resource group: %s and location: %s.\n" "$groupName" "$location"
azure group create --name "$groupName" --location "$location"
resourceName="CluResource"
destinationGroupName=$groupName"Destination"

printf "\n2. Registering Resource Provider Namespace.\n"
providerNamespace="Providers.Test"
azure resource provider register --ProviderNamespace $providerNamespace --Force

printf "\n3. Creating a new Resource: %s.\n" "$resourceName"
resourceType="$providerNamespace/statefulResources"
tags='[{"Name": "testtag", "Value": "testvalue"}]'
properties='{"administratorLogin": "adminuser", "administratorLoginPassword": "P@ssword1"}'
apiversion="2014-04-01"
azure resource create --Name $resourceName --Location $location --Tags "$tags" --ResourceGroupName $groupName --ResourceType $resourceType --PropertyObject "$properties" --ApiVersion $apiversion --Force

printf "\n4. Get information about Resource : %s.\n" "$resourceName"
resourceInfo=$(azure resource get -n $resourceName)
printf "\nValidating Resource name is: %s\n" "$resourceName"
[ $(echo $resourceInfo | jq '.Name' --raw-output) == "$resourceName" ]

printf "\n5. Find Resource with name = %s and type =.\n" "$resourceName" "$resourceType"
foundResource=$(azure resource find -n "clu" -t $resourceType)
printf "\nValidating Resource name is: %s\n" "$resourceName"
[ $(echo $foundResource | jq '.Name' --raw-output) == "$resourceName" ]

printf "\n6. Update Resource.\n" 
tagsUpdate='[{"Name": "testtagUpdated", "Value": "testvalueUpdated"}]'
azure resource set  --ResourceGroupName $groupName --ResourceName $resourceName --ResourceType $resourceType --Tags "$tagsUpdate" -f

printf "\n7. Move Resource to resource group: %s.\n" "$destinationGroupName"
azure group create --name "$destinationGroupName" --location "$location"
resourceId=$(echo $resourceInfo | jq '.Id')
arrayId="[$resourceId]"
azure resource move -g "$destinationGroupName" --ResourceId "$arrayId" -f

printf "\n8. Removing resource: %s.\n" "$resourceName"
foundResource=$(azure resource find -n "clu" -t $resourceType)
resourceId=$(echo $foundResource | jq '.Id' --raw-output)
azure resource remove --Id "$resourceId" -f