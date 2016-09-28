using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplitDynamicImages
{
    public partial class MiscTransitionSettings : UserControl
    {
        public string newRunImage { get { return imageBrowseAndTestNewRun.imagePath; } }
        public string runEndPBImage { get { return imageBrowseAndTestRunEndPB.imagePath; } }
        public string runEndNoPBImage { get { return imageBrowseAndTestRunEndNoPB.imagePath; } }
        public string resetImage { get { return imageBrowseAndTestReset.imagePath; } }

        public MiscTransitionSettings()
        {
            InitializeComponent();
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            System.Xml.XmlNode settingsNode = document.CreateElement(this.Name);
            
            settingsNode.AppendChild(imageBrowseAndTestNewRun.GetSettings(document));
            settingsNode.AppendChild(imageBrowseAndTestRunEndPB.GetSettings(document));
            settingsNode.AppendChild(imageBrowseAndTestRunEndNoPB.GetSettings(document));
            settingsNode.AppendChild(imageBrowseAndTestReset.GetSettings(document));

            return settingsNode;
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            imageBrowseAndTestNewRun.SetSettings(settings[imageBrowseAndTestNewRun.Name]);
            imageBrowseAndTestRunEndPB.SetSettings(settings[imageBrowseAndTestRunEndPB.Name]);
            imageBrowseAndTestRunEndNoPB.SetSettings(settings[imageBrowseAndTestRunEndNoPB.Name]);
            imageBrowseAndTestReset.SetSettings(settings[imageBrowseAndTestReset.Name]);
        }

    }
}
