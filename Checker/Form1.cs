using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
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

namespace Checker
{
    public partial class Form1 : Form
    {
        // Инициализируем нужные переменные
        private bool _iTunesInstalled = false;
        private bool _internetStatus = false;

        // Происходит при создании окна Form1
        public Form1()
        {
            InitializeComponent();
        }

        // Происходит при нажатии на кнопку «Далее» («Пропустить»)
        private void button1_Click(object sender, EventArgs e)
        {
            // Если мы на первом шаге, то выполняем следующее..
            if(stepLabel.Text == "Шаг 1: Приветствие")
            {
                checkInstall(); // Проверяем установленность iTunes
                setupProgress.Value = 25; // Устанавливаем значение прогресс-бара на 25%
            }

            // Если мы на втором шаге, то..
            else if(stepLabel.Text == "Шаг 2: Проверка iTunes")
            {
                // Если iTunes не был найден, то показываем предупреждение
                if(_iTunesInstalled == false)
                {

                    DialogResult result = MessageBox.Show("Вы действительно хотите продолжить? Стабильная работа программы не гарантируется", "Закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        checkInternet(); // Проверяем доступ к интернету (пингуем VK.com)
                        setupProgress.Value = 75; // Устанавливаем значение прогресс-бара на 75%
                    }
                    else
                    {
                        Close();
                    }
                }

                checkInternet(); // Проверяем интернет (пингуем VK.com)
                setupProgress.Value = 75; // Прогресс-бар на 75%
                nextStep.Text = "Далее"; // Меняем название кнопки
            }

            // Если мы на третьем шаге..
            else if(stepLabel.Text == "Шаг 3: Проверка подключения к VK.com")
            {
                // Если пингование прошло неуспешно, то показываем предупреждение
                if (_internetStatus == false)
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите продолжить? Стабильная работа программы не гарантируется", "Закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        showFinalStep(); // Показываем последний шаг
                        setupProgress.Value = 100; // Прогресс-бар на 100%
                        nextStep.Visible = false; // Скрываем кнопку «Продолжить» («Пропустить»
                    }
                    else
                    {
                        Close();
                    }

                }

                showFinalStep(); // Показываем последний шаг
                setupProgress.Value = 100; // Прогресс-бар на 100%
            }
        }
        
        // Проверяем установленность iTunes (А точнее, нужный ключ в реестре). Требуется найти другой способ(!)
        private void checkInstall()
        {

            Text = "Добро пожаловать в iTunes SVKS | Шаг 2"; // Меняем название окна
            stepLabel.Text = "Шаг 2: Проверка iTunes"; // Меняем название шага

            // Пробуем получить определенный ключ из реестра
            try
            {

                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Apple Computer, Inc.\iTunes");

                // Ключ InstalledOnVista, при правильной установке iTunes, по идее, должен быть равен 1, если ОС пользователя - это
                // Windows 7/Vista, и 0, если ОС - Windows XP и ниже
                string s = key.GetValue("InstalledOnVista").ToString();

                if (s == "1" || s == "0")
                {
                    _iTunesInstalled = true;
                    mainLabel.Text = "Плеер iTunes успешно найден на вашем компьютере.\n \n Щелкните «Далее», чтобы продолжить";
                }

                else
                {
                    _iTunesInstalled = false;
                    nextStep.Text = "Пропустить";
                    mainLabel.Text = "iTunes не найден. Возможно он не установлен на вашей системе, либо установлен неправильно.";
                    otherLabel.Visible = true;
                    otherLabel.Text =
                        "Рекомендуется установить/переустановить iTunes. Вы можете продолжить, но стабильная работа программы не гарантируется.";
                }

            }
            catch (Exception)
            {
                _iTunesInstalled = false;
                nextStep.Text = "Пропустить";
                mainLabel.Text = "iTunes не найден. Возможно он не установлен на вашей системе, либо установлен неправильно.";
                otherLabel.Visible = true;
                otherLabel.Text =
                    "Рекомендуется установить/переустановить iTunes. \n Вы можете пропустить этот шаг, но стабильная работа программы не гарантируется.";
            }
        }

        // Проверяем наличие соединения к VK.com (попросту говоря, пингуем сайт)
        private void checkInternet()
        {
            Text = "Добро пожаловать в iTunes SVKS | Шаг 3";
            stepLabel.Text = "Шаг 3: Проверка подключения к VK.com";

            // Пробуем пропинговать VK.com
            try
            {
                Ping pingSender = new Ping();  // Инициализируем
                PingOptions options = new PingOptions { DontFragment = true }; // Настраиваем (фактически, отключаем фрагментацию)

                string data = "InatrailoffireIknowWewillbefreeagain"; // Формируем строку, которую отправим
                byte[] buffer = Encoding.ASCII.GetBytes(data); // Кодируем строку в ASCII (не?)
                int timeout = 300; // Устанавливаем таймаут
                PingReply reply = pingSender.Send("vk.com", timeout, buffer, options); // Пингуем!

                // Если ответ получен, то..
                if (reply.Status == IPStatus.Success)
                {
                    _internetStatus = true;
                    mainLabel.Text = "Соединение с VK.com установлено. Вы можете продолжить";
                }

                // А если не получен..
                else
                {
                    _internetStatus = false;
                    nextStep.Text = "Пропустить";
                    mainLabel.Text = "Настройщик не смог соединиться с VK.com. \n \n Возможно сайт попросту недоступен, но, на всякий случай \n проверьте соединение с интернетом.";
                    otherLabel.Visible = true;
                    otherLabel.Text =
                        "Проверьте настройки интернета. \n Вы можете пропустить этот шаг, но стабильная работа программы не гарантируется.";
                }
            }

            // Если произошла ошибка..        
            catch (Exception)
            {
                _internetStatus = false;
                nextStep.Text = "Пропустить";
                mainLabel.Text = "Настройщик не смог соединиться с VK.com. \n \n Возможно сайт попросту недоступен, но, на всякий случай \n проверьте соединение с интернетом.";
                otherLabel.Visible = true;
                otherLabel.Text =
                    "Проверьте настройки интернета. \n Вы можете пропустить этот шаг, но стабильная работа программы не гарантируется.";
            }
        }

        // Показываем финальный шаг
        private void showFinalStep()
        {
            CreateRegistryRecord(); // Выполняем функцию создания записи в реестре

            Text = "Добро пожаловать в iTunes SVKS | Шаг 4";
            stepLabel.Text = "Шаг 4: Финальный шаг";

            nextStep.Visible = false;
            otherLabel.Visible = false;
            runButton.Visible = true;

            mainLabel.Text =
                "Первоначальная настройка iTunes SVKS успешно завершена. \n \n Теперь вы можете начать полноценную работу с программой. \n \n По всем вопросам и пожеланиям пишите на snouwer@gmail.com \n \n Удачного дня и работы! \n \n Для сохранения изменений запустите iTunes SVKS заного.";
        }

        // При нажатии на «Закрыть», неожиданно, закрываем окно
        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("iTunesSVKS.exe");
            }
            catch (Exception)
            {

            }
            Application.Exit();
        }

        // Создаем запись в реестре
        private void CreateRegistryRecord()
        {
            RegistryKey key = Registry.CurrentUser;
            key.CreateSubKey("Software\\iTunesSVKS");

            RegistryKey keyS = Registry.CurrentUser.OpenSubKey("Software\\iTunesSVKS", true);
            keyS.OpenSubKey("Software\\iTunesSVKS", true);
            keyS.SetValue("Installed", "1");
            keyS.Close();
        }
    }
}
