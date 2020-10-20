using System;
using System.Runtime.InteropServices;
using ASMeSDK_CSharp;

namespace AsmeFace
{
    public class DeviceInfo
    {
        public string szVersion { get; set; }
        public string szMac { get; set; }
        public string dwIPAddress { get; set; }
        public string dwStatus { get; set; }
        public string dwDoor { get; set; }
        public string dwType { get; set; }

        public string dwSubnetMask { get; set; }
        public string dwIPGate { get; set; }
    }

    public class AsmeDevice
    {
        private const int AS_ME_MEM_TYPE_GROUP = 0;
        private const int AS_ME_MEM_TYPE_WEEK_SCHEDULE = 1;
        private const int AS_ME_MEM_TYPE_HOLIDAY_SCHEDULE = 2;
        private const int AS_ME_MEM_TYPE_CARD = 3;
        private const int AS_ME_GROUP_NUM = 200;
        private const ulong AS_ME_NO_CARD = 0xffffffffffffffff;

        private const int AS_ME_FIRST_AUTH_DISABLE = 0;        
        private const int AS_ME_FIRST_AUTH_DAY = 1;        
        private const int AS_ME_FIRST_AUTH_ALWAYS = 2;        

        //access type card and password
        private const int AS_ME_AUTH_MODE_CARD = 0;
        private const int AS_ME_AUTH_MODE_PASSWORD = 1;
        private const int AS_ME_AUTH_MODE_CARD_OR_PASSWORD = 2;
        private const int AS_ME_AUTH_MODE_CARD_AND_PASSWORD = 3;
        private const int AS_ME_AUTH_MODE_DISABLE = 4;

        //access type finger and card and password
        private const int AS_ME_AUTH_MODE_FINGER = 5;
        private const int AS_ME_AUTH_MODE_FINGER_OR_CARD = 6;
        private const int AS_ME_AUTH_MODE_FINGER_AND_CARD = 7;
        private const int AS_ME_AUTH_MODE_FINGER_CARD_PWD = 8;
        private const int AS_ME_AUTH_MODE_FINGER_OR_PWD = 9;
        private const int AS_ME_AUTH_MODE_FINGER_AND_PWD = 10;

        //access type face and card
        private const int AS_ME_AUTH_MODE_FACE_OR_CARD = 11;
        private const int AS_ME_AUTH_MODE_FACE_AND_CARD = 12;
        private const int AS_ME_AUTH_MODE_FACE = 13;


