using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WeFinex
{
    // PP 3 điểm nghịch 
    public class Rule9
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
        int checkLostChainTotal = 0;
        int checkNghich = 0;
        int checkSole = 0;

        int vaoLenhThuan = 0;
        int thuanGetCommandFistTime = 0;

        int vaoLenhNghich = 0;
        int nghichGetCommandFistTime = 0;

        int vaoLenhSole = 0;
        int soleGetCommandFistTime = 0;
        int baseSave = 0;
        int startFromBase = 0;





        public Rule9()
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

            checkLostChainTotal = tmp_resultArrayRule1[14];
            checkNghich = tmp_resultArrayRule1[15];
            checkSole = tmp_resultArrayRule1[16];

            vaoLenhThuan = tmp_resultArrayRule1[17];
            thuanGetCommandFistTime = tmp_resultArrayRule1[18];

            vaoLenhNghich = tmp_resultArrayRule1[19];
            nghichGetCommandFistTime = tmp_resultArrayRule1[20];

            vaoLenhSole = tmp_resultArrayRule1[21];
            soleGetCommandFistTime = tmp_resultArrayRule1[22];
            baseSave = tmp_resultArrayRule1[23];
            startFromBase = tmp_resultArrayRule1[24];




            //  createCommand();

            ruleLogic();
            

            int[] resultArrayRule1 = new int[30];

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

            resultArrayRule1[14] = checkLostChainTotal;
            resultArrayRule1[15] = checkNghich;
            resultArrayRule1[16] = checkSole;
            resultArrayRule1[17] = vaoLenhThuan;
            resultArrayRule1[18] = thuanGetCommandFistTime;
            resultArrayRule1[19] = vaoLenhNghich;
            resultArrayRule1[20] = nghichGetCommandFistTime;
            resultArrayRule1[21] = vaoLenhSole;
            resultArrayRule1[22] = soleGetCommandFistTime;
            resultArrayRule1[23] = baseSave;
            resultArrayRule1[24] = startFromBase;



            return resultArrayRule1;
        }


        public void ruleLogic()
        {

            checkCandle1();
            checkCandle3();
            checkCandle5();
            checkCandle7();
            checkCandleCommand();
            checkCandleResult();


        }


        public void checkCandle1()
        {
            // 1 = blue
            // 0 = red

            if (currentCandle == 1)
            {
                int colorCommand = checkColorCandle1();
                if (checkLostChainTotal > 3)
                {
                    Console.WriteLine(" da vao nen 1 ");
                    if (colorCommand == 1)
                    {
                        // ket qua  la blue
                        setCommandBlue();

                    }
                    else if (colorCommand == 0)
                    {
                        setCommmandRed();
                    }
                }
            }

        }

        public void checkCandle3()
        {
            // 1 = blue
            // 0 = red

            if (currentCandle == 3)
            {
                int colorCheck = 0;
                int colorCommand = checkColorCandle1();

                if (block0[currentCandle].CompareTo("blue") == 0)
                {
                    colorCheck = 1;
                }
                else
                {
                    colorCheck = 0;
                }

                if(colorCheck == colorCommand)
                {
                    // win
                    lostChain = 0;
                    checkLostChainTotal = 0;
                }
                else
                {
                    checkLostChainTotal++; 
                }


                if (checkLostChainTotal == 4)
                {
                    //  checkLostChainTotal = 4;

                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_INFO]  PP Xét 3 điểm nghịch :    %0A  Đã có 4 chuỗi thua liên tục!   ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }
            }

        }



        public void checkCandle5()
        {
            // 1 = blue
            // 0 = red

            if (currentCandle == 5)
            {
                
                int colorCommand = checkColorCandle5();
                if (checkLostChainTotal > 3)
                {
                    Console.WriteLine(" da vao nen 5 ");
                    if (colorCommand == 1)
                    {
                        // ket qua  la blue
                        setCommandBlue();

                    }
                    else if (colorCommand == 0)
                    {
                        setCommmandRed();
                    }
                }
            }

        }

        public void checkCandle7()
        {
            // 1 = blue
            // 0 = red

            if (currentCandle == 7)
            {
                int colorCheck;
                int colorCommand = checkColorCandle5();

                if (block0[currentCandle].CompareTo("blue") == 0)
                {
                    colorCheck = 1;
                }
                else
                {
                    colorCheck = 0;
                }

                if (colorCheck == colorCommand)
                {
                    // win
                    lostChain = 0;
                    checkLostChainTotal = 0;
                }
                else
                {
                    checkLostChainTotal++;
                }

                if (checkLostChainTotal == 4)
                {
                    //  checkLostChainTotal = 4;

                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_INFO]  PP Xét 3 điểm nghịch  :    %0A  Đã có 4 chuỗi thua liên tục!   ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }
            }

        }



        public void checkCandleCommand()
        {
            if ((currentCandle == 9) ||
                (currentCandle == 13) ||
                (currentCandle == 17))
            {
                int colorCommand = checkColorCandleBlock0(currentCandle);
                if (checkLostChainTotal >3 )
                {
                    if (colorCommand == 1)
                    {
                        // ket qua  la blue
                        setCommandBlue();

                    }
                    else if (colorCommand == 0)
                    {
                        setCommmandRed();
                    }
                }
            }
        }

        public void checkCandleResult()
        {
            if ((currentCandle == 11) ||
               (currentCandle == 15) ||
               (currentCandle == 19))
            {
                int colorCheck;
                int colorCommand = checkColorCandleBlock0(currentCandle-2);

                if (block0[currentCandle].CompareTo("blue") == 0)
                {
                    colorCheck = 1;
                }
                else
                {
                    colorCheck = 0;
                }

                if (colorCheck == colorCommand)
                {
                    // win
                    lostChain = 0;
                    checkLostChainTotal = 0;
                }
                else
                {
                    checkLostChainTotal++;
                }

                if (checkLostChainTotal == 4)
                {
                    //  checkLostChainTotal = 4;

                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_INFO]  PP Xét 3 điểm nghịch :    %0A  Đã có 4 chuỗi thua liên tục!   ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }
            }
        }







        public int checkColorCandle5()
        {
            // 1 = blue
            // 0 = red

            int count_red = 0;
            int count_blue = 0;
            int columResult = 2;

            int fistCandle = 3; // block 0
            int twoCandle = 18;
            int thirtCandle = 20; 

            int[] arrayCheck = {  twoCandle, thirtCandle };
            // 1 = blue
            // 0 = red


            // check rieng cho thang 3
            if (block0[fistCandle].CompareTo("blue") == 0)
            {
                count_blue++;
            }
            else
            {
                count_red++;
            }

            for (int i = 0; i < arrayCheck.Length; i++)
            {
                int j = arrayCheck[i];
                if (block1[j].CompareTo("blue") == 0)
                {
                    count_blue++;
                }
                else
                {
                    count_red++;
                }
            }

            if (count_blue == 3)
            {
                columResult = 0;
            }
            else
            if (count_red == 3)
            {
                columResult = 1;
            }
            else
            if (count_blue > count_red)
            {
                columResult = 1;
            }
            else if (count_red > count_blue)
            {
                columResult = 0;
            }

            return columResult;

        }


        public int checkColorCandle1()
        {
            // 1 = blue
            // 0 = red

            int count_red = 0;
            int count_blue = 0;
            int columResult = 2;

            int fistCandle = 14;
            int twoCandle = 16;
            int thirtCandle = 19;

            int[] arrayCheck = { fistCandle, twoCandle, thirtCandle };
            // 1 = blue
            // 0 = red

            for (int i = 0; i < arrayCheck.Length; i++)
            {
                int j = arrayCheck[i];
                if (block1[j].CompareTo("blue") == 0)
                {
                    count_blue++;
                }
                else
                {
                    count_red++;
                }
            }


            if (count_blue == 3)
            {
                columResult = 0;
            }
            else
            if (count_red == 3)
            {
                columResult = 1;
            }
            else
            if (count_blue > count_red)
            {
                columResult = 1;
            }
            else if (count_red > count_blue)
            {
                columResult = 0;
            }

            return columResult;

        }

        public int checkColorCandleBlock0(int candle)
        {
            // 1 = blue
            // 0 = red

            int count_red = 0;
            int count_blue = 0;
            int columResult = 2;

            int fistCandle = candle - 7;
            int twoCandle = candle - 5;
            int thirtCandle = candle - 2;

            int[] arrayCheck = { fistCandle, twoCandle,thirtCandle };
            // 1 = blue
            // 0 = red

            for (int i = 0; i < arrayCheck.Length; i++)
            {
                int j = arrayCheck[i];
                if (block0[j].CompareTo("blue") == 0)
                {
                    count_blue++;
                }
                else
                {
                    count_red++;
                }
            }


            if (count_blue == 3)
            {
                columResult = 0;
            }
            else
             if (count_red == 3)
            {
                columResult = 1;
            }
            else
             if (count_blue > count_red)
            {
                columResult = 1;
            }
            else if (count_red > count_blue)
            {
                columResult = 0;
            }

            return columResult;

        }






        public void setCommmandRed()
        {
            float moneyGo = 0;
           
                createCommand();
                moneyGo = commandMoney[lostChain];
            


            //  float moneyGo = commandMoney[lostChain] * lostDouble;
            setCommandDown(moneyGo);
            totalCommand++;
            updateResultCommand();
            lostChain++;

        }

        public void setCommandBlue()
        {

            float moneyGo = 0;
         
                createCommand();
                moneyGo = commandMoney[lostChain];
      


            //  float moneyGo = commandMoney[lostChain] * lostDouble;
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

            if (lostChain == 0)
            {
                lost0++;
            }
            else if (lostChain == 1)
            {
                lost1++;
                lost0--;
            }
            else if (lostChain == 2)
            {
                lost2++;
                lost1--;
            }
            else if (lostChain == 3)
            {
                lost3++;
                lost2--;
            }
            else if (lostChain == 4)
            {
                lost4++;
                lost3--;
            }
            else if (lostChain == 5)
            {
                lost5++;
                lost4--;
            }
            else if (lostChain == 6)
            {
                lost6++;
                lost5--;
            }
            else if (lostChain == 7)
            {
                lost7++;
                lost6--;
            }
            else if (lostChain == 8)
            {
                lost8++;
                lost7--;
            }
            else if (lostChain == 9)
            {
                lost9++;
                lost8--;
            }
            else if (lostChain == 10)
            {
                lost10++;
                lost9--;
            }

            if (lostChain > maxLostChain)
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
                Thread.Sleep(200);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('change', {     bubbles: true })); return 1;");
                Thread.Sleep(500);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('blur', {     bubbles: true })); return 1;");
                Thread.Sleep(500);
                chromeDriver.ExecuteScript("document.querySelector('.button.btnSuccess').click(); return 1;");

                var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");

                Console.WriteLine("------>Time : " + show_time + " Set Command Up with " + money + "$");

                //string numberTmp1;
                //float currentMoney;
                //numberTmp1 = (string)js.ExecuteScript("var money = document.querySelector('.buttonBalance.d-flex.align-items-center').querySelector('.d-flex.flex-column.mr-lg-2.mr-2').querySelector('.d-flex.align-items-center').getElementsByTagName('span')[0].textContent; var lengthX = money.length; var moneytmp2= money.slice(1,lengthX); var moneyTmp = parseFloat(moneytmp2.replace(/,/g,'')); return moneyTmp.toString();");
                //currentMoney = float.Parse(numberTmp1);
                //chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_COMMAND] SET COMMAND - PP căn theo nến 6 :    %0A [" + currentMoney + " $] Set Command Up with " + money + "$ %0A  ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");

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


                var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");

                Console.WriteLine("------>Time : " + show_time + " Set Command Down with " + money + "$");

                //string numberTmp1;
                //float currentMoney;
                //numberTmp1 = (string)js.ExecuteScript("var money = document.querySelector('.buttonBalance.d-flex.align-items-center').querySelector('.d-flex.flex-column.mr-lg-2.mr-2').querySelector('.d-flex.align-items-center').getElementsByTagName('span')[0].textContent; var lengthX = money.length; var moneytmp2= money.slice(1,lengthX); var moneyTmp = parseFloat(moneytmp2.replace(/,/g,'')); return moneyTmp.toString();");
                //currentMoney = float.Parse(numberTmp1);
                //chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_COMMAND] SET COMMAND - PP Căn theo nến 6:    %0A [" + currentMoney + " $] Set Command Down with " + money + "$ %0A  ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");


            }

        }


    }
}
