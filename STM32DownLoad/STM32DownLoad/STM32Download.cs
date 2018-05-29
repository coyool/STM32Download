using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM32DownLoad
{
    public partial class STM32Download : Form
    {
        private string m_strBeginClear = "开始擦除";
        private string m_strEndClear = "擦除成功";
        private string m_strFailClear = "擦除失败";
        private string m_strBeginDownload = "正在下载";
        private string m_strEndDownload = "下载成功";
        private string m_strFailDownload = "下载失败";
        private string m_strAddress = "0x8000000";
        private string m_strFilePath = "path.ini";

        private string m_strSTM_LINK = string.Empty;
        enum SerialNumber {One,Two,Three,Four,Five,Six,Seven,Eigth,Error };
        System.Timers.Timer DownloadOneTimer = new System.Timers.Timer(500);//实例化Timer类，设置间隔时间为500毫秒；
        System.Timers.Timer DownloadTwoTimer = new System.Timers.Timer(500);
        System.Timers.Timer DownloadThreeTimer = new System.Timers.Timer(500);
        System.Timers.Timer DownloadFourTimer = new System.Timers.Timer(500);
        System.Timers.Timer DownloadFiveTimer = new System.Timers.Timer(500);
        System.Timers.Timer DownloadSixTimer = new System.Timers.Timer(500);
        System.Timers.Timer DownloadSevenTimer = new System.Timers.Timer(500);
        System.Timers.Timer DownloadEightTimer = new System.Timers.Timer(500);
        public STM32Download()
        {
            InitializeComponent();
        }

        private bool IsRunningDownload()
        {
            if(this.buttonStart_1.Enabled || this.buttonStart_2.Enabled || this.buttonStart_3.Enabled || this.buttonStart_4.Enabled ||
               this.buttonStart_5.Enabled || this.buttonStart_6.Enabled || this.buttonStart_7.Enabled || this.buttonStart_8.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ResetDownloadProgress()
        {
            this.progressBar1.Value = 0;
            this.progressBar2.Value = 0;
            this.progressBar3.Value = 0;
            this.progressBar4.Value = 0;
            this.progressBar5.Value = 0;
            this.progressBar6.Value = 0;
            this.progressBar7.Value = 0;
            this.progressBar8.Value = 0;
        }
        private void ResetDownloadProgress(SerialNumber num)
        {
            switch(num)
            {
                case SerialNumber.One:
                    this.progressBar1.Value = 0;
                    break;
                case SerialNumber.Two:
                    this.progressBar2.Value = 0;
                    break;
                case SerialNumber.Three:
                    this.progressBar3.Value = 0;
                    break;
                case SerialNumber.Four:
                    this.progressBar4.Value = 0;
                    break;
                case SerialNumber.Five:
                    this.progressBar5.Value = 0;
                    break;
                case SerialNumber.Six:
                    this.progressBar6.Value = 0;
                    break;
                case SerialNumber.Seven:
                    this.progressBar7.Value = 0;
                    break;
                case SerialNumber.Eigth:
                    this.progressBar8.Value = 0;
                    break;
                default:
                    break;
            }
        }

        private void FullDownloadProgress(SerialNumber num)
        {
            switch (num)
            {
                case SerialNumber.One:
                    this.progressBar1.Value = 100;
                    break;
                case SerialNumber.Two:
                    this.progressBar2.Value = 100;
                    break;
                case SerialNumber.Three:
                    this.progressBar3.Value = 100;
                    break;
                case SerialNumber.Four:
                    this.progressBar4.Value = 100;
                    break;
                case SerialNumber.Five:
                    this.progressBar5.Value = 100;
                    break;
                case SerialNumber.Six:
                    this.progressBar6.Value = 100;
                    break;
                case SerialNumber.Seven:
                    this.progressBar7.Value = 100;
                    break;
                case SerialNumber.Eigth:
                    this.progressBar8.Value = 100;
                    break;
                default:
                    break;
            }
        }
        private void IncreaseProgress(SerialNumber num)
        {
            switch (num)
            {
                case SerialNumber.One:
                    if (this.progressBar1.Value+5 < this.progressBar1.Maximum)
                    {
                        this.progressBar1.Value+=5;
                    }
                    else
                    {
                        this.progressBar1.Value = 95;
                    }
                    break;
                case SerialNumber.Two:
                    if (this.progressBar2.Value + 5 < this.progressBar2.Maximum)
                    {
                        this.progressBar2.Value += 5;
                    }
                    else
                    {
                        this.progressBar2.Value = 95;
                    }
                    break;
                case SerialNumber.Three:
                    if (this.progressBar3.Value + 5 < this.progressBar3.Maximum)
                    {
                        this.progressBar3.Value += 5;
                    }
                    else
                    {
                        this.progressBar3.Value = 95;
                    }
                    break;
                case SerialNumber.Four:
                    if (this.progressBar4.Value + 5 < this.progressBar4.Maximum)
                    {
                        this.progressBar4.Value += 5;
                    }
                    else
                    {
                        this.progressBar4.Value = 95;
                    }
                    break;
                case SerialNumber.Five:
                    if (this.progressBar5.Value + 5 < this.progressBar5.Maximum)
                    {
                        this.progressBar5.Value += 5;
                    }
                    else
                    {
                        this.progressBar5.Value = 95;
                    }
                    break;
                case SerialNumber.Six:
                    if (this.progressBar6.Value + 5 < this.progressBar6.Maximum)
                    {
                        this.progressBar6.Value += 5;
                    }
                    else
                    {
                        this.progressBar6.Value = 95;
                    }
                    break;
                case SerialNumber.Seven:
                    if (this.progressBar7.Value + 5 < this.progressBar7.Maximum)
                    {
                        this.progressBar7.Value += 5;
                    }
                    else
                    {
                        this.progressBar7.Value = 95;
                    }
                    break;
                case SerialNumber.Eigth:
                    if (this.progressBar8.Value + 5 < this.progressBar8.Maximum)
                    {
                        this.progressBar8.Value += 5;
                    }
                    else
                    {
                        this.progressBar8.Value = 95;
                    }
                    break;
                default:
                    break;
            }
        }
        private void GetSimulatorToolSerialNumber_Click(object sender, EventArgs e)
        {
            /*
            if(IsRunningDownload())
            {
                MessageBox.Show("版本下载中，请待版本下载结束后再获取新的仿真器串号");
                return;
            }
            */
            GetSimulatorToolSerial();
        }
        private bool EraseResult(string strResult)
        {
            if(strResult.Contains("Flash memory erased."))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EraseChip(SerialNumber num)
        {
            Cmd cmd = new Cmd();
            string Erasecmd = string.Empty;
            string str = string.Empty;
            ResetDownloadProgress(num);
            StartDownloadTimer(num);
            switch (num)
            {
                case SerialNumber.One:
                    
                    Erasecmd = string.Format("{0} -c SN={1} -ME {2}\r\n", m_strSTM_LINK, this.textBox_Serial_1.Text.Trim(), m_strAddress);
                    str = cmd.RunCmd(Erasecmd);
                    if (EraseResult(str))
                    {
                        this.textBox_Result_1.ForeColor = Color.Green;   
                        this.textBox_Result_1.Text = m_strEndClear;

                        Thread downloadCmd = new Thread(DownloadVersionOne);
                        downloadCmd.Start();
                    }
                    else
                    {
                        this.textBox_Result_1.ForeColor = Color.Red;
                        this.textBox_Result_1.Text = m_strFailClear;
                        StopDownloadTimer(num);
                        ResetDownloadProgress(num);
                        this.buttonStart_1.Enabled = true;
                    }
                    break;
                case SerialNumber.Two:
                    Erasecmd = string.Format("{0} -c SN={1} -ME {2}\r\n", m_strSTM_LINK, this.textBox_Serial_2.Text.Trim(), m_strAddress);
                    str = cmd.RunCmd(Erasecmd);
                    if (EraseResult(str))
                    {
                        this.textBox_Result_2.ForeColor = Color.Green;
                        this.textBox_Result_2.Text = m_strEndClear;

                        Thread downloadCmd = new Thread(DownloadVersionTwo);
                        downloadCmd.Start();
                    }
                    else
                    {
                        this.textBox_Result_2.ForeColor = Color.Red;
                        this.textBox_Result_2.Text = m_strFailClear;
                        StopDownloadTimer(num);
                        ResetDownloadProgress(num);
                        this.buttonStart_2.Enabled = true;
                    }
                    break;
                case SerialNumber.Three:
                    Erasecmd = string.Format("{0} -c SN={1} -ME {2}\r\n", m_strSTM_LINK, this.textBox_Serial_3.Text.Trim(), m_strAddress);
                    str = cmd.RunCmd(Erasecmd);
                    if (EraseResult(str))
                    {
                        this.textBox_Result_3.ForeColor = Color.Green;
                        this.textBox_Result_3.Text = m_strEndClear;

                        Thread downloadCmd = new Thread(DownloadVersionThree);
                        downloadCmd.Start();
                    }
                    else
                    {
                        this.textBox_Result_3.ForeColor = Color.Red;
                        this.textBox_Result_3.Text = m_strFailClear;
                        StopDownloadTimer(num);
                        ResetDownloadProgress(num);
                        this.buttonStart_3.Enabled = true;
                    }
                    break;
                case SerialNumber.Four:
                    Erasecmd = string.Format("{0} -c SN={1} -ME {2}\r\n", m_strSTM_LINK, this.textBox_Serial_4.Text.Trim(), m_strAddress);
                    str = cmd.RunCmd(Erasecmd);
                    if (EraseResult(str))
                    {
                        this.textBox_Result_4.ForeColor = Color.Green;
                        this.textBox_Result_4.Text = m_strEndClear;

                        Thread downloadCmd = new Thread(DownloadVersionFour);
                        downloadCmd.Start();
                    }
                    else
                    {
                        this.textBox_Result_4.ForeColor = Color.Red;
                        this.textBox_Result_4.Text = m_strFailClear;
                        StopDownloadTimer(num);
                        ResetDownloadProgress(num);
                        this.buttonStart_4.Enabled = true;
                    }
                    break;
                case SerialNumber.Five:
                    Erasecmd = string.Format("{0} -c SN={1} -ME {2}\r\n", m_strSTM_LINK, this.textBox_Serial_5.Text.Trim(), m_strAddress);
                    str = cmd.RunCmd(Erasecmd);
                    if (EraseResult(str))
                    {
                        this.textBox_Result_5.ForeColor = Color.Green;
                        this.textBox_Result_5.Text = m_strEndClear;

                        Thread downloadCmd = new Thread(DownloadVersionFive);
                        downloadCmd.Start();
                    }
                    else
                    {
                        this.textBox_Result_5.ForeColor = Color.Red;
                        this.textBox_Result_5.Text = m_strFailClear;
                        StopDownloadTimer(num);
                        ResetDownloadProgress(num);
                        this.buttonStart_5.Enabled = true;
                    }
                    break;
                case SerialNumber.Six:
                    Erasecmd = string.Format("{0} -c SN={1} -ME {2}\r\n", m_strSTM_LINK, this.textBox_Serial_6.Text.Trim(), m_strAddress);
                    str = cmd.RunCmd(Erasecmd);
                    if (EraseResult(str))
                    {
                        this.textBox_Result_6.ForeColor = Color.Green;
                        this.textBox_Result_6.Text = m_strEndClear;

                        Thread downloadCmd = new Thread(DownloadVersionSix);
                        downloadCmd.Start();
                    }
                    else
                    {
                        this.textBox_Result_6.ForeColor = Color.Red;
                        this.textBox_Result_6.Text = m_strFailClear;
                        StopDownloadTimer(num);
                        ResetDownloadProgress(num);
                        this.buttonStart_6.Enabled = true;
                    }
                    break;
                case SerialNumber.Seven:
                    Erasecmd = string.Format("{0} -c SN={1} -ME {2}\r\n", m_strSTM_LINK, this.textBox_Serial_7.Text.Trim(), m_strAddress);
                    str = cmd.RunCmd(Erasecmd);
                    if (EraseResult(str))
                    {
                        this.textBox_Result_7.ForeColor = Color.Green;
                        this.textBox_Result_7.Text = m_strEndClear;

                        Thread downloadCmd = new Thread(DownloadVersionSeven);
                        downloadCmd.Start();
                    }
                    else
                    {
                        this.textBox_Result_7.ForeColor = Color.Red;
                        this.textBox_Result_7.Text = m_strFailClear;
                        StopDownloadTimer(num);
                        ResetDownloadProgress(num);
                        this.buttonStart_7.Enabled = true;
                    }
                    break;
                case SerialNumber.Eigth:
                    Erasecmd = string.Format("{0} -c SN={1} -ME {2}\r\n", m_strSTM_LINK, this.textBox_Serial_8.Text.Trim(), m_strAddress);
                    str = cmd.RunCmd(Erasecmd);
                    if (EraseResult(str))
                    {
                        this.textBox_Result_8.ForeColor = Color.Green;
                        this.textBox_Result_8.Text = m_strEndClear;

                        Thread downloadCmd = new Thread(DownloadVersionEight);
                        downloadCmd.Start();
                    }
                    else
                    {
                        this.textBox_Result_8.ForeColor = Color.Red;
                        this.textBox_Result_8.Text = m_strFailClear;
                        StopDownloadTimer(num);
                        ResetDownloadProgress(num);
                        this.buttonStart_8.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }
        private void EraseChipOne()
        {
            EraseChip(SerialNumber.One);
        }
        private void EraseChipTwo()
        {
            EraseChip(SerialNumber.Two);
        }
        private void EraseChipThree()
        {
            EraseChip(SerialNumber.Three);
        }
        private void EraseChipFour()
        {
            EraseChip(SerialNumber.Four);
        }
        private void EraseChipFive()
        {
            EraseChip(SerialNumber.Five);
        }
        private void EraseChipSix()
        {
            EraseChip(SerialNumber.Six);
        }
        private void EraseChipSeven()
        {
            EraseChip(SerialNumber.Seven);
        }
        private void EraseChipEight()
        {
            EraseChip(SerialNumber.Eigth);
        }

        private bool DownloadResult(string strResult)
        {
            if(strResult.Contains("Programming Complete."))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DownloadVersion(SerialNumber num)
        {
            Cmd cmd = new Cmd();
            string DownloadCmd = string.Empty;
            string str = string.Empty;
            switch (num)
            {
                case SerialNumber.One:
                    this.textBox_Result_1.Text = m_strBeginDownload ;
                    this.progressBar1.Increment(15);
                    DownloadCmd = string.Format("{0} -c SN={1} -P {2} {3}\r\n", m_strSTM_LINK, this.textBox_Serial_1.Text.Trim(), this.textBox_VersionPath.Text, m_strAddress);
                    str = cmd.RunCmd(DownloadCmd);
                    StopDownloadTimer(num);
                    if (DownloadResult(str))
                    {
                        FullDownloadProgress(num);
                        this.textBox_Result_1.ForeColor = Color.Blue;
                        this.textBox_Result_1.Text = m_strEndDownload;
                    }
                    else
                    {
                        this.textBox_Result_1.ForeColor = Color.Red;
                        this.textBox_Result_1.Text = m_strFailDownload;
                        ResetDownloadProgress(num);
                    }
                    this.buttonStart_1.Enabled = true;
                    break;
                case SerialNumber.Two:
                    this.textBox_Result_2.Text = m_strBeginDownload;
                    DownloadCmd = string.Format("{0} -c SN={1} -P {2} {3}\r\n", m_strSTM_LINK, this.textBox_Serial_2.Text.Trim(), this.textBox_VersionPath.Text, m_strAddress);
                    str = cmd.RunCmd(DownloadCmd);
                    StopDownloadTimer(num);
                    if (DownloadResult(str))
                    {
                        FullDownloadProgress(num);
                        this.textBox_Result_2.ForeColor = Color.Blue;
                        this.textBox_Result_2.Text = m_strEndDownload;
                    }
                    else
                    {
                        this.textBox_Result_2.ForeColor = Color.Red;
                        this.textBox_Result_2.Text = m_strFailDownload;
                        ResetDownloadProgress(num);
                    }
                    this.buttonStart_2.Enabled = true;
                    break;
                case SerialNumber.Three:
                    this.textBox_Result_3.Text = m_strBeginDownload;
                    DownloadCmd = string.Format("{0} -c SN={1} -P {2} {3}\r\n", m_strSTM_LINK, this.textBox_Serial_3.Text.Trim(), this.textBox_VersionPath.Text, m_strAddress);
                    str = cmd.RunCmd(DownloadCmd);
                    StopDownloadTimer(num);
                    if (DownloadResult(str))
                    {
                        FullDownloadProgress(num);
                        this.textBox_Result_3.ForeColor = Color.Blue;
                        this.textBox_Result_3.Text = m_strEndDownload;
                    }
                    else
                    {
                        this.textBox_Result_3.ForeColor = Color.Red;
                        this.textBox_Result_3.Text = m_strFailDownload;
                        ResetDownloadProgress(num);
                    }
                    this.buttonStart_3.Enabled = true;
                    break;
                case SerialNumber.Four:
                    this.textBox_Result_4.Text = m_strBeginDownload;
                    DownloadCmd = string.Format("{0} -c SN={1} -P {2} {3}\r\n", m_strSTM_LINK, this.textBox_Serial_4.Text.Trim(), this.textBox_VersionPath.Text, m_strAddress);
                    str = cmd.RunCmd(DownloadCmd);
                    StopDownloadTimer(num);
                    if (DownloadResult(str))
                    {
                        FullDownloadProgress(num);
                        this.textBox_Result_4.ForeColor = Color.Blue;
                        this.textBox_Result_4.Text = m_strEndDownload;
                    }
                    else
                    {
                        this.textBox_Result_4.ForeColor = Color.Red;
                        this.textBox_Result_4.Text = m_strFailDownload;
                        ResetDownloadProgress(num);
                    }
                    this.buttonStart_4.Enabled = true;
                    break;
                case SerialNumber.Five:
                    this.textBox_Result_5.Text = m_strBeginDownload;
                    DownloadCmd = string.Format("{0} -c SN={1} -P {2} {3}\r\n", m_strSTM_LINK, this.textBox_Serial_5.Text.Trim(), this.textBox_VersionPath.Text, m_strAddress);
                    str = cmd.RunCmd(DownloadCmd);
                    StopDownloadTimer(num);
                    if (DownloadResult(str))
                    {
                        FullDownloadProgress(num);
                        this.textBox_Result_5.ForeColor = Color.Blue;
                        this.textBox_Result_5.Text = m_strEndDownload;
                    }
                    else
                    {
                        this.textBox_Result_5.ForeColor = Color.Red;
                        this.textBox_Result_5.Text = m_strFailDownload;
                        ResetDownloadProgress(num);
                    }
                    this.buttonStart_5.Enabled = true;
                    break;
                case SerialNumber.Six:
                    this.textBox_Result_6.Text = m_strBeginDownload;
                    DownloadCmd = string.Format("{0} -c SN={1} -P {2} {3}\r\n", m_strSTM_LINK, this.textBox_Serial_6.Text.Trim(), this.textBox_VersionPath.Text, m_strAddress);
                    str = cmd.RunCmd(DownloadCmd);
                    StopDownloadTimer(num);
                    if (DownloadResult(str))
                    {
                        FullDownloadProgress(num);
                        this.textBox_Result_6.ForeColor = Color.Blue;
                        this.textBox_Result_6.Text = m_strEndDownload;
                    }
                    else
                    {
                        this.textBox_Result_6.ForeColor = Color.Red;
                        this.textBox_Result_6.Text = m_strFailDownload;
                        ResetDownloadProgress(num);
                    }
                    this.buttonStart_6.Enabled = true;
                    break;
                case SerialNumber.Seven:
                    this.textBox_Result_7.Text = m_strBeginDownload;
                    DownloadCmd = string.Format("{0} -c SN={1} -P {2} {3}\r\n", m_strSTM_LINK, this.textBox_Serial_7.Text.Trim(), this.textBox_VersionPath.Text, m_strAddress);
                    str = cmd.RunCmd(DownloadCmd);
                    StopDownloadTimer(num);
                    if (DownloadResult(str))
                    {
                        FullDownloadProgress(num);
                        this.textBox_Result_7.ForeColor = Color.Blue;
                        this.textBox_Result_7.Text = m_strEndDownload;
                    }
                    else
                    {
                        this.textBox_Result_7.ForeColor = Color.Red;
                        this.textBox_Result_7.Text = m_strFailDownload;
                        ResetDownloadProgress(num);
                    }
                    this.buttonStart_7.Enabled = true;
                    break;
                case SerialNumber.Eigth:
                    this.textBox_Result_8.Text = m_strBeginDownload;
                    DownloadCmd = string.Format("{0} -c SN={1} -P {2} {3}\r\n", m_strSTM_LINK, this.textBox_Serial_8.Text.Trim(), this.textBox_VersionPath.Text, m_strAddress);
                    str = cmd.RunCmd(DownloadCmd);
                    StopDownloadTimer(num);
                    if (DownloadResult(str))
                    {
                        FullDownloadProgress(num);
                        this.textBox_Result_8.ForeColor = Color.Blue;
                        this.textBox_Result_8.Text = m_strEndDownload;
                    }
                    else
                    {
                        this.textBox_Result_8.ForeColor = Color.Red;
                        this.textBox_Result_8.Text = m_strFailDownload;
                        ResetDownloadProgress(num);
                    }
                    this.buttonStart_8.Enabled = true;
                    break;
                default:
                    break;

            }
        }
        private void DownloadVersionOne()
        {
            DownloadVersion(SerialNumber.One);
        }
        private void DownloadVersionTwo()
        {
            DownloadVersion(SerialNumber.Two);
        }
        private void DownloadVersionThree()
        {
            DownloadVersion(SerialNumber.Three);
        }
        private void DownloadVersionFour()
        {
            DownloadVersion(SerialNumber.Four);
        }
        private void DownloadVersionFive()
        {
            DownloadVersion(SerialNumber.Five);
        }
        private void DownloadVersionSix()
        {
            DownloadVersion(SerialNumber.Six);
        }
        private void DownloadVersionSeven()
        {
            DownloadVersion(SerialNumber.Seven);
        }
        private void DownloadVersionEight()
        {
            DownloadVersion(SerialNumber.Eigth);
        }
        private void ClearSimulatorToolSerial()
        {
            this.textBox_Serial_1.Clear();
            this.textBox_Serial_2.Clear();
            this.textBox_Serial_3.Clear();
            this.textBox_Serial_4.Clear();
            this.textBox_Serial_5.Clear();
            this.textBox_Serial_6.Clear();
            this.textBox_Serial_7.Clear();
            this.textBox_Serial_8.Clear();
        }

        private void ClearResultInfo()
        {
            this.textBox_Result_1.Clear();
            this.textBox_Result_1.BackColor = Color.White;
            this.textBox_Result_2.Clear();
            this.textBox_Result_2.BackColor = Color.White;
            this.textBox_Result_3.Clear();
            this.textBox_Result_3.BackColor = Color.White;
            this.textBox_Result_4.Clear();
            this.textBox_Result_4.BackColor = Color.White;
            this.textBox_Result_5.Clear();
            this.textBox_Result_5.BackColor = Color.White;
            this.textBox_Result_6.Clear();
            this.textBox_Result_6.BackColor = Color.White;
            this.textBox_Result_7.Clear();
            this.textBox_Result_7.BackColor = Color.White;
            this.textBox_Result_8.Clear();
            this.textBox_Result_8.BackColor = Color.White;
        }

        private void ResetProgressInfo()
        {
            this.progressBar1.Step = 0;
            this.progressBar2.Step = 0;
            this.progressBar3.Step = 0;
            this.progressBar4.Step = 0;
            this.progressBar5.Step = 0;
            this.progressBar6.Step = 0;
            this.progressBar7.Step = 0;
            this.progressBar8.Step = 0;
        }

        private void DisableStartButton()
        {
            this.buttonStartALL.Enabled = false;
            this.buttonStart_1.Enabled = false;
            this.buttonStart_2.Enabled = false;
            this.buttonStart_3.Enabled = false;
            this.buttonStart_4.Enabled = false;
            this.buttonStart_5.Enabled = false;
            this.buttonStart_6.Enabled = false;
            this.buttonStart_7.Enabled = false;
            this.buttonStart_8.Enabled = false;
        }
        private void RunListCmd()
        {
            string strListCmd = m_strSTM_LINK + " -List\r\n";
            Cmd cmd = new Cmd();
            string str = cmd.RunCmd(strListCmd);
            ClearSimulatorToolSerial();
            DisableStartButton();
            ClearResultInfo();
            ResetDownloadProgress();
            string[] LineString = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] SNNumber = new string[8];
            int iIndex = 0;
            for (int i = 0; i < LineString.Count(); i++)
            {
                if (LineString[i].Contains("SN:"))
                {
                    string []strSn = LineString[i].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if(iIndex<8)
                    {
                        SNNumber.SetValue(strSn[1].Trim(), iIndex++);
                    }  
                }
            }
            if(0 == iIndex)
            {
                this.GetSimulatorToolSerialNumber.Enabled = true;
                MessageBox.Show("无法获取仿真器串口，请确认仿真器是否插入！");
                return;
            }
            if(iIndex>0)
            {
                this.buttonStartALL.Enabled = true;
            }
            for(int i=0;i<iIndex;i++)
            {
                switch(i)
                {
                    case 0:
                        this.textBox_Serial_1.Text = SNNumber[0];
                        this.buttonStart_1.Enabled = true;
                        break;
                    case 1:
                        this.textBox_Serial_2.Text = SNNumber[1];
                        this.buttonStart_2.Enabled = true;
                        break;
                    case 2:
                        this.textBox_Serial_3.Text = SNNumber[2];
                        this.buttonStart_3.Enabled = true;
                        break;
                    case 3:
                        this.textBox_Serial_4.Text = SNNumber[3];
                        this.buttonStart_4.Enabled = true;
                        break;
                    case 4:
                        this.textBox_Serial_5.Text = SNNumber[4];
                        this.buttonStart_5.Enabled = true;
                        break;
                    case 5:
                        this.textBox_Serial_6.Text = SNNumber[5];
                        this.buttonStart_6.Enabled = true;
                        break;
                    case 6:
                        this.textBox_Serial_7.Text = SNNumber[6];
                        this.buttonStart_6.Enabled = true;
                        break;
                    case 7:
                        this.textBox_Serial_8.Text = SNNumber[7];
                        this.buttonStart_7.Enabled = true;
                        break;
                    default:
                        break;
                }
            }

            this.GetSimulatorToolSerialNumber.Enabled = true;
        }
        private void GetSimulatorToolSerial()
        {
            this.GetSimulatorToolSerialNumber.Enabled = false;  
            Thread listCmd = new Thread(RunListCmd);
            listCmd.Start();
        }

        private bool HasSelectVerion()
        {
            if(string.Empty.Equals(this.textBox_VersionPath.Text.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void pictureBoxOpenFolder_Click(object sender, EventArgs e)
        {

        }

        private void StartOneThread()
        {
            this.buttonStart_1.Enabled = false;
            this.textBox_Result_1.BackColor = Color.Blue;
            this.textBox_Result_1.Text = m_strBeginClear;
            Thread ClearCmd = new Thread(EraseChipOne);
            ClearCmd.Start();
        }

        private void StartTwoThread()
        {
            this.buttonStart_2.Enabled = false;
            this.textBox_Result_2.BackColor = Color.Blue;
            this.textBox_Result_2.Text = m_strBeginClear;
            Thread ClearCmd = new Thread(EraseChipTwo);
            ClearCmd.Start();
        }
        private void StartThreeThread()
        {
            this.buttonStart_3.Enabled = false;
            this.textBox_Result_3.BackColor = Color.Blue;
            this.textBox_Result_3.Text = m_strBeginClear;
            Thread ClearCmd = new Thread(EraseChipThree);
            ClearCmd.Start();
        }
        private void StartFourThread()
        {
            this.buttonStart_4.Enabled = false;
            this.textBox_Result_4.BackColor = Color.Blue;
            this.textBox_Result_4.Text = m_strBeginClear;
            Thread ClearCmd = new Thread(EraseChipFour);
            ClearCmd.Start();
        }
        private void StartFiveThread()
        {
            this.buttonStart_5.Enabled = false;
            this.textBox_Result_5.BackColor = Color.Blue;
            this.textBox_Result_5.Text = m_strBeginClear;
            Thread ClearCmd = new Thread(EraseChipFive);
            ClearCmd.Start();
        }
        private void StartSixThread()
        {
            this.buttonStart_6.Enabled = false;
            this.textBox_Result_6.BackColor = Color.Blue;
            this.textBox_Result_6.Text = m_strBeginClear;
            Thread ClearCmd = new Thread(EraseChipSix);
            ClearCmd.Start();
        }
        private void StartSevenThread()
        {
            this.buttonStart_7.Enabled = false;
            this.textBox_Result_7.BackColor = Color.Blue;
            this.textBox_Result_7.Text = m_strBeginClear;
            Thread ClearCmd = new Thread(EraseChipSeven);
            ClearCmd.Start();
        }

        private void StartEightThread()
        {
            this.buttonStart_8.Enabled = false;
            this.textBox_Result_8.BackColor = Color.Blue;
            this.textBox_Result_8.Text = m_strBeginClear;
            Thread ClearCmd = new Thread(EraseChipEight);
            ClearCmd.Start();
        }
        private void buttonStartALL_Click(object sender, EventArgs e)
        {
            if(HasSelectVerion())
            {
                if (this.buttonStart_1.Enabled)
                {
                    StartOneThread();
                }
                if (this.buttonStart_2.Enabled)
                {
                    StartTwoThread();
                }
                
                if(this.buttonStart_3.Enabled)
                {
                    StartThreeThread();
                }
                if (this.buttonStart_4.Enabled)
                {
                    StartFourThread();
                }
                if (this.buttonStart_5.Enabled)
                {
                    StartFiveThread();
                }
                if (this.buttonStart_6.Enabled)
                {
                    StartSixThread();
                }
                if (this.buttonStart_7.Enabled)
                {
                    StartSevenThread();
                }
                if (this.buttonStart_8.Enabled)
                {
                    StartEightThread();
                }  
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void buttonStart_1_Click(object sender, EventArgs e)
        {
            if (HasSelectVerion())
            {
                StartOneThread();
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void buttonStart_2_Click(object sender, EventArgs e)
        {
            if (HasSelectVerion())
            {
                StartTwoThread();
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void buttonStart_3_Click(object sender, EventArgs e)
        {
            if (HasSelectVerion())
            {
                StartThreeThread();
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void buttonStart_4_Click(object sender, EventArgs e)
        {
            if (HasSelectVerion())
            {
                StartFourThread();
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void buttonStart_5_Click(object sender, EventArgs e)
        {
            if (HasSelectVerion())
            {
                StartFiveThread();
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void buttonStart_6_Click(object sender, EventArgs e)
        {
            if (HasSelectVerion())
            {
                StartSixThread();
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void buttonStart_7_Click(object sender, EventArgs e)
        {
            if (HasSelectVerion())
            {
                StartSevenThread();
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void buttonStart_8_Click(object sender, EventArgs e)
        {
            if (HasSelectVerion())
            {
                StartEightThread();
            }
            else
            {
                MessageBox.Show("请选择要下载的版本！");
            }
        }

        private void InitDownloadTimer()
        {
            DownloadOneTimer.Elapsed += new System.Timers.ElapsedEventHandler(DownloadTimeOut);//到达时间的时候执行事件；
            DownloadOneTimer.AutoReset = true;
            DownloadOneTimer.Enabled = false;
            DownloadOneTimer.Stop();

            DownloadTwoTimer.Elapsed += new System.Timers.ElapsedEventHandler(DownloadTimeOut);
            DownloadTwoTimer.AutoReset = true;
            DownloadTwoTimer.Enabled = false;
            DownloadTwoTimer.Stop();

            DownloadThreeTimer.Elapsed += new System.Timers.ElapsedEventHandler(DownloadTimeOut);
            DownloadThreeTimer.AutoReset = true;
            DownloadThreeTimer.Enabled = false;
            DownloadThreeTimer.Stop();

            DownloadFourTimer.Elapsed += new System.Timers.ElapsedEventHandler(DownloadTimeOut);
            DownloadFourTimer.AutoReset = true;
            DownloadFourTimer.Enabled = false;
            DownloadFourTimer.Stop();

            DownloadFiveTimer.Elapsed += new System.Timers.ElapsedEventHandler(DownloadTimeOut);
            DownloadFiveTimer.AutoReset = true;
            DownloadFiveTimer.Enabled = false;
            DownloadFiveTimer.Stop();

            DownloadSixTimer.Elapsed += new System.Timers.ElapsedEventHandler(DownloadTimeOut);
            DownloadSixTimer.AutoReset = true;
            DownloadSixTimer.Enabled = false;
            DownloadSixTimer.Stop();

            DownloadSevenTimer.Elapsed += new System.Timers.ElapsedEventHandler(DownloadTimeOut);
            DownloadSevenTimer.AutoReset = true;
            DownloadSevenTimer.Enabled = false;
            DownloadSevenTimer.Stop();

            DownloadEightTimer.Elapsed += new System.Timers.ElapsedEventHandler(DownloadTimeOut);
            DownloadEightTimer.AutoReset = true;
            DownloadEightTimer.Enabled = false;
            DownloadEightTimer.Stop();
        }

        private void StartDownloadTimer(SerialNumber num)
        {
            switch(num)
            {
                case SerialNumber.One:
                    this.DownloadOneTimer.Enabled = true;
                    this.DownloadOneTimer.Start();
                    break;
                case SerialNumber.Two:
                    this.DownloadTwoTimer.Enabled = true;
                    this.DownloadTwoTimer.Start();
                    break;
                case SerialNumber.Three:
                    this.DownloadThreeTimer.Enabled = true;
                    this.DownloadThreeTimer.Start();
                    break;
                case SerialNumber.Four:
                    this.DownloadFourTimer.Enabled = true;
                    this.DownloadFourTimer.Start();
                    break;
                case SerialNumber.Five:
                    this.DownloadFiveTimer.Enabled = true;
                    this.DownloadFiveTimer.Start();
                    break;
                case SerialNumber.Six:
                    this.DownloadSixTimer.Enabled = true;
                    this.DownloadSixTimer.Start();
                    break;
                case SerialNumber.Seven:
                    this.DownloadSevenTimer.Enabled = true;
                    this.DownloadSevenTimer.Start();
                    break;
                case SerialNumber.Eigth:
                    this.DownloadEightTimer.Enabled = true;
                    this.DownloadEightTimer.Start();
                    break;
                default:
                    break;
            }
        }
        private void StopDownloadTimer(SerialNumber num)
        {
            switch (num)
            {
                case SerialNumber.One:
                    this.DownloadOneTimer.Enabled = false;
                    this.DownloadOneTimer.Stop();
                    break;
                case SerialNumber.Two:
                    this.DownloadTwoTimer.Enabled = false;
                    this.DownloadTwoTimer.Stop();
                    break;
                case SerialNumber.Three:
                    this.DownloadThreeTimer.Enabled = false;
                    this.DownloadThreeTimer.Stop();
                    break;
                case SerialNumber.Four:
                    this.DownloadFourTimer.Enabled = false;
                    this.DownloadFourTimer.Stop();
                    break;
                case SerialNumber.Five:
                    this.DownloadFiveTimer.Enabled = false;
                    this.DownloadFiveTimer.Stop();
                    break;
                case SerialNumber.Six:
                    this.DownloadSixTimer.Enabled = false;
                    this.DownloadSixTimer.Stop();
                    break;
                case SerialNumber.Seven:
                    this.DownloadSevenTimer.Enabled = false;
                    this.DownloadSevenTimer.Stop();
                    break;
                case SerialNumber.Eigth:
                    this.DownloadEightTimer.Enabled = false;
                    this.DownloadEightTimer.Stop();
                    break;
                default:
                    break;
            }
        }
        private void STM32Download_Load(object sender, EventArgs e)
        {
            m_strSTM_LINK = AppDomain.CurrentDomain.BaseDirectory + "/ST-LINK_CLI.exe";
            Control.CheckForIllegalCrossThreadCalls = false;
            ClearSimulatorToolSerial();
            ClearResultInfo();

            InitDownloadTimer();

            string strFullPath = AppDomain.CurrentDomain.BaseDirectory + "/" + m_strFilePath;
            if (File.Exists(strFullPath))
            {
                this.textBox_VersionPath.Text = File.ReadAllText(strFullPath);
            }
        }

        private void DownloadTimeOut(object source, System.Timers.ElapsedEventArgs e)
        {
            if(source.Equals(DownloadOneTimer))
            {
                IncreaseProgress(SerialNumber.One);
            }
            else if(source.Equals(DownloadTwoTimer))
            {
                IncreaseProgress(SerialNumber.Two);
            }
            else if (source.Equals(DownloadThreeTimer))
            {
                IncreaseProgress(SerialNumber.Three);
            }
            else if (source.Equals(DownloadFourTimer))
            {
                IncreaseProgress(SerialNumber.Four);
            }
            else if (source.Equals(DownloadFiveTimer))
            {
                IncreaseProgress(SerialNumber.Five);
            }
            else if (source.Equals(DownloadSixTimer))
            {
                IncreaseProgress(SerialNumber.Six);
            }
            else if (source.Equals(DownloadSevenTimer))
            {
                IncreaseProgress(SerialNumber.Seven);
            }
            else if (source.Equals(DownloadEightTimer))
            {
                IncreaseProgress(SerialNumber.Eigth);
            }
        }

        private void button_SelectVersion_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "支持的文件|*.bin;*.hex;*.srec;*.s19|*.bin|*.bin|*.hex|*.hex|*.srec|*.srec|*.s19|*.s19";
            file.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            file.Multiselect = false;

            if (file.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            this.textBox_VersionPath.Text = file.FileName;

            string strFullPath = AppDomain.CurrentDomain.BaseDirectory + "/" + m_strFilePath;
            if (File.Exists(strFullPath))
            {
                string strRead = File.ReadAllText(strFullPath);
                if (!strRead.Equals(file.FileName))
                {
                    File.WriteAllText(strFullPath, file.FileName);
                }
            }
            else
            {
                File.WriteAllText(strFullPath, file.FileName);
            }
        }
    }
}
