using System;
using System.Collections.Generic;
using System.Linq;

namespace HB_NASA
{
    public enum Directions
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }
    public class Program
    {


        public static void Main(string[] args)
        {
            string returnCoordinate = "";
            List<string> plateauDataSyn = new List<string>();
            List<string> plateauAreaSyn = new List<string>();
            Console.WriteLine("Kaç tane data girişi yapacaksınız?");
            string dataCount = Console.ReadLine();

            plateauDataSyn = ControlForSyntax(dataCount, true);

            Console.WriteLine("Plato alanı için (x,y) değerleri giriniz.");
            string plateauArea = Console.ReadLine();

            plateauAreaSyn = ControlForSyntax(plateauArea, false);

            for (int i = 0; i < plateauDataSyn.Count; i++)
            {
                Console.WriteLine("baslangıç koordinatlarınızı giriniz");
                string coordinate = Console.ReadLine();
                Console.WriteLine("Hareket rotalarını giriniz.");
                string rotate = Console.ReadLine();

                string[] arrCoordinate = coordinate.ToUpper().ToString().Split(' ');
                List<string> arrCoordinateWithoutnull = new List<string>();
                for (int x = 0; x < arrCoordinate.Length; x++)
                {
                    if (arrCoordinate[x] != "")
                    {
                        arrCoordinateWithoutnull.Add(arrCoordinate[x].ToString());
                    }
                }
                List<string> arrRotate = ArrayWithInputStr(rotate.ToUpper());
                string messageCoordinate = ControlForInput(arrCoordinateWithoutnull, true);
                if (messageCoordinate != "")
                {
                    Console.WriteLine(messageCoordinate);
                    return;
                }

                //doğru input giriş kontrolleri yapıldı.
                string messageRotate = ControlForInput(arrRotate, false);

                if (messageRotate != "")
                {
                    Console.WriteLine(messageRotate);
                    return;
                }

                returnCoordinate = plaetauCoordinate(arrRotate, arrCoordinateWithoutnull);
                Console.WriteLine(returnCoordinate);
            }

        }

        private static List<string> ArrayWithInputStr(string input)
        {
            List<string> arrTemp = new List<string>();


            for (int i = 0; i < input.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(input[i].ToString()))
                {
                    arrTemp.Add(input[i].ToString());
                }

            }

            return arrTemp;
        }

        /// <summary>
        /// alan ve data girişi 
        /// </summary>
        /// <param name="controlArea"></param>
        /// <param name="flagforData"></param>
        /// <returns></returns>
        private static List<string> ControlForSyntax(string controlArea, bool flagforData)
        {
            string plateau;
            bool flagForArea = true;
            List<string> dataCountList = new List<string>();
            dataCountList = ArrayWithInputStr(controlArea.ToUpper());
            while (flagForArea)
            {
                flagForArea = false;
                if (flagforData)
                {
                    if (dataCountList.Count != 1 || !dataCountList[0].All(char.IsNumber))
                    {
                        Console.WriteLine("Data girişi için 1 tane sayı girişi yapmanız gerekmektedir.");
                        Console.WriteLine("Data girişi için  değerleri giriniz.");
                        controlArea = Console.ReadLine();
                        flagForArea = true;
                        dataCountList = ArrayWithInputStr(controlArea.ToUpper());
                    }
                    else
                    {
                        return dataCountList;
                        flagForArea = false;
                    }

                }
                else
                {
                    if (dataCountList.Count != 2 || !dataCountList[0].All(char.IsNumber) || !dataCountList[1].All(char.IsNumber))
                    {
                        Console.WriteLine("Plato alanı için 2 tane sayı girişi yapmanız gerekmektedir.(x,y)");
                        Console.WriteLine("Plato alanı için (x,y) değerleri giriniz.");
                        controlArea = Console.ReadLine();
                        flagForArea = true;
                        dataCountList = ArrayWithInputStr(controlArea.ToUpper());

                    }
                    else
                    {
                        flagForArea = false;
                        return dataCountList;
                    }
                }

            }
            return dataCountList;



        }
        /// data girişlerinin doğru yapılıp yapılmadığı kontrolü
        public static string ControlForInput(List<string> controlData, bool flag)
        {
            string[] rotation = new string[] { "N", "E", "W", "S" };
            string[] direction = new string[] { "L", "M", "R" };

            if (controlData.Count == 0)
            {
                return "Dataları girdiğinizden emin olunuz!";
            }
            if (flag && controlData.Count != 3)
            {
                return "Girdiğiniz değerlerde aralarda boşluk olacak şekilde(virgül ,nokta vs olmadan) 3 adet başlangıç koordinatı girmeniz beklenmektedir.";
            }

            if (flag && (!controlData[0].All(char.IsNumber) || !controlData[1].All(char.IsNumber)
                || controlData[2].All(char.IsNumber) || !rotation.Any(X => X.Contains(controlData[2]))))
            {
                return "Girdiğiniz değerlerde  ilk 2 değer sayı 3. değeriniz 'S,E,N,W' den biri olmalıdır.";
            }
            if (!flag)
            {
                for (int i = 0; i < controlData.Count; i++)
                {
                    if (controlData[i]==direction[0])
                    {
                        continue;
                    }
                    else if(controlData[i] == direction[1])
                    {
                        continue;
                    }
                    else if (controlData[i] == direction[2])
                    {
                        continue;
                    }
                    else
                    {
                        return "Girdiğiniz değerlerde aralarda virgül ,nokta vs olmadan hareket rotaları L,R,M olarak düzenlenmesi gerekmektedir.";
                    }
                }
            }
           

            return "";
        }

        //son durumda doğru datalarla girilmiş son koordinatı verir.
        public static string plaetauCoordinate(List<string> listLastRotate, List<string> firstDirection)
        {

            int directionData = returnCoordinate(firstDirection[2]);

            for (int i = 0; i < listLastRotate.Count; i++)
            {
                if (listLastRotate[i] == "R")
                {
                    directionData = directionData + 1;
                    if (directionData > 3)
                    {
                        directionData = directionData - 4;
                    }
                }

                else if (listLastRotate[i] == "L")
                {
                    directionData = directionData - 1;
                    if (directionData < 0)
                    {
                        directionData = directionData + 4;
                    }
                }
                else
                {
                    if (directionData == 0)
                    {
                        firstDirection[1] = (Convert.ToInt32(firstDirection[1]) + 1).ToString();
                    }
                    else if (directionData == 1)
                    {
                        firstDirection[0] = (Convert.ToInt32(firstDirection[0]) + 1).ToString();
                    }
                    else if (directionData == 2)
                    {
                        firstDirection[1] = (Convert.ToInt32(firstDirection[1]) - 1).ToString();
                    }
                    else if (directionData == 3)
                    {
                        firstDirection[0] = (Convert.ToInt32(firstDirection[0]) - 1).ToString();
                    }
                }
            }
            string lastDirection = Enum.GetName(typeof(Directions), directionData);
            //  Console.WriteLine(firstDirection[0] + " " + firstDirection[1] + " " + lastDirection);
            return firstDirection[0] + " " + firstDirection[1] + " " + lastDirection;
        }
        // unit testten kontrollerin görülmesi için çoklanmış bir methoddur.
        public static string plaetauCoordinateUnitTest(List<string> listLastRotate, List<string> firstDirection)
        {
           
            string messageCoordinate = ControlForInput(firstDirection, true);
            if (messageCoordinate != "")
            {
                return messageCoordinate;
            }

            string messageRotate = ControlForInput(listLastRotate, false);
            if (messageRotate != "")
            {
                return messageRotate;
            }
            int directionData = returnCoordinate(firstDirection[2]);

            for (int i = 0; i < listLastRotate.Count; i++)
            {
                if (listLastRotate[i] == "R")
                {
                    directionData = directionData + 1;
                    if (directionData > 3)
                    {
                        directionData = directionData - 4;
                    }
                }

                else if (listLastRotate[i] == "L")
                {
                    directionData = directionData - 1;
                    if (directionData < 0)
                    {
                        directionData = directionData + 4;
                    }
                }
                else
                {
                    if (directionData == 0)
                    {
                        firstDirection[1] = (Convert.ToInt32(firstDirection[1]) + 1).ToString();
                    }
                    else if (directionData == 1)
                    {
                        firstDirection[0] = (Convert.ToInt32(firstDirection[0]) + 1).ToString();
                    }
                    else if (directionData == 2)
                    {
                        firstDirection[1] = (Convert.ToInt32(firstDirection[1]) - 1).ToString();
                    }
                    else if (directionData == 3)
                    {
                        firstDirection[0] = (Convert.ToInt32(firstDirection[0]) - 1).ToString();
                    }
                }
            }
            string lastDirection = Enum.GetName(typeof(Directions), directionData);
            //  Console.WriteLine(firstDirection[0] + " " + firstDirection[1] + " " + lastDirection);
            return firstDirection[0] + " " + firstDirection[1] + " " + lastDirection;
        }
        private static int returnCoordinate(string direction)
        {
            int returnData = Convert.ToInt32((Directions)Enum.Parse(typeof(Directions), direction));
            return returnData;

        }
    }
}
