using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Security.Cryptography;
using System.Windows.Forms;
namespace _File_Deling
{
    public class TwoColor_File_Deling
    {
        FileStream fs;
        public FileStream Fs
        {
            get { return fs; }
            set { fs = value; }
        }       
        /// <summary>
        /// 打开一个文件流
        /// </summary>
        /// <param name="file_Path">文件路径</param>
        /// <param name="file_cmd">"read为读取方式","write为写入方式"</param>
        public TwoColor_File_Deling(string file_Path,string file_cmd)
        {
            switch (file_cmd)
            {
                case "read":
                    fs = new FileStream(@file_Path, FileMode.OpenOrCreate, FileAccess.Read);
                    break;
                case"write":
                    fs = new FileStream(@file_Path, FileMode.OpenOrCreate, FileAccess.Write);
                    break;
            }            
        }
        /// <summary>
        /// 关闭这个文件流
        /// </summary>
        public void File_Close()
        {
            fs.Close();
        }
        /// <summary>
        /// 读取文件的方法
        /// </summary>
        /// <param name="Read_Line">读取的行数,-1为全部读取</param>
        public ArrayList File_ReadFile(int Read_Line)
        {
            StreamReader m_streamReader = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            string strLine = m_streamReader.ReadLine();
            int ReadEdLine = 0;
            ArrayList FileDetail = new ArrayList();
            while (strLine != null)
            {
                FileDetail.Add(strLine);
                strLine = m_streamReader.ReadLine();
                ReadEdLine++;
                if (ReadEdLine >= Read_Line && Read_Line != -1)
                    break;
            }
            m_streamReader.Close();//读取完以后将其关闭
            //fs.Close();
            return FileDetail;
        }
        /// <summary>
        /// 写入文件方法 - 一行一行写入
        /// </summary>
        /// <param name="strLine">写入的内容</param>
        /// <param name="Line_Num">"begin"为从头开始,"end"为从最后一行开始</param>
        /// <returns>成功返回true ，失败返回false</returns>
        public bool File_WriteFile(string strLine,string Line_Num)
        {
            StreamWriter m_streamWriter = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));           
            switch (Line_Num)
            {
                case "begin":
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    break;
                case "end":
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    break;
            }
            m_streamWriter.Write(strLine);
            m_streamWriter.Flush();
            m_streamWriter.Close();//读取完以后将其关闭
            fs.Close();
            return true;
        }
        /// <summary>
        /// 得到当前程序的路径
        /// </summary>
        /// <returns>路径</returns>
        public string Get_OwnPath()
        {
            return Application.StartupPath;
        }
        string iv = "password";
        string key = "password";

        /// <summary>
        /// DES加密偏移量，必须是>=8位长的字符串
        /// </summary>
        public string IV
        {
            get { return iv; }
            set { iv = value; }
        }

        /// <summary>
        /// DES加密的私钥，必须是8位长的字符串
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 对文件内容进行DES加密
        /// </summary>
        /// <param name="sourceFile">待加密的文件绝对路径</param>
        /// <param name="destFile">加密后的文件保存的绝对路径</param>
        public void EncryptFile(string sourceFile, string destFile)
        {
       
            if (!File.Exists(sourceFile)) throw new FileNotFoundException("指定的文件路径不存在！", sourceFile);

            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] btFile = File.ReadAllBytes(sourceFile);
          
         
            using (FileStream fs = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (CryptoStream cs = new CryptoStream(fs, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(btFile, 0, btFile.Length);
                        cs.FlushFinalBlock();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 对文件内容进行DES加密，加密后覆盖掉原来的文件
        /// </summary>
        /// <param name="sourceFile">待加密的文件的绝对路径</param>
        public void EncryptFile(string sourceFile)
        {
            EncryptFile(sourceFile, sourceFile);
        }

        /// <summary>
        /// 对文件内容进行DES解密
        /// </summary>
        /// <param name="sourceFile">待解密的文件绝对路径</param>
        /// <param name="destFile">解密后的文件保存的绝对路径</param>
        public void DecryptFile(string sourceFile, string destFile)
        {

            if (!File.Exists(sourceFile))
                throw new FileNotFoundException("指定的文件路径不存在！", sourceFile);

            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] btFile = File.ReadAllBytes(sourceFile);
          
           
            using (FileStream fs = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (CryptoStream cs = new CryptoStream(fs, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(btFile, 0, btFile.Length);
                        cs.FlushFinalBlock();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }
        /// <summary>
        /// 对文件内容进行DES解密，解密后覆盖掉原来的文件
        /// </summary>
        /// <param name="sourceFile">待解密的文件的绝对路径</param>
        public void DecryptFile(string sourceFile)
        {
            DecryptFile(sourceFile, sourceFile);
        }

    }
}
