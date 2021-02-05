using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WeFinex;


namespace Wefinex
{
    class BaseRun1
    {
        static ChromeDriver chromeDriver;

        static string[] block0 = new string[21];
        static string[] block1 = new string[21];
        static string[] block2 = new string[21];
        static string[] block3 = new string[21];
        static string[] block4 = new string[21];
        static string[] block5 = new string[21];

        static float minMoney = 100;
        static float maxMoney = 15550;
        static string startTime;
        static int currentCandle;
        static float currentMoney;
        static int countCheckLostConnect = 0;



        static int isJustUpdate;
        static int isJustCommanded;





        //rule1
        static int[] resultArrayRule1 = new int[20];
        static int rule1_totalCommand = 0;
        static int rule1_lostChain = 0;
        static int rule1_maxLostChain = 0;
        static int rule1_lost0 = 0;
        static int rule1_lost1 = 0;
        static int rule1_lost2 = 0;
        static int rule1_lost3 = 0;
        static int rule1_lost4 = 0;
        static int rule1_lost5 = 0;
        static int rule1_lost6 = 0;
        static int rule1_lost7 = 0;
        static int rule1_lost8 = 0;
        static int rule1_lost9 = 0;
        static int rule1_lost10 = 0;
        static int rule1_lostChainSignal = 0;
        static int rule1_totalWin = 0;
        static int rule1_totalLost = 0;
        static int rule1_total_2_san = 0;



        //rule2
        static int[] resultArrayrule2 = new int[20];
        static int rule2_totalCommand = 0;
        static int rule2_lostChain = 0;
        static int rule2_maxLostChain = 0;
        static int rule2_lost0 = 0;
        static int rule2_lost1 = 0;
        static int rule2_lost2 = 0;
        static int rule2_lost3 = 0;
        static int rule2_lost4 = 0;
        static int rule2_lost5 = 0;
        static int rule2_lost6 = 0;
        static int rule2_lost7 = 0;
        static int rule2_lost8 = 0;
        static int rule2_lost9 = 0;
        static int rule2_lost10 = 0;
        static int rule2_lostChainSignal = 0;



        //rule3
        static int[] resultArrayrule3 = new int[20];
        static int rule3_totalCommand = 0;
        static int rule3_lostChain = 0;
        static int rule3_maxLostChain = 0;
        static int rule3_lost0 = 0;
        static int rule3_lost1 = 0;
        static int rule3_lost2 = 0;
        static int rule3_lost3 = 0;
        static int rule3_lost4 = 0;
        static int rule3_lost5 = 0;
        static int rule3_lost6 = 0;
        static int rule3_lost7 = 0;
        static int rule3_lost8 = 0;
        static int rule3_lost9 = 0;
        static int rule3_lost10 = 0;
        static int rule3_lostChainSignal = 0;
        static int rule3_lostDouble = 1;


        //rule4
        static int[] resultArrayrule4 = new int[20];
        static int rule4_totalCommand = 0;
        static int rule4_lostChain = 0;
        static int rule4_maxLostChain = 0;
        static int rule4_lost0 = 0;
        static int rule4_lost1 = 0;
        static int rule4_lost2 = 0;
        static int rule4_lost3 = 0;
        static int rule4_lost4 = 0;
        static int rule4_lost5 = 0;
        static int rule4_lost6 = 0;
        static int rule4_lost7 = 0;
        static int rule4_lost8 = 0;
        static int rule4_lost9 = 0;
        static int rule4_lost10 = 0;
        static int rule4_lostChainSignal = 0;
        static int rule4_lostDouble = 1;

        //rule5
        static int[] resultArrayrule5 = new int[30];
        static int rule5_totalCommand = 0;
        static int rule5_lostChain = 0;
        static int rule5_maxLostChain = 0;
        static int rule5_lost0 = 0;
        static int rule5_lost1 = 0;
        static int rule5_lost2 = 0;
        static int rule5_lost3 = 0;
        static int rule5_lost4 = 0;
        static int rule5_lost5 = 0;
        static int rule5_lost6 = 0;
        static int rule5_lost7 = 0;
        static int rule5_lost8 = 0;
        static int rule5_lost9 = 0;
        static int rule5_lost10 = 0;
        static int rule5_checkThuan = 0;
        static int rule5_checkNghich = 0;
        static int rule5_checkSole = 0;

        //rule6
        static int[] resultArrayrule6 = new int[30];
        static int rule6_totalCommand = 0;
        static int rule6_lostChain = 0;
        static int rule6_maxLostChain = 0;
        static int rule6_lost0 = 0;
        static int rule6_lost1 = 0;
        static int rule6_lost2 = 0;
        static int rule6_lost3 = 0;
        static int rule6_lost4 = 0;
        static int rule6_lost5 = 0;
        static int rule6_lost6 = 0;
        static int rule6_lost7 = 0;
        static int rule6_lost8 = 0;
        static int rule6_lost9 = 0;
        static int rule6_lost10 = 0;
        static int rule6_checkThuan = 0;
        static int rule6_checkNghich = 0;
        static int rule6_checkSole = 0;


        static string title1;
        static string title2;
        static string title3;

        static float buy_binance = 0;
        static float sell_binance = 0;


        static float buy_huobi = 0;
        static float sell_huobi = 0;




        static void Main(string[] args)
        {
            createChomeDriver();

            checkLogin();


            createBlockFirstTime();

            waitFirstTime();
            messageStartBot();

            //int a = 1;

            //while (a < 3)
            //{
            //    Thread.Sleep(2000);
            //    getInfoBinance3();
            //    getInfoHuobi2();
            //    Console.WriteLine("--------Check every 2 seconds --------- ");
            //}


              runAll();

        }

