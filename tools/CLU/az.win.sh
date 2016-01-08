#!/bin/bash
if [ -z ${CmdletSessionID} ]
then
  export CmdletSessionID=$PPID
fi
SCRIPTPATH=$(dirname "$0")
WSCRIPTPATH=$({ cd $SCRIPTPATH && pwd -W; } | sed 's|/|\\|g')
$WSCRIPTPATH/clurun -s az -r $WSCRIPTPATH/azure.lx "$@" 