        public string GetResponse(int nRes)
        {
            string nResponse = "";
            switch (nRes)
            {
                case -1:
                    nResponse = "Operation was canceled by user";
                    break;
                case -2:
                    nResponse = "Function call parameter incorrect";
                    break;
                case -3:
                    nResponse = "Out of memory";
                    break;
                case -4:
                    nResponse = "No implementation";
                    break;
                case -5:
                    nResponse = "Update **";
                    break;
                case -6:
                    nResponse = "Save file";
                    break;
                case -7:
                    nResponse = "Remote file";
                    break;

                case -101:
                    nResponse = "Can not create socket";
                    break;
                case -102:
                    nResponse = "Broadcast error";
                    break;
                case -103:
                    nResponse = "Send date error";
                    break;
                case -104:
                    nResponse = "Send data time out";
                    break;
                case -105:
                    nResponse = "Receive data error";
                    break;
                case -106:
                    nResponse = "Recieve data time out";
                    break;
                case -107:
                    nResponse = "Network connection failure";
                    break;
                case -108:
                    nResponse = "Connection time out, may communication line is blocked or device not work normal or device alredy be opened";
                    break;
                case -110:
                    nResponse = "Can not open serial port, this serial port may be not exist or opened by other programs";
                    break;
                case -111:
                    nResponse = "Do not support this type communication";
                    break;
                case -112:
                    nResponse = "SDK can not creat event object";
                    break;
                case -114:
                    nResponse = "Set communication time out failure";
                    break;
                case -115:
                    nResponse = "Change communication rate failure";
                    break;
                case -116:
                    nResponse = "Communication process error";
                    break;

                case -301:
                    nResponse = "Specified address can not find controller";
                    break;
                case -302:
                    nResponse = "Controller type unknown";
                    break;
                case -303:
                    nResponse = "Responce package data format error";
                    break;


                case -601:
                    nResponse = "Group number overflow";
                    break;
                case -602:
                    nResponse = "Go across maxmum card number";
                    break;
                case -604:
                    nResponse = "Multi-card group setup overflow";
                    break;
                case -605:
                    nResponse = "Door-magnet 0 setup error";
                    break;
                case -606:
                    nResponse = "Door-magnet 1 setup error";
                    break;
                case -607:
                    nResponse = "Door-magnet 2 setup error";
                    break;
                case -608:
                    nResponse = "Door-magnet 3 setup error";
                    break;
                case -609:
                    nResponse = "Exit-button 0 setup error";
                    break;
                case -610:
                    nResponse = "Exit-button 1 setup error";
                    break;
                case -611:
                    nResponse = "Exit-button 2 setup error";
                    break;
                case -612:
                    nResponse = "Exit-button 3 setup error";
                    break;
                case -613:
                    nResponse = "Alarm 0 setup error";
                    break;
                case -614:
                    nResponse = "Alarm 1 setup error";
                    break;
                case -615:
                    nResponse = "Alarm 2 setup error";
                    break;
                case -616:
                    nResponse = "Alarm 3 setup error";
                    break;
                case -617:
                    nResponse = "Device memory damage";
                    break;
                case -618:
                    nResponse = "Output pin damage";
                    break;
                case -619:
                    nResponse = "Input pin damage";
                    break;
                case -620:
                    nResponse = "Device time error";
                    break;
                case -621:
                    nResponse = "Read card error";
                    break;
                case -623:
                    nResponse = "Comunication error";
                    break;
                case -624:
                    nResponse = "No extension board conection";
                    break;
                case -625:
                    nResponse = "Communication password error";
                    break;
                case -635:
                    nResponse = "Photo are similar to others";
                    break;
                case -636:
                    nResponse = "Wrong photo format";
                    break;
            }
            return nResponse;
        }

        private const ushort AS_ME_NO_PASSWORD = 0xffff;

        //private bool m_bOpen;
        private bool m_bStop;
        private static int OpenControllerStop = 0;
        //private readonly ushort wCtrlAddress = 0;
        private IntPtr m_hController = IntPtr.Zero;
        private static asc_SDKAPI.DEVICE_PROC FindACtrl = null;
        private System.Collections.Generic.List<DeviceInfo> _devices = new System.Collections.Generic.List<DeviceInfo>();
        private asc_STU.LPAS_ME_COMM_ADDRESS address = new asc_STU.LPAS_ME_COMM_ADDRESS();

        //public AsmeDevice()
        //{

        //}

        private static uint StrIpToUint(string strIPAddress)
        {
            if (string.IsNullOrEmpty(strIPAddress)) return 0;

            string[] ipSplit = strIPAddress.Split('.');

            return (uint.Parse(ipSplit[3])) | (uint.Parse(ipSplit[2]) << 8) |
                (uint.Parse(ipSplit[1]) << 16) | (uint.Parse(ipSplit[0]) << 24);
        }
        
        public int FindController()
        {
            IntPtr Handle = IntPtr.Zero;
            m_bStop = false;
            _devices.Clear();
            _devices = new System.Collections.Generic.List<DeviceInfo>();
            FindACtrl = GetControllers;
            return asc_SDKAPI.AS_ME_FindLocalNetController(FindACtrl, Handle, ref m_bStop);            
        }

