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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model
{
    public class PSClientCertAuthenticationJobDetail : PSHttpJobDetail
    {
        public string AuthenticationType = "Client Certificate Authentication";

        public string ClientCertSubjectName { get; internal set; }

        public string ClientCertThumbprint { get; internal set; }

        public string ClientCertExpiryDate { get; internal set; }

        public PSClientCertAuthenticationJobDetail (PSHttpJobDetail jobDetail)
        {
            foreach(PropertyInfo prop in jobDetail.GetType().GetProperties())
            {
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(jobDetail, null), null);
            }
        }

        public PSClientCertAuthenticationJobDetail()
        {            
        }
    }
}
