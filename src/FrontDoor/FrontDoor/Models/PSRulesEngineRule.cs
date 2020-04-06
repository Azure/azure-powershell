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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.FrontDoor.Models
{
    public class PSRulesEngineRule
    {
        // required
        public string Name { get; set; }

        // required
        public int Priority { get; set; }

        public PSMatchProcessingBehavior MatchProcessingBehavior { get; set; }

        public List<PSRulesEngineMatchCondition> RulesEngineMAtchCondition { get; set; }

        // required
        public PSRulesEngineAction RulesEngineAction { get; set; }
    }

    public class PSRulesEngineMatchCondition
    {
        public PSRulesEngineMatchVariable RulesEngineMatchVariable { get; set; }

        public List<string> RulesEngineMatchValue { get; set; }

        public string Selector { get; set; }

        // This should be enum because there's a set of valid values
        public PSRulesEngineOperator RulesEngineOperator { get; set; }

        public bool? NegateCondition { get; set; }

        public List<PSTransforms> Transforms { get; set; }
    }

    public class PSRulesEngineAction
    {
        public List<PSHeaderAction> RequestHeaderActions { get; set; }

        public List<PSHeaderAction> ResponseHeaderActions { get; set; }

        public PSRouteConfiguration RouteConfigurationOverride { get; set; }
    }

    public class PSHeaderAction
    {
        //required
        public string HeaderName { get; set; }

        //required
        public PSHeaderActionType HeaderActionType { get; set; }

        public string Value { get; set; }
    }

    public enum PSMatchProcessingBehavior
    {
        Continue,
        Stop
    }

    public enum PSRulesEngineMatchVariable
    {
        IsMobile,
        RemoteAddr,
        RequestMethod,
        QueryString,
        PostArgs,
        RequestUri,
        RequestPath,
        RequestFilename,
        RequestFilenameExtension,
        RequestHeader,
        RequestBody,
        RequestScheme
    }

    public enum PSRulesEngineOperator
    {
        Any,
        IPMatch,
        GeoMatch,
        Equal,
        contains,
        LessThan,
        GreaterThan,
        LessThanOrEqual,
        GreaterThanOrEqual,
        BeginsWith,
        EndsWith
    }

    public enum PSTransforms
    {
        Lowercase,
        Uppercase,
        Trim,
        UrlDecode,
        UrlEncode,
        RemoveNulls
    }

    public enum PSHeaderActionType
    {
        Append,
        Delete,
        Overwrite
    }
}