        private int GetControllers(ref asc_STU.LPAS_ME_DEVICE_ITEM pItem, IntPtr pUserParam)
        {
            uint dwType = pItem.dwType;
            string strTmp;            
            switch (dwType)
            {
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_MS_12:
                    strTmp = ("MS-12");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_MS_24:
                    strTmp = ("MS-24");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_ME_12:
                    strTmp = ("ME-12");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_ME_24:
                    strTmp = ("ME-24");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_ME_20:
                    strTmp = ("ME-20");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_ME_30:
                    strTmp = ("ME-30");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DE_12:
                    strTmp = ("DE-12");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DE_24:
                    strTmp = ("DE-24");
                    break;

                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DE_20:
                    strTmp = ("DE-24");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_ME_30IC:
                    strTmp = ("DE-24");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_ME_20IC:
                    strTmp = ("DE-24");
                    break;

                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DL_24:
                    strTmp = ("DL-24");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DS_12:
                    strTmp = ("DS-12");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DE_20T:
                    strTmp = ("DE-2OT");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DE_30T:
                    strTmp = ("DE-30T");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DF_30:
                    strTmp = ("DF-30");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DE_20IC:
                    strTmp = ("DE-20IC");
                    break;

                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DF_20:
                    strTmp = ("DF-20");
                    break;
                case (int)asc_STU.asc_device_type.AS_ME_TYPE_DF_40:
                    strTmp = ("DF-40");
                    break;
                default:
                    strTmp = dwType.ToString();
                    break;
            }
            
            uint dwIPAddress = pItem.dwIPAddress;
            uint dwSubnetMask = pItem.dwSubnetMask;
            uint dwIPGate = pItem.dwIPGate;

            DeviceInfo listOfInfo = new DeviceInfo
            {
                szMac = System.Runtime.InteropServices.Marshal.PtrToStringUni(pItem.szMac),
                szVersion = System.Runtime.InteropServices.Marshal.PtrToStringUni(pItem.szVersion),

                dwIPAddress = string.Format(("{0}.{1}.{2}.{3}"), dwIPAddress >> 24,
                    (dwIPAddress >> 16) & 0xff, (dwIPAddress >> 8) & 0xff,
                    dwIPAddress & 0xff),

                dwSubnetMask = string.Format(("{0}.{1}.{2}.{3}"), dwSubnetMask >> 24,
                    (dwSubnetMask >> 16) & 0xff, (dwSubnetMask >> 8) & 0xff,
                    dwSubnetMask & 0xff),

                dwIPGate = string.Format(("{0}.{1}.{2}.{3}"), dwIPGate >> 24,
                    (dwIPGate >> 16) & 0xff, (dwIPGate >> 8) & 0xff,
                    dwIPGate & 0xff)
            };
            _devices.Add(listOfInfo);            
            return 0;
        }

        public System.Collections.Generic.List<DeviceInfo> GetControllerInfo()
        {
            return _devices;
        }

        public int ChangeIP(string m_ip, string m_mask, string m_gate, string m_type, string m_mac)
        {
            m_bStop = false;
            uint m_dwIP = StrIpToUint(m_ip);
            uint m_dwMask = StrIpToUint(m_mask);
            uint m_dwGate = StrIpToUint(m_gate);

            int nRes;
            if (m_type == ("ASV-TCP/IP"))
            {
                nRes = asc_SDKAPI.AS_ME_ChangeLocalNetConvertorIP(m_mac, m_dwIP, m_dwMask, m_dwGate, ref m_bStop);
            }
            else
            {
                //The following code just only work fine on controller that not set password.
                //You can set the right password for actual case.
                nRes = asc_SDKAPI.AS_ME_ChangeLocalNetControllerIP(m_mac, m_dwIP, m_dwMask, m_dwGate, AS_ME_NO_PASSWORD, ref m_bStop);
            }
            return nRes;
        }

