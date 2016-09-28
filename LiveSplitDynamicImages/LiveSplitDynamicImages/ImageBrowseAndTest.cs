using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LiveSplitDynamicImages
{
    public partial class ImageBrowseAndTest : UserControl
    {
        public string label
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public ObsPipe pipe { get; set; }
        public String imagePath { get; set; }
        public Image image {
            get { return button1.Image; }
            private set { button1.Image = value; }
        }

        public ImageBrowseAndTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                loadAndSetImage(file);
            }
        }

        private void loadAndSetImage(string path)
        {
            if (path.Equals(""))
            {
                button1.Image = null;
                imagePath = "";
                return;
            }
            try
            {
                Image image = Image.FromFile(path);
                Image scaledImage = scaleImage(image);
                button1.Image = scaledImage;
                imagePath = path;
            }
            catch (Exception ex) when (ex is OutOfMemoryException || ex is FileNotFoundException || ex is ArgumentException)
            {
            }
        }

        private Image scaleImage(Image image)
        {
            double imageWidthToHeight = image.Width / image.Height;
            double buttonWidthToHeight = button1.Width / button1.Height;
            double newImageScale;
            if (imageWidthToHeight < buttonWidthToHeight)
                newImageScale = image.Height / button1.Height;
            else
                newImageScale = image.Width / button1.Width;
            int newWidth = (int)(image.Width / newImageScale);
            int newHeight = (int)(image.Height / newImageScale);
            Bitmap scaledImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(scaledImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            return scaledImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pipe.changeImageFile(imagePath);
        }

        public void setImage(string imagePath, Image image)
        {
            this.imagePath = imagePath;
            this.image = image;
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            System.Xml.XmlNode settingsNode = document.CreateElement(this.Name);
            settingsNode.AppendChild(Settings.ToElement(document, "imagePath", imagePath));
            return settingsNode;
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            if (settings["imagePath"] != null)
            {
                loadAndSetImage(settings["imagePath"].InnerText);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadAndSetImage("");
        }
    }

}