        static void createChomeDriver()
        {
            ChromeOptions option = new ChromeOptions();


            //  string profile = "@/Users/huynhduc96/Library/Application\\ Support/Google/Chrome/Default";
            // string profile1 = @"/Users/huynhduc96/Library/Application Support/Google/Chrome/Default";

            // string profile3 = @"/Users/huynhduc96/Library/Application Support/Google/Chrome";


            string profile2 = "/Users/huynhduc96/Desktop/test/";
            string binance = "https://www.binance.com/en/trade/BTC_BUSD";
            string huobi = "https://www.huobi.com/en-us/exchange/";
            string okex = "https://www.okex.com/spot/trade/btc-usdt";
          //  string okex = "https://www.okex.com/spot/full/btc-usdt#type=1";



            option.AddArgument("user-data-dir=" + profile2);
            option.AddArgument("--disable-blink-features=AutomationControlled");
           // option.AddArgument("--headless");
            //option.AddAdditionalCapability("useAutomationExtension", false);
            //option.AddExcludedArgument("enable-automation");

            chromeDriver = new ChromeDriver(option);

            // open first url
            chromeDriver.Navigate().GoToUrl("https://wefinex.net/");
            chromeDriver.Manage().Window.Size = new System.Drawing.Size(1366, 768);

            Thread.Sleep(1000);
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            title1 = (string)js.ExecuteScript("var a= document.querySelector('title').textContent; return a;");

            //     title1 = currentColor;
            Console.WriteLine("title1: " + title1);
            // open 2 tab

            //------------------------

            chromeDriver.ExecuteScript("window.open('" + binance + "', '_blank');");

            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[1]);


            Thread.Sleep(1000);
            title2 = (string)js.ExecuteScript("var a= document.querySelector('title').textContent; return a;");
            Console.WriteLine("run Binance : " + title2);
            // open 3 tabs
            chromeDriver.ExecuteScript("window.open('" + huobi + "', '_blank');");
          //  chromeDriver.ExecuteScript("window.open('" + okex + "', '_blank');");
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[2]);
            Thread.Sleep(1000);
            title3 = (string)js.ExecuteScript("var a= document.querySelector('title').textContent; return a;");

