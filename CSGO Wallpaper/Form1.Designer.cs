using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CSGO_Wallpaper
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.Home = new System.Windows.Forms.TabPage();
            this.materialSingleLineTextField3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Refresh_wallpaper_button = new MaterialSkin.Controls.MaterialFlatButton();
            this.Start_cs_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Shortcut_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Random_wallpaper = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Change_selected_wallpaper = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Change_wallpaper_path_button = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Tools = new System.Windows.Forms.TabPage();
            this.materialSingleLineTextField4 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Change_FileToReplace_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Change_CSGOfolder_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.Remove_textColorMod_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Add_textColorMod_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialSingleLineTextField2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.About = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.materialTabControl1.SuspendLayout();
            this.Home.SuspendLayout();
            this.Tools.SuspendLayout();
            this.About.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.materialTabControl1.Controls.Add(this.Home);
            this.materialTabControl1.Controls.Add(this.Tools);
            this.materialTabControl1.Controls.Add(this.About);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(-4, 67);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(581, 528);
            this.materialTabControl1.TabIndex = 12;
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.Color.White;
            this.Home.Controls.Add(this.materialSingleLineTextField3);
            this.Home.Controls.Add(this.Refresh_wallpaper_button);
            this.Home.Controls.Add(this.Start_cs_button);
            this.Home.Controls.Add(this.Shortcut_button);
            this.Home.Controls.Add(this.Random_wallpaper);
            this.Home.Controls.Add(this.Change_selected_wallpaper);
            this.Home.Controls.Add(this.materialListView1);
            this.Home.Controls.Add(this.Change_wallpaper_path_button);
            this.Home.Controls.Add(this.materialSingleLineTextField1);
            this.Home.Location = new System.Drawing.Point(4, 4);
            this.Home.Margin = new System.Windows.Forms.Padding(0);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(573, 502);
            this.Home.TabIndex = 0;
            this.Home.Text = "Home";
            // 
            // materialSingleLineTextField3
            // 
            this.materialSingleLineTextField3.Depth = 0;
            this.materialSingleLineTextField3.Enabled = false;
            this.materialSingleLineTextField3.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialSingleLineTextField3.Hint = "";
            this.materialSingleLineTextField3.Location = new System.Drawing.Point(123, 8);
            this.materialSingleLineTextField3.MaxLength = 32767;
            this.materialSingleLineTextField3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField3.Name = "materialSingleLineTextField3";
            this.materialSingleLineTextField3.PasswordChar = '\0';
            this.materialSingleLineTextField3.SelectedText = "";
            this.materialSingleLineTextField3.SelectionLength = 0;
            this.materialSingleLineTextField3.SelectionStart = 0;
            this.materialSingleLineTextField3.Size = new System.Drawing.Size(370, 23);
            this.materialSingleLineTextField3.TabIndex = 46;
            this.materialSingleLineTextField3.TabStop = false;
            this.materialSingleLineTextField3.UseSystemPasswordChar = false;
            // 
            // Refresh_wallpaper_button
            // 
            this.Refresh_wallpaper_button.AutoSize = true;
            this.Refresh_wallpaper_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Refresh_wallpaper_button.Depth = 0;
            this.Refresh_wallpaper_button.Icon = ((System.Drawing.Image)(resources.GetObject("Refresh_wallpaper_button.Icon")));
            this.Refresh_wallpaper_button.Location = new System.Drawing.Point(500, 0);
            this.Refresh_wallpaper_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Refresh_wallpaper_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Refresh_wallpaper_button.Name = "Refresh_wallpaper_button";
            this.Refresh_wallpaper_button.Primary = false;
            this.Refresh_wallpaper_button.Size = new System.Drawing.Size(44, 36);
            this.Refresh_wallpaper_button.TabIndex = 45;
            this.Refresh_wallpaper_button.UseVisualStyleBackColor = true;
            this.Refresh_wallpaper_button.Click += new System.EventHandler(this.Refresh_wallpaper_button_Click);
            // 
            // Start_cs_button
            // 
            this.Start_cs_button.AutoSize = true;
            this.Start_cs_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Start_cs_button.Depth = 0;
            this.Start_cs_button.Icon = ((System.Drawing.Image)(resources.GetObject("Start_cs_button.Icon")));
            this.Start_cs_button.Location = new System.Drawing.Point(202, 356);
            this.Start_cs_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Start_cs_button.Name = "Start_cs_button";
            this.Start_cs_button.Primary = true;
            this.Start_cs_button.Size = new System.Drawing.Size(135, 36);
            this.Start_cs_button.TabIndex = 44;
            this.Start_cs_button.Text = "Start CS:GO";
            this.Start_cs_button.UseVisualStyleBackColor = true;
            this.Start_cs_button.Click += new System.EventHandler(this.Start_cs_button_Click);
            // 
            // Shortcut_button
            // 
            this.Shortcut_button.AutoSize = true;
            this.Shortcut_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Shortcut_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Shortcut_button.Depth = 0;
            this.Shortcut_button.Icon = ((System.Drawing.Image)(resources.GetObject("Shortcut_button.Icon")));
            this.Shortcut_button.Location = new System.Drawing.Point(268, 314);
            this.Shortcut_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Shortcut_button.Name = "Shortcut_button";
            this.Shortcut_button.Primary = true;
            this.Shortcut_button.Size = new System.Drawing.Size(174, 36);
            this.Shortcut_button.TabIndex = 43;
            this.Shortcut_button.Text = "Create Shortcut";
            this.Shortcut_button.UseVisualStyleBackColor = true;
            this.Shortcut_button.Click += new System.EventHandler(this.Shortcut_button_Click);
            // 
            // Random_wallpaper
            // 
            this.Random_wallpaper.AutoSize = true;
            this.Random_wallpaper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Random_wallpaper.Depth = 0;
            this.Random_wallpaper.Icon = ((System.Drawing.Image)(resources.GetObject("Random_wallpaper.Icon")));
            this.Random_wallpaper.Location = new System.Drawing.Point(7, 356);
            this.Random_wallpaper.MouseState = MaterialSkin.MouseState.HOVER;
            this.Random_wallpaper.Name = "Random_wallpaper";
            this.Random_wallpaper.Primary = true;
            this.Random_wallpaper.Size = new System.Drawing.Size(189, 36);
            this.Random_wallpaper.TabIndex = 42;
            this.Random_wallpaper.Text = "Random wallpaper";
            this.Random_wallpaper.UseVisualStyleBackColor = true;
            this.Random_wallpaper.Click += new System.EventHandler(this.Random_wallpaper_Click);
            // 
            // Change_selected_wallpaper
            // 
            this.Change_selected_wallpaper.AutoSize = true;
            this.Change_selected_wallpaper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Change_selected_wallpaper.Depth = 0;
            this.Change_selected_wallpaper.Icon = ((System.Drawing.Image)(resources.GetObject("Change_selected_wallpaper.Icon")));
            this.Change_selected_wallpaper.Location = new System.Drawing.Point(7, 314);
            this.Change_selected_wallpaper.MouseState = MaterialSkin.MouseState.HOVER;
            this.Change_selected_wallpaper.Name = "Change_selected_wallpaper";
            this.Change_selected_wallpaper.Primary = true;
            this.Change_selected_wallpaper.Size = new System.Drawing.Size(255, 36);
            this.Change_selected_wallpaper.TabIndex = 41;
            this.Change_selected_wallpaper.Text = "Change selected wallpaper";
            this.Change_selected_wallpaper.UseVisualStyleBackColor = true;
            this.Change_selected_wallpaper.Click += new System.EventHandler(this.Change_selected_wallpaper_Click);
            // 
            // materialListView1
            // 
            this.materialListView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.materialListView1.Depth = 0;
            this.materialListView1.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.materialListView1.FullRowSelect = true;
            this.materialListView1.GridLines = true;
            this.materialListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.materialListView1.HideSelection = false;
            this.materialListView1.HoverSelection = true;
            this.materialListView1.Location = new System.Drawing.Point(0, -4);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.MultiSelect = false;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.ShowGroups = false;
            this.materialListView1.Size = new System.Drawing.Size(569, 312);
            this.materialListView1.TabIndex = 36;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Current wallpaper:";
            this.columnHeader1.Width = 550;
            // 
            // Change_wallpaper_path_button
            // 
            this.Change_wallpaper_path_button.AutoSize = true;
            this.Change_wallpaper_path_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Change_wallpaper_path_button.Depth = 0;
            this.Change_wallpaper_path_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Change_wallpaper_path_button.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Change_wallpaper_path_button.Icon = null;
            this.Change_wallpaper_path_button.Location = new System.Drawing.Point(7, 407);
            this.Change_wallpaper_path_button.Margin = new System.Windows.Forms.Padding(0);
            this.Change_wallpaper_path_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Change_wallpaper_path_button.Name = "Change_wallpaper_path_button";
            this.Change_wallpaper_path_button.Primary = false;
            this.Change_wallpaper_path_button.Size = new System.Drawing.Size(57, 36);
            this.Change_wallpaper_path_button.TabIndex = 35;
            this.Change_wallpaper_path_button.Text = "Open";
            this.Change_wallpaper_path_button.UseVisualStyleBackColor = true;
            this.Change_wallpaper_path_button.Click += new System.EventHandler(this.Change_wallpaper_path_button_Click_1);
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(67, 414);
            this.materialSingleLineTextField1.MaxLength = 32767;
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(502, 23);
            this.materialSingleLineTextField1.TabIndex = 34;
            this.materialSingleLineTextField1.TabStop = false;
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // Tools
            // 
            this.Tools.BackColor = System.Drawing.Color.White;
            this.Tools.Controls.Add(this.materialSingleLineTextField4);
            this.Tools.Controls.Add(this.Change_FileToReplace_button);
            this.Tools.Controls.Add(this.Change_CSGOfolder_button);
            this.Tools.Controls.Add(this.materialLabel2);
            this.Tools.Controls.Add(this.Remove_textColorMod_button);
            this.Tools.Controls.Add(this.Add_textColorMod_button);
            this.Tools.Controls.Add(this.materialSingleLineTextField2);
            this.Tools.Location = new System.Drawing.Point(4, 4);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(573, 502);
            this.Tools.TabIndex = 2;
            this.Tools.Text = "Tools";
            // 
            // materialSingleLineTextField4
            // 
            this.materialSingleLineTextField4.Depth = 0;
            this.materialSingleLineTextField4.Enabled = false;
            this.materialSingleLineTextField4.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialSingleLineTextField4.Hint = "";
            this.materialSingleLineTextField4.Location = new System.Drawing.Point(250, 52);
            this.materialSingleLineTextField4.MaxLength = 32767;
            this.materialSingleLineTextField4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField4.Name = "materialSingleLineTextField4";
            this.materialSingleLineTextField4.PasswordChar = '\0';
            this.materialSingleLineTextField4.SelectedText = "";
            this.materialSingleLineTextField4.SelectionLength = 0;
            this.materialSingleLineTextField4.SelectionStart = 0;
            this.materialSingleLineTextField4.Size = new System.Drawing.Size(318, 23);
            this.materialSingleLineTextField4.TabIndex = 43;
            this.materialSingleLineTextField4.TabStop = false;
            this.materialSingleLineTextField4.UseSystemPasswordChar = false;
            // 
            // Change_FileToReplace_button
            // 
            this.Change_FileToReplace_button.AutoSize = true;
            this.Change_FileToReplace_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Change_FileToReplace_button.Depth = 0;
            this.Change_FileToReplace_button.Icon = null;
            this.Change_FileToReplace_button.Location = new System.Drawing.Point(12, 45);
            this.Change_FileToReplace_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Change_FileToReplace_button.Name = "Change_FileToReplace_button";
            this.Change_FileToReplace_button.Primary = true;
            this.Change_FileToReplace_button.Size = new System.Drawing.Size(233, 36);
            this.Change_FileToReplace_button.TabIndex = 42;
            this.Change_FileToReplace_button.Text = "Change webm file to replace";
            this.Change_FileToReplace_button.UseVisualStyleBackColor = true;
            this.Change_FileToReplace_button.Click += new System.EventHandler(this.Change_FileToReplace_button_Click);
            // 
            // Change_CSGOfolder_button
            // 
            this.Change_CSGOfolder_button.AutoSize = true;
            this.Change_CSGOfolder_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Change_CSGOfolder_button.Depth = 0;
            this.Change_CSGOfolder_button.Icon = null;
            this.Change_CSGOfolder_button.Location = new System.Drawing.Point(12, 3);
            this.Change_CSGOfolder_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Change_CSGOfolder_button.Name = "Change_CSGOfolder_button";
            this.Change_CSGOfolder_button.Primary = true;
            this.Change_CSGOfolder_button.Size = new System.Drawing.Size(158, 36);
            this.Change_CSGOfolder_button.TabIndex = 41;
            this.Change_CSGOfolder_button.Text = "Change CS:GO path";
            this.Change_CSGOfolder_button.UseVisualStyleBackColor = true;
            this.Change_CSGOfolder_button.Click += new System.EventHandler(this.Change_CSGOfolder_button_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(208, 389);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(130, 38);
            this.materialLabel2.TabIndex = 40;
            this.materialLabel2.Text = "Text color mod by\r\nBananaGaming";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Remove_textColorMod_button
            // 
            this.Remove_textColorMod_button.AutoSize = true;
            this.Remove_textColorMod_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Remove_textColorMod_button.Depth = 0;
            this.Remove_textColorMod_button.Icon = null;
            this.Remove_textColorMod_button.Location = new System.Drawing.Point(366, 390);
            this.Remove_textColorMod_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Remove_textColorMod_button.Name = "Remove_textColorMod_button";
            this.Remove_textColorMod_button.Primary = true;
            this.Remove_textColorMod_button.Size = new System.Drawing.Size(193, 36);
            this.Remove_textColorMod_button.TabIndex = 39;
            this.Remove_textColorMod_button.Text = "Remove Text Color Mod";
            this.Remove_textColorMod_button.UseVisualStyleBackColor = true;
            this.Remove_textColorMod_button.Click += new System.EventHandler(this.Remove_textColorMod_button_Click);
            // 
            // Add_textColorMod_button
            // 
            this.Add_textColorMod_button.AutoSize = true;
            this.Add_textColorMod_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Add_textColorMod_button.Depth = 0;
            this.Add_textColorMod_button.Icon = null;
            this.Add_textColorMod_button.Location = new System.Drawing.Point(12, 390);
            this.Add_textColorMod_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Add_textColorMod_button.Name = "Add_textColorMod_button";
            this.Add_textColorMod_button.Primary = true;
            this.Add_textColorMod_button.Size = new System.Drawing.Size(166, 36);
            this.Add_textColorMod_button.TabIndex = 38;
            this.Add_textColorMod_button.Text = "Add Text Color Mod";
            this.Add_textColorMod_button.UseVisualStyleBackColor = true;
            this.Add_textColorMod_button.Click += new System.EventHandler(this.Add_textColorMod_button_Click);
            // 
            // materialSingleLineTextField2
            // 
            this.materialSingleLineTextField2.Depth = 0;
            this.materialSingleLineTextField2.Enabled = false;
            this.materialSingleLineTextField2.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialSingleLineTextField2.Hint = "";
            this.materialSingleLineTextField2.Location = new System.Drawing.Point(176, 10);
            this.materialSingleLineTextField2.MaxLength = 32767;
            this.materialSingleLineTextField2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            this.materialSingleLineTextField2.PasswordChar = '\0';
            this.materialSingleLineTextField2.SelectedText = "";
            this.materialSingleLineTextField2.SelectionLength = 0;
            this.materialSingleLineTextField2.SelectionStart = 0;
            this.materialSingleLineTextField2.Size = new System.Drawing.Size(392, 23);
            this.materialSingleLineTextField2.TabIndex = 35;
            this.materialSingleLineTextField2.TabStop = false;
            this.materialSingleLineTextField2.UseSystemPasswordChar = false;
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.White;
            this.About.Controls.Add(this.label7);
            this.About.Controls.Add(this.label6);
            this.About.Controls.Add(this.label5);
            this.About.Controls.Add(this.label4);
            this.About.Controls.Add(this.label3);
            this.About.Controls.Add(this.label2);
            this.About.Controls.Add(this.label1);
            this.About.Controls.Add(this.linkLabel1);
            this.About.Controls.Add(this.linkLabel2);
            this.About.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About.Location = new System.Drawing.Point(4, 4);
            this.About.Name = "About";
            this.About.Padding = new System.Windows.Forms.Padding(3);
            this.About.Size = new System.Drawing.Size(573, 502);
            this.About.TabIndex = 1;
            this.About.Text = "About";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(270, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 18);
            this.label7.TabIndex = 42;
            this.label7.Text = "BananaGaming";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(303, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 33);
            this.label6.TabIndex = 41;
            this.label6.Text = "1.3";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(176, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "leonmisch@gmail.com\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(285, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 25);
            this.label4.TabIndex = 39;
            this.label4.Text = "Leon M.\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 36);
            this.label3.TabIndex = 38;
            this.label3.Text = "Text color mod by BananaGaming\r\nI do not own the wallpapers credit goes to their " +
    "respective owner!\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(524, 75);
            this.label2.TabIndex = 37;
            this.label2.Text = "Made by Leon M.\r\nFor suggestions, bug reports and other stuff email me at: \r\nleon" +
    "misch@gmail.com\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 66);
            this.label1.TabIndex = 36;
            this.label1.Text = "CS:GO wallpaper changer \r\nversion 1.3\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Orange;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.linkLabel1.Location = new System.Drawing.Point(98, 220);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(374, 33);
            this.linkLabel1.TabIndex = 35;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "View this project on Github.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked_1);
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Orange;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.linkLabel2.Location = new System.Drawing.Point(98, 292);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(371, 33);
            this.linkLabel2.TabIndex = 34;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Click here to open how to...";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Gainsboro;
            this.button4.Location = new System.Drawing.Point(861, 484);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 23);
            this.button4.TabIndex = 28;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(215, 24);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(694, 40);
            this.materialTabSelector1.TabIndex = 23;
            this.materialTabSelector1.Text = "materialTabSelector1";
            this.materialTabSelector1.Click += new System.EventHandler(this.MaterialTabSelector1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(571, 28);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.ShortcutsEnabled = false;
            this.richTextBox1.Size = new System.Drawing.Size(338, 479);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(907, 504);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Sizable = false;
            this.Text = "CS:GO Wallpaper Changer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.Home.ResumeLayout(false);
            this.Home.PerformLayout();
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            this.ResumeLayout(false);

        }

      

       

        #endregion
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage Home;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
       
        private System.Windows.Forms.Button button4;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private RichTextBox richTextBox1;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private ColumnHeader columnHeader1;
        private MaterialSkin.Controls.MaterialRaisedButton Change_selected_wallpaper;
        private MaterialSkin.Controls.MaterialFlatButton Change_wallpaper_path_button;
        private MaterialSkin.Controls.MaterialRaisedButton Random_wallpaper;
        private MaterialSkin.Controls.MaterialRaisedButton Shortcut_button;
        private MaterialSkin.Controls.MaterialRaisedButton Start_cs_button;
        private TabPage Tools;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField2;
        private MaterialSkin.Controls.MaterialFlatButton Refresh_wallpaper_button;
        private MaterialSkin.Controls.MaterialRaisedButton Add_textColorMod_button;
        private MaterialSkin.Controls.MaterialRaisedButton Remove_textColorMod_button;
        private TabPage About;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField3;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private MaterialSkin.Controls.MaterialRaisedButton Change_CSGOfolder_button;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField4;
        private MaterialSkin.Controls.MaterialRaisedButton Change_FileToReplace_button;
    }


}

