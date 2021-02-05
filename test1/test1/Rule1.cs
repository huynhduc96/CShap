using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WeFinex
{
    public class Rule1
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
        static int setMaxLost = 6;

        int colum1Result = 2;
        int colum2Result = 2;
        int alreadySetCommand7 = 0;
        int alreadySetCommand9 = 0;
        
       


        public Rule1()
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

            colum1Result =  tmp_resultArrayRule1[14];
            colum2Result = tmp_resultArrayRule1[15];
            alreadySetCommand7 = tmp_resultArrayRule1[16];
            alreadySetCommand9 = tmp_resultArrayRule1[17];




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

            resultArrayRule1[14] = colum1Result;
            resultArrayRule1[15] = colum2Result;
            resultArrayRule1[16] = alreadySetCommand7;
            resultArrayRule1[17] = alreadySetCommand9;
            


            return resultArrayRule1;
        }


        public void ruleLogic()
        {
            checkCandle7();
            checkCandle9();
            checkCandle11();

        }


        public void checkCandle7()
        {
            if(currentCandle == 7)
            {

           

            // check result colum1
            int[] arrayCheck1 = { 1, 2, 3 };
            colum1Result = checkColumBlock0(arrayCheck1);


            // check result colum2

            if (colum1Result == 1)
            {
                // ket qua hang 1 la blue

                if((block0[5].CompareTo("blue") == 0) || (block0[7].CompareTo("blue") == 0))
                {

                    checkAndSetCommandColum2();


                }
            }else if(colum1Result == 0)
            {
                // ket qua hang 1 la red
                if ((block0[5].CompareTo("red") == 0) || (block0[7].CompareTo("red") == 0))
                {

                    checkAndSetCommandColum2();
                }

            }

            }

        }

        public void checkCandle9() {
            
            if ((currentCandle == 9) && (alreadySetCommand7== 1))
            {
                Console.WriteLine("check in currentCandle 9 ");
         
                if (colum2Result == 0)
                {
                    // lenh 7 da vao la lenh do 
                    if(block0[9].CompareTo("red") == 0)
                    {
                        // da an lenh
                         
                         colum1Result = 2;
                         colum2Result = 2;
                         alreadySetCommand7 = 0;
                         alreadySetCommand9 = 0;
                         lostChain = 0;
                    }
                    else
                    {
                        // da thua lenh 7
                        
                       
                        float moneyGo = commandMoney[lostChain];
                        setCommandDown(moneyGo);
                        alreadySetCommand9 = 1;
                        totalCommand++;
                        updateResultCommand();
                        lostChain++;
                    }
                }else if(colum2Result == 1)
                {
                    // lenh 7 da vao la lenh xanh

                    if (block0[9].CompareTo("red") == 0)
                    {
                        // da thua lenh 7
                        
                       
                        float moneyGo = commandMoney[lostChain];
                        setCommandUp(moneyGo);
                        alreadySetCommand9 = 1;
                        totalCommand++;
                        updateResultCommand();
                        lostChain++;
                    }
                    else
                    {
                        // da an lenh
                       
                        colum1Result = 2;
                        colum2Result = 2;
                        alreadySetCommand7 = 0;
                        alreadySetCommand9 = 0;
                        lostChain = 0;

                    }
                }
                

            }
        }

        public void checkCandle11()
        {
           
            if ((currentCandle == 11) && (alreadySetCommand9 == 1))
            {


                if (colum2Result == 0)
                {
                    // lenh 9 da vao la lenh do 
                    if (block0[11].CompareTo("red") == 0)
                    {
                        // da an lenh

                        colum1Result = 2;
                        colum2Result = 2;
                        alreadySetCommand7 = 0;
                        alreadySetCommand9 = 0;
                        lostChain = 0;
                        
                    }
                    else
                    {
                        // da thua lenh 9
                        colum1Result = 2;
                        colum2Result = 2;
                        alreadySetCommand7 = 0;
                        alreadySetCommand9 = 0;
                    
                        
                    }
                }
                else if (colum2Result == 1)
                {
                    // lenh 9 da vao la lenh xanh

                    if (block0[11].CompareTo("red") == 0)
                    {
                        // da thua lenh 7
                        colum1Result = 2;
                        colum2Result = 2;
                        alreadySetCommand7 = 0;
                        alreadySetCommand9 = 0;
                     
                        
                    }
                    else
                    {
                        // da an lenh
                        colum1Result = 2;
                        colum2Result = 2;
                        alreadySetCommand7 = 0;
                        alreadySetCommand9 = 0;
                        lostChain = 0;

                    }
                }


                

            }
        }


            public void checkAndSetCommandColum2()
        {
            int[] arrayCheck2 = { 5, 6, 7 };
            colum2Result = checkColumBlock0(arrayCheck2);

            if (colum2Result == 1)
            {
                
                float moneyGo = commandMoney[lostChain];
                setCommandUp(moneyGo);
                totalCommand++;
                updateResultCommand();
                lostChain++;

                alreadySetCommand7 = 1;
                
            }
            else if (colum2Result == 0)
            {
                
                float moneyGo = commandMoney[lostChain];
                setCommandDown(moneyGo);
                totalCommand++;
                updateResultCommand();
                lostChain++;

                alreadySetCommand7 = 1;
                
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


        public void createCommand()
        {
            float command1 = 5;
            float command2 = 10;
            float command3 = 20;
            float command4 = 40;
            float command5 = 80;
            float command6 = 170;
            float command7 = 350;
            float command8 = 350;
            float command9 = 350;
            float command10 = 350;
            

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
