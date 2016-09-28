using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplitDynamicImages
{
    static class Constants
    {
        public const ComponentCategory COMPONENT_CATEGORY = ComponentCategory.Media;
        public const string COMPONENT_NAME = "Dynamic Images";
        public const string DESCRIPTION = "An image that changes dependending on the last split.";
        public const string URL = "www.example.com";
        public const string VERSION = "0.1";
        public const string XML_URL = URL + "/xml.xml";
        public const string PIPE_NAME = "LiveSplitDynamicImagesPipe";
        public const string SINGLE_IMAGE_BUTTON_TEXT = "Image";
    }
}
