using System;
using System.Net.NetworkInformation;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WeFinex;

namespace Wefinex
{
    class BaseRun
    {
        static ChromeDriver chromeDriver;

        static string[] block0 = new string[21];
        static string[] block1 = new string[21];
        static string[] block2 = new string[21];
        static string[] block3 = new string[21];
        static string[] block4 = new string[21];
        static string[] block5 = new string[21];

        static float minMoney = 100;
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



        static void Main(string[] args)
        {
            createChomeDriver();

            checkLogin();

            createBlockFirstTime();

            waitFirstTime();

            runAll();

        }

      

        static void runAll()
        {
            
            getCurrentCandle();
            int createLoop = 1;

            while (createLoop < 3)
            {
                updateCandle28_26();
                updateCandle25_23();
                refresh();
                checkMinMonney();
                // run 1
                runRule1();
               
            }
            

        }



        static void runRule1()
        {
            Rule1 rule1 = new Rule1();
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

        }

        static void printCurrentCandle()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");


            // print rule 1

            Console.WriteLine("--->Result: " + "lost0: " + (rule1_lost0 - rule1_lost2) + " - lost1: " + (rule1_lost1 - rule1_lost2) + " - lost2: " + (rule1_lost2 - rule1_lost3));
            Console.WriteLine("--->Result: " + "lost3: " + (rule1_lost3 - rule1_lost4) + " - lost4: " + (rule1_lost4 - rule1_lost5) + " - lost5: " + (rule1_lost5-rule1_lost6));
            Console.WriteLine("--->Result: " + "lost6: " + (rule1_lost6 - rule1_lost7) + " - lost7: " + (rule1_lost7- rule1_lost8) + " - lost8: " + rule1_lost8);
            Console.WriteLine("--->Time " + show_time + " :  currentCandle : " + currentCandle + " - " + block0[currentCandle] + " **** totalCommand:  " + rule1_totalCommand + " - maxLostChain: "+ rule1_maxLostChain + " - current lostChain: " + rule1_lostChain);

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
            else if( (currentCandle < 20) && (currentCandle > 0))
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
            if((currentCandle%10) == 0)
            {
                chromeDriver.Navigate().Refresh();
                chromeDriver.Manage().Window.Size = new System.Drawing.Size(1366, 768);

                Thread.Sleep(5000);
                chromeDriver.ExecuteScript("document.querySelector('.nav.nav-pills.tab-last-result').getElementsByTagName('li')[1].getElementsByTagName('a')[0].click();");
            }
        }

        static void updateCandle25_23()
        {
            if(isJustUpdate == 0)
            {
                int createLoop25 = 1;
                IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;

                while (createLoop25 < 3)
                {
                    var time25s = (string)js.ExecuteScript("getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent; return getCorrectTime;");
                    if ((time25s.CompareTo("25s") == 0) ||
                        (time25s.CompareTo("24s") == 0) ||
                        (time25s.CompareTo("23s") == 0))
                    {
                        updateCandleBase();
                        createLoop25 = 4;
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
                if ((time27s.CompareTo("28s") == 0) ||
                    (time27s.CompareTo("27s") == 0))
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
            Console.WriteLine(" ");
            Console.WriteLine("Block 5: [{0}]", string.Join(", ", block5));
            Console.WriteLine("Block 4: [{0}]", string.Join(", ", block4));
            Console.WriteLine("Block 3: [{0}]", string.Join(", ", block3));
            Console.WriteLine("Block 2: [{0}]", string.Join(", ", block2));
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

            if(countCheckLostConnect > 8)
            {
                Console.WriteLine("Stop because lost internet !!!");

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

        static void checkMinMonney()
        {

            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            string numberTmp;
            numberTmp = (string)js.ExecuteScript("var money = document.querySelector('.buttonBalance.d-flex.align-items-center').querySelector('.d-flex.flex-column.mr-lg-2.mr-2').querySelector('.d-flex.align-items-center').getElementsByTagName('span')[0].textContent; var lengthX = money.length; var moneytmp2= money.slice(1,lengthX); var moneyTmp = parseFloat(moneytmp2.replace(/,/g,'')); return moneyTmp.toString();");
            currentMoney = float.Parse(numberTmp);

            if( currentMoney < minMoney)
            {
                Console.WriteLine("currentMoney : " + currentMoney);
                Console.WriteLine("Stop because currentMoney less minMoney !!!");
                Environment.Exit(0);
            }

        }

        static void createChomeDriver()
        {
            ChromeOptions option = new ChromeOptions();
          

            //  string profile = "@/Users/huynhduc96/Library/Application\\ Support/Google/Chrome/Default";
            // string profile1 = @"/Users/huynhduc96/Library/Application Support/Google/Chrome/Default";
            string profile2 = "/Users/huynhduc96/Desktop/test/";

            option.AddArgument("user-data-dir=" + profile2);

            chromeDriver = new ChromeDriver(option);
            chromeDriver.Navigate().GoToUrl("https://wefinex.net/");
            chromeDriver.Manage().Window.Size = new System.Drawing.Size(1366, 768);

            Thread.Sleep(5000);
            chromeDriver.ExecuteScript("document.querySelector('.nav.nav-pills.tab-last-result').getElementsByTagName('li')[1].getElementsByTagName('a')[0].click();");

        }

        static void checkLogin()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            var confirmLogin = (string)js.ExecuteScript("var confirm = document.querySelector('.profitPercent.color-light-blue.ml-2.mb-2.d-inline-block').textContent; return confirm;");

            Console.WriteLine(confirmLogin);

            string checkString = "95%";
            

            if(checkString.CompareTo(confirmLogin) == 0)
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


                    if((currentColorTmp.CompareTo("#31BAA0") == 0) ||
                        (currentColorTmp.CompareTo("rgb(49,186,160)") == 0) ||
                        (currentColorTmp.CompareTo("rgb(74,211,185)") == 0) ||
                        (currentColorTmp.CompareTo("#31baa0") == 0) )
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

            for(int i = lengthArray; i > 0; i--)
            {
                string currentColor;
                string currentColorTmp;
                currentColorTmp = (string)js.ExecuteScript("var last = " + i+ "; var allListCraw2 = document.querySelector('.highcharts-series.highcharts-series-1.highcharts-column-series.highcharts-color-0.highcharts-tracker'); var colorTmp2; var colorX = allListCraw2.childNodes[last].getAttribute('fill');  return colorX;");

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


                if(block < 2)
                {
                    if(inputCurrentCandle == 1)
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
                    }else if(inputCurrentCandle < 21 && inputCurrentCandle > 1)
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

            if(canSetCommand == 1)
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