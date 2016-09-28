using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using LiveSplit.Model;
using System.IO;

namespace LiveSplitDynamicImages
{
    public partial class Settings : UserControl
    {
        private ObsPipe pipe;

        public LiveSplitState LivesplitState { get; set; }
        public bool SameForAllTransationsDarkRed { get; set; }
        public List<string> SelectedSegments { get; set; }
        public string newRunImage { get { return MiscSettings.newRunImage; } }
        public string runEndPBImage { get { return MiscSettings.runEndPBImage; } }
        public string runEndNoPBImage { get { return MiscSettings.runEndNoPBImage; } }
        public string resetImage { get { return MiscSettings.resetImage; } }

        public Settings(ObsPipe pipe, LiveSplitState state)
        {
            this.pipe = pipe;
            this.LivesplitState = state;
            InitializeComponent();
            SelectedSegments = new List<string>();
            SameForAllTransationsDarkRed = false;
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            System.Xml.XmlNode settingsNode = document.CreateElement("Settings");
            settingsNode.AppendChild(ToElement(document, "Version", Constants.VERSION));

            settingsNode.AppendChild(DarkRedSettings.GetSettings(document));
            settingsNode.AppendChild(LightRedSettings.GetSettings(document));
            settingsNode.AppendChild(LightGreenSettings.GetSettings(document));
            settingsNode.AppendChild(DarkGreenSettings.GetSettings(document));
            settingsNode.AppendChild(GoldSettings.GetSettings(document));
            settingsNode.AppendChild(MiscSettings.GetSettings(document));

            serializeAppend(settingsNode, SelectedSegments);

            return settingsNode;
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            DarkRedSettings.SetSettings(settings[DarkRedSettings.Name]);
            LightRedSettings.SetSettings(settings[LightRedSettings.Name]);
            LightGreenSettings.SetSettings(settings[LightGreenSettings.Name]);
            DarkGreenSettings.SetSettings(settings[DarkGreenSettings.Name]);
            GoldSettings.SetSettings(settings[GoldSettings.Name]);
            MiscSettings.SetSettings(settings[MiscSettings.Name]);
        }

        public static XmlElement ToElement<T>(XmlDocument document, String name, T value)
        {
            var element = document.CreateElement(name);
            if (value != null)
                element.InnerText = value.ToString();
            else
                element.InnerText = "";
            return element;
        }

        public static void serializeAppend(XmlNode parentNode, object obj)
        {
            XPathNavigator nav = parentNode.CreateNavigator();
            using (var writer = nav.AppendChild())
            {
                var serializer = new XmlSerializer(obj.GetType());
                writer.WriteWhitespace("");
                serializer.Serialize(writer, obj);
                writer.Close();
            }
        }

        public string getImagePathFromColour(SplitColour currentColour, SplitColour lastColour)
        {
            SingleTransitionSettings currentTransitionSettings = getCurrentTransitionSettings(currentColour);
            return currentTransitionSettings.getFileName(lastColour);
        }

        private SingleTransitionSettings getCurrentTransitionSettings(SplitColour colour)
        {
            if (colour == SplitColour.DARK_RED)
                return DarkRedSettings;
            if (colour == SplitColour.LIGHT_RED)
                return LightRedSettings;
            if (colour == SplitColour.LIGHT_GREEN)
                return LightGreenSettings;
            if (colour == SplitColour.DARK_GREEN)
                return DarkGreenSettings;
            if (colour == SplitColour.GOLD)
                return GoldSettings;
            return null;
        }
    }
}
