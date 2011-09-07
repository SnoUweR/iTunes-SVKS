using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace Checker
{
    public partial class Form1 : Form
    {
        private bool _iTunesInstalled = false;
        private bool _internetStatus = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(stepLabel.Text == "Шаг 1: Приветствие")
            {
                checkInstall();
                setupProgress.Value = 25;
            }
            else if(stepLabel.Text == "Шаг 2: Проверка iTunes")
            {
                if(_iTunesInstalled == false)
                {

                    DialogResult result = MessageBox.Show("Вы действительно хотите продолжить? Стабильная работа программы не гарантируется", "Закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        checkInternet();
                        setupProgress.Value = 75;
                    }
                    else
                    {
                        Close();
                    }
                }

                checkInternet();
                setupProgress.Value = 75;
                nextStep.Text = "Далее";
            }
            else if(stepLabel.Text == "Шаг 3: Проверка подключения к VK.com")
            {

                if (_internetStatus == false)
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите продолжить? Стабильная работа программы не гарантируется", "Закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        showFinalStep();
                        setupProgress.Value = 100;
                        nextStep.Visible = false;
                    }
                    else
                    {
                        Close();
                    }

                }

                showFinalStep();
                setupProgress.Value = 100;
            }
        }

        private void checkInstall()
        {

            Text = "Добро пожаловать в iTunes SVKS | Шаг 2";
            stepLabel.Text = "Шаг 2: Проверка iTunes";

            try
            {

                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Apple Computer, Inc.\iTunes");
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

        private void checkInternet()
        {
            Text = "Добро пожаловать в iTunes SVKS | Шаг 3";
            stepLabel.Text = "Шаг 3: Проверка подключения к VK.com";

            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions { DontFragment = true };

                string data = "InatrailoffireIknowWewillbefreeagain";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 300;
                PingReply reply = pingSender.Send("vk.com", timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    _internetStatus = true;
                    mainLabel.Text = "Соединение с VK.com установлено. Вы можете продолжить";
                }
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

        private void showFinalStep()
        {
            CreateRegistryRecord();

            Text = "Добро пожаловать в iTunes SVKS | Шаг 4";
            stepLabel.Text = "Шаг 4: Финальный шаг";

            nextStep.Visible = false;
            otherLabel.Visible = false;
            runButton.Visible = true;

            mainLabel.Text =
                "Первоначальная настройка iTunes SVKS успешно завершена. \n \n Теперь вы можете начать полноценную работу с программой. \n \n По всем вопросам и пожеланиям пишите на snouwer@gmail.com \n \n Удачного дня и работы! \n \n Для сохранения изменений запустите iTunes SVKS заного.";
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Close();
        }

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
