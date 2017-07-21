using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Drawing;
using Microsoft.Win32;

namespace DevinDow.VisionBoard
{
    class vbdFile
    {
        public static void Write(VisionBoard visionBoard)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".vbd";
            sfd.Title = "Save Vision Board file";
            sfd.Filter = "Vision Board files (*.vbd)|*.vbd|All Files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                /*RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\VisionBoard");
                key.SetValue("currentVbdFile", sfd.FileName);
                key.Close();*/
                Properties.Settings.Default.CurrentVisionBoardFile = sfd.FileName;
                Properties.Settings.Default.Save();

                Write(sfd.FileName, visionBoard);
            }
        }

        public static void Write(string filename, VisionBoard visionBoard)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                FileInfo fi = new FileInfo(filename);
                string imageDirectory = fi.DirectoryName + "\\" + fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);
                Directory.CreateDirectory(imageDirectory);

                writer.WriteStartElement("VisionBoard");

                foreach (ImageItem item in visionBoard.Items)
                {
                    item.Write(writer);
                    string bmpFilename = imageDirectory + "\\" + item.Filename + ".bmp";
					try { item.Image.Save(bmpFilename); }
					catch (Exception) { }
                }

                writer.WriteEndElement();

                writer.Flush();
            }

            visionBoard.IsDirty = false;
        }

        public static VisionBoard Read()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".vbd";
            ofd.Title = "Save Vision Board file";
            ofd.Filter = "Vision Board files (*.vbd)|*.vbd|All Files (*.*)|*.*";
			ofd.FileName = Properties.Settings.Default.CurrentVisionBoardFile;
			try 
			{ 
				FileInfo fi = new FileInfo(Properties.Settings.Default.CurrentVisionBoardFile);
				ofd.InitialDirectory = fi.DirectoryName;
			}
			catch (Exception) { }
            if (ofd.ShowDialog() != DialogResult.OK)
                return null;

            /*RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\VisionBoard");
            key.SetValue("currentVbdFile", ofd.FileName);
            key.Close();*/
            Properties.Settings.Default.CurrentVisionBoardFile = ofd.FileName;
            Properties.Settings.Default.Save();

            return Read(ofd.FileName);
        }

        public static VisionBoard Read(string filename)
        {
            VisionBoard visionBoard = new VisionBoard();

            if (filename.Length == 0)
                return visionBoard;

            if (!File.Exists(filename))
            {
                MessageBox.Show(filename, "File does not exist");
                return visionBoard;
            }

            visionBoard.Filename = filename;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(filename))
                {
                    FileInfo fi = new FileInfo(filename);
                    string imageDirectory = fi.DirectoryName + "\\" + fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);

                    while (reader.Read())
                    {
                        reader.MoveToContent();

                        if (reader.NodeType == System.Xml.XmlNodeType.Element)
                        {
                            if (reader.Name == "Image")
                            {
                                ImageItem item = new ImageItem();
                                item.X = int.Parse(reader.GetAttribute("x"));
                                item.Y = int.Parse(reader.GetAttribute("y"));
                                item.RotationDegrees = float.Parse(reader.GetAttribute("rotation"));
                                item.Scale = float.Parse(reader.GetAttribute("scale"));
                                item.Caption = reader.GetAttribute("caption");

                                item.Filename = reader.GetAttribute("filename");
                                string path = imageDirectory + "\\" + item.Filename + ".bmp";
                                try
                                {
                                    int index = int.Parse(item.Filename);
                                    if (index >= visionBoard.nextIndex)
                                        visionBoard.nextIndex = index + 1;
                                }
                                catch (Exception) { }

                                if (File.Exists(path))
                                {
                                    item.Image = Image.FromFile(path);
                                    visionBoard.Items.Add(item);
                                }
                                else
                                    MessageBox.Show(path, "File does not exist");
                            }
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
             
            return visionBoard;
        }
    }
}
