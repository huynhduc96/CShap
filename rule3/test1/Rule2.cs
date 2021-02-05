using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WeFinex
{
    public class Rule2
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
        int lostChainSignal = 0;

        
       


        public Rule2()
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

            lostChainSignal = tmp_resultArrayRule1[14];




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

            resultArrayRule1[14] = lostChainSignal;



            return resultArrayRule1;
        }


        public void ruleLogic()
        {
            checkCandle1();
            checkCandle3();
            checkCandle5();
            checkCandle7();
            checkCandle9();
            checkCandle11();
            checkCandle13();
            checkCandle15();
            checkCandle17();
            checkCandle19();
          

        }


        public void checkCandle1()
        {
            if (currentCandle == 1)
            {
                int columResult;

                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 17, 18, 19 };
                    columResult = checkColumBlock1(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue

                        if(block0[1].CompareTo("blue") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommandBlue();
                        }


                        

                    }
                    else
                    {
                        // ket qua hang 5 la red

                        if (block0[1].CompareTo("red") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommmandRed();
                        }
                        
                    }
                }


            }
        }


        public void checkCandle3()
        {
            if (currentCandle == 3)
            {
                int columResult;
                // check result colum5
                int[] arrayCheck1 = { 17, 18, 19 };
                columResult = checkColumBlock1(arrayCheck1);


                if (columResult == 1)
                {
                    // ket qua hang 5 block 1 la blue

                    if ((block0[1].CompareTo("blue") == 0) || (block0[3].CompareTo("blue") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[1].CompareTo("red") == 0) && (block0[3].CompareTo("red") == 0))
                    {
                        lostChainSignal++;
                    }

                }
                else
                {
                    // ket qua hang 5 block 1 la red
                    if ((block0[1].CompareTo("red") == 0) || (block0[3].CompareTo("red") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[1].CompareTo("blue") == 0) && (block0[3].CompareTo("blue") == 0))
                    {
                        lostChainSignal++;
                    }

                }

                if (lostChainSignal == 4)
                {
                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001486990896' + '&text=[BOT_Signal] PP Liên hoàn 1 cột :    %0A Đã thua 3 chuỗi lệnh liên tiếp %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }


                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 1, 2, 3 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue
                        setCommandBlue();

                    }
                    else
                    {
                        setCommmandRed();
                    }
                }


            }
        }

        public void checkCandle5()
        {
            if (currentCandle == 5)
            {
                int columResult;

                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 1, 2, 3 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue

                        if (block0[5].CompareTo("blue") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommandBlue();
                        }




                    }
                    else
                    {
                        // ket qua hang 5 la red

                        if (block0[5].CompareTo("red") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommmandRed();
                        }

                    }
                }


            }
        }

        public void checkCandle7()
        {
            if (currentCandle == 7)
            {
                int columResult;
                // check result colum5
                int[] arrayCheck1 = { 1, 2, 3 };
                columResult = checkColumBlock0(arrayCheck1);


                if (columResult == 1)
                {
                    // ket qua hang 5 block 1 la blue

                    if ((block0[5].CompareTo("blue") == 0) || (block0[7].CompareTo("blue") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[5].CompareTo("red") == 0) && (block0[7].CompareTo("red") == 0))
                    {
                        lostChainSignal++;
                    }

                }
                else
                {
                    // ket qua hang 5 block 1 la red
                    if ((block0[5].CompareTo("red") == 0) || (block0[7].CompareTo("red") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[5].CompareTo("blue") == 0) && (block0[7].CompareTo("blue") == 0))
                    {
                        lostChainSignal++;
                    }

                }

                if (lostChainSignal == 4)
                {
                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001486990896' + '&text=[BOT_Signal] PP Liên hoàn 1 cột :    %0A Đã thua 3 chuỗi lệnh liên tiếp %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }


                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 5, 6, 7 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue
                        setCommandBlue();

                    }
                    else
                    {
                        setCommmandRed();
                    }
                }


            }
        }

        public void checkCandle9()
        {
            if (currentCandle == 9)
            {
                int columResult;

                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 5, 6, 7 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue

                        if (block0[9].CompareTo("blue") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommandBlue();
                        }




                    }
                    else
                    {
                        // ket qua hang 5 la red

                        if (block0[9].CompareTo("red") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommmandRed();
                        }

                    }
                }


            }
        }

        public void checkCandle11()
        {
            if (currentCandle == 11)
            {
                int columResult;
                // check result colum5
                int[] arrayCheck1 = { 5, 6, 7 };
                columResult = checkColumBlock0(arrayCheck1);


                if (columResult == 1)
                {
                    // ket qua hang 5 block 1 la blue

                    if ((block0[9].CompareTo("blue") == 0) || (block0[11].CompareTo("blue") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[9].CompareTo("red") == 0) && (block0[11].CompareTo("red") == 0))
                    {
                        lostChainSignal++;
                    }

                }
                else
                {
                    // ket qua hang 5 block 1 la red
                    if ((block0[9].CompareTo("red") == 0) || (block0[11].CompareTo("red") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[9].CompareTo("blue") == 0) && (block0[11].CompareTo("blue") == 0))
                    {
                        lostChainSignal++;
                    }

                }

                if (lostChainSignal == 4)
                {
                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001486990896' + '&text=[BOT_Signal] PP Liên hoàn 1 cột :    %0A Đã thua 3 chuỗi lệnh liên tiếp %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }


                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 9, 10, 11 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue
                        setCommandBlue();

                    }
                    else
                    {
                        setCommmandRed();
                    }
                }


            }
        }

        public void checkCandle13()
        {
            if (currentCandle == 13)
            {
                int columResult;

                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 9, 10, 11 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue

                        if (block0[13].CompareTo("blue") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommandBlue();
                        }




                    }
                    else
                    {
                        // ket qua hang 5 la red

                        if (block0[13].CompareTo("red") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommmandRed();
                        }

                    }
                }


            }
        }

        public void checkCandle15()
        {
            if (currentCandle == 15)
            {
                int columResult;
                // check result colum5
                int[] arrayCheck1 = { 9, 10, 11 };
                columResult = checkColumBlock0(arrayCheck1);


                if (columResult == 1)
                {
                    // ket qua hang 5 block 1 la blue

                    if ((block0[13].CompareTo("blue") == 0) || (block0[15].CompareTo("blue") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[13].CompareTo("red") == 0) && (block0[15].CompareTo("red") == 0))
                    {
                        lostChainSignal++;
                    }

                }
                else
                {
                    // ket qua hang 5 block 1 la red
                    if ((block0[13].CompareTo("red") == 0) || (block0[15].CompareTo("red") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[13].CompareTo("blue") == 0) && (block0[15].CompareTo("blue") == 0))
                    {
                        lostChainSignal++;
                    }

                }

                if (lostChainSignal == 4)
                {
                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001486990896' + '&text=[BOT_Signal] PP Liên hoàn 1 cột :    %0A Đã thua 3 chuỗi lệnh liên tiếp %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }


                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 13, 14, 15 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue
                        setCommandBlue();

                    }
                    else
                    {
                        setCommmandRed();
                    }
                }


            }
        }

        public void checkCandle17()
        {
            if (currentCandle == 17)
            {
                int columResult;

                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 13, 14, 15 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue

                        if (block0[17].CompareTo("blue") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommandBlue();
                        }




                    }
                    else
                    {
                        // ket qua hang 5 la red

                        if (block0[17].CompareTo("red") == 0)
                        {
                            lostChainSignal = 0;
                            lostChain = 0;
                        }
                        else
                        {
                            setCommmandRed();
                        }

                    }
                }


            }
        }

        public void checkCandle19()
        {
            if (currentCandle == 19)
            {
                int columResult;
                // check result colum4
                int[] arrayCheck1 = { 13, 14, 15 };
                columResult = checkColumBlock0(arrayCheck1);

                if(columResult == 1)
                {
                    // ket qua hang 4 block 1 la blue

                    if((block0[17].CompareTo("blue") == 0) || (block0[19].CompareTo("blue") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[17].CompareTo("red") == 0) && (block0[19].CompareTo("red") == 0))
                    {
                        lostChainSignal++;
                    }

                }
                else
                {
                    // ket qua hang 4 block 1 la red
                    if ((block0[17].CompareTo("red") == 0) || (block0[19].CompareTo("red") == 0))
                    {
                        lostChainSignal = 0;
                        lostChain = 0;
                    }

                    if ((block0[17].CompareTo("blue") == 0) && (block0[19].CompareTo("blue") == 0))
                    {
                        lostChainSignal++;
                    }

                }

                if (lostChainSignal == 4)
                {
                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001486990896' + '&text=[BOT_Signal] PP Liên hoàn 1 cột :    %0A Đã thua 3 chuỗi lệnh liên tiếp %0A Check ngay ! ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }


                if (lostChainSignal >= 4)
                {
                    int[] arrayCheck2 = { 17, 18, 19 };
                    columResult = checkColumBlock0(arrayCheck2);


                    if (columResult == 1)
                    {
                        // ket qua hang 5 la blue
                        setCommandBlue();

                    }
                    else
                    {
                        setCommmandRed();
                    }
                }

                
            }
        }

      



        public int checkColumBlock0(int[] arrayCheck)
        {
            int count_red = 0;
            int count_blue = 0;
            int columResult = 2;
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

            if (count_red == 3)
            {
                columResult = 1;
            }
            else if (count_blue == 3)
            {
                columResult = 0;
            }
            else if (count_blue > count_red)
            {
                columResult = 1;
            }
            else if (count_red > count_blue)
            {
                columResult = 0;
            }

            return columResult;

        }


        public int checkColumBlock1(int[] arrayCheck)
        {
            int count_red = 0;
            int count_blue = 0;
            int columResult = 2;
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

            if (count_red == 3)
            {
                columResult = 1;
            }
            else if (count_blue == 3)
            {
                columResult = 0;
            }
            else if (count_blue > count_red)
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
            float command5 = 0;
            float command6 = 0;
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
                Thread.Sleep(200);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('change', {     bubbles: true })); return 1;");
                Thread.Sleep(500);
                chromeDriver.ExecuteScript("var input = document.getElementById('InputNumber'); input.dispatchEvent(new Event('blur', {     bubbles: true })); return 1;");
                Thread.Sleep(500);
                chromeDriver.ExecuteScript("document.querySelector('.button.btnSuccess').click(); return 1;");

                var show_time = (string)js.ExecuteScript("var time_string = (new Date()).getHours().toString().padStart(2, 0) + ':' + (new Date()).getMinutes().toString().padStart(2, 0) + ':' + (new Date()).getSeconds().toString().padStart(2, 0);  var getCorrectTime = document.querySelector('.font-18.mb-0.font-weight-700').textContent;  var show_time = time_string + ' - in ' + getCorrectTime; return show_time;");

                Console.WriteLine("------>Time : " + show_time + " Set Command Up with " + money + "$");

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



            }

        }


    }
}
