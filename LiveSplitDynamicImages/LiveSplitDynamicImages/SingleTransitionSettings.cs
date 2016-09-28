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

    public partial class SingleTransitionSettings : UserControl
    {
        [Description("Title"), Category("Data")]
        public string Title
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        public ObsPipe pipe { get; set; }

        private string multiImageText;

        public SingleTransitionSettings()
        {
            InitializeComponent();
            multiImageText = imageBrowseAndTestDarkRed.label;
            setImageButtonVisibility();
        }

        public string getDarkRedFileName() { return imageBrowseAndTestDarkRed.imagePath; }
        public string getLightRedFileName() { return imageBrowseAndTestLightRed.imagePath; }
        public string getLightGreenFileName() { return imageBrowseAndTestLightGreen.imagePath; }
        public string getDarkGreenFileName() { return imageBrowseAndTestDarkGreen.imagePath; }
        public string getGoldFileName() { return imageBrowseAndTestGold.imagePath; }
        public string getNoneFileName() { return imageBrowseAndTestNone.imagePath; }
        public string getFileName(SplitColour colour)
        {
            if (checkBox1.Checked)
                return getDarkRedFileName();
            if (colour == SplitColour.DARK_RED)
                return getDarkRedFileName();
            if (colour == SplitColour.LIGHT_RED)
                return getLightRedFileName();
            if (colour == SplitColour.LIGHT_GREEN)
                return getLightGreenFileName();
            if (colour == SplitColour.DARK_GREEN)
                return getDarkGreenFileName();
            if (colour == SplitColour.GOLD)
                return getGoldFileName();
            if (colour == SplitColour.NONE)
                return getNoneFileName();
            return getNoneFileName();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            setImageButtonVisibility();
        }

        void setImageButtonVisibility()
        {
            if (checkBox1.Checked)
                setAllImagesSame();
            else
                setDifferentImages();
        }

        private void setAllImagesSame()
        {
            imageBrowseAndTestDarkRed.Visible = true;
            imageBrowseAndTestDarkRed.label = Constants.SINGLE_IMAGE_BUTTON_TEXT;
            imageBrowseAndTestLightRed.Visible = false;
            imageBrowseAndTestLightGreen.Visible = false;
            imageBrowseAndTestDarkGreen.Visible = false;
            imageBrowseAndTestGold.Visible = false;
            imageBrowseAndTestNone.Visible = false;
        }

        private void setDifferentImages()
        {
            Image image = imageBrowseAndTestDarkRed.image;
            string imagePath = imageBrowseAndTestDarkRed.imagePath;
            imageBrowseAndTestDarkRed.Visible = true;
            imageBrowseAndTestDarkRed.label = multiImageText;
            setImageBrowseVisible(imageBrowseAndTestLightRed, image, imagePath);
            setImageBrowseVisible(imageBrowseAndTestLightGreen, image, imagePath);
            setImageBrowseVisible(imageBrowseAndTestDarkGreen, image, imagePath);
            setImageBrowseVisible(imageBrowseAndTestGold, image, imagePath);
            setImageBrowseVisible(imageBrowseAndTestNone, image, imagePath);
        }

        private void setImageBrowseVisible(ImageBrowseAndTest imgBT, Image image, string imagePath)
        {
            imgBT.Visible = true;
            imgBT.setImage(imagePath, image);
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            System.Xml.XmlNode settingsNode = document.CreateElement(this.Name);

            settingsNode.AppendChild(Settings.ToElement(document, "sameForAllTransitions", checkBox1.Checked));
            settingsNode.AppendChild(imageBrowseAndTestDarkRed.GetSettings(document));
            settingsNode.AppendChild(imageBrowseAndTestLightRed.GetSettings(document));
            settingsNode.AppendChild(imageBrowseAndTestLightGreen.GetSettings(document));
            settingsNode.AppendChild(imageBrowseAndTestDarkGreen.GetSettings(document));
            settingsNode.AppendChild(imageBrowseAndTestGold.GetSettings(document));
            settingsNode.AppendChild(imageBrowseAndTestNone.GetSettings(document));

            return settingsNode;
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            if (settings["sameForAllTransitions"] != null)
                checkBox1.Checked = bool.Parse(settings["sameForAllTransitions"].InnerText);
            imageBrowseAndTestDarkRed.SetSettings(settings[imageBrowseAndTestDarkRed.Name]);
            imageBrowseAndTestLightRed.SetSettings(settings[imageBrowseAndTestLightRed.Name]);
            imageBrowseAndTestLightGreen.SetSettings(settings[imageBrowseAndTestLightGreen.Name]);
            imageBrowseAndTestDarkGreen.SetSettings(settings[imageBrowseAndTestDarkGreen.Name]);
            imageBrowseAndTestGold.SetSettings(settings[imageBrowseAndTestGold.Name]);
            imageBrowseAndTestNone.SetSettings(settings[imageBrowseAndTestNone.Name]);
        }
    }
}