            Thread.Sleep(1000);
            chromeDriver.ExecuteScript("window.open('" + okex + "', '_blank');");
            //  chromeDriver.ExecuteScript("window.open('" + okex + "', '_blank');");
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[3]);
           


            Thread.Sleep(1000);
            checkLoad();
            Thread.Sleep(1000);

            //------------------------


            Console.WriteLine("run Huobi ");
            Console.WriteLine("title1: " + title1);
            Console.WriteLine("title2: " + title2);
            Console.WriteLine("title3: " + title3);

            //   getInfoBinance();
            //   getInfoBinance2();
            //    getInfoHuobi();



            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
            Thread.Sleep(5000);

          //  Console.WriteLine(chromeDriver.PageSource);


            //   var time25s = (string)js.ExecuteScript("getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent; return getCorrectTime;");
            //  Thread.Sleep(60000);
            chromeDriver.ExecuteScript("document.querySelector('.nav.nav-pills.tab-last-result').getElementsByTagName('li')[1].getElementsByTagName('a')[0].click();");


        }

        static public void getInfoBinance3()
        {
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[1]);
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;

            // bán - đỏ

            string sellString = (string)js.ExecuteScript(" var list = document.querySelectorAll('.orderbook-progress'); var sellTotal = 0; for(var i = 0 ; i < list.length ; i++){ var a = list[i]; var listInfo = a.childNodes[0].childNodes[0]; var className = listInfo.childNodes[0].className; if(className.localeCompare('ask-light') === 0){ var data = parseFloat(listInfo.childNodes[1].textContent); sellTotal = sellTotal + data; } } return sellTotal.toString();");
            float sellFloat = float.Parse(sellString);
            sell_binance = sellFloat;

            string buyString = (string)js.ExecuteScript(" var list = document.querySelectorAll('.orderbook-progress'); var sellTotal = 0; for(var i = 0 ; i < list.length ; i++){ var a = list[i]; var listInfo = a.childNodes[0].childNodes[0]; var className = listInfo.childNodes[0].className; if(className.localeCompare('bid-light') === 0){ var data = parseFloat(listInfo.childNodes[1].textContent); sellTotal = sellTotal + data; } } return sellTotal.toString();");

            float buyFloat = float.Parse(buyString);
            buy_binance = buyFloat;

            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
            Console.WriteLine("Binance *** Buy : " + buy_binance + " Sell : " + sell_binance);
        }

        static public void getInfoHuobi2()
        {
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[2]);
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;

            string sellString = (string)js.ExecuteScript("var list = document.querySelector('.list.asks').querySelectorAll('.single-orderbook'); var sellTotal = 0; for(var i = 0 ; i < 16 ; i++){ var data = parseFloat(list[i].childNodes[2].textContent); sellTotal = sellTotal + data; } return sellTotal.toString(); ");
            float sellFloat = float.Parse(sellString);
            sell_huobi = sellFloat;

            string buyString = (string)js.ExecuteScript("var list = document.querySelector('.list.bids').querySelectorAll('.single-orderbook'); var sellTotal = 0; for(var i = 0 ; i < 16 ; i++){ var data = parseFloat(list[i].childNodes[2].textContent); sellTotal = sellTotal + data; } return sellTotal.toString();");
            float buyFloat = float.Parse(buyString);
            buy_huobi = buyFloat;
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);

            Console.WriteLine("Huobi   *** Buy : " + buy_huobi + " Sell : " + sell_huobi);
        }

        static public void getInfoBinance2()
        {
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[1]);


            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            int lengthArray;


            string numberTmp;
            numberTmp = (string)js.ExecuteScript("var list = document.querySelectorAll('.orderbook-progress'); var length = list.length ; return length.toString();;");
            lengthArray = Convert.ToInt32(numberTmp);
            for (int i = 0; i < lengthArray; i++)
            {

                string checkType = (string)js.ExecuteScript("var list = document.querySelectorAll('.orderbook-progress'); var a = list[" + i + "]; var listInfo = a.childNodes[0].childNodes[0]; var className = listInfo.childNodes[0].className; return className;");


                if (checkType.CompareTo("ask-light") == 0)
                {
                    // bán - đỏ

                    string sellString = (string)js.ExecuteScript("var list = document.querySelectorAll('.orderbook-progress'); var a = list[" + i + "]; var listInfo = a.childNodes[0].childNodes[0]; var data = listInfo.childNodes[1].textContent; return data.toString();;");

                    float sellFloat = float.Parse(sellString);

                    sell_binance = sell_binance + sellFloat;


                }
                else if (checkType.CompareTo("bid-light") == 0)
                {
                    // mua - xanh 
                    string buyString = (string)js.ExecuteScript("var list = document.querySelectorAll('.orderbook-progress'); var a = list[" + i + "]; var listInfo = a.childNodes[0].childNodes[0]; var data = listInfo.childNodes[1].textContent; return data.toString();");

                    float buyFloat = float.Parse(buyString);

                    buy_binance = buy_binance + buyFloat;
                }
            }

            Console.WriteLine("Binance *** Buy : " + buy_binance + " Sell : " + sell_binance);
        }


        static public void getInfoBinance()
        {
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[1]);

            IReadOnlyList<IWebElement> listAllData = chromeDriver.FindElements(By.CssSelector(".orderbook-progress"));

            for (int i = 0; i < listAllData.Count; i++)
            {
                IWebElement a = listAllData.ElementAt(i).FindElement(By.CssSelector(".progress-container"));
                IWebElement b = a.FindElement(By.CssSelector(".row-content"));

                IReadOnlyList<IWebElement> dataReal = b.FindElements(By.TagName("div"));

                string checkType = dataReal.ElementAt(0).GetAttribute("class");
                //     Console.WriteLine("Binance *** checkType : " + checkType);
                if (checkType.CompareTo("ask-light") == 0)
                {
                    // bán - đỏ

                    string sellString = dataReal.ElementAt(1).Text;
                    float sellFloat = float.Parse(sellString);

                    sell_binance = sell_binance + sellFloat;


                }
                else if (checkType.CompareTo("bid-light") == 0)
                {
                    // mua - xanh 
                    string buyString = dataReal.ElementAt(1).Text;
                    float buyFloat = float.Parse(buyString);

                    buy_binance = buy_binance + buyFloat;
                }

            }

            Console.WriteLine("Binance *** Buy : " + buy_binance + " Sell : " + sell_binance);
        }


        static public void getInfoHuobi()
        {
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[2]);

            IWebElement asks = (IWebElement)chromeDriver.FindElement(By.CssSelector(".list.asks"));

            IReadOnlyList<IWebElement> listAllDataAsks = asks.FindElements(By.TagName("p"));

            for (int i = 0; i < listAllDataAsks.Count; i++)
            {

                try
                {
                    IReadOnlyList<IWebElement> listSell = listAllDataAsks.ElementAt(i).FindElements(By.TagName("span"));
                    string sellString = listSell.ElementAt(1).Text;
                    if ((sellString == null || String.IsNullOrEmpty(sellString)))
                    {

                    }
                    else
                    {
                        float sellFloat = float.Parse(sellString);

                        sell_huobi = sell_huobi + sellFloat;
                    }


                }
                catch (StaleElementReferenceException ex)
                {

                }


            }


            IWebElement bids = (IWebElement)chromeDriver.FindElement(By.CssSelector(".list.asks"));

            IReadOnlyList<IWebElement> listAllDataBids = bids.FindElements(By.TagName(".single-orderbook"));

            for (int i = 0; i < listAllDataAsks.Count; i++)
            {

                try
                {
                    IReadOnlyList<IWebElement> listBuy = listAllDataBids.ElementAt(i).FindElements(By.TagName("span"));
                    string buyString = listBuy.ElementAt(1).Text;
                    if ((buyString == null || String.IsNullOrEmpty(buyString)))
                    {

                    }
                    else
                    {
                        float buyFloat = float.Parse(buyString);

                        buy_huobi = buy_huobi + buyFloat;
                    }


                }
                catch (StaleElementReferenceException ex)
                {

                }


            }


            Console.WriteLine("Huobi *** Buy : " + buy_huobi + " Sell : " + sell_huobi);
        }

        static void checkLoad()
        {
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
            chromeDriver.ExecuteScript("window.open('" + "https://wefinex.net/" + "', '_blank');");

            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[4]);
            Thread.Sleep(7000);
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[4]).Close();
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
        }

        static void runAll()
        {

            getCurrentCandle();
            int createLoop = 1;

            while (createLoop < 3)
            {
                updateCandle28_26();
                updateCandle25_23();
                //   refresh();

                IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
                int canSetCommand;
                string numberTmp;
                numberTmp = (string)js.ExecuteScript("var result; var canSetCommandTml = document.querySelector('.button.btnSuccess.colorDisable'); if (canSetCommandTml == null) {     result= 1; } else {     result = 0; } return result.toString();");
                canSetCommand = Convert.ToInt32(numberTmp);

                if (canSetCommand == 0)
                {
                       refresh();
                }
                checkStopMoney();
                // run 1
                runRule1();

                //   runRule3();
                //   runRule4();



              //  updateCandle5();
            }


        }



        static void runRule1()
        {
            Rule1_1 rule1 = new Rule1_1();
            int[] tmp_resultArrayRule1 = new int[20]; ;
            tmp_resultArrayRule1 = rule1.getStaticValue(chromeDriver, block0, block1, block2, block3, block4, block5, currentCandle, resultArrayRule1);
            resultArrayRule1 = tmp_resultArrayRule1;


            rule1_totalCommand = tmp_resultArrayRule1[0];
            rule1_lostChain = tmp_resultArrayRule1[1];
            rule1_maxLostChain = tmp_resultArrayRule1[2];
            rule1_lost0 = tmp_resultArrayRule1[3];
            rule1_lost1 = tmp_resultArrayRule1[4];
            rule1_lost2 = tmp_resultArrayRule1[5];
            rule1_lost3 = tmp_resultArrayRule1[6];
            rule1_lost4 = tmp_resultArrayRule1[7];
            rule1_lost5 = tmp_resultArrayRule1[8];
            rule1_lost6 = tmp_resultArrayRule1[9];
            rule1_lost7 = tmp_resultArrayRule1[10];
            rule1_lost8 = tmp_resultArrayRule1[11];
            rule1_lost9 = tmp_resultArrayRule1[12];
            rule1_lost10 = tmp_resultArrayRule1[13];

            rule1_totalLost  = tmp_resultArrayRule1[16];
            rule1_totalWin = tmp_resultArrayRule1[17];
            rule1_total_2_san = tmp_resultArrayRule1[18];
        }

        static void runRule2()
        {
            Rule2 rule2 = new Rule2();
            int[] tmp_resultArrayrule2 = new int[20]; ;
            tmp_resultArrayrule2 = rule2.getStaticValue(chromeDriver, block0, block1, block2, block3, block4, block5, currentCandle, resultArrayrule2);
            resultArrayrule2 = tmp_resultArrayrule2;


            rule2_totalCommand = tmp_resultArrayrule2[0];
            rule2_lostChain = tmp_resultArrayrule2[1];
            rule2_maxLostChain = tmp_resultArrayrule2[2];
            rule2_lost0 = tmp_resultArrayrule2[3];
            rule2_lost1 = tmp_resultArrayrule2[4];
            rule2_lost2 = tmp_resultArrayrule2[5];
            rule2_lost3 = tmp_resultArrayrule2[6];
            rule2_lost4 = tmp_resultArrayrule2[7];
            rule2_lost5 = tmp_resultArrayrule2[8];
            rule2_lost6 = tmp_resultArrayrule2[9];
            rule2_lost7 = tmp_resultArrayrule2[10];
            rule2_lost8 = tmp_resultArrayrule2[11];
            rule2_lost9 = tmp_resultArrayrule2[12];
            rule2_lost10 = tmp_resultArrayrule2[13];
            rule2_lostChainSignal = tmp_resultArrayrule2[14];


        }

        static void runRule3()
        {
            Rule3 rule3 = new Rule3();
            int[] tmp_resultArrayrule3 = new int[20]; ;
            tmp_resultArrayrule3 = rule3.getStaticValue(chromeDriver, block0, block1, block2, block3, block4, block5, currentCandle, resultArrayrule3);
            resultArrayrule3 = tmp_resultArrayrule3;


            rule3_totalCommand = tmp_resultArrayrule3[0];
            rule3_lostChain = tmp_resultArrayrule3[1];
            rule3_maxLostChain = tmp_resultArrayrule3[2];
            rule3_lost0 = tmp_resultArrayrule3[3];
            rule3_lost1 = tmp_resultArrayrule3[4];
            rule3_lost2 = tmp_resultArrayrule3[5];
            rule3_lost3 = tmp_resultArrayrule3[6];
            rule3_lost4 = tmp_resultArrayrule3[7];
            rule3_lost5 = tmp_resultArrayrule3[8];
            rule3_lost6 = tmp_resultArrayrule3[9];
            rule3_lost7 = tmp_resultArrayrule3[10];
            rule3_lost8 = tmp_resultArrayrule3[11];
            rule3_lost9 = tmp_resultArrayrule3[12];
            rule3_lost10 = tmp_resultArrayrule3[13];
            rule3_lostChainSignal = tmp_resultArrayrule3[14];
            rule3_lostDouble = tmp_resultArrayrule3[15];

        }

        static void runRule4()
        {
            Rule4 rule4 = new Rule4();
            int[] tmp_resultArrayrule4 = new int[20]; ;
            tmp_resultArrayrule4 = rule4.getStaticValue(chromeDriver, block0, block1, block2, block3, block4, block5, currentCandle, resultArrayrule4);
            resultArrayrule4 = tmp_resultArrayrule4;


            rule4_totalCommand = tmp_resultArrayrule4[0];
            rule4_lostChain = tmp_resultArrayrule4[1];
            rule4_maxLostChain = tmp_resultArrayrule4[2];
            rule4_lost0 = tmp_resultArrayrule4[3];
            rule4_lost1 = tmp_resultArrayrule4[4];
            rule4_lost2 = tmp_resultArrayrule4[5];
            rule4_lost3 = tmp_resultArrayrule4[6];
            rule4_lost4 = tmp_resultArrayrule4[7];
            rule4_lost5 = tmp_resultArrayrule4[8];
            rule4_lost6 = tmp_resultArrayrule4[9];
            rule4_lost7 = tmp_resultArrayrule4[10];
            rule4_lost8 = tmp_resultArrayrule4[11];
            rule4_lost9 = tmp_resultArrayrule4[12];
            rule4_lost10 = tmp_resultArrayrule4[13];
            rule4_lostChainSignal = tmp_resultArrayrule4[14];
            rule4_lostDouble = tmp_resultArrayrule4[15];

        }




        static void printCurrentCandle()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");


            // print rule 1
            Console.WriteLine(" ");
            Console.WriteLine("PP Tường ");
            Console.WriteLine(" ");
            Console.WriteLine("--->Result: " + "lost0: " + (rule1_lost0 - rule1_lost2) + " - lost1: " + (rule1_lost1 - rule1_lost2) + " - lost2: " + (rule1_lost2 - rule1_lost3));
            Console.WriteLine("--->Result: " + "lost3: " + (rule1_lost3 - rule1_lost4) + " - lost4: " + (rule1_lost4 - rule1_lost5) + " - lost5: " + (rule1_lost5 - rule1_lost6));
            Console.WriteLine("--->Result: " + "lost6: " + (rule1_lost6 - rule1_lost7) + " - lost7: " + (rule1_lost7 - rule1_lost8) + " - lost8: " + rule1_lost8);
            Console.WriteLine("Total Win: " + rule1_totalWin + " -  Total Lost: " + rule1_totalLost + " - CurrentMonney: " + currentMoney + "$");
            Console.WriteLine("--->Time " + show_time + " :  currentCandle : " + currentCandle + " - " + block0[currentCandle] + " **** totalCommand:  " + rule1_totalCommand + " - total_2_san: " + rule1_total_2_san + " - maxLostChain: " + rule1_maxLostChain + " - current lostChain: " + rule1_lostChain);


            //      printrule3();
            //     printrule4();


        }

        static void printRule2()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");

            // print rule 2
            Console.WriteLine(" ");
            Console.WriteLine("PP Lien Hoan cot 1 ");
            Console.WriteLine(" ");
            Console.WriteLine("--->Result: " + "lost0: " + (rule2_lost0 - rule2_lost2) + " - lost1: " + (rule2_lost1 - rule2_lost2) + " - lost2: " + (rule2_lost2 - rule2_lost3));
            Console.WriteLine("--->Result: " + "lost3: " + (rule2_lost3 - rule2_lost4) + " - lost4: " + (rule2_lost4 - rule2_lost5) + " - lost5: " + (rule2_lost5 - rule2_lost6));
            Console.WriteLine("--->Result: " + "lost6: " + (rule2_lost6 - rule2_lost7) + " - lost7: " + (rule2_lost7 - rule2_lost8) + " - lost8: " + rule2_lost8);
            Console.WriteLine("lostChainSignal: " + rule2_lostChainSignal);
            Console.WriteLine("--->Time " + show_time + " :  currentCandle : " + currentCandle + " - " + block0[currentCandle] + " **** totalCommand:  " + rule2_totalCommand + " - maxLostChain: " + rule2_maxLostChain + " - current lostChain: " + rule2_lostChain);

        }

        static void printrule3()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");

            // print rule 2
            Console.WriteLine(" ");
            Console.WriteLine("PP Trung bình kết quả ");
            Console.WriteLine(" ");
            Console.WriteLine("--->Result: " + "lost0: " + (rule3_lost0 - rule3_lost2) + " - lost1: " + (rule3_lost1 - rule3_lost2) + " - lost2: " + (rule3_lost2 - rule3_lost3));
            Console.WriteLine("--->Result: " + "lost3: " + (rule3_lost3 - rule3_lost4) + " - lost4: " + (rule3_lost4 - rule3_lost5) + " - lost5: " + (rule3_lost5 - rule3_lost6));
            Console.WriteLine("--->Result: " + "lost6: " + (rule3_lost6 - rule3_lost7) + " - lost7: " + (rule3_lost7 - rule3_lost8) + " - lost8: " + rule3_lost8);
            Console.WriteLine("lostChainSignal: " + rule3_lostChainSignal + " - rule3_lostDouble: " + rule3_lostDouble);
            Console.WriteLine("--->Time " + show_time + " :  currentCandle : " + currentCandle + " - " + block0[currentCandle] + " **** totalCommand:  " + rule3_totalCommand + " - maxLostChain: " + rule3_maxLostChain + " - current lostChain: " + rule3_lostChain);

        }

        static void printrule4()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");

            // print rule 2
            Console.WriteLine(" ");
            Console.WriteLine("PP theo nến 6 ");
            Console.WriteLine(" ");
            Console.WriteLine("--->Result: " + "lost0: " + (rule4_lost0 - rule4_lost2) + " - lost1: " + (rule4_lost1 - rule4_lost2) + " - lost2: " + (rule4_lost2 - rule4_lost3));
            Console.WriteLine("--->Result: " + "lost3: " + (rule4_lost3 - rule4_lost4) + " - lost4: " + (rule4_lost4 - rule4_lost5) + " - lost5: " + (rule4_lost5 - rule4_lost6));
            Console.WriteLine("--->Result: " + "lost6: " + (rule4_lost6 - rule4_lost7) + " - lost7: " + (rule4_lost7 - rule4_lost8) + " - lost8: " + rule4_lost8);
            Console.WriteLine("lostChainSignal: " + rule4_lostChainSignal + " - rule4_lostDouble: " + rule4_lostDouble);
            Console.WriteLine("--->Time " + show_time + " :  currentCandle : " + currentCandle + " - " + block0[currentCandle] + " **** totalCommand:  " + rule4_totalCommand + " - maxLostChain: " + rule4_maxLostChain + " - current lostChain: " + rule4_lostChain);

        }


        static void updateCandleBase()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            string currentColor;
            string currentColorTmp;

            if (currentCandle == 20)
            {
                string[] tmpArray = new string[21];
                currentCandle = 1;
                isJustUpdate = 1;

                tmpArray = block4;
                block5 = tmpArray;
                tmpArray = block3;
                block4 = tmpArray;
                tmpArray = block2;
                block3 = tmpArray;
                tmpArray = block1;
                block2 = tmpArray;
                tmpArray = block0;
                block1 = tmpArray;
                block0 = new string[21];


                // update

                currentColorTmp = (string)js.ExecuteScript("var allListCraw2 = document.querySelector('.highcharts-series.highcharts-series-1.highcharts-column-series.highcharts-color-0.highcharts-tracker'); var colorTmp2; var last = allListCraw2.childNodes.length - 2; var colorX = allListCraw2.childNodes[last].getAttribute('fill');  return colorX;");


                if ((currentColorTmp.CompareTo("#31BAA0") == 0) ||
                    (currentColorTmp.CompareTo("rgb(49,186,160)") == 0) ||
                    (currentColorTmp.CompareTo("rgb(74,211,185)") == 0) ||
                    (currentColorTmp.CompareTo("#31baa0") == 0))
                {
                    currentColor = "blue";
                }
                else
                {
                    currentColor = "red";
                }

                block0[currentCandle] = currentColor;

            }
            else if ((currentCandle < 20) && (currentCandle > 0))
            {
                currentCandle = currentCandle + 1;

                currentColorTmp = (string)js.ExecuteScript("var allListCraw2 = document.querySelector('.highcharts-series.highcharts-series-1.highcharts-column-series.highcharts-color-0.highcharts-tracker'); var colorTmp2; var last = allListCraw2.childNodes.length - 2; var colorX = allListCraw2.childNodes[last].getAttribute('fill');  return colorX;");


                if ((currentColorTmp.CompareTo("#31BAA0") == 0) ||
                    (currentColorTmp.CompareTo("rgb(49,186,160)") == 0) ||
                    (currentColorTmp.CompareTo("rgb(74,211,185)") == 0) ||
                    (currentColorTmp.CompareTo("#31baa0") == 0))
                {
                    currentColor = "blue";
                }
                else
                {
                    currentColor = "red";
                }

                block0[currentCandle] = currentColor;

            }

        }


        static void refresh()
        {
            if (currentCandle == 20)
            {
                chromeDriver.Navigate().Refresh();
                chromeDriver.Manage().Window.Size = new System.Drawing.Size(1366, 768);
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[1]);
                chromeDriver.Navigate().Refresh();
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[2]);
                chromeDriver.Navigate().Refresh();
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[3]);
                chromeDriver.Navigate().Refresh();
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                checkLoad();
           //     chromeDriver.Navigate().Refresh();
                Thread.Sleep(3000);

                chromeDriver.ExecuteScript("document.querySelector('.nav.nav-pills.tab-last-result').getElementsByTagName('li')[1].getElementsByTagName('a')[0].click();");

                IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
                string numberTmp;
                int currentCandle_Check = 0;
                numberTmp = (string)js.ExecuteScript("getup_down = document.querySelector('.overviewInfo.d-flex.align-items-center').getElementsByClassName('badgeItem'); up_span = getup_down[0].getElementsByTagName('span')[1].textContent; down_span = getup_down[1].getElementsByTagName('span')[1].textContent; up = parseInt(up_span); down = parseInt(down_span); inputCurrentCandle = ((up + down) % 20); return inputCurrentCandle.toString();");
                Console.WriteLine("numberTmp:  " + numberTmp);
                currentCandle_Check = Convert.ToInt32(numberTmp);
                if (currentCandle_Check == 0)
                {
                    if (currentCandle != 20)
                    {
                        Console.WriteLine("---------------------------------------> Lệch nến : ");
                        chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_WARNING]%0A Xuất hiện nến trắng hoặc Bot đã chạy sai !   %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");

                    }
                }
                else
                {
                    if (currentCandle != currentCandle_Check)
                    {
                        Console.WriteLine("---------------------------------------> Lệch nến : ");
                        chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_WARNING]%0A Xuất hiện nến trắng hoặc Bot đã chạy sai !   %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");

                    }
                }

            }
            else
            {
                if ((currentCandle % 4) == 0)
                {
                    chromeDriver.Navigate().Refresh();
                    chromeDriver.Manage().Window.Size = new System.Drawing.Size(1366, 768);


                    checkLoad();
                //    chromeDriver.Navigate().Refresh();
                    Thread.Sleep(5000);



                    chromeDriver.ExecuteScript("document.querySelector('.nav.nav-pills.tab-last-result').getElementsByTagName('li')[1].getElementsByTagName('a')[0].click();");
                }
                // check lech nen
                if ((currentCandle % 10) == 0)
                {
                    chromeDriver.Navigate().Refresh();
                    chromeDriver.Manage().Window.Size = new System.Drawing.Size(1366, 768);


                    checkLoad();
               //     chromeDriver.Navigate().Refresh();
                    Thread.Sleep(5000);

                    chromeDriver.ExecuteScript("document.querySelector('.nav.nav-pills.tab-last-result').getElementsByTagName('li')[1].getElementsByTagName('a')[0].click();");

                    IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
                    string numberTmp;
                    int currentCandle_Check = 0;
                    numberTmp = (string)js.ExecuteScript("getup_down = document.querySelector('.overviewInfo.d-flex.align-items-center').getElementsByClassName('badgeItem'); up_span = getup_down[0].getElementsByTagName('span')[1].textContent; down_span = getup_down[1].getElementsByTagName('span')[1].textContent; up = parseInt(up_span); down = parseInt(down_span); inputCurrentCandle = ((up + down) % 20); return inputCurrentCandle.toString();");

                    currentCandle_Check = Convert.ToInt32(numberTmp);
                    if (currentCandle_Check == 0)
                    {
                        if (currentCandle != 20)
                        {
                            Console.WriteLine("---------------------------------------> Lệch nến : ");
                            chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_WARNING]%0A Xuất hiện nến trắng hoặc Bot đã chạy sai !   %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");

                        }
                    }
                    else
                    {
                        if (currentCandle != currentCandle_Check)
                        {
                            Console.WriteLine("---------------------------------------> Lệch nến : ");
                            chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_WARNING]%0A Xuất hiện nến trắng hoặc Bot đã chạy sai !   %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");

                        }
                    }

                }
            }


        }


        static void updateCandle5()
        {
            if (isJustUpdate == 0)
            {
                int createLoop25 = 1;
                IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;

                while (createLoop25 < 3)
                {
                    var time25s = (string)js.ExecuteScript("getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent; return getCorrectTime;");
                    if ((time25s.CompareTo("5s") == 0) ||
                        (time25s.CompareTo("4s") == 0) ||
                        (time25s.CompareTo("3s") == 0) ||
                        (time25s.CompareTo("2s") == 0))
                    {
                        updateCandleBase();
                        createLoop25 = 4;
                        isJustUpdate = 1;
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
            }
        }



        static void updateCandle25_23()
        {
            if (isJustUpdate == 0)
            {
                int createLoop25 = 1;
                IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;

                while (createLoop25 < 3)
                {
                    var time25s = (string)js.ExecuteScript("getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent; return getCorrectTime;");
                    if ((time25s.CompareTo("25s") == 0) ||
                        (time25s.CompareTo("24s") == 0) ||
                        (time25s.CompareTo("23s") == 0) ||
                        (time25s.CompareTo("22s") == 0))
                    {
                        updateCandleBase();
                        createLoop25 = 4;
                        isJustUpdate = 1;
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
            }
        }

        static void updateCandle28_26()
        {
            printAllCandle();
            printCurrentCandle();
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;

            int createLoop27 = 1;

            while (createLoop27 < 3)
            {
                var time27s = (string)js.ExecuteScript("getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent; return getCorrectTime;");
                if ((time27s.CompareTo("28s") == 0)
                   || (time27s.CompareTo("27s") == 0)
                   || (time27s.CompareTo("26s") == 0)
                   )
                {
                    updateValueSignalBase();
                    createLoop27 = 4;
                }
                else
                {
                    Thread.Sleep(500);
                    checkStop();
                }


            }
        }

        static void updateValueSignalBase()
        {
            isJustUpdate = 0;
            isJustCommanded = 0;
            countCheckLostConnect = 0;
        }

        static void printAllCandle()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" --------------------------------------------------------------------------------");
            //Console.WriteLine(" ");
            //Console.WriteLine("Block 5: [{0}]", string.Join(", ", block5));
            //Console.WriteLine("Block 4: [{0}]", string.Join(", ", block4));
            //Console.WriteLine("Block 3: [{0}]", string.Join(", ", block3));
            //Console.WriteLine("Block 2: [{0}]", string.Join(", ", block2));
            Console.WriteLine("Block 1: [{0}]", string.Join(", ", block1));
            Console.WriteLine("Block 0: [{0}]", string.Join(", ", block0));
        }


        static void checkStop()
        {
            bool result = checkInternet();
            if (!result)
            {
                countCheckLostConnect++;
                Console.WriteLine("-------------->Lost internet !!!");

            }

            if (countCheckLostConnect > 10)
            {
                Console.WriteLine("Stop because lost internet !!!");
                chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_CLOSE] Bot Stop!!!      %0A Stop because lost internet !!! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }

        static bool checkInternet()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void checkStopMoney()
        {

            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            string numberTmp;
            Thread.Sleep(1000);
            numberTmp = (string)js.ExecuteScript("var money = document.querySelector('.buttonBalance.d-flex.align-items-center').querySelector('.d-flex.flex-column.mr-lg-2.mr-2').querySelector('.d-flex.align-items-center').getElementsByTagName('span')[0].textContent; var lengthX = money.length; var moneytmp2= money.slice(1,lengthX); var moneyTmp = parseFloat(moneytmp2.replace(/,/g,'')); return moneyTmp.toString();");
            Console.WriteLine("numberTmp:  " + numberTmp);
            currentMoney = float.Parse(numberTmp);

            if (currentMoney < minMoney)
            {
                Console.WriteLine("currentMoney : " + currentMoney);
                Console.WriteLine("Stop because currentMoney less minMoney !!!");
                string currentTime;
                currentTime = (string)js.ExecuteScript(" var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + '- in ' + getCorrectTime; return show_time;");
                chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_CLOSE] Chốt Lỗ :    %0A Số tiền chốt lỗ : " + minMoney + " $ %0A Số tiền hiện tại : " + currentMoney + " $ %0A Start Bot in " + startTime + "  %0A Stop Bot in " + currentTime + " ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }

            if (currentMoney > maxMoney)
            {
                Console.WriteLine("currentMoney : " + currentMoney);
                Console.WriteLine("Stop because currentMoney over maxMoney !!!");
                string currentTime;
                currentTime = (string)js.ExecuteScript(" var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + '- in ' + getCorrectTime; return show_time;");
                chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_CLOSE] Chốt Lời :    %0A Số tiền chốt lời : " + maxMoney + " $ %0A Số tiền hiện tại : " + currentMoney + " $ %0A Start Bot in " + startTime + " %0A Stop Bot in " + currentTime + " ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }

        }

        static void messageStartBot()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            string currentTime;
            string numberTmp;
            numberTmp = (string)js.ExecuteScript("var money = document.querySelector('.buttonBalance.d-flex.align-items-center').querySelector('.d-flex.flex-column.mr-lg-2.mr-2').querySelector('.d-flex.align-items-center').getElementsByTagName('span')[0].textContent; var lengthX = money.length; var moneytmp2= money.slice(1,lengthX); var moneyTmp = parseFloat(moneytmp2.replace(/,/g,'')); return moneyTmp.toString();");
            currentMoney = float.Parse(numberTmp);
            currentTime = (string)js.ExecuteScript(" var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + '- in ' + getCorrectTime; return show_time;");
            chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_START] Bot Start :   %0A Số tiền chốt lời : " + maxMoney + " $ %0A Số tiền chốt lỗ : " + minMoney + " $ %0A Số tiền hiện tại : " + currentMoney + " $ %0A Start Bot in " + currentTime + " ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
            startTime = currentTime;

        }



        static void checkLogin()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            var confirmLogin = (string)js.ExecuteScript("var confirm = document.querySelector('.profitPercent.color-light-blue.ml-2.mb-2.d-inline-block').textContent; return confirm;");

            Console.WriteLine(confirmLogin);

            string checkString = "95%";


            if (checkString.CompareTo(confirmLogin) == 0)
            {
                Console.WriteLine("Login successful !!!");

                getCurrentCandle();


            }
            else
            {
                Console.WriteLine("Login failed  !!!");
            }
        }

        static void getCurrentCandle()
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            string numberTmp;
            numberTmp = (string)js.ExecuteScript("getup_down = document.querySelector('.overviewInfo.d-flex.align-items-center').getElementsByClassName('badgeItem'); up_span = getup_down[0].getElementsByTagName('span')[1].textContent; down_span = getup_down[1].getElementsByTagName('span')[1].textContent; up = parseInt(up_span); down = parseInt(down_span); inputCurrentCandle = ((up + down) % 20); return inputCurrentCandle.toString();");

            currentCandle = Convert.ToInt32(numberTmp);
            Console.WriteLine("currentCandle: " + currentCandle);
        }

        static void waitFirstTime()
        {
            Console.WriteLine("Wait to first time come   !!!");
            int createLoopFirstTime = 1;
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            string currentColor;
            string currentColorTmp;



            while (createLoopFirstTime < 3)
            {
                var time20s = (string)js.ExecuteScript("getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent; return getCorrectTime;");
                if ((time20s.CompareTo("20s") == 0) ||
                    (time20s.CompareTo("19s") == 0) ||
                    (time20s.CompareTo("18s") == 0))
                {
                    //  currentColor = (string)js.ExecuteScript("var allListCraw2 = document.querySelector('.highcharts-series.highcharts-series-1.highcharts-column-series.highcharts-color-0.highcharts-tracker'); var colorTmp2; var last = allListCraw2.childNodes.length - 2; var colorX = allListCraw2.childNodes[last].getAttribute('fill'); if ((colorX.localeCompare('#31BAA0') === 0) || (colorX.localeCompare('rgb(49,186,160)') === 0) || (colorX.localeCompare('rgb(74,211,185)') === 0) || (colorX.localeCompare('#31baa0') === 0)) {     colorTmp = 'blue'; } else {     colorTmp = 'red'; } return colorTmp;");
                    currentColorTmp = (string)js.ExecuteScript("var allListCraw2 = document.querySelector('.highcharts-series.highcharts-series-1.highcharts-column-series.highcharts-color-0.highcharts-tracker'); var colorTmp2; var last = allListCraw2.childNodes.length - 2; var colorX = allListCraw2.childNodes[last].getAttribute('fill');  return colorX;");


                    if ((currentColorTmp.CompareTo("#31BAA0") == 0) ||
                        (currentColorTmp.CompareTo("rgb(49,186,160)") == 0) ||
                        (currentColorTmp.CompareTo("rgb(74,211,185)") == 0) ||
                        (currentColorTmp.CompareTo("#31baa0") == 0))
                    {
                        currentColor = "blue";
                    }
                    else
                    {
                        currentColor = "red";
                    }

                    block0[currentCandle + 1] = currentColor;
                    Console.WriteLine("currentCandle color : " + block0[currentCandle + 1]);
                    createLoopFirstTime = 4;
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
        }

        static void createBlockFirstTime()
        {

            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            int lengthArray;
            int block = 0;
            int inputCurrentCandle = currentCandle;

            string numberTmp;
            numberTmp = (string)js.ExecuteScript("var allListCraw2 = document.querySelector('.highcharts-series.highcharts-series-1.highcharts-column-series.highcharts-color-0.highcharts-tracker'); var length = allListCraw2.childNodes.length - 2; return length.toString();");

            lengthArray = Convert.ToInt32(numberTmp);

            for (int i = lengthArray; i > 0; i--)
            {
                string currentColor;
                string currentColorTmp;
                currentColorTmp = (string)js.ExecuteScript("var last = " + i + "; var allListCraw2 = document.querySelector('.highcharts-series.highcharts-series-1.highcharts-column-series.highcharts-color-0.highcharts-tracker'); var colorTmp2; var colorX = allListCraw2.childNodes[last].getAttribute('fill');  return colorX;");

                if ((currentColorTmp.CompareTo("#31BAA0") == 0) ||
                    (currentColorTmp.CompareTo("rgb(49,186,160)") == 0) ||
                    (currentColorTmp.CompareTo("rgb(74,211,185)") == 0) ||
                    (currentColorTmp.CompareTo("#31baa0") == 0))
                {
                    currentColor = "blue";
                }
                else
                {
                    currentColor = "red";
                }


                if (block < 2)
                {
                    if (inputCurrentCandle == 1)
                    {
                        if (block == 0)
                        {
                            block0[1] = currentColor;
                        }
                        if (block == 1)
                        {
                            block1[1] = currentColor;
                        }
                        if (block == 2)
                        {
                            block2[1] = currentColor;
                        }
                        inputCurrentCandle = 20;
                        block = block + 1;
                    }
                    else if (inputCurrentCandle < 21 && inputCurrentCandle > 1)
                    {
                        if (block == 0)
                        {
                            block0[inputCurrentCandle] = currentColor;

                        }
                        if (block == 1)
                        {
                            block1[inputCurrentCandle] = currentColor;

                        }
                        if (block == 2)
                        {
                            block2[inputCurrentCandle] = currentColor;

                        }
                        inputCurrentCandle = inputCurrentCandle - 1;
                    }
                }


            }
            printAllCandle();


        }

        static void setCommandUp(float money)
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            int canSetCommand;
            string numberTmp;
            numberTmp = (string)js.ExecuteScript("var result; var canSetCommandTml = document.querySelector('.button.btnSuccess.colorDisable'); if (canSetCommandTml == null) {     result= 1; } else {     result = 0; } return result.toString();");
            canSetCommand = Convert.ToInt32(numberTmp);

            if (canSetCommand == 1)
            {
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.value =" + money + "; return 1;");
                Thread.Sleep(200);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('change', {     bubbles: true })); return 1;");
                Thread.Sleep(500);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('blur', {     bubbles: true })); return 1;");
                Thread.Sleep(500);
                chromeDriver.ExecuteScript("document.querySelector('.button.btnSuccess').click(); return 1;");
                isJustCommanded = 1;
            }

        }

        static void setCommandDown(float money)
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            int canSetCommand;
            string numberTmp;
            numberTmp = (string)js.ExecuteScript("var result; var canSetCommandTml = document.querySelector('.button.btnSuccess.colorDisable'); if (canSetCommandTml == null) {     result= 1; } else {     result = 0; } return result.toString();");
            canSetCommand = Convert.ToInt32(numberTmp);

            if (canSetCommand == 1)
            {
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.value =" + money + "; return 1;");
                Thread.Sleep(200);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('change', {     bubbles: true })); return 1;");
                Thread.Sleep(500);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('blur', {     bubbles: true })); return 1;");
                Thread.Sleep(500);
                chromeDriver.ExecuteScript("document.querySelector('.button.btnDown').click(); return 1;");
                isJustCommanded = 1;
            }

        }

    }
}