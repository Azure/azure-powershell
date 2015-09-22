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

using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MS.Test.Common.MsTestLib
{
    public class TestContext2 : TestContext
    {
        private DataRow dataRow = null;
        public override DataRow DataRow { get { return dataRow; } }
        Dictionary<object, object> properties = new Dictionary<object, object>();
        public override IDictionary Properties { get { return properties; } }
        public override void AddResultFile(string fileName) { }
        public override void BeginTimer(string timerName) { }

        public override void EndTimer(string timerName) { }
        public override void WriteLine(string format, params object[] args) { }

        public override DbConnection DataConnection { get { return null; } }


        public string fullyQualifiedTestClassName = string.Empty;

        public override string FullyQualifiedTestClassName { get { return fullyQualifiedTestClassName; } }


        public string testName = string.Empty;
        public override string TestName { get { return testName; } }
    }
    
    
}
