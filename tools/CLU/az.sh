#!/bin/bash
if [ -z ${CmdletSessionID} ]
then
  export CmdletSessionID=$PPID
fi
SCRIPTPATH=$(dirname "$0")
$SCRIPTPATH/clurun -s az -r $SCRIPTPATH/azure.lx "$@" 
