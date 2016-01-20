#!/bin/env/bash
set -e
printf "\n=== Managing App Service Plans in Azure ===\n"

#setup
printf "\nSetup: Creating a new resource group: %s at location: %s.\n" "$groupName" "$location"
export whpName=`randomName testplan`
tier="Standard"
size="Medium"
capacity=2
skuName="S2"
az resource group create --name "$groupName" --location "$location"

printf "\n1. Create a new app service plan %s " "$whpName"
az appservice plan create -n "$whpName" -g "$groupName" -l "$location" --tier "$tier" --size "$size" --workers "$capacity"

printf "\n2. Get information about the app service plan : %s.\n" "$whpName"
whpInfo=`az appservice plan ls --name $whpName --group $groupName`

printf "\nValidating app service plan name: %s\n" "$whpName"
[ $(echo $whpInfo | jq '.name' --raw-output) == "$whpName" ]
[ $(echo $whpInfo | jq '.location' --raw-output) == "West US" ]
[ $(echo $whpInfo | jq '.sku.tier' --raw-output) == "$tier" ]
[ $(echo $whpInfo | jq '.sku.name' --raw-output) == "$skuName" ]
[ $(echo $whpInfo | jq '.sku.capacity' --raw-output) -eq $capacity ]

printf "\n3. Set the appservice plan: %s " "$whpName"
newTier="Shared"
newCapacity=0
newSize="Medium"
setPlanInfo=`az appservice plan set -n $whpName -g $groupName --tier $newTier --workers --workers $newCapacity --size $newSize`
[ $(echo $setPlanInfo | jq '.name' --raw-output) == "$whpName" ]
[ $(echo $setPlanInfo | jq '.sku.tier' --raw-output) == "$newTier" ]
[ $(echo $setPlanInfo | jq '.sku.capacity' --raw-output) -eq $newCapacity ]
[ $(echo $setPlanInfo | jq '.sku.name' --raw-output) == "D1" ]
[ $(echo $setPlanInfo | jq '.["geoRegion"]' --raw-output) == "West US" ]

whpName2=`randomName testplan`
printf "\n4. Creating a new app service plan: %s" "$whpName2"
location2="East US"
az appservice plan create -n "$whpName2" -g "$groupName" -l "$location2" --tier "$tier" --size "$size" --workers "$capacity"

printf "\n5. Get All app service plans by name: %s" "$whpName2"
whpInfo2=`az appservice plan ls --name $whpName2`
[ $(echo $whpInfo | jq '.name' --raw-output) == "$whpName2" ]
[ $(echo $whpInfo | jq '.location' --raw-output) == "$location2" ]
[ $(echo $whpInfo | jq '.sku.tier' --raw-output) == "$tier" ]
[ $(echo $whpInfo | jq '.sku.name' --raw-output) == "$skuName" ]
[ $(echo $whpInfo | jq '.sku.capacity' --raw-output) -eq $capacity ]

printf "\n6. Get All app service plans by resource group: %s" "$groupName"
plansByGroup=`az appservice plan ls --group $groupName`
[  $plansByGroup == *"$whpName"* ]
[  $plansByGroup == *"$whpName2"* ]

printf "\n7. Get All app service plans by location: %s" "$location2"
plansByLocation=`az appservice plan ls -l $location2`
[  $plansByLocation == *"$whpName2"* ]

printf "\n8. Get All app service plans in a subscription."
plansInSubscription=`az appservice plan ls`
[  $plansInSubscription == *"$whpName"* ]
[  $plansInSubscription == *"$whpName2"* ]

printf "\n9. Remove app service plan: %s." "$whpName"
az appservice plan rm -n $whpName -g $groupName

printf "\n10. Remove app service plan: %s." "$whpName2"
az appservice plan rm -n $whpName2 -g $groupName
