using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Model;
using LiveSplit.UI;
using System.Xml;
using System.Threading;
using System.IO.Pipes;

namespace LiveSplitDynamicImages
{
    class DynamicImagesComponent : LogicComponent
    {
        public Settings settings { get; set; }
        private SplitHandler splitHander;

        public DynamicImagesComponent(LiveSplitState state)
        {
            ObsPipe pipe = new ObsPipe();
            settings = new Settings(pipe, state);
            splitHander = new SplitHandler(state, settings, pipe);
        }

        public override string ComponentName
        {
            get { return Constants.COMPONENT_NAME; }
        }

        public override void Dispose()
        {
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return settings.GetSettings(document);
        }

        public override System.Windows.Forms.Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        public override void SetSettings(XmlNode xmlNodeSettings)
        {
            settings.SetSettings(xmlNodeSettings);
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
        }
    }
}
