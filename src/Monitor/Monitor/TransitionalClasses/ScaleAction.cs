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

using Microsoft.Azure.Commands.Insights.TransitionalClasses;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the ScaleAction, but in the old namespace
    /// </summary>
    public class ScaleAction : Monitor.Models.ScaleAction
    {
        /// <summary>
        /// Gets or sets the ScaleType of the scale action
        /// </summary>
        public new ScaleType Type
        {
            get
            {
                return (ScaleType)System.Enum.Parse(typeof(ScaleType), base.Type.ToString());
            }
            set
            {
                base.Type = (Monitor.Models.ScaleType)System.Enum.Parse(typeof(Monitor.Models.ScaleType), value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the Direction of the scale action
        /// </summary>
        public new ScaleDirection Direction
        {
            get
            {
                return (ScaleDirection)System.Enum.Parse(typeof(ScaleDirection), base.Direction.ToString());
            }
            set
            {
                base.Direction = (Monitor.Models.ScaleDirection)System.Enum.Parse(typeof(Monitor.Models.ScaleDirection), value.ToString());
            }
        }

        /// <summary>
        /// Initializes a new instance of the ScaleAction class.
        /// </summary>
        public ScaleAction()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScaleAction class.
        /// </summary>
        /// <param name="scaleAction">The ScaleAction object</param>
        public ScaleAction(Monitor.Models.ScaleAction scaleAction)
            : base()
        {
            if (scaleAction != null)
            {
                base.Cooldown = scaleAction.Cooldown;
                base.Direction = scaleAction.Direction;
                base.Type = scaleAction.Type;
                Value = scaleAction.Value;
                this.Type = TransitionHelpers.ConvertNamespace(scaleAction.Type);
                this.Direction = TransitionHelpers.ConvertNamespace(scaleAction.Direction);
            }
        }
    }
}