        public int DetectController(string m_ip)
        {
            ushort wCtrlAddress = 0;
            address.nType = asc_STU.AS_ME_COMM_TYPE_IPV4;
            address.IPV4.dwIPAddress = StrIpToUint(m_ip);
            address.IPV4.wServicePort = 50000;
            asc_STU.LPAS_ME_TYPE_INFO pInfo = new asc_STU.LPAS_ME_TYPE_INFO();
            IntPtr init = Marshal.AllocHGlobal(asc_STU.AS_ME_TYPE_NAME_LEN);
            pInfo.szTypeName = init;
            return asc_SDKAPI.AS_ME_DetectController(ref address, wCtrlAddress, ref pInfo, ref OpenControllerStop);
        }

        public int OpenDevice(string ip)
        {
            if (m_hController != IntPtr.Zero)
                return 1;

            address.nType = asc_STU.AS_ME_COMM_TYPE_IPV4;
            address.IPV4.dwIPAddress = StrIpToUint(ip);
            address.IPV4.wServicePort = 50000;
            int dType = -1;
            return asc_SDKAPI.AS_ME_OpenController((int)dType, ref address, 0,
                   asc_STU.AS_ME_NO_PASSWORD, ref OpenControllerStop, ref m_hController);
        }

        public int SetCard(int UserID, string card, int groupID)
        {
            bool bIgnoreCardNum = true;
            ulong dw64CardNum = AS_ME_NO_CARD;
            bool bSearch = true;
            asc_STU.LPAS_ME_CARD_PARAM pParam = new asc_STU.LPAS_ME_CARD_PARAM
            {
                bHasPassCount = false,
                bHasDeadline = false,
                bFirstCard = false,
                bSetGuard = false,
                nGroup = groupID,
                szName = Marshal.StringToHGlobalUni(UserID.ToString()),
                szPassword = Marshal.StringToHGlobalUni("8888")
            };

            if (!string.IsNullOrEmpty(card))
            {
                dw64CardNum = Convert.ToUInt64(card);
                bIgnoreCardNum = false;
            }

            var nRes = asc_SDKAPI.AS_ME_SetCard(m_hController, UserID, bIgnoreCardNum, dw64CardNum, bSearch, ref pParam);
            Marshal.FreeHGlobal(pParam.szPassword);
            Marshal.FreeHGlobal(pParam.szName);

            return nRes;
        }

        public int DeleteCard(int UserID)
        {
            bool bIgnoreCardNum = false;
            ulong dw64CardNum = 0;
            bool bSearch = true;
            asc_STU.LPAS_ME_CARD_PARAM pParam = new asc_STU.LPAS_ME_CARD_PARAM
            {
                bCancelOpen = false,
                bHasPassCount = false,
                bHasDeadline = false,
                bFirstCard = false,
                nGroup = 0,
                szPassword = IntPtr.Zero
            };          

            return asc_SDKAPI.AS_ME_SetCard(m_hController, UserID, bIgnoreCardNum, dw64CardNum, bSearch, ref pParam);
        }

        public int ReadFinger(byte[] intPtr)
        {
            return asc_SDKAPI.AS_ME_ReadFingerprint(m_hController, intPtr);
        }

        public int SetFinger(int userID, byte[] intPtr)
        {           
            return asc_SDKAPI.AS_ME_SetFingerprint(m_hController, true, userID, 0, intPtr);
        }

        public int DeleteFinger(int userID)
        {
            return asc_SDKAPI.AS_ME_SetFingerprint(m_hController, true, userID, 0, null);
        }

        public int WriteFace(byte[] photo, int userID)
        {      
            var temp = new byte[1080];
            int nRes = asc_SDKAPI.AS_ME_ReadFaceByPhoto(m_hController, photo, photo.Length, temp);

            if (nRes < 0)
            {
                CustomLog.WriteToFile("Error: AsmeDevice AS_ME_ReadFaceByPhoto " + nRes);
                asc_SDKAPI.AS_ME_CloseController(m_hController);
                m_hController = IntPtr.Zero;
                return nRes;
            }

            nRes = asc_SDKAPI.AS_ME_SetFaceByPhoto(m_hController, false, userID, photo.Length, photo,
                userID.ToString());

            if (nRes < 0)
            {
                CustomLog.WriteToFile("Error: AsmeDevice Failed AS_ME_SetFaceByPhoto " + nRes);
                asc_SDKAPI.AS_ME_CloseController(m_hController);
                m_hController = IntPtr.Zero;
                return nRes;
            }

            CustomLog.WriteToFile("WriteFace Success " + nRes);
            return nRes;
        }

