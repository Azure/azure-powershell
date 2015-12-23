#!/bin/bash
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

azure group create --name "$groupName" --location "$location"

printf "\n1. Create a new app service plan %s " "$planName"
azure app service plan create -n "$planName" -g "$groupName" -l "$location" --tier "$tier"

printf "\n2. Create a new web app %s " "$appName"
webappInfo=`azure webapp create -g "$groupName" -n "$appName" -l "$location" --plan "$planName"`

printf "\nValidating web app name %s " "$appName"
[ $(echo $webappInfo | jq '.name' --raw-output) == "$appName" ]

printf "\n3. Create a web app slot %s " "$slotname1"
slot1=`azure webapp slot create -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname1"`
appWithSlotName1="$appName/$slotname1"

printf "\nValidating web app slot %s " "$slotname1"
[ $(echo $slot1 | jq '.name' --raw-output) == "$appWithSlotName1" ]

printf "\nValidating web app slot get for %s " "$slotname1"
slot1=`azure webapp slot get -g "$groupName" -n "$appName" --slot "$slotname1"`
[ $(echo $slot1 | jq '.name' --raw-output) == "$appWithSlotName1" ]

printf "\nValidating web app slot via pipline obj for %s " "$slotname1"
# !Not able to test pipeline for now
slot1=`echo "$webappInfo" | azure webapp slot get --slot "$slotname1"`

printf "\n4. Create another web app slot %s " "$slotname2"
slot2=`azure webapp slot create -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname2"`
appWithSlotName2="$appName/$slotname2"

printf "\n5. Get the webapp slots:"
slots=`azure webapp slot get -g "$groupName" -n "$appName"`
slotN1=`echo $slots | jq '[0].name'`
slotN2=`echo $slots | jq '[1].name'`
slotNames=`echo "$slotN1" "$slotN2"`

printf "\nValidating web app slots %s " "$slotname1 and $slotname2" 
[ $(echo $slotNames ) == "$appWithSlotName1" ]
[ $(echo $slotNames ) == "$appWithSlotName2" ]

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
$metricsNames='[ "CPU" ]'

metrics=`azure webapp slot metrics get -g "$groupName" -n "$appName" --slot "$slotname1" --granularity PT1M --starttime "$startTime" --endtime "$endTime" --metrics "$metricsNames"`
# azure webapp slot metrics get -g testrg12068 -n testweb121 --slot staging --granularity PT1M --metrics "CPU, Requests" --starttime "Monday, December 21, 2015 3:31:26 PM" --endtime "Monday, December 2

printf "\nValidating web app slot metrics %s " "$slotname1" 
for i in $metricsNames
do
	[ $(echo $metrics ) == "$i" ]
done

# !Not able to test pipeline for now
printf "\nValidating web app slot metrics via pipline obj %s " "$slotname1" 

printf "\n12. Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure web app slot stop`
printf "\nValidating web app slot %s stopped " "$slotname1" 
[ $(echo $slot1 | jq '.State' ) == "Stopped" ]

printf "\n13 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure web app slot start`
printf "\nValidating web app slot %s running " "$slotname1" 
[ $(echo $slot1 | jq '.State' ) == "Running" ]


printf "\n14 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure web app slot stop`
printf "\nValidating web app slot %s stopped " "$slotname1" 
[ $(echo $slot1 | jq '.State' ) == "Stopped" ]

printf "\n15 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure web app slot start`
printf "\nValidating web app slot %s running " "$slotname1" 
[ $(echo $slot1 | jq '.State' ) == "Running" ]


printf "\n16 Restart web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure web app slot restart`
printf "\nValidating web app slot %s Running " "$slotname1" 
[ $(echo $slot1 | jq '.State' ) == "Stopped" ]

printf "\n17 Restart web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure web app slot restart`
printf "\nValidating web app slot %s Running " "$slotname1" 
[ $(echo $slot1 | jq '.State' ) == "Stopped" ]

# Clone ------
printf "\n10. Clone web app slot: %s." "$slotname1"
slotClone=`azure web app slot clone`
appWithSlotNameClone="$appName/slotname1"

printf "\nValidating cloned web app slot %s " "$slotname1"
[ $(echo $slotClone | jq '.name' --raw-output) == "$appWithSlotNameClone" ]

printf "\nValidating web app slot get for %s " "$slotname1"
slot1=`azure webapp slot get -g "$groupName" -n "$appName" --slot "$slotname1"`
[ $(echo $slot1 | jq '.name' --raw-output) == "$appWithSlotNameClone" ]
#------- 

# Cleanup
printf "\n20. Remove web app slot: %s." "$slotname1"
printf "\n20. Remove web app: %s." "$appName"
printf "\n20. Remove app service plan: %s." "$planName"
printf "\n20. Remove resource group: %s." "$groupName"