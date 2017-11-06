//          ▂▆██████████▇▄▁ 　
//　　　▁▆███████████████▅
//　　▃██████████████████▇　
//　▆████████████████████▌
//　████████　    三肿镇楼　    ▅███
//　███████▌　求不封号,求无BUG 　   ██
//　███████　　▃▇█▆▂　　▄█▅　▇█
//　█████　 　  ▂▄▄▄▄   ▄▄▄▄▄▄▕   
//▕▅　▂            █　    ▋    █▋　█　▕
//▕　　　　　　　　　█▆▄▆▊　　█▆▄▆  ▕
//▕▅　▂                                    ▕
//　█▁▁　　　　　　　　　　　▂　▂　　 　　▏
//　　▏　　　　　　　　　　　　　▂　　　　　▏
//　▃▅　　　　　　　　　　    ███　　    ▏ 
//  ██▆                       █  █       ▏
//  ██▆                        ███      ▏
//　██▆　　　　　　　　　　　　  　　　　╱　
//█████▅　　　　　　　　　　　　　　╱
//    ███▅                          ╱
//███████▁　▁▁▂▄▆▆▅╱
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using testdm;
using System.Threading;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using _File_Deling;
using System.Diagnostics;
using Dama2Lib;
using UUWiseCSWrapper;
using System.Drawing.Imaging;
using ACCOUNT;
using AccountService;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
//脚本密码 LOLengpc
namespace OneRoad_TOl
{
    public partial class Form1 : CCSkinMain
    {
        //注销、关机、重启
        [DllImport("user32.dll", EntryPoint = "ExitWindowsEx", CharSet = CharSet.Ansi)]
        private static extern int ExitWindowsEx(int uFlags, int dwReserved);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(7, 30, Width - 14, Height - 37));
            //Pen pen = new Pen(Color.FromArgb(100, 0, 0, 0), 1);
            //g.DrawRectangle(pen, new Rectangle(7, 30, Width - 14, Height - 37));
        }
        /// <summary>
        /// 判断开始执行脚本线程
        /// </summary>
        Thread Begin_Thread = null;
        /// <summary>
        /// 判断结束脚本线程
        /// </summary>
        Thread Stop_Thread = null;
        /// <summary>
        /// 延迟停止脚本
        /// </summary>
        Thread Delay_Stop_Thread = null;
        /// <summary>
        /// 判断结束脚本线程
        /// </summary>
        Thread HoleDeal_Thread = null;
        /// <summary>
        /// 启动脚本监听大漠
        /// </summary>
        CDmSoft ListemBeginDm = new CDmSoft();
        /// <summary>
        /// 启动脚本监听大漠
        /// </summary>
        CDmSoft ListemStopDm = new CDmSoft();
        /// <summary>
        /// 延迟停止脚本大漠
        /// </summary>
        CDmSoft ListemDelayStopDm = new CDmSoft();
        /// <summary>
        /// 全局工作大漠
        /// </summary>
        CDmSoft WorkDmDm = new CDmSoft();
        /// <summary>
        /// 主线程工作大漠
        /// </summary>
        CDmSoft Own_Dm = new CDmSoft();
        /// <summary>
        /// 登陆用大漠
        /// </summary>
        CDmSoft Login_Dm = new CDmSoft();
        /// <summary>
        /// 大厅用大漠
        /// </summary>
        CDmSoft Lobby_Dm = new CDmSoft();
        /// <summary>
        /// 游戏专用大漠对象
        /// </summary>
        CDmSoft Game_Dm = new CDmSoft();
        /// <summary>
        /// 不知名大漠对象
        /// </summary>
        CDmSoft Hown_dm = new CDmSoft();
        private void Form1_Load(object sender, EventArgs e)
        {
            //获取当前活动进程的模块名称
            string moduleName = Process.GetCurrentProcess().MainModule.ModuleName;
            //返回指定路径字符串的文件名
            string processName = System.IO.Path.GetFileNameWithoutExtension(moduleName);
            //根据文件名创建进程资源数组
            Process[] processes = Process.GetProcessesByName(processName);
            //如果该数组长度大于1，说明多次运行
            if (processes.Length > 1)
            {
                MessageBox.Show("本程序不可重复开启，可能是之前的软件进程还存在，请耐心等待几秒后重试", "中国战线", MessageBoxButtons.OK, MessageBoxIcon.Information);//弹出提示信息
                this.Close();//关闭当前窗体
            }
            try
            {
                ConFigTo_Form();
                Tex_Psd_Lg.Text = "请登陆软件以获取到期时间";
            }
            catch (System.Exception ex)
            {

            }
            //
            Btn_UpdusrLIST_Click(sender, e);
            //
            BeginTime = DateTime.Now;
            CDmSoft regdm = new CDmSoft();
            //int dm_ret = regdm.RegNoMac(DecodeStr("eXRL:]Lse=&AL1vQ+YesDnvRG]L3DnYQYsRV-V^Q+:&|DwL0G]K5{}Z%"), "0001");
            //if (dm_ret != 1)
            //{
            //    MessageBox.Show("辅助注册失败,返回值是：" + dm_ret.ToString());
            //    Environment.Exit(0);
            //}
            //启动脚本监听
            Begin_Thread = new Thread(Thread_Scripets_Begin);
            Begin_Thread.SetApartmentState(ApartmentState.MTA);
            Begin_Thread.Start();
            //停止脚本监听
            Stop_Thread = new Thread(Thread_Scripets_Stop);
            Stop_Thread.SetApartmentState(ApartmentState.MTA);
            Stop_Thread.Start();
            //延迟停止脚本监听
            Delay_Stop_Thread = new Thread(Thread_Scripets_Delay_Stop);
            Delay_Stop_Thread.SetApartmentState(ApartmentState.MTA);
            Delay_Stop_Thread.Start();
            //启动脚本主执行线程
            HoleDeal_Thread = new Thread(Scripets_Working);
            //
            //
            HeartBeat = new Thread(Thd_Rebind_Server);
            //
            //统治5个点识别坐标
            FiveTip[0] = "863,655,870,662";
            FiveTip[1] = "923,612,929,618";
            FiveTip[2] = "984,656,990,662";
            FiveTip[3] = "959,727,965,733";
            FiveTip[4] = "888,727,894,733";
            //统治5个点坐标点击方法
            GetFiveTip[0] = "866,659,520,398";
            GetFiveTip[1] = "926,615,523,419";
            GetFiveTip[2] = "986,658,547,427";
            GetFiveTip[3] = "961,729,534,431";
            GetFiveTip[4] = "890,729,544,437";
            //技能处理
            ResetSkillArrary();
            //逃跑路线
            RunaayZb[0] = "909,947,658,696";//统治战场逃跑位置

            RunaayZb[1] = "844,877,717,754";
            RunaayZb[2] = "974,1016,585,623";

            RunaayZb[3] = "837,849,673,683";//扭曲左边逃跑位置
            RunaayZb[4] = "1002,1013,672,683";//扭曲右边逃跑位置

            RunaayZb[5] = "862,873,724,737";//极地左下角逃跑位置
            RunaayZb[6] = "982,993,610,623";//极地左下角逃跑位置

            //英雄名字
            HeroName.Clear();
            HeroName.Add("Hero_Dm|0|2");
            HeroName.Add("Hero_Gh|2|0");
            HeroName.Add("Hero_Jj|0|2");
            HeroName.Add("Hero_Js|0|2");
            HeroName.Add("Hero_Ll|0|2");
            HeroName.Add("Hero_Nq|0|2");
            HeroName.Add("Hero_Ps|0|2");
            HeroName.Add("Hero_St|0|2");
            HeroName.Add("Hero_Wq|0|2");
            HeroName.Add("Hero_ZD|0|2");
            HeroName.Add("Hero_Zx|2|0");
            HeroName.Add("Hero_Hz|0|2");
            HeroName.Add("Hero_Nk|0|1");
            HeroName.Add("Hero_Ey|0|2");
            HeroName.Add("Hero_Wk|2|0");
            HeroName.Add("Hero_Jm|2|1");
            HeroName.Add("Hero_Gx|2|0");
            HeroName.Add("Hero_Ln|1|2");
            HeroName.Add("Hero_Md|1|0");
            HeroName.Add("Hero_Ms|0|2");
            HeroName.Add("Hero_Hl|0|2");
            HeroName.Add("Hero_Kz|0|2");
            HeroName.Add("Hero_Ng|0|1");
            HeroName.Add("Hero_Rw|0|1");
            HeroName.Add("Hero_Gt|2|0");
            HeroName.Add("Hero_Zm|0|1");
            HeroName.Add("Hero_Df|1|2");
            HeroName.Add("Hero_Ys|0|2");
            HeroName.Add("Hero_Gf|0|2");
            HeroName.Add("Hero_Tl|0|1");
            HeroName.Add("Hero_Nj|0|2");
            HeroName.Add("Hero_Rm|0|1");
            HeroName.Add("Hero_Rn|0|1");
            HeroName.Add("Hero_Xz|0|1");
            //召唤师技能
            ZhsSkill[0] = "498,220";
            ZhsSkill[1] = "574,217";
            ZhsSkill[2] = "653,222";
            ZhsSkill[3] = "731,221";
            ZhsSkill[4] = "807,217";
            ZhsSkill[5] = "493,317";
            ZhsSkill[6] = "579,318";
            ZhsSkill[7] = "652,311";
            ZhsSkill[8] = "731,312";
            ZhsSkill[9] = "810,313";
            ZhsSkill[10] = "499,412";
            ZhsSkill[11] = "574,407";
            //
            //设置日期
            Datetime_MissionTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            Datetime_MissionTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //
        }
        #region 大漠处理事件
        /// <summary>
        /// 大漠键盘按下弹起
        /// </summary>
        /// <param name="dm">大漠对象</param>
        /// <param name="KeyNume">键码</param>
        /// <param name="DelayTime">延迟</param>
        private void Zs_KeyD_U(CDmSoft dm, int KeyNume, int DelayTime)
        {
            dm.KeyDown(KeyNume);
            Delay(DelayTime);
            for (int kI = 0; kI < 2; kI++)
            {
                dm.KeyUp(KeyNume);
            }
        }
        /// <summary>
        /// 大漠键盘单击事件
        /// </summary>
        /// <param name="dm">大漠对象</param>
        /// <param name="KeyNume">键码</param>
        /// <param name="count">次数</param>
        private void Zs_KeyP(CDmSoft dm, int KeyNume, int count)
        {
            for (int i = 0; i < count; i++)
            {
                dm.KeyPress(KeyNume);
            }
        }
        /// <summary>
        /// 大漠移动 + 做键单击
        /// </summary>
        private void Zs_Move_Clk(CDmSoft dm, int moveX, int moveY, int DelayTime, int count)
        {
            for (int i = 0; i < count; i++)
            {
                dm.MoveTo(moveX, moveY);
                Delay(DelayTime);
                dm.LeftClick();
            }
        }
        /// <summary>
        /// 大漠移动 + 右键单击
        /// </summary>
        private void Zs_Move_R(CDmSoft dm, int moveX, int moveY, int DelayTime, int count)
        {
            for (int i = 0; i < count; i++)
            {
                dm.MoveTo(moveX, moveY);
                Delay(DelayTime);
                dm.RightClick();
            }
        }
        /// <summary>
        /// 大漠移动 + 左键双击
        /// </summary>
        private void Zs_Move_Dbl_L(CDmSoft dm, int moveX, int moveY, int DelayTime, int count)
        {
            for (int i = 0; i < count; i++)
            {
                dm.MoveTo(moveX, moveY);
                Delay(DelayTime);
                dm.LeftDoubleClick();
            }
        }
        #endregion

        #region 全局变量层
        /// <summary>
        /// 游戏路径
        /// </summary>
        private string Gamepath = "";
        /// <summary>
        /// 账号密码集合
        /// </summary>
        private List<string> Usermsg = new List<string>();
        /// <summary>
        /// 自动换号
        /// </summary>
        private bool OpenChangeUser = false;
        /// <summary>
        /// 召唤师峡谷人机
        /// </summary>
        private int Zhs_Rj_Class = 0;
        /// <summary>
        /// 统治人机
        /// </summary>
        private int Tz_Rj_Class = 0;
        /// <summary>
        /// 统治匹配
        /// </summary>
        private int Tz_Pp_Class = 0;
        /// <summary>
        /// 扭曲匹配
        /// </summary>
        private int Nq_Pp_Class = 0;
        /// <summary>
        /// 极地匹配
        /// </summary>
        private int Jd_Pp_Class = 0;
        /// <summary>
        /// 开启信息记录窗口
        /// </summary>
        private bool OpenCheckMsgWindow = false;
        /// <summary>
        /// Cpu降低程度
        /// </summary>
        private int Cpudown = 10;
        /// <summary>
        /// 脚本模式
        /// </summary>
        private int SoftMod = 0;
        /// <summary>
        /// 是否开启打码兔
        /// </summary>
        private bool OpenDm2 = false;
        /// <summary>
        /// 是否开启优优云
        /// </summary>
        private bool OpenUu = false;
        /// <summary>
        /// 是否开启大漠
        /// </summary>
        private bool OpenDm = false;
        /// <summary>
        /// 打码兔账号
        /// </summary>
        private string Dm2User = "";
        /// <summary>
        /// 打码兔密码
        /// </summary>
        private string Dm2Psd = "";
        /// <summary>
        /// 优优云账号
        /// </summary>
        private string UUuser = "";
        /// <summary>
        /// 优优云密码
        /// </summary>
        private string UUpsd = "";
        /// <summary>
        /// 大漠IP
        /// </summary>
        private string DMip = "";
        /// <summary>
        /// 出问题自动换大漠
        /// </summary>
        private bool ErrcgDm = false;
        /// <summary>
        /// 7级以后随机换图
        /// </summary>
        private bool SjcgMap = false;
        /// <summary>
        /// 换号时间
        /// </summary>
        private int CguserTime = 0;
        /// <summary>
        /// 是否有开启QQ监控
        /// </summary>
        private bool OpenQQsend = false;
        /// <summary>
        /// 本机备注
        /// </summary>
        private string MyBackUp = "";
        /// <summary>
        /// 发送数据对象
        /// </summary>
        private string Sendname = "";
        /// <summary>
        /// 是否开启中央监控
        /// </summary>
        private bool OpenZyjk = false;
        /// <summary>
        /// 主机IP地址
        /// </summary>
        private string HostIp = "";
        /// <summary>
        /// 主机端口号
        /// </summary>
        private string HostPott = "";
        /// <summary>
        /// 开启全场Carry模式
        /// </summary>
        private bool OpenTzCarry = false;
        /// <summary>
        /// 开启占塔模式(击杀小兵)
        /// </summary>
        private bool OpenStmod = false;
        /// <summary>
        /// 开启定时关机
        /// </summary>
        private bool OpenDsgj = false;
        /// <summary>
        /// 停止时间
        /// </summary>
        private string ExitTime = "";

        #endregion

        #region 全局定义层
        private string Fz_UpdNumber = "25";
        /// <summary>
        /// 首次登陆时候的产品号
        /// </summary> 
        private string loginpUD = "";
        /// <summary>
        /// 产品号
        /// </summary>
        private string Fz_Cph = "";
        /// <summary>
        /// 之前登陆的机器码
        /// </summary>
        private string FzMod = "0";//辅助形式，0为个人版，1为工作室版
        private string NowMecod2 = "";
        private string NowMecod = "";
        private string Fz_UserName = "";
        private string Fz_UserPsd = "";
        private bool IsVerify = false;
        private int CanVerifycOUNT = 0;
        private int MaxVerifyCount = 2;
        /// <summary>
        /// 机器码
        /// </summary>
        private string MechineCode = "";
        /// <summary>
        /// 被锁定的机器码
        /// </summary>
        private string LockMechineCode = "";
        /// <summary>
        /// 锁定机器码路径
        /// </summary>
        string LockMechineConfigPath = "C:\\LockMechineConfig.txt";
        //心跳线程初始化
        Thread HeartBeat = null;
        //加密相关
        private const string KEY2 = "wWnXh&\\|3>l)K\"fdIJEG8L?#O:@;.01Y']}7u_-p9b$tBHNc*q!/jP6y4CkzFog%iVS,=xQTa(+vAUMsemR^2[5<DZ{r";
        private const string KEY3 = "0123456789!@Q#WA$ESZ%RDX^TFC&YGV*UHB(IJN)OKM_PL<+{:>}\"?|/']\\.;[=,lp-mkonjibhuvgycftxdrzsewaq";
        /// <summary>
        /// 打码兔
        /// </summary>
        private uint ulVCodeID = 0;
        //UU云相关
        static int SoftID = 97650;
        static string SoftKey = "f2ddb5d765bf4b3f83f44ea3dbcbb248";
        private int codeType = 1004;
        private int m_codeID;
        /// <summary>
        /// 大区名字
        /// </summary>
        private string AreaName = "";
        /// <summary>
        /// 上第几个号
        /// </summary>
        private int LoginIndex = 0;
        /// <summary>
        /// 游戏执行模式
        /// </summary>
        private int GameMod = 0;
        /// <summary>
        /// 统治5点识别坐标
        /// </summary>
        private string[] FiveTip = new string[5];
        /// <summary>
        /// 要达到统治5点坐标的方法
        /// </summary>
        private string[] GetFiveTip = new string[5];
        /// <summary>
        /// 技能存放数组
        /// </summary>
        private int[] SkillAry = new int[4];
        /// <summary>
        /// 逃跑路线
        /// </summary>
        private string[] RunaayZb = new string[7];
        private int Tpzsx = 0;
        private int Tpzxy = 0;
        private int Tpyxx = 0;
        private int Tpyxy = 0;
        /// <summary>
        /// 召唤师技能
        /// </summary>
        private string[] ZhsSkill = new string[12];
        /// <summary>
        /// 上路防御塔
        /// </summary>
        private string[] S_FytFw = new string[6];
        /// <summary>
        /// 中路防御塔
        /// </summary>
        private string[] Z_FytFw = new string[6];
        /// <summary>
        /// 下路防御塔
        /// </summary>
        private string[] X_FytFw = new string[6];
        /// <summary>
        /// 扭曲_上路识别位置
        /// </summary>
        private string[] Nq_sb_Sl = new string[4];
        /// <summary>
        /// 扭曲_下路识别位置
        /// </summary>
        private string[] Nq_sb_Xl = new string[4];
        /// <summary>
        /// 极地识别位置
        /// </summary>
        private string[] Jd_Sb_road = new string[6];
        /// <summary>
        /// 召唤师峡谷路线选择
        /// </summary>
        private int RoadSelect = 0;
        /// <summary>
        /// 扭曲丛林路线选择
        /// </summary>
        private int RoadSelect_Nq = 0;
        /// <summary>
        /// 全局随机数种子
        /// </summary>
        private Random rad = new Random();
        /// <summary>
        /// 启动时间
        /// </summary>
        private DateTime BeginTime = DateTime.Now;
        /// <summary>
        /// 启动时间
        /// </summary>
        private DateTime ChangeUserTime = DateTime.Now;
        /// <summary>
        /// 总获得金币
        /// </summary>
        private int JbCount = 0;
        /// <summary>
        /// 总提升等级
        /// </summary>
        private int DjCount = 0;
        /// <summary>
        /// 总进行局数
        /// </summary>
        private int MatchCount = 0;
        /// <summary>
        /// 总胜利局数
        /// </summary>
        private int WinCount = 0;
        /// <summary>
        /// 总失败局数
        /// </summary>
        private int LoseCount = 0;
        /// <summary>
        /// 启动时等级
        /// </summary>
        private int BeginDj = 0;
        /// <summary>
        /// 启动时金币
        /// </summary>
        private int BeginJb = 0;
        /// <summary>
        /// 是否第一次启动
        /// </summary>
        private bool IsFirstBegin = true;
        /// <summary>
        /// 总共有多少号需要处理
        /// </summary>
        private int UserNumCount = 0;
        /// <summary>
        /// 任务完成的数量
        /// </summary>
        private int OverUserCount = 0;
        /// <summary>
        /// 游戏目标
        /// </summary>
        private int MBdealCase = 0;
        /// <summary>
        /// 目标数量
        /// </summary>
        private int MBcount = 0;
        /// <summary>
        /// 用于QQ监控发送的等级
        /// </summary>
        private string SendClass = "";
        /// <summary>
        /// 用于QQ监控发送的金币
        /// </summary>
        private string SendJb = "";
        /// <summary>
        /// 用于QQ监控目标
        /// </summary>
        private string SendMb = "";
        /// <summary>
        /// 用于QQ监控目标数量
        /// </summary>
        private string SendMbNum = "";
        /// <summary>
        /// 登录次数
        /// </summary>
        private int LoginNum = 0;
        #endregion

        #region 游戏相关方法
        /// <summary>
        /// 清理客户端
        /// </summary>
        private void ClearClient()
        {
            //删除游戏客户端下玩家的配置文件
            try
            {
                //路径一
                string DireactoryPath = SplitGamePath(Gamepath) + "Air\\preferences";
                //
                Directory.CreateDirectory(DireactoryPath);
                //
                DeletDireactory(DireactoryPath);
                //
                Directory.CreateDirectory(DireactoryPath);
                //路径二
                DireactoryPath = SplitGamePath(Gamepath) + "Cross\\Filecache";
                //
                Directory.CreateDirectory(DireactoryPath);
                //
                DeletDireactory(DireactoryPath);
                //
                Directory.CreateDirectory(DireactoryPath);

            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 删除文件夹下所有内容
        /// </summary>
        /// <param name="path"></param>
        private void DeletDireactory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    foreach (string deleteFile in Directory.GetFileSystemEntries(path))
                    {
                        if (File.Exists(deleteFile))
                            File.Delete(deleteFile);
                        else
                            DeleteFolder(deleteFile);
                    }
                    Directory.Delete(path);
                }
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 最后一次游戏时间写入文本
        /// </summary>
        private void WriteLastGame()
        {
            try
            {
                //
                File.Delete(Application.StartupPath + "\\config\\LastGameTime.txt");
                //
                TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + "\\config\\LastGameTime.txt", "write");
                //
                OverCheck.File_WriteFile(DateTime.Now.ToString() + "\r\n", "end");
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 随机填充技能数组
        /// </summary>
        private void ResetSkillArrary()
        {
            //技能处理
            SkillAry[0] = 0;
            SkillAry[1] = 0;
            SkillAry[2] = 0;
            SkillAry[3] = 0;
            List<int> Skilllist = new List<int>();
            Skilllist.Clear();
            Skilllist.Add(81);
            Skilllist.Add(87);
            Skilllist.Add(69);
            Skilllist.Add(82);
            for (int i = 0; i < 4; i++)
            {
                int getrad = Skilllist[rad.Next(0, 4)];
                bool getsame = false;
                while (true)
                {
                    getsame = false;
                    for (int j = 0; j < 4; j++)
                    {
                        if (getrad == SkillAry[j])
                        {
                            getsame = true;
                            getrad = Skilllist[rad.Next(0, 4)];
                            break;
                        }
                    }
                    if (!getsame)
                    {
                        break;
                    }
                }
                if (!getsame)
                {
                    SkillAry[i] = getrad;
                }
            }
        }
        /// <summary>
        /// 任务完成处理
        /// </summary>
        private void Missionover(string Usmsg, bool IsEnd)
        {
            //设置状态
            SetState("账号达到目标");
            //
            //整合大号文本路径
            string Bg_Path = "\\任务完成记录" + ".txt";
            //
            TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + Bg_Path, "write");
            //
            OverCheck.File_WriteFile(Usmsg + " 完成时间：" + System.DateTime.Now + "\r\n", "end");
            //
            if (IsEnd)
            {
                //
                //先杀死这些进程
                KillProcessByName("LolClient");
                KillProcessByName("lol.launcher_tencent");
                KillProcessByName("League of Legends");
                //
                MessageBox.Show("任务完成,请及时处理", "任务完成");
                //
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// 换号的处理
        /// </summary>
        private void CguserDoing(bool IsEnd)
        {
            //设置状态
            SetState("进入换号处理");
            //
            //先杀死这些进程
            KillProcessByName("LolClient");
            KillProcessByName("lol.launcher_tencent");
            KillProcessByName("League of Legends");
            //重置变量
            /// <summary>
            /// 是否第一次启动
            /// </summary>
            IsFirstBegin = true;
            /// <summary>
            /// 总获得金币
            /// </summary>
            JbCount = 0;
            /// <summary>
            /// 总提升等级
            /// </summary>
            DjCount = 0;
            /// <summary>
            /// 总进行局数
            /// </summary>
            MatchCount = 0;
            /// <summary>
            /// 总胜利局数
            /// </summary>
            WinCount = 0;
            /// <summary>
            /// 总失败局数
            /// </summary>
            LoseCount = 0;
            /// <summary>
            /// 启动时等级
            /// </summary>
            BeginDj = 0;
            /// <summary>
            /// 启动时金币
            /// </summary>
            BeginJb = 0;
            /// <summary>
            /// 任务完成的数量
            /// </summary>
            OverUserCount = 0;
            //
            BeginTime = DateTime.Now;
            //
            if (LoginIndex != UserNumCount - 1)
            {
                LoginIndex++;
            }
            else
            {
                if (IsEnd)
                {
                    //
                    MessageBox.Show("任务完成,请及时处理", "任务完成");
                    //
                    Environment.Exit(0);
                }
                else
                {
                    LoginIndex = 0;
                }
            }
            //
            //数据信息获取
            this.Invoke(new Action(() =>
            {
                Tex_NowDeal.Text = (LoginIndex + 1).ToString();
            }));
            //
            Delay(2000);
        }
        /// <summary>
        /// 验证码处理方法
        /// </summary>
        private string Verification_code(CDmSoft dm, int CutX, int CutY, int CutZ, int CutW)
        {
            int dm_ret = 0;
            string VerPath = ".\\Jt.bmp";
            string VeriFiPath = ".\\attachment\\Jt.bmp";
            dm_ret = dm.Capture(CutX, CutY, CutZ, CutW, VerPath);
            Delay(10);
            string Answer = "";
            if (OpenDm2)
            {
                StringBuilder VCodeText = new StringBuilder(100);
                int ret = Dama2.D2File(
                    "93375314cc361cf56a76925467a7c2fc", //softawre key (software id)
                    Dm2User,//user name
                    Dm2Psd,//password
                    VeriFiPath,
                    30,
                    32,
                    VCodeText);
                if (ret > 0)
                {
                    ulVCodeID = (uint)ret;
                    Answer = VCodeText.ToString();
                }
                else
                {
                    switch (ret)
                    {
                        case -101:
                            MessageBox.Show("打码兔【余额不足】", "提示");
                            break;
                        case -102:
                            MessageBox.Show("打码兔【用户名不存在】", "提示");
                            break;
                        case -103:
                            MessageBox.Show("打码兔【密码错误】", "提示");
                            break;
                        default:
                            //如果不存在以上三种错误，就把其他错误写入文本方便查看
                            TwoColor_File_Deling FileDeling = new TwoColor_File_Deling(".\\DM2ErrorConfig.txt", "write");
                            DateTime Sdata = DateTime.Now;
                            string InsertStr = "时间:" + Sdata.ToString() + " - 错误码:" + ret.ToString();
                            FileDeling.File_WriteFile(InsertStr + "\r\n", "end");
                            if (ErrcgDm)
                            {
                                OpenDm2 = false;
                                OpenDm = true;
                            }
                            break;
                    }
                }
            }
            else if (OpenDm)
            {
                int handle = dm.FaqCapture(CutX, CutY, CutZ, CutW, 50, 0, 0);
                string result = dm.FaqSend(DMip, handle, 2, 80 * 1000);
                string[] resultSplit = result.Split(':');
                if (resultSplit[1] == "123")
                {
                }
                else
                {
                    Answer = resultSplit[1].ToString();
                }
            }
            else if (OpenUu)
            {
                Wrapper.uu_setSoftInfo(SoftID, SoftKey);
                //
                /*	优优云DLL 文件MD5值校验
                 *  用处：近期有不法份子采用替换优优云官方dll文件的方式，极大的破坏了开发者的利益
                 *  用户使用替换过的DLL打码，导致开发者分成变成别人的，利益受损，
                 *  所以建议所有开发者在软件里面增加校验官方MD5值的函数
                 *  如何获取文件的MD5值，通过下面的GetFileMD5(文件)函数即返回文件MD5
                 */
                string DLLPath = System.Environment.CurrentDirectory + "\\UUWiseHelper.dll";
                string Md5 = GetFileMD5(DLLPath);
                string u = UUuser;
                string p = UUpsd;
                int res = Wrapper.uu_login(u, p);
                //
                if (res > 0)
                {
                    //下面是软件id对应的dll校验key。在开发者后台-我的软件里面可以查的到。
                    string strCheckKey = "5A5F77BF-99E5-40AC-A82C-F7E857EC99CB".ToUpper();
                    Image img = null;
                    if (!string.IsNullOrEmpty(VeriFiPath))
                    {
                        img = Image.FromFile(VeriFiPath);
                        //
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        MemoryStream ms = new MemoryStream();
                        img.Save(ms, ImageFormat.Jpeg);
                        byte[] buffer = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(buffer, 0, buffer.Length);
                        ms.Flush();
                        //新版本dll需要预先分配50个字节的空间，否则dll会崩溃！！！！
                        StringBuilder res2 = new StringBuilder(50);
                        int codeId = Wrapper.uu_recognizeByCodeTypeAndBytes(buffer, buffer.Length, codeType, res2);
                        string resultCode = CheckResult(res2.ToString(), SoftID, codeId, strCheckKey);
                        m_codeID = codeId;
                        if (resultCode != "结果校验不正确")
                        {
                            Answer = resultCode.ToString();
                        }
                        ms.Close();
                        ms.Dispose();
                        img.Dispose();
                        sw.Stop();
                    }
                }
                else
                {
                    if (ErrcgDm)
                    {
                        OpenUu = false;
                        OpenDm = true;
                    }
                    else
                    {
                        MessageBox.Show("优优云登陆失败,错误码:" + res.ToString());
                    }
                }
            }
            try
            {
                File.Delete(VeriFiPath);
            }
            catch (System.Exception ex)
            {

            }
            return Answer;
        }
        /// <summary>
        /// 刷新窗口
        /// </summary>
        /// <param name="dm">大漠对象</param>
        /// <param name="Hwnd">窗口句柄</param>
        private void UpdateWindow(CDmSoft dm, int Hwnd)
        {
            //大漠通用
            object intX, intY;
            int dm_ret = 0;
            //**************刷新窗口*****************
            dm_ret = dm.SetWindowState(Hwnd, 2);
            Delay(100);
            for (int i = 0; i < 3; i++)
                dm_ret = dm.SetWindowState(Hwnd, 1);
            //**************刷新窗口*****************
        }
        /// <summary>
        /// 进入下一个点
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="tipindex"></param>
        private bool GotGetTip(CDmSoft dm, int tipindex, out bool IsRedtip)
        {
            IsRedtip = false;
            //设置状态
            SetState("前往 " + (tipindex + 1) + " 号据点中");
            if (OpenTzCarry)
            {
                object intX, intY;
                int dm_ret = 0;
                //如果这个点已经被占领，就不前往
                int Lx = int.Parse(FiveTip[(int)Roaltip[tipindex]].Split(',')[0]);
                int Ly = int.Parse(FiveTip[(int)Roaltip[tipindex]].Split(',')[1]);
                int Rx = int.Parse(FiveTip[(int)Roaltip[tipindex]].Split(',')[2]);
                int Ry = int.Parse(FiveTip[(int)Roaltip[tipindex]].Split(',')[3]);
                Delay(5);
                dm_ret = dm.FindColor(Lx, Ly, Rx, Ry, "ff0000-030303", 0.9, 0, out intX, out intY);
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState((tipindex + 1) + " 号据点安全，前往");
                    //
                    IsRedtip = true;
                }
                else
                {
                    //内围没有发现红色
                    Delay(5);
                    dm_ret = dm.FindColor(Lx - 10, Ly - 10, Rx + 10, Ry + 10, "ff0000-030303", 0.9, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        Delay(5);
                        dm_ret = dm.FindColor(Lx - 10, Ly - 10, Rx + 10, Ry + 10, "32a5cf-101010|0299df-010101", 0.9, 0, out intX, out intY);
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState((tipindex + 1) + " 号据点杀过去殴打");
                        }
                        else
                        {
                            //设置状态
                            SetState((tipindex + 1) + " 号据点不安全，不去");
                            //外围发现红色
                            return false;
                        }
                    }
                }
            }
            if (OpenTzCarry)
            {
                //
                Zs_Move_Clk(dm, int.Parse(GetFiveTip[tipindex].Split(',')[0]) + rad.Next(-1, 2), int.Parse(GetFiveTip[tipindex].Split(',')[1]) + rad.Next(-1, 2), 100, 1);
                Delay(rad.Next(100, 400));
                Zs_Move_R(dm, int.Parse(GetFiveTip[tipindex].Split(',')[2]) + rad.Next(-1, 2), int.Parse(GetFiveTip[tipindex].Split(',')[3]) + rad.Next(-1, 2), 100, 1);
                Delay(rad.Next(300, 700));
            }
            else
            {
                //
                Zs_Move_Clk(dm, int.Parse(GetFiveTip[tipindex].Split(',')[0]) + rad.Next(-1, 2), int.Parse(GetFiveTip[tipindex].Split(',')[1]) + rad.Next(-1, 2), 100, 1);
                Delay(rad.Next(300, 700));
                Zs_Move_R(dm, int.Parse(GetFiveTip[tipindex].Split(',')[2]) + rad.Next(-1, 2), int.Parse(GetFiveTip[tipindex].Split(',')[3]) + rad.Next(-1, 2), 100, 1);
                Delay(rad.Next(1000, 2000));
            }
            return true;
        }
        /// <summary>
        /// 检测顺序的动态数组
        /// </summary>
        ArrayList Roaltip = new ArrayList();
        /// <summary>
        /// 检测要达到的点
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        private int CheckCanGetTip(CDmSoft dm, out bool IsRedtip)
        {
            IsRedtip = false;
            //设置状态
            SetState("搜寻可占领点");
            //
            bool getsame = false;
            //随机检测顺序
            Roaltip.Clear();
            for (int i = 0; i < 5; i++)
            {
                Roaltip.Add(-1);
            }
            for (int i = 0; i < 5; i++)
            {
                int gettip = rad.Next(0, 5);
                while (true)
                {
                    getsame = false;
                    foreach (int tp in Roaltip)
                    {
                        if (gettip == tp)
                        {
                            getsame = true;
                            break;
                        }
                    }
                    if (getsame)
                    {
                        gettip = rad.Next(0, 5);
                    }
                    else
                    {
                        break;
                    }
                }
                Roaltip[i] = gettip;
            }
            object intX, intY;
            int dm_ret = 0;
            int ReturnTip = -1;
            int ClickCount = 0;
            //识别顺序得到以后
            for (int i = 0; i < 5; i++)
            {
                int Lx = int.Parse(FiveTip[(int)Roaltip[i]].Split(',')[0]);
                int Ly = int.Parse(FiveTip[(int)Roaltip[i]].Split(',')[1]);
                int Rx = int.Parse(FiveTip[(int)Roaltip[i]].Split(',')[2]);
                int Ry = int.Parse(FiveTip[(int)Roaltip[i]].Split(',')[3]);
                Delay(10);
                dm_ret = dm.FindColor(Lx, Ly, Rx, Ry, "ff0000-030303", 0.9, 0, out intX, out intY);
                if ((int)intX > 0)
                {
                    if (ReturnTip == -1)
                    {
                        IsRedtip = true;
                        ReturnTip = (int)Roaltip[i];
                    }
                    Zs_KeyP(dm, 71, 1);
                    Delay(10);
                    Zs_Move_Clk(dm, int.Parse(GetFiveTip[(int)Roaltip[i]].Split(',')[0]) + rad.Next(-10, 20), int.Parse(GetFiveTip[(int)Roaltip[i]].Split(',')[1]) + rad.Next(-10, 20), 100, 1);
                    ClickCount++;
                    if (ClickCount >= rad.Next(0, 5))
                    {
                        break;
                    }
                }
            }
            if (ReturnTip == -1)
            {
                ClickCount = 0;
                //识别顺序得到以后
                for (int i = 0; i < 5; i++)
                {
                    int Lx = int.Parse(FiveTip[(int)Roaltip[i]].Split(',')[0]);
                    int Ly = int.Parse(FiveTip[(int)Roaltip[i]].Split(',')[1]);
                    int Rx = int.Parse(FiveTip[(int)Roaltip[i]].Split(',')[2]);
                    int Ry = int.Parse(FiveTip[(int)Roaltip[i]].Split(',')[3]);
                    Delay(10);
                    dm_ret = dm.FindColor(Lx, Ly, Rx, Ry, "808080-010101", 0.9, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        if (ReturnTip == -1)
                        {
                            ReturnTip = (int)Roaltip[i];
                        }
                        Zs_KeyP(dm, 71, 1);
                        Delay(10);
                        Zs_Move_Clk(dm, int.Parse(GetFiveTip[(int)Roaltip[i]].Split(',')[0]) + rad.Next(-10, 20), int.Parse(GetFiveTip[(int)Roaltip[i]].Split(',')[1]) + rad.Next(-10, 20), 100, 1);
                        ClickCount++;
                        if (ClickCount >= rad.Next(0, 5))
                        {
                            break;
                        }
                    }
                }
            }
            return ReturnTip;
        }
        /// <summary>
        /// 扭曲丛林逃跑方法
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        private void TaoPao_Nq(CDmSoft dm, int zy)
        {
            try
            {
                Zs_KeyP(dm, 32, rad.Next(1, 3));
                Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                Delay(100);
                dm.MoveTo(493, 367);
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 召唤师峡谷逃跑方法
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        private void TaoPao(CDmSoft dm, int zy)
        {
            Zs_KeyP(dm, 32, rad.Next(1, 3));
            if (zy == 2)
            {
                if (RoadSelect == 0)//上路
                {
                    Zs_Move_R(dm, rad.Next(841, 864), rad.Next(703, 723), 30, rad.Next(1, 4));
                    Delay(100);
                }
                else if (RoadSelect == 1)//中路
                {
                    Zs_Move_R(dm, rad.Next(869, 894), rad.Next(708, 729), 30, rad.Next(1, 4));
                    Delay(100);
                }
                else
                {
                    Zs_Move_R(dm, rad.Next(876, 900), rad.Next(742, 759), 30, rad.Next(1, 4));
                    Delay(100);
                }
            }
            else
            {
                if (RoadSelect == 0)//上路
                {
                    Zs_Move_R(dm, rad.Next(969, 987), rad.Next(584, 599), 30, rad.Next(1, 4));
                    Delay(100);
                }
                else if (RoadSelect == 1)//中路
                {
                    Zs_Move_R(dm, rad.Next(976, 989), rad.Next(615, 627), 30, rad.Next(1, 4));
                    Delay(100);
                }
                else
                {
                    Zs_Move_R(dm, rad.Next(1005, 1016), rad.Next(620, 632), 30, rad.Next(1, 4));
                    Delay(100);
                }
            }
            dm.MoveTo(493, 367);
        }
        /// <summary>
        /// 回城
        /// </summary>
        /// <param name="dm"></param>
        private bool GoHome(CDmSoft dm)
        {
            //
            object intX, intY;
            int dm_ret = 0;
            DateTime gohometime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            while (true)
            {
                dm.UseDict(0);
                string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                if (isdead != "")
                {
                    break;
                }
                if ((int)GetCoadDoIngTime(false, gohometime) >= 30 * 1000)//15秒超时
                {
                    break;
                }
                bool IsFindArmy = false;
                Delay(rad.Next(20, 50));
                //看看有没有敌方小兵
                dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("逗比，补完血来干死你");
                    //
                    //往地图中间逃
                    Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                    IsFindArmy = true;
                    Zs_KeyP(dm, 32, rad.Next(1, 4));
                }
                //判断是否有敌方英雄
                Delay(rad.Next(20, 50));
                dm_ret = dm.FindPic(211, 26, 811, 655, "Garmy_1.bmp|Garmy_2.bmp|Garmy_3.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("大爷别追了，我要屎了");
                    //
                    //往地图中间逃
                    Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                    IsFindArmy = true;
                    Zs_KeyP(dm, 32, rad.Next(1, 4));
                }
                if (!IsFindArmy)
                {
                    Delay(50);
                    dm_ret = dm.FindPic(361, 593, 662, 614, "ghome_1.bmp", "000000", 0.8, 0, out intX, out intY);//回城处理
                    if ((int)intX > 0)
                    {
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 32, rad.Next(1, 4));
                        Delay(500);
                    }
                    else
                    {
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 66, 1);
                        Delay(100);
                        Zs_KeyP(dm, 32, rad.Next(1, 4));
                        Delay(300);
                    }
                }
                if (GameMod == 0)
                {
                    Delay(50);
                    dm_ret = dm.FindPic(834, 728, 872, 765, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp", "000000", 0.8, 0, out intX, out intY);//判断是否到家
                    if ((int)intX > 0)
                    {
                        return true;
                    }
                    Delay(50);
                    dm_ret = dm.FindPic(987, 577, 1022, 621, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//判断是否到家
                    if ((int)intX > 0)
                    {
                        return true;
                    }
                }
                else if (GameMod == 1 || GameMod == 2)
                {
                    Delay(50);
                    dm_ret = dm.FindPic(834, 675, 871, 732, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//判断是否到家
                    if ((int)intX > 0)
                    {
                        return true;
                    }
                    Delay(50);
                    dm_ret = dm.FindPic(980, 670, 1019, 731, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//判断是否到家
                    if ((int)intX > 0)
                    {
                        return true;
                    }
                }
                else if (GameMod == 3)
                {
                    Delay(50);
                    dm_ret = dm.FindPic(831, 640, 879, 700, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//左边阵营
                    if ((int)intX > 0)
                    {
                        return true;
                    }
                    Delay(50);
                    dm_ret = dm.FindPic(977, 650, 1022, 697, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//右边阵营
                    if ((int)intX > 0)
                    {
                        return true;
                    }
                }
                Delay(50);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(50);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(50);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(50);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 1);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(50);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(50);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
            }
            return false;
        }
        /// <summary>
        /// 装备购买
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        private bool GetShopSomething_Tz(CDmSoft dm)
        {
            //设置状态
            SetState("进入商店购物");
            //
            object intX, intY;
            int dm_ret = 0;
            Delay(20);
            bool OpenShop = false;
            DateTime GameStilLTime = DateTime.Now;
            while (true)
            {
                if ((int)GetCoadDoIngTime(false, GameStilLTime) >= 30 * 1000)//30秒超时
                {
                    break;
                }
                Delay(100);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 1);
                    Delay(50);
                    dm.MoveTo(0, 0);
                }
                Delay(100);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(100);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(100);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(100);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return false;
                }
                if (!OpenShop)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                    if ((int)intX > 0)
                    {
                        OpenShop = true;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(369, 101, 600, 212, "Sd_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                    if ((int)intX > 0)
                    {
                        OpenShop = true;
                    }
                }
                else
                {
                    Zs_Move_Clk(dm, 230, 114, 100, rad.Next(1, 3));
                    Delay(rad.Next(50, 300));
                    Zs_Move_Clk(dm, 524, 112, 100, rad.Next(1, 3));
                    Delay(rad.Next(50, 300));
                    //发现商店打开
                    //查找第一个位置是否购买
                    Delay(20);
                    dm_ret = dm.FindPic(132, 664, 172, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第1个位置为空
                    if ((int)intX > 0)
                    {
                        //买第1个推荐装备
                        Zs_Move_Clk(dm, 159 + rad.Next(-5, 5), 333 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(173, 664, 213, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第2个位置为空
                    if ((int)intX > 0)
                    {
                        //买第2个推荐装备
                        Zs_Move_Clk(dm, 219 + rad.Next(-5, 5), 335 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(214, 664, 254, 704, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第3个位置为空
                    if ((int)intX > 0)
                    {
                        //买第3个推荐装备
                        Zs_Move_Clk(dm, 162 + rad.Next(-5, 5), 429 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(256, 664, 295, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第4个位置为空
                    if ((int)intX > 0)
                    {
                        //买第4个推荐装备
                        Zs_Move_Clk(dm, 158 + rad.Next(-5, 5), 527 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(297, 664, 337, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第5个位置为空
                    if ((int)intX > 0)
                    {
                        //买第5个推荐装备
                        Zs_Move_Clk(dm, 216 + rad.Next(-5, 5), 430 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(338, 664, 378, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第6个位置为空
                    if ((int)intX > 0)
                    {
                        //买第6个推荐装备
                        Zs_Move_Clk(dm, 280 + rad.Next(-5, 5), 430 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                }
            }
            while (true)
            {
                Delay(1000);
                dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                if ((int)intX > 0)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                }
                Delay(100);
                dm_ret = dm.FindPic(369, 101, 600, 212, "Sd_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                if ((int)intX > 0)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                }
                else
                {
                    return true;
                }
                Delay(100);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(100);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(100);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(100);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(100);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
            }
        }
        /// <summary>
        /// 装备购买
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        private bool GetShopSomething_Zh(CDmSoft dm)
        {
            //设置状态
            SetState("进入商店购物");
            //
            object intX, intY;
            int dm_ret = 0;
            Delay(20);
            bool OpenShop = false;
            DateTime GameStilLTime = DateTime.Now;
            while (true)
            {
                if ((int)GetCoadDoIngTime(false, GameStilLTime) >= 30 * 1000)//30秒超时
                {
                    break;
                }
                Delay(100);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 1);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(100);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(100);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(100);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(100);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return false;
                }
                if (!OpenShop)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                    if ((int)intX > 0)
                    {
                        OpenShop = true;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(369, 101, 600, 212, "Sd_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                    if ((int)intX > 0)
                    {
                        OpenShop = true;
                    }
                }
                else
                {
                    Zs_Move_Clk(dm, 230, 114, 100, rad.Next(1, 3));
                    Delay(rad.Next(50, 300));
                    Zs_Move_Clk(dm, 524, 112, 100, rad.Next(1, 3));
                    Delay(rad.Next(50, 300));
                    //发现商店打开
                    //查找第一个位置是否购买
                    Delay(20);
                    dm_ret = dm.FindPic(132, 664, 172, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第1个位置为空
                    if ((int)intX > 0)
                    {
                        //买第1个推荐装备
                        Zs_Move_Clk(dm, 159 + rad.Next(-5, 5), 238 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(173, 664, 213, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第2个位置为空
                    if ((int)intX > 0)
                    {
                        //买第2个推荐装备
                        Zs_Move_Clk(dm, 160 + rad.Next(-5, 5), 333 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(214, 664, 254, 704, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第3个位置为空
                    if ((int)intX > 0)
                    {
                        //买第3个推荐装备
                        Zs_Move_Clk(dm, 219 + rad.Next(-5, 5), 335 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(256, 664, 295, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第4个位置为空
                    if ((int)intX > 0)
                    {
                        //买第4个推荐装备
                        Zs_Move_Clk(dm, 160 + rad.Next(-5, 5), 428 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(297, 664, 337, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第5个位置为空
                    if ((int)intX > 0)
                    {
                        //买第5个推荐装备
                        Zs_Move_Clk(dm, 217 + rad.Next(-5, 5), 429 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                    Delay(20);
                    dm_ret = dm.FindPic(338, 664, 378, 703, "ZbK_1.bmp", "000000", 0.8, 0, out intX, out intY);//第6个位置为空
                    if ((int)intX > 0)
                    {
                        //买第6个推荐装备
                        Zs_Move_Clk(dm, 280 + rad.Next(-5, 5), 430 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        Delay(rad.Next(50, 300));
                        Zs_Move_Clk(dm, 883 + rad.Next(-5, 5), 474 + rad.Next(-5, 5), 100, rad.Next(1, 2));
                        break;
                    }
                }
            }
            while (true)
            {
                Delay(1000);
                dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                if ((int)intX > 0)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                }
                Delay(100);
                dm_ret = dm.FindPic(369, 101, 600, 212, "Sd_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                if ((int)intX > 0)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                }
                else
                {
                    return true;
                }
                Delay(100);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(100);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return false;
                }
                Delay(100);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(100);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(100);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
            }
        }
        /// <summary>
        /// 血量检查
        /// </summary>
        /// <param name="dm"></param>
        private bool BloodCheck(CDmSoft dm)
        {
            object intX, intY;
            int dm_ret = 0;
            Delay(20);
            dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
            if ((int)intX > 0)
            {
                Zs_Move_Clk(dm, 615, 472, 200, 2);
                Delay(100);
                dm.MoveTo(0, 0);
            }
            Delay(20);
            dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
            if ((int)intX > 0)
            {
                Zs_Move_Clk(dm, 945, 69, 200, 2);
                Delay(100);
                dm.MoveTo(0, 0);
                Delay(100);
            }
            Delay(20);
            dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
            if ((int)intX > 0)
            {
                Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                Delay(100);
                dm.MoveTo(0, 0);
            }
            Delay(20);
            dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
            if ((int)intX > 0)
            {
                return false;
            }
            Delay(20);
            dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
            if ((int)intX > 0)
            {
                return false;
            }
            Delay(20);
            dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
            if ((int)intX > 0)
            {
                return false;
            }
            //检查是否已经死亡
            dm.UseDict(0);
            string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
            if (isdead != "")
            {
                return false;
            }
            bool LessBlood = false;
            if (OpenCheckMsgWindow)
            {
                if (dm.CmpColor(465, 738, "010604-000000", 0.8) == 0 && dm.CmpColor(465, 737, "010704-000000", 0.8) == 0)
                {
                    LessBlood = true;
                }
            }
            else
            {
                dm.UseDict(1);
                Delay(20);
                string Nowblood = dm.Ocr(447, 732, 608, 745, "c8c8c8-303030|c5c5c5-404040", 0.9);
                if (Nowblood != "")
                {
                    try
                    {
                        int MaxBlood = int.Parse(Nowblood.Split('/')[1]);
                        int NowBlood = int.Parse(Nowblood.Split('/')[0]);
                        if (NowBlood < 300)
                        {
                            LessBlood = true;
                        }
                    }
                    catch (System.Exception ex)
                    {

                    }
                }
            }
            if (LessBlood)
            {
                Zs_KeyP(dm, 32, rad.Next(1, 3));
                //设置状态
                SetState("贫血中，开始跑路");
                //
                Delay(100);
                dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_3.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                if ((int)intX > 0)
                {
                    //往地图中间逃
                    Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                    Delay(1000);
                    while (true)
                    {
                        Delay(100);
                        dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_3.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                        if ((int)intX > 0)
                        {
                            //往地图中间逃
                            Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                            Delay(1000);
                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                        }
                        else
                        {
                            break;
                        }
                    }
                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 打乱集合内的元素(本方法以string集合为例，可以延伸出其他集合)
        /// </summary>
        /// <param name="StrList">被打乱的集合（List)</param>
        private void DisorganizeList(ref List<string> StrList)
        {
            Random rad = new Random();
            List<string> newlist = new List<string>();
            newlist.Clear();
            bool havesame = false;
            for (int i = 0; i < StrList.Count; i++)
            {
                int getindex = 0;
                while (true)
                {
                    havesame = false;
                    getindex = rad.Next(0, StrList.Count);
                    foreach (string str in newlist)
                    {
                        if (str == StrList[getindex])
                        {
                            havesame = true;
                            break;
                        }
                    }
                    if (!havesame)
                    {
                        break;
                    }
                }
                newlist.Add(StrList[getindex]);
            }
            StrList = newlist;
        }
        /// <summary>
        /// 英雄技能副加什么 0-副Q 1-副W 2-副E
        /// </summary>
        private int HeroSkillFadd = 1;
        /// <summary>
        /// 英雄技能主加什么 0-主Q 1-主W 2-主E
        /// </summary>
        private int HeroSkillZadd = 0;
        /// <summary>
        /// 英雄名字数组
        /// </summary>
        private List<string> HeroName = new List<string>();
        /// <summary>
        /// 秒选英雄
        /// </summary>
        /// <param name="dm"></param>
        private bool SelectHero(CDmSoft dm)
        {
            //
            try
            {
                DisorganizeList(ref HeroName);
                ArrayList alreadyget = new ArrayList();
                object intX, intY;
                int dm_ret = 0;
                for (int i = 0; i < HeroName.Count; i++)
                {
                    int index = rad.Next(0, HeroName.Count);
                    string HeroNameGet = HeroName[index].Split('|')[0];
                    string HeroSkillZaddStr = HeroName[index].Split('|')[1];
                    string HeroSkillFaddStr = HeroName[index].Split('|')[2];
                    Delay(10);
                    dm_ret = dm.FindPic(281, 166, 986, 439, HeroNameGet + ".bmp", "000000", 0.8, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 300, 1);
                        Delay(1000);
                        alreadyget.Clear();
                        HeroSkillZadd = int.Parse(HeroSkillZaddStr);
                        HeroSkillFadd = int.Parse(HeroSkillFaddStr);
                        return true;
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return false;
        }
        /// <summary>
        /// 击杀小兵方法
        /// </summary>
        /// <param name="dm"></param>
        private bool KillDfXb(CDmSoft dm)
        {
            Zs_KeyP(dm, 32, rad.Next(1, 3));
            //
            object intX, intY;
            int dm_ret = 0;
            DateTime killouttime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            bool LessBlood = false;
            int Findxbcount = 0;
            bool IsgettinT = false;
            while (true)
            {
                IsgettinT = false;
                Delay(5);
                dm_ret = dm.FindPic(362, 594, 664, 615, "GetFYT_1.bmp|GetFYT_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现在占领防御塔
                if ((int)intX > 0)
                {
                    IsgettinT = true;
                }
                Delay(5);
                dm_ret = dm.FindPic(433, 563, 601, 603, "Zzzl_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现在占领防御塔
                if ((int)intX > 0)
                {
                    IsgettinT = true;
                }
                if (IsgettinT)
                {
                    break;
                }
                Delay(5);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    return true;
                }
                Delay(5);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(5);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(5);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(5);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return true;
                }
                Delay(5);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return true;
                }
                dm.UseDict(0);
                string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                if (isdead != "")
                {
                    return true;
                }
                Delay(rad.Next(10, 30));
                LessBlood = false;
                if (!OpenCheckMsgWindow)
                {
                    dm.UseDict(1);
                    string Nowblood = dm.Ocr(447, 732, 608, 745, "c8c8c8-303030|c5c5c5-404040", 0.9);
                    if (Nowblood != "")
                    {
                        try
                        {
                            int MaxBlood = int.Parse(Nowblood.Split('/')[1]);
                            int NowBlood = int.Parse(Nowblood.Split('/')[0]);
                            if (NowBlood < 300)
                            {
                                //失血过多
                                LessBlood = true;
                            }
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }
                }
                else
                {
                    if (dm.CmpColor(465, 738, "010604-000000", 0.8) == 0 && dm.CmpColor(465, 737, "010704-000000", 0.8) == 0)
                    {
                        LessBlood = true;
                    }
                }
                if (!LessBlood)
                {
                    Delay(5);
                    //看看有没有敌方小兵
                    dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                    if ((int)intX > 0)
                    {
                        Findxbcount++;
                        if (Findxbcount >= 2)
                        {
                            Findxbcount = 0;
                            //
                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                            //
                        }
                        int Dfxbx = (int)intX;
                        int Dfxby = (int)intY;
                        //看看有没有我方小兵
                        dm_ret = dm.FindPic(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现我方小兵
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("猛烈殴打敌方小兵中");
                            Zs_KeyP(dm, 65, rad.Next(1, 3));
                            Delay(rad.Next(10, 30));
                            Zs_Move_Clk(dm, (int)intX + rad.Next(-5, 5), (int)intY + rad.Next(-5, 5), rad.Next(10, 30), 1);
                            Zs_KeyP(dm, 65, rad.Next(1, 3));
                            Delay(rad.Next(10, 30));
                            Zs_Move_Clk(dm, Dfxbx + rad.Next(-5, 5), Dfxby + rad.Next(-5, 5), rad.Next(10, 30), rad.Next(1, 4));
                            Delay(rad.Next(10, 30));
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        //设置状态
                        SetState("艾玛，失血过多");
                        //
                        //往地图中间逃
                        Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                        //
                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                        //
                    }
                    Delay(5);
                    dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_3.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                    if ((int)intX > 0)
                    {
                        return false;
                    }
                }
                if ((int)GetCoadDoIngTime(false, killouttime) >= 20 * 1000)//10秒超时
                {
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// 判断主动技能
        /// </summary>
        /// <param name="dm"></param>
        private void CheckZdSkill(CDmSoft dm)
        {
            //1号点有主动技能
            if (dm.CmpColor(135, 679, "05c501-020202", 0.9) == 0)
            {
                //
                Zs_KeyP(dm, 49, rad.Next(1, 3));
                //
            }
            //2号点有主动技能
            if (dm.CmpColor(170, 679, "05c501-020202", 0.9) == 0)
            {
                //
                Zs_KeyP(dm, 50, rad.Next(1, 3));
                //
            }
            //3号点有主动技能
            if (dm.CmpColor(201, 679, "05c501-020202", 0.9) == 0)
            {
                //
                Zs_KeyP(dm, 51, rad.Next(1, 3));
                //
            }
            //4号点有主动技能
            if (dm.CmpColor(141, 710, "05c501-020202", 0.9) == 0)
            {
                //
                Zs_KeyP(dm, 52, rad.Next(1, 3));
                //
            }
        }
        /// <summary>
        /// 通用击杀敌方英雄方法
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="DFyxx"></param>
        /// <param name="DFyxy"></param>
        private bool KillDfyx_Normal_NoCheckBlood(CDmSoft dm, int DFyxx = 0, int DFyxy = 0)
        {
            //
            Zs_KeyP(dm, 32, rad.Next(1, 3));
            //
            object intX, intY;
            int dm_ret = 0;
            DateTime killouttime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            int Unfindtime = 0;
            int KillCount = 0;
            int ZhsSkillCount = 0;
            bool IsFindDfArmy = false;
            int Yxx = 0;
            int Yxy = 0;
            int FindDelay = 5;
            while (true)
            {
                //
                Zs_KeyP(dm, 32, rad.Next(1, 3));
                //
                //检查是否发现防御塔
                dm_ret = dm.FindPic(180, 118, 830, 631, "LongBld_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("防御塔卧槽，作死啊");
                    //
                    return false;
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return true;
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return true;
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    return true;
                }
                dm.UseDict(0);
                string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                if (isdead != "")
                {
                    return true;
                }

                int DarmyNum = 0;
                int MarmyNum = 0;
                IsFindDfArmy = false;
                Delay(rad.Next(5, 10));
                string DArmyList = dm.FindPicEx(208, 118, 800, 631, "Garmy_2.bmp", "000000", 0.8, 0);
                if (DArmyList.Length > 0)
                {
                    DarmyNum = DArmyList.Split('|').Length;
                    Yxx = int.Parse(DArmyList.Split('|')[0].Split(',')[1]) + 69;
                    Yxy = int.Parse(DArmyList.Split('|')[0].Split(',')[2]) + 84;
                }
                Delay(rad.Next(5, 10));
                string MArmyList = dm.FindPicEx(208, 118, 800, 631, "MyArmy_1.bmp", "000000", 0.8, 0);
                if (MArmyList.Length > 0)
                {
                    MarmyNum = MArmyList.Split('|').Length;
                }
                if (DarmyNum > 0)
                {
                    Zs_KeyP(dm, 32, rad.Next(1, 2));
                    if (DarmyNum <= MarmyNum)
                    {
                        IsFindDfArmy = true;
                    }
                    else if (DarmyNum - MarmyNum == 1 && DarmyNum != 1)
                    {
                        IsFindDfArmy = true;
                    }
                    else if (DarmyNum == 1)//如果我方是敌方小兵的二倍且敌方英雄只有1人
                    {
                        int DxbNum = 0;
                        int MxbyNum = 0;
                        //英雄数量确定，再确定小兵数量
                        Delay(5);
                        string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                        if (DxbList.Length > 0)
                        {
                            DxbNum = DxbList.Split('|').Length;
                        }
                        Delay(5);
                        string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                        if (MxbList.Length > 0)
                        {
                            MxbyNum = MxbList.Split('|').Length;
                        }
                        if (DxbNum != 0 && MxbyNum != 0)
                        {
                            if ((MxbyNum / DxbNum >= 2) || (DxbNum == 0 && MxbyNum > 3))
                            {
                                IsFindDfArmy = true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                if (IsFindDfArmy)
                {
                    Zs_KeyP(dm, 32, rad.Next(1, 2));
                    int DxbNum = 0;
                    int MxbyNum = 0;
                    //英雄数量确定，再确定小兵数量
                    Delay(5);
                    string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                    if (DxbList.Length > 0)
                    {
                        DxbNum = DxbList.Split('|').Length;
                    }
                    Delay(5);
                    string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                    if (MxbList.Length > 0)
                    {
                        MxbyNum = MxbList.Split('|').Length;
                    }
                    if (DxbNum / MxbyNum >= 2)
                    {
                        return false;
                    }
                }
                if (IsFindDfArmy)
                {
                    //设置状态
                    SetState("跟我浪我搞死你丫的");
                    //
                    Unfindtime = 0;
                    Zs_KeyP(dm, 65, 1);
                    Delay(rad.Next(10, 50));
                    Zs_Move_Clk(dm, Yxx, Yxy, 30, rad.Next(1, 4));
                    ZhsSkillCount++;
                    if (ZhsSkillCount >= 3)
                    {
                        Zs_KeyP(dm, 68, rad.Next(1, 2));
                        Delay(rad.Next(20, 70));
                        Zs_KeyP(dm, 70, rad.Next(1, 2));
                        ZhsSkillCount = -50;
                    }
                    Delay(rad.Next(10, 30));
                    for (int i = 0; i < 6; i++)
                    {
                        Zs_KeyP(dm, SkillAry[rad.Next(0, 4)], rad.Next(1, 3));
                    }
                    Delay(rad.Next(10, 30));
                    KillCount++;
                    if (KillCount >= 2)
                    {
                        //判断主动技能是否可以释放
                        CheckZdSkill(dm);
                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                        Delay(rad.Next(10, 100));
                        KillCount = 0;
                    }
                }
                else
                {
                    Unfindtime++;
                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                    if (Unfindtime >= 2)
                    {
                        break;
                    }
                }
                if ((int)GetCoadDoIngTime(false, killouttime) >= 20 * 1000)//15秒超时
                {
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// 通用击杀敌方英雄方法
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="DFyxx"></param>
        /// <param name="DFyxy"></param>
        private bool KillDfyx_Normal(CDmSoft dm, int DFyxx = 0, int DFyxy = 0)
        {
            //
            Zs_KeyP(dm, 32, rad.Next(1, 3));
            //
            object intX, intY;
            int dm_ret = 0;
            DateTime killouttime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            int Unfindtime = 0;
            int KillCount = 0;
            bool LessBlood = false;
            int Bloodckeckcount = 0;
            int ZhsSkillCount = 0;
            bool IsFindDfArmy = false;
            int Yxx = 0;
            int Yxy = 0;
            int FindDelay = 5;
            while (true)
            {
                //
                Zs_KeyP(dm, 32, rad.Next(1, 3));
                //
                //检查是否发现防御塔
                dm_ret = dm.FindPic(180, 118, 830, 631, "LongBld_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("防御塔卧槽，作死啊");
                    //
                    return false;
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return true;
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return true;
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    return true;
                }
                dm.UseDict(0);
                string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                if (isdead != "")
                {
                    return true;
                }
                Delay(rad.Next(FindDelay, FindDelay + 15));
                LessBlood = false;
                if (!OpenCheckMsgWindow)
                {
                    dm.UseDict(1);
                    string Nowblood = dm.Ocr(447, 732, 608, 745, "c8c8c8-303030|c5c5c5-404040", 0.9);
                    if (Nowblood != "")
                    {
                        try
                        {
                            int MaxBlood = int.Parse(Nowblood.Split('/')[1]);
                            int NowBlood = int.Parse(Nowblood.Split('/')[0]);
                            if (NowBlood < 300)
                            {
                                //失血过多
                                LessBlood = true;
                            }
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }
                }
                else
                {
                    if (dm.CmpColor(465, 738, "010604-000000", 0.8) == 0 && dm.CmpColor(465, 737, "010704-000000", 0.8) == 0)
                    {
                        LessBlood = true;
                    }
                }
                if (!LessBlood)
                {
                    int DarmyNum = 0;
                    int MarmyNum = 0;
                    IsFindDfArmy = false;
                    Delay(rad.Next(5, 10));
                    string DArmyList = dm.FindPicEx(208, 118, 800, 631, "Garmy_2.bmp", "000000", 0.8, 0);
                    if (DArmyList.Length > 0)
                    {
                        DarmyNum = DArmyList.Split('|').Length;
                        Yxx = int.Parse(DArmyList.Split('|')[0].Split(',')[1]) + 69;
                        Yxy = int.Parse(DArmyList.Split('|')[0].Split(',')[2]) + 84;
                    }
                    Delay(rad.Next(5, 10));
                    string MArmyList = dm.FindPicEx(208, 118, 800, 631, "MyArmy_1.bmp", "000000", 0.8, 0);
                    if (MArmyList.Length > 0)
                    {
                        MarmyNum = MArmyList.Split('|').Length;
                    }
                    if (DarmyNum > 0)
                    {
                        Zs_KeyP(dm, 32, rad.Next(1, 2));
                        if (DarmyNum <= MarmyNum)
                        {
                            IsFindDfArmy = true;
                        }
                        else if (DarmyNum - MarmyNum == 1 && DarmyNum != 1)
                        {
                            IsFindDfArmy = true;
                        }
                        else if (DarmyNum == 1)//如果我方是敌方小兵的二倍且敌方英雄只有1人
                        {
                            int DxbNum = 0;
                            int MxbyNum = 0;
                            //英雄数量确定，再确定小兵数量
                            Delay(5);
                            string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                            if (DxbList.Length > 0)
                            {
                                DxbNum = DxbList.Split('|').Length;
                            }
                            Delay(5);
                            string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                            if (MxbList.Length > 0)
                            {
                                MxbyNum = MxbList.Split('|').Length;
                            }
                            if (DxbNum != 0 && MxbyNum != 0)
                            {
                                if ((MxbyNum / DxbNum >= 2) || (DxbNum == 0 && MxbyNum > 3))
                                {
                                    IsFindDfArmy = true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    if (IsFindDfArmy)
                    {
                        Zs_KeyP(dm, 32, rad.Next(1, 2));
                        int DxbNum = 0;
                        int MxbyNum = 0;
                        //英雄数量确定，再确定小兵数量
                        Delay(5);
                        string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                        if (DxbList.Length > 0)
                        {
                            DxbNum = DxbList.Split('|').Length;
                        }
                        Delay(5);
                        string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                        if (MxbList.Length > 0)
                        {
                            MxbyNum = MxbList.Split('|').Length;
                        }
                        if (DxbNum / MxbyNum >= 2)
                        {
                            return false;
                        }
                    }
                    if (IsFindDfArmy)
                    {
                        //设置状态
                        SetState("跟我浪我搞死你丫的");
                        //
                        Unfindtime = 0;
                        Zs_KeyP(dm, 65, 1);
                        Delay(rad.Next(10, 50));
                        Zs_Move_Clk(dm, Yxx, Yxy, 30, rad.Next(1, 4));
                        ZhsSkillCount++;
                        if (ZhsSkillCount >= 3)
                        {
                            Zs_KeyP(dm, 68, rad.Next(1, 2));
                            Delay(rad.Next(20, 70));
                            Zs_KeyP(dm, 70, rad.Next(1, 2));
                            ZhsSkillCount = -50;
                        }
                        Delay(rad.Next(10, 30));
                        for (int i = 0; i < 6; i++)
                        {
                            Zs_KeyP(dm, SkillAry[rad.Next(0, 4)], rad.Next(1, 3));
                        }
                        Delay(rad.Next(10, 30));
                        KillCount++;
                        if (KillCount >= 2)
                        {
                            //判断主动技能是否可以释放
                            CheckZdSkill(dm);
                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                            Delay(rad.Next(10, 100));
                            KillCount = 0;
                        }
                    }
                    else
                    {
                        Unfindtime++;
                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                        if (Unfindtime >= 2)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    //设置状态
                    SetState("艾玛，失血过多");
                    //
                    //往地图中间逃
                    Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                    Bloodckeckcount++;
                    if (Bloodckeckcount >= 2)
                    {
                        Zs_KeyP(dm, 32, rad.Next(1, 4));
                        Delay(1000);
                        Bloodckeckcount = 0;
                        return false;
                    }
                }
                if ((int)GetCoadDoIngTime(false, killouttime) >= 20 * 1000)//15秒超时
                {
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// 击杀英雄方法
        /// </summary>
        /// <param name="dm"></param>
        private void KillDfyx(CDmSoft dm, int DFyxx = 0, int DFyxy = 0)
        {
            //
            if (DFyxx != 0)
            {
                Zs_Move_R(dm, DFyxx, DFyxy, 30, rad.Next(1, 4));
            }
            //
            Zs_KeyP(dm, 32, rad.Next(1, 3));
            //
            object intX, intY;
            int dm_ret = 0;
            DateTime killouttime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            int Unfindtime = 0;
            int KillCount = 0;
            bool LessBlood = false;
            int Bloodckeckcount = 0;
            int ZhsSkillCount = 0;
            int DownAnUp = 0;
            bool IsFindDfArmy = false;
            int Yxx = 0;
            int Yxy = 0;
            bool IsgettinT = false;
            bool IsAwarclick = false;
            int FindDelay = 20;
            if (OpenTzCarry)
            {
                FindDelay = 5;
            }
            while (true)
            {
                Delay(FindDelay);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    return;
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    return;
                }
                Delay(FindDelay);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    return;
                }
                dm.UseDict(0);
                string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                if (isdead != "")
                {
                    return;
                }
                Delay(rad.Next(FindDelay, FindDelay + 15));
                LessBlood = false;
                if (!OpenCheckMsgWindow)
                {
                    dm.UseDict(1);
                    string Nowblood = dm.Ocr(447, 732, 608, 745, "c8c8c8-303030|c5c5c5-404040", 0.9);
                    if (Nowblood != "")
                    {
                        try
                        {
                            int MaxBlood = int.Parse(Nowblood.Split('/')[1]);
                            int NowBlood = int.Parse(Nowblood.Split('/')[0]);
                            if (NowBlood < 300)
                            {
                                //失血过多
                                LessBlood = true;
                            }
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }
                }
                else
                {
                    if (dm.CmpColor(465, 738, "010604-000000", 0.8) == 0 && dm.CmpColor(465, 737, "010704-000000", 0.8) == 0)
                    {
                        LessBlood = true;
                    }
                }
                if (!LessBlood)
                {
                    IsFindDfArmy = false;
                    Delay(rad.Next(20, 40));
                    dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                    if ((int)intX > 0)
                    {
                        Yxx = (int)intX - 69;
                        Yxy = (int)intY + 84;
                        IsFindDfArmy = true;
                    }
                    Delay(rad.Next(20, 40));
                    dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                    if ((int)intX > 0)
                    {
                        Yxx = (int)intX + 69;
                        Yxy = (int)intY + 84;
                        IsFindDfArmy = true;
                    }
                    if (OpenTzCarry)
                    {
                        IsgettinT = false;
                        Delay(10);
                        dm_ret = dm.FindPic(362, 594, 664, 615, "GetFYT_1.bmp|GetFYT_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现在占领防御塔
                        if ((int)intX > 0)
                        {
                            IsgettinT = true;
                            IsFindDfArmy = false;
                        }
                        else
                        {
                            Delay(10);
                            dm_ret = dm.FindPic(433, 563, 601, 603, "Zzzl_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现在占领防御塔
                            if ((int)intX > 0)
                            {
                                IsgettinT = true;
                                IsFindDfArmy = false;
                            }
                        }
                        if (IsgettinT)
                        {
                            if (IsAwarclick)
                            {
                                //往下
                                if (DownAnUp == 1)
                                {
                                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                                    Delay(rad.Next(10, 50));
                                    Zs_Move_R(dm, 494, 322, 10, rad.Next(1, 4));
                                }
                                else if (DownAnUp == 2)//往上
                                {
                                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                                    Delay(rad.Next(10, 50));
                                    Zs_Move_R(dm, 515, 456, 10, rad.Next(1, 4));
                                }
                            }
                            else
                            {
                                //往上
                                if (DownAnUp == 1)
                                {
                                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                                    Delay(rad.Next(10, 50));
                                    Zs_Move_R(dm, 515, 456, 10, rad.Next(1, 4));
                                }
                                else if (DownAnUp == 2)//往下
                                {
                                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                                    Delay(rad.Next(10, 50));
                                    Zs_Move_R(dm, 494, 322, 10, rad.Next(1, 4));
                                }
                            }
                        }
                    }
                    if (IsFindDfArmy)
                    {
                        IsAwarclick = false;
                        //设置状态
                        SetState("跟我浪我搞死你丫的");
                        //
                        Unfindtime = 0;
                        Zs_KeyP(dm, 65, 1);
                        Delay(rad.Next(10, 50));
                        Zs_Move_Clk(dm, Yxx, Yxy, 30, rad.Next(1, 4));
                        ZhsSkillCount++;
                        if (ZhsSkillCount >= 3)
                        {
                            Zs_KeyP(dm, 68, rad.Next(1, 2));
                            Delay(rad.Next(20, 70));
                            Zs_KeyP(dm, 70, rad.Next(1, 2));
                            ZhsSkillCount = -50;
                        }
                        Delay(rad.Next(10, 30));
                        for (int i = 0; i < 6; i++)
                        {
                            Zs_KeyP(dm, SkillAry[rad.Next(0, 4)], rad.Next(1, 3));
                        }
                        Delay(rad.Next(10, 30));
                        KillCount++;
                        if (KillCount >= 2)
                        {
                            //判断主动技能是否可以释放
                            CheckZdSkill(dm);
                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                            Delay(rad.Next(10, 100));
                            KillCount = 0;
                            if (OpenTzCarry)
                            {
                                if (Yxy - 84 >= 298)
                                {
                                    //往下走一点
                                    DownAnUp = 1;
                                }
                                else
                                {
                                    //往上走一点
                                    DownAnUp = 2;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (OpenTzCarry)
                        {
                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                            Delay(rad.Next(10, 50));
                            //往下
                            if (DownAnUp == 1)
                            {
                                Zs_Move_R(dm, 515, 456, 10, rad.Next(1, 4));
                                IsAwarclick = true;
                            }
                            else if (DownAnUp == 2)//往上
                            {
                                Zs_Move_R(dm, 494, 322, 10, rad.Next(1, 4));
                                IsAwarclick = true;
                            }

                        }
                        Unfindtime++;
                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                        if (Unfindtime >= 5)
                        {
                            break; ;
                        }
                    }
                }
                else
                {
                    //设置状态
                    SetState("艾玛，失血过多");
                    //
                    //往地图中间逃
                    Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                    Bloodckeckcount++;
                    if (Bloodckeckcount >= 2)
                    {
                        //判断物品主动技能是否可以释放
                        Zs_KeyP(dm, 32, rad.Next(1, 4));
                        Delay(100);
                        Bloodckeckcount = 0;
                    }
                }
                if ((int)GetCoadDoIngTime(false, killouttime) >= 20 * 1000)//15秒超时
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 统治逃跑方法
        /// </summary>
        /// <param name="dm"></param>
        private bool TzRunAway(CDmSoft dm)
        {
            dm.MoveTo(493, 367);
            Zs_KeyP(dm, 32, rad.Next(1, 3));
            //设置状态
            SetState("被打断占据，快跑");
            //如果发现敌方英雄打断占据，先撤退，换点撤退10秒
            for (int i = 0; i < 2; i++)
            {
                Zs_KeyP(dm, 32, rad.Next(1, 3));
                //往地图中间逃
                Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                Delay(2000);
                //判断死亡
                dm.UseDict(0);
                string isdeads = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                if (isdeads != "")
                {
                    break;
                }
            }
            //敌方英雄判断
            KillDfyx(dm);
            //血量判断
            if (BloodCheck(dm))
            {
                //设置状态
                SetState("(血量过低)开始回城");
                //
                if (GoHome(dm))
                {
                    GetShopSomething_Tz(dm);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 游戏结束处理
        /// </summary>
        /// <param name="dm"></param>
        private bool GameEndWaite(CDmSoft dm, int GameHwnd)
        {
            object intX, intY;
            int dm_ret = 0;
            DateTime EndingTime = System.DateTime.Now;
            while (true)
            {
                if ((int)GetCoadDoIngTime(false, EndingTime) >= 30 * 1000)//30秒超时
                {
                    return false;
                }
                KillProcessByName("iexplore");
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return false;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return false;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return false;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return false;
                }
                Delay(200);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏需要重连");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    //
                    Delay(2000);
                    return false;
                }
                Delay(50);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("有本事晚上床上来");
                    //
                    Zs_Move_Clk(dm, 509, 571, 50, 1);
                    Delay(5000);
                    dm.MoveTo(0, 0);
                }
                Delay(50);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("都没有一个能打的吗");
                    //
                    Zs_Move_Clk(dm, 509, 571, 50, 1);
                    Delay(5000);
                    dm.MoveTo(0, 0);
                }
                Delay(50);
                if (dm.GetWindowState(GameHwnd, 0) == 0)
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 临时路线处理
        /// </summary>
        List<string> Roaddeals = new List<string>();
        /// <summary>
        /// 判断路线是否可以走
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="rodx"></param>
        /// <param name="rody"></param>
        /// <returns></returns>
        private bool Jd_GetroadSafe(CDmSoft dm, out int rodx, out int rody, int Zy, int count)
        {
            object intX, intY;
            int dm_ret = 0;
            Roaddeals.Clear();
            rodx = -1;
            rody = -1;
            for (int i = 0; i < count; i++)
            {
                Roaddeals.Add(Jd_Sb_road[i]);
            }
            int searcmod = 0;
            foreach (string str in Roaddeals)
            {
                int Sszsx = int.Parse(str.Split(',')[0]);
                int Sszsy = int.Parse(str.Split(',')[1]);
                int Ssyxx = int.Parse(str.Split(',')[2]);
                int Ssyxy = int.Parse(str.Split(',')[3]);
                Delay(10);
                if (Zy == 1)
                {
                    searcmod = 1;
                }
                else
                {
                    searcmod = 2;
                }
                //先判断是否有敌军
                dm_ret = dm.FindColor(Sszsx, Sszsy, Ssyxx, Ssyxy, "0099e0-020202", 0.8, searcmod, out intX, out intY);
                if ((int)intX > 0)
                {
                    Delay(10);
                    //再判断是否有我军
                    dm_ret = dm.FindColor(Sszsx, Sszsy, Ssyxx, Ssyxy, "ff0000-020202", 0.8, searcmod, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        rodx = (int)intX;
                        rody = (int)intY;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 判断路线是否可以走
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="rodx"></param>
        /// <param name="rody"></param>
        /// <returns></returns>
        private bool Nq_GetroadSafe(CDmSoft dm, out int rodx, out int rody, int Zy, int count)
        {
            object intX, intY;
            int dm_ret = 0;
            Roaddeals.Clear();
            rodx = -1;
            rody = -1;
            if (RoadSelect_Nq == 0)//上路
            {
                for (int i = 0; i < count; i++)
                {
                    Roaddeals.Add(Nq_sb_Sl[i]);
                }
            }
            else if (RoadSelect_Nq == 1)//下路
            {
                for (int i = 0; i < count; i++)
                {
                    Roaddeals.Add(Nq_sb_Xl[i]);
                }
            }
            int searcmod = 0;
            foreach (string str in Roaddeals)
            {
                int Sszsx = int.Parse(str.Split(',')[0]);
                int Sszsy = int.Parse(str.Split(',')[1]);
                int Ssyxx = int.Parse(str.Split(',')[2]);
                int Ssyxy = int.Parse(str.Split(',')[3]);
                Delay(10);
                if (Zy == 1)
                {
                    searcmod = 1;
                }
                else
                {
                    searcmod = 2;
                }
                //先判断是否有敌军
                dm_ret = dm.FindColor(Sszsx, Sszsy, Ssyxx, Ssyxy, "0099e0-020202", 0.8, searcmod, out intX, out intY);
                if ((int)intX > 0)
                {
                    Delay(10);
                    //再判断是否有我军
                    dm_ret = dm.FindColor(Sszsx, Sszsy, Ssyxx, Ssyxy, "ff0000-020202", 0.8, searcmod, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        rodx = (int)intX;
                        rody = (int)intY;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 判断路线是否可以走
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="rodx"></param>
        /// <param name="rody"></param>
        /// <returns></returns>
        private bool Zhs_GetroadSafe(CDmSoft dm, out int rodx, out int rody, int Zy, int count)
        {
            object intX, intY;
            int dm_ret = 0;
            Roaddeals.Clear();
            rodx = -1;
            rody = -1;
            if (RoadSelect == 0)//上路
            {
                for (int i = 0; i < count; i++)
                {
                    Roaddeals.Add(S_FytFw[i]);
                }
            }
            else if (RoadSelect == 1)//中路
            {
                for (int i = 0; i < count; i++)
                {
                    Roaddeals.Add(Z_FytFw[i]);
                }
            }
            else
            {
                //下路
                for (int i = 0; i < count; i++)
                {
                    Roaddeals.Add(X_FytFw[i]);
                }
            }
            int searcmod = 0;
            foreach (string str in Roaddeals)
            {
                int Sszsx = int.Parse(str.Split(',')[0]);
                int Sszsy = int.Parse(str.Split(',')[1]);
                int Ssyxx = int.Parse(str.Split(',')[2]);
                int Ssyxy = int.Parse(str.Split(',')[3]);
                Delay(10);
                if (Zy == 2)
                {
                    searcmod = 1;
                }
                else
                {
                    searcmod = 2;
                }
                //先判断是否有敌军
                dm_ret = dm.FindColor(Sszsx, Sszsy, Ssyxx, Ssyxy, "0099e0-020202", 0.8, searcmod, out intX, out intY);
                if ((int)intX > 0)
                {
                    Delay(10);
                    //再判断是否有我军
                    dm_ret = dm.FindColor(Sszsx, Sszsy, Ssyxx, Ssyxy, "ff0000-020202", 0.8, searcmod, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        rodx = (int)intX;
                        rody = (int)intY;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 技能处理
        /// </summary>
        private bool SkillDeal(CDmSoft dm)
        {
            int Lx = 0;
            int Ly = 0;
            int Lz = 0;
            int Lw = 0;
            bool UnfindAdd = true;
            //大漠通用
            object intX, intY;
            int dm_ret = 0;
            Delay(10);
            dm_ret = dm.FindPic(523, 625, 578, 676, "Addskill_1.bmp|Addskill_2.bmp|AddSkill3.bmp", "000000", 0.7, 0, out intX, out intY);//发现大招可以加
            if ((int)intX > 0)
            {
                //设置状态
                SetState("发现可加点技能");
                //
                Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 1);
                Delay(50);
                dm.MoveTo(587, rad.Next(250, 650));
                UnfindAdd = false;
            }
            else
            {
                switch (HeroSkillZadd)
                {
                    case 0:
                        Lx = 398;
                        Ly = 627;
                        Lz = 442;
                        Lw = 671;
                        break;
                    case 1:
                        Lx = 444;
                        Ly = 627;
                        Lz = 484;
                        Lw = 671;
                        break;
                    case 2:
                        Lx = 485;
                        Ly = 627;
                        Lz = 528;
                        Lw = 671;
                        break;
                }
                Delay(10);
                dm_ret = dm.FindPic(Lx, Ly, Lz, Lw, "Addskill_1.bmp|Addskill_2.bmp|AddSkill3.bmp", "000000", 0.7, 0, out intX, out intY);//发现普通技能可以加
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现可加点技能");
                    //
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 1);
                    Delay(200);
                    dm.MoveTo(587, rad.Next(250, 650));
                    UnfindAdd = false;
                }
                else
                {
                    switch (HeroSkillFadd)
                    {
                        case 0:
                            Lx = 398;
                            Ly = 627;
                            Lz = 442;
                            Lw = 671;
                            break;
                        case 1:
                            Lx = 444;
                            Ly = 627;
                            Lz = 484;
                            Lw = 671;
                            break;
                        case 2:
                            Lx = 485;
                            Ly = 627;
                            Lz = 528;
                            Lw = 671;
                            break;
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(Lx, Ly, Lz, Lw, "Addskill_1.bmp|Addskill_2.bmp|AddSkill3.bmp", "000000", 0.7, 0, out intX, out intY);//发现普通技能可以加
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("发现可加点技能");
                        //
                        Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 1);
                        Delay(150);
                        dm.MoveTo(587, rad.Next(250, 650));
                        UnfindAdd = false;
                    }
                }
            }
            return UnfindAdd;
        }
        /// <summary>
        /// 游戏模式识别
        /// </summary>
        /// <param name="dm"></param>
        private bool GameModDeal(CDmSoft dm, int NowMod)
        {
            //大漠通用
            object intX, intY;
            int dm_ret = 0;

            int Getmod = -1;

            Delay(200);

            //召唤师峡谷阵营识别
            dm_ret = dm.FindColor(993, 576, 1022, 599, "ffffff-020202", 0.9, 0, out intX, out intY);//右上角阵营
            if ((int)intX > 0)
            {
                Getmod = 0;
            }
            Delay(200);
            dm_ret = dm.FindColor(833, 737, 859, 763, "ffffff-020202", 0.9, 0, out intX, out intY);//左下角阵营
            if ((int)intX > 0)
            {
                Getmod = 0;
            }

            //极地阵营识别
            //识别阵营
            dm_ret = dm.FindPic(832, 714, 880, 761, "Jdzy_1.bmp", "000000", 0.8, 0, out intX, out intY);//左下角阵营
            if ((int)intX > 0)
            {
                Getmod = 4;
            }
            Delay(200);
            //识别阵营
            dm_ret = dm.FindPic(963, 576, 1020, 619, "Jdzy_2.bmp|Jdzy_3.bmp", "000000", 0.8, 0, out intX, out intY);//右边阵营
            if ((int)intX > 0)
            {
                Getmod = 4;
            }

            //扭曲阵营识别
            //识别阵营
            dm_ret = dm.FindPic(831, 640, 879, 700, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//左边阵营
            if ((int)intX > 0)
            {
                Getmod = 3;
            }
            Delay(200);
            //识别阵营
            dm_ret = dm.FindPic(977, 650, 1022, 697, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//右边阵营
            if ((int)intX > 0)
            {
                Getmod = 3;
            }

            //通知阵营识别
            Delay(200);
            dm_ret = dm.FindColor(453, 68, 492, 87, "01f901-020202|01f401-020202", 0.8, 0, out intX, out intY);
            if ((int)intX > 0)
            {
                Getmod = 1;
            }
            Delay(200);
            dm_ret = dm.FindColor(536, 68, 574, 89, "01f901-020202|01f401-020202", 0.8, 0, out intX, out intY);
            if ((int)intX > 0)
            {
                Getmod = 1;
            }

            if (Getmod != -1 && Getmod != NowMod)
            {
                GameMod = Getmod;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 召唤师峡谷
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="Lobbyhwnd"></param>
        private void Zh_Game(CDmSoft dm, int Lobbyhwnd)
        {
            dm.EnableRealMouse(1, 10, 50);
            dm.EnableRealKeypad(1);
            //大漠通用
            object intX, intY;
            int dm_ret = 0;
            dm.SetPath(".\\attachment");
            dm_ret = dm.SetShowErrorMsg(0);
            dm_ret = dm.SetPicPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDictPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDict(0, "Onerd_GamDeadzk.txt");
            dm_ret = dm.SetDict(1, "Onerd_Blood.txt");
            dm_ret = dm.UnBindWindow();
            int RoadRadom = rad.Next(0, 100);
            if (RoadRadom < 30)
            {
                RoadSelect = 0;//上路
            }
            else if (RoadRadom >= 30 && RoadRadom < 60)
            {
                RoadSelect = 1;//中路 
            }
            else
            {
                RoadSelect = 2;//下路
            }
            //
            dm.SetWindowState(Lobbyhwnd, 1);
            Delay(100);
            //移动窗口到左上角
            dm.MoveWindow(Lobbyhwnd, 0, 0);
            Delay(100);
            //进行绑定
            if (SoftMod == 0)//前台
            {
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "normal", "normal", "normal", "dx.public.disable.window.minmax", 101);//      
            }
            else
            {
                //
                for (int i = 0; i < 3; i++)
                {
                    dm.SetWindowState(Lobbyhwnd, 1);
                    Delay(100);
                    //移动窗口到左上角
                    dm.MoveWindow(Lobbyhwnd, -10, -1);
                    Delay(100);
                }
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "gdi", "dx.mouse.position.lock.api|dx.mouse.position.lock.message|dx.mouse.clip.lock.api|dx.mouse.input.lock.api|dx.mouse.state.api|dx.mouse.api|dx.mouse.cursor", "dx.keypad.input.lock.api|dx.keypad.state.api|dx.keypad.api", "dx.public.active.api|dx.public.down.cpu", 101);//   
            }
            if (dm_ret != 1)
            {
                int Errormsg = dm.GetLastError();
                Delay(5000);
                dm.UnBindWindow();
                return;
            }
            //设置状态
            SetState("检测游戏窗口成功");
            //
            int GetZy = 0;
            //
            int ChooseZyCount = 0;
            bool QQisSend = false;
            int SkillUnfindTime = 0;
            bool UnNeedLock = false;
            while (true)
            {
                KillProcessByName("iexplore");
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏需要重连");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    //
                    Delay(2000);
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(101, 345, 622, 420, "Sm_Tip_1.bmp|Vs_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏在载入
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏正在载入中");
                    //
                    Delay(4000);
                    dm.MoveTo(0, 0);
                }
                bool InGameing = false;
                //识别是否进入游戏
                Delay(200);
                dm_ret = dm.FindPic(816, 531, 922, 588, "intGame_1.bmp|intGame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经进入游戏
                if ((int)intX > 0)
                {
                    InGameing = true;
                }
                Delay(200);
                dm_ret = dm.FindPic(70, 668, 99, 765, "Ft_1_2.bmp|Ft_2.bmp|Ft_3.bmp|Ft_4.bmp|Ft_5.bmp|Ft_6.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经进入游戏
                if ((int)intX > 0)
                {
                    InGameing = true;
                    UnNeedLock = true;
                }
                if (InGameing)
                {
                    Delay(200);
                    dm_ret = dm.FindColor(453, 68, 492, 87, "01f901-020202|01f401-020202", 0.8, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("地图模式自动校正");
                        //
                        GameMod = 1;
                        return;
                    }
                    Delay(200);
                    dm_ret = dm.FindColor(536, 68, 574, 89, "01f901-020202|01f401-020202", 0.8, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("地图模式自动校正");
                        //
                        GameMod = 1;
                        return;
                    }
                    dm.MoveTo(493, 367);
                    Zs_KeyP(dm, 32, 1);
                    Delay(1500);
                    dm_ret = dm.FindColor(993, 576, 1022, 599, "ffffff-020202", 0.9, 0, out intX, out intY);//右上角阵营
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("我方在右上角阵营");
                        //
                        //上路防御塔
                        S_FytFw[5] = "833,690,859,735";
                        S_FytFw[4] = "836,650,862,694";
                        S_FytFw[3] = "837,586,862,652";
                        S_FytFw[2] = "856,583,907,619";
                        S_FytFw[1] = "904,582,956,603";
                        S_FytFw[0] = "957,581,997,601";
                        //中路防御塔
                        Z_FytFw[5] = "861,699,891,735";
                        Z_FytFw[4] = "883,685,917,719";
                        Z_FytFw[3] = "896,662,937,696";
                        Z_FytFw[2] = "922,647,963,679";
                        Z_FytFw[1] = "947,629,981,654";
                        Z_FytFw[0] = "960,605,998,640";
                        //下路防御塔
                        X_FytFw[5] = "863,737,904,759";
                        X_FytFw[4] = "904,737,956,760";
                        X_FytFw[3] = "946,724,1000,759";
                        X_FytFw[2] = "987,689,1019,755";
                        X_FytFw[1] = "997,642,1018,696";
                        X_FytFw[0] = "997,601,1017,643";
                        //
                        Tpzsx = int.Parse(RunaayZb[2].Split(',')[0]);
                        Tpzxy = int.Parse(RunaayZb[2].Split(',')[1]);
                        Tpyxx = int.Parse(RunaayZb[2].Split(',')[2]);
                        Tpyxy = int.Parse(RunaayZb[2].Split(',')[3]);
                        //
                        GetZy = 1;
                        Delay(1500);
                    }
                    dm.MoveTo(493, 367);
                    Zs_KeyP(dm, 32, 1);
                    Delay(1500);
                    dm_ret = dm.FindColor(833, 737, 859, 763, "ffffff-020202", 0.9, 0, out intX, out intY);//左下角阵营
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("我方在左下角阵营");
                        //
                        //上路防御塔
                        S_FytFw[0] = "833,690,859,735";
                        S_FytFw[1] = "836,650,862,694";
                        S_FytFw[2] = "837,586,862,652";
                        S_FytFw[3] = "856,583,907,619";
                        S_FytFw[4] = "904,582,956,603";
                        S_FytFw[5] = "957,581,997,601";
                        //中路防御塔
                        Z_FytFw[0] = "861,699,891,735";
                        Z_FytFw[1] = "883,685,917,719";
                        Z_FytFw[2] = "896,662,937,696";
                        Z_FytFw[3] = "922,647,963,679";
                        Z_FytFw[4] = "947,629,981,654";
                        Z_FytFw[5] = "960,605,998,640";
                        //下路防御塔
                        X_FytFw[0] = "863,737,904,759";
                        X_FytFw[1] = "904,737,956,760";
                        X_FytFw[2] = "946,724,1000,759";
                        X_FytFw[3] = "987,689,1019,755";
                        X_FytFw[4] = "997,642,1018,696";
                        X_FytFw[5] = "997,601,1017,643";
                        //
                        Tpzsx = int.Parse(RunaayZb[1].Split(',')[0]);
                        Tpzxy = int.Parse(RunaayZb[1].Split(',')[1]);
                        Tpyxx = int.Parse(RunaayZb[1].Split(',')[2]);
                        Tpyxy = int.Parse(RunaayZb[1].Split(',')[3]);
                        //
                        GetZy = 2;
                        Delay(1500);
                    }
                    if (GetZy != 0)
                    {
                        if (UnNeedLock)
                        {
                            //设置状态
                            SetState("正式开始游戏对局");
                            //
                            break;
                        }
                        Delay(200);
                        dm_ret = dm.FindPic(972, 534, 1018, 588, "Lock_1.bmp|Lock_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现视角没有锁定
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("正式开始游戏对局");
                            //
                            break;
                        }
                        else
                        {
                            Zs_KeyP(dm, 89, 1);
                            Delay(1000);
                        }
                    }
                    else
                    {
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                        if (!GameModDeal(dm, GameMod))
                        {
                            return;
                        }
                        ChooseZyCount++;
                        if (ChooseZyCount >= 3)
                        {
                            ChooseZyCount = 0;
                            dm.MoveTo(493, 367);
                            Zs_KeyP(dm, 32, 1);
                            Delay(1500);
                            dm_ret = dm.FindColor(993, 576, 1022, 599, "ffffff-020202", 0.9, 0, out intX, out intY);//右上角阵营
                            if ((int)intX > 0)
                            {
                                //上路防御塔
                                S_FytFw[5] = "833,690,859,735";
                                S_FytFw[4] = "836,650,862,694";
                                S_FytFw[3] = "837,586,862,652";
                                S_FytFw[2] = "856,583,907,619";
                                S_FytFw[1] = "904,582,956,603";
                                S_FytFw[0] = "957,581,997,601";
                                //中路防御塔
                                Z_FytFw[5] = "861,699,891,735";
                                Z_FytFw[4] = "883,685,917,719";
                                Z_FytFw[3] = "896,662,937,696";
                                Z_FytFw[2] = "922,647,963,679";
                                Z_FytFw[1] = "947,629,981,654";
                                Z_FytFw[0] = "960,605,998,640";
                                //下路防御塔
                                X_FytFw[5] = "863,737,904,759";
                                X_FytFw[4] = "904,737,956,760";
                                X_FytFw[3] = "946,724,1000,759";
                                X_FytFw[2] = "987,689,1019,755";
                                X_FytFw[1] = "997,642,1018,696";
                                X_FytFw[0] = "997,601,1017,643";
                                //
                                Tpzsx = int.Parse(RunaayZb[2].Split(',')[0]);
                                Tpzxy = int.Parse(RunaayZb[2].Split(',')[1]);
                                Tpyxx = int.Parse(RunaayZb[2].Split(',')[2]);
                                Tpyxy = int.Parse(RunaayZb[2].Split(',')[3]);
                                //
                                GetZy = 1;
                            }
                            dm.MoveTo(493, 367);
                            Zs_KeyP(dm, 32, 1);
                            Delay(1500);
                            dm_ret = dm.FindColor(833, 737, 859, 763, "ffffff-020202", 0.9, 0, out intX, out intY);//左下角阵营
                            if ((int)intX > 0)
                            {
                                //上路防御塔
                                S_FytFw[0] = "833,690,859,735";
                                S_FytFw[1] = "836,650,862,694";
                                S_FytFw[2] = "837,586,862,652";
                                S_FytFw[3] = "856,583,907,619";
                                S_FytFw[4] = "904,582,956,603";
                                S_FytFw[5] = "957,581,997,601";
                                //中路防御塔
                                Z_FytFw[0] = "861,699,891,735";
                                Z_FytFw[1] = "883,685,917,719";
                                Z_FytFw[2] = "896,662,937,696";
                                Z_FytFw[3] = "922,647,963,679";
                                Z_FytFw[4] = "947,629,981,654";
                                Z_FytFw[5] = "960,605,998,640";
                                //下路防御塔
                                X_FytFw[0] = "863,737,904,759";
                                X_FytFw[1] = "904,737,956,760";
                                X_FytFw[2] = "946,724,1000,759";
                                X_FytFw[3] = "987,689,1019,755";
                                X_FytFw[4] = "997,642,1018,696";
                                X_FytFw[5] = "997,601,1017,643";
                                //
                                Tpzsx = int.Parse(RunaayZb[1].Split(',')[0]);
                                Tpzxy = int.Parse(RunaayZb[1].Split(',')[1]);
                                Tpyxx = int.Parse(RunaayZb[1].Split(',')[2]);
                                Tpyxy = int.Parse(RunaayZb[1].Split(',')[3]);
                                //
                                GetZy = 2;
                            }
                            if (GetZy == 0)
                            {
                                Zs_KeyP(dm, 66, 1);
                                Delay(1500);
                            }
                        }
                        GoHome(dm);
                        Delay(1500);
                    }
                    dm.MoveTo(493, 367);
                    Zs_KeyP(dm, 32, 1);
                    Delay(1500);
                    //识别阵营
                    dm_ret = dm.FindPic(990, 574, 1020, 615, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//右上角阵营
                    if ((int)intX > 0)
                    {
                        //上路防御塔
                        S_FytFw[5] = "833,690,859,735";
                        S_FytFw[4] = "836,650,862,694";
                        S_FytFw[3] = "837,586,862,652";
                        S_FytFw[2] = "856,583,907,619";
                        S_FytFw[1] = "904,582,956,603";
                        S_FytFw[0] = "957,581,997,601";
                        //中路防御塔
                        Z_FytFw[5] = "861,699,891,735";
                        Z_FytFw[4] = "883,685,917,719";
                        Z_FytFw[3] = "896,662,937,696";
                        Z_FytFw[2] = "922,647,963,679";
                        Z_FytFw[1] = "947,629,981,654";
                        Z_FytFw[0] = "960,605,998,640";
                        //下路防御塔
                        X_FytFw[5] = "863,737,904,759";
                        X_FytFw[4] = "904,737,956,760";
                        X_FytFw[3] = "946,724,1000,759";
                        X_FytFw[2] = "987,689,1019,755";
                        X_FytFw[1] = "997,642,1018,696";
                        X_FytFw[0] = "997,601,1017,643";
                        //
                        Tpzsx = int.Parse(RunaayZb[2].Split(',')[0]);
                        Tpzxy = int.Parse(RunaayZb[2].Split(',')[1]);
                        Tpyxx = int.Parse(RunaayZb[2].Split(',')[2]);
                        Tpyxy = int.Parse(RunaayZb[2].Split(',')[3]);
                        //
                        GetZy = 1;
                    }
                    dm.MoveTo(493, 367);
                    Zs_KeyP(dm, 32, 1);
                    Delay(1500);
                    dm_ret = dm.FindPic(834, 729, 872, 764, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp", "000000", 0.8, 0, out intX, out intY);//左下角阵营
                    if ((int)intX > 0)
                    {
                        //上路防御塔
                        S_FytFw[0] = "833,690,859,735";
                        S_FytFw[1] = "836,650,862,694";
                        S_FytFw[2] = "837,586,862,652";
                        S_FytFw[3] = "856,583,907,619";
                        S_FytFw[4] = "904,582,956,603";
                        S_FytFw[5] = "957,581,997,601";
                        //中路防御塔
                        Z_FytFw[0] = "861,699,891,735";
                        Z_FytFw[1] = "883,685,917,719";
                        Z_FytFw[2] = "896,662,937,696";
                        Z_FytFw[3] = "922,647,963,679";
                        Z_FytFw[4] = "947,629,981,654";
                        Z_FytFw[5] = "960,605,998,640";
                        //下路防御塔
                        X_FytFw[0] = "863,737,904,759";
                        X_FytFw[1] = "904,737,956,760";
                        X_FytFw[2] = "946,724,1000,759";
                        X_FytFw[3] = "987,689,1019,755";
                        X_FytFw[4] = "997,642,1018,696";
                        X_FytFw[5] = "997,601,1017,643";
                        //
                        Tpzsx = int.Parse(RunaayZb[1].Split(',')[0]);
                        Tpzxy = int.Parse(RunaayZb[1].Split(',')[1]);
                        Tpyxx = int.Parse(RunaayZb[1].Split(',')[2]);
                        Tpyxy = int.Parse(RunaayZb[1].Split(',')[3]);
                        //
                        GetZy = 2;
                    }
                }
                Delay(200);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    break;
                }
                Delay(200);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    break;
                }
                Delay(200);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(200);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(200);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(200);
                if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                {
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                if ((int)intX > 0)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                }
            }
            //降低CPU优化程度
            if (SoftMod == 1)
            {
                //设置状态
                SetState("进行CPU优化");
                //
                dm.DownCpu(Cpudown);
            }
            //
            //
            GetShopSomething_Zh(dm);
            //
            DateTime AddskillTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime kPoWN = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime GameStilLTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            double KgCoutTime = 1;
            int SearArmyCount = 3;
            //
            while (true)
            {
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                Delay(10);
                if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                {
                    return;
                }
                if ((int)GetCoadDoIngTime(false, GameStilLTime) >= 25 * 60 * 1000)//15分钟超时
                {
                    SearArmyCount = 6;
                }
                try
                {
                    Delay(10);
                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                    if ((int)intX > 0)
                    {
                        Zs_KeyP(dm, 80, 1);
                        Delay(1000);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("游戏需要重连");
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        //
                        Delay(2000);
                        return;
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, 615, 472, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, 945, 69, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                        Delay(100);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                        Delay(3000);
                        Zs_Move_R(dm, rad.Next(280, 633), rad.Next(249, 597), rad.Next(10, 40), 1);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("有本事晚上床上来");
                        //
                        Zs_Move_Clk(dm, 509, 571, 50, 1);
                        Delay(5000);
                        dm.MoveTo(0, 0);
                        if (!QQisSend)
                        {
                            try
                            {
                                this.Invoke(new Action(() =>
                                {
                                    Lab_CloseTime.Text = DateTime.Now.ToString();
                                    WriteLastGame();
                                }));
                            }
                            catch (System.Exception ex)
                            {

                            }
                            MatchCount++;
                            LoseCount++;
                            QQisSend = true;
                            if (OpenQQsend)
                            {
                                string sendstr = "[ " + MyBackUp + " ]： 本局失败 - 共进行对局：" + MatchCount + " 胜：" + WinCount + " 负：" + LoseCount + " 当前等级：" + SendClass + " 当前金币：" + SendJb + " " + SendMb + SendMbNum;
                                QQsENDER(sendstr);
                            }
                        }
                        if (GameEndWaite(dm, Lobbyhwnd))
                        {
                            return;
                        }
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("都没有一个能打的吗");
                        //
                        Zs_Move_Clk(dm, 509, 571, 50, 1);
                        Delay(5000);
                        dm.MoveTo(0, 0);
                        if (!QQisSend)
                        {
                            try
                            {
                                this.Invoke(new Action(() =>
                                {
                                    Lab_CloseTime.Text = DateTime.Now.ToString();
                                    WriteLastGame();

                                }));
                            }
                            catch (System.Exception ex)
                            {

                            }
                            MatchCount++;
                            WinCount++;
                            QQisSend = true;
                            if (OpenQQsend)
                            {
                                string sendstr = "[ " + MyBackUp + " ]： 本局胜利 - 共进行对局：" + MatchCount + " 胜：" + WinCount + " 负：" + LoseCount + " 当前等级：" + SendClass + " 当前金币：" + SendJb + " " + SendMb + SendMbNum;
                                QQsENDER(sendstr);
                            }
                        }
                        if (GameEndWaite(dm, Lobbyhwnd))
                        {
                            return;
                        }
                    }
                    Delay(10);
                    //判断死亡
                    dm.UseDict(0);
                    string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                    if (isdead != "")
                    {
                        ResetSkillArrary();
                        RoadRadom = rad.Next(0, 100);
                        if (RoadRadom < 30)
                        {
                            RoadSelect = 0;//上路
                        }
                        else if (RoadRadom >= 30 && RoadRadom < 60)
                        {
                            RoadSelect = 1;//中路
                        }
                        else
                        {
                            RoadSelect = 2;//下路
                        }
                        //
                        GetShopSomething_Zh(dm);
                        while (true)
                        {
                            //设置状态
                            SetState("角色死亡中");
                            Delay(500);
                            isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                            if (isdead == "")
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                            if ((int)intX > 0)
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                            if ((int)intX > 0)
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("游戏需要重连");
                                KillProcessByName("LolClient");
                                KillProcessByName("lol.launcher_tencent");
                                KillProcessByName("League of Legends");
                                //
                                Delay(2000);
                                return;
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, 945, 69, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                                Delay(100);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, 615, 472, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                            if ((int)intX > 0)
                            {
                                Zs_KeyP(dm, 80, 1);
                                Delay(1000);
                            }
                        }
                        //死了
                    }
                    if ((int)GetCoadDoIngTime(false, AddskillTime) >= 5 * 1000)//15秒超时
                    {
                        bool UnfindAdd = true;
                        bool findJN = true;
                        DateTime SkillOutTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                        while (findJN)
                        {
                            if ((int)GetCoadDoIngTime(false, SkillOutTime) >= 30 * 1000)//30秒超时
                            {
                                break;
                            }
                            Delay(5);
                            dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("游戏需要重连");
                                KillProcessByName("LolClient");
                                KillProcessByName("lol.launcher_tencent");
                                KillProcessByName("League of Legends");
                                //
                                Delay(2000);
                                return;
                            }
                            if (SkillDeal(dm))
                            {
                                findJN = false;
                            }
                            else
                            {
                                UnfindAdd = false;
                            }
                        }
                        if (UnfindAdd)
                        {
                            SkillUnfindTime++;
                            if (SkillUnfindTime >= 2)
                            {
                                Zs_Move_Clk(dm, 549, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 421, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 465, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 507, 650, 10, 2);
                                Delay(10);
                                dm.MoveTo(587, rad.Next(250, 650));
                                SkillUnfindTime = 0;
                            }
                        }
                        else
                        {
                            SkillUnfindTime = 0;
                        }
                        AddskillTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                    }
                    //
                    //
                    if ((int)GetCoadDoIngTime(false, kPoWN) >= KgCoutTime * 1000)//15秒超时
                    {
                        bool unfindR = true;
                        Zs_KeyP(dm, 32, rad.Next(1, 2));
                        Delay(50);
                        KgCoutTime = 0.2;
                        //检查是否发现防御塔
                        dm_ret = dm.FindPic(180, 118, 830, 631, "LongBld_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("防御塔卧槽，作死啊");
                            //
                            for (int runnum = 0; runnum < 3; runnum++)
                            {
                                TaoPao(dm, GetZy);
                                Delay(100);
                            }
                        }
                        else
                        {
                            //判断敌方英雄
                            dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                            if ((int)intX > 0)
                            {
                                SkillUnfindTime = 0;
                                unfindR = false;
                                //设置状态
                                SetState("发现敌方英雄");
                                //
                                //
                                int Yxx = (int)intX + 69;
                                int Yxy = (int)intY + 84;
                                //
                                if (!KillDfyx_Normal(dm, Yxx, Yxy))
                                {
                                    TaoPao(dm, GetZy);
                                }
                                //
                                Zs_KeyP(dm, 32, rad.Next(1, 3));
                            }
                            else
                            {
                                int DxbNum = 0;
                                int MxbyNum = 0;
                                int MyxNum = 0;
                                //确定我方英雄数量
                                string MArmyList = dm.FindPicEx(208, 118, 800, 631, "MyArmy_1.bmp", "000000", 0.8, 0);
                                if (MArmyList.Length > 0)
                                {
                                    MyxNum = MArmyList.Split('|').Length;
                                }
                                //确定小兵数量
                                Delay(5);
                                string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                                if (DxbList.Length > 0)
                                {
                                    DxbNum = DxbList.Split('|').Length;
                                }
                                Delay(5);
                                string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                                if (MxbList.Length > 0)
                                {
                                    MxbyNum = MxbList.Split('|').Length;
                                }
                                bool CanFight = false;
                                if (MxbyNum != 0 && DxbNum != 0 && DxbNum / MxbyNum <= 2)
                                {
                                    CanFight = true;
                                }
                                else if (MyxNum > 0 && DxbNum <= 8 && DxbNum != 0)
                                {
                                    CanFight = true;
                                }
                                else if (DxbNum == 0)
                                {
                                    unfindR = true;
                                }
                                else if (DxbNum > 0 && MxbyNum <= 0)
                                {
                                    //设置状态
                                    SetState("往回撤一些");
                                    //逃跑
                                    TaoPao(dm, GetZy);
                                    unfindR = false;
                                }
                                else
                                {
                                    //设置状态
                                    SetState("往回撤一些");
                                    //逃跑
                                    TaoPao(dm, GetZy);
                                    unfindR = false;
                                }
                                if (CanFight)
                                {
                                    Delay(5);
                                    //看看有没有敌方小兵
                                    dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                                    if ((int)intX > 0)
                                    {
                                        //
                                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                                        //
                                        int Dfxbx = (int)intX;
                                        int Dfxby = (int)intY;
                                        //设置状态
                                        SetState("发现敌方小兵在视线内");
                                        unfindR = false;
                                        //看看有没有我方小兵
                                        dm_ret = dm.FindPic(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现我方小兵
                                        if ((int)intX > 0)
                                        {
                                            //
                                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                                            //
                                            //设置状态
                                            SetState("发现我方小兵在视线内");
                                            Zs_KeyP(dm, 65, rad.Next(1, 3));
                                            Delay(rad.Next(10, 30));
                                            Zs_Move_Clk(dm, (int)intX + rad.Next(-5, 5), (int)intY + rad.Next(-15, 15), rad.Next(10, 30), 1);
                                            Zs_KeyP(dm, 65, rad.Next(1, 3));
                                            Delay(rad.Next(10, 30));
                                            Zs_Move_Clk(dm, Dfxbx + rad.Next(-5, 5), Dfxby + rad.Next(-5, 5), rad.Next(10, 30), rad.Next(1, 4));
                                            Delay(rad.Next(10, 30));
                                            int SkillOpenNum = SkillAry[rad.Next(0, 4)];
                                            if (SkillOpenNum != 82)
                                            {
                                                Zs_KeyP(dm, SkillOpenNum, rad.Next(1, 3));
                                                Delay(10);
                                            }
                                            dm.MoveTo(493, 367);
                                        }
                                        else
                                        {
                                            //设置状态
                                            SetState("压太前往回撤一些");
                                            //逃跑
                                            TaoPao(dm, GetZy);
                                        }
                                    }
                                }
                            }
                        }
                        if (BloodCheck(dm))
                        {
                            //设置状态
                            SetState("(血量过低)开始回城");
                            //
                            if (GoHome(dm))
                            {
                                GetShopSomething_Zh(dm);
                            }
                        }
                        if (unfindR)
                        {
                            //设置状态
                            SetState("寻找合适的带兵位置");
                            int rodx = -1;
                            int rody = -1;
                            Zhs_GetroadSafe(dm, out rodx, out rody, GetZy, SearArmyCount);
                            if (rodx != -1)
                            {
                                if (GetZy == 1)
                                {
                                    if (RoadSelect == 0)
                                    {
                                        Delay(10);
                                        Zs_Move_Clk(dm, rodx, rody + 3, 20, 1);
                                        Delay(20);
                                        Zs_Move_R(dm, rodx, rody + 3, 20, 1);
                                    }
                                    else
                                    {
                                        Delay(10);
                                        Zs_Move_Clk(dm, rodx, rody + 6, 20, 1);
                                        Delay(20);
                                        Zs_Move_R(dm, rodx, rody + 6, 20, 1);
                                    }

                                }
                                else
                                {
                                    if (RoadSelect == 0)
                                    {
                                        Delay(10);
                                        Zs_Move_Clk(dm, rodx, rody - 3, 20, 1);
                                        Delay(20);
                                        Zs_Move_R(dm, rodx, rody - 3, 20, 1);
                                    }
                                    else
                                    {
                                        Delay(10);
                                        Zs_Move_Clk(dm, rodx, rody - 6, 20, 1);
                                        Delay(20);
                                        Zs_Move_R(dm, rodx, rody - 6, 20, 1);
                                    }
                                }
                                Delay(10);
                                dm.MoveTo(493, 367);
                                Zs_KeyP(dm, 32, 1);
                            }
                            else
                            {
                                //原地搜索
                                DateTime YdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                while (true)
                                {
                                    Zs_KeyP(dm, 32, 1);
                                    Delay(rad.Next(10, 20));
                                    if ((int)GetCoadDoIngTime(false, YdTime) >= 2 * 1000)//2秒超时
                                    {
                                        break;
                                    }
                                    Delay(5);
                                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                                    if ((int)intX > 0)
                                    {
                                        Zs_KeyP(dm, 80, 1);
                                        Delay(1000);
                                    }
                                    Delay(5);
                                    dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                                    if ((int)intX > 0)
                                    {
                                        //设置状态
                                        SetState("游戏需要重连");
                                        KillProcessByName("LolClient");
                                        KillProcessByName("lol.launcher_tencent");
                                        KillProcessByName("League of Legends");
                                        //
                                        Delay(2000);
                                        return;
                                    }
                                    //检查是否发现防御塔
                                    dm_ret = dm.FindPic(180, 118, 830, 631, "LongBld_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                                    if ((int)intX > 0)
                                    {
                                        //设置状态
                                        SetState("防御塔卧槽，作死啊");
                                        //
                                        for (int runnum = 0; runnum < 3; runnum++)
                                        {
                                            TaoPao(dm, GetZy);
                                            Delay(100);
                                        }
                                        break;
                                    }
                                    int ClickCount = rad.Next(1, 6);
                                    for (int ydt = 0; ydt < ClickCount; ydt++)
                                    {
                                        Delay(10);
                                        //找敌方英雄
                                        //判断敌方英雄
                                        dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                                        if ((int)intX > 0)
                                        {
                                            unfindR = false;
                                            //设置状态
                                            SetState("发现敌方英雄");
                                            //
                                            //
                                            int Yxx = (int)intX + 69;
                                            int Yxy = (int)intY + 84;
                                            if (!KillDfyx_Normal(dm, Yxx, Yxy))
                                            {
                                                TaoPao(dm, GetZy);
                                            }
                                            //
                                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                                            //
                                        }
                                        else
                                        {
                                            bool CanstillCheck = true;
                                            int DxbNum = 0;
                                            int MxbyNum = 0;
                                            int MyxNum = 0;
                                            //确定我方英雄数量
                                            string MArmyList = dm.FindPicEx(208, 118, 800, 631, "MyArmy_1.bmp", "000000", 0.8, 0);
                                            if (MArmyList.Length > 0)
                                            {
                                                MyxNum = MArmyList.Split('|').Length;
                                            }
                                            //确定小兵数量
                                            Delay(5);
                                            string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                                            if (DxbList.Length > 0)
                                            {
                                                DxbNum = DxbList.Split('|').Length;
                                            }
                                            Delay(5);
                                            string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                                            if (MxbList.Length > 0)
                                            {
                                                MxbyNum = MxbList.Split('|').Length;
                                            }
                                            if (MxbyNum != 0 && DxbNum != 0 && DxbNum / MxbyNum < 2)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (DxbNum == 0)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (MyxNum > 0 && DxbNum <= 8 && DxbNum != 0)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (DxbNum > 0 && MxbyNum <= 0)
                                            {
                                                //设置状态
                                                SetState("往回撤一些");
                                                //逃跑
                                                TaoPao_Nq(dm, GetZy);
                                                //
                                                CanstillCheck = false;
                                            }
                                            else
                                            {
                                                //设置状态
                                                SetState("往回撤一些");
                                                //逃跑
                                                TaoPao_Nq(dm, GetZy);
                                                //
                                                CanstillCheck = false;
                                            }
                                            if (CanstillCheck)
                                            {
                                                Delay(5);
                                                //看看有没有敌方小兵
                                                dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                                                if ((int)intX > 0)
                                                {
                                                    //
                                                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                                                    //
                                                    int Dfxbx = (int)intX;
                                                    int Dfxby = (int)intY;
                                                    //设置状态
                                                    SetState("发现敌方小兵在视线内");
                                                    unfindR = false;
                                                    //看看有没有我方小兵
                                                    dm_ret = dm.FindPic(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现我方小兵
                                                    if ((int)intX > 0)
                                                    {
                                                        //
                                                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                                                        //
                                                        //设置状态
                                                        SetState("发现我方小兵在视线内");
                                                        Zs_KeyP(dm, 65, rad.Next(1, 3));
                                                        Delay(rad.Next(10, 30));
                                                        Zs_Move_Clk(dm, (int)intX + rad.Next(-5, 5), (int)intY + rad.Next(-5, 5), rad.Next(10, 30), 1);
                                                        Zs_KeyP(dm, 65, rad.Next(1, 3));
                                                        Delay(rad.Next(10, 30));
                                                        Zs_Move_Clk(dm, Dfxbx + rad.Next(-5, 5), Dfxby + rad.Next(-5, 5), rad.Next(10, 30), rad.Next(1, 4));
                                                        Delay(rad.Next(10, 30));
                                                        int SkillOpenNum = SkillAry[rad.Next(0, 4)];
                                                        if (SkillOpenNum != 82)
                                                        {
                                                            Zs_KeyP(dm, SkillOpenNum, rad.Next(1, 3));
                                                            Delay(10);
                                                        }
                                                        dm.MoveTo(493, 367);
                                                    }
                                                    else
                                                    {
                                                        //设置状态
                                                        SetState("压太前往回撤一些");
                                                        //逃跑
                                                        TaoPao_Nq(dm, GetZy);
                                                    }
                                                }
                                                else
                                                {
                                                    int Sbmod = 0;
                                                    if (GetZy == 1)
                                                    {
                                                        Sbmod = 1;
                                                    }
                                                    else
                                                    {
                                                        Sbmod = 2;
                                                    }
                                                    bool StillClick = false;
                                                    string dm_ret_string = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, Sbmod);
                                                    //设置状态
                                                    if (dm_ret_string.Length > 0)
                                                    {
                                                        if (dm_ret_string.Split('|').Length > 2)
                                                        {
                                                            Zs_KeyP(dm, 32, 1);
                                                            Delay(10);
                                                            int ClickX = int.Parse(dm_ret_string.Split('|')[1].Split(',')[1]);
                                                            int ClickY = int.Parse(dm_ret_string.Split('|')[1].Split(',')[2]);
                                                            Zs_Move_R(dm, ClickX, ClickY, rad.Next(10, 30), 2);
                                                            Delay(10);
                                                            dm.MoveTo(493, 367);
                                                            YdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                                            StillClick = false;
                                                        }
                                                        else
                                                        {
                                                            StillClick = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        StillClick = true;
                                                    }
                                                    //可以往交战点集合
                                                    if (StillClick)
                                                    {
                                                        if (GetZy == 2)
                                                        {
                                                            if (RoadSelect == 0)
                                                            {
                                                                Zs_Move_R(dm, 850, 634, rad.Next(10, 20), 1);
                                                            }
                                                            else if (RoadSelect == 1)
                                                            {
                                                                Zs_Move_R(dm, 913, 682, rad.Next(10, 20), 1);
                                                            }
                                                            else if (RoadSelect == 2)
                                                            {
                                                                Zs_Move_R(dm, 974, 749, rad.Next(10, 20), 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (RoadSelect == 0)
                                                            {
                                                                Zs_Move_R(dm, 887, 590, rad.Next(10, 20), 1);
                                                            }
                                                            else if (RoadSelect == 1)
                                                            {
                                                                Zs_Move_R(dm, 944, 660, rad.Next(10, 20), 1);
                                                            }
                                                            else if (RoadSelect == 2)
                                                            {
                                                                Zs_Move_R(dm, 1005, 711, rad.Next(10, 20), 1);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (BloodCheck(dm))
                                    {
                                        //设置状态
                                        SetState("(血量过低)开始回城");
                                        //
                                        if (GoHome(dm))
                                        {
                                            GetShopSomething_Zh(dm);
                                        }
                                    }
                                    Delay(rad.Next(100, 300));
                                }
                            }
                        }
                        kPoWN = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                    }
                    //
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("线程错误:" + ex.Message);
                    Delay(3000);
                }
            }
        }
        /// <summary>
        /// 游戏中处理 - 扭曲
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="Lobbyhwnd"></param>
        private void Nq_Game(CDmSoft dm, int Lobbyhwnd)
        {
            dm.EnableRealMouse(1, 10, 50);
            dm.EnableRealKeypad(1);
            //大漠通用
            object intX, intY;
            int dm_ret = 0;
            dm.SetPath(".\\attachment");
            dm_ret = dm.SetShowErrorMsg(0);
            dm_ret = dm.SetPicPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDictPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDict(0, "Onerd_GamDeadzk.txt");
            dm_ret = dm.SetDict(1, "Onerd_Blood.txt");
            dm_ret = dm.UnBindWindow();
            dm.SetWindowState(Lobbyhwnd, 1);
            Delay(100);
            //移动窗口到左上角
            dm.MoveWindow(Lobbyhwnd, 0, 0);
            Delay(100);
            //进行绑定
            if (SoftMod == 0)//前台
            {
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "normal", "normal", "normal", "dx.public.disable.window.minmax", 101);//      
            }
            else
            {
                //
                for (int i = 0; i < 3; i++)
                {
                    dm.SetWindowState(Lobbyhwnd, 1);
                    Delay(100);
                    //移动窗口到左上角
                    dm.MoveWindow(Lobbyhwnd, -10, -1);
                    Delay(100);
                }
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "gdi", "dx.mouse.position.lock.api|dx.mouse.position.lock.message|dx.mouse.clip.lock.api|dx.mouse.input.lock.api|dx.mouse.state.api|dx.mouse.api|dx.mouse.cursor", "dx.keypad.input.lock.api|dx.keypad.state.api|dx.keypad.api", "dx.public.active.api|dx.public.down.cpu", 101);//   
            }
            if (dm_ret != 1)
            {
                int Errormsg = dm.GetLastError();
                Delay(5000);
                dm.UnBindWindow();
                return;
            }
            //设置状态
            SetState("检测游戏窗口成功");
            //
            //是否识别到阵营
            int GetZy = 0;
            //
            bool FindIngame = false;
            int UngetZycount = 0;
            bool QQisSend = false;
            int SkillUnfindTime = 0;
            bool UnNeedLock = false;
            while (true)
            {
                KillProcessByName("iexplore");
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏需要重连");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    //
                    Delay(2000);
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(816, 531, 922, 588, "intGame_1.bmp|intGame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经进入游戏
                if ((int)intX > 0)
                {
                    FindIngame = true;
                }
                Delay(200);
                dm_ret = dm.FindPic(70, 668, 99, 765, "Ft_1_2.bmp|Ft_2.bmp|Ft_3.bmp|Ft_4.bmp|Ft_5.bmp|Ft_6.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经进入游戏
                if ((int)intX > 0)
                {
                    FindIngame = true;
                    UnNeedLock = true;
                }
                Delay(200);
                dm_ret = dm.FindPic(101, 345, 622, 420, "Sm_Tip_1.bmp|Vs_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏在载入
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏正在载入中");
                    //
                    Delay(4000);
                    dm.MoveTo(0, 0);
                }
                if (GetZy != 0)
                {
                    if (UnNeedLock)
                    {
                        //设置状态
                        SetState("正式开始游戏对局");
                        //
                        break;
                    }
                    //识别阵营
                    Delay(200);
                    dm_ret = dm.FindPic(972, 534, 1018, 588, "Lock_1.bmp|Lock_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现视角没有锁定
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("正式开始游戏对局");
                        //
                        break;
                    }
                    else
                    {
                        Zs_KeyP(dm, 89, 1);
                        Delay(1000);
                    }
                }
                if (FindIngame)
                {
                    //设置状态
                    SetState("阵营识别中");
                    Delay(200);
                    //识别阵营
                    dm_ret = dm.FindPic(831, 640, 879, 700, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//左边阵营
                    if ((int)intX > 0)
                    {
                        //
                        Tpzsx = int.Parse(RunaayZb[3].Split(',')[0]);
                        Tpzxy = int.Parse(RunaayZb[3].Split(',')[1]);
                        Tpyxx = int.Parse(RunaayZb[3].Split(',')[2]);
                        Tpyxy = int.Parse(RunaayZb[3].Split(',')[3]);
                        //
                        Nq_sb_Sl[0] = "852,664,874,736";
                        Nq_sb_Sl[1] = "874,641,944,669";
                        Nq_sb_Sl[2] = "944,664,1018,682";
                        Nq_sb_Sl[3] = "984,679,1017,708";
                        //
                        Nq_sb_Xl[0] = "852,664,874,736";
                        Nq_sb_Xl[1] = "874,695,945,712";
                        Nq_sb_Xl[2] = "945,715,1003,739";
                        Nq_sb_Xl[3] = "978,690,1013,720";
                        //
                        //设置状态
                        SetState("我方在左边阵营");
                        Delay(2000);
                        //
                        GetZy = 1;
                    }
                    Delay(200);
                    //识别阵营
                    dm_ret = dm.FindPic(977, 650, 1022, 697, "Jd_1.bmp|Jd_2.bmp|Jd_3.bmp|Jd_4.bmp|Zh_hc_1.bmp", "000000", 0.8, 0, out intX, out intY);//右边阵营
                    if ((int)intX > 0)
                    {
                        //
                        Tpzsx = int.Parse(RunaayZb[4].Split(',')[0]);
                        Tpzxy = int.Parse(RunaayZb[4].Split(',')[1]);
                        Tpyxx = int.Parse(RunaayZb[4].Split(',')[2]);
                        Tpyxy = int.Parse(RunaayZb[4].Split(',')[3]);
                        //
                        Nq_sb_Sl[0] = "979,658,1006,740";
                        Nq_sb_Sl[1] = "905,636,978,669";
                        Nq_sb_Sl[2] = "855,662,909,682";
                        Nq_sb_Sl[3] = "853,674,882,708";
                        //
                        Nq_sb_Xl[0] = "979,658,1006,740";
                        Nq_sb_Xl[1] = "910,699,979,713";
                        Nq_sb_Xl[2] = "854,717,908,738";
                        Nq_sb_Xl[3] = "854,686,882,722";
                        //
                        //设置状态
                        SetState("我方在右边阵营");
                        Delay(2000);
                        //
                        GetZy = 2;
                    }
                    if (GetZy == 0)
                    {
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                        if (!GameModDeal(dm, GameMod))
                        {
                            return;
                        }
                        UngetZycount++;
                        if (UngetZycount > 3)
                        {
                            //设置状态
                            SetState("地图模式自动校正");
                            //
                            GameMod = 0;
                            return;
                        }
                        Zs_KeyP(dm, 66, 1);
                        Delay(1500);
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                    }
                }
                Delay(200);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    break;
                }
                Delay(200);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    break;
                }
                Delay(200);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(200);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(200);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(200);
                if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                {
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                if ((int)intX > 0)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                }
            }
            int RoadRadom = rad.Next(0, 100);
            if (RoadRadom < 50)
            {
                RoadSelect_Nq = 0;//上路
            }
            else
            {
                RoadSelect_Nq = 1;//下路
            }
            //降低CPU优化程度
            if (SoftMod == 1)
            {
                //设置状态
                SetState("进行CPU优化");
                //
                dm.DownCpu(Cpudown);
            }
            //正式进入执行
            GetShopSomething_Tz(dm);
            DateTime GameStilLTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime AddskillTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime kPoWN = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            double KgCoutTime = 1;
            int SearArmyCount = 2;
            //
            while (true)
            {
                //正式进入运行
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                Delay(10);
                if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                {
                    return;
                }
                if ((int)GetCoadDoIngTime(false, GameStilLTime) >= 25 * 60 * 1000)//15分钟超时
                {
                    SearArmyCount = 4;
                }
                try
                {
                    Delay(10);
                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                    if ((int)intX > 0)
                    {
                        Zs_KeyP(dm, 80, 1);
                        Delay(1000);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("游戏需要重连");
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        //
                        Delay(2000);
                        return;
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, 615, 472, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, 945, 69, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                        Delay(100);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                        Delay(3000);
                        Zs_Move_R(dm, rad.Next(280, 633), rad.Next(249, 597), rad.Next(10, 40), 1);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("有本事晚上床上来");
                        //
                        Zs_Move_Clk(dm, 509, 571, 50, 1);
                        Delay(5000);
                        dm.MoveTo(0, 0);
                        if (!QQisSend)
                        {
                            try
                            {
                                this.Invoke(new Action(() =>
                                {
                                    Lab_CloseTime.Text = DateTime.Now.ToString();
                                    WriteLastGame();
                                }));
                            }
                            catch (System.Exception ex)
                            {

                            }
                            MatchCount++;
                            LoseCount++;
                            QQisSend = true;
                            if (OpenQQsend)
                            {
                                string sendstr = "[ " + MyBackUp + " ]： 本局失败 - 共进行对局：" + MatchCount + " 胜：" + WinCount + " 负：" + LoseCount + " 当前等级：" + SendClass + " 当前金币：" + SendJb + " " + SendMb + SendMbNum;
                                QQsENDER(sendstr);
                            }
                        }
                        if (GameEndWaite(dm, Lobbyhwnd))
                        {
                            return;
                        }
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("都没有一个能打的吗");
                        //
                        Zs_Move_Clk(dm, 509, 571, 50, 1);
                        Delay(5000);
                        dm.MoveTo(0, 0);
                        if (!QQisSend)
                        {
                            try
                            {
                                this.Invoke(new Action(() =>
                                {
                                    Lab_CloseTime.Text = DateTime.Now.ToString();
                                    WriteLastGame();

                                }));
                            }
                            catch (System.Exception ex)
                            {

                            }
                            MatchCount++;
                            WinCount++;
                            QQisSend = true;
                            if (OpenQQsend)
                            {
                                string sendstr = "[ " + MyBackUp + " ]： 本局胜利 - 共进行对局：" + MatchCount + " 胜：" + WinCount + " 负：" + LoseCount + " 当前等级：" + SendClass + " 当前金币：" + SendJb + " " + SendMb + SendMbNum;
                                QQsENDER(sendstr);
                            }
                        }
                        if (GameEndWaite(dm, Lobbyhwnd))
                        {
                            return;
                        }
                    }
                    Delay(10);
                    //判断死亡
                    dm.UseDict(0);
                    string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                    if (isdead != "")
                    {
                        ResetSkillArrary();
                        //
                        GetShopSomething_Tz(dm);
                        while (true)
                        {
                            //设置状态
                            SetState("角色死亡中");
                            Delay(500);
                            isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                            if (isdead == "")
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                            if ((int)intX > 0)
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                            if ((int)intX > 0)
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("游戏需要重连");
                                KillProcessByName("LolClient");
                                KillProcessByName("lol.launcher_tencent");
                                KillProcessByName("League of Legends");
                                //
                                Delay(2000);
                                return;
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, 945, 69, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                                Delay(100);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, 615, 472, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                            if ((int)intX > 0)
                            {
                                Zs_KeyP(dm, 80, 1);
                                Delay(1000);
                            }
                        }
                        //死了
                    }
                    if ((int)GetCoadDoIngTime(false, AddskillTime) >= 5 * 1000)//15秒超时
                    {
                        bool UnfindAdd = true;
                        bool findJN = true;
                        DateTime SkillOutTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                        while (findJN)
                        {
                            if ((int)GetCoadDoIngTime(false, SkillOutTime) >= 30 * 1000)//30秒超时
                            {
                                break;
                            }
                            Delay(5);
                            dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("游戏需要重连");
                                KillProcessByName("LolClient");
                                KillProcessByName("lol.launcher_tencent");
                                KillProcessByName("League of Legends");
                                //
                                Delay(2000);
                                return;
                            }
                            if (SkillDeal(dm))
                            {
                                findJN = false;
                            }
                            else
                            {
                                UnfindAdd = false;
                            }
                        }
                        if (UnfindAdd)
                        {
                            SkillUnfindTime++;
                            if (SkillUnfindTime >= 2)
                            {
                                Zs_Move_Clk(dm, 549, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 421, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 465, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 507, 650, 10, 2);
                                Delay(10);
                                dm.MoveTo(587, rad.Next(250, 650));
                                SkillUnfindTime = 0;
                            }
                        }
                        else
                        {
                            SkillUnfindTime = 0;
                        }
                        AddskillTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                    }
                    if ((int)GetCoadDoIngTime(false, kPoWN) >= KgCoutTime * 1000)//15秒超时
                    {
                        bool unfindR = true;
                        Zs_KeyP(dm, 32, rad.Next(1, 2));
                        Delay(50);
                        KgCoutTime = 0.3;
                        //检查是否发现防御塔
                        dm_ret = dm.FindPic(180, 118, 830, 631, "LongBld_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("防御塔卧槽，作死啊");
                            //
                            for (int runnum = 0; runnum < 3; runnum++)
                            {
                                TaoPao_Nq(dm, GetZy);
                                Delay(100);
                            }
                        }
                        else
                        {
                            //判断敌方英雄 
                            dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                            if ((int)intX > 0)
                            {
                                SkillUnfindTime = 0;
                                unfindR = false;
                                //设置状态
                                SetState("发现敌方英雄");
                                //
                                //
                                int Yxx = (int)intX + 69;
                                int Yxy = (int)intY + 84;
                                if (!KillDfyx_Normal(dm, Yxx, Yxy))
                                {
                                    TaoPao_Nq(dm, GetZy);
                                }
                                //
                                Zs_KeyP(dm, 32, rad.Next(1, 3));
                                //
                            }
                            else
                            {
                                int DxbNum = 0;
                                int MxbyNum = 0;
                                int MyxNum = 0;
                                //确定我方英雄数量
                                string MArmyList = dm.FindPicEx(208, 118, 800, 631, "MyArmy_1.bmp", "000000", 0.8, 0);
                                if (MArmyList.Length > 0)
                                {
                                    MyxNum = MArmyList.Split('|').Length;
                                }
                                //确定小兵数量
                                Delay(5);
                                string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                                if (DxbList.Length > 0)
                                {
                                    DxbNum = DxbList.Split('|').Length;
                                }
                                Delay(5);
                                string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                                if (MxbList.Length > 0)
                                {
                                    MxbyNum = MxbList.Split('|').Length;
                                }
                                bool CanFight = false;
                                if (MxbyNum != 0 && DxbNum != 0 && DxbNum / MxbyNum <= 2)
                                {
                                    CanFight = true;
                                }
                                else if (MyxNum > 0 && DxbNum <= 8 && DxbNum != 0)
                                {
                                    CanFight = true;
                                }
                                else if (DxbNum == 0)
                                {
                                    unfindR = true;
                                }
                                else if (DxbNum > 0 && MxbyNum <= 0)
                                {
                                    //设置状态
                                    SetState("往回撤一些");
                                    //逃跑
                                    TaoPao_Nq(dm, GetZy);
                                    unfindR = false;
                                }
                                else
                                {
                                    //设置状态
                                    SetState("往回撤一些");
                                    //逃跑
                                    TaoPao_Nq(dm, GetZy);
                                    unfindR = false;
                                }
                                if (CanFight)
                                {
                                    Delay(5);
                                    //看看有没有敌方小兵
                                    dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                                    if ((int)intX > 0)
                                    {
                                        //
                                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                                        //
                                        int Dfxbx = (int)intX;
                                        int Dfxby = (int)intY;
                                        //设置状态
                                        SetState("发现敌方小兵在视线内");
                                        unfindR = false;
                                        //看看有没有我方小兵
                                        dm_ret = dm.FindPic(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现我方小兵
                                        if ((int)intX > 0)
                                        {
                                            //
                                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                                            //
                                            //设置状态
                                            SetState("发现我方小兵在视线内");
                                            Zs_KeyP(dm, 65, rad.Next(1, 3));
                                            Delay(rad.Next(10, 30));
                                            Zs_Move_Clk(dm, (int)intX + rad.Next(-5, 5), (int)intY + rad.Next(-5, 5), rad.Next(10, 30), 1);
                                            Zs_KeyP(dm, 65, rad.Next(1, 3));
                                            Delay(rad.Next(10, 30));
                                            Zs_Move_Clk(dm, Dfxbx + rad.Next(-5, 5), Dfxby + rad.Next(-5, 5), rad.Next(10, 30), rad.Next(1, 4));
                                            Delay(rad.Next(10, 30));
                                            int SkillOpenNum = SkillAry[rad.Next(0, 4)];
                                            if (SkillOpenNum != 82)
                                            {
                                                Zs_KeyP(dm, SkillOpenNum, rad.Next(1, 3));
                                                Delay(10);
                                            }
                                            dm.MoveTo(493, 367);
                                        }
                                        else
                                        {
                                            //设置状态
                                            SetState("压太前往回撤一些");
                                            //逃跑
                                            TaoPao_Nq(dm, GetZy);
                                        }
                                    }
                                }
                            }
                        }
                        if (BloodCheck(dm))
                        {
                            //设置状态
                            SetState("(血量过低)开始回城");
                            //
                            if (GoHome(dm))
                            {
                                GetShopSomething_Tz(dm);
                            }
                        }
                        if (unfindR)
                        {
                            //设置状态
                            SetState("寻找合适的带兵位置");
                            int rodx = -1;
                            int rody = -1;
                            Nq_GetroadSafe(dm, out rodx, out rody, GetZy, SearArmyCount);
                            if (rodx != -1)
                            {
                                if (GetZy == 1)
                                {
                                    if (RoadSelect_Nq == 0)
                                    {
                                        Delay(10);
                                        Zs_Move_Clk(dm, rodx, rody - 5, 20, 1);
                                        Delay(20);
                                        Zs_Move_R(dm, rodx, rody - 5, 20, 1);
                                    }
                                    else
                                    {
                                        Delay(10);
                                        Zs_Move_Clk(dm, rodx, rody - 5, 20, 1);
                                        Delay(20);
                                        Zs_Move_R(dm, rodx, rody - 5, 20, 1);
                                    }

                                }
                                else
                                {
                                    if (RoadSelect_Nq == 0)
                                    {
                                        Delay(10);
                                        Zs_Move_Clk(dm, rodx, rody + 5, 20, 1);
                                        Delay(20);
                                        Zs_Move_R(dm, rodx, rody + 5, 20, 1);
                                    }
                                    else
                                    {
                                        Delay(10);
                                        Zs_Move_Clk(dm, rodx, rody + 5, 20, 1);
                                        Delay(20);
                                        Zs_Move_R(dm, rodx, rody + 5, 20, 1);
                                    }
                                }
                                dm.MoveTo(493, 367);
                                Zs_KeyP(dm, 32, 1);
                            }
                            else
                            {
                                //前进到指定地点
                                DateTime YdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                while (true)
                                {
                                    Zs_KeyP(dm, 32, 1);
                                    Delay(rad.Next(10, 20));
                                    if ((int)GetCoadDoIngTime(false, YdTime) >= 2 * 1000)//2秒超时
                                    {
                                        break;
                                    }
                                    Delay(5);
                                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                                    if ((int)intX > 0)
                                    {
                                        Zs_KeyP(dm, 80, 1);
                                        Delay(1000);
                                    }
                                    Delay(5);
                                    dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                                    if ((int)intX > 0)
                                    {
                                        //设置状态
                                        SetState("游戏需要重连");
                                        KillProcessByName("LolClient");
                                        KillProcessByName("lol.launcher_tencent");
                                        KillProcessByName("League of Legends");
                                        //
                                        Delay(2000);
                                        return;
                                    }
                                    //检查是否发现防御塔
                                    dm_ret = dm.FindPic(180, 118, 830, 631, "LongBld_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                                    if ((int)intX > 0)
                                    {
                                        //设置状态
                                        SetState("防御塔卧槽，作死啊");
                                        //
                                        for (int runnum = 0; runnum < 3; runnum++)
                                        {
                                            TaoPao_Nq(dm, GetZy);
                                            Delay(100);
                                        }
                                        break;
                                    }
                                    int ClickCount = rad.Next(1, 6);
                                    for (int ydt = 0; ydt < ClickCount; ydt++)
                                    {
                                        Delay(10);
                                        //找敌方英雄
                                        //判断敌方英雄
                                        dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                                        if ((int)intX > 0)
                                        {
                                            unfindR = false;
                                            //设置状态
                                            SetState("发现敌方英雄");
                                            //
                                            //
                                            int Yxx = (int)intX + 69;
                                            int Yxy = (int)intY + 84;
                                            if (!KillDfyx_Normal(dm, Yxx, Yxy))
                                            {
                                                TaoPao_Nq(dm, GetZy);
                                            }
                                            //
                                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                                            //
                                        }
                                        else
                                        {
                                            bool CanstillCheck = true;
                                            int DxbNum = 0;
                                            int MxbyNum = 0;
                                            int MyxNum = 0;
                                            //确定我方英雄数量
                                            string MArmyList = dm.FindPicEx(208, 118, 800, 631, "MyArmy_1.bmp", "000000", 0.8, 0);
                                            if (MArmyList.Length > 0)
                                            {
                                                MyxNum = MArmyList.Split('|').Length;
                                            }
                                            //确定小兵数量
                                            Delay(5);
                                            string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                                            if (DxbList.Length > 0)
                                            {
                                                DxbNum = DxbList.Split('|').Length;
                                            }
                                            Delay(5);
                                            string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                                            if (MxbList.Length > 0)
                                            {
                                                MxbyNum = MxbList.Split('|').Length;
                                            }
                                            if (MxbyNum != 0 && DxbNum != 0 && DxbNum / MxbyNum < 2)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (DxbNum == 0)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (MyxNum > 0 && DxbNum <= 8 && DxbNum != 0)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (DxbNum > 0 && MxbyNum <= 0)
                                            {
                                                //设置状态
                                                SetState("往回撤一些");
                                                //逃跑
                                                TaoPao_Nq(dm, GetZy);
                                                //
                                                CanstillCheck = false;
                                            }
                                            else
                                            {
                                                //设置状态
                                                SetState("往回撤一些");
                                                //逃跑
                                                TaoPao_Nq(dm, GetZy);
                                                //
                                                CanstillCheck = false;
                                            }
                                            if (CanstillCheck)
                                            {
                                                Delay(5);
                                                //看看有没有敌方小兵
                                                dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                                                if ((int)intX > 0)
                                                {
                                                    //
                                                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                                                    //
                                                    int Dfxbx = (int)intX;
                                                    int Dfxby = (int)intY;
                                                    //设置状态
                                                    SetState("发现敌方小兵在视线内");
                                                    unfindR = false;
                                                    //看看有没有我方小兵
                                                    dm_ret = dm.FindPic(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现我方小兵
                                                    if ((int)intX > 0)
                                                    {
                                                        //
                                                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                                                        //
                                                        //设置状态
                                                        SetState("发现我方小兵在视线内");
                                                        Zs_KeyP(dm, 65, rad.Next(1, 3));
                                                        Delay(rad.Next(10, 30));
                                                        Zs_Move_Clk(dm, (int)intX + rad.Next(-5, 5), (int)intY + rad.Next(-5, 5), rad.Next(10, 30), 1);
                                                        Zs_KeyP(dm, 65, rad.Next(1, 3));
                                                        Delay(rad.Next(10, 30));
                                                        Zs_Move_Clk(dm, Dfxbx + rad.Next(-5, 5), Dfxby + rad.Next(-5, 5), rad.Next(10, 30), rad.Next(1, 4));
                                                        Delay(rad.Next(10, 30));
                                                        int SkillOpenNum = SkillAry[rad.Next(0, 4)];
                                                        if (SkillOpenNum != 82)
                                                        {
                                                            Zs_KeyP(dm, SkillOpenNum, rad.Next(1, 3));
                                                            Delay(10);
                                                        }
                                                        dm.MoveTo(493, 367);
                                                    }
                                                    else
                                                    {
                                                        //设置状态
                                                        SetState("压太前往回撤一些");
                                                        //逃跑
                                                        TaoPao_Nq(dm, GetZy);
                                                    }
                                                }
                                                else
                                                {
                                                    int Sbmod = 0;
                                                    if (GetZy == 1)
                                                    {
                                                        Sbmod = 3;
                                                    }
                                                    else
                                                    {
                                                        Sbmod = 1;
                                                    }
                                                    bool StillClick = false;
                                                    string dm_ret_string = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, Sbmod);
                                                    //设置状态
                                                    if (dm_ret_string.Length > 0)
                                                    {
                                                        if (dm_ret_string.Split('|').Length > 2)
                                                        {
                                                            Zs_KeyP(dm, 32, 1);
                                                            Delay(10);
                                                            int ClickX = int.Parse(dm_ret_string.Split('|')[1].Split(',')[1]);
                                                            int ClickY = int.Parse(dm_ret_string.Split('|')[1].Split(',')[2]);
                                                            Zs_Move_R(dm, ClickX, ClickY, rad.Next(10, 30), 2);
                                                            Delay(10);
                                                            dm.MoveTo(493, 367);
                                                            YdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                                            StillClick = false;
                                                        }
                                                        else
                                                        {
                                                            StillClick = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        StillClick = true;
                                                    }
                                                    //可以往交战点集合
                                                    if (StillClick)
                                                    {
                                                        if (GetZy == 1)
                                                        {
                                                            if (RoadSelect_Nq == 0)
                                                            {
                                                                Zs_Move_R(dm, 890, 651, rad.Next(10, 20), 1);
                                                            }
                                                            else
                                                            {
                                                                Zs_Move_R(dm, 892, 709, rad.Next(10, 20), 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (RoadSelect_Nq == 0)
                                                            {
                                                                Zs_Move_R(dm, 964, 648, rad.Next(10, 20), 1);
                                                            }
                                                            else
                                                            {
                                                                Zs_Move_R(dm, 962, 708, rad.Next(10, 20), 1);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (BloodCheck(dm))
                                    {
                                        //设置状态
                                        SetState("(血量过低)开始回城");
                                        //
                                        if (GoHome(dm))
                                        {
                                            GetShopSomething_Tz(dm);
                                        }
                                    }
                                    Delay(rad.Next(10, 30));
                                }
                            }
                        }
                        kPoWN = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                    }
                    //
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("线程错误:" + ex.Message);
                    Delay(3000);
                }
            }
        }
        /// <summary>
        /// 游戏中处理 - 极地
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="Lobbyhwnd"></param>
        private void Jd_Game(CDmSoft dm, int Lobbyhwnd)
        {
            dm.EnableRealMouse(1, 10, 50);
            dm.EnableRealKeypad(1);
            //大漠通用
            object intX, intY;
            int dm_ret = 0;
            dm.SetPath(".\\attachment");
            dm_ret = dm.SetShowErrorMsg(0);
            dm_ret = dm.SetPicPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDictPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDict(0, "Onerd_GamDeadzk.txt");
            dm_ret = dm.SetDict(1, "Onerd_Blood.txt");
            dm_ret = dm.UnBindWindow();
            dm.SetWindowState(Lobbyhwnd, 1);
            Delay(100);
            //移动窗口到左上角
            dm.MoveWindow(Lobbyhwnd, 0, 0);
            Delay(100);
            //进行绑定
            if (SoftMod == 0)//前台
            {
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "normal", "normal", "normal", "dx.public.disable.window.minmax", 101);//      
            }
            else
            {
                //
                for (int i = 0; i < 3; i++)
                {
                    dm.SetWindowState(Lobbyhwnd, 1);
                    Delay(100);
                    //移动窗口到左上角
                    dm.MoveWindow(Lobbyhwnd, -10, -1);
                    Delay(100);
                }
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "gdi", "dx.mouse.position.lock.api|dx.mouse.position.lock.message|dx.mouse.clip.lock.api|dx.mouse.input.lock.api|dx.mouse.state.api|dx.mouse.api|dx.mouse.cursor", "dx.keypad.input.lock.api|dx.keypad.state.api|dx.keypad.api", "dx.public.active.api|dx.public.down.cpu", 101);//   
            }
            if (dm_ret != 1)
            {
                int Errormsg = dm.GetLastError();
                Delay(5000);
                dm.UnBindWindow();
                return;
            }
            //设置状态
            SetState("检测游戏窗口成功");
            //
            //是否识别到阵营
            int GetZy = 0;
            //
            bool FindIngame = false;
            int UngetZycount = 0;
            bool QQisSend = false;
            int SkillUnfindTime = 0;
            bool UnNeedLock = false;
            while (true)
            {
                KillProcessByName("iexplore");
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏需要重连");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    //
                    Delay(2000);
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(816, 531, 922, 588, "intGame_1.bmp|intGame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经进入游戏
                if ((int)intX > 0)
                {
                    FindIngame = true;
                }
                Delay(200);
                dm_ret = dm.FindPic(70, 668, 99, 765, "Ft_1_2.bmp|Ft_2.bmp|Ft_3.bmp|Ft_4.bmp|Ft_5.bmp|Ft_6.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经进入游戏
                if ((int)intX > 0)
                {
                    FindIngame = true;
                    UnNeedLock = true;
                }
                Delay(200);
                dm_ret = dm.FindPic(101, 345, 622, 420, "Sm_Tip_1.bmp|Vs_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏在载入
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏正在载入中");
                    //
                    Delay(4000);
                    dm.MoveTo(0, 0);
                }
                if (GetZy != 0)
                {
                    if (UnNeedLock)
                    {
                        //设置状态
                        SetState("正式开始游戏对局");
                        //
                        break;
                    }
                    //识别阵营
                    Delay(200);
                    dm_ret = dm.FindPic(972, 534, 1018, 588, "Lock_1.bmp|Lock_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现视角没有锁定
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("正式开始游戏对局");
                        //
                        break;
                    }
                    else
                    {
                        Zs_KeyP(dm, 89, 1);
                        Delay(1000);
                    }
                }
                if (FindIngame)
                {
                    //设置状态
                    SetState("阵营识别中");
                    Delay(200);
                    //识别阵营
                    dm_ret = dm.FindPic(832, 714, 880, 761, "Jdzy_1.bmp", "000000", 0.8, 0, out intX, out intY);//左下角阵营
                    if ((int)intX > 0)
                    {
                        //
                        Tpzsx = int.Parse(RunaayZb[5].Split(',')[0]);
                        Tpzxy = int.Parse(RunaayZb[5].Split(',')[1]);
                        Tpyxx = int.Parse(RunaayZb[5].Split(',')[2]);
                        Tpyxy = int.Parse(RunaayZb[5].Split(',')[3]);
                        //
                        Jd_Sb_road[0] = "848,714,885,744";
                        Jd_Sb_road[1] = "867,698,903,726";
                        Jd_Sb_road[2] = "894,667,932,702";

                        Jd_Sb_road[3] = "922,642,958,676";
                        Jd_Sb_road[4] = "945,621,981,650";
                        Jd_Sb_road[5] = "966,598,1006,632";
                        //
                        //设置状态
                        SetState("我方在左下角阵营");
                        Delay(2000);
                        //
                        GetZy = 1;
                    }
                    Delay(200);
                    //识别阵营
                    dm_ret = dm.FindPic(963, 576, 1020, 619, "Jdzy_2.bmp|Jdzy_3.bmp", "000000", 0.8, 0, out intX, out intY);//右边阵营
                    if ((int)intX > 0)
                    {
                        //
                        Tpzsx = int.Parse(RunaayZb[6].Split(',')[0]);
                        Tpzxy = int.Parse(RunaayZb[6].Split(',')[1]);
                        Tpyxx = int.Parse(RunaayZb[6].Split(',')[2]);
                        Tpyxy = int.Parse(RunaayZb[6].Split(',')[3]);
                        //
                        Jd_Sb_road[0] = "963,607,993,632";
                        Jd_Sb_road[1] = "938,629,974,659";
                        Jd_Sb_road[2] = "919,656,945,678";

                        Jd_Sb_road[3] = "895,676,924,700";
                        Jd_Sb_road[4] = "878,693,908,721";
                        Jd_Sb_road[5] = "851,713,885,748";

                        //
                        //设置状态
                        SetState("我方在右上角阵营");
                        Delay(2000);
                        //
                        GetZy = 2;
                    }
                    //

                    //
                    if (GetZy == 0)
                    {
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                        if (!GameModDeal(dm, GameMod))
                        {
                            return;
                        }
                        UngetZycount++;
                        if (UngetZycount > 3)
                        {
                            //设置状态
                            SetState("地图模式自动校正");
                            //
                            GameMod = 0;
                            return;
                        }
                        Zs_KeyP(dm, 66, 1);
                        Delay(1500);
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                    }
                }
                Delay(200);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    break;
                }
                Delay(200);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    break;
                }
                Delay(200);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(200);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(200);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(200);
                if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                {
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                if ((int)intX > 0)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                }
            }
            //降低CPU优化程度
            if (SoftMod == 1)
            {
                //设置状态
                SetState("进行CPU优化");
                //
                dm.DownCpu(Cpudown);
            }
            //正式进入执行
            GetShopSomething_Tz(dm);
            DateTime GameStilLTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime AddskillTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime kPoWN = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            double KgCoutTime = 1;
            int SearArmyCount = 3;
            //
            while (true)
            {
                //正式进入运行
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                Delay(10);
                if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                {
                    return;
                }
                if ((int)GetCoadDoIngTime(false, GameStilLTime) >= 20 * 60 * 1000)//15分钟超时
                {
                    SearArmyCount = 6;
                }
                try
                {
                    Delay(10);
                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                    if ((int)intX > 0)
                    {
                        Zs_KeyP(dm, 80, 1);
                        Delay(1000);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("游戏需要重连");
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        //
                        Delay(2000);
                        return;
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, 615, 472, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, 945, 69, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                        Delay(100);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                        Delay(3000);
                        Zs_Move_R(dm, rad.Next(280, 633), rad.Next(249, 597), rad.Next(10, 40), 1);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("有本事晚上床上来");
                        //
                        Zs_Move_Clk(dm, 509, 571, 50, 1);
                        Delay(5000);
                        dm.MoveTo(0, 0);
                        if (!QQisSend)
                        {
                            try
                            {
                                this.Invoke(new Action(() =>
                                {
                                    Lab_CloseTime.Text = DateTime.Now.ToString();
                                    WriteLastGame();
                                }));
                            }
                            catch (System.Exception ex)
                            {

                            }
                            MatchCount++;
                            LoseCount++;
                            QQisSend = true;
                            if (OpenQQsend)
                            {
                                string sendstr = "[ " + MyBackUp + " ]： 本局失败 - 共进行对局：" + MatchCount + " 胜：" + WinCount + " 负：" + LoseCount + " 当前等级：" + SendClass + " 当前金币：" + SendJb + " " + SendMb + SendMbNum;
                                QQsENDER(sendstr);
                            }
                        }
                        if (GameEndWaite(dm, Lobbyhwnd))
                        {
                            return;
                        }
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("都没有一个能打的吗");
                        //
                        Zs_Move_Clk(dm, 509, 571, 50, 1);
                        Delay(5000);
                        dm.MoveTo(0, 0);
                        if (!QQisSend)
                        {
                            try
                            {
                                this.Invoke(new Action(() =>
                                {
                                    Lab_CloseTime.Text = DateTime.Now.ToString();
                                    WriteLastGame();

                                }));
                            }
                            catch (System.Exception ex)
                            {

                            }
                            MatchCount++;
                            WinCount++;
                            QQisSend = true;
                            if (OpenQQsend)
                            {
                                string sendstr = "[ " + MyBackUp + " ]： 本局胜利 - 共进行对局：" + MatchCount + " 胜：" + WinCount + " 负：" + LoseCount + " 当前等级：" + SendClass + " 当前金币：" + SendJb + " " + SendMb + SendMbNum;
                                QQsENDER(sendstr);
                            }
                        }
                        if (GameEndWaite(dm, Lobbyhwnd))
                        {
                            return;
                        }
                    }
                    Delay(10);
                    //判断死亡
                    dm.UseDict(0);
                    string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                    if (isdead != "")
                    {
                        ResetSkillArrary();
                        //
                        GetShopSomething_Tz(dm);
                        while (true)
                        {
                            //设置状态
                            SetState("角色死亡中");
                            Delay(500);
                            isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                            if (isdead == "")
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                            if ((int)intX > 0)
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                            if ((int)intX > 0)
                            {
                                break;
                            }
                            Delay(500);
                            dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("游戏需要重连");
                                KillProcessByName("LolClient");
                                KillProcessByName("lol.launcher_tencent");
                                KillProcessByName("League of Legends");
                                //
                                Delay(2000);
                                return;
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, 945, 69, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                                Delay(100);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, 615, 472, 200, 2);
                                Delay(100);
                                dm.MoveTo(0, 0);
                            }
                            Delay(200);
                            dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                            if ((int)intX > 0)
                            {
                                Zs_KeyP(dm, 80, 1);
                                Delay(1000);
                            }
                        }
                        //死了
                    }
                    if ((int)GetCoadDoIngTime(false, AddskillTime) >= 5 * 1000)//15秒超时
                    {
                        bool UnfindAdd = true;
                        bool findJN = true;
                        DateTime SkillOutTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                        while (findJN)
                        {
                            if ((int)GetCoadDoIngTime(false, SkillOutTime) >= 30 * 1000)//30秒超时
                            {
                                break;
                            }
                            Delay(5);
                            dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("游戏需要重连");
                                KillProcessByName("LolClient");
                                KillProcessByName("lol.launcher_tencent");
                                KillProcessByName("League of Legends");
                                //
                                Delay(2000);
                                return;
                            }
                            if (SkillDeal(dm))
                            {
                                findJN = false;
                            }
                            else
                            {
                                UnfindAdd = false;
                            }
                        }
                        if (UnfindAdd)
                        {
                            SkillUnfindTime++;
                            if (SkillUnfindTime >= 2)
                            {
                                Zs_Move_Clk(dm, 549, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 421, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 465, 650, 10, 2);
                                Delay(10);
                                Zs_Move_Clk(dm, 507, 650, 10, 2);
                                Delay(10);
                                dm.MoveTo(587, rad.Next(250, 650));
                                SkillUnfindTime = 0;
                            }
                        }
                        else
                        {
                            SkillUnfindTime = 0;
                        }
                        AddskillTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                    }
                    if ((int)GetCoadDoIngTime(false, kPoWN) >= KgCoutTime * 1000)//15秒超时
                    {
                        bool unfindR = true;
                        Zs_KeyP(dm, 32, rad.Next(1, 2));
                        Delay(50);
                        KgCoutTime = 0.3;
                        //检查是否发现防御塔
                        dm_ret = dm.FindPic(180, 118, 830, 631, "LongBld_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("防御塔卧槽，作死啊");
                            //
                            for (int runnum = 0; runnum < 3; runnum++)
                            {
                                TaoPao_Nq(dm, GetZy);
                                Delay(100);
                            }
                        }
                        else
                        {
                            //判断敌方英雄 
                            dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                            if ((int)intX > 0)
                            {
                                SkillUnfindTime = 0;
                                unfindR = false;
                                //设置状态
                                SetState("发现敌方英雄");
                                //
                                //
                                int Yxx = (int)intX + 69;
                                int Yxy = (int)intY + 84;
                                if (!KillDfyx_Normal_NoCheckBlood(dm, Yxx, Yxy))
                                {
                                    TaoPao_Nq(dm, GetZy);
                                }
                                //
                                Zs_KeyP(dm, 32, rad.Next(1, 3));
                                //
                            }
                            else
                            {
                                int DxbNum = 0;
                                int MxbyNum = 0;
                                int MyxNum = 0;
                                //确定我方英雄数量
                                string MArmyList = dm.FindPicEx(208, 118, 800, 631, "MyArmy_1.bmp", "000000", 0.8, 0);
                                if (MArmyList.Length > 0)
                                {
                                    MyxNum = MArmyList.Split('|').Length;
                                }
                                //确定小兵数量
                                Delay(5);
                                string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                                if (DxbList.Length > 0)
                                {
                                    DxbNum = DxbList.Split('|').Length;
                                }
                                Delay(5);
                                string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                                if (MxbList.Length > 0)
                                {
                                    MxbyNum = MxbList.Split('|').Length;
                                }
                                bool CanFight = false;
                                if (MxbyNum != 0 && DxbNum != 0 && DxbNum / MxbyNum <= 2)
                                {
                                    CanFight = true;
                                }
                                else if (MyxNum > 0 && DxbNum <= 8 && DxbNum != 0)
                                {
                                    CanFight = true;
                                }
                                else if (DxbNum == 0)
                                {
                                    unfindR = true;
                                }
                                else if (DxbNum > 0 && MxbyNum <= 0)
                                {
                                    //设置状态
                                    SetState("往回撤一些");
                                    //逃跑
                                    TaoPao_Nq(dm, GetZy);
                                    unfindR = false;
                                }
                                else
                                {
                                    //设置状态
                                    SetState("往回撤一些");
                                    //逃跑
                                    TaoPao_Nq(dm, GetZy);
                                    unfindR = false;
                                }
                                if (CanFight)
                                {
                                    Delay(5);
                                    //看看有没有敌方小兵
                                    dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                                    if ((int)intX > 0)
                                    {
                                        //
                                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                                        //
                                        int Dfxbx = (int)intX;
                                        int Dfxby = (int)intY;
                                        //设置状态
                                        SetState("发现敌方小兵在视线内");
                                        unfindR = false;
                                        //看看有没有我方小兵
                                        dm_ret = dm.FindPic(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现我方小兵
                                        if ((int)intX > 0)
                                        {
                                            //
                                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                                            //
                                            //设置状态
                                            SetState("发现我方小兵在视线内");
                                            Zs_KeyP(dm, 65, rad.Next(1, 3));
                                            Delay(rad.Next(10, 30));
                                            Zs_Move_Clk(dm, (int)intX + rad.Next(-5, 5), (int)intY + rad.Next(-5, 5), rad.Next(10, 30), 1);
                                            Zs_KeyP(dm, 65, rad.Next(1, 3));
                                            Delay(rad.Next(10, 30));
                                            Zs_Move_Clk(dm, Dfxbx + rad.Next(-5, 5), Dfxby + rad.Next(-5, 5), rad.Next(10, 30), rad.Next(1, 4));
                                            Delay(rad.Next(10, 30));
                                            int SkillOpenNum = SkillAry[rad.Next(0, 4)];
                                            if (SkillOpenNum != 82)
                                            {
                                                Zs_KeyP(dm, SkillOpenNum, rad.Next(1, 3));
                                                Delay(10);
                                            }
                                            dm.MoveTo(493, 367);
                                        }
                                        else
                                        {
                                            //设置状态
                                            SetState("压太前往回撤一些");
                                            //逃跑
                                            TaoPao_Nq(dm, GetZy);
                                        }
                                    }
                                }
                            }
                        }
                        if (unfindR)
                        {
                            //设置状态
                            SetState("寻找合适的带兵位置");
                            int rodx = -1;
                            int rody = -1;
                            Jd_GetroadSafe(dm, out rodx, out rody, GetZy, SearArmyCount);
                            if (rodx != -1)
                            {
                                Delay(10);
                                Zs_Move_Clk(dm, rodx, rody, 20, 1);
                                Delay(20);
                                Zs_Move_R(dm, rodx, rody, 20, 1);
                                dm.MoveTo(493, 367);
                                Zs_KeyP(dm, 32, 1);
                            }
                            else
                            {
                                //前进到指定地点
                                DateTime YdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                while (true)
                                {
                                    Zs_KeyP(dm, 32, 1);
                                    Delay(rad.Next(10, 20));
                                    if ((int)GetCoadDoIngTime(false, YdTime) >= 3 * 1000)//2秒超时
                                    {
                                        break;
                                    }
                                    Delay(5);
                                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                                    if ((int)intX > 0)
                                    {
                                        Zs_KeyP(dm, 80, 1);
                                        Delay(1000);
                                    }
                                    Delay(5);
                                    dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                                    if ((int)intX > 0)
                                    {
                                        //设置状态
                                        SetState("游戏需要重连");
                                        KillProcessByName("LolClient");
                                        KillProcessByName("lol.launcher_tencent");
                                        KillProcessByName("League of Legends");
                                        //
                                        Delay(2000);
                                        return;
                                    }
                                    //检查是否发现防御塔
                                    dm_ret = dm.FindPic(180, 118, 830, 631, "LongBld_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                                    if ((int)intX > 0)
                                    {
                                        //设置状态
                                        SetState("防御塔卧槽，作死啊");
                                        //
                                        for (int runnum = 0; runnum < 3; runnum++)
                                        {
                                            TaoPao_Nq(dm, GetZy);
                                            Delay(100);
                                        }
                                        break;
                                    }
                                    int ClickCount = rad.Next(1, 6);
                                    for (int ydt = 0; ydt < ClickCount; ydt++)
                                    {
                                        Delay(10);
                                        //找敌方英雄
                                        //判断敌方英雄
                                        dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                                        if ((int)intX > 0)
                                        {
                                            unfindR = false;
                                            //设置状态
                                            SetState("发现敌方英雄");
                                            //
                                            //
                                            int Yxx = (int)intX + 69;
                                            int Yxy = (int)intY + 84;
                                            if (!KillDfyx_Normal_NoCheckBlood(dm, Yxx, Yxy))
                                            {
                                                TaoPao_Nq(dm, GetZy);
                                            }
                                            //
                                            Zs_KeyP(dm, 32, rad.Next(1, 3));
                                            //
                                        }
                                        else
                                        {
                                            bool CanstillCheck = true;
                                            int DxbNum = 0;
                                            int MxbyNum = 0;
                                            int MyxNum = 0;
                                            //确定我方英雄数量
                                            string MArmyList = dm.FindPicEx(208, 118, 800, 631, "MyArmy_1.bmp", "000000", 0.8, 0);
                                            if (MArmyList.Length > 0)
                                            {
                                                MyxNum = MArmyList.Split('|').Length;
                                            }
                                            //确定小兵数量
                                            Delay(5);
                                            string DxbList = dm.FindPicEx(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0);
                                            if (DxbList.Length > 0)
                                            {
                                                DxbNum = DxbList.Split('|').Length;
                                            }
                                            Delay(5);
                                            string MxbList = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                                            if (MxbList.Length > 0)
                                            {
                                                MxbyNum = MxbList.Split('|').Length;
                                            }
                                            if (MxbyNum != 0 && DxbNum != 0 && DxbNum / MxbyNum < 2)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (DxbNum == 0)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (MyxNum > 0 && DxbNum <= 8 && DxbNum != 0)
                                            {
                                                CanstillCheck = true;
                                            }
                                            else if (DxbNum > 0 && MxbyNum <= 0)
                                            {
                                                //设置状态
                                                SetState("往回撤一些");
                                                //逃跑
                                                TaoPao_Nq(dm, GetZy);
                                                //
                                                CanstillCheck = false;
                                            }
                                            else
                                            {
                                                //设置状态
                                                SetState("往回撤一些");
                                                //逃跑
                                                TaoPao_Nq(dm, GetZy);
                                                //
                                                CanstillCheck = false;
                                            }
                                            if (CanstillCheck)
                                            {
                                                Delay(5);
                                                //看看有没有敌方小兵
                                                dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                                                if ((int)intX > 0)
                                                {
                                                    //
                                                    Zs_KeyP(dm, 32, rad.Next(1, 3));
                                                    //
                                                    int Dfxbx = (int)intX;
                                                    int Dfxby = (int)intY;
                                                    //设置状态
                                                    SetState("发现敌方小兵在视线内");
                                                    unfindR = false;
                                                    //看看有没有我方小兵
                                                    dm_ret = dm.FindPic(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现我方小兵
                                                    if ((int)intX > 0)
                                                    {
                                                        //
                                                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                                                        //
                                                        //设置状态
                                                        SetState("发现我方小兵在视线内");
                                                        Zs_KeyP(dm, 65, rad.Next(1, 3));
                                                        Delay(rad.Next(10, 30));
                                                        Zs_Move_Clk(dm, (int)intX + rad.Next(-5, 5), (int)intY + rad.Next(-5, 5), rad.Next(10, 30), 1);
                                                        Zs_KeyP(dm, 65, rad.Next(1, 3));
                                                        Delay(rad.Next(10, 30));
                                                        Zs_Move_Clk(dm, Dfxbx + rad.Next(-5, 5), Dfxby + rad.Next(-5, 5), rad.Next(10, 30), rad.Next(1, 4));
                                                        Delay(rad.Next(10, 30));
                                                        int SkillOpenNum = SkillAry[rad.Next(0, 4)];
                                                        if (SkillOpenNum != 82)
                                                        {
                                                            Zs_KeyP(dm, SkillOpenNum, rad.Next(1, 3));
                                                            Delay(10);
                                                        }
                                                        dm.MoveTo(493, 367);
                                                    }
                                                    else
                                                    {
                                                        //设置状态
                                                        SetState("压太前往回撤一些");
                                                        //逃跑
                                                        TaoPao_Nq(dm, GetZy);
                                                    }
                                                }
                                                else
                                                {
                                                    bool StillClick = false;
                                                    string dm_ret_string = dm.FindPicEx(208, 118, 800, 631, "Wfxb_1.bmp|Wfxb_2.bmp", "000000", 0.8, 0);
                                                    //设置状态
                                                    if (dm_ret_string.Length > 0)
                                                    {
                                                        if (dm_ret_string.Split('|').Length > 2)
                                                        {
                                                            Zs_KeyP(dm, 32, 1);
                                                            Delay(10);
                                                            int ClickX = int.Parse(dm_ret_string.Split('|')[1].Split(',')[1]);
                                                            int ClickY = int.Parse(dm_ret_string.Split('|')[1].Split(',')[2]);
                                                            Zs_Move_R(dm, ClickX, ClickY, rad.Next(10, 30), 2);
                                                            Delay(10);
                                                            dm.MoveTo(493, 367);
                                                            StillClick = false;
                                                        }
                                                        else
                                                        {
                                                            StillClick = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        StillClick = true;
                                                    }
                                                    //可以往交战点集合
                                                    if (StillClick)
                                                    {
                                                        if (GetZy == 1)
                                                        {
                                                            Zs_Move_R(dm, 910, 685, rad.Next(10, 20), 1);
                                                        }
                                                        else
                                                        {
                                                            Zs_Move_R(dm, 943, 655, rad.Next(10, 20), 1);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    Delay(rad.Next(10, 30));
                                }
                            }
                        }
                        kPoWN = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                    }
                    //
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("线程错误:" + ex.Message);
                    Delay(3000);
                }
            }
        }
        /// <summary>
        /// 游戏中的处理 - 统治
        /// </summary>
        /// <param name="dm"></param>
        private void Tz_Game(CDmSoft dm, int Lobbyhwnd)
        {
            dm.EnableRealMouse(1, 10, 50);
            dm.EnableRealKeypad(1);
            //大漠通用
            object intX, intY;
            int dm_ret = 0;
            dm.SetPath(".\\attachment");
            dm_ret = dm.SetShowErrorMsg(0);
            dm_ret = dm.SetPicPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDictPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDict(0, "Onerd_GamDeadzk.txt");
            dm_ret = dm.SetDict(1, "Onerd_Blood.txt");
            dm_ret = dm.UnBindWindow();
            //
            Tpzsx = int.Parse(RunaayZb[0].Split(',')[0]);
            Tpzxy = int.Parse(RunaayZb[0].Split(',')[1]);
            Tpyxx = int.Parse(RunaayZb[0].Split(',')[2]);
            Tpyxy = int.Parse(RunaayZb[0].Split(',')[3]);
            //
            dm.SetWindowState(Lobbyhwnd, 1);
            Delay(100);
            //移动窗口到左上角
            dm.MoveWindow(Lobbyhwnd, 0, 0);
            Delay(100);
            //进行绑定
            if (SoftMod == 0)//前台
            {
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "normal", "normal", "normal", "dx.public.disable.window.minmax", 101);//      
            }
            else
            {
                //
                for (int i = 0; i < 3; i++)
                {
                    dm.SetWindowState(Lobbyhwnd, 1);
                    Delay(100);
                    //移动窗口到左上角
                    dm.MoveWindow(Lobbyhwnd, -10, -1);
                    Delay(100);
                }
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "gdi", "dx.mouse.position.lock.api|dx.mouse.position.lock.message|dx.mouse.clip.lock.api|dx.mouse.input.lock.api|dx.mouse.state.api|dx.mouse.api|dx.mouse.cursor", "dx.keypad.input.lock.api|dx.keypad.state.api|dx.keypad.api", "dx.public.active.api|dx.public.down.cpu", 101);//   
            }
            if (dm_ret != 1)
            {
                int Errormsg = dm.GetLastError();
                Delay(5000);
                dm.UnBindWindow();
                return;
            }
            //设置状态
            SetState("检测游戏窗口成功");
            //
            //是否识别到阵营
            int GetZy = 0;
            //
            bool FindIngame = false;
            int UngetZycount = 0;
            bool QQisSend = false;
            int SkillUnfindTime = 0;
            bool UnNeedLock = false;
            while (true)
            {
                KillProcessByName("iexplore");
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 13);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏需要重连");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    //
                    Delay(2000);
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(816, 531, 922, 588, "intGame_1.bmp|intGame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经进入游戏
                if ((int)intX > 0)
                {
                    FindIngame = true;
                }
                Delay(200);
                dm_ret = dm.FindPic(70, 668, 99, 765, "Ft_1_2.bmp|Ft_2.bmp|Ft_3.bmp|Ft_4.bmp|Ft_5.bmp|Ft_6.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经进入游戏
                if ((int)intX > 0)
                {
                    FindIngame = true;
                    UnNeedLock = true;
                }
                Delay(200);
                dm_ret = dm.FindPic(101, 345, 622, 420, "Sm_Tip_1.bmp|Vs_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏在载入
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏正在载入中");
                    //
                    Delay(4000);
                    dm.MoveTo(0, 0);
                }
                if (GetZy != 0)
                {
                    if (UnNeedLock)
                    {
                        //设置状态
                        SetState("正式开始游戏对局");
                        //
                        break;
                    }
                    //识别阵营
                    Delay(200);
                    dm_ret = dm.FindPic(972, 534, 1018, 588, "Lock_1.bmp|Lock_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现视角没有锁定
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("正式开始游戏对局");
                        //
                        break;
                    }
                    else
                    {
                        Zs_KeyP(dm, 89, 1);
                        Delay(1000);
                    }
                }
                if (FindIngame)
                {
                    Delay(200);
                    dm_ret = dm.FindColor(453, 68, 492, 87, "01f901-020202|01f401-020202", 0.8, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("我方在左边阵营");
                        //
                        GetZy = 1;
                    }
                    Delay(200);
                    dm_ret = dm.FindColor(536, 68, 574, 89, "01f901-020202|01f401-020202", 0.8, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("我方在右边阵营");
                        //
                        GetZy = 2;
                    }
                    if (GetZy == 0)
                    {
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                        Zs_KeyP(dm, 32, 1);
                        Delay(1500);
                        if (!GameModDeal(dm, GameMod))
                        {
                            return;
                        }
                        UngetZycount++;
                        if (UngetZycount > 3)
                        {
                            //设置状态
                            SetState("地图模式自动校正");
                            //
                            GameMod = 0;
                            return;
                        }
                    }
                }
                Delay(200);
                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                if ((int)intX > 0)
                {
                    break;
                }
                Delay(200);
                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                if ((int)intX > 0)
                {
                    break;
                }
                Delay(200);
                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(200);
                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                    Delay(100);
                }
                Delay(200);
                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                if ((int)intX > 0)
                {
                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                    Delay(100);
                    dm.MoveTo(0, 0);
                }
                Delay(200);
                if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                {
                    return;
                }
                Delay(200);
                dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                if ((int)intX > 0)
                {
                    Zs_KeyP(dm, 80, 1);
                    Delay(1000);
                }
            }
            //降低CPU优化程度
            if (SoftMod == 1)
            {
                //设置状态
                SetState("进行CPU优化");
                //
                dm.DownCpu(Cpudown);
            }
            //
            DateTime AddskillTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime kPoWN = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime Gettiptime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime ReclickTip = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime JdMudTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime FyjdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            DateTime ZlJdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            bool IsZljudian = false;//是否正在占领据点
            bool GettingTip = false;//是否在行进中
            double KgCoutTime = rad.Next(1, 4);
            bool IsgettinT = false;//是否在占塔
            int GetTaCount = 0;//占塔次数
            int KpRadMax = 3;
            int AddSkillMax = 10;
            bool IsInZlJudian = false;
            bool IsRedTip = false;
            if (OpenTzCarry)
            {
                AddSkillMax = 3;
                KpRadMax = 2;
                KgCoutTime = 0.3;
            }
            //当前处理的点
            int NowDealTip = -1;
            //
            dm.SetWindowState(Lobbyhwnd, 1);
            //
            int FindJnCount = rad.Next(0, 3);
            int Alreadyfindcount = 0;
            //先加一个W
            while (true)
            {
                Delay(50);
                dm_ret = dm.FindPic(443, 629, 485, 668, "Addskill_1.bmp|Addskill_2.bmp|AddSkill3.bmp", "000000", 0.7, 0, out intX, out intY);//发现大招可以加
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现可加点技能");
                    //
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 1);
                    Delay(1000);
                    dm.MoveTo(587, rad.Next(250, 650));
                    Delay(100);
                    //
                    Alreadyfindcount++;
                    if (Alreadyfindcount >= FindJnCount)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //
            GetShopSomething_Tz(dm);
            //
            try
            {
                while (true)
                {
                    //异常检测
                    int ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                    if (ErrorHwnd != 0)
                    {
                        //设置状态
                        SetState("游戏窗口崩溃_1");
                        //
                        dm.SetWindowState(ErrorHwnd, 0);
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(2000);
                        return;
                    }
                    //异常检测
                    ErrorHwnd = dm.FindWindow("#32770", "Error");
                    if (ErrorHwnd != 0)
                    {
                        //设置状态
                        SetState("游戏窗口崩溃_2");
                        //
                        dm.SetWindowState(ErrorHwnd, 13);
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(2000);
                        return;
                    }
                    //异常检测
                    ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                    if (ErrorHwnd != 0)
                    {
                        //设置状态
                        SetState("游戏窗口崩溃_3");
                        //
                        dm.SetWindowState(ErrorHwnd, 13);
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(2000);
                        return;
                    }
                    //异常检测
                    ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                    if (ErrorHwnd != 0)
                    {
                        //设置状态
                        SetState("TS 警告码");
                        //
                        dm.SetWindowState(ErrorHwnd, 0);
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(2000);
                        return;
                    }
                    Delay(10);
                    if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                    {
                        break;
                    }
                    //
                    if (SoftMod == 0)
                    {
                        dm.SetWindowState(Lobbyhwnd, 1);
                    }
                    //
                    IsgettinT = false;
                    Delay(10);
                    dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("游戏需要重连");
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        //
                        Delay(2000);
                        return;
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(800, 32, 1018, 228, "Sd_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现商店打开
                    if ((int)intX > 0)
                    {
                        Zs_KeyP(dm, 80, 1);
                        Delay(1000);
                        //
                        NowDealTip = -1;
                        GettingTip = false;
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, 945, 69, 200, 2);
                        Delay(100);
                        dm.MoveTo(0, 0);
                        Delay(100);
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                    if ((int)intX > 0)
                    {
                        Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                        Delay(200);
                        dm.MoveTo(0, 0);
                        //
                        NowDealTip = -1;
                        GettingTip = false;
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(443, 527, 584, 571, "pctjd_1.bmp|pctjd_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现防御据点
                    if ((int)intX > 0)
                    {
                        if ((int)GetCoadDoIngTime(false, FyjdTime) >= 15 * 1000)//15秒超时
                        {
                            //设置状态
                            SetState("成功防御据点");
                            //
                            NowDealTip = -1;
                            GettingTip = false;
                            //
                            KillDfyx(dm);
                            FyjdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                        }
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(430, 523, 587, 573, "Gjd_1.bmp|Gjd_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现据点处理完毕
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("据点已经占领");
                        //
                        NowDealTip = -1;
                        GettingTip = false;
                        if ((int)GetCoadDoIngTime(false, JdMudTime) >= 6 * 1000)//6秒超时
                        {
                            GetTaCount++;
                            JdMudTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                        }
                        if (GetTaCount >= 5)
                        {
                            NowDealTip = -1;
                            GettingTip = false;
                            GetTaCount = 0;
                            //设置状态
                            SetState("(据点达标)开始回城");
                            if (GoHome(dm))
                            {
                                //
                                GetShopSomething_Tz(dm);
                            }
                        }
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(362, 594, 664, 615, "GetFYT_1.bmp|GetFYT_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现在占领防御塔
                    if ((int)intX > 0)
                    {
                        IsgettinT = true;
                    }
                    Delay(10);
                    dm_ret = dm.FindPic(433, 563, 601, 603, "Zzzl_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现在占领防御塔
                    if ((int)intX > 0)
                    {
                        IsgettinT = true;
                    }
                    if (!IsgettinT)
                    {
                        if (IsInZlJudian && OpenTzCarry && IsRedTip)
                        {
                            Delay(10);
                            //这里要注意，可能出现敌方英雄打断占据
                            dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                            if ((int)intX > 0)
                            {
                                NowDealTip = -1;
                                GettingTip = false;
                                if (!TzRunAway(dm))
                                {
                                    GetTaCount = 0;
                                }
                            }
                        }
                        IsZljudian = false;
                        Delay(10);
                        //判断死亡
                        dm.UseDict(0);
                        string isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                        if (isdead != "")
                        {
                            ResetSkillArrary();
                            //
                            GetShopSomething_Tz(dm);
                            NowDealTip = -1;
                            GettingTip = false;
                            while (true)
                            {
                                //设置状态
                                SetState("角色死亡中");
                                Delay(500);
                                isdead = dm.Ocr(10, 681, 74, 746, "edf6ee-303030", 0.9);
                                if (isdead == "")
                                {
                                    break;
                                }
                                Delay(200);
                                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                                if ((int)intX > 0)
                                {
                                    //设置状态
                                    SetState("游戏需要重连");
                                    KillProcessByName("LolClient");
                                    KillProcessByName("lol.launcher_tencent");
                                    KillProcessByName("League of Legends");
                                    //
                                    Delay(2000);
                                    return;
                                }
                                Delay(500);
                                dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                                if ((int)intX > 0)
                                {
                                    break;
                                }
                                Delay(500);
                                dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                                if ((int)intX > 0)
                                {
                                    break;
                                }
                                Delay(200);
                                dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                                if ((int)intX > 0)
                                {
                                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                                    Delay(100);
                                    dm.MoveTo(0, 0);
                                }
                                Delay(200);
                                dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                                if ((int)intX > 0)
                                {
                                    Zs_Move_Clk(dm, 945, 69, 200, 2);
                                    Delay(100);
                                    dm.MoveTo(0, 0);
                                    Delay(100);
                                }
                                Delay(200);
                                dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                                if ((int)intX > 0)
                                {
                                    Zs_Move_Clk(dm, 615, 472, 200, 2);
                                    Delay(100);
                                    dm.MoveTo(0, 0);
                                }
                            }
                            //死了
                        }
                        //
                        if ((int)GetCoadDoIngTime(false, kPoWN) >= KgCoutTime * 1000)//15秒超时
                        {
                            Zs_KeyP(dm, 32, rad.Next(1, KpRadMax));
                            Delay(50);
                            //判断敌方英雄
                            dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                            if ((int)intX > 0)
                            {
                                //
                                int Yxx = (int)intX + 69;
                                int Yxy = (int)intY + 84;
                                //设置状态
                                SetState("发现敌方英雄");
                                //
                                KillDfyx(dm, Yxx, Yxy);
                                //
                                GettingTip = false;
                            }
                            if (OpenTzCarry && OpenStmod)
                            {
                                if (!BloodCheck(dm))
                                {
                                    Delay(5);
                                    //看看有没有敌方小兵
                                    dm_ret = dm.FindPic(208, 118, 800, 631, "Dfxb_1.bmp|Dfxb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方小兵
                                    if ((int)intX > 0)
                                    {
                                        if (!KillDfXb(dm))
                                        {
                                            //
                                            KillDfyx(dm);
                                            //
                                            GettingTip = false;
                                        }
                                    }
                                }
                            }
                            if (BloodCheck(dm))
                            {
                                //设置状态
                                SetState("(血量过低)开始回城");
                                //
                                if (GoHome(dm))
                                {
                                    NowDealTip = -1;
                                    GetShopSomething_Tz(dm);
                                    GetTaCount = 0;
                                    GettingTip = false;
                                }
                            }
                            kPoWN = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                        }
                        if ((int)GetCoadDoIngTime(false, AddskillTime) >= AddSkillMax * 1000)//15秒超时
                        {
                            bool UnfindAdd = true;
                            bool findJN = true;
                            DateTime SkillOutTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                            while (findJN)
                            {
                                if ((int)GetCoadDoIngTime(false, SkillOutTime) >= 30 * 1000)//30秒超时
                                {
                                    break;
                                }
                                Delay(5);
                                dm_ret = dm.FindPic(419, 85, 617, 124, "rLine_1.bmp|rLine_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏需要重连
                                if ((int)intX > 0)
                                {
                                    //设置状态
                                    SetState("游戏需要重连");
                                    KillProcessByName("LolClient");
                                    KillProcessByName("lol.launcher_tencent");
                                    KillProcessByName("League of Legends");
                                    //
                                    Delay(2000);
                                    return;
                                }
                                if (SkillDeal(dm))
                                {
                                    findJN = false;
                                }
                                else
                                {
                                    UnfindAdd = false;
                                }
                            }
                            if (UnfindAdd)
                            {
                                SkillUnfindTime++;
                                if (SkillUnfindTime >= 2)
                                {
                                    Zs_Move_Clk(dm, 549, 650, 10, 2);
                                    Delay(10);
                                    Zs_Move_Clk(dm, 421, 650, 10, 2);
                                    Delay(10);
                                    Zs_Move_Clk(dm, 465, 650, 10, 2);
                                    Delay(10);
                                    Zs_Move_Clk(dm, 507, 650, 10, 2);
                                    Delay(10);
                                    dm.MoveTo(587, rad.Next(250, 650));
                                    SkillUnfindTime = 0;
                                }
                            }
                            else
                            {
                                SkillUnfindTime = 0;
                            }
                            AddskillTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                        }
                        Delay(10);
                        dm_ret = dm.FindPic(338, 241, 1018, 336, "stop_1.bmp|stop_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接断开
                        if ((int)intX > 0)
                        {
                            Zs_Move_Clk(dm, 615, 472, 200, 2);
                            Delay(100);
                            dm.MoveTo(0, 0);
                        }
                        Delay(10);
                        dm_ret = dm.FindPic(230, 87, 383, 215, "Rj_1.bmp|Rj_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏设置
                        if ((int)intX > 0)
                        {
                            Zs_Move_Clk(dm, 945, 69, 200, 2);
                            Delay(100);
                            dm.MoveTo(0, 0);
                            Delay(100);
                        }
                        Delay(10);
                        dm_ret = dm.FindPic(407, 354, 872, 590, "jg_1.bmp|jg_2.bmp|jg_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现暂离警告
                        if ((int)intX > 0)
                        {
                            Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 3, 200, 2);
                            Delay(100);
                            dm.MoveTo(0, 0);
                        }
                        Delay(10);
                        dm_ret = dm.FindPic(363, 211, 663, 388, "Losgame_1.bmp|Losgame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏失败
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("有本事晚上床上来");
                            //
                            Zs_Move_Clk(dm, 509, 571, 50, 1);
                            Delay(5000);
                            dm.MoveTo(0, 0);
                            if (!QQisSend)
                            {
                                try
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        Lab_CloseTime.Text = DateTime.Now.ToString();
                                        WriteLastGame();
                                    }));
                                }
                                catch (System.Exception ex)
                                {

                                }
                                MatchCount++;
                                LoseCount++;
                                QQisSend = true;
                                if (OpenQQsend)
                                {
                                    string sendstr = "[ " + MyBackUp + " ]： 本局失败 - 共进行对局：" + MatchCount + " 胜：" + WinCount + " 负：" + LoseCount + " 当前等级：" + SendClass + " 当前金币：" + SendJb + " " + SendMb + SendMbNum;
                                    QQsENDER(sendstr);
                                }
                            }
                            if (GameEndWaite(dm, Lobbyhwnd))
                            {
                                return;
                            }
                        }
                        Delay(10);
                        dm_ret = dm.FindPic(384, 230, 658, 373, "Wingame_1.bmp|Wingame_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏胜利
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("都没有一个能打的吗");
                            //
                            Zs_Move_Clk(dm, 509, 571, 50, 1);
                            Delay(5000);
                            dm.MoveTo(0, 0);
                            if (!QQisSend)
                            {
                                try
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        Lab_CloseTime.Text = DateTime.Now.ToString();
                                        WriteLastGame();
                                    }));
                                }
                                catch (System.Exception ex)
                                {

                                }
                                MatchCount++;
                                WinCount++;
                                QQisSend = true;
                                if (OpenQQsend)
                                {
                                    string sendstr = "[ " + MyBackUp + " ]： 本局胜利 - 共进行对局：" + MatchCount + " 胜：" + WinCount + " 负：" + LoseCount + " 当前等级：" + SendClass + " 当前金币：" + SendJb + " " + SendMb + SendMbNum;
                                    QQsENDER(sendstr);
                                }
                            }
                            if (GameEndWaite(dm, Lobbyhwnd))
                            {
                                return;
                            }
                        }
                        if (NowDealTip == -1)
                        {
                            NowDealTip = CheckCanGetTip(dm, out IsRedTip);
                            if (NowDealTip != -1)
                            {
                                //向下一点进发
                                if ((int)GetCoadDoIngTime(false, ReclickTip) >= 3 * 1000)//2秒超时
                                {
                                    if (!GotGetTip(dm, NowDealTip, out IsRedTip))
                                    {
                                        Zs_KeyP(dm, 32, rad.Next(1, KpRadMax));
                                        Delay(100);
                                        //                      
                                        Zs_Move_Clk(dm, rad.Next(455, 631), rad.Next(316, 470), 10, rad.Next(1, 4));
                                        GettingTip = false;
                                        NowDealTip = -1;
                                    }
                                    ReclickTip = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                }
                                if (!GettingTip)
                                {
                                    Gettiptime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                    GettingTip = true;
                                }
                                else
                                {
                                    if ((int)GetCoadDoIngTime(false, Gettiptime) >= 45 * 1000)//45秒超时
                                    {
                                        GettingTip = false;
                                        NowDealTip = -1;
                                        GetTaCount++;
                                    }
                                }
                            }
                            else
                            {
                                Zs_KeyP(dm, 32, 1);
                                Delay(100);
                                //原地搜索
                                DateTime YdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                while (true)
                                {
                                    if ((int)GetCoadDoIngTime(false, YdTime) >= 2 * 1000)//2秒超时
                                    {
                                        break;
                                    }
                                    int ClickCount = rad.Next(1, 6);
                                    for (int ydt = 0; ydt < ClickCount; ydt++)
                                    {
                                        Zs_Move_R(dm, rad.Next(280, 633), rad.Next(249, 597), rad.Next(10, 40), 1);
                                        if (ydt % 2 == 0)
                                        {
                                            Zs_KeyP(dm, 65, 1);
                                            Delay(rad.Next(10, 50));
                                            Zs_Move_Clk(dm, rad.Next(472, 564), rad.Next(328, 426), rad.Next(5, 40), 1);
                                        }
                                        //找敌方英雄
                                    }
                                    Delay(rad.Next(100, 500));
                                }
                            }
                        }
                        else
                        {
                            //向下一点进发
                            if ((int)GetCoadDoIngTime(false, ReclickTip) >= 3 * 1000)//2秒超时
                            {
                                if (!GotGetTip(dm, NowDealTip, out IsRedTip))
                                {
                                    Zs_KeyP(dm, 32, rad.Next(1, KpRadMax));
                                    Delay(100);
                                    //                      
                                    Zs_Move_Clk(dm, rad.Next(455, 631), rad.Next(316, 470), 10, rad.Next(1, 4));
                                    GettingTip = false;
                                    NowDealTip = -1;
                                }
                                ReclickTip = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                            }
                            if (!GettingTip)
                            {
                                Gettiptime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                GettingTip = true;
                            }
                            else
                            {
                                if ((int)GetCoadDoIngTime(false, Gettiptime) >= 45 * 1000)//45秒超时
                                {
                                    GettingTip = false;
                                    NowDealTip = -1;
                                    GetTaCount++;
                                }
                            }
                        }
                        IsInZlJudian = false;
                    }
                    else
                    {
                        IsInZlJudian = true;
                        if (!IsZljudian)
                        {
                            ZlJdTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                            IsZljudian = true;
                        }
                        else
                        {
                            if ((int)GetCoadDoIngTime(false, ZlJdTime) >= 45 * 1000)//45秒超时
                            {
                                IsZljudian = false;
                                //
                                NowDealTip = -1;
                                GettingTip = false;
                                //
                                GetShopSomething_Tz(dm);
                                //
                                //往地图中间逃
                                Zs_Move_R(dm, rad.Next(Tpzsx, Tpzxy), rad.Next(Tpyxx, Tpyxy), 30, rad.Next(1, 4));
                                Delay(3000);
                            }
                        }
                        //设置状态
                        SetState("正在占领据点中");
                        //
                        DateTime Ckgetjd = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                        while (true)
                        {
                            Delay(rad.Next(10, 30));
                            if ((int)GetCoadDoIngTime(false, Ckgetjd) >= 3 * 1000)//2秒超时
                            {
                                break;
                            }
                            dm_ret = dm.FindPic(430, 523, 587, 573, "Gjd_1.bmp|Gjd_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现据点处理完毕
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("据点已经占领");
                                //
                                NowDealTip = -1;
                                GettingTip = false;
                                if ((int)GetCoadDoIngTime(false, JdMudTime) >= 5 * 1000)//3秒超时
                                {
                                    GetTaCount++;
                                    JdMudTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                                }
                                if (GetTaCount >= 7)
                                {
                                    NowDealTip = -1;
                                    GettingTip = false;
                                    GetTaCount = 0;
                                    //设置状态
                                    SetState("(据点达标)开始回城");
                                    //
                                    if (GoHome(dm))
                                    {
                                        GetShopSomething_Tz(dm);
                                    }
                                }
                                break;
                            }
                            Delay(rad.Next(10, 30));
                            dm_ret = dm.FindPic(430, 523, 587, 573, "Bcjd_1.bmp|Bcjd_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现已经拔出
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("拔除据点，屠杀开始");
                                //
                                IsRedTip = false;
                            }
                            if (OpenTzCarry)
                            {
                                Delay(rad.Next(10, 30));
                                //判断敌方英雄
                                dm_ret = dm.FindPic(208, 118, 800, 631, "Garmy_1.bmp|Garmy_2.bmp|Garmy_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现敌方英雄
                                if ((int)intX > 0)
                                {
                                    SkillUnfindTime = 0;
                                    //
                                    int Yxx = (int)intX + 69;
                                    int Yxy = (int)intY + 84;
                                    if (IsRedTip)
                                    {
                                        //如果是红点
                                        NowDealTip = -1;
                                        GettingTip = false;
                                        if (!TzRunAway(dm))
                                        {
                                            GetTaCount = 0;
                                        }
                                    }
                                    else
                                    {
                                        //和他干
                                        KillDfyx(dm, Yxx, Yxy);
                                    }
                                    if (BloodCheck(dm))
                                    {
                                        //设置状态
                                        SetState("(血量过低)开始回城");
                                        //
                                        if (GoHome(dm))
                                        {
                                            NowDealTip = -1;
                                            GetShopSomething_Tz(dm);
                                            GetTaCount = 0;
                                            GettingTip = false;
                                        }
                                    }
                                }
                            }
                        }
                        dm.MoveTo(493, 367);
                        Zs_KeyP(dm, 32, rad.Next(1, 3));
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 选地图方法
        /// </summary>
        /// <param name="dm"></param>
        private void SelectMap(CDmSoft dm)
        {
            if (GameMod == 0)
            {
                Zs_Move_Clk(dm, 324, 176, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 479, 147, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 677, 151, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 865, 179, 100, 1);
                //
                Delay(rad.Next(1000, 3000));
            }
            else if (GameMod == 1)
            {
                Zs_Move_Clk(dm, 324, 176, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 465, 181, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 651, 155, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 864, 178, 100, 1);
                //
                Delay(rad.Next(1000, 3000));
            }
            else if (GameMod == 2)
            {
                Zs_Move_Clk(dm, 320, 122, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 465, 181, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 651, 155, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 873, 158, 100, 1);
                //
                Delay(rad.Next(1000, 3000));
            }
            else if (GameMod == 3)
            {
                Zs_Move_Clk(dm, 320, 122, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 473, 150, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 671, 202, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 880, 160, 100, 1);
                //
                Delay(rad.Next(1000, 3000));
            }
            else if (GameMod == 4)
            {
                Zs_Move_Clk(dm, 320, 122, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 473, 207, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 672, 149, 100, 1);
                //
                Delay(rad.Next(300, 700));
                Zs_Move_Clk(dm, 868, 160, 100, 1);
                //
                Delay(rad.Next(1000, 3000));
            }
        }
        /// <summary>
        /// 大厅处理
        /// </summary>
        /// <param name="dm"></param>
        private void Lobby(CDmSoft dm, int Lobbyhwnd)
        {
            string UserMsg = "";
            string MakeName = "";
            try
            {
                //数据信息获取
                this.Invoke(new Action(() =>
                {
                    Lab_GamUser.Text = Usermsg[LoginIndex].Split('-')[0];
                    Lab_Area.Text = Usermsg[LoginIndex].Split('-')[2];
                    if (Usermsg[LoginIndex].Split('-')[3].Split('|')[0] == "金币")
                    {
                        MBdealCase = 1;
                        label29.Text = "目标金币：";
                        SendMb = "目标金币：";
                    }
                    else if (Usermsg[LoginIndex].Split('-')[3].Split('|')[0] == "等级")
                    {
                        MBdealCase = 2;
                        label29.Text = "目标等级：";
                        SendMb = "目标等级：";
                    }
                    Lab_MbCount.Text = Usermsg[LoginIndex].Split('-')[3].Split('|')[1];
                    MBcount = int.Parse(Usermsg[LoginIndex].Split('-')[3].Split('|')[1]);
                    SendMbNum = Lab_MbCount.Text;
                    Lab_CountMatch.Text = MatchCount.ToString();
                    Lab_Winmatch.Text = WinCount.ToString();
                    Lab_LoseMatch.Text = LoseCount.ToString();
                    Lab_Cgusertime.Text = CguserTime.ToString() + " 分钟";
                    UserMsg = "账号：" + Usermsg[LoginIndex].Split('-')[0] + " 密码：" + Usermsg[LoginIndex].Split('-')[1] + " 大区：" + Usermsg[LoginIndex].Split('-')[2] + " " + SendMb + Usermsg[LoginIndex].Split('-')[3].Split('|')[1];
                    try
                    {
                        MakeName = Usermsg[LoginIndex].Split('-')[4];
                        UserMsg = "游戏名：" + MakeName + " 账号：" + Usermsg[LoginIndex].Split('-')[0] + " 密码：" + Usermsg[LoginIndex].Split('-')[1] + " 大区：" + Usermsg[LoginIndex].Split('-')[2] + " " + SendMb + Usermsg[LoginIndex].Split('-')[3].Split('|')[1];
                    }
                    catch (System.Exception ex)
                    {

                    }
                }));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请不要将目标数量设置过大,如果目标是金币,请保证在百万以内！请停止软件重新设置后启动！", "配置异常");
                return;
            }
            //
            dm.EnableRealMouse(1, 10, 30);
            dm.EnableRealKeypad(1);
            //大漠通用
            object intX, intY;
            int dm_ret = 0;
            dm.SetPath(".\\attachment");
            dm_ret = dm.SetShowErrorMsg(0);
            dm_ret = dm.SetPicPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDictPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDict(0, "Onerd_Mnzk.txt");
            dm_ret = dm.SetDict(1, "Onerd_DjzkDa.txt");
            dm_ret = dm.UnBindWindow();
            Delay(100);
            //
            dm.SetWindowState(Lobbyhwnd, 1);
            //
            Delay(100);
            //移动窗口到左上角
            dm.MoveWindow(Lobbyhwnd, 0, 0);
            Delay(100);
            //进行绑定
            if (SoftMod == 0)//前台
            {
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "normal", "normal", "normal", "", 101);//      
            }
            else
            {
                //
                for (int i = 0; i < 3; i++)
                {
                    dm.SetWindowState(Lobbyhwnd, 1);
                    Delay(100);
                    //移动窗口到左上角
                    dm.MoveWindow(Lobbyhwnd, -10, -1);
                    Delay(100);
                }
                dm_ret = dm.BindWindowEx(Lobbyhwnd, "gdi", "windows", "windows", "", 101);//   
            }
            if (dm_ret != 1)
            {
                int Errormsg = dm.GetLastError();
                Delay(5000);
                dm.UnBindWindow();
                return;
            }
            //设置状态
            SetState("检测游戏大厅成功");
            //
            //是否已经取得金币和等级数据
            bool IsGetMsg = false;
            int NowClass = 1;
            int ClickDtcount = 0;
            bool MissionOver = false;
            //是否设置过召唤师技能
            bool IsSetSkill = false;
            //是否开始匹配
            bool PPbegin = false;
            DateTime PPbeginTime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
            //
            //客户区宽度高度
            object w, h;
            //最大等待时间
            int MaxWateTime = rad.Next(4, 10);
            while (true)
            {
                //KillProcessByName("broadcasting");
                //异常检测
                int ErrorHwnd = dm.FindWindow("#32770", "TS 警告码");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("TS 警告码");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error Report");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("调度—游戏窗口崩溃_1");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "Error");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("调度-游戏窗口崩溃_2");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                //异常检测
                ErrorHwnd = dm.FindWindow("#32770", "连接断开");
                if (ErrorHwnd != 0)
                {
                    //设置状态
                    SetState("调度-游戏窗口崩溃_3");
                    //
                    dm.SetWindowState(ErrorHwnd, 0);
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                }
                KillProcessByName("iexplore");
                //判断窗口大小
                dm_ret = dm.GetClientSize(Lobbyhwnd, out w, out h);
                if ((int)w > 100 && (int)h > 100)
                {
                    if ((int)w < 1280 || (int)h < 800)
                    {
                        //设置状态
                        SetState("大厅窗口大小异常");
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(2000);
                        return;
                    }
                }
                Delay(100);
                if (dm.GetWindowState(Lobbyhwnd, 0) == 0)
                {
                    Delay(2000);
                    return;
                }
                Delay(100);
                dm_ret = dm.FindPic(403, 225, 647, 338, "LoginError1_1.bmp|LoginError1_2.bmp|LoginError1_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现登录异常提示
                if ((int)intX > 0)
                {
                    Delay(100);
                    dm_ret = dm.FindPic(582, 256, 950, 348, "Ftz_1.bmp|Ftz_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现封号
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("发现（不明）封号窗口");
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(2000);
                        MessageBox.Show("发现不明原因被封停,请处理！", "封号提示");
                        Environment.Exit(0);
                        return;
                    }
                    else
                    {
                        //设置状态
                        SetState("发现登录异常提示");
                        Zs_Move_Clk(dm, 703, 531, 10, 1);
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(2000);
                        return;
                    }
                }
                Delay(100);
                dm_ret = dm.FindPic(409, 314, 609, 404, "DlError_1.bmp|DlError_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现进入队列失败
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("进入队列失败");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                    //
                }
                Delay(100);
                dm_ret = dm.FindPic(401, 278, 724, 417, "UnknowError_1.bmp|UnknowError_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现未知错误
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现未知游戏错误");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    return;
                    //
                }
                Delay(100);
                dm_ret = dm.FindPic(731, 71, 1068, 143, "ZbCloseXX_1.bmp|ZbCloseXX_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现跳过等待
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现直播弹窗");
                    Zs_Move_Clk(dm, (int)intX + 7, (int)intY + 7, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(409, 322, 795, 447, "ChooseYxError_1.bmp|ChooseYxError_2.bmp|ChooseYxError_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现选择英雄错误
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("选择英雄错误");
                    Zs_Move_Clk(dm, 644, 435, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(452, 81, 830, 215, "JpWaite_1.bmp|JpWaite_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现跳过等待
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现跳过等待");
                    Zs_Move_Clk(dm, (int)intX + 15, (int)intY + 5, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(451, 334, 823, 463, "JgGameover_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现游戏完成警告
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现游戏完成警告");
                    Zs_Move_Clk(dm, 644, 442, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(433, 132, 891, 206, "Skillxx_1.bmp|Skillxx_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现打开召唤师技能界面
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现召唤师技能窗口");
                    Zs_Move_Clk(dm, 835, 163, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                int DThwnd = dm.FindWindowByProcess("League of Legends.exe", "RiotWindowClass", "League of Legends (TM) Client");
                if (DThwnd != 0)
                {
                    //设置状态
                    SetState("发现游戏窗口");
                    //
                    Delay(2000);
                    return;
                }
                Delay(100);
                dm_ret = dm.FindPic(494, 79, 583, 166, "TipxXX_1.bmp|TipxXX_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现弹窗提示
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现弹出广告窗口");
                    Zs_Move_Clk(dm, (int)intX + 5, (int)intY + 5, 10, 1);
                    //
                    Delay(1000);
                    //
                    Zs_Move_Clk(dm, 78, 45, 10, 1);
                    //
                    Delay(100);
                    return;
                }
                Delay(100);
                dm_ret = dm.FindPic(399, 304, 642, 414, "Ft_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现封号
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现（掉线）封号窗口");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    MessageBox.Show("发现因为掉线被封停账号,请处理！", "封号提示");
                    Environment.Exit(0);
                    return;
                }
                Delay(100);
                dm_ret = dm.FindPic(582, 256, 950, 348, "Ftz_1.bmp|Ftz_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现封号
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现（不明）封号窗口");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    Delay(2000);
                    MessageBox.Show("发现不明原因被封停,请处理！", "封号提示");
                    Environment.Exit(0);
                    return;
                }
                Delay(100);
                dm_ret = dm.FindPic(347, 145, 631, 306, "SetName_1.bmp|SetName_2.bmp|SetName_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现建号
                if ((int)intX > 0)
                {
                    SetState("发现需要建号");
                    try
                    {
                        string GetName = "";
                        if (MakeName == "")
                        {
                            ArrayList Rtary = new ArrayList();
                            TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + "\\Config\\UserNameConfig" + ".txt", "read");
                            Rtary = OverCheck.File_ReadFile(-1);
                            if (Rtary.Count == 0)
                            {
                                SetState("建号失败");
                                KillProcessByName("LolClient");
                                KillProcessByName("lol.launcher_tencent");
                                KillProcessByName("League of Legends");
                                Delay(2000);
                                MessageBox.Show("无建号名字,自动建号失败", "失败提示");
                                Environment.Exit(0);
                            }
                            SetState("得到名字准备输入");
                            GetName = Rtary[rad.Next(0, Rtary.Count)].ToString().Trim();
                        }
                        else
                        {
                            GetName = MakeName;
                        }
                        //
                        for (int i = 0; i < 2; i++)
                        {
                            Zs_Move_Clk(dm, 771, 492, 30, rad.Next(1, 4));
                            //
                            Zs_KeyP(dm, 8, 3);
                        }
                        Delay(rad.Next(100, 500));
                        //
                        dm.SendString2(Lobbyhwnd, ThickNull(GetName));
                        //
                        Delay(rad.Next(100, 500));
                        //
                        Zs_Move_Clk(dm, 638, 569, 100, 1);
                        //
                        Delay(rad.Next(100, 500));
                        //             
                    }
                    catch (System.Exception ex)
                    {

                    }
                }
                Delay(100);
                dm_ret = dm.FindPic(240, 228, 407, 275, "ZhsTb_1.bmp|ZhsTb_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现召唤师图标
                if ((int)intX > 0)
                {
                    SetState("选择召唤师图标");
                    Delay(rad.Next(100, 500));
                    Zs_Move_Clk(dm, rad.Next(274, 630), rad.Next(294, 501), 100, 1);
                    //
                    Delay(rad.Next(100, 500));
                    //  
                    Zs_Move_Clk(dm, 974, 545, 100, 1);
                    Delay(rad.Next(100, 500));
                    //  
                }
                Delay(100);
                dm_ret = dm.FindPic(503, 265, 771, 338, "ZsSp_1.bmp|ZsSp_2.bmp|ZsSp_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现选择水平
                if ((int)intX > 0)
                {
                    SetState("我是大神你懂么");
                    Delay(rad.Next(100, 500));
                    Zs_Move_Clk(dm, 862, 384, 100, 1);
                    //
                    Delay(rad.Next(100, 500));
                    //  
                    Zs_Move_Clk(dm, 886, 542, 100, 1);
                    Delay(rad.Next(100, 500));
                    //  
                }
                Delay(100);
                dm_ret = dm.FindPic(531, 347, 756, 439, "Szxly_1.bmp|Szxly_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现实战训练营
                if ((int)intX > 0)
                {
                    SetState("实战训练营");
                    Delay(rad.Next(100, 500));
                    Zs_Move_Clk(dm, 691, 510, 100, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(1229, 79, 1279, 139, "BsXX_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现直播
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现直播窗口");
                    //
                    Zs_Move_Clk(dm, (int)intX + 5, (int)intY + 5, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(1124, 586, 1250, 677, "FiveXX_1.bmp|FiveXX_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现弹窗
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现弹窗");
                    //
                    Zs_Move_Clk(dm, (int)intX + 5, (int)intY + 5, 10, 1);
                    //

                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(430, 308, 840, 391, "lkcf_1.bmp|lkcf_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现离开惩罚警告
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("离开惩罚警告");
                    //
                    Zs_Move_Clk(dm, 640, 452, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(392, 312, 849, 506, "ConnectError_1.bmp|ConnectError_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现链接异常
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏链接异常");
                    //
                    Zs_Move_Clk(dm, 673, 439, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(427, 320, 870, 486, "PpError_1.bmp|PpError_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现匹配失败
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("进入匹配系统失败");
                    //
                    Zs_Move_Clk(dm, 641, 437, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(440, 266, 841, 528, "Cl_1.bmp|Cl_2.bmp|Cl_3.bmp|Cl_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现重连按钮
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("重新连接游戏");
                    //
                    Zs_Move_Clk(dm, 640, 456, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(431, 204, 825, 406, "QdZb_1.bmp|QdZb_2.bmp", "000000", 0.8, 0, out intX, out intY);//确定退出直播
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("确定退出直播");
                    //
                    Zs_Move_Clk(dm, (int)intX + 5, (int)intY + 5, 10, 1);
                    //
                    Delay(rad.Next(100, 500));
                }
                Delay(100);
                dm_ret = dm.FindPic(543, 3, 747, 93, "Sgame_1.bmp|Sgame_2.bmp|Sgame_3.bmp|Sgame_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现寻找游戏中
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("寻找游戏中");
                    //
                    if (!PPbegin)
                    {
                        PPbeginTime = DateTime.Now;
                        PPbegin = true;
                    }
                    else
                    {
                        if ((int)GetCoadDoIngTime(false, PPbeginTime) >= MaxWateTime * 60 * 1000)//10秒超时
                        {
                            //设置状态
                            SetState("匹配3分钟超时，重新匹配");
                            PPbegin = false;
                            //3分钟匹配超时，重新选择匹配地图
                            Zs_Move_Clk(dm, 725, 61, 100, 1);
                            //
                            Delay(rad.Next(100, 500));
                        }
                    }
                    if (!IsGetMsg)
                    {
                        DateTime breaktime = DateTime.Now;
                        //设置状态
                        SetState("读取金币和等级");
                        while (true)
                        {
                            Delay(100);
                            dm_ret = dm.FindPic(364, 252, 871, 590, "Cgyx_1.bmp|Nplay_2.bmp|Nplay_3.bmp|Nplay_4.bmp|Nplay_5.bmp", "000000", 0.8, 0, out intX, out intY);//发现开始游戏
                            if ((int)intX > 0)
                            {
                                break;
                            }
                            if ((int)GetCoadDoIngTime(false, breaktime) >= 10 * 1000)//10秒超时
                            {
                                IsGetMsg = true;
                                break;
                            }
                            Delay(100);
                            dm_ret = dm.FindPic(91, 97, 939, 255, "Grzl_1.bmp|Grzl_2.bmp|Grzl_3.bmp|Fw_1.bmp|Tf_1.bmp", "000000", 0.8, 0, out intX, out intY);//打开个人资料
                            if ((int)intX > 0)
                            {
                                Delay(3000);
                                //
                                dm.UseDict(0);
                                string getmoney = dm.Ocr(1115,5,1211,33, "e9e9e9-404040|9a9b9b-202020", 0.9);
                                if (getmoney == "" )
                                {
                                    break;
                                }
                                if (IsFirstBegin && getmoney != "")
                                {
                                    ChangeUserTime = DateTime.Now;
                                    BeginJb = int.Parse(getmoney);
                                    try
                                    {
                                        //数据信息获取
                                        this.Invoke(new Action(() =>
                                        {
                                            Lab_BeginJb.Text = getmoney;
                                            Lab_NowJb.Text = getmoney;
                                        }));
                                    }
                                    catch (System.Exception ex)
                                    {

                                    }
                                }
                                //
                                dm.UseDict(1);
                                string getdenji = dm.Ocr(438, 300, 574, 347, "eaeaea-303030|bbbbbb-202020", 0.9);
                                if (getdenji != "")
                                {
                                    IsGetMsg = true;
                                }
                                else
                                {
                                    getdenji = dm.Ocr(239, 309, 380, 351, "eaeaea-303030|bbbbbb-202020", 0.9);
                                    if (getdenji != "")
                                    {
                                        IsGetMsg = true;
                                        try
                                        {
                                            if (int.Parse(getdenji) >= 30)
                                            {
                                                getdenji = "30";
                                            }
                                        }
                                        catch (System.Exception ex)
                                        {
                                            getdenji = "30";
                                        }
                                    }
                                }
                                if (IsFirstBegin && getdenji != "")
                                {
                                    ChangeUserTime = DateTime.Now;
                                    IsFirstBegin = false;
                                    BeginDj = int.Parse(getdenji);
                                    try
                                    {
                                        //数据信息获取
                                        this.Invoke(new Action(() =>
                                        {
                                            Lab_BeginDj.Text = getdenji;
                                            Lab_NowClass.Text = getdenji;
                                        }));
                                    }
                                    catch (System.Exception ex)
                                    {

                                    }
                                }
                                if (getmoney != "" || getdenji != "")
                                {
                                    MissionOver = false;
                                    if (getmoney != "")
                                    {
                                        SendJb = getmoney;
                                        try
                                        {
                                            //数据信息获取
                                            this.Invoke(new Action(() =>
                                            {
                                                Lab_GetJb.Text = (int.Parse(getmoney) - BeginJb).ToString();
                                                Lab_NowJb.Text = getmoney;
                                            }));
                                            //如果是锁定金币
                                            if (int.Parse(getmoney) >= MBcount && MBdealCase == 1)
                                            {
                                                MissionOver = true;
                                            }
                                        }
                                        catch (System.Exception ex)
                                        {

                                        }
                                    }
                                    if (getdenji != "")
                                    {
                                        SendClass = getdenji;
                                        NowClass = int.Parse(getdenji);
                                        try
                                        {
                                            //数据信息获取
                                            this.Invoke(new Action(() =>
                                            {
                                                Lab_GETdj.Text = (int.Parse(getdenji) - BeginDj).ToString();
                                                Lab_NowClass.Text = getdenji;
                                            }));
                                        }
                                        catch (System.Exception ex)
                                        {

                                        }
                                        //如果是锁定等级
                                        if (int.Parse(getdenji) >= MBcount && MBdealCase == 2)
                                        {
                                            MissionOver = true;
                                        }
                                    }
                                    if (MissionOver)
                                    {
                                        if (OpenChangeUser)
                                        {
                                            //任务完成
                                            OverUserCount++;
                                            if (OverUserCount >= UserNumCount)
                                            {
                                                //全部任务完成
                                                Missionover(UserMsg, true);
                                            }
                                            else
                                            {
                                                Missionover(UserMsg, false);
                                                //换号
                                                CguserDoing(false);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            //全部任务完成
                                            Missionover(UserMsg, true);
                                        }
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Zs_Move_Clk(dm, 1005, 57, 100, 1);
                                Delay(3000);
                            }
                        }
                    }
                }
                else
                {
                    Delay(100);
                    dm_ret = dm.FindPic(274, 261, 384, 398, "Pfjt_1.bmp|Pfjt_2.bmp|Pfjt_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现选择完毕
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("等待游戏开始");
                        //
                        PPbegin = false;
                    }
                    else
                    {
                        bool NeedGetHero = false;
                        Delay(100);
                        dm_ret = dm.FindPic(234, 41, 410, 182, "Ghero_1.bmp|Ghero_2.bmp|Ghero_3.bmp", "000000", 0.8, 0, out intX, out intY);//发现选择英雄
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("需要选择英雄");
                            //
                            NeedGetHero = true;
                        }
                        Delay(100);
                        dm_ret = dm.FindPic(537, 437, 754, 591, "Jn_1.bmp|Bothcg_1.bmp|Bothcg_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现选择英雄
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("需要选择英雄");
                            //
                            NeedGetHero = true;
                        }
                        if (NeedGetHero)
                        {
                            PPbegin = false;
                            ClickDtcount = 0;
                            if (SelectHero(dm))
                            {
                                //设置状态
                                SetState("先秒选特定英雄");
                                //
                                Delay(rad.Next(500, 1000));
                                //
                                Zs_Move_Clk(dm, 869, 508, 10, 1);
                                //
                                Delay(rad.Next(200, 1000));
                                //
                                dm.MoveTo(0, 15);
                                //
                                Delay(rad.Next(100, 500));
                            }
                            else
                            {
                                //设置状态
                                SetState("随机选择英雄");
                                //
                                Delay(rad.Next(500, 2000));
                                //选择英雄
                                Zs_Move_Clk(dm, 321, 207, 10, rad.Next(1, 3));
                                //
                                Delay(rad.Next(500, 1000));
                                //
                                Zs_Move_Clk(dm, 869, 508, 10, 1);
                                //
                                Delay(rad.Next(200, 1000));
                                //
                                dm.MoveTo(0, 15);
                                //
                                Delay(rad.Next(100, 500));
                            }
                            //
                            if (!IsSetSkill)
                            {
                                DateTime GameStilLTime = DateTime.Now;
                                while (true)
                                {
                                    if ((int)GetCoadDoIngTime(false, GameStilLTime) >= 15 * 1000)//15秒超时
                                    {
                                        break;
                                    }
                                    Delay(100);
                                    dm_ret = dm.FindPic(433, 132, 891, 206, "Skillxx_1.bmp|Skillxx_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现打开召唤师技能界面
                                    if ((int)intX > 0)
                                    {
                                        int ChooseSkillIndex = rad.Next(0, 12);
                                        //
                                        Zs_Move_Clk(dm, int.Parse(ZhsSkill[ChooseSkillIndex].Split(',')[0]) + rad.Next(-3, 3), int.Parse(ZhsSkill[ChooseSkillIndex].Split(',')[1]) + rad.Next(-3, 3), 10, 1);
                                        //
                                        Delay(rad.Next(100, 500));
                                        //
                                        ChooseSkillIndex = rad.Next(0, 12);
                                        //
                                        Zs_Move_Clk(dm, int.Parse(ZhsSkill[ChooseSkillIndex].Split(',')[0]) + rad.Next(-3, 3), int.Parse(ZhsSkill[ChooseSkillIndex].Split(',')[1]) + rad.Next(-3, 3), 10, 1);
                                        //
                                        IsSetSkill = true;
                                        //
                                        break;
                                    }
                                    else
                                    {
                                        //
                                        Zs_Move_Clk(dm, 645 + rad.Next(-10, 10), 532 + rad.Next(-2, 2), 10, 1);
                                        //
                                        Delay(rad.Next(100, 500));
                                    }
                                }
                            }
                        }
                        Delay(100);
                        dm_ret = dm.FindPic(831, 561, 1124, 764, "ZbXX_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现直播的XX
                        if ((int)intX > 0)
                        {
                            //
                            Delay(rad.Next(100, 200));
                            //
                            Zs_Move_Clk(dm, (int)intX + 5, (int)intY + 5, 10, 1);
                            //
                            Delay(rad.Next(100, 500));
                            //
                            dm.MoveTo(0, 35);
                            //
                            Delay(rad.Next(100, 500));
                        }

                        Delay(100);
                        dm_ret = dm.FindPic(364, 252, 871, 590, "Cgyx_1.bmp|Nplay_2.bmp|Nplay_3.bmp|Nplay_4.bmp|Nplay_5.bmp", "000000", 0.8, 0, out intX, out intY);//发现开始游戏
                        if ((int)intX > 0)
                        {
                            ClickDtcount = 0;
                            //设置状态
                            SetState("找到游戏准备开始");
                            //
                            Delay(rad.Next(1500, 3000));
                            //进入选择
                            Zs_Move_Clk(dm, 744, 481, 10, 1);
                            //
                            Delay(rad.Next(100, 500));
                            //
                            dm.MoveTo(0, 35);
                            //
                            Delay(rad.Next(100, 500));
                        }

                        Delay(100);
                        dm_ret = dm.FindPic(828, 612, 1273, 776, "Agn_1.bmp|Agn_2.bmp|Agn_3.bmp|Agn_4.bmp|Agn_5.bmp|Agn_6.bmp", "000000", 0.8, 0, out intX, out intY);//发现再来一次
                        if ((int)intX > 0)
                        {
                            ClickDtcount++;
                            //**************************停止部分**************************
                            if (DelayStop)
                            {
                                dm.UnBindWindow();
                                Game_Dm.UnBindWindow();
                                DelayStop = false;
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }
                            //脚本有异常，需要停止
                            if (IsScriptsEnd)
                            {
                                Scripts_ShowErrorMsg(scriptendmsg);
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }
                            if (OpenDsgj)
                            {
                                bool CanGj = false;
                                DateTime Nowtime = System.DateTime.Now;
                                DateTime DsGjTime = DateTime.Parse(ExitTime);
                                if (Nowtime.Year == DsGjTime.Year && Nowtime.Month == DsGjTime.Month && Nowtime.Day == DsGjTime.Day)
                                {
                                    if (Nowtime.Hour > DsGjTime.Hour)
                                    {
                                        CanGj = true;
                                    }
                                    else if (Nowtime.Hour == DsGjTime.Hour)
                                    {
                                        if (Nowtime.Minute >= DsGjTime.Minute)
                                        {
                                            CanGj = true;
                                        }
                                    }
                                    if (CanGj)
                                    {
                                        //关机
                                        System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                                        myProcess.StartInfo.FileName = "cmd.exe";//启动cmd命令
                                        myProcess.StartInfo.UseShellExecute = false;//是否使用系统外壳程序启动进程
                                        myProcess.StartInfo.RedirectStandardInput = true;//是否从流中读取
                                        myProcess.StartInfo.RedirectStandardOutput = true;//是否写入流
                                        myProcess.StartInfo.RedirectStandardError = true;//是否将错误信息写入流
                                        myProcess.StartInfo.CreateNoWindow = true;//是否在新窗口中启动进程
                                        myProcess.Start();//启动进程
                                        myProcess.StandardInput.WriteLine("shutdown -s -t 0");//执行关机命令
                                    }

                                }
                            }
                            //**************************停止部分**************************
                            if (CguserTime > 0)
                            {
                                //设置状态
                                SetState("查看是否需要换号");
                                //
                                Delay(rad.Next(1000, 2000));
                                //
                                //需要进行换号处理
                                if ((int)GetCoadDoIngTime(false, ChangeUserTime) >= CguserTime * 1000 * 60)//一个号执行超时
                                {
                                    CguserDoing(false);
                                    return;
                                }
                                //设置状态
                                SetState("暂时不需要换号");
                                //
                                Delay(rad.Next(1000, 2000));
                            }
                            //设置状态
                            SetState("一局游戏完成");
                            //
                            Delay(10);
                            dm_ret = dm.FindPic(828, 612, 1273, 776, "Bag_1.bmp|Bag_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现再来一次 - 灰色
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("返回大厅");
                                //
                                //返回大厅
                                Zs_Move_Clk(dm, 904, 736, 10, 1);
                                //
                                Delay(rad.Next(100, 200));
                                //
                                dm.MoveTo(0, 5);
                                //
                                Delay(rad.Next(100, 300));
                            }
                            else
                            {
                                if (SjcgMap)
                                {
                                    //设置状态
                                    SetState("返回大厅");
                                    //
                                    //返回大厅
                                    Zs_Move_Clk(dm, 904, 736, 10, 1);
                                    //
                                    Delay(rad.Next(100, 200));
                                    //
                                    dm.MoveTo(0, 5);
                                    //
                                    Delay(rad.Next(100, 300));
                                }
                                else
                                {
                                    if (ClickDtcount >= 3)
                                    {
                                        //设置状态
                                        SetState("再来一局");
                                        //
                                        //再来一局
                                        Zs_Move_Clk(dm, 1118, 735, 10, 1);
                                        //
                                        Delay(rad.Next(100, 200));
                                        //
                                        dm.MoveTo(0, 5);
                                        //
                                        Delay(rad.Next(100, 300));
                                        //
                                        ClickDtcount = 0;
                                    }
                                    else
                                    {
                                        if (MatchCount % 5 == 0 || GameMod == 0 || IsFirstBegin)
                                        {
                                            //设置状态
                                            SetState("返回大厅");
                                            //
                                            //返回大厅
                                            Zs_Move_Clk(dm, 904, 736, 10, 1);
                                            //
                                            Delay(rad.Next(100, 200));
                                            //
                                            dm.MoveTo(0, 5);
                                            //
                                            Delay(rad.Next(100, 300));
                                        }
                                        else
                                        {
                                            //设置状态
                                            SetState("再来一局");
                                            //
                                            //再来一局
                                            Zs_Move_Clk(dm, 1118, 735, 10, 1);
                                            //
                                            Delay(rad.Next(100, 200));
                                            //
                                            dm.MoveTo(0, 5);
                                            //
                                            Delay(rad.Next(100, 300));
                                        }
                                    }
                                }
                            }
                        }
                        Delay(100);
                        dm_ret = dm.FindPic(1, 2, 779, 88, "LmBg_2.bmp|LmBg_1.bmp|Rp_1.bmp|Rp_2.bmp|Rp_3.bmp|Rp_4.bmp", "000000", 0.8, 0, out intX, out intY);//发现大厅主按钮
                        if ((int)intX > 0)
                        {
                            //删除游戏配置文件
                            ClearClient();
                            //
                            //**************************停止部分**************************
                            if (DelayStop)
                            {
                                dm.UnBindWindow();
                                Game_Dm.UnBindWindow();
                                DelayStop = false;
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }
                            //脚本有异常，需要停止
                            if (IsScriptsEnd)
                            {
                                Scripts_ShowErrorMsg(scriptendmsg);
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }
                            if (OpenDsgj)
                            {
                                if (System.DateTime.Now >= DateTime.Parse(ExitTime))
                                {
                                    //关机
                                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                                    myProcess.StartInfo.FileName = "cmd.exe";//启动cmd命令
                                    myProcess.StartInfo.UseShellExecute = false;//是否使用系统外壳程序启动进程
                                    myProcess.StartInfo.RedirectStandardInput = true;//是否从流中读取
                                    myProcess.StartInfo.RedirectStandardOutput = true;//是否写入流
                                    myProcess.StartInfo.RedirectStandardError = true;//是否将错误信息写入流
                                    myProcess.StartInfo.CreateNoWindow = true;//是否在新窗口中启动进程
                                    myProcess.Start();//启动进程
                                    myProcess.StandardInput.WriteLine("shutdown -s -t 0");//执行关机命令
                                }
                            }
                            //**************************停止部分**************************
                            Delay(10);
                            dm_ret = dm.FindPic(494, 79, 583, 166, "TipxXX_1.bmp|TipxXX_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现弹窗提示
                            if ((int)intX > 0)
                            {
                            }
                            else
                            {
                                //
                                if (!IsGetMsg)
                                {
                                    DateTime breaktime = DateTime.Now;
                                    //设置状态
                                    SetState("读取金币和等级");
                                    while (true)
                                    {
                                        Delay(100);
                                        dm_ret = dm.FindPic(364, 252, 871, 590, "Cgyx_1.bmp|Nplay_2.bmp|Nplay_3.bmp|Nplay_4.bmp|Nplay_5.bmp", "000000", 0.8, 0, out intX, out intY);//发现开始游戏
                                        if ((int)intX > 0)
                                        {
                                            break;
                                        }
                                        if ((int)GetCoadDoIngTime(false, breaktime) >= 10 * 1000)//10秒超时
                                        {
                                            break;
                                        }
                                        Delay(100);
                                        dm_ret = dm.FindPic(91, 97, 939, 255, "Grzl_1.bmp|Grzl_2.bmp|Grzl_3.bmp|Fw_1.bmp|Tf_1.bmp", "000000", 0.8, 0, out intX, out intY);//打开个人资料
                                        if ((int)intX > 0)
                                        {
                                            Delay(3000);
                                            //
                                            dm.UseDict(0);
                                            string getmoney = dm.Ocr(1115,5,1211,33, "e9e9e9-404040|9a9b9b-202020", 0.9);
                                            if (getmoney == "" )
                                            {
                                                break;
                                            }
                                            if (IsFirstBegin && getmoney != "")
                                            {
                                                ChangeUserTime = DateTime.Now;
                                                BeginJb = int.Parse(getmoney);
                                                try
                                                {
                                                    //数据信息获取
                                                    this.Invoke(new Action(() =>
                                                    {
                                                        Lab_BeginJb.Text = getmoney;
                                                        Lab_NowJb.Text = getmoney;
                                                    }));
                                                }
                                                catch (System.Exception ex)
                                                {

                                                }
                                            }
                                            //
                                            dm.UseDict(1);
                                            string getdenji = dm.Ocr(438, 300, 574, 347, "eaeaea-303030|bbbbbb-202020", 0.9);
                                            if (getdenji != "")
                                            {
                                                IsGetMsg = true;
                                            }
                                            else
                                            {
                                                getdenji = dm.Ocr(239, 309, 380, 351, "eaeaea-303030|bbbbbb-202020", 0.9);
                                                if (getdenji != "")
                                                {
                                                    IsGetMsg = true;
                                                    try
                                                    {
                                                        if (int.Parse(getdenji) >= 30)
                                                        {
                                                            getdenji = "30";
                                                        }
                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        getdenji = "30";
                                                    }
                                                }
                                            }
                                            if (IsFirstBegin && getdenji != "")
                                            {
                                                ChangeUserTime = DateTime.Now;
                                                IsFirstBegin = false;
                                                BeginDj = int.Parse(getdenji);
                                                //数据信息获取
                                                this.Invoke(new Action(() =>
                                                {
                                                    Lab_BeginDj.Text = getdenji;
                                                    Lab_NowClass.Text = getdenji;
                                                }));
                                            }
                                            if (getmoney != "" || getdenji != "")
                                            {
                                                MissionOver = false;
                                                if (getmoney != "")
                                                {
                                                    try
                                                    {
                                                        //数据信息获取
                                                        this.Invoke(new Action(() =>
                                                        {
                                                            Lab_GetJb.Text = (int.Parse(getmoney) - BeginJb).ToString();
                                                            Lab_NowJb.Text = getmoney;
                                                        }));
                                                        //如果是锁定金币
                                                        if (int.Parse(getmoney) >= MBcount && MBdealCase == 1)
                                                        {
                                                            MissionOver = true;
                                                        }
                                                    }
                                                    catch (System.Exception ex)
                                                    {

                                                    }

                                                }
                                                if (getdenji != "")
                                                {
                                                    NowClass = int.Parse(getdenji);
                                                    try
                                                    {
                                                        //数据信息获取
                                                        this.Invoke(new Action(() =>
                                                        {
                                                            Lab_GETdj.Text = (int.Parse(getdenji) - BeginDj).ToString();
                                                            Lab_NowClass.Text = getdenji;
                                                        }));
                                                        //如果是锁定等级
                                                        if (int.Parse(getdenji) >= MBcount && MBdealCase == 2)
                                                        {
                                                            MissionOver = true;
                                                        }
                                                    }
                                                    catch (System.Exception ex)
                                                    {

                                                    }
                                                }
                                                if (MissionOver)
                                                {
                                                    if (OpenChangeUser)
                                                    {
                                                        //任务完成
                                                        OverUserCount++;
                                                        if (OverUserCount >= UserNumCount)
                                                        {
                                                            //全部任务完成
                                                            Missionover(UserMsg, true);
                                                        }
                                                        else
                                                        {
                                                            Missionover(UserMsg, false);
                                                            //换号
                                                            CguserDoing(false);
                                                            return;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //全部任务完成
                                                        Missionover(UserMsg, true);
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            Zs_Move_Clk(dm, 1005, 57, 100, 1);
                                            Delay(500);
                                        }
                                    }
                                }
                                Delay(100);
                                dm_ret = dm.FindPic(485, 3, 799, 170, "Bp_1.bmp|Bp_2.bmp|Gmap_1.bmp|Gmod_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现黑色play
                                if ((int)intX > 0)
                                {

                                }
                                else
                                {
                                    //进入选择
                                    Zs_Move_Clk(dm, 643, 40, 10, 1);
                                    //
                                    Delay(rad.Next(100, 200));
                                    //
                                    dm.MoveTo(0, 15);
                                    //
                                    Delay(rad.Next(100, 200));
                                }
                            }
                        }
                        Delay(100);
                        dm_ret = dm.FindPic(432, 323, 873, 486, "QxTf_1.bmp|QxTf_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现新赛季天赋重置
                        if ((int)intX > 0)
                        {
                            Delay(20);
                            dm_ret = dm.FindPic(432, 323, 873, 486, "Uok_1.bmp|Uok_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现取消按钮
                            if ((int)intX > 0)
                            {
                                Zs_Move_Clk(dm, (int)intX + 5, (int)intY + 5, 50, 1);
                                Delay(50);
                                //
                                dm.MoveTo(0, 15);
                            }
                        }
                        bool CanPp = false;
                        Delay(100);
                        dm_ret = dm.FindPic(485, 3, 799, 170, "Bp_1.bmp|Bp_2.bmp|Gmap_1.bmp|Gmod_1.bmp", "000000", 0.8, 0, out intX, out intY);//发现进入模式选择
                        if ((int)intX > 0)
                        {
                            if (!IsFirstBegin)
                            {
                                //设置状态
                                SetState("选择游戏模式");
                                //
                                if (SjcgMap && NowClass >= 7)
                                {
                                    int GamesJmOD = rad.Next(0, 5);
                                    //设置状态
                                    SetState("产生随机种子 " + GamesJmOD);
                                    if (GamesJmOD == 0 && Zhs_Rj_Class != 0)
                                    {
                                        //设置状态
                                        SetState("随机选定 - 召唤师人机");
                                        GameMod = 0;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                    else if (GamesJmOD == 1 && Tz_Rj_Class != 0)
                                    {
                                        //设置状态
                                        SetState("随机选定 - 统治人机");
                                        //统治人机
                                        GameMod = 1;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                    else if (GamesJmOD == 2 && Tz_Pp_Class != 0)
                                    {
                                        //设置状态
                                        SetState("随机选定 - 统治匹配");
                                        //统治匹配
                                        GameMod = 2;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                    else if (GamesJmOD == 3 && Nq_Pp_Class != 0)
                                    {
                                        //设置状态
                                        SetState("随机选定 - 扭曲匹配");
                                        //扭曲匹配
                                        GameMod = 3;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                    else if (GamesJmOD == 4 && Jd_Pp_Class != 0)
                                    {
                                        //设置状态
                                        SetState("随机选定 - 极地匹配");
                                        //极地匹配
                                        GameMod = 4;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                }
                                else
                                {
                                    //选择模式
                                    if (NowClass < Zhs_Rj_Class && Zhs_Rj_Class != 0)
                                    {
                                        //设置状态
                                        SetState(NowClass + "/" + Zhs_Rj_Class + " 召唤师人机");
                                        //召唤师峡谷人机
                                        GameMod = 0;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                    else if (NowClass >= Tz_Rj_Class && Tz_Rj_Class != 0)
                                    {
                                        //设置状态
                                        SetState(NowClass + "/" + Tz_Rj_Class + " 统治人机");
                                        //统治人机
                                        GameMod = 1;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                    else if (NowClass >= Tz_Pp_Class && Tz_Pp_Class != 0)
                                    {
                                        //设置状态
                                        SetState(NowClass + "/" + Tz_Pp_Class + " 统治匹配");
                                        //统治匹配
                                        GameMod = 2;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                    else if (NowClass >= Nq_Pp_Class && Nq_Pp_Class != 0)
                                    {
                                        //设置状态
                                        SetState(NowClass + "/" + Nq_Pp_Class + " 扭曲匹配");
                                        //扭曲匹配
                                        GameMod = 3;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                    else if (NowClass >= Jd_Pp_Class && Jd_Pp_Class != 0)
                                    {
                                        //设置状态
                                        SetState(NowClass + "/" + Jd_Pp_Class + " 极地匹配");
                                        //极地匹配
                                        GameMod = 4;
                                        SelectMap(dm);
                                        CanPp = true;
                                    }
                                }
                            }
                        }
                        if (CanPp)
                        {
                            Delay(100);
                            dm_ret = dm.FindPic(615, 644, 915, 765, "Gsc_dy_1.bmp|Gsc_dy_2.bmp", "000000", 0.8, 0, out intX, out intY);//发现系统匹配队友
                            if ((int)intX > 0)
                            {
                                //设置状态
                                SetState("开始匹配");
                                //
                                Zs_Move_Clk(dm, (int)intX + 5, (int)intY + 5, 50, 1);
                                //
                                Delay(rad.Next(100, 200));
                                //
                                dm.MoveTo(0, 15);
                            }
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 登陆方法
        /// </summary>
        private void UserLogin(CDmSoft dm)
        {
            //设置状态
            SetState("开始自动登陆");
            //
            //先杀死这些进程
            KillProcessByName("iexplore");
            KillProcessByName("Client");
            KillProcessByName("LolClient");
            KillProcessByName("lol.launcher_tencent");
            KillProcessByName("League of Legends");
            //
            //大漠通用
            object intX, intY;
            int dm_ret = 0;
            //
            LoginNum++;
            this.Invoke(new Action(() =>
            {
                Lab_LoginNum.Text = LoginNum + " 次";
            }));
            //
            dm.SetPath(".\\attachment");
            dm_ret = dm.SetShowErrorMsg(0);
            dm_ret = dm.SetPicPwd(DecodeStr(":=-bL@Lp]n]%"));
            dm_ret = dm.SetDictPwd(DecodeStr(":=-bL@Lp]n]%"));

            int LoginHwnd = 0;
            string UserName = "";//账号
            string UserPassword = "";//密码
            string UserArea = "";//大区
            UserName = Usermsg[LoginIndex].Split('-')[0];
            UserPassword = Usermsg[LoginIndex].Split('-')[1];
            UserArea = Usermsg[LoginIndex].Split('-')[2];

            //输入账号密码次数
            int SendpsdCount = 0;
            //窗体绑定之前先解绑，再绑定
            try
            {
                dm_ret = dm.UnBindWindow();
            }
            catch (System.Exception ex)
            {

            }
            try
            {
                //先删除配置文件
                ClearClient();
                //
                DeleteFolder(SplitGamePath(Gamepath) + "Game\\config");
                //先删除
                Directory.CreateDirectory(SplitGamePath(Gamepath) + "Game\\config");
                Delay(1000);
                File.Delete(SplitGamePath(Gamepath) + "Game\\config\\Game.cfg");
                File.Delete(SplitGamePath(Gamepath) + "Game\\config\\input.ini");
                //
                Directory.CreateDirectory(SplitGamePath(Gamepath) + "Game\\config");
                if (Cpudown > 0)
                {
                    //后复制
                    File.Copy(Environment.CurrentDirectory + "\\attachment\\Dimod\\Game.cfg", SplitGamePath(Gamepath) + "Game\\config\\Game.cfg");
                    File.Copy(Environment.CurrentDirectory + "\\attachment\\Dimod\\input.ini", SplitGamePath(Gamepath) + "Game\\config\\input.ini");
                }
                else
                {
                    //后复制
                    File.Copy(Environment.CurrentDirectory + "\\attachment\\Himod\\Game.cfg", SplitGamePath(Gamepath) + "Game\\config\\Game.cfg");
                    File.Copy(Environment.CurrentDirectory + "\\attachment\\Himod\\input.ini", SplitGamePath(Gamepath) + "Game\\config\\input.ini");
                }
                //设置状态
                SetState("设置文件替换完毕");
                //
                Delay(1000);
            }
            catch (System.Exception ex)
            {
                //设置状态
                SetState("游戏路径设置有误");
                //
                MessageBox.Show(ex.Message, "错误提示 - 请截图后联系管理员");
                Environment.Exit(0);
            }
            //设置状态
            SetState("准备运行客户端");
            //
            //
            while (true)
            {
                Delay(1000);
                LoginHwnd = dm.FindWindowByProcess("Client.exe", "", "英雄联盟登录程序");
                if (LoginHwnd == 0)
                {
                    Runapp(Gamepath);
                    DateTime opentime = (DateTime)GetCoadDoIngTime(true, System.DateTime.Now);
                    while (true)
                    {
                        if ((int)GetCoadDoIngTime(false, opentime) >= 10 * 1000)//10秒超时
                        {
                            break;
                        }
                        Delay(500);
                        LoginHwnd = dm.FindWindowByProcess("Client.exe", "", "英雄联盟登录程序");
                        if (LoginHwnd != 0)
                        {
                            //设置状态
                            SetState("客户端已经打开");
                            //
                            break;
                        }
                    }
                    Delay(100);
                }
                else
                {
                    break;
                }
            }
            //进行绑定
            try
            {
                Delay(100);
                dm_ret = dm.BindWindowEx(LoginHwnd, "normal", "normal", "normal", "", 0);
                if (dm_ret != 1)
                {
                    MessageBox.Show("程序错误 - 错误代码 Login 002");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("程序错误 - 错误代码 Login 001");
            }
            DateTime OpenErrorTime = DateTime.Now;
            //设置状态
            SetState("绑定客户端成功");
            //
            while (true)
            {
                //设置状态
                SetState("正在自动登陆");
                //
                if ((int)GetCoadDoIngTime(false, OpenErrorTime) >= 60 * 1000)//10秒超时
                {
                    //先杀死这些进程
                    KillProcessByName("iexplore");
                    KillProcessByName("Client");
                    KillProcessByName("LolClient");
                    KillProcessByName("lol.launcher_tencent");
                    KillProcessByName("League of Legends");
                    //
                    Delay(3000);
                    dm.UnBindWindow();
                    return;
                }
                Delay(100);
                if (dm.GetWindowState(LoginHwnd, 0) == 0)
                {
                    //先杀死这些进程
                    KillProcessByName("Client");
                    //
                    Delay(3000);
                    dm.UnBindWindow();
                    return;
                }
                //如果存在大厅进程，则进行大厅操作
                Delay(100);
                int DThwnd = dm.FindWindowByProcess("LolClient.exe", "ApolloRuntimeContentWindow", "PVP.net 客户端");
                if (DThwnd != 0)
                {
                    //设置状态
                    SetState("发现游戏大厅窗口");
                    //
                    KillProcessByName("Client");
                    //
                    Delay(3000);
                    dm.UnBindWindow();
                    return;
                }
                Delay(100);
                if (dm.FindWindow("ApolloRuntimeContentWindow", "PVP.net 客户端") != 0)
                {
                    //设置状态
                    SetState("发现游戏大厅窗口");
                    //
                    KillProcessByName("Client");
                    //
                    Delay(3000);
                    dm.UnBindWindow();
                    return;
                }
                Delay(100);
                dm_ret = dm.FindPic(439, 414, 864, 486, "LgUpd_1.bmp|LgUpd_2.bmp", "000000", 0.8, 0, out intX, out intY);
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("游戏正在更新中");
                    OpenErrorTime = DateTime.Now;
                    Delay(3000);
                }
                Delay(100);
                dm_ret = dm.FindPic(444, 436, 824, 497, "VerfyQd.bmp", "000000", 0.8, 0, out intX, out intY);
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("发现疑似验证码");
                    //
                    int CdX = (int)intX;
                    int CdY = (int)intY;
                    Delay(100);
                    dm_ret = dm.FindPic(444, 436, 824, 497, "VerfyQx.bmp", "000000", 0.8, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("发现验证码");
                        //
                        string returnVeri = Verification_code(dm, 555, 387, 686, 441);//验证码处理
                        if (returnVeri.Length == 4)
                        {
                            Delay(100);
                            Zs_Move_Clk(dm, 743, 367, 10, 3);
                            Delay(100);
                            int InsertBoxHwnd = dm.GetMousePointWindow();
                            dm.SendString(InsertBoxHwnd, returnVeri);
                            Delay(100);
                            Zs_KeyP(dm, 13, 1);
                            Delay(1000);
                            //设置状态
                            SetState("验证码输入完毕");
                            //
                        }
                    }
                    else
                    {
                        Zs_Move_Clk(dm, CdX, CdY, 200, 1);
                    }
                }
                Delay(100);
                dm_ret = dm.FindPic(782, 602, 1272, 760, "ServerList.bmp|OkSelect.bmp", "000000", 0.8, 0, out intX, out intY);
                if ((int)intX > 0)
                {
                    //设置状态
                    SetState("选择游戏大区");
                    //
                    for (int i = 0; i < 5; i++)
                    {
                        Delay(33);
                        dm_ret = dm.FindPic(1027, 94, 1095, 148, "QtCloset.bmp", "000000", 0.7, 0, out intX, out intY);
                        if ((int)intX > 0)
                        {
                            //设置状态
                            SetState("关闭内置QT");
                            //
                            Zs_Move_Clk(dm, 1066, 124, 200, 1);
                            Delay(300);
                            dm.MoveTo(0, 0);
                            Delay(300);
                        }
                        else
                        {
                            break;
                        }
                    }
                    Delay(300);
                    dm_ret = dm.FindPic(21, 120, 436, 190, "OverLogin.bmp|Dxtj.bmp|WTTJ.bmp", "000000", 0.7, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("选择指定大区");
                        //
                        //选区
                        string[] Area_Zb = ChoseArea(UserArea).Split(',');
                        Zs_Move_Clk(dm, int.Parse(Area_Zb[0]) - 320, int.Parse(Area_Zb[1]) - 156, 10, 2);
                        dm.LeftDoubleClick();
                        Delay(200);
                        //设置状态
                        SetState("选择大区完毕");
                        //
                        Delay(2000);
                    }
                    else
                    {
                        Zs_Move_Clk(dm, 1192, 694, 200, 1);
                    }
                }
                else
                {
                    Delay(33);
                    dm_ret = dm.FindPic(930, 478, 1119, 589, "dlGame.bmp|LoginGam_2.bmp|LoginGam_1.bmp", "000000", 0.8, 0, out intX, out intY);
                    if ((int)intX > 0)
                    {
                        //设置状态
                        SetState("开始输入账号密码");
                        //
                        int LoginX = (int)intX;
                        int LoginY = (int)intY;
                        Delay(2000);
                        dm_ret = dm.FindPic(782, 602, 1272, 760, "ServerList.bmp|OkSelect.bmp", "000000", 0.8, 0, out intX, out intY);
                        if ((int)intX > 0)
                        {

                        }
                        else
                        {
                            Zs_Move_Clk(dm, 1092, 331, 10, 3);
                            Delay(200);
                            Zs_KeyP(dm, 8, 20);
                            Delay(200);
                            int InsertBoxHwnd = dm.GetMousePointWindow();
                            dm.SendString(InsertBoxHwnd, UserName);
                            Delay(300);
                            Zs_Move_Clk(dm, 1071, 400, 10, 3);
                            Delay(200);
                            dm.KeyPressStr(UserPassword, 20);
                            Delay(200);
                            Zs_Move_Clk(dm, LoginX, LoginY, 200, 1);
                            //设置状态
                            SetState("账号密码输入完毕");
                            SendpsdCount++;
                            if (SendpsdCount >= 5)
                            {
                                KillProcessByName("Client");
                                return;
                            }
                            //
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 选大区方法
        /// </summary>
        /// <param name="area_Number">大区名字</param>
        /// <returns>大区X和Y链接成的字符串连接符号","</returns>
        private string ChoseArea(string area_Number)
        {
            switch (area_Number)
            {
                case "艾欧尼亚":
                    AreaName = "艾欧尼亚";
                    return "420" + "," + "430";
                case "祖安":
                    AreaName = "祖安";
                    return "555" + "," + "430";
                case "诺克萨斯":
                    AreaName = "诺克萨斯";
                    return "690" + "," + "430";
                case "班德尔城":
                    AreaName = "班德尔城";
                    return "825" + "," + "430";
                case "皮尔特沃夫":
                    AreaName = "皮尔特沃夫";
                    return "960" + "," + "430";
                case "战争学院":
                    AreaName = "战争学院";
                    return "420" + "," + "480";
                case "巨神峰":
                    AreaName = "巨神峰";
                    return "555" + "," + "480";
                case "雷瑟守备":
                    AreaName = "雷瑟守备";
                    return "690" + "," + "480";
                case "钢铁烈阳":
                    AreaName = "钢铁烈阳";
                    return "825" + "," + "480";
                case "裁决之地":
                    AreaName = "裁决之地";
                    return "960" + "," + "480";
                case "黑色玫瑰":
                    AreaName = "黑色玫瑰";
                    return "420" + "," + "530";
                case "暗影岛":
                    AreaName = "暗影岛";
                    return "555" + "," + "530";
                case "均衡教派":
                    AreaName = "均衡教派";
                    return "690" + "," + "530";
                case "水晶之痕":
                    AreaName = "水晶之痕";
                    return "825" + "," + "530";
                case "影流":
                    AreaName = "影流";
                    return "960" + "," + "530";
                case "守望之海":
                    AreaName = "守望之海";
                    return "420" + "," + "580";
                case "征服之海":
                    AreaName = "征服之海";
                    return "555" + "," + "580";
                case "比尔吉沃特":
                    AreaName = "比尔吉沃特";
                    return "420" + "," + "655";
                case "德玛西亚":
                    AreaName = "德玛西亚";
                    return "555" + "," + "655";
                case "弗雷尔卓德":
                    AreaName = "弗雷尔卓德";
                    return "690" + "," + "655";
                case "无畏先锋":
                    AreaName = "无畏先锋";
                    return "825" + "," + "655";
                case "恕瑞玛":
                    AreaName = "恕瑞玛";
                    return "960" + "," + "655";
                case "扭曲丛林":
                    AreaName = "扭曲丛林";
                    return "420" + "," + "705";
                case "教育网专区":
                    AreaName = "教育网专区";
                    return "420" + "," + "790";
                case "卡拉曼达":
                    AreaName = "卡拉曼达";
                    return "690" + "," + "580";
                case "皮城警备":
                    AreaName = "皮城警备";
                    return "825" + "," + "580";
                default:
                    return "0" + "," + "0";
            }
        }
        #endregion

        #region 执行方法层
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="deleteDirectory">文件夹路径</param>
        public void DeleteFolder(string deleteDirectory)
        {
            if (Directory.Exists(deleteDirectory))
            {
                foreach (string deleteFile in Directory.GetFileSystemEntries(deleteDirectory))
                {
                    if (File.Exists(deleteFile))
                        File.Delete(deleteFile);
                    else
                        DeleteFolder(deleteFile);
                }
                Directory.Delete(deleteDirectory);
            }
        }
        /// <summary>
        /// QQ发送数据
        /// </summary>
        private bool QQsENDER(string SendString)
        {
            if (!OpenQQsend)
            {
                return false;
            }
            string SendName = Sendname;
            CDmSoft Sender_dm = new CDmSoft();
            int SendHwnd = Sender_dm.FindWindow("TXGuiFoundation", SendName);
            if (SendHwnd == 0)
            {
                return false;
            }
            try
            {
                int dm_ret = Sender_dm.BindWindow(SendHwnd, "normal", "windows", "windows", 0);
                Delay(100);
                Zs_Move_Clk(Sender_dm, 198, 441, 30, 3);
                Delay(100);
                Sender_dm.SendString(SendHwnd, SendString);
                Delay(300);
                Zs_KeyP(Sender_dm, 13, 1);
                Delay(100);
                dm_ret = Sender_dm.UnBindWindow();
                Sender_dm.Dispose();
                return true;
            }
            catch (System.Exception ex)
            {

            }
            return false;
        }
        /// <summary>
        /// 机器码判断方法
        /// </summary>
        /// <param name="overMcd"></param>
        /// <returns></returns>
        private bool CheckMechineCode_Gzs(string overMcd)
        {
            //
            //登陆成功，锁定机器码
            if (!File.Exists(LockMechineConfigPath))
            {
                //
                MechineCode = MD5Esc(Hown_dm.GetMachineCodeNoMac() + Tex_GzxLockMima.Text);
                LockMechineCode = "";
            }
            else if (Hown_dm.ReadFile(LockMechineConfigPath) == "")
            {
                //
                MechineCode = MD5Esc(Hown_dm.GetMachineCodeNoMac() + Tex_GzxLockMima.Text);
                LockMechineCode = "";
            }
            else
            {
                //直接采用锁定机器码
                MechineCode = Hown_dm.ReadFile(LockMechineConfigPath);
                LockMechineCode = MechineCode;
            }
            //机器码进行对比
            if (overMcd == EncodeStr(MechineCode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 机器码判断方法
        /// </summary>
        /// <param name="overMcd"></param>
        /// <returns></returns>
        private bool CheckMechineCode(string overMcd)
        {
            //
            //登陆成功，锁定机器码
            if (!File.Exists(LockMechineConfigPath))
            {
                //
                MechineCode = Hown_dm.GetMachineCodeNoMac();
                LockMechineCode = "";
            }
            else if (Hown_dm.ReadFile(LockMechineConfigPath) == "")
            {
                //
                MechineCode = Hown_dm.GetMachineCodeNoMac();
                LockMechineCode = "";
            }
            else
            {
                //直接采用锁定机器码
                MechineCode = Hown_dm.ReadFile(LockMechineConfigPath);
                LockMechineCode = MechineCode;
            }
            //机器码进行对比
            if (overMcd == EncodeStr(MechineCode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 利用文本输出错误信息
        /// </summary>
        /// <param name="ErrorMsg">错误信息提示内容</param>
        private void Scripts_ShowErrorMsg(string ErrorMsg)
        {
            try
            {
                //
                TwoColor_File_Deling OverCheck = new TwoColor_File_Deling("C:\\Cnbtl_ErrorMsg.txt", "write");
                //
                OverCheck.File_WriteFile(ErrorMsg + " 时间：" + System.DateTime.Now + "\r\n", "end");
                //
            }
            catch (System.Exception ex)
            {

            }
            //
            Runapp("C:\\Cnbtl_ErrorMsg.txt");
        }
        /// <summary>
        /// 将错误写入文本，心跳包错误
        /// </summary>
        /// <param name="ErrorMsg"></param>
        private void Scripts_WriteError_to_Config(string ErrorMsg)
        {
            try
            {
                //
                TwoColor_File_Deling OverCheck = new TwoColor_File_Deling("C:\\Cnbtl_ErrorMsg_Beat.txt", "write");
                //
                OverCheck.File_WriteFile(ErrorMsg + " 时间：" + System.DateTime.Now + "\r\n", "end");
                //
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="stateMsg"></param>
        private void SetState(string stateMsg)
        {
            //
            this.Invoke(new Action(() =>
            {
                Lab_StateLab.Text = stateMsg;
            }));
        }
        /// <summary>
        /// 拆分LOL路径
        /// </summary>
        /// <param name="paht">游戏完整路径，带QQlogin</param>
        /// <returns>返回游戏路径前面部分</returns>
        private string SplitGamePath(string path)
        {
            for (int i = 0; i < path.Length; i++)
            {
                try
                {
                    if (path.Substring(i, 4) == "TCLS" && i <= path.Length - 4)
                    {
                        return path.Substring(0, i);
                    }
                }
                catch (System.Exception ex)
                {

                }
            }
            return "";
        }
        /// <summary>
        /// 从文件全路径中返回文件相关信息
        /// </summary>
        /// <param name="filepath">文件全路径</param>
        /// <param name="G_filepath">返回 文件根路径</param>
        /// <param name="filename">返回 文件名</param>
        /// <param name="fileobjname">返回 文件拓展名</param>
        private void GetFilePathMsg(string filepath, out string G_filepath, out string filename, out string fileobjname)
        {
            string P_str_all = filepath;
            G_filepath = P_str_all.Substring(0, P_str_all.LastIndexOf("\\") + 1);
            filename = P_str_all.Substring(P_str_all.LastIndexOf("\\") + 1, P_str_all.LastIndexOf(".") - (P_str_all.LastIndexOf("\\") + 1));
            fileobjname = P_str_all.Substring(P_str_all.LastIndexOf(".") + 1, P_str_all.Length - P_str_all.LastIndexOf(".") - 1);
        }
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string EncodeStr(string input)
        {
            string tmp = "";
            for (int i = 0; i < input.Length; i++)
                tmp += KEY2[KEY3.IndexOf(input[i])];
            string tmp2 = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(tmp));
            tmp = "";
            for (int i = 0; i < tmp2.Length; i++)
                tmp += KEY2[KEY3.IndexOf(tmp2[i])];
            return tmp;
        }
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string DecodeStr(string input)
        {
            string tmp = "";
            for (int i = 0; i < input.Length; i++)
                tmp += KEY3[KEY2.IndexOf(input[i])];
            string tmp2 = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(tmp));
            tmp = "";
            for (int i = 0; i < tmp2.Length; i++)
                tmp += KEY3[KEY2.IndexOf(tmp2[i])];
            return tmp;
        }

        public string CheckResult(string result, int softId, int codeId, string checkKey)
        {
            //对验证码结果进行校验，防止dll被替换
            if (string.IsNullOrEmpty(result))
                return result;
            else
            {
                if (result[0] == '-')
                    //服务器返回的是错误代码
                    return result;

                string[] modelReult = result.Split('_');
                //解析出服务器返回的校验结果
                string strServerKey = modelReult[0];
                string strCodeResult = modelReult[1];
                //本地计算校验结果
                string localInfo = softId.ToString() + checkKey + codeId.ToString() + strCodeResult.ToUpper();
                string strLocalKey = MD5Encoding(localInfo).ToUpper();
                //相等则校验通过
                if (strServerKey.Equals(strLocalKey))
                    return strCodeResult;
                return "结果校验不正确";
            }
        }

        /// <summary>
        /// MD5 加密字符串
        /// </summary>
        /// <param name="rawPass">源字符串</param>
        /// <returns>加密后字符串</returns>
        public static string MD5Encoding(string rawPass)
        {
            // 创建MD5类的默认实例：MD5CryptoServiceProvider
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(rawPass);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                // 以十六进制格式格式化
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取文件MD5校验值
        /// </summary>
        /// <param name="filePath">校验文件路径</param>
        /// <returns>MD5校验字符串</returns>
        private string GetFileMD5(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] md5byte = md5.ComputeHash(fs);
            int i, j;
            StringBuilder sb = new StringBuilder(16);
            foreach (byte b in md5byte)
            {
                i = Convert.ToInt32(b);
                j = i >> 4;
                sb.Append(Convert.ToString(j, 16));
                j = ((i << 4) & 0x00ff) >> 4;
                sb.Append(Convert.ToString(j, 16));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 随机生成英文名字
        /// </summary>
        /// <returns></returns>
        private static string GenerateSurname()
        {
            string name = string.Empty;
            string[] currentConsonant;
            string[] vowels = "a,a,a,a,a,e,e,e,e,e,e,e,e,e,e,e,i,i,i,o,o,o,u,y,ee,ee,ea,ea,ey,eau,eigh,oa,oo,ou,ough,ay".Split(',');
            string[] commonConsonants = "s,s,s,s,t,t,t,t,t,n,n,r,l,d,sm,sl,sh,sh,th,th,th".Split(',');
            string[] averageConsonants = "sh,sh,st,st,b,c,f,g,h,k,l,m,p,p,ph,wh".Split(',');
            string[] middleConsonants = "x,ss,ss,ch,ch,ck,ck,dd,kn,rt,gh,mm,nd,nd,nn,pp,ps,tt,ff,rr,rk,mp,ll".Split(','); //Can't start
            string[] rareConsonants = "j,j,j,v,v,w,w,w,z,qu,qu".Split(',');
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            int[] lengthArray = new int[] { 2, 2, 2, 2, 2, 2, 3, 3, 3, 4 }; //Favor shorter names but allow longer ones
            int length = lengthArray[rng.Next(lengthArray.Length)];
            for (int i = 0; i < length; i++)
            {
                int letterType = rng.Next(1000);
                if (letterType < 775) currentConsonant = commonConsonants;
                else if (letterType < 875 && i > 0) currentConsonant = middleConsonants;
                else if (letterType < 985) currentConsonant = averageConsonants;
                else currentConsonant = rareConsonants;
                name += currentConsonant[rng.Next(currentConsonant.Length)];
                name += vowels[rng.Next(vowels.Length)];
                if (name.Length > 4 && rng.Next(1000) < 800) break; //Getting long, must roll to save
                if (name.Length > 6 && rng.Next(1000) < 950) break; //Really long, roll again to save
                if (name.Length > 7) break; //Probably ridiculous, stop building and add ending
            }
            int endingType = rng.Next(1000);
            if (name.Length > 6)
                endingType -= (name.Length * 25); //Don't add long endings if already long
            else
                endingType += (name.Length * 10); //Favor long endings if short
            if (endingType < 400) { } // Ends with vowel
            else if (endingType < 775) name += commonConsonants[rng.Next(commonConsonants.Length)];
            else if (endingType < 825) name += averageConsonants[rng.Next(averageConsonants.Length)];
            else if (endingType < 840) name += "ski";
            else if (endingType < 860) name += "son";
            else if (Regex.IsMatch(name, "(.+)(ay|e|ee|ea|oo)$") || name.Length < 5)
            {
                name = "Mc" + name.Substring(0, 1).ToUpper() + name.Substring(1);
                return name;
            }
            else name += "ez";
            name = name.Substring(0, 1).ToUpper() + name.Substring(1); //Capitalize first letter
            return name;
        }

        bool CheckSid()
        {
            if (SoftID <= 0)
            {
                MessageBox.Show("请先设置软件id");
                return false;

            }
            if (string.IsNullOrEmpty(SoftKey))
            {
                MessageBox.Show("请先设置软件key");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 根据进程名字关闭指定进程
        /// </summary>
        /// <param name="ProssName">进程名</param>
        private void KillProcessByName(string ProssName)
        {
            Process[] pp = Process.GetProcessesByName(ProssName);
            for (int i = 0; i < pp.Length; i++)
            {
                if (pp[i].ProcessName == ProssName)
                {
                    pp[i].Kill();
                }
            }
        }
        /// <summary>
        /// 根据进程名获得进程PID
        /// </summary>
        /// <param name="ProssName">进城名</param>
        /// <returns>进城PID</returns>
        private int GetProcessPid(string ProssName)
        {
            string name = ProssName;//name就是进程的名称,不带后缀
            int pid = -1;
            Process[] pp = Process.GetProcessesByName(name);
            for (int i = 0; i < pp.Length; i++)
            {
                if (pp[i].ProcessName == name)
                {
                    pid = pp[i].Id;//这个就是进程的ID     
                }
            }
            return pid;
        }
        /// <summary>
        /// 计算一段代码的运行时间
        /// </summary>
        /// <param name="Gettime">true为获取时间</param>
        /// <param name="Datatime">上一次的时间截</param>
        /// <returns>当参数为 0 ，返回值为datatime类型，当参数为datatime类型时，返回值为int</returns>
        private object GetCoadDoIngTime(bool Gettime, DateTime Datatime)
        {
            DateTime beforDT = System.DateTime.Now;
            if (Gettime)
            {
                return beforDT;
            }
            else
            {
                TimeSpan ts = beforDT.Subtract(Datatime);
                return (int)ts.TotalMilliseconds;
            }
        }
        /// <summary>
        /// 去掉字符串中的空格
        /// </summary>
        /// <param name="str">需要去掉空格的字符串</param>
        /// <returns>去掉空格后的字符串</returns>
        private string ThickNull(string str)
        {
            char[] P_chr = str.ToCharArray();
            IEnumerator P_ienumerator_chr = P_chr.GetEnumerator();
            StringBuilder P_stringbuilder = new StringBuilder();
            while (P_ienumerator_chr.MoveNext())
            {
                P_stringbuilder.Append(
                (char)P_ienumerator_chr.Current != ' ' ?
                P_ienumerator_chr.Current.ToString() : string.Empty);
            }
            return P_stringbuilder.ToString();
        }
        /// <summary>
        /// 运行一个指定文件或者程序
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <returns>失败返回false</returns>
        private bool Runapp(string Path)
        {
            try
            {
                Process pro = new Process();
                pro.StartInfo.FileName = @Path;
                pro.Start();
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 延迟方法
        /// </summary>
        /// <param name="Delaytime"></param>
        private void Delay(int Delaytime)
        {
            Thread.Sleep(Delaytime);
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public string MD5Esc(string encryptString)
        {
            byte[] result = Encoding.Default.GetBytes(encryptString);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string encryptResult = BitConverter.ToString(output).Replace("-", "");
            return encryptResult;
        }
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <returns></returns>
        private bool SetValueFormConfig()
        {
            try
            {
                //当前进行的号
                try
                {
                    LoginIndex = int.Parse(Tex_NowDeal.Text.Trim());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("当前进行的号设置有误,必须为纯数字,请重新设置", "配置异常");
                    return false;
                }
                if (LoginIndex <= 0)
                {
                    MessageBox.Show("当前进行的号设置有误,必须大于 0,请重新设置", "配置异常");
                    return false;
                }
                LoginIndex--;
                /// <summary>
                /// 游戏路径
                /// </summary>
                Gamepath = Tex_GamePath.Text.Trim();
                if (Gamepath == "")
                {
                    MessageBox.Show("游戏路径设置有误,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 账号密码集合
                /// </summary>
                //整合大号文本路径
                string Bg_Path = "\\Config\\OneRoad_User" + ".txt";
                //读取这个文本
                TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + Bg_Path, "read");
                ArrayList LoginList = OverCheck.File_ReadFile(-1);
                Usermsg.Clear();
                foreach (string str in LoginList)
                {
                    if (ThickNull(str) != "")
                    {
                        if (str.Split('-').Length < 4)
                        {
                            MessageBox.Show("账号文本设置有误,请重新设置", "配置异常");
                            return false;
                        }
                        else
                        {
                            Usermsg.Add(str);
                        }
                    }
                }
                if (Usermsg.Count <= 0)
                {
                    MessageBox.Show("账号文本设置有误,请重新设置", "配置异常");
                    return false;
                }
                else
                {
                    foreach (string str in LoginList)
                    {
                        try
                        {
                            string tstn = Usermsg[LoginIndex].Split('-')[0];
                            tstn = Usermsg[LoginIndex].Split('-')[1];
                            tstn = Usermsg[LoginIndex].Split('-')[2];
                            tstn = Usermsg[LoginIndex].Split('-')[3].Split('|')[0];
                            tstn = Usermsg[LoginIndex].Split('-')[3].Split('|')[1];
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("账号文本设置有误,请重新设置", "配置异常");
                            return false;
                        }
                    }
                }
                UserNumCount = Usermsg.Count;
                /// <summary>
                /// 自动换号
                /// </summary>
                OpenChangeUser = Che_ChangeUser.Checked;
                /// <summary>
                /// 召唤师峡谷人机
                /// </summary>
                try
                {
                    Zhs_Rj_Class = int.Parse(Tex_zhsRj_Class.Text.Trim());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("召唤师人机等级设置有误,必须设置纯数字,请重新设置", "配置异常");
                    return false;
                }
                if (Zhs_Rj_Class < 0 || Zhs_Rj_Class > 30)
                {
                    MessageBox.Show("召唤师人机等级设置有误,必须在 0-30 以内,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 统治人机
                /// </summary>
                try
                {
                    Tz_Rj_Class = int.Parse(Tex_Tzrj_Class.Text.Trim());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("统治战场人机等级设置有误,必须设置纯数字,请重新设置", "配置异常");
                    return false;
                }
                if (Tz_Rj_Class < 0 || Tz_Rj_Class > 30)
                {
                    MessageBox.Show("统治战场等级设置有误,必须在 0-30 以内,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 统治匹配
                /// </summary>
                try
                {
                    Tz_Pp_Class = int.Parse(Tex_TzPp_Class.Text.Trim());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("统治战场匹配等级设置有误,必须设置纯数字,请重新设置", "配置异常");
                    return false;
                }
                if (Tz_Pp_Class < 0 || Tz_Pp_Class > 30)
                {
                    MessageBox.Show("统治战场匹配等级设置有误,必须在 0-30 以内,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 扭曲匹配
                /// </summary>
                try
                {
                    Nq_Pp_Class = int.Parse(Tex_NqPP_Class.Text.Trim());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("扭曲丛林匹配等级设置有误,必须设置纯数字,请重新设置", "配置异常");
                    return false;
                }
                if (Nq_Pp_Class < 0 || Nq_Pp_Class > 30)
                {
                    MessageBox.Show("扭曲丛林匹配等级设置有误,必须在 0-30 以内,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 极地匹配
                /// </summary>
                try
                {
                    Jd_Pp_Class = int.Parse(Tex_JdPP_Class.Text.Trim());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("极地乱斗匹配等级设置有误,必须设置纯数字,请重新设置", "配置异常");
                    return false;
                }
                if (Jd_Pp_Class < 0 || Jd_Pp_Class > 30)
                {
                    MessageBox.Show("极地乱斗匹配等级设置有误,必须在 0-30 以内,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 开启信息记录窗口
                /// </summary>
                OpenCheckMsgWindow = Che_OpenZhmsgCheck.Checked;
                /// <summary>
                /// Cpu降低程度
                /// </summary>
                try
                {
                    Cpudown = int.Parse(Tex_CpuDown.Text.Trim());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("CPU占用率优化设置有误,必须设置纯数字,请重新设置", "配置异常");
                    return false;
                }
                if (Cpudown < 0 || Cpudown >= 80)
                {
                    MessageBox.Show("CPU占用率优化设置有误,必须在 0-79 以内,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 脚本模式
                /// </summary>
                SoftMod = Com_SoftMod.SelectedIndex;
                /// <summary>
                /// 是否开启打码兔
                /// </summary>
                OpenDm2 = Che_Dm2.Checked;
                /// <summary>
                /// 是否开启优优云
                /// </summary>
                OpenUu = Che_uu.Checked;
                /// <summary>
                /// 是否开启大漠
                /// </summary>
                OpenDm = Che_Dm.Checked;
                /// <summary>
                /// 打码兔账号
                /// </summary>
                Dm2User = Tex_DM2username.Text.Trim();
                /// <summary>
                /// 打码兔密码
                /// </summary>
                Dm2Psd = Tex_DM2psd.Text.Trim();
                /// <summary>
                /// 优优云账号
                /// </summary>
                UUuser = Tex_UuUSER.Text.Trim();
                /// <summary>
                /// 优优云密码
                /// </summary>
                UUpsd = Tex_UupSD.Text.Trim();
                /// <summary>
                /// 大漠IP
                /// </summary>
                DMip = Tex_DM_Ip.Text.Trim() + ":12346";
                /// <summary>
                /// 出问题自动换大漠
                /// </summary>
                ErrcgDm = Che_TrunDm.Checked;
                /// <summary>
                /// 7级以后随机换图
                /// </summary>
                SjcgMap = Che_Sjcgmap.Checked;
                /// <summary>
                /// 换号时间
                /// </summary>
                try
                {
                    CguserTime = int.Parse(Tex_CguserTime.Text.Trim());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("更换账号时间设置有误,必须设置纯数字,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 是否有开启QQ监控
                /// </summary>
                OpenQQsend = Che_OpenQQjk.Checked;
                /// <summary>
                /// 本机备注
                /// </summary>
                MyBackUp = Tex_MechineBacup.Text;
                if (MyBackUp == "")
                {
                    MessageBox.Show("本机备注设置有误,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 发送数据对象
                /// </summary>
                Sendname = Tex_QQsendername.Text;
                if (Sendname == "")
                {
                    MessageBox.Show("QQ数据发送对象设置有误,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 是否开启中央监控
                /// </summary>
                OpenZyjk = Che_OpenZyjk.Checked;
                /// <summary>
                /// 主机IP地址
                /// </summary>
                HostIp = Tex_HostIP.Text;
                if (HostIp == "")
                {
                    MessageBox.Show("中控主机IP设置有误,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 主机端口号
                /// </summary>
                HostPott = Tex_HostPort.Text;
                if (HostPott == "")
                {
                    MessageBox.Show("中控主机端口号设置有误,请重新设置", "配置异常");
                    return false;
                }
                /// <summary>
                /// 开启全场Carry模式
                /// </summary>
                OpenTzCarry = Che_TzCarry.Checked;
                /// <summary>
                /// 开启占塔模式
                /// </summary>
                OpenStmod = Che_TzShouT.Checked;
                /// <summary>
                /// 开启定时关机
                /// </summary>
                OpenDsgj = Che_DinshiExit.Checked;
                /// <summary>
                /// 停止时间
                /// </summary>
                ExitTime = Datetime_MissionTime.Value.ToString();
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// 读取配置，把配置写入窗体
        /// </summary>
        private void ConFigTo_Form()
        {
            //
            try
            {
                //读取这个文本
                TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + "\\config\\LastGameTime.txt", "read");
                ArrayList LastTime = OverCheck.File_ReadFile(-1);
                if (LastTime[0].ToString().Trim() != "")
                {
                    Lab_CloseTime.Text = LastTime[0].ToString();
                }
            }
            catch (System.Exception ex)
            {

            }
            //
            ArrayList Rtary = ReadConfig();
            if (Rtary.Count != 0)
            {
                /// <summary>
                /// 游戏路径
                /// </summary>
                Tex_GamePath.Text = Rtary[0].ToString();
                /// <summary>
                /// 自动换号
                /// </summary>
                Che_ChangeUser.Checked = Convert.ToBoolean(Rtary[1].ToString());
                /// <summary>
                /// 召唤师峡谷人机
                /// </summary>
                Tex_zhsRj_Class.Text = Rtary[2].ToString();
                /// <summary>
                /// 统治人机
                /// </summary>
                Tex_Tzrj_Class.Text = Rtary[3].ToString();
                /// <summary>
                /// 统治匹配
                /// </summary>
                Tex_TzPp_Class.Text = Rtary[4].ToString();
                /// <summary>
                /// 开启信息记录窗口
                /// </summary>
                Che_OpenZhmsgCheck.Checked = Convert.ToBoolean(Rtary[5].ToString());
                /// <summary>
                /// Cpu降低程度
                /// </summary>
                Tex_CpuDown.Text = Rtary[6].ToString();
                /// <summary>
                /// 脚本模式
                /// </summary>
                Com_SoftMod.SelectedIndex = int.Parse(Rtary[7].ToString());
                /// <summary>
                /// 是否开启打码兔
                /// </summary>
                Che_Dm2.Checked = Convert.ToBoolean(Rtary[8].ToString());
                /// <summary>
                /// 是否开启优优云
                /// </summary>
                Che_uu.Checked = Convert.ToBoolean(Rtary[9].ToString());
                /// <summary>
                /// 是否开启大漠
                /// </summary>
                Che_Dm.Checked = Convert.ToBoolean(Rtary[10].ToString());
                /// <summary>
                /// 打码兔账号
                /// </summary>
                Tex_DM2username.Text = Rtary[11].ToString();
                /// <summary>
                /// 打码兔密码
                /// </summary>
                Tex_DM2psd.Text = Rtary[12].ToString();
                /// <summary>
                /// 优优云账号
                /// </summary>
                Tex_UuUSER.Text = Rtary[13].ToString();
                /// <summary>
                /// 优优云密码
                /// </summary>
                Tex_UupSD.Text = Rtary[14].ToString();
                /// <summary>
                /// 大漠IP
                /// </summary>
                Tex_DM_Ip.Text = Rtary[15].ToString();
                /// <summary>
                /// 出问题自动换大漠
                /// </summary>
                Che_TrunDm.Checked = Convert.ToBoolean(Rtary[16].ToString());
                /// <summary>
                /// 7级以后随机换图
                /// </summary>
                Che_Sjcgmap.Checked = Convert.ToBoolean(Rtary[17].ToString());
                /// <summary>
                /// 换号时间
                /// </summary>
                Tex_CguserTime.Text = Rtary[18].ToString();
                //客户前一次登陆成功的机器码
                NowMecod = Rtary[19].ToString();
                //用户账号
                Tex_UserName_Lg.Text = Rtary[20].ToString();
                //用户密码
                Tex_Psd_Lg.Text = Rtary[21].ToString();
                /// <summary>
                /// 是否有开启QQ监控
                /// </summary>
                Che_OpenQQjk.Checked = Convert.ToBoolean(Rtary[22].ToString());
                /// <summary>
                /// 本机备注
                /// </summary>
                Tex_MechineBacup.Text = Rtary[23].ToString();
                /// <summary>
                /// 发送数据对象
                /// </summary>
                Tex_QQsendername.Text = Rtary[24].ToString();
                /// <summary>
                /// 是否开启中央监控
                /// </summary>
                Che_OpenZyjk.Checked = Convert.ToBoolean(Rtary[25].ToString());
                /// <summary>
                /// 主机IP地址
                /// </summary>
                Tex_HostIP.Text = Rtary[26].ToString();
                /// <summary>
                /// 主机端口号
                /// </summary>
                Tex_HostPort.Text = Rtary[27].ToString();
                //客户前一次登陆成功的机器码
                NowMecod2 = Rtary[28].ToString();
                //用户账号
                Tex_GzxUserName.Text = Rtary[29].ToString();
                //用户密码
                Tex_GzxPsd.Text = Rtary[30].ToString();
                //锁定密码
                Tex_GzxLockMima.Text = Rtary[31].ToString();
                /// <summary>
                /// 开启全场Carry模式
                /// </summary>
                Che_TzCarry.Checked = Convert.ToBoolean(Rtary[32].ToString());
                /// <summary>
                /// 开启占塔模式
                /// </summary>
                Che_TzShouT.Checked = Convert.ToBoolean(Rtary[33].ToString());
                /// <summary>
                /// 开启定时关机
                /// </summary>
                Che_DinshiExit.Checked = Convert.ToBoolean(Rtary[34].ToString());
                /// <summary>
                /// 停止时间
                /// </summary>
                Datetime_MissionTime.Value = Convert.ToDateTime(Rtary[35].ToString());
                /// <summary>
                /// 扭曲匹配
                /// </summary>
                Tex_NqPP_Class.Text = Rtary[36].ToString();
                /// <summary>
                /// 极地匹配
                /// </summary>
                Tex_JdPP_Class.Text = Rtary[37].ToString();
            }
        }

        /// <summary>
        /// 保存窗体配置
        /// </summary>
        private void Form_To_ConFig()
        {
            //
            //先将各个控件的值存到arraylist里面
            ArrayList ConfigList = new ArrayList();
            File.Delete(Application.StartupPath + "\\ScripsConfig.txt");
            //
            /// <summary>
            /// 授权码
            /// </summary>          
            //ConfigList.Add(Tex_SqmText.Text);
            /// <summary>
            /// 游戏路径
            /// </summary>
            ConfigList.Add(Tex_GamePath.Text.ToString());
            /// <summary>
            /// 自动换号
            /// </summary>
            ConfigList.Add(Che_ChangeUser.Checked.ToString());
            /// <summary>
            /// 召唤师峡谷人机
            /// </summary>
            ConfigList.Add(Tex_zhsRj_Class.Text.ToString());
            /// <summary>
            /// 统治人机
            /// </summary>
            ConfigList.Add(Tex_Tzrj_Class.Text.ToString());
            /// <summary>
            /// 统治匹配
            /// </summary>
            ConfigList.Add(Tex_TzPp_Class.Text.ToString());
            /// <summary>
            /// 开启信息记录窗口
            /// </summary>
            ConfigList.Add(Che_OpenZhmsgCheck.Checked.ToString());
            /// <summary>
            /// Cpu降低程度
            /// </summary>
            ConfigList.Add(Tex_CpuDown.Text.ToString());
            /// <summary>
            /// 脚本模式
            /// </summary>
            ConfigList.Add(Com_SoftMod.SelectedIndex.ToString());
            /// <summary>
            /// 是否开启打码兔
            /// </summary>
            ConfigList.Add(Che_Dm2.Checked.ToString());
            /// <summary>
            /// 是否开启优优云
            /// </summary>
            ConfigList.Add(Che_uu.Checked.ToString());
            /// <summary>
            /// 是否开启大漠
            /// </summary>
            ConfigList.Add(Che_Dm.Checked.ToString());
            /// <summary>
            /// 打码兔账号
            /// </summary>
            ConfigList.Add(Tex_DM2username.Text.ToString());
            /// <summary>
            /// 打码兔密码
            /// </summary>
            ConfigList.Add(Tex_DM2psd.Text.ToString());
            /// <summary>
            /// 优优云账号
            /// </summary>
            ConfigList.Add(Tex_UuUSER.Text.ToString());
            /// <summary>
            /// 优优云密码
            /// </summary>
            ConfigList.Add(Tex_UupSD.Text.ToString());
            /// <summary>
            /// 大漠IP
            /// </summary>
            ConfigList.Add(Tex_DM_Ip.Text.ToString());
            /// <summary>
            /// 出问题自动换大漠
            /// </summary>
            ConfigList.Add(Che_TrunDm.Checked.ToString());
            /// <summary>
            /// 7级以后随机换图
            /// </summary>
            ConfigList.Add(Che_Sjcgmap.Checked.ToString());
            /// <summary>
            /// 换号时间
            /// </summary>
            ConfigList.Add(Tex_CguserTime.Text.ToString());
            //客户前一次登陆成功的机器码
            ConfigList.Add(NowMecod.ToString());
            //用户账号
            ConfigList.Add(Tex_UserName_Lg.Text.ToString());
            //用户密码
            ConfigList.Add(Tex_Psd_Lg.Text.ToString());
            /// <summary>
            /// 是否有开启QQ监控
            /// </summary>
            ConfigList.Add(Che_OpenQQjk.Checked.ToString());
            /// <summary>
            /// 本机备注
            /// </summary>
            ConfigList.Add(Tex_MechineBacup.Text.ToString());
            /// <summary>
            /// 发送数据对象
            /// </summary>
            ConfigList.Add(Tex_QQsendername.Text.ToString());
            /// <summary>
            /// 是否开启中央监控
            /// </summary>
            ConfigList.Add(Che_OpenZyjk.Checked.ToString());
            /// <summary>
            /// 主机IP地址
            /// </summary>
            ConfigList.Add(Tex_HostIP.Text.ToString());
            /// <summary>
            /// 主机端口号
            /// </summary>
            ConfigList.Add(Tex_HostPort.Text.ToString());
            //客户前一次登陆成功的机器码
            ConfigList.Add(NowMecod2.ToString());
            //用户账号
            ConfigList.Add(Tex_GzxUserName.Text.ToString());
            //用户密码
            ConfigList.Add(Tex_GzxPsd.Text.ToString());
            //锁定密码
            ConfigList.Add(Tex_GzxLockMima.Text.ToString());
            /// <summary>
            /// 开启全场Carry模式
            /// </summary>
            ConfigList.Add(Che_TzCarry.Checked.ToString());
            /// <summary>
            /// 开启占塔模式
            /// </summary>
            ConfigList.Add(Che_TzShouT.Checked.ToString());
            /// <summary>
            /// 开启定时关机
            /// </summary>
            ConfigList.Add(Che_DinshiExit.Checked.ToString());
            /// <summary>
            /// 停止时间
            /// </summary>
            ConfigList.Add(Datetime_MissionTime.Value.ToString());
            /// <summary>
            /// 扭曲匹配
            /// </summary>
            ConfigList.Add(Tex_NqPP_Class.Text.ToString());
            /// <summary>
            /// 极地匹配
            /// </summary>
            ConfigList.Add(Tex_JdPP_Class.Text.ToString());
            //
            WriteConfig(ConfigList);
        }
        /// <summary>
        /// 写入配置文件方法
        /// </summary>
        /// <param name="ConfigAry">配置数组</param>
        private void WriteConfig(ArrayList ConfigAry)
        {
            foreach (string configStr in ConfigAry)
            {
                TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + "\\ScripsConfig.txt", "write");
                OverCheck.File_WriteFile(configStr + "\r\n", "end");
            }
        }
        /// <summary>
        /// 读取配置文件方法
        /// </summary>
        private ArrayList ReadConfig()
        {
            ArrayList Rtary = new ArrayList();
            TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + "\\ScripsConfig.txt", "read");
            Rtary = OverCheck.File_ReadFile(-1);
            return Rtary;
        }
        #endregion

        #region 方法层
        /// <summary>
        /// 软件到期提示
        /// </summary>
        private string scriptendmsg = "";
        /// <summary>
        /// 软件是否到期
        /// </summary>
        private bool IsScriptsEnd = false;
        /// <summary>
        /// 重新认证服务器
        /// </summary>
        private void Re_Bind_Server()
        {
            string msD = "";
            if (loginpUD == "")
            {
                loginpUD = Fz_Cph;
            }
            AccountHandle AHD = new AccountHandle();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Clear();
            if (FzMod == "0")
            {
                Dic = AHD.personHeartBeat(Fz_UserName, loginpUD, MechineCode);
            }
            else
            {
                Dic = AHD.heartBeat(Fz_UserName, loginpUD, MechineCode);
            }
            //
            if (Dic != null)
            {
                string result = (string)Dic["msgResult"];
                if (result == "0")
                {
                    //
                    msD = (string)Dic["msgDesc"];
                    //
                    Scripts_WriteError_to_Config(msD);
                    //
                    CanVerifycOUNT++;
                }
                else
                {
                    //
                    File.Delete("C:\\Cnbtl_ErrorMsg_Beat.txt");
                    //
                    CanVerifycOUNT = 0;
                    //
                    IsScriptsEnd = false;
                    return;
                }
            }
            else
            {
                CanVerifycOUNT++;
            }
            //}
            if (CanVerifycOUNT >= MaxVerifyCount)
            {
                IsScriptsEnd = true;
                scriptendmsg = msD + " 程序即将关闭！对您带来不必要的麻烦我们深表歉意！";
            }
            //
        }
        /// <summary>
        /// 心跳线程
        /// </summary>
        private void Thd_Rebind_Server()
        {
            int ErrorMaxCount = 20;
            if (FzMod == "0")
            {
                ErrorMaxCount = 60;
            }
            else
            {
                ErrorMaxCount = 20;
            }
            CDmSoft ConnectDm = new CDmSoft();
            int ConnectCount = 0;
            while (true)
            {
                try
                {
                    ConnectDm.delay(31 * 1000);
                    if (ConnectCount >= ErrorMaxCount)
                    {
                        Re_Bind_Server();
                        ConnectCount = 0;
                    }
                    else
                    {
                        ConnectCount++;
                    }
                    Thread.Sleep(1);
                }
                catch (System.Exception ex)
                {

                }
            }
        }
        /// <summary>
        /// 主执行线程
        /// </summary>
        private void Scripets_Working()
        {
            DateTime LobbyOverTime = DateTime.Now;
            DateTime LoginBeginTime = DateTime.Now;
            bool IsGGlogin = false;
            bool CanBeginAddtime = false;
            int ErrorHwnd = 0;
            //
            if (IsVerify)
            {
                while (true)
                {
                    //异常检测
                    ErrorHwnd = Own_Dm.FindWindow("#32770", "Error Report");
                    if (ErrorHwnd != 0)
                    {
                        //设置状态
                        SetState("调度—游戏窗口崩溃_1");
                        //
                        Own_Dm.SetWindowState(ErrorHwnd, 0);
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(3000);
                    }
                    //异常检测
                    ErrorHwnd = Own_Dm.FindWindow("#32770", "Error");
                    if (ErrorHwnd != 0)
                    {
                        //设置状态
                        SetState("调度-游戏窗口崩溃_2");
                        //
                        Own_Dm.SetWindowState(ErrorHwnd, 13);
                    }
                    //异常检测
                    ErrorHwnd = Own_Dm.FindWindow("#32770", "连接断开");
                    if (ErrorHwnd != 0)
                    {
                        //设置状态
                        SetState("调度-游戏窗口崩溃_3");
                        //
                        Own_Dm.SetWindowState(ErrorHwnd, 13);
                    }
                    //异常检测
                    ErrorHwnd = Own_Dm.FindWindow("#32770", "TS 警告码");
                    if (ErrorHwnd != 0)
                    {
                        //设置状态
                        SetState("TS 警告码");
                        //
                        Own_Dm.SetWindowState(ErrorHwnd, 0);
                        KillProcessByName("LolClient");
                        KillProcessByName("lol.launcher_tencent");
                        KillProcessByName("League of Legends");
                        Delay(3000);
                    }
                    //设置状态
                    SetState("任务调度中");
                    //
                    try
                    {
                        Delay(200);
                        int DThwnd = Own_Dm.FindWindowByProcess("League of Legends.exe", "RiotWindowClass", "League of Legends (TM) Client");
                        if (DThwnd != 0)
                        {
                            IsGGlogin = false;
                            KillProcessByName("Client");
                            CanBeginAddtime = false;
                            Login_Dm.UnBindWindow();
                            Lobby_Dm.UnBindWindow();
                            Game_Dm.UnBindWindow();
                            //如果存在游戏进程，则进行游戏
                            //调试位置
                            //GameMod = 4;
                            //
                            if (GameMod == 0)
                            {
                                Zh_Game(Game_Dm, DThwnd);
                            }
                            else if (GameMod == 1 || GameMod == 2)
                            {
                                Tz_Game(Game_Dm, DThwnd);
                            }
                            else if (GameMod == 3)
                            {
                                Nq_Game(Game_Dm, DThwnd);
                            }
                            else if (GameMod == 4)
                            {
                                Jd_Game(Game_Dm, DThwnd);
                            }
                        }
                        else
                        {
                            //如果存在大厅进程，则进行大厅操作
                            Delay(200);
                            DThwnd = Own_Dm.FindWindowByProcess("LolClient.exe", "ApolloRuntimeContentWindow", "PVP.net 客户端");
                            if (DThwnd != 0)
                            {
                                //脚本有异常，需要停止
                                if (IsScriptsEnd)
                                {
                                    Scripts_ShowErrorMsg(scriptendmsg);
                                    Thread.Sleep(2000);
                                    Environment.Exit(0);
                                }
                                IsGGlogin = false;
                                KillProcessByName("Client");
                                CanBeginAddtime = false;
                                Login_Dm.UnBindWindow();
                                Lobby_Dm.UnBindWindow();
                                Game_Dm.UnBindWindow();
                                Lobby(Lobby_Dm, DThwnd);
                            }
                            else
                            {
                                //如果大厅进程还存在，就不进行登陆
                                if (GetProcessPid("LolClient") == -1)
                                {
                                    CanBeginAddtime = false;
                                    Login_Dm.UnBindWindow();
                                    Lobby_Dm.UnBindWindow();
                                    Game_Dm.UnBindWindow();
                                    //如果都没有，进行登陆操作
                                    if (!IsGGlogin)
                                    {
                                        //设置状态
                                        SetState("准备进行登陆");
                                        //
                                        UserLogin(Login_Dm);
                                        IsGGlogin = true;
                                        LoginBeginTime = DateTime.Now;
                                    }
                                    else
                                    {
                                        //设置状态
                                        SetState("登陆重置等1分钟");
                                        //
                                        if ((int)GetCoadDoIngTime(false, LoginBeginTime) >= 60 * 1000)//60秒超时
                                        {
                                            //设置状态
                                            SetState("登陆重置完毕");
                                            //
                                            IsGGlogin = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (!CanBeginAddtime)
                                    {
                                        LobbyOverTime = DateTime.Now;
                                        CanBeginAddtime = true;
                                    }
                                    else
                                    {
                                        //设置状态
                                        SetState("窗口异常等待1分钟");
                                        //
                                        if ((int)GetCoadDoIngTime(false, LobbyOverTime) >= 60 * 1000)//60秒超时
                                        {
                                            IsGGlogin = false;
                                            //设置状态
                                            SetState("游戏窗口异常等待完成");
                                            //
                                            CanBeginAddtime = false;
                                            //先杀死这些进程
                                            KillProcessByName("LolClient");
                                            KillProcessByName("lol.launcher_tencent");
                                            KillProcessByName("League of Legends");
                                        }
                                    }
                                }
                            }
                        }
                        Thread.Sleep(1000);
                        //检测心跳线程
                        if (!HeartBeat.IsAlive)
                        {
                            HeartBeat = new Thread(Thd_Rebind_Server);
                            HeartBeat.SetApartmentState(ApartmentState.MTA);
                            HeartBeat.Start();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        //设置状态
                        SetState("软件可能被强行停止");
                    }
                }
            }
            //
            this.Invoke(new Action(() =>
            {
                StateLabel.Text = "当前状态：停止中";
            }));
        }
        /// <summary>
        /// 软件启动方法
        /// </summary>
        private void Scripets_Begin()
        {
            if (IsVerify)
            {
                bool Canstill = false;
                if (!HoleDeal_Thread.IsAlive)
                {
                    this.Invoke(new Action(() =>
                    {
                        Btn_DelayDtop.Enabled = true;
                        DelayStop = false;
                        if (!DelayStop)
                        {
                            if (Btn_DelayDtop.BackColor == Color.FromArgb(128, 128, 255))
                            {
                                Btn_DelayDtop.Text = "延迟停止软件( F10 )";
                                Btn_DelayDtop.BackColor = Color.FromArgb(34, 162, 205);
                                Btn_DelayDtop.Enabled = true;
                            }
                        }
                        //刷新列表
                        UpdUsrList();
                        /// <summary>
                        /// 是否第一次启动
                        /// </summary>
                        IsFirstBegin = true;
                        /// <summary>
                        /// 总获得金币
                        /// </summary>
                        JbCount = 0;
                        /// <summary>
                        /// 总提升等级
                        /// </summary>
                        DjCount = 0;
                        /// <summary>
                        /// 总进行局数
                        /// </summary>
                        MatchCount = 0;
                        /// <summary>
                        /// 总胜利局数
                        /// </summary>
                        WinCount = 0;
                        /// <summary>
                        /// 总失败局数
                        /// </summary>
                        LoseCount = 0;
                        /// <summary>
                        /// 启动时等级
                        /// </summary>
                        BeginDj = 0;
                        /// <summary>
                        /// 启动时金币
                        /// </summary>
                        BeginJb = 0;
                        /// <summary>
                        /// 任务完成的数量
                        /// </summary>
                        OverUserCount = 0;
                        /// <summary>
                        /// 登录的次数
                        /// </summary>
                        LoginNum = 0;
                        //
                        StateLabel.Text = "当前状态：运行中";
                        //
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height - 25);
                        //
                        skinTabControl1.SelectedTab = tabPage5;
                        //
                        BeginTime = DateTime.Now;
                        Lab_BeginTime.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + "点" + DateTime.Now.Minute + "分";
                        //
                        if (SetValueFormConfig())//获得窗体变量
                        {
                            //
                            Form_To_ConFig();//保存设置
                            //
                            UpdUsrList();
                            //
                            Canstill = true;
                            //
                            if (OpenTzCarry)
                            {
                                Lab_ScMod.Text = "全场Carry模式";
                            }
                            else
                            {
                                Lab_ScMod.Text = "正常操作模式";
                            }
                            //
                            if (SoftMod == 0)
                            {
                                Lab_softMod.Text = "前台( 请勿操作键鼠 )";
                            }
                            else
                            {
                                Lab_softMod.Text = "后台( 可以操作键鼠 )";
                            }
                        }
                    }));
                    if (Canstill)
                    {
                        if (IsTs)
                        {
                            if (!IsTSwindowAlive)
                            {
                                tswindow = new Form2(this);
                                tswindow.Show();
                            }
                        }
                        //启动脚本主执行线程
                        HoleDeal_Thread = new Thread(Scripets_Working);
                        HoleDeal_Thread.SetApartmentState(ApartmentState.MTA);
                        HoleDeal_Thread.Start();
                        //设置状态
                        SetState("软件刚刚启动");
                        //
                    }
                }
                //
                if (!HeartBeat.IsAlive)
                {
                    HeartBeat = new Thread(Thd_Rebind_Server);
                    HeartBeat.SetApartmentState(ApartmentState.MTA);
                    HeartBeat.Start();
                }
            }
        }
        /// <summary>
        /// 软件停止方法
        /// </summary>
        private void Scripets_Stop()
        {
            try
            {

                this.Invoke(new Action(() =>
                {
                    StateLabel.Text = "当前状态：停止中";
                    Btn_DelayDtop.Enabled = true;
                    DelayStop = false;
                    if (!DelayStop)
                    {
                        if (Btn_DelayDtop.BackColor == Color.FromArgb(128, 128, 255))
                        {
                            Btn_DelayDtop.Text = "延迟停止软件( F10 )";
                            Btn_DelayDtop.BackColor = Color.FromArgb(34, 162, 205);
                            Btn_DelayDtop.Enabled = true;
                        }
                    }
                }));
                //设置状态
                SetState("辅助人为停止");
                //
                HoleDeal_Thread.Abort();
                try
                {
                    WorkDmDm.UnBindWindow();
                    Login_Dm.UnBindWindow();
                    Lobby_Dm.UnBindWindow();
                    Game_Dm.UnBindWindow();
                }
                catch (System.Exception ex)
                {

                }
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 软件启动方法_线程
        /// </summary>
        private void Thread_Scripets_Begin()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(10);
                    if (ListemBeginDm.WaitKey(119, 0) == 1)
                    {
                        Scripets_Begin();
                        Thread.Sleep(1000);
                    }
                }
                catch (System.Exception ex)
                {

                }
            }
        }
        /// <summary>
        /// 软件停止方法_线程
        /// </summary>
        private void Thread_Scripets_Stop()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(10);
                    if (ListemStopDm.WaitKey(123, 0) == 1)
                    {
                        Scripets_Stop();
                        Thread.Sleep(1000);
                    }
                }
                catch (System.Exception ex)
                {

                }
            }
        }
        /// <summary>
        /// 软件延迟停止
        /// </summary>
        private void Thread_Scripets_Delay_Stop()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(10);
                    if (ListemDelayStopDm.WaitKey(121, 0) == 1)
                    {
                        //委托的最简便的写法
                        this.Invoke(new Action(() =>
                        {
                            DelayStop = true;
                            Btn_DelayDtop.Enabled = false;
                            Btn_DelayDtop.Text = "已经被设定延迟停止";
                            Btn_DelayDtop.BackColor = Color.FromArgb(128, 128, 255);
                            Thread.Sleep(1000);
                        }));
                    }
                }
                catch (System.Exception ex)
                {

                }
            }
        }
        #endregion

        #region 窗体界面层
        /// <summary>
        /// 调试窗体是否存在
        /// </summary>
        public bool IsTSwindowAlive = false;
        /// <summary>
        /// 一个用于调试的窗体
        /// </summary>
        private Form2 tswindow;
        /// <summary>
        /// 是否处于调试阶段
        /// </summary>
        private bool IsTs = false;
        /// <summary>
        /// 输出调试信息
        /// </summary>
        /// <param name="msg"></param>
        private void OutputTs(string msg)
        {
            if (IsTSwindowAlive)
            {
                tswindow.SetTsMessage(msg);
            }
        }
        /// <summary>
        /// 启动线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //
            IsTs = false;
            //
            Scripets_Begin();
        }
        /// <summary>
        /// 停止线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Scripets_Stop();
        }
        /// <summary>
        /// 程序结束自动清理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WorkDmDm.UnBindWindow();
            Login_Dm.UnBindWindow();
            Lobby_Dm.UnBindWindow();
            Game_Dm.UnBindWindow();
            Environment.Exit(0);
        }
        /// <summary>
        /// 得到游戏路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_GetPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(ofd.FileName).ToUpper() != ".EXE")
                {
                    MessageBox.Show("游戏路径设置有误,请重新设置", "错误提示");
                    Tex_GamePath.Text = "";
                }
                else
                {
                    Tex_GamePath.Text = ofd.FileName;
                }
            }
        }
        private void UpdUsrList()
        {
            //整合大号文本路径
            string Bg_Path = "\\Config\\OneRoad_User" + ".txt";
            //读取这个文本
            TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + Bg_Path, "read");
            ArrayList LoginList = OverCheck.File_ReadFile(-1);
            List_UserMsg.Items.Clear();
            foreach (string inset in LoginList)
            {
                List_UserMsg.Items.Add(inset);
            }
        }

        private void Btn_UpdusrLIST_Click(object sender, EventArgs e)
        {
            UpdUsrList();
        }

        private void Btn_OpenUSEtext_Click(object sender, EventArgs e)
        {
            //整合大号文本路径
            string Bg_Path = "\\Config\\OneRoad_User" + ".txt";
            //读取这个文本
            TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + Bg_Path, "read");
            ArrayList LoginList = OverCheck.File_ReadFile(-1);
            //运行文本
            Runapp(Application.StartupPath + Bg_Path);
        }

        private void Btn_SafeConfig_Click(object sender, EventArgs e)
        {
            if (SetValueFormConfig())
            {
                Form_To_ConFig();
                Btn_UpdusrLIST_Click(sender, e);
                MessageBox.Show("保存配置成功", "保存成功");
            }
        }

        private void Btn_Dm2_Click(object sender, EventArgs e)
        {
            Runapp("http://www.dama2.com/index");
        }

        private void Btn_Dm2showerror_Click(object sender, EventArgs e)
        {
            Runapp("http://wiki.dama2.com/index.php?n=ApiDoc.ErrDef");
        }

        private void Btn_DM2Cxtf_Click(object sender, EventArgs e)
        {
            //先初始化，再登陆
            try
            {
                int ret = Dama2.Init("VerfyCode_ChineZx", "a28470ef7585040776d0713a1d4d9e88");
                if (ret == 0)
                {
                    ret = Dama2.Login2(Tex_DM2username.Text, Tex_DM2psd.Text);
                    if (ret < 0)
                    {
                        Lab_UserSytf.Text = "查询失败,错误码 ：" + ret.ToString();
                        return;
                    }
                    uint ulBalance = 0;
                    ret = Dama2.QueryBalance(ref ulBalance);
                    if (ret < 0)
                    {
                        Lab_UserSytf.Text = "查询失败,错误码 ：" + ret.ToString();
                        return;
                    }
                    Lab_UserSytf.Text = "当前剩余题分 ：" + ulBalance.ToString();
                    return;
                }
                if (ret < 0)
                {
                    Lab_UserSytf.Text = "查询失败,错误码 ：" + ret.ToString();
                    return;
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void Btn_Uu_Click(object sender, EventArgs e)
        {
            Runapp("http://www.uuwise.com/");
        }

        private void Btn_GetUuError_Click(object sender, EventArgs e)
        {
            Runapp("http://www.uuwise.com/allErrorCode.html");
        }

        private void Btn_GetUuTF_Click(object sender, EventArgs e)
        {
            Wrapper.uu_setSoftInfo(SoftID, SoftKey);
            //
            /*	优优云DLL 文件MD5值校验
             *  用处：近期有不法份子采用替换优优云官方dll文件的方式，极大的破坏了开发者的利益
             *  用户使用替换过的DLL打码，导致开发者分成变成别人的，利益受损，
             *  所以建议所有开发者在软件里面增加校验官方MD5值的函数
             *  如何获取文件的MD5值，通过下面的GetFileMD5(文件)函数即返回文件MD5
             */
            string DLLPath = System.Environment.CurrentDirectory + "\\UUWiseHelper.dll";
            string Md5 = GetFileMD5(DLLPath);
            if (!CheckSid())
                return;
            string u = Tex_UuUSER.Text.Trim();
            string p = Tex_UupSD.Text.Trim();
            int res = Wrapper.uu_login(u, p);
            //
            int score = Wrapper.uu_getScore(Tex_UuUSER.Text, Tex_UupSD.Text);
            Lab_UUtf.Text = "当前剩余题分 ：" + score;
        }

        private void Che_Dm2_CheckedChanged(object sender, EventArgs e)
        {
            if (Che_Dm2.Checked)
            {
                Che_uu.Checked = false;
                Che_Dm.Checked = false;
            }
        }

        private void Che_uu_CheckedChanged(object sender, EventArgs e)
        {
            if (Che_uu.Checked)
            {
                Che_Dm2.Checked = false;
                Che_Dm.Checked = false;
            }
        }

        private void Che_Dm_CheckedChanged(object sender, EventArgs e)
        {
            if (Che_Dm.Checked)
            {
                Che_uu.Checked = false;
                Che_Dm2.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan Tcb = System.DateTime.Now - BeginTime;
                Lab_CountTime.Text = Tcb.TotalHours.ToString("0.00") + " 小时";
                Tcb = System.DateTime.Now - ChangeUserTime;
                Lab_NowIntime.Text = Tcb.TotalMinutes.ToString("0.00") + " 分钟";

                switch (GameMod)
                {
                    case 0:
                        label65.Text = "召唤师峡谷（匹配）";
                        break;
                    case 1:
                        label65.Text = "统治战场（人机）";
                        break;
                    case 2:
                        label65.Text = "统治战场（匹配）";
                        break;
                    case 3:
                        label65.Text = "扭曲丛林（匹配）";
                        break;
                    case 4:
                        label65.Text = "嚎哭深渊（匹配）";
                        break;
                }
            }
            catch (System.Exception ex)
            {

            }

        }

        private void Btn_CheckXf_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 登陆按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (Tex_UserName_Lg.Text == "")
            {
                MessageBox.Show("登录信息设置有误,请重新设置后登录", "登录失败");
                return;
            }
            //
            LockMechineConfigPath = "C:\\LockMechineConfig.txt";
            string MechineConfigPath = "C:\\MechineConfig_Lol.txt";
            //
            //登陆成功，锁定机器码
            if (!File.Exists(LockMechineConfigPath))
            {
                //
                MechineCode = Hown_dm.GetMachineCodeNoMac();
                LockMechineCode = "";
            }
            else if (Hown_dm.ReadFile(LockMechineConfigPath) == "")
            {
                //
                MechineCode = Hown_dm.GetMachineCodeNoMac();
                LockMechineCode = "";
            }
            else
            {
                //直接采用锁定机器码
                MechineCode = Hown_dm.ReadFile(LockMechineConfigPath);
                LockMechineCode = MechineCode;
            }
            //
            if (MechineCode == "")
            {
                MessageBox.Show("登陆失败！请关闭UAC权限！", "提示");
                return;
            }
            //
            Fz_UserName = Tex_UserName_Lg.Text.Trim();
            Fz_UserPsd = Tex_Psd_Lg.Text.Trim();
            //
            Fz_Cph = "ppdt201405230000";
            //是否确定登陆
            DialogResult r3 = MessageBox.Show("当前即将进行登陆,请确定是否登陆！", "登陆提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r3 == DialogResult.OK)
            {
                //
                AccountHandle AHD = new AccountHandle();
                Dictionary<string, object> Dic = AHD.activationLogin(Fz_UserName, Fz_Cph, MechineCode);
                //
                if (Dic != null)
                {
                    bool GetRightDate = false;
                    string result = (string)Dic["msgResult"];
                    if (result == "0")
                    {
                        if (!GetRightDate)
                        {
                            //
                            string msD = (string)Dic["msgDesc"];
                            //
                            MessageBox.Show(msD, "登陆提示");
                        }
                        //
                    }
                    else
                    {
                        //
                        loginpUD = Fz_Cph;
                        //
                        IsVerify = true;
                        FzMod = "0";
                        //
                        Btn_Login.Enabled = false;
                        Btn_Login.BackColor = Color.Silver;
                        Btn_GzsLogin.Enabled = false;
                        Btn_GzsLogin.BackColor = Color.Silver;
                        Btn_XfMx.Enabled = false;
                        Btn_XfMx.BackColor = Color.Silver;
                        MaxVerifyCount = 2;
                        //
                        MessageBox.Show("恭喜您，登陆成功！欢迎使用本软件 - 中国战线\r\n\r\n卡密到期时间：" + (string)Dic["deadLine"], "登陆成功");
                        Tex_Psd_Lg.Clear();
                        Tex_Psd_Lg.Text = (string)Dic["deadLine"];
                        //
                        NowMecod = EncodeStr(MechineCode);
                        //
                        Form_To_ConFig();
                        //
                        string Ls_Show_3 = "登陆时间：" + System.DateTime.Now + " . 本机原始机器码：" + EncodeStr(Hown_dm.GetMachineCodeNoMac()) + " . 机器附加码：无 . 最终机器码：" + NowMecod;
                        //
                        Ls_Show_3 = Ls_Show_3 + " . 未启用附加码";
                        //
                        if (MechineCode == LockMechineCode)
                        {
                            Ls_Show_3 = Ls_Show_3 + " . 此为锁定机器码";
                        }
                        else
                        {
                            Ls_Show_3 = Ls_Show_3 + " . 非锁定机器码";
                        }
                        //记录历史机器码
                        TwoColor_File_Deling OverCheck_2 = new TwoColor_File_Deling(MechineConfigPath, "write");
                        OverCheck_2.File_WriteFile(Ls_Show_3 + "\r\n", "end");
                        //登陆成功，锁定机器码
                        if (!File.Exists(LockMechineConfigPath))
                        {
                            Hown_dm.WriteFile(LockMechineConfigPath, MechineCode);
                        }
                        else if (Hown_dm.ReadFile(LockMechineConfigPath) == "")
                        {
                            Hown_dm.WriteFile(LockMechineConfigPath, MechineCode);
                        }
                        //返回公告
                        //公告标题
                        string Title = (string)Dic["noticeTitle"];
                        //公告内容
                        string Body = (string)Dic["noticeContent"];
                        //标志位
                        string MsgRpt = (string)Dic["showFlag"];
                        //
                        if (MsgRpt == "1")
                        {
                            //
                            MessageBox.Show(Body, Title);
                        }
                        Tex_Gogao.Text = Body;
                        //
                        bool GetGx = false;
                        Dictionary<string, object> upd = AHD.getLastVersionProductInfo(Fz_Cph, Fz_UpdNumber);
                        //检查更新
                        if (upd != null)
                        {
                            string Upd_result = (string)upd["msgResult"];
                            switch (Upd_result)
                            {
                                case "0":
                                    break;
                                case "1":
                                    string Upd_title = (string)upd["title"];

                                    UpdUrl = (string)upd["url"];

                                    UpdMsg = (string)upd["content"];
                                    //有更新
                                    Lab_Upd.ForeColor = Color.Lime;
                                    Lab_Upd.Text = "发现更新,请点我更新";
                                    GetGx = true;
                                    break;
                                case "2":
                                    break;
                            }
                        }
                        if (GetGx)
                        {
                            if (UpdUrl != "")
                            {
                                string ShowUpdMsg = "";
                                //
                                foreach (string updmsg in UpdMsg.Split('|'))
                                {
                                    ShowUpdMsg = ShowUpdMsg + updmsg + "\r\n";
                                }
                                ShowUpdMsg = ShowUpdMsg + "\r\n" + "请确定是否进行更新？";
                                //是否确定登陆
                                DialogResult r4 = MessageBox.Show(ShowUpdMsg, "更新内容", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                if (r4 == DialogResult.OK)
                                {
                                    //
                                    Runapp(UpdUrl);
                                    //
                                    Environment.Exit(0);
                                }
                            }
                        }
                        if (!HeartBeat.IsAlive)
                        {
                            HeartBeat = new Thread(Thd_Rebind_Server);
                            HeartBeat.SetApartmentState(ApartmentState.MTA);
                            HeartBeat.Start();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("辅助登陆出现未知异常,请联系管理员", "提示");
                }
            }
        }
        /// <summary>
        /// 更新链接
        /// </summary>
        private string UpdUrl = "";
        /// <summary>
        /// 更新内容
        /// </summary>
        private string UpdMsg = "";
        /// <summary>
        /// 更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lab_Upd_Click(object sender, EventArgs e)
        {
            if (UpdUrl != "")
            {
                string ShowUpdMsg = "";
                //
                foreach (string updmsg in UpdMsg.Split('|'))
                {
                    ShowUpdMsg = ShowUpdMsg + updmsg + "\r\n";
                }
                ShowUpdMsg = ShowUpdMsg + "\r\n" + "请确定是否进行更新？";
                //是否确定登陆
                DialogResult r3 = MessageBox.Show(ShowUpdMsg, "更新内容", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (r3 == DialogResult.OK)
                {
                    //
                    Runapp(UpdUrl);
                    //
                    Environment.Exit(0);
                }
            }
        }

        private void Btn_RegetMechineCode_Click(object sender, EventArgs e)
        {

        }

        private void Btn_QQtestSend_Click(object sender, EventArgs e)
        {
            if (Tex_QQsendername.Text != "")
            {
                CDmSoft Sender_dm = new CDmSoft();
                int SendHwnd = Sender_dm.FindWindow("TXGuiFoundation", Tex_QQsendername.Text);
                if (SendHwnd == 0)
                {
                    Sender_dm.UnBindWindow();
                    Sender_dm.Dispose();
                    MessageBox.Show("发送对象窗口不存在,请检查", "发送失败");
                    return;
                }
                try
                {
                    int dm_ret = Sender_dm.BindWindow(SendHwnd, "normal", "windows", "windows", 0);
                    Delay(100);
                    Zs_Move_Clk(Sender_dm, 198, 441, 30, 3);
                    Delay(100);
                    Sender_dm.SendString(SendHwnd, "一路向撸：发来测试消息！请查收！");
                    Delay(300);
                    Zs_KeyP(Sender_dm, 13, 1);
                    Delay(100);
                    dm_ret = Sender_dm.UnBindWindow();
                    Sender_dm.Dispose();
                    return;
                }
                catch (System.Exception ex)
                {

                }
                return;
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 根据进程名和进程PID，关闭指定进程 - 进程名不需要带后缀
        /// </summary>
        /// <param name="ProssName">进程名</param>
        /// <param name="ClosePid">需要关闭的进程PID</param>
        private void CloseProcessByProcessId(string ProssName, int ClosePid)
        {
            Process[] pp = Process.GetProcessesByName(ProssName);
            for (int i = 0; i < pp.Length; i++)
            {
                if (pp[i].Id == ClosePid)
                {
                    pp[i].Kill();
                }
            }
        }

        private void Btn_RecoverClick_Click(object sender, EventArgs e)
        {
            DialogResult r1 = MessageBox.Show("请确定是否进行异常恢复处理！！！", "严重警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r1 == DialogResult.OK)
            {
                //先杀死这些进程
                KillProcessByName("Client");
                KillProcessByName("LolClient");
                KillProcessByName("lol.launcher_tencent");
                KillProcessByName("League of Legends");
                MessageBox.Show("操作成功,请启动软件！", "操作完成");
            }
        }

        /// <summary>
        /// 延迟停止
        /// </summary>
        private bool DelayStop = false;
        private void Btn_DelayDtop_Click(object sender, EventArgs e)
        {
            DelayStop = true;
            Btn_DelayDtop.Enabled = false;
            Btn_DelayDtop.Text = "已经被设定延迟停止";
            Btn_DelayDtop.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void Btn_GzsLogin_Click(object sender, EventArgs e)
        {
            if (Tex_GzxUserName.Text == "" || Tex_GzxPsd.Text == "" || Tex_GzxLockMima.Text == "")
            {
                MessageBox.Show("登录信息设置有误,请重新设置后登录", "登录失败");
                return;
            }
            //
            LockMechineConfigPath = "C:\\LockMechineConfig_Gzs.txt";
            //
            //登陆成功，锁定机器码
            if (!File.Exists(LockMechineConfigPath))
            {
                //
                MechineCode = MD5Esc(Hown_dm.GetMachineCodeNoMac() + Tex_GzxLockMima.Text.Trim());
                LockMechineCode = "";
            }
            else if (Hown_dm.ReadFile(LockMechineConfigPath) == "")
            {
                //
                MechineCode = MD5Esc(Hown_dm.GetMachineCodeNoMac() + Tex_GzxLockMima.Text.Trim());
                LockMechineCode = "";
            }
            else
            {
                //直接采用锁定机器码
                MechineCode = Hown_dm.ReadFile(LockMechineConfigPath);
                LockMechineCode = MechineCode;
            }
            //
            if (MechineCode == "")
            {
                MessageBox.Show("登陆失败！请关闭UAC权限！", "提示");
                return;
            }
            //
            Fz_UserName = Tex_GzxUserName.Text.Trim();
            Fz_UserPsd = Tex_GzxPsd.Text.Trim();
            //
            //
            if (NowMecod2 != "")
            {
                if (!CheckMechineCode_Gzs(NowMecod2))
                {
                    //机器码不一致
                    DialogResult r1 = MessageBox.Show("严重警告：当前机器码与前一次登陆的机器码不一致,可能造成一次扣费！", "严重警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (r1 == DialogResult.OK)
                    {

                    }
                    else
                    {
                        Environment.Exit(0);
                        return;
                    }
                }
            }
            Fz_Cph = "pdt201405220014";
            //是否确定登陆
            DialogResult r3 = MessageBox.Show("当前即将进行登陆,请确定是否登陆！", "登陆提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r3 == DialogResult.OK)
            {
                //
                AccountHandle AHD = new AccountHandle();
                Dictionary<string, object> Dic = AHD.accountLogin(Fz_UserName, Fz_Cph, MechineCode, Fz_UserPsd);
                //
                if (Dic != null)
                {
                    bool GetRightDate = false;
                    string result = (string)Dic["msgResult"];
                    if (result == "0")
                    {
                        if (!GetRightDate)
                        {
                            //
                            string msD = (string)Dic["msgDesc"];
                            //
                            MessageBox.Show(msD, "登陆提示");
                        }
                        //
                    }
                    else
                    {
                        //
                        loginpUD = Fz_Cph;
                        //
                        string Diccon = (string)Dic["comsumeStatus"];
                        //
                        AccountService.His[] his = (His[])Dic["comsumeHisList"];
                        //
                        IsVerify = true;
                        //
                        Btn_Login.Enabled = false;
                        Btn_Login.BackColor = Color.Silver;
                        Btn_GzsLogin.Enabled = false;
                        Btn_GzsLogin.BackColor = Color.Silver;
                        MaxVerifyCount = 5;
                        FzMod = "1";
                        //
                        ArrayList showproductComsumes = new ArrayList();
                        AccountHandle ah = new AccountHandle();
                        Dictionary<string, object> Qpc = ah.queryPerProductComsumeInfoByAccountNo(Fz_UserName);
                        if (Qpc != null)
                        {
                            result = (string)Qpc["msgResult"];
                            if (result == "1")
                            {
                                string Qpc_Desc = (string)Qpc["msgDesc"];
                                DayProductComsume[] productComsumes = (DayProductComsume[])Qpc["productComsumes"];
                                foreach (DayProductComsume tem in productComsumes)
                                {
                                    string productName = tem.productName;//(产品名称)
                                    string count = tem.dayMachineCount;//(当天该产品的消费机器总数)
                                    string totalMoney = tem.dayComsumeMoney;//(当天该产品消费总额)
                                    showproductComsumes.Add(" 本账号今日在 " + tem.productName + " 共登陆 " + tem.dayMachineCount + " 次 , 总计 " + tem.dayComsumeMoney);
                                }
                            }
                        }
                        showproductComsumes.Add("  ");
                        showproductComsumes.Add(" 如果扣费情况和实际不符，请及时联系管理员 ");
                        //余额
                        string Balance = (string)Dic["balance"];
                        if (Diccon == "今天首次扣费")
                        {
                            string showmsg = " 今天首次扣费 - 欢迎使用本软件\r\n\r\n";
                            foreach (string str in showproductComsumes)
                            {
                                showmsg = showmsg + str + "\r\n";
                            }
                            showmsg = showmsg + "\r\n 账户当前余额：" + Balance + "\r\n";
                            MessageBox.Show(showmsg, "恭喜 - 登录成功");
                        }
                        else
                        {
                            string showmsg = " 本次没有扣费 - 欢迎使用本软件\r\n\r\n";
                            foreach (string str in showproductComsumes)
                            {
                                showmsg = showmsg + str + "\r\n";
                            }
                            showmsg = showmsg + "\r\n 账户当前余额：" + Balance + "\r\n";
                            MessageBox.Show(showmsg, "恭喜 - 登录成功");
                        }
                        //
                        NowMecod2 = EncodeStr(MechineCode);
                        //
                        Form_To_ConFig();
                        //
                        string ConfigPath = "\\Config\\LoginConfig.txt";
                        //
                        try
                        {
                            //先尝试删除文本
                            File.Delete(Application.StartupPath + ConfigPath);
                        }
                        catch (System.Exception ex)
                        {

                        }
                        foreach (His tem in his)
                        {
                            //消费金额
                            string cMon = tem.comsumeMoney;
                            //消费时间
                            string cTime = tem.comsumeTime;
                            //
                            string cCp = tem.productCode;
                            //
                            string Ls_Show = "[ 时间 ] " + cTime + " [ 产品 ] " + cCp + " [ 扣除 ] " + cMon + " ";
                            //
                            //再尝试写入文本
                            try
                            {
                                TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + ConfigPath, "write");
                                OverCheck.File_WriteFile(Ls_Show + "\r\n", "end");
                            }
                            catch (System.Exception ex)
                            {

                            }
                            //
                        }
                        //
                        string Ls_Show_2 = "[ 温馨提示：以上记录为您的账户 3 天内在各机器首次登陆的消费情况,超出 3 天的记录不予显示 ]";
                        //
                        //再尝试写入文本
                        try
                        {
                            TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + ConfigPath, "write");
                            OverCheck.File_WriteFile(Ls_Show_2 + "\r\n", "end");
                        }
                        catch (System.Exception ex)
                        {

                        }
                        //登陆成功，锁定机器码
                        if (!File.Exists(LockMechineConfigPath))
                        {
                            Hown_dm.WriteFile(LockMechineConfigPath, MechineCode);
                        }
                        else if (Hown_dm.ReadFile(LockMechineConfigPath) == "")
                        {
                            Hown_dm.WriteFile(LockMechineConfigPath, MechineCode);
                        }
                        //返回公告
                        //公告标题
                        string Title = (string)Dic["noticeTitle"];
                        //公告内容
                        string Body = (string)Dic["noticeContent"];
                        //标志位
                        string MsgRpt = (string)Dic["showFlag"];
                        //
                        if (MsgRpt == "1")
                        {
                            //
                            MessageBox.Show(Body, Title);
                        }
                        Tex_Gogao.Text = Body;
                        //
                        bool GetGx = false;
                        Dictionary<string, object> upd = AHD.getLastVersionProductInfo(Fz_Cph, Fz_UpdNumber);
                        //检查更新
                        if (upd != null)
                        {
                            string Upd_result = (string)upd["msgResult"];
                            switch (Upd_result)
                            {
                                case "0":
                                    break;
                                case "1":
                                    string Upd_title = (string)upd["title"];

                                    UpdUrl = (string)upd["url"];

                                    UpdMsg = (string)upd["content"];
                                    //有更新
                                    Lab_Upd.ForeColor = Color.Lime;
                                    Lab_Upd.Text = "发现更新,请点我更新";
                                    GetGx = true;
                                    break;
                                case "2":
                                    break;
                            }
                        }
                        if (GetGx)
                        {
                            if (UpdUrl != "")
                            {
                                string ShowUpdMsg = "";
                                //
                                foreach (string updmsg in UpdMsg.Split('|'))
                                {
                                    ShowUpdMsg = ShowUpdMsg + updmsg + "\r\n";
                                }
                                ShowUpdMsg = ShowUpdMsg + "\r\n" + "请确定是否进行更新？";
                                //是否确定登陆
                                DialogResult r4 = MessageBox.Show(ShowUpdMsg, "更新内容", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                if (r4 == DialogResult.OK)
                                {
                                    //
                                    Runapp(UpdUrl);
                                    //
                                    Environment.Exit(0);
                                }
                            }
                        }
                        //
                        if (!HeartBeat.IsAlive)
                        {
                            HeartBeat = new Thread(Thd_Rebind_Server);
                            HeartBeat.SetApartmentState(ApartmentState.MTA);
                            HeartBeat.Start();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("辅助登陆出现未知异常,请联系管理员", "提示");
                }
            }
        }

        private void Btn_XfMx_Click(object sender, EventArgs e)
        {
            string ConfigPath = "\\Config\\LoginConfig.txt";
            Runapp(Application.StartupPath + ConfigPath);
        }

        private void Btn_CgLockMiMa_Click(object sender, EventArgs e)
        {
            //机器码不一致
            DialogResult r1 = MessageBox.Show("严重警告：如果您不是在技术员指导下修改此位置！请不要修改！", "严重警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r1 == DialogResult.OK)
            {
                string LockMechineConfigPath = "C:\\LockMechineConfig_Gzs.txt";
                File.Delete(LockMechineConfigPath);
                MessageBox.Show("修改成功,请登录！请勿频繁修改此密码！", "修改成功");
            }
        }

        private void Btn_SetNameConfig_Click(object sender, EventArgs e)
        {
            //整合大号文本路径
            string Bg_Path = "\\Config\\UserNameConfig" + ".txt";
            //读取这个文本
            TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + Bg_Path, "read");
            ArrayList LoginList = OverCheck.File_ReadFile(-1);
            //运行文本
            Runapp(Application.StartupPath + Bg_Path);
        }

        /// <summary>
        /// 随机生成建号名字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SjscJhmz_Click(object sender, EventArgs e)
        {
            ArrayList SjName = new ArrayList();
            for (int i = 0; i < 100; i++)
            {
                SjName.Add(GenerateSurname());
            }
            //整合大号文本路径
            string Bg_Path = "\\Config\\UserNameConfig" + ".txt";
            //
            File.Delete(Application.StartupPath + Bg_Path);
            //
            foreach (string configStr in SjName)
            {
                TwoColor_File_Deling OverCheck = new TwoColor_File_Deling(Application.StartupPath + Bg_Path, "write");
                OverCheck.File_WriteFile(configStr + "\r\n", "end");
            }
            //
            //运行文本
            Runapp(Application.StartupPath + Bg_Path);
        }
        #endregion


    }
}
