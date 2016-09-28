using LiveSplit.UI.Components;
using LiveSplitDynamicImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveSplit.Model;

[assembly: ComponentFactory(typeof(DynamicImagesFactory))]

namespace LiveSplitDynamicImages
{
    public class DynamicImagesFactory : IComponentFactory
    {
        public ComponentCategory Category
        {
            get { return Constants.COMPONENT_CATEGORY; }
        }

        public string ComponentName
        {
            get { return Constants.COMPONENT_NAME; }
        }

        public string Description
        {
            get { return Constants.DESCRIPTION; }
        }

        public string UpdateName
        {
            get { return ComponentName; }
        }

        public string UpdateURL
        {
            get { return Constants.URL; }
        }

        public Version Version
        {
            get { return Version.Parse(Constants.VERSION); }
        }

        public string XMLURL
        {
            get { return Constants.XML_URL; }
        }

        public IComponent Create(LiveSplitState state)
        {
            return new DynamicImagesComponent(state);
        }
    }
}
