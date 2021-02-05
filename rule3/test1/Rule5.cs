using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WeFinex
{
    // PP check theo cặp
    public class Rule5
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
        int checkThuan = 0;
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





        public Rule5()
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

            checkThuan = tmp_resultArrayRule1[14];
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

            resultArrayRule1[14] = checkThuan;
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


           
            

            if (currentCandle % 2 != 0)
            {
                checkThuanFuction();
                checkNghichFunction();
                checkSoleCommand();

                vaoLenhThuanCommand();
                vaoLenhNghichCommand();
                vaoLenhSoleCommand();

            }
        }

        public void vaoLenhSoleCommand()
        {
            if (vaoLenhSole == 1)
            {
                

                if(startFromBase == 0)
                {
                    // la Thuan
                    // danh thuan

                    if (soleGetCommandFistTime == 0)
                    {

                        if ((currentCandle == 1) ||
                        (currentCandle == 5) ||
                        (currentCandle == 9) ||
                        (currentCandle == 13) ||
                        (currentCandle == 17))
                        {
                            // cay vao lenh
                            if ((block0[currentCandle].CompareTo("blue") == 0))
                            {
                                setCommandBlue();
                                soleGetCommandFistTime = 1;
                            }
                            else
                            {

                                setCommmandRed();
                                soleGetCommandFistTime = 1;
                            }
                        }
                    }
                    else
                    {

                        if ((currentCandle == 1) ||
                      (currentCandle == 5) ||
                      (currentCandle == 9) ||
                      (currentCandle == 13) ||
                      (currentCandle == 17))
                        {
                            // check ket qua


                            if (currentCandle == 1)
                            {

                                if ((block1[19].CompareTo(block1[17]) != 0))
                                {

                                    // tiep tuc lost 
                                    if ((block0[currentCandle].CompareTo("blue") == 0))
                                    {
                                        
                                        setCommmandRed();
                                    }
                                    else
                                    {

                                        setCommandBlue();

                                    }
                                    startFromBase = 1;
                                }
                                else
                                {

                                    // win
                                    soleGetCommandFistTime = 0;
                                    vaoLenhSole = 0;
                                    startFromBase = 0;
                                    lostChain = 0;
                                }
                            }
                            else
                            {

                                if ((block0[currentCandle - 2].CompareTo(block0[currentCandle - 4]) != 0))
                                {
                                    // tiep tuc lost

                                    if ((block0[currentCandle].CompareTo("blue") == 0))
                                    {

                                        setCommmandRed();
                                    }
                                    else
                                    {

                                        setCommandBlue();

                                    }
                                    startFromBase = 1;
                                }
                                else
                                {
                                    // win

                                    soleGetCommandFistTime = 0;
                                    vaoLenhSole = 0;
                                    startFromBase = 0;
                                    lostChain = 0;
                                }
                            }



                        }

                    }
                    
                }
                else
                {
                    // la nghich
                    // Danh nghich
                    if (soleGetCommandFistTime == 0)
                    {
                        if ((currentCandle == 1) ||
                        (currentCandle == 5) ||
                        (currentCandle == 9) ||
                        (currentCandle == 13) ||
                        (currentCandle == 17))
                        {

                            // cay vao lenh
                            if ((block0[currentCandle].CompareTo("blue") == 0))
                            {
                                setCommmandRed();
                                soleGetCommandFistTime = 1;
                            }
                            else
                            {

                                setCommandBlue();
                                soleGetCommandFistTime = 1;
                            }
                        }
                    }
                    else
                    {

                        if ((currentCandle == 1) ||
                      (currentCandle == 5) ||
                      (currentCandle == 9) ||
                      (currentCandle == 13) ||
                      (currentCandle == 17))
                        {
                            // check ket qua

                            if (currentCandle == 1)
                            {

                                if ((block1[19].CompareTo(block1[17]) == 0))
                                {

                                    // tiep tuc lost 
                                    if ((block0[currentCandle].CompareTo("blue") == 0))
                                    {
                                        
                                        setCommandBlue();
                                    }
                                    else
                                    {

                                        setCommmandRed();
                                    }
                                    startFromBase = 0;
                                }
                                else
                                {
                                    // win

                                    soleGetCommandFistTime = 0;
                                    vaoLenhSole = 0;
                                    startFromBase = 0;
                                    lostChain = 0;
                                }
                            }
                            else
                            {

                                if ((block0[currentCandle - 2].CompareTo(block0[currentCandle - 4]) == 0))
                                {
                                    // tiep tuc lost

                                    if ((block0[currentCandle].CompareTo("blue") == 0))
                                    {

                                        setCommandBlue();
                                    }
                                    else
                                    {

                                        setCommmandRed();
                                    }
                                    startFromBase = 0;
                                }
                                else
                                {
                                    // win

                                    soleGetCommandFistTime = 0;
                                    vaoLenhSole = 0;
                                    startFromBase = 0;
                                    lostChain = 0;
                                }
                            }





                        }

                    }
                   
                }
               




            }
        }

        public void vaoLenhThuanCommand()
        {
            if (vaoLenhThuan == 1)
            {
                // vao khi checkThuan ==9
                // vao lenh den khi nghich

                if (thuanGetCommandFistTime == 0)
                {
                    if ((currentCandle == 1) ||
                    (currentCandle == 5) ||
                    (currentCandle == 9) ||
                    (currentCandle == 13) ||
                    (currentCandle == 17))
                    {
                       
                        // cay vao lenh
                        if ((block0[currentCandle].CompareTo("blue") == 0))
                        {
                            setCommmandRed();
                            thuanGetCommandFistTime = 1;
                        }
                        else
                        {

                            setCommandBlue();
                            thuanGetCommandFistTime = 1;
                        }
                    }
                }
                else
                {

                    if ((currentCandle == 1) ||
                  (currentCandle == 5) ||
                  (currentCandle == 9) ||
                  (currentCandle == 13) ||
                  (currentCandle == 17))
                    {
                        // check ket qua

                        if (currentCandle == 1)
                        {
                        
                            if ((block1[19].CompareTo(block1[17]) == 0))
                            {
                                
                                // tiep tuc lost 
                                if ((block0[currentCandle].CompareTo("blue") == 0))
                                {
                                    setCommmandRed();
                                }
                                else
                                {

                                    setCommandBlue();
                                }
                            }
                            else
                            {
                                // win
                               
                                thuanGetCommandFistTime = 0;
                                vaoLenhThuan = 0;
                                lostChain = 0;
                            }
                        }
                        else
                        {
                            
                            if ((block0[currentCandle - 2].CompareTo(block0[currentCandle - 4]) == 0))
                            {
                                // tiep tuc lost
                               
                                if ((block0[currentCandle].CompareTo("blue") == 0))
                                {
                                    setCommmandRed();
                                }
                                else
                                {

                                    setCommandBlue();
                                }
                            }
                            else
                            {
                                // win
                               
                                thuanGetCommandFistTime = 0;
                                vaoLenhThuan = 0;
                                lostChain = 0;
                            }
                        }





                    }

                }




            }
        }

        public void vaoLenhNghichCommand()
        {
            if (vaoLenhNghich == 1)
            {
                // vao khi checkThuan ==9
                // vao lenh den khi thuan

                if (nghichGetCommandFistTime == 0)
                {
                  
                    if ((currentCandle == 1) ||
                    (currentCandle == 5) ||
                    (currentCandle == 9) ||
                    (currentCandle == 13) ||
                    (currentCandle == 17))
                    {
                        // cay vao lenh
                        if ((block0[currentCandle].CompareTo("blue") == 0))
                        {
                            setCommandBlue();
                            nghichGetCommandFistTime = 1;
                        }
                        else
                        {

                            setCommmandRed();
                            nghichGetCommandFistTime = 1;
                        }
                    }
                }
                else
                {
                  
                    if ((currentCandle == 1) ||
                  (currentCandle == 5) ||
                  (currentCandle == 9) ||
                  (currentCandle == 13) ||
                  (currentCandle == 17))
                    {
                        // check ket qua
                        

                        if (currentCandle == 1)
                        {
                           
                            if ((block1[19].CompareTo(block1[17]) != 0))
                            {
                               
                                // tiep tuc lost 
                                if ((block0[currentCandle].CompareTo("blue") == 0))
                                {
                                    setCommandBlue();
                                }
                                else
                                {

                                    setCommmandRed();
                                }
                            }
                            else
                            {
                                
                                // win
                                nghichGetCommandFistTime = 0;
                                vaoLenhNghich = 0;
                                lostChain = 0;
                            }
                        }
                        else
                        {
                            
                            if ((block0[currentCandle - 2].CompareTo(block0[currentCandle - 4]) != 0))
                            {
                                // tiep tuc lost
                           
                                if ((block0[currentCandle].CompareTo("blue") == 0))
                                {
                                    setCommandBlue();
                                }
                                else
                                {

                                    setCommmandRed();
                                }
                            }
                            else
                            {
                                // win
                                
                                nghichGetCommandFistTime = 0;
                                vaoLenhNghich = 0;
                                lostChain = 0;
                            }
                        }





                    }

                }




            }
        }


        public void checkSoleCommand()
        {
            int stopCheck = 0;
            int startFrom ;
            baseSave = 0;
            // 0 = start from Thuan
            // 1 = start from Nghich

            if ((currentCandle == 3) ||
                (currentCandle == 7) ||
                (currentCandle == 11) ||
                (currentCandle == 15) ||
                (currentCandle == 19))
            {
                checkSole = 0;
                int[] arrayCheck1 = { };


                if (currentCandle == 3)
                {
                    arrayCheck1 = new int[] { 3 };
                }
                else if (currentCandle == 7)
                {
                    arrayCheck1 = new int[] { 7, 3 };
                }
                else if (currentCandle == 11)
                {
                    arrayCheck1 = new int[] { 11, 7, 3 };
                }
                else if (currentCandle == 15)
                {
                    arrayCheck1 = new int[] { 15, 11, 7, 3 };
                }
                else if (currentCandle == 19)
                {
                    arrayCheck1 = new int[] { 19, 15, 11, 7, 3 };
                }


                if (block0[currentCandle].CompareTo(block0[currentCandle - 2]) == 0)
                {
                    startFrom = 0;
                    baseSave = startFrom;
                }
                else
                {
                    startFrom = 1;
                    baseSave = startFrom;
                }


                for (int i = 0; i < arrayCheck1.Length; i++)
                {
                    int j = arrayCheck1[i];
                    if (startFrom == 0)
                    {
                        if (block0[j].CompareTo(block0[j - 2]) == 0)
                        {
                            checkSole++;
                            startFrom = 1;
                        }
                        else
                        {
                            stopCheck = 1;
                            break;
                        }
                    }
                    else
                    {
                        if (block0[j].CompareTo(block0[j - 2]) != 0)
                        {
                            checkSole++;
                            startFrom = 0;
                        }
                        else
                        {
                            stopCheck = 1;
                            break;
                        }
                    }
                   
                }
                Console.WriteLine("block 0 ---> sole:  " + checkSole + "- stopCheck : " + stopCheck + "- startFrom: " + startFrom);

                if (stopCheck == 0)
                {
                    Console.WriteLine("---> check sole them block 1 ");
                    int[] arrayCheck2 = { 19, 15, 11, 7, 3 };

                    for (int i = 0; i < arrayCheck2.Length; i++)
                    {
                        int j = arrayCheck2[i];
                        Console.WriteLine("block 1 ---> sole:  " + checkSole );
                        if (startFrom == 0)
                        {
                            if (block1[j].CompareTo(block1[j - 2]) == 0)
                            {
                                checkSole++;
                                startFrom = 1;
                            }
                            else
                            {
                                stopCheck = 1;
                                break;
                            }
                        }
                        else
                        {
                            if (block1[j].CompareTo(block1[j - 2]) != 0)
                            {
                                checkSole++;
                                startFrom = 0;
                            }
                            else
                            {
                                stopCheck = 1;
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine("final ---> sole:  " + checkSole);

                if (checkSole == 6)
                {
                  //  vaoLenhSole = 1;
                  // khong vao lenh nay nua 
                    startFromBase = baseSave;
                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_INFO]  PP Xét theo cặp:    %0A  Đã có 5 cặp So le !   ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }

            }
        }

        public void checkThuanFuction()
        {
            
            int stopCheck = 0;
            if((currentCandle == 3)||
                (currentCandle == 7) ||
                (currentCandle == 11) ||
                (currentCandle == 15) ||
                (currentCandle == 19))
            {
                checkThuan = 0;
                int[] arrayCheck1 = { };
               

                if (currentCandle == 3)
                {
                    arrayCheck1 = new int[] { 3 };
                }else if (currentCandle == 7)
                {
                    arrayCheck1 = new int[] { 7, 3 };
                }
                else if (currentCandle == 11)
                {
                    arrayCheck1 = new int[] { 11, 7, 3 };
                }
                else if (currentCandle == 15)
                {
                    arrayCheck1 = new int[] { 15, 11, 7, 3 };
                }
                else if (currentCandle == 19)
                {
                    arrayCheck1 = new int[] { 19, 15, 11, 7, 3 };
                }

                for (int i = 0; i < arrayCheck1.Length; i++)
                {
                    int j = arrayCheck1[i];

                    if (block0[j].CompareTo(block0[j - 2]) == 0)
                    {
                        checkThuan++;
                    }
                    else
                    {
                        stopCheck = 1;
                        break;
                    }
                }


                if(stopCheck == 0)
                {

                    int[] arrayCheck2 = { 19, 15, 11, 7, 3 };

                    for (int i = 0; i < arrayCheck2.Length; i++)
                    {
                        int j = arrayCheck2[i];

                        if (block1[j].CompareTo(block1[j - 2]) == 0)
                        {
                            checkThuan++;
                        }
                        else
                        {
                            stopCheck = 1;
                            break;
                        }
                    }
                }

                if (stopCheck == 0)
                {

                    int[] arrayCheck3 = { 19, 15, 11, 7, 3 };

                    for (int i = 0; i < arrayCheck3.Length; i++)
                    {
                        int j = arrayCheck3[i];

                        if (block2[j].CompareTo(block2[j - 2]) == 0)
                        {
                            checkThuan++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (checkThuan == 9)
                {
                    vaoLenhThuan = 1; // vao lenh 
                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_INFO]  PP Xét theo cặp:    %0A  Đã có 9 cặp Thuận!   ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }

            }
        }


        public void checkNghichFunction()
        {
            
            int stopCheck = 0;
            if ((currentCandle == 3) ||
                (currentCandle == 7) ||
                (currentCandle == 11) ||
                (currentCandle == 15) ||
                (currentCandle == 19))
            {
                checkNghich = 0;

                int[] arrayCheck1 = { };
                

                if (currentCandle == 3)
                {
                    arrayCheck1 = new int[] { 3 };
                }
                else if (currentCandle == 7)
                {
                    arrayCheck1 = new int[] { 7, 3 };
                }
                else if (currentCandle == 11)
                {
                    arrayCheck1 = new int[] { 11, 7, 3 };
                }
                else if (currentCandle == 15)
                {
                    arrayCheck1 = new int[] { 15, 11, 7, 3 };
                }
                else if (currentCandle == 19)
                {
                    arrayCheck1 = new int[] { 19, 15, 11, 7, 3 };
                }

                for (int i = 0; i < arrayCheck1.Length; i++)
                {
                    int j = arrayCheck1[i];

                    if (block0[j].CompareTo(block0[j - 2]) != 0)
                    {
                        checkNghich++;
                    }
                    else
                    {
                        stopCheck = 1;
                        break;
                    }
                }


                if (stopCheck == 0)
                {

                    int[] arrayCheck2 = { 19, 15, 11, 7, 3 };

                    for (int i = 0; i < arrayCheck2.Length; i++)
                    {
                        int j = arrayCheck2[i];

                        if (block1[j].CompareTo(block1[j - 2]) != 0)
                        {
                            checkNghich++;
                        }
                        else
                        {
                            stopCheck = 1;
                            break;
                        }
                    }
                }

                if (stopCheck == 0)
                {

                    int[] arrayCheck3 = { 19, 15, 11, 7, 3 };

                    for (int i = 0; i < arrayCheck3.Length; i++)
                    {
                        int j = arrayCheck3[i];

                        if (block2[j].CompareTo(block2[j - 2]) != 0)
                        {
                            checkNghich++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (checkNghich == 7)
                {
                    vaoLenhNghich = 1;
                    chromeDriver.ExecuteScript("var popupwin = window.open('https://api.telegram.org/bot1477417480:AAHtpkU2nrwMiTC_zl-rThkFTLEOE2xbEEA/sendMessage?chat_id=-1001398145297' + '&text=[BOT_INFO]  PP Xét theo cặp:    %0A  Đã có 7 cặp Nghịch!   ', 'anyname', 'width=10,height=1,left=5,top=3'); setTimeout(function () {     popupwin.close(); }, 1000);;");
                }

            }
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
