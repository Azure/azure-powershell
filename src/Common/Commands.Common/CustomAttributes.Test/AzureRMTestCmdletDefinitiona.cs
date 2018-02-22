// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.CustomAttributes.Test
{
    [CmdletDeprecationMarker("Get-AzureRMTestCmdlet1", "GEt-AzureRMTestCmdlet2")]
    class AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute : AzureRMCmdlet
    {
    }

    [OutputType(typeof(List<String>))]
    [CmdLetOutputDeprecationMarker("Get-AzureRMTestCmdlet2", "String", "List<String>")]
    class AzureRMTestCmdletWithCmdletWithOutputTypeChange : AzureRMCmdlet
    {

    }

    // This deprecation marker should print the deprevated by version only in the message
    [CmdletMetadataChangeMarker("Get-AzureRMTestCmdlet2", "ParameterSet1", "ParameterSet1 is being deprecated for ParameterSet2", "5.0.0.0")]
    class AzureRMTestCmdletWithMetadataChangeAttribute : AzureRMCmdlet
    {

    }

    //This deprecation marker should have the deprecated by version and deprecated by both present in the message printed out
    [CmdLetOutputPropertiesChangeMarker("Get-AzureRMTestCmdlet2", "FakeTypw2", new String[] { "Prop1", "Prop2" }, new String[] { "NewProp1" }, "5.0.1.0", "02/05/2018")]
    class AzureRMTEstCmdletWithOutputPropertyChanges : AzureRMCmdlet
    {

    }

    class AzureRMTestCmdletWithDeprecatedParam
    {
        //This deprecation marker should not have the OldWay=x New way=y printed as New way is not specified
        [CmdLetParameterDeprecationMarker("Get-AzureRMTestCmdlet2", "Param1", "Param2", OldWay = "Get-AzureRMTestCmdlet2 -Param1=\"blah\"")]
        public String Param1;
    }

    class AzureRMTestCmdletWithParameterBecomingMandatory
    {
        public String Param1;
        //this deprecation marker should print the old way and new way of calling the cmdlet.
        [CmdletParameterMandatoryStatusChange("Get-AzureRMTestCmdlet2", "Param2", OldWay = "Get-AzureRMTestCmdlet2 -Param1=\"blah\"", NewWay = "Get-AzureRMTestCmdlet2 -Param1=\"blah\" -Param2=\"Yo Yo\"")]
        public String Param2;
    }

    //Multiple attributes test where one attrib is on the class the other on a property
    [CmdLetParameterOrderChange("Get-AzureRMTestCmdlet2", null, new String[] {"Param1", "ParamX"}, new String[] { "ParamX", "Param1"})]
    class AzureRMTestCmdletWithParameterMetadataChangeAndOrderChange
    {
        public String Param1;
        [CmdletParameterMetadataChangeMarker("Get-AzureRMTestCmdlet2", "ParamX", "ParamX.getData()", "getData now returns a List<String> instead of String")]
        public String ParamX;
    }

    //Multiple attributes test where both the attribs are on the same entity
    class AzureRMTestCmdletWithParamTypeChangeAndMandatoryChange
    {
        [CmdletParameterTypeChangeMarker("Get-AzureRMTestCmdlet2", "Param1", "String", "List<String>")]
        [CmdletParameterMandatoryStatusChange("Get-AzureRMTestCmdlet2", "Param1", "5.0.1.0", "02/05/2018")]
        public List<String> Param1;

        public String Param2;
    }
}