        public void CloseDevice()
        {
            asc_SDKAPI.AS_ME_CloseController(m_hController);
            m_hController = IntPtr.Zero;
        }

        public int DeleteFaceByPhoto(int userID)
        {
            bool bSearch = true;
            asc_STU.LPAS_ME_CARD_PARAM pParam = new asc_STU.LPAS_ME_CARD_PARAM();
            pParam.bCancelOpen = false;
            pParam.bHasPassCount = false;
            pParam.bHasDeadline = false;
            pParam.bFirstCard = false;
            pParam.nGroup = 0;
            pParam.szPassword = IntPtr.Zero;

            return asc_SDKAPI.AS_ME_SetFaceByPhoto(m_hController, bSearch, userID, 0, null, userID.ToString());
        }

        public int DeleteFace(int userID)
        {
            return asc_SDKAPI.AS_ME_SetFace(m_hController, true, userID, null, userID.ToString());
        }

        public int DeleteAllFace()
        {
            return asc_SDKAPI.AS_ME_ClearAllFace(m_hController);
        }

        public int InitController(string m_ip)
        {
            return asc_SDKAPI.AS_ME_InitController(m_hController);
        }

        public int ReadCard(ulong card)
        {
            int nRes = asc_SDKAPI.AS_ME_StartReadCard(m_hController);
            if(nRes < 0)
            {
                CloseWriteToFile("AS_ME_StartReadCard " + GetResponse(nRes));
                return nRes;
            }
            int nErrCount = 0;
            m_bStop = false;
            while (m_bStop != true)
            {
                nRes = asc_SDKAPI.AS_ME_ReadCard(m_hController, ref card);
                if (nRes >= 0)
                {
                    nErrCount = 0;
                }
                else
                {
                    if (nRes == -1)
                        break;
                    else
                    {
                        if (nRes == -106)
                            continue;

                        nErrCount++;
                        if (nErrCount >= 3)
                        {
                            CustomLog.WriteToFile("AS_ME_ReadCard " + GetResponse(nRes));
                            break;
                        }
                    }
                }
            }
            asc_SDKAPI.AS_ME_StopReadCard(m_hController);
            return nRes;
        }

        int nReaderNum = -1;
        int nCurDoorNum = 0;

        public int CommunicationTest()
        {
            IntPtr init = Marshal.AllocHGlobal(asc_STU.AS_ME_TYPE_NAME_LEN);
            asc_STU.LPAS_ME_TYPE_INFO pInfo = new asc_STU.LPAS_ME_TYPE_INFO
            {
                szTypeName = init
            };

            var nRes = asc_SDKAPI.AS_ME_CommuncationTest(m_hController, ref pInfo, 1);
            if (nRes < 0)
            {
                CloseWriteToFile("AS_ME_CommuncationTest " + GetResponse(nRes));
                return nRes;
            }

            nReaderNum = pInfo.nReaderNum;
            pInfo.nCurDoorNum = pInfo.nDoorNum;
            nCurDoorNum = pInfo.nCurDoorNum;

            if (pInfo.dwType != asc_SDKAPI.AS_ME_GetType(m_hController))
            {
                CloseWriteToFile("The type of device is wrong " + GetResponse(nRes));
                return nRes;
            }

            Marshal.FreeHGlobal(init);
            init = IntPtr.Zero;
            return 1;
        }

