using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WeFinex
{
    public class Rule1_1 
    {
        static ChromeDriver chromeDriver;
        static string[] block0 = new string[21];
        static string[] block1 = new string[21];
        static string[] block2 = new string[21];
        static string[] block3 = new string[21];
        static string[] block4 = new string[21];
        static string[] block5 = new string[21];
        static int currentCandle;

        int totalCommand = 0;
        int lostChain = 0;
        int maxLostChain = 0;
        int lost0 = 0;
        int lost1 = 0;
        int lost2 = 0;
        int lost3 = 0;
        int lost4 = 0;
        int lost5 = 0;
        int lost6 = 0;
        int lost7 = 0;
        int lost8 = 0;
        int lost9 = 0;
        int lost10 = 0;

        // cua rieng luat nay

        static float[] commandMoney = new float[10];
        static int setMaxLost = 10;

        int setCommanded = 0;
        int setcolored = 0;


        static float buy_binance = 0;
        static float sell_binance = 0;


        static float buy_huobi = 0;
        static float sell_huobi = 0;


        static float buy_okex = 0;
        static float sell_okex = 0;

        static float binance_trades_history = 0;
        static int total_2_san = 0;

        int totalLost = 0;
        int totalWin = 0;

        public Rule1_1()
        {

        }

        public int[] getStaticValue(ChromeDriver chromeDriver1,
            string[] tmp_block0,
            string[] tmp_block1,
            string[] tmp_block2,
            string[] tmp_block3,
            string[] tmp_block4,
            string[] tmp_block5,
            int tmp_currentCandle,
            int[] tmp_resultArrayRule1
            
            )
        {
            chromeDriver = chromeDriver1;
            block0 = tmp_block0;
            block1 = tmp_block1;
            block2 = tmp_block2;
            block3 = tmp_block3;
            block4 = tmp_block4;
            block5 = tmp_block5;
            currentCandle = tmp_currentCandle;
           

            totalCommand = tmp_resultArrayRule1[0];
            lostChain = tmp_resultArrayRule1[1];
            maxLostChain = tmp_resultArrayRule1[2];
            lost0 = tmp_resultArrayRule1[3];
            lost1 = tmp_resultArrayRule1[4];
            lost2 = tmp_resultArrayRule1[5];
            lost3 = tmp_resultArrayRule1[6];
            lost4 = tmp_resultArrayRule1[7];
            lost5 = tmp_resultArrayRule1[8];
            lost6 = tmp_resultArrayRule1[9];
            lost7 = tmp_resultArrayRule1[10];
            lost8 = tmp_resultArrayRule1[11];
            lost9 = tmp_resultArrayRule1[12];
            lost10 = tmp_resultArrayRule1[13];

            setCommanded =  tmp_resultArrayRule1[14];
            setcolored = tmp_resultArrayRule1[15];

            totalLost = tmp_resultArrayRule1[16];
            totalWin = tmp_resultArrayRule1[17];
            total_2_san = tmp_resultArrayRule1[18];



            createCommand();

            ruleLogic();

            int[] resultArrayRule1 = new int[20];

            resultArrayRule1[0] = totalCommand;
            resultArrayRule1[1] = lostChain;
            resultArrayRule1[2] = maxLostChain;
            resultArrayRule1[3] = lost0;
            resultArrayRule1[4] = lost1;
            resultArrayRule1[5] = lost2;
            resultArrayRule1[6] = lost3;
            resultArrayRule1[7] = lost4;
            resultArrayRule1[8] = lost5;
            resultArrayRule1[9] = lost6;
            resultArrayRule1[10] = lost7;
            resultArrayRule1[11] = lost8;
            resultArrayRule1[12] = lost9;
            resultArrayRule1[13] = lost10;

            resultArrayRule1[14] = setCommanded;
            resultArrayRule1[15] = setcolored;

            resultArrayRule1[16] = totalLost;
            resultArrayRule1[17] = totalWin;
            resultArrayRule1[18] = total_2_san;


            return resultArrayRule1;
        }


        public void ruleLogic()
        {
            //   checkCandle();
            checkCandle2();
        }


        public void checkCandle2()
        {
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;
            int canSetCommand;
            string numberTmp;
            numberTmp = (string)js.ExecuteScript("var result; var canSetCommandTml = document.querySelector('.button.btnSuccess.colorDisable'); if (canSetCommandTml == null) {     result= 1; } else {     result = 0; } return result.toString();");
            canSetCommand = Convert.ToInt32(numberTmp);

            if (canSetCommand == 1)
            {
                int createLoop27 = 1;
                



                if (setCommanded == 1)
                {

                    int colorCheck;
                    if (block0[currentCandle].CompareTo("blue") == 0)
                    {
                        colorCheck = 1;
                    }
                    else
                    {
                        colorCheck = 0;
                    }

                    if (colorCheck == setcolored)
                    {
                        // win
                        totalWin++;
                        lostChain = 0;
                    }
                    else
                    {
                        totalLost++;
                    }

              //      Console.WriteLine(">>>>>>>>---------------->>>>>>>> *** colorCheck : " + colorCheck + " setcolored : " + setcolored);


                    setCommanded = 0;

                }
                // Console.WriteLine(">>>>>>>>---------------->>>>>>>> *** colorCheck : " + colorCheck + " setcolored : " + setcolored);



                while (createLoop27 < 3)
                {
                    var time27s = (string)js.ExecuteScript("getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent; return getCorrectTime;");
                    if ((time27s.CompareTo("2s") == 0))
                    {
                        getInfoBinance3();
                        getInfoHuobi2();
                        getInfoOkex();

                        bool binance = checkValue(buy_binance, sell_binance);
                        bool houbi = checkValue(buy_huobi, sell_huobi);
                     //   bool okex = checkValue(buy_okex, sell_okex);

                        //chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                        //setCommandBlue();
                       

                            if (binance && houbi)
                        {
                            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                            // 1 = blue
                            // 0 = red



                            if (buy_binance > sell_binance)
                            {
                                if (buy_huobi > sell_huobi)
                                {
                                    float spaceHuobi = buy_huobi - sell_huobi;
                                    float spaceBinance = buy_binance - sell_binance;
                                    float spaceOkex = buy_okex - sell_okex;
                                    if ((spaceHuobi >= 2) && (spaceBinance >= 2) && (spaceOkex >= 2))
                                    {
                                        setCommandBlue();
                                        setCommanded = 1;
                                        setcolored = 1;
                                    }

                                }

                            }
                            else
                            {
                                if (buy_huobi < sell_huobi)
                                {

                                    float spaceHuobi = sell_huobi - buy_huobi;
                                    float spaceBinance = sell_binance - buy_binance;
                                    float spaceOkex = sell_okex - buy_okex;
                                    if ((spaceHuobi >= 2) && (spaceBinance >= 2) && (spaceOkex >= 2))
                                    {
                                        setCommmandRed();
                                        setCommanded = 1;
                                        setcolored = 0;
                                    }

                                }

                            }
                        }


                        createLoop27 = 4;
                    }
                    else
                    {
                        Thread.Sleep(300);

                    }


                }
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
            }
        }

        public void checkCandle()
        {
            if ((currentCandle == 1) ||
                (currentCandle == 3) ||
                (currentCandle == 5) ||
                (currentCandle == 7) ||
                (currentCandle == 9) ||
                (currentCandle == 11) ||
                (currentCandle == 13) ||
               (currentCandle == 15) ||
               (currentCandle == 17) ||
               (currentCandle == 19))
            {
                // đây là cây vào lệnh
                int createLoop27 = 1;
                IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;



                if (setCommanded == 1)
                {

                    int colorCheck;
                    if (block0[currentCandle].CompareTo("blue") == 0)
                    {
                        colorCheck = 1;
                    }
                    else
                    {
                        colorCheck = 0;
                    }

                    if (colorCheck == setcolored)
                    {
                        // win
                        totalWin++;
                        lostChain = 0;
                    }
                    else
                    {
                        totalLost++;
                    }

                     Console.WriteLine(">>>>>>>>---------------->>>>>>>> *** colorCheck : " + colorCheck + " setcolored : " + setcolored);


                    setCommanded = 0;
                    
                }
                // Console.WriteLine(">>>>>>>>---------------->>>>>>>> *** colorCheck : " + colorCheck + " setcolored : " + setcolored);

               

                while (createLoop27 < 3)
                {
                    var time27s = (string)js.ExecuteScript("getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent; return getCorrectTime;");
                    if ((time27s.CompareTo("2s") == 0))
                    {
                        getInfoBinance3();
                        getInfoHuobi2();
                     //   getInfoOkex();

                        bool binance = checkValue(buy_binance, sell_binance);
                        bool houbi = checkValue(buy_huobi, sell_huobi);

                        //chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                        //setCommandBlue();


                        if (binance && houbi)
                        {
                            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                            // 1 = blue
                            // 0 = red



                            if (buy_binance > sell_binance)
                            {
                                if (buy_huobi > sell_huobi)
                                {
                                    float spaceHuobi = buy_huobi - sell_huobi;
                                    float spaceBinance = buy_binance - sell_binance;
                                    if ((spaceHuobi >= 2) && (spaceBinance >= 2))
                                    {
                                        setCommandBlue();
                                        setCommanded = 1;
                                        setcolored = 1;
                                    }

                                }

                            }
                            else
                            {
                                if (buy_huobi < sell_huobi)
                                {

                                    float spaceHuobi = sell_huobi - buy_huobi;
                                    float spaceBinance = sell_binance - buy_binance;
                                    if ((spaceHuobi >= 2) && (spaceBinance >= 2))
                                    {
                                        setCommmandRed();
                                        setCommanded = 1;
                                        setcolored = 0;
                                    }

                                }

                            }
                        }


                        createLoop27 = 4;
                    }
                    else
                    {
                        Thread.Sleep(300);
                        
                    }


                }
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
            }
        }


        public bool checkValue( float buy, float sell)
        {

            if( (buy < 1) && (sell > 1))
            {
                return true;
            }else if ((buy > 1 ) && (sell < 1))
            {
                return true;
            }else
            {
                return false;
            }

            
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


            Console.WriteLine("Binance *** Buy : " + buy_binance + " Sell : " + sell_binance);
        }

        static public void getInfoHuobi2()
        {
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[2]);
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;

      //      Console.WriteLine(chromeDriver.PageSource);

            string sellString = (string)js.ExecuteScript("var list = document.querySelector('.list.asks').querySelectorAll('.single-orderbook'); var sellTotal = 0; for(var i = 0 ; i < 16 ; i++){ var data = parseFloat(list[i].childNodes[2].textContent); sellTotal = sellTotal + data; } return sellTotal.toString(); ");
            float sellFloat = float.Parse(sellString);
            sell_huobi = sellFloat;

            string buyString = (string)js.ExecuteScript("var list = document.querySelector('.list.bids').querySelectorAll('.single-orderbook'); var sellTotal = 0; for(var i = 0 ; i < 16 ; i++){ var data = parseFloat(list[i].childNodes[2].textContent); sellTotal = sellTotal + data; } return sellTotal.toString();");
            float buyFloat = float.Parse(buyString);
            buy_huobi = buyFloat;


            Console.WriteLine("Huobi   *** Buy : " + buy_huobi + " Sell : " + sell_huobi);
        }


        static public void getInfoOkex()
        {
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[3]);
            IJavaScriptExecutor js = chromeDriver as IJavaScriptExecutor;

            //      Console.WriteLine(chromeDriver.PageSource);

            string sellString = (string)js.ExecuteScript("var list = document.querySelectorAll('.sell-item'); var buyTotal = 0; for(var i = 0 ; i < list.length ; i++){ var a = list[i]; var data = parseFloat(a.childNodes[1].textContent); buyTotal = buyTotal + data; } return buyTotal.toString();");
             float sellFloat = float.Parse(sellString);
            sell_okex = sellFloat;

            string buyString = (string)js.ExecuteScript("var list = document.querySelectorAll('.buy-item'); var buyTotal = 0; for(var i = 0 ; i < list.length ; i++){ var a = list[i]; var data = parseFloat(a.childNodes[1].textContent); buyTotal = buyTotal + data; } return buyTotal.toString();");
            float buyFloat = float.Parse(buyString);
            buy_okex = buyFloat;


            Console.WriteLine("Okex    *** Buy : " + buy_okex + " Sell : " + sell_okex);
        }


        public void setCommmandRed()
        {
            float moneyGo = commandMoney[lostChain];
            setCommandDown(moneyGo);
            totalCommand++;
            updateResultCommand();
            lostChain++;
        }

        public void setCommandBlue()
        {
            float moneyGo = commandMoney[lostChain];
            setCommandUp(moneyGo);
            totalCommand++;
            updateResultCommand();
            lostChain++;
        }



        public void createCommand()
        {
            float command1 = 10;
            float command2 = 20;
            float command3 = 40;
            float command4 = 80;
            float command5 = 170;
            float command6 = 350;
            float command7 = 0;
            float command8 = 0;
            float command9 = 0;
            float command10 = 0;


            commandMoney[0] = command1;
            commandMoney[1] = command2;
            commandMoney[2] = command3;
            commandMoney[3] = command4;
            commandMoney[4] = command5;
            commandMoney[5] = command6;
            commandMoney[6] = command7;
            commandMoney[7] = command8;
            commandMoney[8] = command9;
            commandMoney[9] = command10;
            

        }

        public void updateResultCommand()
        {
            
            if(lostChain == 0)
            {
                lost0++;
            }else if( lostChain == 1)
            {
                lost1++;
            }
            else if (lostChain == 2)
            {
                lost2++;
            }
            else if (lostChain == 3)
            {
                lost3++;
            }
            else if (lostChain == 4)
            {
                lost4++;
            }
            else if (lostChain == 5)
            {
                lost5++;
            }
            else if (lostChain == 6)
            {
                lost6++;
            }
            else if (lostChain == 7)
            {
                lost7++;
            }
            else if (lostChain == 8)
            {
                lost8++;
            }
            else if (lostChain == 9)
            {
                lost9++;
            }
            else if (lostChain == 10)
            {
                lost10++;
            }

            if(lostChain > maxLostChain)
            {
                maxLostChain = lostChain;
            }

            if (lostChain > setMaxLost)
            {
                lostChain = 0;
            }
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
                Thread.Sleep(100);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('change', {     bubbles: true })); return 1;");
                Thread.Sleep(100);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('blur', {     bubbles: true })); return 1;");
                Thread.Sleep(100);
                chromeDriver.ExecuteScript("document.querySelector('.button.btnSuccess').click(); return 1;");

                var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");

                Console.WriteLine("------>Time : " + show_time + " Set Command Up with " + money + "$");

                //string numberTmp1;
                //float currentMoney;
                //numberTmp1 = (string)js.ExecuteScript("var money = document.querySelector('.buttonBalance.d-flex.align-items-center').querySelector('.d-flex.flex-column.mr-lg-2.mr-2').querySelector('.d-flex.align-items-center').getElementsByTagName('span')[0].textContent; var lengthX = money.length; var moneytmp2= money.slice(1,lengthX); var moneyTmp = parseFloat(moneytmp2.replace(/,/g,'')); return moneyTmp.toString();");
                //currentMoney = float.Parse(numberTmp1);
                //chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001419460829' + '&text=[BOT_COMMAND] SET COMMAND - PP Tam Giac :    %0A [" + currentMoney + " $] Set Command Up with " + money + "$ %0A  ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");


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
                Thread.Sleep(100);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('change', {     bubbles: true })); return 1;");
                Thread.Sleep(100);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('blur', {     bubbles: true })); return 1;");
                Thread.Sleep(100);
                chromeDriver.ExecuteScript("document.querySelector('.button.btnDown').click(); return 1;");

               
                var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");

                Console.WriteLine("------>Time : " + show_time + " Set Command Down with " + money + "$");

                //string numberTmp1;
                //float currentMoney;
                //numberTmp1 = (string)js.ExecuteScript("var money = document.querySelector('.buttonBalance.d-flex.align-items-center').querySelector('.d-flex.flex-column.mr-lg-2.mr-2').querySelector('.d-flex.align-items-center').getElementsByTagName('span')[0].textContent; var lengthX = money.length; var moneytmp2= money.slice(1,lengthX); var moneyTmp = parseFloat(moneytmp2.replace(/,/g,'')); return moneyTmp.toString();");
                //currentMoney = float.Parse(numberTmp1);
                //chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001419460829' + '&text=[BOT_COMMAND] SET COMMAND - PP Tam Giac :    %0A [" + currentMoney + " $] Set Command Down with " + money + "$ %0A  ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");


            }

        }


    }
}
