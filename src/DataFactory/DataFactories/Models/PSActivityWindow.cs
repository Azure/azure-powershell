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

using Microsoft.Azure.Management.DataFactories.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    public class PSActivityWindow
    {
        private ActivityWindow activityWindow;

        public PSActivityWindow()
        {
            this.activityWindow = new ActivityWindow();
        }

        public PSActivityWindow(ActivityWindow activityWindow)
        {
            if (activityWindow == null)
            {
                throw new ArgumentNullException("activityWindow");
            }

            this.activityWindow = activityWindow;
        }

        public string ResourceGroupName
        {
            get
            {
                return activityWindow.ResourceGroupName;
            }
            internal set
            {
                activityWindow.ResourceGroupName = value;
            }
        }

        public string DataFactoryName
        {
            get
            {
                return activityWindow.DataFactoryName;
            }
            internal set
            {
                activityWindow.DataFactoryName = value;
            }
        }

        public string PipelineName
        {
            get
            {
                return activityWindow.PipelineName;
            }
            internal set
            {
                activityWindow.PipelineName = value;
            }
        }

        public string ActivityName
        {
            get
            {
                return activityWindow.ActivityName;
            }
            internal set
            {
                activityWindow.ActivityName = value;
            }
        }

        public string ActivityType
        {
            get
            {
                return activityWindow.ActivityType;
            }
            internal set
            {
                activityWindow.ActivityType = value;
            }
        }

        public string LinkedServiceName
        {
            get
            {
                return activityWindow.LinkedServiceName;
            }
            internal set
            {
                activityWindow.LinkedServiceName = value;
            }
        }

        public string WindowState
        {
            get
            {
                return activityWindow.WindowState;
            }
            internal set
            {
                activityWindow.WindowState = value;
            }
        }

        public string WindowSubstate
        {
            get
            {
                return activityWindow.WindowSubstate;
            }
            internal set
            {
                activityWindow.WindowSubstate = value;
            }
        }

        public TimeSpan? Duration
        {
            get
            {
                return activityWindow.Duration;
            }
            internal set
            {
                activityWindow.Duration = value;
            }
        }

        public IList<string> InputDatasets
        {
            get
            {
                return activityWindow.InputDatasets;
            }
            internal set
            {
                activityWindow.InputDatasets = value;
            }
        }

        public IList<string> OutputDatasets
        {
            get
            {
                return activityWindow.OutputDatasets;
            }
            internal set
            {
                activityWindow.OutputDatasets = value;
            }
        }

        public int? PercentComplete
        {
            get
            {
                return activityWindow.PercentComplete;
            }
            internal set
            {
                activityWindow.PercentComplete = value;
            }
        }

        public int RunAttempts
        {
            get
            {
                return activityWindow.RunAttempts;
            }
            internal set
            {
                activityWindow.RunAttempts = value;
            }
        }

        public DateTime? RunStart
        {
            get
            {
                return activityWindow.RunStart;
            }
            internal set
            {
                activityWindow.RunStart = value;
            }
        }

        public DateTime? RunEnd
        {
            get
            {
                return activityWindow.RunEnd;
            }
            internal set
            {
                activityWindow.RunEnd = value;
            }
        }

        public DateTime WindowStart
        {
            get
            {
                return activityWindow.WindowStart;
            }
            internal set
            {
                activityWindow.WindowStart = value;
            }
        }

        public DateTime WindowEnd
        {
            get
            {
                return activityWindow.WindowEnd;
            }
            internal set
            {
                activityWindow.WindowEnd = value;
            }
        }

        public bool IsEqualTo(PSActivityWindow activityWindow)
        {
            Type type = typeof(PSActivityWindow);
            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                object actualValue = type.GetProperty(pi.Name).GetValue(activityWindow, null);
                object expectedValue = type.GetProperty(pi.Name).GetValue(this, null);

                if (actualValue != expectedValue && (actualValue == null || !actualValue.Equals(expectedValue)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