        public int SetReader(int doorDelay, int accessType)
        {
            if (CommunicationTest() < 0)
                return -1;

            for (int i = 0; i < nCurDoorNum; i++)
            {
                ////Set the lock 0 relay to 0, the lock 1 relay to 1...
                var nRes = asc_SDKAPI.AS_ME_SetLockRelay(m_hController, i, i);
                if (nRes < 0)//Error Return
                {
                    CloseWriteToFile("AS_ME_SetLockRelay " + GetResponse(nRes));
                    return nRes;
                }
                //Set all locks delay to 3s...
                nRes = asc_SDKAPI.AS_ME_SetLockDelay(m_hController, i, doorDelay);
                if (nRes < 0)//Error Return
                {
                    CloseWriteToFile("AS_ME_SetLockDelay " + GetResponse(nRes));
                    return nRes;
                }
            }

            asc_STU.LPAS_ME_READER_PARAM reader = new asc_STU.LPAS_ME_READER_PARAM
            {
                bRemoteAuth = false,
                nExtraAuth = 0, //one card open door
                nFirstAuthMode = AS_ME_FIRST_AUTH_DISABLE,
                nGreenMode = accessType, // access type face or card
                nRedMode = AS_ME_AUTH_MODE_DISABLE,
                szUrgencyCode = Marshal.StringToHGlobalUni("888888")
            };

            for (int i = 0; i < nReaderNum; i++)
            {
                var nRes = asc_SDKAPI.AS_ME_SetReader(m_hController, i, ref reader);
                if (nRes < 0)//Error Return
                {
                    CloseWriteToFile("Failed to SetUp the reader " + GetResponse(nRes));
                    return nRes;
                }
            }

            return 1;
        }

