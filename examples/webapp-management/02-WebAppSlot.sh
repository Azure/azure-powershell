#!/bin/env/bash
set -e
printf "\n=== Managing Web App Slot in Azure ===\n"

pingwebapp() {
    # a helper function to ping a webapp
}

#setup
printf "\nSetup: Creating a new resource group: %s at location: %s.\n" "$groupName" "$location"

appName=`randomName testweb`
slotname1="staging"
slotname2="testing"
planName=`randomName testplan`
tier="Standard"
apiversion="2015-08-01"
resourceType="Microsoft.Web/sites"

az resourcemanager group create --name "$groupName" --location "$location"

printf "\n1. Create a new app service plan %s " "$planName"
az appservice plan create -n "$planName" -g "$groupName" -l "$location" --tier "$tier"

printf "\n2. Create a new web app %s " "$appName"
webappInfo=`az webapp create -g "$groupName" -n "$appName" -l "$location" --plan "$planName"`

printf "\nValidating web app name %s " "$appName"
[ $(echo $webappInfo | jq '.name' --raw-output) == "$appName" ]

printf "\n3. Create a web app slot %s " "$slotname1"
slot1=`az webapp slot create -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname1"`
appWithSlotName1="$appName/$slotname1"

printf "\nValidating web app slot %s " "$slotname1"
[ $(echo $slot1 | jq '.name' --raw-output) == "$appWithSlotName1" ]

printf "\nValidating web app slot get for %s " "$slotname1"
slot1=`az webapp slot ls -g "$groupName" -n "$appName" --slot "$slotname1"`
[ $(echo $slot1 | jq '.name' --raw-output) == "$appWithSlotName1" ]

printf "\nValidating web app slot via pipline obj for %s " "$slotname1"
slot1=`echo "$webappInfo" | az webapp slot ls --slot "$slotname1"`

printf "\n4. Create another web app slot %s " "$slotname2"
slot2=`az webapp slot create -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname2"`
appWithSlotName2="$appName/$slotname2"

printf "\n5. Get the webapp slots:"
slots=`az webapp slot ls -g "$groupName" -n "$appName"`
slotN1=`echo $slots | jq '.[0].name'`
slotN2=`echo $slots | jq '.[1].name'`
slotNames=`echo $slotN1 $slotN2`

printf "\nValidating web app slots %s " "$slotname1 and $slotname2" 
[[ $slotNames == *"$appWithSlotName1"* ]]
[[ $slotNames == *"$appWithSlotName2"* ]]

printf "\n6. Change web app slot %s service plan" "$slotname2"
printf "\n7. Set web app slot %s config properties" "$slotname2"
printf "\n8. Set web app slot %s settings and connection strings" "$slotname2"

printf "\n9. Get web app slot %s publishing profile" "$slotname1"
printf "\n10. Get web app slot %s publishing profile via pipline obj" "$slotname1"

printf "\n11. Get web app slot metrics %s " "$slotname1"
for i in {1..10}
do
    pingwebapp $slot1
done

endTime=`date +"%A, %B %d, %Y %X"`
startTime=`date +"%A, %B %d, %Y %X" --date "3 hour ago"`
$metricsNames="\"('CPU', 'Requests')\""

# !Not able to test since complex object issue.
metrics=`az webapp slot metrics ls -g "$groupName" -n "$appName" --slot "$slotname1" --granularity PT1M --starttime "$startTime" --endtime "$endTime" --metrics "$metricsNames"`

printf "\nValidating web app slot metrics %s " "$slotname1" 
for i in $metricsNames
do
    [ $(echo $metrics ) == "$i" ]
done

# !Not able to test pipeline for now
printf "\nValidating web app slot metrics via pipline obj %s " "$slotname1" 

printf "\n12. Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az webapp slot stop`
printf "\nValidating web app slot %s stopped " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Stopped" ]

printf "\n13 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az webapp slot start`
printf "\nValidating web app slot %s running " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n14 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az webapp slot stop`
printf "\nValidating web app slot %s stopped " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Stopped" ]

printf "\n15 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az webapp slot start`
printf "\nValidating web app slot %s running " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n16 Restart web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az webapp slot restart`
printf "\nValidating web app slot %s Running " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n17 Restart web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az webapp slot restart`
printf "\nValidating web app slot %s Running " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Running" ]

# Clone ------
# !Not able to test since complex object input issue.
# printf "\n10. Clone web app slot: %s." "$slotname1"
# slotClone=`az web app slot clone`
# appWithSlotNameClone="$appName/slotname1"

# printf "\nValidating cloned web app slot %s " "$slotname1"
# [ $(echo $slotClone | jq '.name' --raw-output) == "$appWithSlotNameClone" ]

# printf "\nValidating web app slot get for %s " "$slotname1"
# slot1=`az webapp slot ls -g "$groupName" -n "$appName" --slot "$slotname1"`
# [ $(echo $slot1 | jq '.name' --raw-output) == "$appWithSlotNameClone" ]
#------- 

# Cleanup
printf "\n20. Remove web app slot: %s." "$slotname1"
az webapp slot rm -g "$groupName" -n "$appName" --slot "$slotname1"

printf "\n20. Remove web app: %s." "$appName"
az webapp rm -g "$groupName" -n "$appName"

printf "\n20. Remove app service plan: %s." "$planName"
az appservice plan rm -g "$groupName" -n "$planName"

printf "\n20. Remove resource group: %s." "$groupName"