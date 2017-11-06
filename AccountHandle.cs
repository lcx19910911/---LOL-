using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountService;

namespace ACCOUNT
{
    public class AccountHandle
    {
        private ACCOUNTService accountCLient = new ACCOUNTService();
        /// <summary>
        /// 账户登录1
        /// </summary>
        /// <param name="accountNo">账号</param>
        /// <param name="productCode">产品编号</param>
        /// <param name="machineCode">机器唯一码</param>
        /// <param name="password">密码</param>
        /// <returns>
        ///     Dictionary里以键值对存放的 
        ///     msgResult=1 登录成功 则msgDesc=登录成功信息，comsumeHisList为前三天消费记录,comsumeStatus消费状态，balance账户余额,usableScore可用积分，disableScore待返积分，rankName账户等级
        ///     msgResult=0 登录失败 则msgDesc=登录失败信息，无comsumeHisList，comsumeStatus，balance信息
        /// </returns>
        public Dictionary<string, object> accountLogin(string accountNo, string productCode, string machineCode, string password)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if(accountNo==null || productCode==null || machineCode==null || password==null){
                result.Add("msgResult", "0");
                result.Add("msgDesc","登录失败，登录信息为空！");
                return result;
            }
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.accountNo = accountNo;
            loginInfo.machineCode = machineCode;
            loginInfo.password = password;
            loginInfo.productCode = productCode;
            accountLoginRequest loginRequestXml = new accountLoginRequest();
            //ACCOUNTClient accountCLient = new ACCOUNTClient("ACCOUNTSoap11", "http://51cfjs.com:8080/jdd-billing/services/");
            loginRequestXml.loginRequestInfo = loginInfo;
            accountLoginResponse loginResponse = null;
            try
            {
                loginResponse = accountCLient.accountLogin(loginRequestXml);
            }catch(Exception e){
                result.Add("msgResult", "0");
                result.Add("msgDesc", "登录失败！失败时间：" + DateTime.Now.ToString() + "，参数信息" + loginRequestXml.ToString() + "，异常信息" + e.Message);
                return result;
            }
            if (loginResponse != null && loginResponse.loginResponseInfo != null && loginResponse.loginResponseInfo.result == "1")
            {
                His[] comsumeHis = loginResponse.loginResponseInfo.comHisList;
                string comsumeStatus=loginResponse.loginResponseInfo.comsumeStatus;
                string balance = loginResponse.loginResponseInfo.balance;
                string usableScore = loginResponse.loginResponseInfo.usableScore;
                string disableScore = loginResponse.loginResponseInfo.disableScore;
                string rankName = loginResponse.loginResponseInfo.rankName;
                string noticeTitle = loginResponse.loginResponseInfo.noticeTitle;
                string noticeContent = loginResponse.loginResponseInfo.noticeContent;
                string showFlag = loginResponse.loginResponseInfo.showFlag;
                string isUpdate = loginResponse.loginResponseInfo.isUpdate;
                if (comsumeHis != null && comsumeHis.Length > 0){
                    result.Add("comsumeHisList", comsumeHis);
                }
                else {
                    result.Add("comsumeHisList", new His[] { });
                }
                result.Add("msgResult", "1");
                result.Add("msgDesc", loginResponse.loginResponseInfo.resultMsg);
                result.Add("balance", balance);
                result.Add("usableScore", usableScore);
                result.Add("disableScore", disableScore);
                result.Add("rankName", rankName);
                result.Add("noticeTitle", noticeTitle);
                result.Add("noticeContent", noticeContent);
                result.Add("showFlag", showFlag);
                result.Add("isUpdate", isUpdate);
                result.Add("comsumeStatus", comsumeStatus);
                return result; 
            }
            else if (loginResponse != null && loginResponse.loginResponseInfo != null && loginResponse.loginResponseInfo.result == "0")
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", loginResponse.loginResponseInfo.resultMsg);
                return result;
            }
            else {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "登录失败！");
                return result;
            }
        }
        /// <summary>
        /// 心跳检测
        /// </summary>
        /// <param name="accountNo">账号</param>
        /// <param name="productCode">产品编号</param>
        /// <param name="machineCode">机器唯一码</param>
        /// <returns>
        ///     Dictionary里以键值对存放的 
        ///     msgResult=1表示检测成功 则msgDesc=成功信息
        ///     msgResult=0检测失败 则msgDesc=失败信息
        /// </returns>
        public Dictionary<string, object> heartBeat(string accountNo, string productCode, string machineCode)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (accountNo == null || productCode == null || machineCode == null) {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测失败！检测信息为空！");
                return result;
            }
            //ACCOUNTClient accountCLient = new ACCOUNTClient("ACCOUNTSoap11", "http://51cfjs.com:8080/jdd-billing/services/");
            AccProMacInfo macInfo = new AccProMacInfo();
            macInfo.accountNo = accountNo;
            macInfo.machineCode = machineCode;
            macInfo.productCode = productCode;
            heartBeatRequest heartBeatRequest = new heartBeatRequest();
            heartBeatRequest.heartBeatRequestInfo = macInfo;
            heartBeatResponse heartBeatResponse = null;
            try
            {
                heartBeatResponse = accountCLient.heartBeat(heartBeatRequest);
            }catch(Exception e){
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测失败！失败时间：" + DateTime.Now.ToString() + "，参数信息" + heartBeatRequest.ToString() + "，异常信息" + e.Message);
                return result;
            }

            if (heartBeatResponse != null && heartBeatResponse.heartBeatResponseInfo != null && heartBeatResponse.heartBeatResponseInfo.result == "1")
            {
                result.Add("msgResult", "1");
                result.Add("msgDesc", heartBeatResponse.heartBeatResponseInfo.resultMsg);
                return result;
            }
            else if (heartBeatResponse != null && heartBeatResponse.heartBeatResponseInfo != null && heartBeatResponse.heartBeatResponseInfo.result == "0")
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", heartBeatResponse.heartBeatResponseInfo.resultMsg);
                return result;
            }
            else {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测失败！");
                return result;
            }
        }
        /// <summary>
        /// 查询该机器该账户扣过费的产品编号
        /// </summary>
        /// <param name="accountNo">账号</param>
        /// <param name="password">密码</param>
        /// <param name="machineCode">机器唯一码</param>
        /// <returns>
        ///     Dictionary里以键值对存放的 
        ///     msgResult=1 查询成功 则msgDesc=查询成功信息，productList产品编码的列表
        ///     msgResult=0 查询失败 则msgDesc=查询失败信息，无productList信息
        /// </returns>
        public Dictionary<string, object> chargedProduct(string accountNo, string password, string machineCode)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (accountNo == null || password == null || machineCode == null)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "查询失败，检测信息为空！");
                return result;
            }
            //ACCOUNTClient accountCLient = new ACCOUNTClient("ACCOUNTSoap11", "http://51cfjs.com:8080/jdd-billing/services/");
            ChargedProductInfo proInfo = new ChargedProductInfo();
            proInfo.accountNo = accountNo;
            proInfo.machineCode = machineCode;
            proInfo.password = password;
            chargedProductRequest productRequest = new chargedProductRequest();
            productRequest.chargedProductRequestInfo = proInfo;
            chargedProductResponse productResponse = null;
            try
            {
                productResponse = accountCLient.chargedProduct(productRequest);
            }
            catch (Exception e)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "查询失败！失败时间：" + DateTime.Now.ToString() + "，参数信息" + productRequest.ToString() + "，异常信息：" + e.Message);
                return result;
            }
            if (productResponse != null && productResponse.chargedProductResponseInfo != null && productResponse.chargedProductResponseInfo.result == "1")
            {
                result.Add("msgResult", "1");
                result.Add("msgDesc", productResponse.chargedProductResponseInfo.resultMsg);
                result.Add("products", productResponse.chargedProductResponseInfo.productList);
                return result;
            }
            else if (productResponse != null && productResponse.chargedProductResponseInfo != null && productResponse.chargedProductResponseInfo.result == "0")
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", productResponse.chargedProductResponseInfo.resultMsg);
                return result;
            }
            else
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "查询失败！");
                return result;
            }
        }
        /// <summary>
        /// 查询最新版本产品的信息
        /// </summary>
        /// <param name="productCode">产品编号</param>
        /// <param name="version">版本</param>
        /// <returns>
        ///     Dictionary里以键值对存放的 
        ///     msgResult=1 检测最新版本产品成功 则msgDesc=检测最新版本产品成功信息，url 、 title、content
        ///     msgResult=0 检测最新版本产品失败 则msgDesc=检测最新版本产品失败信息，无product信息
        ///     msgResult=2 检测已经是最新版本 则msgDesc=已经是最新版本，无product信息
        /// </returns>
        public Dictionary<string, object> getLastVersionProductInfo(string productCode, string version)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (productCode == null || version == null)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测最新版本产品失败，参数信息(productCode,version)为空！");
                return result;
            }
            //ACCOUNTClient accountCLient = new ACCOUNTClient("ACCOUNTSoap11", "http://51cfjs.com:8080/jdd-billing/services/");
            LastVersionInfo lastVersionInfo = new LastVersionInfo();
            lastVersionInfo.productCode = productCode;
            lastVersionInfo.version = version;
            lastVersionRequest lastVersionRequest = new lastVersionRequest();
            lastVersionRequest.lastVersionRequestInfo = lastVersionInfo;
            lastVersionResponse lastVersionResponse = null;
            try
            {
                lastVersionResponse = accountCLient.lastVersion(lastVersionRequest);
            }
            catch (Exception e)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测最新版本产品失败！失败时间：" + DateTime.Now.ToString() + "，参数信息" + lastVersionRequest.ToString() + "，异常信息：" + e.Message);
                return result;
            }
            if (lastVersionResponse != null && lastVersionResponse.lastVersionResponseInfo != null && lastVersionResponse.lastVersionResponseInfo.result == "1")
            {
                result.Add("msgResult", "1");
                result.Add("msgDesc", lastVersionResponse.lastVersionResponseInfo.resultMsg);
                result.Add("url", lastVersionResponse.lastVersionResponseInfo.updateVersionUrl);
                result.Add("title", lastVersionResponse.lastVersionResponseInfo.updateVersionTitle);
                result.Add("content", lastVersionResponse.lastVersionResponseInfo.updateVersionContent);
                return result;
            }
            else if (lastVersionResponse != null && lastVersionResponse.lastVersionResponseInfo != null && lastVersionResponse.lastVersionResponseInfo.result == "0")
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", lastVersionResponse.lastVersionResponseInfo.resultMsg);
                return result;
            }
            else if (lastVersionResponse != null && lastVersionResponse.lastVersionResponseInfo != null && lastVersionResponse.lastVersionResponseInfo.result == "2")
            {
                result.Add("msgResult", "2");
                result.Add("msgDesc", lastVersionResponse.lastVersionResponseInfo.resultMsg);
                return result;
            }
            else
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测最新版本产品失败！");
                return result;
            }
        }
        /// <summary>
        /// 时间：2014-02-14
        /// 根据账号查询该账户各个产品消费的机器数、各个产品的消费总额、产品名称等信息
        /// </summary>
        /// <param name="accountNo">账号</param>
        /// <returns>
        ///     Dictionary里以键值对存放的 
        ///     msgResult=1 检查询各个产品消费情况成功 则msgDesc=查询各个产品消费情况信息，productComsumeList列表信息: productName,dayMachineCount,dayComsumeMoney
        ///     msgResult=0 查询各个产品消费情况失败 则msgDesc=查询各个产品消费情况信息，无productComsumeList信息
        /// </returns>
        public Dictionary<string, object> queryPerProductComsumeInfoByAccountNo(string accountNo)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (accountNo == null)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "查询各个产品消费情况失败，参数信息(accountNo)为空！");
                return result;
            }
            //ACCOUNTClient accountCLient = new ACCOUNTClient("ACCOUNTSoap11", "http://51cfjs.com:8080/jdd-billing/services/");
            DayProductComsumeInfo dayProductComsumeInfo = new DayProductComsumeInfo();
            dayProductComsumeInfo.accountNo = accountNo;
            dayProductComsumeRequest dayProductComsumeRequest = new dayProductComsumeRequest();
            dayProductComsumeRequest.dayProductComsumeRequestInfo = dayProductComsumeInfo;
            dayProductComsumeResponse dayProductComsumeResponse = null;
            try
            {
                dayProductComsumeResponse = accountCLient.dayProductComsume(dayProductComsumeRequest);
            }
            catch (Exception e)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "查询各个产品消费情况失败！失败时间：" + DateTime.Now.ToString() + "，参数信息" + dayProductComsumeRequest.ToString() + "，异常信息：" + e.Message);
                return result;
            }
            if (dayProductComsumeResponse != null && dayProductComsumeResponse.dayProductComsumeResponseInfo != null && dayProductComsumeResponse.dayProductComsumeResponseInfo.result == "1")
            {
                result.Add("msgResult", "1");
                result.Add("msgDesc", dayProductComsumeResponse.dayProductComsumeResponseInfo.resultMsg);
                result.Add("productComsumes", dayProductComsumeResponse.dayProductComsumeResponseInfo.dayProductComsumeList);
                return result;
            }
            else if (dayProductComsumeResponse != null && dayProductComsumeResponse.dayProductComsumeResponseInfo != null && dayProductComsumeResponse.dayProductComsumeResponseInfo.result == "0")
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", dayProductComsumeResponse.dayProductComsumeResponseInfo.resultMsg);
                return result;
            }
            else
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "查询各个产品消费情况失败！");
                return result;
            }
        }

        /// <summary>
        /// 个人产品登录
        /// </summary>
        /// <param name="activationCode">注册码</param>
        /// <param name="productCode">产品编号</param>
        /// <param name="machineCode">机器码</param>
        /// <returns>
        ///     Dictionary里以键值对存放的 
        ///     msgResult=1 登录成功 则msgDesc=登录成功信息
        ///     msgResult=0 登录失败 则msgDesc=登录失败信息
        /// </returns>
        public Dictionary<string, object> activationLogin(string activationCode, string productCode, string machineCode)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (activationCode == null || productCode == null || machineCode == null)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "登录失败，登录信息为空！");
                return result;
            }
            AcvLoginInfo loginInfo = new AcvLoginInfo();
            loginInfo.activationCode = activationCode;
            loginInfo.machineCode = machineCode;
            loginInfo.productCode = productCode;
            activationLoginRequest loginRequestXml = new activationLoginRequest();
            //ACCOUNTClient accountCLient = new ACCOUNTClient("ACCOUNTSoap11", "http://51cfjs.com:8080/jdd-billing/services/");
            loginRequestXml.acvLoginRequestInfo = loginInfo;
            activationLoginResponse loginResponse = null;
            try
            {
                loginResponse = accountCLient.activationLogin(loginRequestXml);
            }
            catch (Exception e)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "登录失败！失败时间：" + DateTime.Now.ToString() + "，参数信息" + loginRequestXml.ToString() + "，异常信息：" + e.Message);
                return result;
            }
            if (loginResponse != null && loginResponse.acvLoginResponseInfo != null && loginResponse.acvLoginResponseInfo.result == "1")
            {
                result.Add("msgResult", loginResponse.acvLoginResponseInfo.result);
                result.Add("msgDesc", loginResponse.acvLoginResponseInfo.resultMsg);
                result.Add("deadLine", loginResponse.acvLoginResponseInfo.deadLine);
                result.Add("noticeTitle", loginResponse.acvLoginResponseInfo.noticeTitle);
                result.Add("noticeContent", loginResponse.acvLoginResponseInfo.noticeContent);
                result.Add("showFlag", loginResponse.acvLoginResponseInfo.showFlag);
                result.Add("isUpdate", loginResponse.acvLoginResponseInfo.isUpdate);
                return result;
            }
            else if (loginResponse != null && loginResponse.acvLoginResponseInfo != null && loginResponse.acvLoginResponseInfo.result == "0")
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", loginResponse.acvLoginResponseInfo.resultMsg);
                return result;
            }
            else
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "登录失败！");
                return result;
            }
        }
        /// <summary>
        /// 个人产品心跳检测
        /// </summary>
        /// <param name="activationCode">注册码</param>
        /// <param name="productCode">产品编号</param>
        /// <param name="machineCode">机器码</param>
        /// <returns>
        ///     Dictionary里以键值对存放的 
        ///     msgResult=1表示检测成功 则msgDesc=成功信息
        ///     msgResult=0检测失败 则msgDesc=失败信息
        /// </returns>
        public Dictionary<string, object> personHeartBeat(string activationCode, string productCode, string machineCode)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (activationCode == null || productCode == null || machineCode == null)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测失败，检测信息为空！");
                return result;
            }
            //ACCOUNTClient accountCLient = new ACCOUNTClient("ACCOUNTSoap11", "http://51cfjs.com:8080/jdd-billing/services/");
            AcvProMacInfo macInfo = new AcvProMacInfo();
            macInfo.activationCode = activationCode;
            macInfo.machineCode = machineCode;
            macInfo.productCode = productCode;
            personHeartBeatRequest heartBeatRequest = new personHeartBeatRequest();
            heartBeatRequest.personHeartBeatRequestInfo = macInfo;
            personHeartBeatResponse heartBeatResponse = null;
            try
            {
                heartBeatResponse = accountCLient.personHeartBeat(heartBeatRequest);
            }
            catch (Exception e)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测失败！失败时间：" + DateTime.Now.ToString() + "，参数信息" + heartBeatRequest.ToString() + "，异常信息：" + e.Message);
                return result;
            }
            if (heartBeatResponse != null && heartBeatResponse.personHeartBeatResponseInfo != null)
            {
                result.Add("msgResult", heartBeatResponse.personHeartBeatResponseInfo.result);
                result.Add("msgDesc", heartBeatResponse.personHeartBeatResponseInfo.resultMsg);
                return result;
            }
            else
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "检测失败！");
                return result;
            }
        }
        public Dictionary<string, object> queryClientConfigs(string productCode)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            clientConfigRequest request = new clientConfigRequest();
            ClientConfigInfo info = new ClientConfigInfo();
            info.productCode = productCode;
            request.clientConfigRequestInfo = info;
            clientConfigResponse response = new clientConfigResponse();
            try
            {
                response = accountCLient.clientConfig(request);
            }
            catch (Exception e)
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "获取客户端配置失败！失败时间：" + DateTime.Now.ToString() + "，参数信息" + request.ToString() + "，异常信息：" + e.Message);
                return result;
            }
            if (response != null && response.clientConfigResponseInfo != null && "1".Equals(response.clientConfigResponseInfo.result))
            {
                result.Add("msgResult", response.clientConfigResponseInfo.result);
                result.Add("msgDesc", response.clientConfigResponseInfo.resultMsg);
                ClientConfig[] configList = response.clientConfigResponseInfo.clientConfigList;
                Dictionary<string, object> configDic = new Dictionary<string, object>();
                foreach (ClientConfig tem in configList)
                {
                    configDic.Add(tem.configKey, tem.configValue);
                }
                result.Add("configDic", configDic);
                return result;
            }
            else
            {
                result.Add("msgResult", "0");
                result.Add("msgDesc", "获取客户端配置失败！");
                return result;
            }

        }


    }
}
