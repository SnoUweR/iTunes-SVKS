namespace iTunesSVKS
{
    partial class MainWnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWnd));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reauthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpdatesToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reauthContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.iTunesStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkiTunesTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            this.songArtistLabel = new System.Windows.Forms.Label();
            this.songNameLabel = new System.Windows.Forms.Label();
            this.lastFMBtn = new System.Windows.Forms.Button();
            this.customText = new System.Windows.Forms.TextBox();
            this.autoUpdCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBFriends = new System.Windows.Forms.ComboBox();
            this.changeShareTextBtn = new System.Windows.Forms.Button();
            this.albumArtCheckBox = new System.Windows.Forms.CheckBox();
            this.shareButton = new System.Windows.Forms.Button();
            this.wallSongButton = new System.Windows.Forms.Button();
            this.setStatusButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.idToCheck = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.onlineCheck = new System.Windows.Forms.CheckBox();
            this.friendsCheck = new System.Windows.Forms.CheckBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.friendsLabel = new System.Windows.Forms.Label();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.statusBoxCheck = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.actionsStatus = new System.Windows.Forms.RichTextBox();
            this.realSongChckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.supportMenuItem,
            this.checkUpdatesToolStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(526, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reauthToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.mainToolStripMenuItem.Text = "Меню";
            // 
            // reauthToolStripMenuItem
            // 
            this.reauthToolStripMenuItem.Name = "reauthToolStripMenuItem";
            this.reauthToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.reauthToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.reauthToolStripMenuItem.Text = "Перелогиниться";
            this.reauthToolStripMenuItem.Click += new System.EventHandler(this.reauthToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // supportMenuItem
            // 
            this.supportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.supportMenuItem.Name = "supportMenuItem";
            this.supportMenuItem.Size = new System.Drawing.Size(64, 20);
            this.supportMenuItem.Text = "Справка";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aboutMenuItem.Text = "О программе..";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // checkUpdatesToolStripMenu
            // 
            this.checkUpdatesToolStripMenu.Name = "checkUpdatesToolStripMenu";
            this.checkUpdatesToolStripMenu.Size = new System.Drawing.Size(147, 20);
            this.checkUpdatesToolStripMenu.Text = "Проверить обновления";
            this.checkUpdatesToolStripMenu.Click += new System.EventHandler(this.checkUpdatesToolStripMenu_Click);
            // 
            // reauthContextMenu
            // 
            this.reauthContextMenu.Name = "reauthContextMenu";
            this.reauthContextMenu.Size = new System.Drawing.Size(157, 22);
            this.reauthContextMenu.Text = "Перелогиниться";
            this.reauthContextMenu.ToolTipText = "Перелогиниться";
            this.reauthContextMenu.Click += new System.EventHandler(this.reauthContextMenu_Click);
            // 
            // updateStripMenu
            // 
            this.updateStripMenu.Name = "updateStripMenu";
            this.updateStripMenu.Size = new System.Drawing.Size(157, 22);
            this.updateStripMenu.Text = "Обновить";
            this.updateStripMenu.Click += new System.EventHandler(this.updateStripMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // exitContextMenu
            // 
            this.exitContextMenu.Name = "exitContextMenu";
            this.exitContextMenu.Size = new System.Drawing.Size(157, 22);
            this.exitContextMenu.Text = "Выход";
            this.exitContextMenu.ToolTipText = "Выход";
            this.exitContextMenu.Click += new System.EventHandler(this.exitContextMenu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iTunesStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(526, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // iTunesStatus
            // 
            this.iTunesStatus.ForeColor = System.Drawing.Color.Blue;
            this.iTunesStatus.Name = "iTunesStatus";
            this.iTunesStatus.Size = new System.Drawing.Size(80, 17);
            this.iTunesStatus.Text = "Ищем iTunes..";
            // 
            // timer1
            // 
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(187, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem2.Text = "Показать программу";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem3.Text = "Выйти";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.exitContextMenu_Click);
            // 
            // checkiTunesTimer
            // 
            this.checkiTunesTimer.Interval = 10000;
            this.checkiTunesTimer.Tick += new System.EventHandler(this.checkiTunesTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.songArtistLabel);
            this.groupBox1.Controls.Add(this.songNameLabel);
            this.groupBox1.Controls.Add(this.lastFMBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 213);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Композиция";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.albumArtBox);
            this.panel1.Location = new System.Drawing.Point(335, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 165);
            this.panel1.TabIndex = 31;
            // 
            // albumArtBox
            // 
            this.albumArtBox.Image = global::iTunesSVKS.Properties.Resources.art;
            this.albumArtBox.Location = new System.Drawing.Point(5, 5);
            this.albumArtBox.Name = "albumArtBox";
            this.albumArtBox.Size = new System.Drawing.Size(155, 155);
            this.albumArtBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.albumArtBox.TabIndex = 27;
            this.albumArtBox.TabStop = false;
            // 
            // songArtistLabel
            // 
            this.songArtistLabel.Location = new System.Drawing.Point(10, 145);
            this.songArtistLabel.Name = "songArtistLabel";
            this.songArtistLabel.Size = new System.Drawing.Size(313, 48);
            this.songArtistLabel.TabIndex = 30;
            this.songArtistLabel.Text = "Нет автора";
            this.songArtistLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // songNameLabel
            // 
            this.songNameLabel.AutoEllipsis = true;
            this.songNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.songNameLabel.Location = new System.Drawing.Point(10, 86);
            this.songNameLabel.Name = "songNameLabel";
            this.songNameLabel.Size = new System.Drawing.Size(307, 59);
            this.songNameLabel.TabIndex = 28;
            this.songNameLabel.Text = "Нет композиции";
            this.songNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lastFMBtn
            // 
            this.lastFMBtn.Enabled = false;
            this.lastFMBtn.Location = new System.Drawing.Point(335, 184);
            this.lastFMBtn.Name = "lastFMBtn";
            this.lastFMBtn.Size = new System.Drawing.Size(165, 23);
            this.lastFMBtn.TabIndex = 29;
            this.lastFMBtn.Text = "Загрузить с LastFM";
            this.lastFMBtn.UseVisualStyleBackColor = true;
            this.lastFMBtn.Click += new System.EventHandler(this.lastFMBtn_Click);
            // 
            // customText
            // 
            this.customText.Enabled = false;
            this.customText.Location = new System.Drawing.Point(6, 19);
            this.customText.Multiline = true;
            this.customText.Name = "customText";
            this.customText.Size = new System.Drawing.Size(311, 36);
            this.customText.TabIndex = 26;
            this.customText.Text = "Сейчас прослушиваю {artist} - {name} via iTunes";
            this.customText.TextChanged += new System.EventHandler(this.customText_TextChanged);
            // 
            // autoUpdCheckBox
            // 
            this.autoUpdCheckBox.AutoSize = true;
            this.autoUpdCheckBox.Enabled = false;
            this.autoUpdCheckBox.Location = new System.Drawing.Point(6, 100);
            this.autoUpdCheckBox.Name = "autoUpdCheckBox";
            this.autoUpdCheckBox.Size = new System.Drawing.Size(104, 17);
            this.autoUpdCheckBox.TabIndex = 7;
            this.autoUpdCheckBox.Text = "Автоматически";
            this.autoUpdCheckBox.UseVisualStyleBackColor = true;
            this.autoUpdCheckBox.CheckedChanged += new System.EventHandler(this.autoUpdCheckBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBFriends);
            this.groupBox4.Controls.Add(this.changeShareTextBtn);
            this.groupBox4.Controls.Add(this.albumArtCheckBox);
            this.groupBox4.Controls.Add(this.shareButton);
            this.groupBox4.Controls.Add(this.wallSongButton);
            this.groupBox4.Location = new System.Drawing.Point(342, 316);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 155);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Поделиться";
            // 
            // comboBFriends
            // 
            this.comboBFriends.Enabled = false;
            this.comboBFriends.FormattingEnabled = true;
            this.comboBFriends.Location = new System.Drawing.Point(6, 19);
            this.comboBFriends.Name = "comboBFriends";
            this.comboBFriends.Size = new System.Drawing.Size(161, 21);
            this.comboBFriends.TabIndex = 27;
            this.comboBFriends.Text = "Выберите друга";
            this.comboBFriends.SelectedIndexChanged += new System.EventHandler(this.comboBFriends_SelectedIndexChanged);
            // 
            // changeShareTextBtn
            // 
            this.changeShareTextBtn.Location = new System.Drawing.Point(5, 69);
            this.changeShareTextBtn.Name = "changeShareTextBtn";
            this.changeShareTextBtn.Size = new System.Drawing.Size(163, 23);
            this.changeShareTextBtn.TabIndex = 25;
            this.changeShareTextBtn.Text = "Изменить текст";
            this.changeShareTextBtn.UseVisualStyleBackColor = true;
            this.changeShareTextBtn.Click += new System.EventHandler(this.changeShareTextBtn_Click);
            // 
            // albumArtCheckBox
            // 
            this.albumArtCheckBox.AutoSize = true;
            this.albumArtCheckBox.Location = new System.Drawing.Point(6, 127);
            this.albumArtCheckBox.Name = "albumArtCheckBox";
            this.albumArtCheckBox.Size = new System.Drawing.Size(133, 17);
            this.albumArtCheckBox.TabIndex = 24;
            this.albumArtCheckBox.Text = "Прикрепить обложку";
            this.albumArtCheckBox.UseVisualStyleBackColor = true;
            this.albumArtCheckBox.CheckedChanged += new System.EventHandler(this.albumArtCheckBox_CheckedChanged);
            // 
            // shareButton
            // 
            this.shareButton.Enabled = false;
            this.shareButton.Location = new System.Drawing.Point(5, 42);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(163, 23);
            this.shareButton.TabIndex = 20;
            this.shareButton.Text = "Порекомендовать";
            this.shareButton.UseVisualStyleBackColor = true;
            this.shareButton.Click += new System.EventHandler(this.shareButton_Click);
            // 
            // wallSongButton
            // 
            this.wallSongButton.Enabled = false;
            this.wallSongButton.Location = new System.Drawing.Point(5, 98);
            this.wallSongButton.Name = "wallSongButton";
            this.wallSongButton.Size = new System.Drawing.Size(163, 23);
            this.wallSongButton.TabIndex = 21;
            this.wallSongButton.Text = "Поместить себе на страницу";
            this.wallSongButton.UseVisualStyleBackColor = true;
            this.wallSongButton.Click += new System.EventHandler(this.wallSongButton_Click);
            // 
            // setStatusButton
            // 
            this.setStatusButton.Enabled = false;
            this.setStatusButton.Location = new System.Drawing.Point(213, 96);
            this.setStatusButton.Name = "setStatusButton";
            this.setStatusButton.Size = new System.Drawing.Size(104, 23);
            this.setStatusButton.TabIndex = 4;
            this.setStatusButton.Text = "Обновить";
            this.setStatusButton.UseVisualStyleBackColor = true;
            this.setStatusButton.Click += new System.EventHandler(this.setStatusButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 61);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(311, 33);
            this.textBox2.TabIndex = 14;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Location = new System.Drawing.Point(12, 477);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(207, 110);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Обозначения";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(6, 19);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(190, 90);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "{name} - Название песни\r\n{artist} - Исполнитель песни\r\n{playlist} - Плейлист\r\n{al" +
    "bum} - Альбом\r\n{count} - Количество исполнений\r\n{genre} - Жанр";
            // 
            // idToCheck
            // 
            this.idToCheck.Location = new System.Drawing.Point(78, 22);
            this.idToCheck.Name = "idToCheck";
            this.idToCheck.Size = new System.Drawing.Size(100, 20);
            this.idToCheck.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(9, 48);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(169, 117);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            // 
            // onlineCheck
            // 
            this.onlineCheck.AutoSize = true;
            this.onlineCheck.Location = new System.Drawing.Point(6, 43);
            this.onlineCheck.Name = "onlineCheck";
            this.onlineCheck.Size = new System.Drawing.Size(64, 17);
            this.onlineCheck.TabIndex = 5;
            this.onlineCheck.Text = "Онлайн";
            this.onlineCheck.UseVisualStyleBackColor = true;
            // 
            // friendsCheck
            // 
            this.friendsCheck.AutoSize = true;
            this.friendsCheck.Location = new System.Drawing.Point(6, 19);
            this.friendsCheck.Name = "friendsCheck";
            this.friendsCheck.Size = new System.Drawing.Size(64, 17);
            this.friendsCheck.TabIndex = 4;
            this.friendsCheck.Text = "Друзья";
            this.friendsCheck.UseVisualStyleBackColor = true;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(6, 16);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(21, 13);
            this.idLabel.TabIndex = 0;
            // 
            // friendsLabel
            // 
            this.friendsLabel.AutoSize = true;
            this.friendsLabel.Location = new System.Drawing.Point(6, 32);
            this.friendsLabel.Name = "friendsLabel";
            this.friendsLabel.Size = new System.Drawing.Size(48, 13);
            this.friendsLabel.TabIndex = 1;
            // 
            // onlineLabel
            // 
            this.onlineLabel.AutoSize = true;
            this.onlineLabel.Location = new System.Drawing.Point(6, 51);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(48, 13);
            this.onlineLabel.TabIndex = 2;
            // 
            // statusBoxCheck
            // 
            this.statusBoxCheck.Enabled = false;
            this.statusBoxCheck.Location = new System.Drawing.Point(7, 70);
            this.statusBoxCheck.Multiline = true;
            this.statusBoxCheck.Name = "statusBoxCheck";
            this.statusBoxCheck.Size = new System.Drawing.Size(175, 59);
            this.statusBoxCheck.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(526, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.realSongChckBox);
            this.groupBox2.Controls.Add(this.customText);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.setStatusButton);
            this.groupBox2.Controls.Add(this.autoUpdCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 155);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шаблон";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.actionsStatus);
            this.groupBox3.Location = new System.Drawing.Point(225, 477);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 110);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Консоль ошибок";
            // 
            // actionsStatus
            // 
            this.actionsStatus.BackColor = System.Drawing.Color.Black;
            this.actionsStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.actionsStatus.Location = new System.Drawing.Point(3, 16);
            this.actionsStatus.Name = "actionsStatus";
            this.actionsStatus.ReadOnly = true;
            this.actionsStatus.Size = new System.Drawing.Size(285, 91);
            this.actionsStatus.TabIndex = 31;
            this.actionsStatus.Text = "";
            // 
            // realSongChckBox
            // 
            this.realSongChckBox.AutoSize = true;
            this.realSongChckBox.Location = new System.Drawing.Point(6, 123);
            this.realSongChckBox.Name = "realSongChckBox";
            this.realSongChckBox.Size = new System.Drawing.Size(267, 17);
            this.realSongChckBox.TabIndex = 27;
            this.realSongChckBox.Text = "Транслировать в статус реальную песню (Beta)";
            this.realSongChckBox.UseVisualStyleBackColor = true;
            this.realSongChckBox.CheckedChanged += new System.EventHandler(this.realSongCheckBox_CheckedChanged);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 616);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWnd";
            this.Text = "iTunes SVKS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWnd_FormClosing);
            this.Shown += new System.EventHandler(this.MainWnd_Shown);
            this.Resize += new System.EventHandler(this.MainWnd_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reauthToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel iTunesStatus;
        private System.Windows.Forms.Timer checkiTunesTimer;
        private System.Windows.Forms.ToolStripMenuItem supportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reauthContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitContextMenu;
        private System.Windows.Forms.ToolStripMenuItem updateStripMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox customText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button shareButton;
        private System.Windows.Forms.Button wallSongButton;
        private System.Windows.Forms.CheckBox autoUpdCheckBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button setStatusButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox idToCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox onlineCheck;
        private System.Windows.Forms.CheckBox friendsCheck;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label friendsLabel;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.TextBox statusBoxCheck;
        private System.Windows.Forms.CheckBox albumArtCheckBox;
        private System.Windows.Forms.Button changeShareTextBtn;
        private System.Windows.Forms.PictureBox albumArtBox;
        private System.Windows.Forms.ComboBox comboBFriends;
        private System.Windows.Forms.Label songNameLabel;
        private System.Windows.Forms.Button lastFMBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label songArtistLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox actionsStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem checkUpdatesToolStripMenu;
        private System.Windows.Forms.CheckBox realSongChckBox;
    }
}

