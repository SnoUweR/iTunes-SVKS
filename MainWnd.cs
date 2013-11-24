using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;

using ApiCore;
using ApiCore.Friends;
using ApiCore.Status;
using ApiCore.Wall;
using ApiCore.Audio;

using Newtonsoft.Json.Linq;
using iTunesLib;

/*
 * iTunes SVKS (iTunes. Song to VK Status)
 * Copyright (c) 2011-2013 Vladislav «SnoUweR» Kovalev at http://me.snouwer.ru

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
        #region Переменные

        private const string AppTitle = "iTunes SVKS";
        private SessionInfo _sessionInfo;
        private ApiManager _manager;

        private string _newstatus;
        private string _oldstatus;
        private string _currentstatus;
        private string _imageDirectory;
        private string _currentSong = "";
        private string _oldSong = "";
        private string _releaseNotes = "";

        private bool _isLoggedIn;
        private bool _coverArt;

        private StatusFactory _statusFactory;
        private WallFactory _wallFactory;
        private FriendsFactory _friendsFactory;
        private AudioFactory _audioFactory;

        private List<Friend> _friendsList;
        private List<AudioEntry> _audioList; 
        private int _friendId;

        private iTunesApp _iTunesAppCurrent;

        #endregion

        // Инициализация главного окна
        public MainWnd()
        {
            InitializeComponent();

            if (Properties.Settings.Default.statusTemplate != null)
            {
                customText.Text = Properties.Settings.Default.statusTemplate;
            }

        }

        #region Эвенты контролов

        private void MainWnd_Shown(object sender, EventArgs e)
        {
            Text = AppTitle + ": Не авторизован!";
            CheckUpdates();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                Properties.Settings.Default.statusTemplate = customText.Text;
                Properties.Settings.Default.Save();

                string currentStatus = _statusFactory.Get(_sessionInfo.UserId); //Берем текущий статус пользователя

                // Проверяем, равен ли текущий статус первоначальному
                if (currentStatus == _oldstatus)
                {
                    // Если да, то завершаем программу
                }

                // Если нет, то спрашиваем, вернуть ли первоначальный статус
                else
                {
                    _statusFactory.Set("");

                    DialogResult result = MessageBox.Show("Вернуть ваш первоначальный статус?", "Закрытие", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (result)
                    {
                        // Возвращаем и завершаем программу
                        case DialogResult.Yes:
                            _statusFactory.Set(_oldstatus);
                            break;
                        // Не завершаем программу
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        // Просто завершаем программу
                        case DialogResult.No:
                            break;
                    }
                }

            }
            catch (Exception)
            {

            }

        }

        private void reauthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sm = new SessionManager(2369574, "status,wall,photos,audio");
            _sessionInfo = sm.ReLogin();
            _isLoggedIn = false;
            Reauth();
        }

        // Выполняется при нажатии кнопки «Обновить»
        private void setStatusButton_Click(object sender, EventArgs e)
        {
            SetStatus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrentSong();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); // Показываем главное окно
            notifyIcon1.Visible = false; // Скрываем иконку в трее
            WindowState = FormWindowState.Normal; // Разворачиваем окно

        }

        private void checkiTunesTimer_Tick(object sender, EventArgs e)
        {
            CheckiTunes();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        private void reauthContextMenu_Click(object sender, EventArgs e)
        {
            Reauth();
        }

        private void exitContextMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void autoUpdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setStatusButton.Enabled = autoUpdCheckBox.Checked != true;
        }

        private void updateStripMenu_Click(object sender, EventArgs e)
        {
            CheckiTunes();
            SetStatus();
        }

        private void albumArtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _coverArt = albumArtCheckBox.Checked;
        }

        private void shareButton_Click(object sender, EventArgs e)
        {
            Share(_friendId);
        }

        // Выполняется при нажатии «Поместить себе на страницу»
        private void wallSongButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = _sessionInfo.UserId;
                Share(id);

            }
            catch (ApiRequestErrorException apiRequestError)
            {
                AddLineToConsole(apiRequestError.Message + ". Сайт вернул неверный ответ. Попробуйте изменить текст для публикации.");
            }
            catch (Exception ex)
            {
                AddLineToConsole(ex.Message);
            }
        }

        private void customText_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = ReplaceKeyWords(customText.Text);
        }

        // Щелчок в трее
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void comboBFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            Friend a = comboBFriends.SelectedItem as Friend;
            _friendId = a.Id;
            shareButton.Enabled = Properties.Settings.Default.messageToPost != null;
        }

        private void changeShareTextBtn_Click(object sender, EventArgs e)
        {
            Message m = new Message();
            m.ShowDialog();
        }

        private void checkUpdatesToolStripMenu_Click(object sender, EventArgs e)
        {
            CheckUpdates();
        }

        private void lastFMBtn_Click(object sender, EventArgs e)
        {
            if (lastFMBtn.Text == "Загрузить с LastFM")
            {
                Thread t = new Thread(delegate() { GetCoverArtLastFM(_iTunesAppCurrent.CurrentTrack.Artist, _iTunesAppCurrent.CurrentTrack.Name); });
                t.Start();
            }

            else if (lastFMBtn.Text == "Сохранить в iTunes")
            {
                SaveAlbumArt();
            }
        }

        private void realSongCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customText.Enabled = realSongChckBox.Checked != true;
            textBox2.Enabled = realSongChckBox.Checked != true;
            setStatusButton.Enabled = realSongChckBox.Checked != true;
            autoUpdCheckBox.Checked = realSongChckBox.Checked;
            autoUpdCheckBox.Enabled = realSongChckBox.Checked != true;
        }

        #endregion

        #region Функции программы

        private void Reauth()
        {
            try
            {
                if (!_isLoggedIn)
                {
                    // Соединяемся с VK API, передаем ему ключ приложения и необходимые нам разрешения
                    var sm = new SessionManager(2369574, "status,wall,photos,audio");
                    _sessionInfo = sm.GetOAuthSession();
                    if (_sessionInfo != null)
                    {
                        _isLoggedIn = true;
                    }
                    Reauth();
                }

                // Выполняется если пользователь залогинен
                else
                {
                    _manager = new ApiManager(_sessionInfo) { Timeout = 10000 };
                    Text = AppTitle + ": Авторизован!";

                    CheckiTunes();
                    GetStatus();
                    GetFriends();
                }
            }
            catch (Exception e)
            {
                AddLineToConsole(e.Message);
            }
        }

        public void CheckiTunes()
        {
            const string iTunesProcessName = "iTunes";
            Process[] iTunesProcess = Process.GetProcessesByName(iTunesProcessName); // Ищем процесс с iTunes

            // Выполняется, если iTunes.exe не запущен
            if (iTunesProcess.Length == 0)
            {
                iTunesStatus.Text = "iTunes не запущен.";
                iTunesStatus.ForeColor = Color.Red;

                // Отключаем определенные кнопки и поля, которые не работают, при выключенном iTunes
                setStatusButton.Enabled = false;
                autoUpdCheckBox.Checked = false;
                autoUpdCheckBox.Enabled = false;
                timer1.Enabled = false;
                shareButton.Enabled = false;
                wallSongButton.Enabled = false;
                comboBFriends.Enabled = false;
                checkiTunesTimer.Enabled = true;
            }

            // Выполняется если iTunes.exe запущен    
            else
            {

                // Пытаемся получить текущую композицию
                try
                {
                    checkiTunesTimer.Enabled = false; // Отключаем таймер, которые каждые n-секунд проверяет запущенность iTunes
                    iTunesStatus.Text = "iTunes запущен."; // Меняем iTunes-статус
                    iTunesStatus.ForeColor = Color.Green; // Меняем цвет у iTunes-статус

                    // Включаем определенные кнопки и поля, которые нам понадобятся при работе с программой
                    setStatusButton.Enabled = true;
                    autoUpdCheckBox.Enabled = true;
                    timer1.Enabled = true; // Включаем таймер, который каждые n-секунд выполняет функцию GetCurrentSong()
                    wallSongButton.Enabled = true;
                    comboBFriends.Enabled = true;
                    customText.Enabled = true;

                    // Инициализируем переменные и записываем в них данные о композиции

                    GetCurrentSong();
                }

                // Если не удалось получить композицию (Например, если проигрывание остановлено)
                catch (Exception)
                {
                    iTunesStatus.ForeColor = Color.Red; // Меняем цвет у iTunes-статус
                    iTunesStatus.Text = "Воспроизведите любую песню в iTunes."; // Меняем iTunes-статус

                    // Вновь отключаем определенные кнопки и поля
                    setStatusButton.Enabled = false;
                    autoUpdCheckBox.Checked = false;
                    autoUpdCheckBox.Enabled = false;
                    timer1.Enabled = false;
                    shareButton.Enabled = false;
                    wallSongButton.Enabled = false;
                    comboBFriends.Enabled = false;
                    customText.Enabled = false;
                    checkiTunesTimer.Enabled = true; // Включаем таймер, который каждые n-секунд выполняет checkiTunes()
                }
            }
        }

        private void CheckUpdates()
        {
            var current = Assembly.GetEntryAssembly().GetName().Version;
            Version curVersion = new Version(current.Major, current.Minor);
            Console.WriteLine(curVersion.ToString());

            Uri url = new Uri("http://isvks.snouwer.ru/app/update.xml");

            try
            {

                HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse tokenResponse = (HttpWebResponse)tokenRequest.GetResponse();
                string tokenResult = new StreamReader(tokenResponse.GetResponseStream(), Encoding.UTF8).ReadToEnd();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(tokenResult);
                var elem = doc.DocumentElement;
                XmlUtils.UseNode(elem);
                Version actualVersion = new Version(XmlUtils.String("Version"));
                _releaseNotes = XmlUtils.String("ReleaseNotes");
                string downloadUrl = XmlUtils.String("URL");




                AddLineToConsole("Текущая версия: " + curVersion);
                AddLineToConsole("Версия на сервере: " + actualVersion);
                switch (curVersion.CompareTo(actualVersion))
                {
                    case 0:
                        AddLineToConsole("Обновление не требуется");
                        break;
                    case -1:
                        AddLineToConsole("Доступна новая версия");
                        NewVersionAvailable newVersion = new NewVersionAvailable(_releaseNotes, actualVersion.ToString(), downloadUrl);
                        newVersion.ShowDialog();
                        break;
                }

            }
            catch (Exception e)
            {
                AddLineToConsole(e.Message);
            }
        }

        private string SendCoverReqestLastFM(string method, string artist, string track)
        {
            StringBuilder buff = new StringBuilder();
            buff.Append("http://ws.audioscrobbler.com/2.0/");
            buff.Append("?method=");
            buff.Append(method);
            buff.Append("&api_key=");
            buff.Append("e8203c02891d90390e16205aa05c1d6d");
            buff.Append("&artist=");
            buff.Append(artist);
            buff.Append("&track=");
            buff.Append(track);
            buff.Append("&format=");
            buff.Append("json");

            Uri url = new Uri(buff.ToString());


                HttpWebRequest tokenRequest = (HttpWebRequest) WebRequest.Create(url);
                HttpWebResponse tokenResponse = (HttpWebResponse) tokenRequest.GetResponse();

                string imageUrl = String.Empty;
                string tokenResult = new StreamReader(tokenResponse.GetResponseStream(), Encoding.UTF8).ReadToEnd();

                var o = JToken.Parse(tokenResult);

                
                imageUrl = (string) o.SelectToken("track.album.image[3].#text");
                if (string.IsNullOrEmpty(imageUrl))
                {
                    imageUrl = (string)o.SelectToken("artist.image[4].#text");
                }

                return imageUrl;

        }

        private void GetCoverArtLastFM(string artist, string track)
        {
            lastFMBtn.BeginInvoke(new LastFMBtnTextDelegate(LastFMBtnTextMethod), "Идет поиск");
            lastFMBtn.BeginInvoke(new LastFMBtnEnabledDelegate(LastFMBtnEnabledMethod), false);

            try
            {
                string imageUrl = SendCoverReqestLastFM("track.getInfo", artist, track);

                if (string.IsNullOrEmpty(imageUrl))
                {
                    imageUrl = SendCoverReqestLastFM("artist.getInfo", artist, track);
                }

                if (string.IsNullOrEmpty(imageUrl))
                {
                    lastFMBtn.BeginInvoke(new LastFMBtnTextDelegate(LastFMBtnTextMethod), "Обложка не найдена");
                }
                else
                {
                    //lastFMBtn.BeginInvoke(new LastFMBtnTextDelegate(LastFMBtnTextMethod), "Найдена");
                    //lastFMBtn.BeginInvoke(new LastFMBtnEnabledDelegate(LastFMBtnEnabledMethod), false);
                    albumArtBox.ImageLocation = imageUrl;
                    lastFMBtn.BeginInvoke(new LastFMBtnTextDelegate(LastFMBtnTextMethod), "Сохранить в iTunes");
                    lastFMBtn.BeginInvoke(new LastFMBtnEnabledDelegate(LastFMBtnEnabledMethod), true);
  
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(imageUrl, String.Concat(Environment.CurrentDirectory, @"\ArtistCover.jpg"));
                    _imageDirectory = String.Concat(Environment.CurrentDirectory, @"\ArtistCover.jpg");
                }
            }
            catch (Exception e)
            {

                lastFMBtn.BeginInvoke(new LastFMBtnTextDelegate(LastFMBtnTextMethod), "Загрузить с LastFM");
                lastFMBtn.BeginInvoke(new LastFMBtnEnabledDelegate(LastFMBtnEnabledMethod), true);
            }
        }

        private void ShowAboutBox()
        {
            About a = new About();
            a.ShowDialog();
        }

        private void AddLineToConsole(string message)
        {
            DateTime d = DateTime.Now;
            actionsStatus.AppendText("[" + d.ToString("HH:mm:ss") + "] " + message + Environment.NewLine);
            actionsStatus.ScrollToCaret();
        }

        private string ReplaceKeyWords(string originalString)
        {
            if (_isLoggedIn)
            {
                try
                {
                    iTunesApp app = new iTunesAppClass();
                    string artist = app.CurrentTrack.Artist;
                    string name = app.CurrentTrack.Name;
                    string playlist = app.CurrentTrack.Playlist.Name;
                    string album = app.CurrentTrack.Album;
                    string genre = app.CurrentTrack.Genre;
                    int count = app.CurrentTrack.PlayedCount;

                    originalString = originalString.Replace("{name}", name);
                    originalString = originalString.Replace("{artist}", artist);
                    originalString = originalString.Replace("{playlist}", playlist);
                    originalString = originalString.Replace("{count}", count.ToString());
                    originalString = originalString.Replace("{album}", album);
                    originalString = originalString.Replace("{genre}", genre);
                }
                catch (Exception e)
                {
                    AddLineToConsole(e.Message);
                }
            }

            return originalString;
        }

        private void FindSong(string name)
        {
            _audioFactory = new AudioFactory(_manager);
            _audioList = _audioFactory.Search(name, AudioSortOrder.ByPopularity, false, 1, 0, true);
        }

        #endregion

        #region Функции VK API

        private void GetStatus()
        {
            try
            {
                _statusFactory = new StatusFactory(_manager);
                _oldstatus = _statusFactory.Get(_sessionInfo.UserId);
            }

            catch (Exception e)
            {
                AddLineToConsole(e.Message);
            }
        }

        private void SetStatus()
        {
            try
            {

                _newstatus = textBox2.Text; // Новый статус получаем из textBox2 (Самое первое, верхнее поле)
                _newstatus = _newstatus.Replace("&", " and ");
                _newstatus = _newstatus.Replace("+", ", ");
                if (_newstatus != _currentstatus)
                {
                    _statusFactory.Set(_newstatus); // Устанавливаем новый статус
                    _currentstatus = _newstatus;
                }
            }

            catch (Exception e)
            {
                AddLineToConsole(e.Message);
            }

        }

        private void SetBroadcast()
        {
            try
            {
                _audioFactory = new AudioFactory(_manager);
                _audioFactory.SetBroadcast(_audioList[0].OwnerId + "_" + _audioList[0].Id);
                _oldSong = _currentSong;
            }

            catch (Exception e)
            {
                AddLineToConsole(e.Message);
            }
        }

        private void GetFriends()
        {

            //comboBFriends.Items.Clear();
            _friendsFactory = new FriendsFactory(_manager);
            string[] fields = { "uid", "first_name", "last_name" };
            _friendsList = _friendsFactory.Get(_sessionInfo.UserId, "nom", null, 0, null, fields);

            foreach (Friend a in _friendsList)
            {
                comboBFriends.Items.Add(a);
            }
        }

        /// <summary>
        /// Опубликовываем запись на стене с картинкой альбома
        /// </summary>
        /// <param name="id">ID пользователя, где будем размещать запись</param>
        private void Share(int id)
        {

            string shareText = ReplaceKeyWords(Properties.Settings.Default.messageToPost);

            Console.WriteLine(shareText);

            _wallFactory = new WallFactory(_manager); // Инициализируем «фабрику» стены
            try
            {
                if (_coverArt)
                {
                    _wallFactory = new WallFactory(_manager);
                    _wallFactory.Manager.Method("photos.getWallUploadServer");
                    _wallFactory.Manager.Params("uid", id);
                    XmlNode result = _wallFactory.Manager.Execute().GetResponseXml().LastChild;
                    XmlUtils.UseNode(result);
                    string uploadUrl = XmlUtils.String("upload_url");

                    HttpUploaderFactory uf = new HttpUploaderFactory();
                    NameValueCollection files = new NameValueCollection();
                    files.Add("photo", _imageDirectory);
                    string resp = uf.Upload(uploadUrl, null, files);
                    Console.WriteLine(resp);
                    var apiResponse = JObject.Parse(resp);
                    var server = (int)apiResponse["server"];
                    var photo = (string)apiResponse["photo"];
                    var hash = (string)apiResponse["hash"];

                    _wallFactory.Manager.Method("photos.saveWallPhoto");
                    _wallFactory.Manager.Params("server", server);
                    _wallFactory.Manager.Params("photo", photo);
                    _wallFactory.Manager.Params("hash", hash);
                    XmlNode result2 = _wallFactory.Manager.Execute().GetResponseXml().FirstChild.FirstChild;
                    XmlUtils.UseNode(result2);
                    string photoId = XmlUtils.String("id");
                    Console.WriteLine(photoId);


                    _wallFactory.Manager.Method("wall.post");
                    _wallFactory.Manager.Params("owner_id", id);
                    _wallFactory.Manager.Params("message", shareText);
                    _wallFactory.Manager.Params("attachments", photoId);
                    _wallFactory.Manager.Params("uid", id);
                    _wallFactory.Manager.Execute();

                }
                else
                {
                    _wallFactory = new WallFactory(_manager); // Инициализируем «фабрику» стены
                    _wallFactory.Manager.Method("wall.post");
                    _wallFactory.Manager.Params("owner_id", id);
                    _wallFactory.Manager.Params("message", shareText);
                    Console.WriteLine(_wallFactory.Manager.Execute().ToString());
                }
                AddLineToConsole("Опубликовано."); // Уведомляем пользователя об успешности
            }

            catch (ApiRequestErrorException apiRequestError)
            {
                AddLineToConsole(apiRequestError.Message + ". Сайт вернул неверный ответ. Попробуйте изменить текст для публикации.");
            }
            catch (Exception e)
            {
                AddLineToConsole(e.Message);
            }
        }

        #endregion

        #region Функции iTunes COM

        public void GetCurrentSong()
        {
            iTunesApp app = new iTunesAppClass();

            try
            {
                string artist = app.CurrentTrack.Artist;
                string name = app.CurrentTrack.Name;

                string currentSongLite = String.Concat(artist, " - ", name);

                if (_currentSong != currentSongLite)
                {
                    lastFMBtn.Enabled = true;
                    lastFMBtn.Text = "Загрузить с LastFM";
                    _currentSong = currentSongLite;
                    GetAlbumArt();
                }

                Fixes.SetNotifyIconText(notifyIcon1, currentSongLite);

                // Если длина статуса превышает максимально допустимую, по меркам VK.com, то просим пользователя отключить некоторые опции
                if (textBox2.Text.Length > 131)
                {
                    AddLineToConsole("Длина статуса превышает рекомендуемую. Макc. 130 знаков.");
                    notifyIcon1.ShowBalloonTip(5, "Внимание!", "Статус превысил рекомендуемую длину.", ToolTipIcon.Warning);
                }

                textBox2.Text = ReplaceKeyWords(customText.Text);
                songNameLabel.Text = name;
                songArtistLabel.Text = artist;

                if (autoUpdCheckBox.Checked && !realSongChckBox.Checked)
                {
                    SetStatus();
                }
                else if (realSongChckBox.Checked)
                {
                    if (currentSongLite != _oldSong)
                    {
                        FindSong(currentSongLite);
                        if (_audioList.Count != 0)
                        {
                            SetBroadcast();
                        }
                        else
                        {
                            SetStatus();
                        }
                        _oldSong = currentSongLite;
                    }
                }
            }
            catch (Exception e)
            {
                AddLineToConsole(e.Message + ". Попробуйте перезапустить программу.");
                //checkiTunes(); // На всякий случай проверяем, запущен ли iTunes
            }

            _iTunesAppCurrent = app;
        }

        private void GetAlbumArt()
        {
            try
            {
                iTunesApp app = new iTunesAppClass();
                IITArtworkCollection art1 = app.CurrentTrack.Artwork;
                IITArtwork art2 = art1[1];
                art2.SaveArtworkToFile(String.Concat(Environment.CurrentDirectory, @"\Cover.jpg"));
                Stream r = File.Open(String.Concat(Environment.CurrentDirectory, @"\Cover.jpg"), FileMode.Open);
                Image temp = Image.FromStream(r);
                r.Close();
                albumArtBox.Image = temp;
                _imageDirectory = String.Concat(Environment.CurrentDirectory, @"\Cover.jpg");
            }
            catch (Exception)
            {
                albumArtBox.Image = Properties.Resources.art;
                _imageDirectory = String.Concat(Environment.CurrentDirectory, @"\No_Cover.jpg");
            }
        }

        private void SaveAlbumArt()
        {
            try
            {
                iTunesApp app = new iTunesAppClass();
                var curTrack = app.CurrentTrack;
                if (curTrack.Artwork[1] != null)
                {
                    curTrack.Artwork[1].SetArtworkFromFile(String.Concat(Environment.CurrentDirectory,
                        @"\ArtistCover.jpg"));
                }
                else
                {
                    curTrack.AddArtworkFromFile(String.Concat(Environment.CurrentDirectory,
                        @"\ArtistCover.jpg"));
                }
                lastFMBtn.Text = "Сохранено";
                lastFMBtn.Enabled = false;

            }
            catch (Exception ex)
            {
                AddLineToConsole(ex.Message);
            }
        }

        #endregion

        #region Делегаты и методы

        private delegate void LastFMBtnTextDelegate(string text);

        private void LastFMBtnTextMethod(string text)
        {
            lastFMBtn.Text = text;
        }


        private delegate void LastFMBtnEnabledDelegate(bool isEnabled);

        private void LastFMBtnEnabledMethod(bool isEnabled)
        {
            lastFMBtn.Enabled = isEnabled;
        }


        #endregion

    }
}