        public int SetGroup(int groupID, asc_STU.LPAS_ME_WEEK_SCHEDULE week)
        {
            //nRes = asc_SDKAPI.AS_ME_Clear_Memory(m_hController, AS_ME_MEM_TYPE_HOLIDAY_SCHEDULE);
            //if (nRes < 0)
            //{
            //    CloseWriteToFile("Clearing holiday scheduale, error code: " + GetResponse(nRes));
            //    return nRes;
            //}

            //nRes = asc_SDKAPI.AS_ME_Clear_Memory(m_hController, AS_ME_MEM_TYPE_WEEK_SCHEDULE);
            //if (nRes < 0)
            //{
            //    CloseWriteToFile("Clearing holiday schedual, error code: " + GetResponse(nRes));
            //    return nRes;
            //}

            //nRes = asc_SDKAPI.AS_ME_Clear_Memory(m_hController, AS_ME_MEM_TYPE_GROUP);
            //if (nRes < 0)
            //{
            //    CloseWriteToFile("Clearing group, error code: " + GetResponse(nRes));
            //    return nRes;
            //}

            //nRes = asc_SDKAPI.AS_ME_Clear_Memory(m_hController, AS_ME_MEM_TYPE_CARD);
            //if (nRes < 0)
            //{
            //    CloseWriteToFile("Clearing card number, error code: " + GetResponse(nRes));
            //    return nRes;
            //}

            // holiday
            //We just set one holiday schedule which has one holiday 1.1.
            asc_STU.LPAS_ME_HOLIDAY_SCHEDULE holiday = new asc_STU.LPAS_ME_HOLIDAY_SCHEDULE
            {
                aHoliday = new asc_STU.AS_ME_HOLIDAY[asc_STU.Holiday_Num]
            };

            for (int i = 0; i < asc_STU.Holiday_Num; i++)
            {
                holiday.aHoliday[i].byMonth = 0xff;
                holiday.aHoliday[i].byDay = 0xff;
            }

            var nRes = asc_SDKAPI.AS_ME_SetHolidaySchedule(m_hController, 0, ref holiday);
            if (nRes < 0)
            {
                CloseWriteToFile("Set holiday schedule, error code: " + GetResponse(nRes));
                return nRes;
            }

            // Week
            //We just two time segments per day from Monday to Friday.

            //asc_STU.LPAS_ME_WEEK_SCHEDULE week = new asc_STU.LPAS_ME_WEEK_SCHEDULE
            //{
            //    aDaySeg = new asc_STU.AS_ME_TIME_SEG[7, 3]
            //};

            //for (int i = 0; i < 7; i++)
            //{
            //    week.aDaySeg[i, 0].byStartHour = 0;
            //    week.aDaySeg[i, 0].byStartMinute = 0;
            //    week.aDaySeg[i, 0].byEndHour = 23;
            //    week.aDaySeg[i, 0].byEndMinute = 59;

            //    week.aDaySeg[i, 1].byStartHour = 0;
            //    week.aDaySeg[i, 1].byStartMinute = 0;
            //    week.aDaySeg[i, 1].byEndHour = 0;
            //    week.aDaySeg[i, 1].byEndMinute = 0;

            //    week.aDaySeg[i, 2].byStartHour = 0;
            //    week.aDaySeg[i, 2].byStartMinute = 0;
            //    week.aDaySeg[i, 2].byEndHour = 0;
            //    week.aDaySeg[i, 2].byEndMinute = 0;
            //}

            nRes = asc_SDKAPI.AS_ME_SetWeekSchedule(m_hController, (groupID + 1), ref week);
            if (nRes < 0)
            {
                CloseWriteToFile("Set week schedule, error code: " + GetResponse(nRes));
                return nRes;
            }

            int[] aHolidaySchedule = new int[asc_STU.AS_ME_READER_MAX_NUM]{
                                0, 0, 0, 0,
                                0, 0, 0, 0,
                                0, 0, 0, 0,
                                0, 0, 0, 0
                            };
            int[] aWeekSchedule = new int[asc_STU.AS_ME_READER_MAX_NUM]{
                                (groupID + 1), 0, 0, 0,
                                0, 0, 0, 0,
                                0, 0, 0, 0,
                                0, 0, 0, 0
                            };

            asc_STU.LPAS_ME_GROUP lmftr = new asc_STU.LPAS_ME_GROUP
            {
                aHolidaySchedule = aHolidaySchedule,
                aWeekSchedule = aWeekSchedule,
                dwReaderMask = (uint)(1 << nReaderNum) - 1
            };

            nRes = asc_SDKAPI.AS_ME_SetGroup(m_hController, groupID, ref lmftr);
            if (nRes < 0)
            {
                CloseWriteToFile("Set group, error code: " + GetResponse(nRes));
                return nRes;
            }
            
            return nRes;
        }

        public asc_STU.LPAS_ME_WEEK_SCHEDULE GetDefaultWeek()
        {
            asc_STU.LPAS_ME_WEEK_SCHEDULE week = new asc_STU.LPAS_ME_WEEK_SCHEDULE
            {
                aDaySeg = new asc_STU.AS_ME_TIME_SEG[7, 3]
            };

            for (int i = 0; i < 7; i++)
            {
                week.aDaySeg[i, 0].byStartHour = 0;
                week.aDaySeg[i, 0].byStartMinute = 0;
                week.aDaySeg[i, 0].byEndHour = 23;
                week.aDaySeg[i, 0].byEndMinute = 59;

                week.aDaySeg[i, 1].byStartHour = 0;
                week.aDaySeg[i, 1].byStartMinute = 0;
                week.aDaySeg[i, 1].byEndHour = 0;
                week.aDaySeg[i, 1].byEndMinute = 0;

                week.aDaySeg[i, 2].byStartHour = 0;
                week.aDaySeg[i, 2].byStartMinute = 0;
                week.aDaySeg[i, 2].byEndHour = 0;
                week.aDaySeg[i, 2].byEndMinute = 0;
            }
            return week;
        }

        private void CloseWriteToFile(string log)
        {
            CustomLog.WriteToFile(log);
            CloseDevice();
        }
    }
}
