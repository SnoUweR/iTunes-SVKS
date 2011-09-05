using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using ApiCore;
using ApiCore.Status;
using ApiCore.Wall;
using ApiCore.Friends;
using iTunesLib;

/*
 * iTunes SVKS (iTunes. Song to VK Status)
 * Copyright (c) 2011 Vladislav «SnoUweR» Kovalev at http://snouwer.ru

 * Данная лицензия разрешает лицам, получившим копию данного программного обеспечения и сопутствующей документации (в дальнейшем именуемыми "Программное Обеспечение"), безвозмездно использовать Программное Обеспечение без ограничений,
 * включая неограниченное право на использование, изменение, добавление, публикацию, распространение, также как и лицам, которым предоставляется данное Программное Обеспечение, при соблюдении следующих условий:
 * 
 * Вышеупомянутый копирайт и данные условия должны быть включены во все копии или значимые части данного Программного Обеспечения.
 * 
 * ДАННОЕ ПРОГРАММНОЕ ОБЕСПЕЧЕНИЕ ПРЕДОСТАВЛЯЕТСЯ «КАК ЕСТЬ», БЕЗ КАКИХ-ЛИБО ГАРАНТИЙ, ЯВНО ВЫРАЖЕННЫХ ИЛИ ПОДРАЗУМЕВАЕМЫХ, ВКЛЮЧАЯ, НО НЕ ОГРАНИЧИВАЯСЬ ГАРАНТИЯМИ ТОВАРНОЙ ПРИГОДНОСТИ, СООТВЕТСТВИЯ ПО ЕГО КОНКРЕТНОМУ НАЗНАЧЕНИЮ И НЕ НАРУШЕНИЯ ПРАВ.
 * НИ В КАКОМ СЛУЧАЕ АВТОРЫ ИЛИ ПРАВООБЛАДАТЕЛИ НЕ НЕСУТ ОТВЕТСТВЕННОСТИ ПО ИСКАМ О ВОЗМЕЩЕНИИ УЩЕРБА, УБЫТКОВ ИЛИ ДРУГИХ ТРЕБОВАНИЙ ПО ДЕЙСТВУЮЩИМ КОНТРАКТАМ, ДЕЛИКТАМ ИЛИ ИНОМУ, ВОЗНИКШИМ ИЗ, ИМЕЮЩИМ ПРИЧИНОЙ ИЛИ СВЯЗАННЫМ С ПРОГРАММНЫМ ОБЕСПЕЧЕНИЕМ ИЛИ ИСПОЛЬЗОВАНИЕМ ПРОГРАММНОГО ОБЕСПЕЧЕНИЯ ИЛИ ИНЫМИ ДЕЙСТВИЯМИ С ПРОГРАММНЫМ ОБЕСПЕЧЕНИЕМ.
 */


namespace iTunesSVKS
{
    public partial class MainWnd : Form
    {
        private const string AppTitle = "iTunes SVKS";

        private SessionInfo _sessionInfo;
        private ApiManager _manager;

        private string _newstatus;
        private string _oldstatus;
        private string _templatestatus = "[iTunes] ";

        private bool _isLoggedIn = false;
        private bool _playlistInStatus = false;
        private bool _countInStatus = false;
        private bool _showTips = true;
        private bool _custom = false;

        private StatusFactory _statusFactory;
        private WallFactory _wallFactory;

        public MainWnd()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                string currentStatus = _statusFactory.Get(int.Parse(_sessionInfo.MemberId));
                if (currentStatus == _oldstatus)
                {

                }
                else
                {
                    _statusFactory.Set("");

                    DialogResult result = MessageBox.Show("Вернуть ваш первоначальный статус?", "Закрытие", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            _statusFactory.Set(_oldstatus);
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        case DialogResult.No:
                            break;
                    }
                }

            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }


        private void reauthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reauth();
        }

        private void Reauth()
        {
            if (!_isLoggedIn)
            {
                SessionManager sm = new SessionManager(2369574, Convert.ToInt32(ApiPerms.UserStatus | ApiPerms.WallPublisher));
                _sessionInfo = sm.GetSession();
                if (_sessionInfo != null)
                {
                    _isLoggedIn = true;
                }
            }

            if (_isLoggedIn)
            {
                _manager = new ApiManager(_sessionInfo) {Timeout = 10000};
                Text = AppTitle + ": Авторизован!";
                templateForStatus.Text = _templatestatus;

                checkiTunes();
                GetStatus();
            }
            
        }

        private void MainWnd_Shown(object sender, EventArgs e)
        {
            Text = AppTitle + ": Не авторизован!";
            Reauth();
        }


        private void MainWnd_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        public void checkiTunes()
        {
            const string iTunesProcessName = "iTunes";
            Process[] iTunesProcess = Process.GetProcessesByName(iTunesProcessName);

            if (iTunesProcess.Length == 0)
            {
                Console.WriteLine("{0} не запущен", iTunesProcessName);
                iTunesStatus.Text = "iTunes не запущен.";
                iTunesStatus.ForeColor = Color.Red;
                setStatusButton.Enabled = false;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                timer1.Enabled = false;
                playlistUse.Enabled = false;
                countCheck.Enabled = false;
                shareButton.Enabled = false;
                wallSongButton.Enabled = false;
                idInput.Enabled = false;
                checkiTunesTimer.Enabled = true;
                customStatus.Enabled = false;
                customSet.Enabled = false;
            } 
            else
            {

                iTunesApp app = new iTunesAppClass();

                try
                {
                    checkiTunesTimer.Enabled = false;
                    iTunesStatus.Text = "iTunes запущен.";
                    iTunesStatus.ForeColor = Color.Green;

                    setStatusButton.Enabled = true;
                    checkBox1.Enabled = true;
                    timer1.Enabled = true;
                    playlistUse.Enabled = true;
                    countCheck.Enabled = true;
                    wallSongButton.Enabled = true;
                    idInput.Enabled = true;
                    customStatus.Enabled = true;

                    string artist = app.CurrentTrack.Artist;
                    string name = app.CurrentTrack.Name;
                    GetCurrentSong();
                }
                catch (Exception)
                {
                    iTunesStatus.ForeColor = Color.Red;
                    iTunesStatus.Text = "Воспроизведите любую песню в iTunes.";
                    setStatusButton.Enabled = false;
                    checkBox1.Checked = false;
                    checkBox1.Enabled = false;
                    timer1.Enabled = false;
                    playlistUse.Enabled = false;
                    countCheck.Enabled = false;
                    shareButton.Enabled = false;
                    wallSongButton.Enabled = false;
                    idInput.Enabled = false;
                    checkiTunesTimer.Enabled = true;
                    customSet.Enabled = false;
                    customStatus.Enabled = false;
                }
            }
        }

        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void setStatusButton_Click(object sender, EventArgs e)
        {
            SetStatus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrentSong();
        }

        private void GetStatus()
        {
            try
            {
                _statusFactory = new StatusFactory(_manager);
                textBox1.Text = _statusFactory.Get(int.Parse(_sessionInfo.MemberId));
                _oldstatus = textBox1.Text;
            }
            catch (Exception)
            {
                statusStatus.Text = "Нет соединения с ВКонтакте. Проверьте работоспособность интернета.";
            }
        }

        private void SetStatus()
        {
            try
            {
                if (_custom)
                {
                    _newstatus = textBox2.Text;
                    _newstatus = _newstatus.Replace("&", " and ");
                    _statusFactory.Set(_newstatus);
                }
                else if (_custom == false)
                {
                    _newstatus = String.Concat(_templatestatus, textBox2.Text);
                    _newstatus = _newstatus.Replace("&", " and ");
                    _statusFactory.Set(_newstatus);
                }
            }
            catch (Exception)
            {
                statusStatus.Text = "Нет соединения с ВКонтакте. Проверьте работоспособность интернета.";
            }

        }

        private void SetOriginalStatus()
        {
            try
            {
                _statusFactory.Set(_oldstatus);
            }
            catch (Exception)
            {
                statusStatus.Text = "Нет соединения с ВКонтакте. Проверьте работоспособность интернета.";
            }
        }

        public void GetCurrentSong()
        {
            iTunesApp app = new iTunesAppClass();
            try
            {
                string artist = app.CurrentTrack.Artist;
                string name = app.CurrentTrack.Name;
                string playlist = app.CurrentTrack.Playlist.Name;
                int count = app.CurrentTrack.PlayedCount;
                string currentSong = String.Concat(artist, " - ", name);
                string currentSongLite = String.Concat(artist, " - ", name);
                string currentSongTemp = String.Concat(artist, " - ", name);
                if (_playlistInStatus)
                {
                    currentSong = String.Concat(currentSongTemp, ". Плейлист: ", "'", playlist, "'");
                    currentSongTemp = currentSong;
                }

                if (_countInStatus)
                {
                    currentSong = String.Concat(currentSongTemp, ". Прослушиваний: ", count);
                }

                if (_countInStatus == false && _playlistInStatus == false)
                {
                    currentSong = currentSongLite;
                }

                if (_custom == false)
                {
                    textBox2.Text = currentSong;
                }

                if (currentSongLite.Length > 64)
                {
                    notifyIcon1.Text = name;
                }
                else
                {
                    notifyIcon1.Text = currentSongLite;
                }

                if (currentSong.Length > 131)
                {
                    statusStatus.Text = "Длина статуса превышает рекомендуемую. Его часть, возможно, будет урезана. Максимум - 130 знаков. Отключите ненужные опции.";

                    if (_showTips)
                    {
                        notifyIcon1.ShowBalloonTip(5, "Внимание!", "Статус превысил рекомендуемую длину.", ToolTipIcon.Warning);
                    }
                }
                else
                {
                    statusStatus.Text = "Всё работает корректно.";
                }

                if (checkBox1.Checked)
                {
                    SetStatus();
                }
            }
            catch (System.Exception)
            {
                statusStatus.Text = "Неопознанная ошибка. Попробуйте перезапустить программу.";
                checkiTunes();
            }
        }

        private void oldStatusButton_Click(object sender, EventArgs e)
        {
            SetOriginalStatus();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
            
        }

        private void setTemplateButton_Click(object sender, EventArgs e)
        {
            _templatestatus = templateForStatus.Text;
        }

        private void checkiTunesTimer_Tick(object sender, EventArgs e)
        {
            checkiTunes();
        }

        private void playlistUse_CheckedChanged(object sender, EventArgs e)
        {
            _playlistInStatus = _playlistInStatus == false;

            GetCurrentSong();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            setStatusButton.Enabled = checkBox1.Checked != true;
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        private void ShowAboutBox()
        {
            About a = new About();
            a.ShowDialog();
        }

        private void countCheck_CheckedChanged(object sender, EventArgs e)
        {
            _countInStatus = _countInStatus == false;

            GetCurrentSong();
        }

        private void reauthContextMenu_Click(object sender, EventArgs e)
        {
            Reauth();
        }

        private void exitContextMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateStripMenu_Click(object sender, EventArgs e)
        {
            checkiTunes();
            SetStatus();
        }

        private void showTipsCheck_CheckedChanged(object sender, EventArgs e)
        {
            _showTips = !_showTips;
        }

        private void shareButton_Click(object sender, EventArgs e)
        {
            iTunesApp app = new iTunesAppClass();

            string artist = app.CurrentTrack.Artist;
            string name = app.CurrentTrack.Name;
            int count = app.CurrentTrack.PlayedCount;
            int id;

            string currentSong = String.Concat(artist, " - ", name);
            string shareText = String.Concat("Привет! :D. Рекомендую послушать трек '", currentSong, "'. Я прослушал его уже где-то ", count, " раз. Вообще супер!");

            _wallFactory = new WallFactory(_manager);
            try
            {
                id = int.Parse(idInput.Text);
                _wallFactory.Post(id, shareText);
                actionsStatus.Text = "Опубликовано.";
                actionsStatusTimer.Enabled = true;
            }
            catch (Exception)
            {
                actionsStatus.Text = "Введен некорректный ID.";
                actionsStatusTimer.Enabled = true;
            }
        }

        private void wallSongButton_Click(object sender, EventArgs e)
        {
            iTunesApp app = new iTunesAppClass();

            string artist = app.CurrentTrack.Artist;
            string name = app.CurrentTrack.Name;
            int count = app.CurrentTrack.PlayedCount;

            string currentSong = String.Concat(artist, " - ", name);
            string shareText = String.Concat("Рекомендую вам послушать трек '", currentSong, "'. Я прослушал его уже где-то ", count, " раз. Мне нравится! :D");

            try
            {
                _wallFactory = new WallFactory(_manager);
                _wallFactory.Post(int.Parse(_sessionInfo.MemberId), shareText);
                actionsStatus.Text = "Опубликовано.";
                actionsStatusTimer.Enabled = true;
            }
            catch (Exception)
            {
                statusStatus.Text = "Нет соединения с ВКонтакте. Проверьте работоспособность интернета.";
            }
        }

        private void actionsStatusTimer_Tick(object sender, EventArgs e)
        {
            actionsStatus.Text = "Выберите необходимое действие.";
            actionsStatusTimer.Enabled = false;
        }

        private void idInput_TextChanged(object sender, EventArgs e)
        {
            shareButton.Enabled = idInput.TextLength > 0;
        }

        private void customSet_Click(object sender, EventArgs e)
        {
            try
            {
                iTunesApp app = new iTunesAppClass();
                string artist = app.CurrentTrack.Artist;
                string name = app.CurrentTrack.Name;
                string playlist = app.CurrentTrack.Playlist.Name;
                string album = app.CurrentTrack.Album;
                string prefix = _templatestatus;
                int count = app.CurrentTrack.PlayedCount;

                string result1 = customText.Text.Replace("{name}", name);
                string result2 = result1.Replace("{artist}", artist);
                string result3 = result2.Replace("{playlist}", playlist);
                string result4 = result3.Replace("{count}", count.ToString());
                string result5 = result4.Replace("{album}", album);
                string result6 = result5.Replace("{prefix}", prefix);
                textBox2.Text = result6;
            }
            catch (Exception)
            {
                checkiTunes();
            }
        }

        private void customStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (_custom == false)
            {
                _custom = true;
                playlistUse.Checked = false;
                playlistUse.Enabled = false;
                countCheck.Checked = false;
                countCheck.Enabled = false;
                groupBox5.Enabled = true;
                textBox3.Enabled = true;
                customText.Enabled = true;
            }
            else
            {
                _custom = false;
                playlistUse.Enabled = true;
                countCheck.Enabled = true;
                groupBox5.Enabled = false;
                textBox3.Enabled = false;
                customText.Enabled = false;
            }
        }

        private void customText_TextChanged(object sender, EventArgs e)
        {
            customSet.Enabled = customText.TextLength > 0;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

    }
}
