﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Common
{
    /// <summary>
    /// Class used to automatically complete the offer provided in the cmdlet
    /// </summary>
    public class OfferCompleter : PSArgumentCompleterAttribute
    {
        public OfferCompleter() : base(
            "SQL2019-WS2019",
            "SQL2019-WS2016",
            "SQL2019-WS2012",
            "SQL2019-WS2008",

            "SQL2017-WS2019",
            "SQL2017-WS2016",
            "SQL2017-WS2012",
            "SQL2017-WS2008",

            "SQL2016-WS2019",
            "SQL2016-WS2016",
            "SQL2016-WS2012",
            "SQL2016-WS2008",

            "SQL2014-WS2019",
            "SQL2014-WS2016",
            "SQL2014-WS2012",
            "SQL2014-WS2008",
            
            "SQL2012-WS2019",
            "SQL2012-WS2016",
            "SQL2012-WS2012",
            "SQL2012-WS2008",

            "SQL2008-WS2019",
            "SQL2008-WS2016",
            "SQL2008-WS2012",
            "SQL2008-WS2008"
            )
        {}
    }
}
