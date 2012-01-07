using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
//Подключаем VK API for .NET by xternalx
using ApiCore;
using ApiCore.Status;
using ApiCore.Wall;
using iTunesLib; //Подключаем COM-библиотеку для работы с iTunes
using Microsoft.Win32; //Подключаем библиотеку для работы с реестром

/*
 * iTunes SVKS (iTunes. Song to VK Status)
 * Copyright (c) 2012 Vladislav «SnoUweR» Kovalev at http://snouwer.ru

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
        // Инициализация всех переменных
        private const string AppTitle = "iTunes SVKS";

        private SessionInfo _sessionInfo;
        private ApiManager _manager;

        private string _newstatus;
        private string _oldstatus;
        private string _templatestatus = "[iTunes] ";
        private string _currentstatus;

        private bool _isLoggedIn;
        private bool _playlistInStatus;
        private bool _genreInStatus;
        private bool _countInStatus;
        private bool _showTips = true;
        private bool _coverArt;
        private bool _custom;

        private StatusFactory _statusFactory;
        private WallFactory _wallFactory;

        
        // Инициализация главного окна
        public MainWnd()
        {
            InitializeComponent();
        }

        // Событие при нажатии на «Выход»
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Событие при закрытии программы
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                string currentStatus = _statusFactory.Get(int.Parse(_sessionInfo.MemberId)); //Берем текущий статус пользователя

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
                e.Cancel = true; // Если произошла какая-то ошибка, то не даем программе завершиться. Надо изменить функцию, ибо это неверно
            }
        }

        // Событие при клике «Перелогиниться»
        private void reauthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reauth();
        }

        // Функция «Перелогиниться»
        private void Reauth()
        {
            // Выполняется если пользователь незалогинен
            if (!_isLoggedIn)
            {
                // Соединяемся с VK API, передаем ему ключ приложения и необходимые нам разрешения
                SessionManager sm = new SessionManager(2369574, Convert.ToInt32(ApiPerms.UserStatus | ApiPerms.WallPublisher));
                _sessionInfo = sm.GetSession();
                if (_sessionInfo != null)
                {
                    _isLoggedIn = true;
                }
                Reauth();
            }

            // Выполняется если пользователь залогинен
            if (_isLoggedIn)
            {
                _manager = new ApiManager(_sessionInfo) {Timeout = 10000};
                Text = AppTitle + ": Авторизован!";
                templateForStatus.Text = _templatestatus;

                checkiTunes();
                GetStatus();
            }
            
        }

        // Выполняется при открытии программы
        private void MainWnd_Shown(object sender, EventArgs e)
        {
            Text = AppTitle + ": Не авторизован!";
            checkInstall();
        }

        // Выполняется при изменении размера окна (В данном случае, при сворачивании)
        private void MainWnd_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide(); // Скрываем главное окно
                notifyIcon1.Visible = true; // Включаем иконку в трее
            }
        }

        // Одна из самых «таких» функций, которая проверяет запущен ли iTunes или нет. Требуется рефакторинг
        public void checkiTunes()
        {
            const string iTunesProcessName = "iTunes"; 
            Process[] iTunesProcess = Process.GetProcessesByName(iTunesProcessName); // Ищем процесс с iTunes

            // Выполняется, если iTunes.exe не запущен
            if (iTunesProcess.Length == 0)
            {
                iTunesStatus.Text = "iTunes не запущен."; // Меняем iTunes-статус (отображается в самом низу программы)
                iTunesStatus.ForeColor = Color.Red; // Меняем цвет iTunes-статуса

                // Отключаем определенные кнопки и поля, которые не работают, при выключенном iTunes
                setStatusButton.Enabled = false;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                timer1.Enabled = false;
                playlistUse.Enabled = false;
                countCheck.Enabled = false;
                shareButton.Enabled = false;
                wallSongButton.Enabled = false;
                idInput.Enabled = false;
                checkiTunesTimer.Enabled = true; // Включаем таймер, который каждые n-секунд выполняет функцию checkiTunes()
                customStatus.Enabled = false;
                customSet.Enabled = false;
            } 

            // Выполняется если iTunes.exe запущен    
            else
            {

                iTunesApp app = new iTunesAppClass(); // Регистрируем наш iTunes, как класс

                // Пытаемся получить текущую композицию
                try
                {
                    checkiTunesTimer.Enabled = false; // Отключаем таймер, которые каждые n-секунд проверяет запущенность iTunes
                    iTunesStatus.Text = "iTunes запущен."; // Меняем iTunes-статус
                    iTunesStatus.ForeColor = Color.Green; // Меняем цвет у iTunes-статус

                    // Включаем определенные кнопки и поля, которые нам понадобятся при работе с программой
                    setStatusButton.Enabled = true;
                    checkBox1.Enabled = true;
                    timer1.Enabled = true; // Включаем таймер, который каждые n-секунд выполняет функцию GetCurrentSong()
                    playlistUse.Enabled = true;
                    countCheck.Enabled = true;
                    genreCheck.Enabled = true;
                    wallSongButton.Enabled = true;
                    idInput.Enabled = true;
                    customStatus.Enabled = true;

                    // Инициализируем переменные и записываем в них данные о композиции
                    string artist = app.CurrentTrack.Artist;
                    string name = app.CurrentTrack.Name;
                    GetCurrentSong();
                }

                // Если не удалось получить композицию (Например, если проигрывание остановлено)
                catch (Exception)
                {
                    iTunesStatus.ForeColor = Color.Red; // Меняем цвет у iTunes-статус
                    iTunesStatus.Text = "Воспроизведите любую песню в iTunes."; // Меняем iTunes-статус

                    // Вновь отключаем определенные кнопки и поля
                    setStatusButton.Enabled = false;
                    checkBox1.Checked = false;
                    checkBox1.Enabled = false;
                    timer1.Enabled = false;
                    playlistUse.Enabled = false;
                    countCheck.Enabled = false;
                    genreCheck.Enabled = false;
                    shareButton.Enabled = false;
                    wallSongButton.Enabled = false;
                    idInput.Enabled = false;
                    checkiTunesTimer.Enabled = true; // Включаем таймер, который каждые n-секунд выполняет checkiTunes()
                    customSet.Enabled = false;
                    customStatus.Enabled = false;
                }
            }
        }
        
        // Выполняется при закрытии формы
        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Заглушка
        }

        // Выполняется при нажатии кнопки «Установить»
        private void setStatusButton_Click(object sender, EventArgs e)
        {
            SetStatus();
        }

        // Выполняется при каждом тике таймера, который, в свою очередь, получает текущую композицию
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrentSong();
        }

        // Выполняется при получении статуса
        private void GetStatus()
        {
            // Пробуем получить статус
            try
            {
                _statusFactory = new StatusFactory(_manager); // Инициализируем «фабрику» статусов

                // Получаем статус текущего пользователя и вставляем его в поле «Первоначальный статус» (textBox1)
                textBox1.Text = _statusFactory.Get(int.Parse(_sessionInfo.MemberId));

                _oldstatus = textBox1.Text; // Записываем наш статус в переменную
            }

            // Если не получилось, то выдаем ошибку в специальном поле
            catch (Exception)
            {
                statusStatus.Text = "Нет соединения с ВКонтакте. Проверьте работоспособность интернета.";
            }
        }

        // Выполняется при установке статуса 
        private void SetStatus()
        {
            try
            {
                // Если чекбокс «Свой» отмечен, то выполняем следующее..
                if (_custom)
                {
                    _newstatus = textBox2.Text; // Новый статус получаем из textBox2 (Самое первое, верхнее поле)
                    _newstatus = _newstatus.Replace("&", " and "); // Заменяем нечитаемый сервером символ на альтернативную текстовую замену
                    _newstatus = _newstatus.Replace("+", ", ");
                    if (_newstatus != _currentstatus)
                    {
                        _statusFactory.Set(_newstatus); // Устанавливаем новый статус
                        _currentstatus = _newstatus;
                    }
                }

                // Если чекбокс «Свой» неактивен, то выполняем это..
                else if (_custom == false)
                {
                    _newstatus = String.Concat(_templatestatus, textBox2.Text); // Новый статус получаем из смеси префикса и textBox2
                    _newstatus = _newstatus.Replace("+", ", ");
                    _newstatus = _newstatus.Replace("&", " and "); // Заменяем символы
                    if (_newstatus != _currentstatus)
                    {
                        _statusFactory.Set(_newstatus); // Устанавливаем новый статус
                        _currentstatus = _newstatus;
                    }
                }
            }

            // Если не получилось, то выдаем ошибку в специальном поле
            catch (Exception)
            {
                statusStatus.Text = "Нет соединения с ВКонтакте. Проверьте работоспособность интернета.";
            }

        }

        // Выполняется после нажатия на кнопку «Вернуть»
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

        // Выполняется при получении текущей композиции. Еще одна довольно затратная функция, требующая рефакторинга
        public void GetCurrentSong()
        {
            iTunesApp app = new iTunesAppClass(); // Вновь регистрируем iTunes, как класс приложения

            //Пробуем получить композицию
            try
            {
                string artist = app.CurrentTrack.Artist; // Получаем исполнителя
                string name = app.CurrentTrack.Name; // Получаем название
                string playlist = app.CurrentTrack.Playlist.Name; // Получаем плейлист
                int count = app.CurrentTrack.PlayedCount; // Получаем количество прослушиваний
                string genre = app.CurrentTrack.Genre; // Получаем жанр

                // Соединяем исполнителя и название в одну строку (требуется пояснение и рефакторинг!)
                string currentSong = String.Concat(artist, " - ", name); 
                string currentSongLite = String.Concat(artist, " - ", name); // Инициализация Lite-версии композиции, которая будем показываться в трее
                string currentSongTemp = String.Concat(artist, " - ", name);

                // Если чекбокс «Плейлист» активен, то вставляем название плейлиста в статус
                if (_playlistInStatus)
                {
                    currentSong = String.Concat(currentSongTemp, ". Плейлист: ", "'", playlist, "'");
                    currentSongTemp = currentSong;
                }

                // Если чекбокс «Счетчик» активен, то вставляем количество прослушиваний
                if (_countInStatus)
                {
                    currentSong = String.Concat(currentSongTemp, ". Прослушиваний: ", count);
                    currentSongTemp = currentSong;
                }

                if (_genreInStatus)
                {
                    currentSong = String.Concat(currentSongTemp, ". Жанр: ", "'", genre, "'");
                }

                // Если чекбоксы «Счетчик» и «Плейлист» неактивны, то показываем статус, как Исполнитель - Название
                if (_countInStatus == false && _playlistInStatus == false && _genreInStatus == false)
                {
                    currentSong = currentSongLite;
                }

                // Если чекбокс «Свой» неактивен, то самое верхнее, первое поле равно текущему статусу, который получен чуть выше
                if (_custom == false)
                {
                    textBox2.Text = currentSong;
                }

                // Если длина Lite-версии песни больше 64-х символов (максимум в notifyIcon), то показываем просто название композиции
                if (currentSongLite.Length > 64)
                {
                    notifyIcon1.Text = name;
                }
                else
                {
                    notifyIcon1.Text = currentSongLite;
                }

                // Если длина статуса превышает максимально допустимую, по меркам VK.com, то просим пользователя отключить некоторые опции
                if (currentSong.Length > 131)
                {
                    statusStatus.Text = "Длина статуса превышает рекомендуемую. Его часть, возможно, будет урезана. Максимум - 130 знаков. Отключите ненужные опции.";

                    // Если чекбокс «Не показывать уведомления» не активен, то показываем уведомления в трее
                    if (_showTips)
                    {
                        notifyIcon1.ShowBalloonTip(5, "Внимание!", "Статус превысил рекомендуемую длину.", ToolTipIcon.Warning);
                    }
                }
                else
                {
                    statusStatus.Text = "Всё работает корректно.";
                }

                // Если чекбокс «Обновлять» активирован, то обновляем статус, выполняя функцию SetStatus()
                if (checkBox1.Checked)
                {
                    SetStatus();
                }
            }
            catch (System.Exception)
            {
                statusStatus.Text = "Неопознанная ошибка. Попробуйте перезапустить программу."; // Вновь показываем ошибку в специальном поле
                checkiTunes(); // На всякий случай проверяем, запущен ли iTunes
            }
        }

        // Выполняется при нажатии на кнопку «Вернуть»
        private void oldStatusButton_Click(object sender, EventArgs e)
        {
            SetOriginalStatus();
        }

        // Выполняется при двойном клике на иконку в трее
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); // Показываем главное окно
            notifyIcon1.Visible = false; // Скрываем иконку в трее
            WindowState = FormWindowState.Normal; // Разворачиваем окно
            
        }

        // Выполняется при нажатии на кнопку «Установить», которая устанавливает префикс к статусу
        private void setTemplateButton_Click(object sender, EventArgs e)
        {
            _templatestatus = templateForStatus.Text;
        }

        // Выполняется при каждом тике таймера, который выполняет функцию проверки iTunes
        private void checkiTunesTimer_Tick(object sender, EventArgs e)
        {
            checkiTunes();
        }

        // Выполняется при изменении статуса чекбокса «Плейлист»
        private void playlistUse_CheckedChanged(object sender, EventArgs e)
        {
            _playlistInStatus = _playlistInStatus == false;

            GetCurrentSong();
        }

        private void genreCheck_CheckedChanged(object sender, EventArgs e)
        {
            _genreInStatus = _genreInStatus == false;
            GetCurrentSong();
        }

        // Выполняется при изменении статуса чекбокса «Обновлять»
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            setStatusButton.Enabled = checkBox1.Checked != true;
        }

        // Выполняется при попытке вызове окна «О программе»
        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        // Вызываем окно «О программе»
        private void ShowAboutBox()
        {
            About a = new About();
            a.ShowDialog();
        }

        // Выполняется при изменении статуса чекбокса «Счетчик»
        private void countCheck_CheckedChanged(object sender, EventArgs e)
        {
            _countInStatus = _countInStatus == false;

            GetCurrentSong();
        }

        // Выполняется при попытке перелогиниться
        private void reauthContextMenu_Click(object sender, EventArgs e)
        {
            Reauth();
        }

        // Выполняется при попытке закрыть программу
        private void exitContextMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Выполняется при попытке обновить статус
        private void updateStripMenu_Click(object sender, EventArgs e)
        {
            checkiTunes();
            SetStatus();
        }

        // Выполняется при изменении статуса чекбокса «Не показывать уведомления»
        private void showTipsCheck_CheckedChanged(object sender, EventArgs e)
        {
            _showTips = !_showTips;
        }

        private void albumArtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _coverArt = albumArtCheckBox.Checked;
        }

        // Выполняется при нажатии на кнопку «Порекомендовать»
        private void shareButton_Click(object sender, EventArgs e)
        {
            iTunesApp app = new iTunesAppClass(); // И снова регистрируем iTunes, как класс приложения

            // Получаем нужную нам информацию о композиции
            string artist = app.CurrentTrack.Artist;
            string name = app.CurrentTrack.Name;
            int count = app.CurrentTrack.PlayedCount;
            //IITArtworkCollection cc = app.CurrentTrack.Artwork;
            

            int id; // Инициализируем нужную переменную, которая будет содержать ID нужного пользователя

            string currentSong = String.Concat(artist, " - ", name); // Соединяем исполнителя и название в одну строку

            // Соединяем текст, текущую композицию и количество прослушиваний в одну строку
            string shareText = String.Concat("Привет! :D. Рекомендую послушать трек '", currentSong, "'. Я прослушал его уже где-то ", count, " раз. Вообще супер!");

            _wallFactory = new WallFactory(_manager); // Инициализируем «фабрику» стены

            // Пробуем опубликовать на стену
            try
            {
                id = int.Parse(idInput.Text); // Преобразуем текст из поля idInput в тип int
                _wallFactory.Post(id, shareText); // Опубликовываем текст рекомендации на стену того ID'a, которого мы указали в поле выше
                actionsStatus.Text = "Опубликовано."; // Уведомляем пользователя об успешности
                actionsStatusTimer.Enabled = true; // Включаем таймер, который каждые n-секунд сбрасывает специальной поле статуса действий
            }

            // Если неудачно, то выдаем ошибку
            catch (Exception)
            {
                actionsStatus.Text = "Введен некорректный ID.";
                actionsStatusTimer.Enabled = true;
            }
        }

        // Выполняется при нажатии «Поместить себе на страницу»
        private void wallSongButton_Click(object sender, EventArgs e)
        {
            iTunesApp app = new iTunesAppClass(); // Как обычно регистрируем iTunes, как класс приложения

            // Получаем нужную нам информацию о композиции
            string artist = app.CurrentTrack.Artist;
            string name = app.CurrentTrack.Name;
            int count = app.CurrentTrack.PlayedCount;

            // Соединяем исполнителя и название в одну строку
            string currentSong = String.Concat(artist, " - ", name);

            // Формируем текст для расшаривания
            string shareText = String.Concat("Рекомендую вам послушать трек '", currentSong, "'. Я прослушал его уже где-то ", count, " раз. Мне нравится! :D");

            // Пробуем поместить себе на стену
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

        // Выполняется при каждом тике таймера, который сбрасывает поле со статусом действий
        private void actionsStatusTimer_Tick(object sender, EventArgs e)
        {
            actionsStatus.Text = "Выберите необходимое действие.";
            actionsStatusTimer.Enabled = false;
        }

        // Выполняется при каждом изменении поля idInput
        private void idInput_TextChanged(object sender, EventArgs e)
        {
            shareButton.Enabled = idInput.TextLength > 0;
        }

        // Выполняется при создании «Своего» статуса
        private void customSet_Click(object sender, EventArgs e)
        {
            try
            {
                iTunesApp app = new iTunesAppClass(); // Регистрируем iTunes

                // Получаем необходимую информацию о композиции
                string artist = app.CurrentTrack.Artist;
                string name = app.CurrentTrack.Name;
                string playlist = app.CurrentTrack.Playlist.Name;
                string album = app.CurrentTrack.Album;
                string genre = app.CurrentTrack.Genre;
                string prefix = _templatestatus;
                int count = app.CurrentTrack.PlayedCount;

                // Преобразуем ключевые слова
                string result1 = customText.Text.Replace("{name}", name);
                string result2 = result1.Replace("{artist}", artist);
                string result3 = result2.Replace("{playlist}", playlist);
                string result4 = result3.Replace("{count}", count.ToString());
                string result5 = result4.Replace("{album}", album);
                string result6 = result5.Replace("{genre}", genre);
                string result7 = result6.Replace("{prefix}", prefix);
                textBox2.Text = result7; // Выдаем результат
            }
            catch (Exception)
            {
                checkiTunes();
            }
        }

        // Выполняется при изменении статуса чекбоска «Свой»
        private void customStatus_CheckedChanged(object sender, EventArgs e)
        {
            // Если чекбокс был неактивен, то..
            if (_custom == false)
            {
                _custom = true;
                playlistUse.Checked = false;
                playlistUse.Enabled = false;
                countCheck.Checked = false;
                countCheck.Enabled = false;
                genreCheck.Enabled = false;
                genreCheck.Checked = false;
                groupBox5.Enabled = true;
                textBox3.Enabled = true;
                customText.Enabled = true;
            }
            
            // А если активен..
            else
            {
                _custom = false;
                playlistUse.Enabled = true;
                countCheck.Enabled = true;
                genreCheck.Enabled = true;
                groupBox5.Enabled = false;
                textBox3.Enabled = false;
                customText.Enabled = false;
            }
        }

        // Выполняется при каждом изменении поля со своим статусом
        private void customText_TextChanged(object sender, EventArgs e)
        {
            customSet.Enabled = customText.TextLength > 0;
        }

        // Выполняется при попытке развернуть программу
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        // Проверяется установленность iTunes SVKS
        private void checkInstall()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\iTunesSVKS"); // Инициализируем ветку реестра, с которой будем работать

            // Пробуем получить нужный ключ
            try
            {
                object value = key.GetValue("Installed"); // Пытаемся получить ключ
                string valueS = value.ToString(); // Преобразуем ключ в строку

                // Проверяем..
                if (valueS == "1")
                {
                    Reauth(); // Успешно! Значит можем авторизироваться
                }

                // Неуспешно..
                else
                {
                    // Показываем предупреждение, но даем пользователю возможность продолжить работу с программой
                  DialogResult result = MessageBox.Show(
                        "iTunes SVKS не сконфигурирован. Возможна нестабильная работа. Для проверки конфигурации запустите Checker.exe",
                        "Не обнаружены нужные записи в реестре", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        Application.Exit(); // Если пользователь не хочет рисковать, то закрываем это всё
                    }
                    else
                    {
                        Reauth(); // Если пользователь рискнул, то логинимся
                    }
                }
            }

            // Ловим ошибку и выполняем всё то же, что и при else
            catch (Exception)
            {
                DialogResult result = MessageBox.Show(
      "iTunes SVKS не сконфигурирован. Возможна нестабильная работа. Для проверки конфигурации запустите Checker.exe",
      "Не обнаружены нужные записи в реестре", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
                else
                {
                    Reauth();
                }
            }
        }
    }
}
