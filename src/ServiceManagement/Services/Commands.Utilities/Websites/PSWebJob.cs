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
using Microsoft.WindowsAzure.WebSitesExtensions.Models;

namespace Microsoft.WindowsAzure.Commands.Websites.WebJobs
{
    public interface IPSWebJob
    {
        string JobName { get; set; }

        WebJobType JobType { get; set; }

        string ExtraInfoUrl { get; set; }

        string RunCommand { get; set; }

        Uri Url { get; set; }

        bool UsingSdk { get; set; }
    }

    public class PSWebJob<TWebJob> : IPSWebJob where TWebJob : WebJobBase
    {
        protected TWebJob WebJob { get; private set; }

        protected PSWebJob(TWebJob webJob)
        {
            WebJob = webJob;
        }

        public string JobName
        {
            get
            {
                return WebJob.Name;
            }
            set
            {
                WebJob.Name = value;
            }
        }

        public WebJobType JobType
        {
            get
            {
                return WebJob.Type;
            }
            set
            {
                WebJob.Type = value;
            }
        }

        public string ExtraInfoUrl
        {
            get
            {
                return WebJob.ExtraInfoUrl;
            }
            set
            {
                WebJob.ExtraInfoUrl = value;
            }
        }

        public string RunCommand
        {
            get
            {
                return WebJob.RunCommand;
            }
            set
            {
                WebJob.RunCommand = value;
            }
        }

        public Uri Url
        {
            get
            {
                return WebJob.Url;
            }
            set
            {
                WebJob.Url = value;
            }
        }

        public bool UsingSdk
        {
            get { return WebJob.UsingSdk; }
            set { WebJob.UsingSdk = value; }
        }
    }
}
