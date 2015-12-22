#!/bin/bash
set -e
printf "\n=== Managing Web App Slot in Azure ===\n"

#setup
printf "\nSetup: Creating a new resource group: %s at location: %s.\n" "$groupName" "$location"

appName = `randomName testweb`
slotname1 = "staging"
slotname2 = "testing"
planName = `randomName testplan`
tier = "Standard"
apiversion = "2015-08-01"
resourceType = "Microsoft.Web/sites"

azure group create --name "$groupName" --location "$location" --plan "$planName"

printf "\n1. Create a new web app %s " "$appName"
webapp=`azure webapp create -g "$groupName" -n "$appName" -l "$location"`
#azure app service plan create -n "$appName" -g "$groupName" -l "$location" --tier "$tier" --size "$size" --workers "$capacity"

printf "\n2. Create a web app slot %s " "$slotname1"
slot1=`azure webapp slot create -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname1"`
appWithSlotName1=""

printf "\n2. Create a web app slot %s " "$slotname2"
slot2=`azure webapp slot create -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname2"`
appWithSlotName2=""

printf "\n3. Set the webapp slots: "
slots=`azure webapp get -g "$groupName" -n "$appName"` 

# Things below are not interested.
#========================================================================================

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
setPlanInfo=`azure app service plan set -n $whpName -g $groupName --tier $newTier --workers --workers $newCapacity --size $newSize`
[ $(echo $setPlanInfo | jq '.name' --raw-output) == "$whpName" ]
[ $(echo $setPlanInfo | jq '.sku.tier' --raw-output) == "$newTier" ]
[ $(echo $setPlanInfo | jq '.sku.capacity' --raw-output) -eq $newCapacity ]
[ $(echo $setPlanInfo | jq '.sku.name' --raw-output) == "D1" ]
[ $(echo $setPlanInfo | jq '.["properties.geoRegion"]' --raw-output) == "West US" ]

whpName2=`randomName testplan`
printf "\n4. Creating a new app service plan: %s" "$whpName2"
location2="East US"
azure app service plan create -n "$whpName2" -g "$groupName" -l "$location2" --tier "$tier" --size "$size" --workers "$capacity"

printf "\n5. Get All app service plans by name: %s" "$whpName2"
whpInfo2=`azure app service plan get --name $whpName2`
[ $(echo $whpInfo | jq '.name' --raw-output) == "$whpName2" ]
[ $(echo $whpInfo | jq '.location' --raw-output) == "$location2" ]
[ $(echo $whpInfo | jq '.sku.tier' --raw-output) == "$tier" ]
[ $(echo $whpInfo | jq '.sku.name' --raw-output) == "$skuName" ]
[ $(echo $whpInfo | jq '.sku.capacity' --raw-output) -eq $capacity ]

printf "\n6. Get All app service plans by resource group: %s" "$groupName"
plansByGroup=`azure app service plan get --group $groupName`
[  $plansByGroup == *"$whpName"* ]
[  $plansByGroup == *"$whpName2"* ]

printf "\n7. Get All app service plans by location: %s" "$location2"
plansByLocation=`azure app service plan get -l $location2`
[  $plansByLocation == *"$whpName2"* ]

printf "\n8. Get All app service plans in a subscription."
plansInSubscription=`azure app service plan get`
[  $plansInSubscription == *"$whpName"* ]
[  $plansInSubscription == *"$whpName2"* ]

printf "\n9. Remove app service plan: %s." "$whpName"
azure app service plan remove -n $whpName -g $groupName

printf "\n10. Remove app service plan: %s." "$whpName2"
azure app service plan remove -n $whpName2 -g $groupName