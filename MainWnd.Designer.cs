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
            this.actionsStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.customText = new System.Windows.Forms.TextBox();
            this.customSet = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.albumArtCheckBox = new System.Windows.Forms.CheckBox();
            this.actionsStatus = new System.Windows.Forms.Label();
            this.idInput = new System.Windows.Forms.TextBox();
            this.shareButton = new System.Windows.Forms.Button();
            this.wallSongButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.genreCheck = new System.Windows.Forms.CheckBox();
            this.customStatus = new System.Windows.Forms.CheckBox();
            this.statusStatus = new System.Windows.Forms.Label();
            this.showTipsCheck = new System.Windows.Forms.CheckBox();
            this.setTemplateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.countCheck = new System.Windows.Forms.CheckBox();
            this.playlistUse = new System.Windows.Forms.CheckBox();
            this.templateForStatus = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.setStatusButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.oldStatusButton = new System.Windows.Forms.Button();
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
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.supportMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
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
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.mainToolStripMenuItem.Text = "Меню";
            // 
            // reauthToolStripMenuItem
            // 
            this.reauthToolStripMenuItem.Name = "reauthToolStripMenuItem";
            this.reauthToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.reauthToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.reauthToolStripMenuItem.Text = "Перелогиниться";
            this.reauthToolStripMenuItem.Click += new System.EventHandler(this.reauthToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // supportMenuItem
            // 
            this.supportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.supportMenuItem.Name = "supportMenuItem";
            this.supportMenuItem.Size = new System.Drawing.Size(65, 20);
            this.supportMenuItem.Text = "Справка";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aboutMenuItem.Text = "О программе..";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 625);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(559, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // iTunesStatus
            // 
            this.iTunesStatus.ForeColor = System.Drawing.Color.Blue;
            this.iTunesStatus.Name = "iTunesStatus";
            this.iTunesStatus.Size = new System.Drawing.Size(86, 17);
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
            this.contextMenuStrip2.Size = new System.Drawing.Size(191, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem2.Text = "Показать программу";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem3.Text = "Выйти";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.exitContextMenu_Click);
            // 
            // checkiTunesTimer
            // 
            this.checkiTunesTimer.Interval = 10000;
            this.checkiTunesTimer.Tick += new System.EventHandler(this.checkiTunesTimer_Tick);
            // 
            // actionsStatusTimer
            // 
            this.actionsStatusTimer.Interval = 5000;
            this.actionsStatusTimer.Tick += new System.EventHandler(this.actionsStatusTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customText);
            this.groupBox1.Controls.Add(this.customSet);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.setStatusButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 402);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Статус";
            // 
            // customText
            // 
            this.customText.Enabled = false;
            this.customText.Location = new System.Drawing.Point(6, 87);
            this.customText.Multiline = true;
            this.customText.Name = "customText";
            this.customText.Size = new System.Drawing.Size(523, 39);
            this.customText.TabIndex = 26;
            this.customText.TextChanged += new System.EventHandler(this.customText_TextChanged);
            // 
            // customSet
            // 
            this.customSet.Enabled = false;
            this.customSet.Location = new System.Drawing.Point(420, 132);
            this.customSet.Name = "customSet";
            this.customSet.Size = new System.Drawing.Size(109, 23);
            this.customSet.TabIndex = 25;
            this.customSet.Text = "Предпросмотр";
            this.customSet.UseVisualStyleBackColor = true;
            this.customSet.Click += new System.EventHandler(this.customSet_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.albumArtCheckBox);
            this.groupBox4.Controls.Add(this.actionsStatus);
            this.groupBox4.Controls.Add(this.idInput);
            this.groupBox4.Controls.Add(this.shareButton);
            this.groupBox4.Controls.Add(this.wallSongButton);
            this.groupBox4.Location = new System.Drawing.Point(326, 163);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 233);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Действия";
            // 
            // albumArtCheckBox
            // 
            this.albumArtCheckBox.AutoSize = true;
            this.albumArtCheckBox.Enabled = false;
            this.albumArtCheckBox.Location = new System.Drawing.Point(10, 106);
            this.albumArtCheckBox.Name = "albumArtCheckBox";
            this.albumArtCheckBox.Size = new System.Drawing.Size(186, 30);
            this.albumArtCheckBox.TabIndex = 24;
            this.albumArtCheckBox.Text = "Прикрепить обложку альбома, \r\nесли это возможно";
            this.albumArtCheckBox.UseVisualStyleBackColor = true;
            this.albumArtCheckBox.CheckedChanged += new System.EventHandler(this.albumArtCheckBox_CheckedChanged);
            // 
            // actionsStatus
            // 
            this.actionsStatus.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.actionsStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actionsStatus.Enabled = false;
            this.actionsStatus.ForeColor = System.Drawing.Color.Black;
            this.actionsStatus.Location = new System.Drawing.Point(6, 170);
            this.actionsStatus.Name = "actionsStatus";
            this.actionsStatus.Size = new System.Drawing.Size(191, 60);
            this.actionsStatus.TabIndex = 23;
            this.actionsStatus.Text = "Выберите необходимое действие.";
            // 
            // idInput
            // 
            this.idInput.Enabled = false;
            this.idInput.Location = new System.Drawing.Point(22, 23);
            this.idInput.Name = "idInput";
            this.idInput.Size = new System.Drawing.Size(163, 20);
            this.idInput.TabIndex = 22;
            this.idInput.TextChanged += new System.EventHandler(this.idInput_TextChanged);
            // 
            // shareButton
            // 
            this.shareButton.Enabled = false;
            this.shareButton.Location = new System.Drawing.Point(22, 42);
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
            this.wallSongButton.Location = new System.Drawing.Point(22, 71);
            this.wallSongButton.Name = "wallSongButton";
            this.wallSongButton.Size = new System.Drawing.Size(163, 25);
            this.wallSongButton.TabIndex = 21;
            this.wallSongButton.Text = "Поместить себе на страницу";
            this.wallSongButton.UseVisualStyleBackColor = true;
            this.wallSongButton.Click += new System.EventHandler(this.wallSongButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.genreCheck);
            this.groupBox2.Controls.Add(this.customStatus);
            this.groupBox2.Controls.Add(this.statusStatus);
            this.groupBox2.Controls.Add(this.showTipsCheck);
            this.groupBox2.Controls.Add(this.setTemplateButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.countCheck);
            this.groupBox2.Controls.Add(this.playlistUse);
            this.groupBox2.Controls.Add(this.templateForStatus);
            this.groupBox2.Location = new System.Drawing.Point(6, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 233);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // genreCheck
            // 
            this.genreCheck.AutoSize = true;
            this.genreCheck.Enabled = false;
            this.genreCheck.Location = new System.Drawing.Point(6, 127);
            this.genreCheck.Name = "genreCheck";
            this.genreCheck.Size = new System.Drawing.Size(55, 17);
            this.genreCheck.TabIndex = 21;
            this.genreCheck.Text = "Жанр";
            this.genreCheck.UseVisualStyleBackColor = true;
            this.genreCheck.CheckedChanged += new System.EventHandler(this.genreCheck_CheckedChanged);
            // 
            // customStatus
            // 
            this.customStatus.AutoSize = true;
            this.customStatus.Enabled = false;
            this.customStatus.Location = new System.Drawing.Point(6, 39);
            this.customStatus.Name = "customStatus";
            this.customStatus.Size = new System.Drawing.Size(51, 17);
            this.customStatus.TabIndex = 20;
            this.customStatus.Text = "Свой";
            this.customStatus.UseVisualStyleBackColor = true;
            this.customStatus.CheckedChanged += new System.EventHandler(this.customStatus_CheckedChanged);
            // 
            // statusStatus
            // 
            this.statusStatus.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.statusStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusStatus.Enabled = false;
            this.statusStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStatus.ForeColor = System.Drawing.Color.Black;
            this.statusStatus.Location = new System.Drawing.Point(6, 170);
            this.statusStatus.Name = "statusStatus";
            this.statusStatus.Size = new System.Drawing.Size(302, 60);
            this.statusStatus.TabIndex = 18;
            this.statusStatus.Text = "Всё работает корректно.";
            // 
            // showTipsCheck
            // 
            this.showTipsCheck.AutoSize = true;
            this.showTipsCheck.Location = new System.Drawing.Point(6, 150);
            this.showTipsCheck.Name = "showTipsCheck";
            this.showTipsCheck.Size = new System.Drawing.Size(174, 17);
            this.showTipsCheck.TabIndex = 19;
            this.showTipsCheck.Text = "Не показывать уведомления";
            this.showTipsCheck.UseVisualStyleBackColor = true;
            this.showTipsCheck.CheckedChanged += new System.EventHandler(this.showTipsCheck_CheckedChanged);
            // 
            // setTemplateButton
            // 
            this.setTemplateButton.Location = new System.Drawing.Point(225, 65);
            this.setTemplateButton.Name = "setTemplateButton";
            this.setTemplateButton.Size = new System.Drawing.Size(81, 23);
            this.setTemplateButton.TabIndex = 11;
            this.setTemplateButton.Text = "Установить";
            this.setTemplateButton.UseVisualStyleBackColor = true;
            this.setTemplateButton.Click += new System.EventHandler(this.setTemplateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Префикс";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Обновлять";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // countCheck
            // 
            this.countCheck.AutoSize = true;
            this.countCheck.Enabled = false;
            this.countCheck.Location = new System.Drawing.Point(6, 106);
            this.countCheck.Name = "countCheck";
            this.countCheck.Size = new System.Drawing.Size(66, 17);
            this.countCheck.TabIndex = 16;
            this.countCheck.Text = "Счетчик";
            this.countCheck.UseVisualStyleBackColor = true;
            this.countCheck.CheckedChanged += new System.EventHandler(this.countCheck_CheckedChanged);
            // 
            // playlistUse
            // 
            this.playlistUse.AutoSize = true;
            this.playlistUse.Enabled = false;
            this.playlistUse.Location = new System.Drawing.Point(6, 83);
            this.playlistUse.Name = "playlistUse";
            this.playlistUse.Size = new System.Drawing.Size(75, 17);
            this.playlistUse.TabIndex = 13;
            this.playlistUse.Text = "Плейлист";
            this.playlistUse.UseVisualStyleBackColor = true;
            this.playlistUse.CheckedChanged += new System.EventHandler(this.playlistUse_CheckedChanged);
            // 
            // templateForStatus
            // 
            this.templateForStatus.Location = new System.Drawing.Point(118, 39);
            this.templateForStatus.Name = "templateForStatus";
            this.templateForStatus.Size = new System.Drawing.Size(188, 20);
            this.templateForStatus.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(523, 33);
            this.textBox2.TabIndex = 14;
            // 
            // setStatusButton
            // 
            this.setStatusButton.Enabled = false;
            this.setStatusButton.Location = new System.Drawing.Point(448, 58);
            this.setStatusButton.Name = "setStatusButton";
            this.setStatusButton.Size = new System.Drawing.Size(81, 23);
            this.setStatusButton.TabIndex = 4;
            this.setStatusButton.Text = "Установить";
            this.setStatusButton.UseVisualStyleBackColor = true;
            this.setStatusButton.Click += new System.EventHandler(this.setStatusButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.oldStatusButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 499);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 116);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Первоначальный статус";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(306, 59);
            this.textBox1.TabIndex = 3;
            // 
            // oldStatusButton
            // 
            this.oldStatusButton.Location = new System.Drawing.Point(198, 84);
            this.oldStatusButton.Name = "oldStatusButton";
            this.oldStatusButton.Size = new System.Drawing.Size(114, 23);
            this.oldStatusButton.TabIndex = 8;
            this.oldStatusButton.Text = "Вернуть";
            this.oldStatusButton.UseVisualStyleBackColor = true;
            this.oldStatusButton.Click += new System.EventHandler(this.oldStatusButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(338, 499);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(209, 116);
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
    "bum} - Альбом\r\n{count} - Количество исполнений\r\n{genre} - Жанр\r\n{prefix} - Префи" +
    "кс";
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
            this.pictureBox1.Size = new System.Drawing.Size(559, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 647);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Timer actionsStatusTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox customText;
        private System.Windows.Forms.Button customSet;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label actionsStatus;
        private System.Windows.Forms.TextBox idInput;
        private System.Windows.Forms.Button shareButton;
        private System.Windows.Forms.Button wallSongButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox customStatus;
        private System.Windows.Forms.Label statusStatus;
        private System.Windows.Forms.CheckBox showTipsCheck;
        private System.Windows.Forms.Button setTemplateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox countCheck;
        private System.Windows.Forms.CheckBox playlistUse;
        private System.Windows.Forms.TextBox templateForStatus;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button setStatusButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button oldStatusButton;
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
        private System.Windows.Forms.CheckBox genreCheck;
    }
}

