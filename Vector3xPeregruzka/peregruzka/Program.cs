using System;

namespace peregruzka
{
    class Program
    {
        static Vectror Vector1;
        static Vectror Vector2;
        static void Main(string[] args)
        {
            double x, y, z;
            x = 0;
            y = 0;
            z = 0;
            
            input(out x, out y, out z);
            Vector1 = new Vectror  (x,y,z);
            input(out x, out y, out z);
            Vector2 = new Vectror(x,y,z);
            OperationSelect();
        }
        static void OperationSelect()
        {
            int key1=0;
            int key2=0;
            Console.WriteLine("Пожалуйста, выберите операцию над векторами:\n 1-Узнать длинну вектора;\n 2-Сумма векторов;\n 3-Разность векторов;\n 4-Умножение вектора на скаляр;\n 5-Скалярное произведение векторов;\n 6-Сравнение векторов\n 7-Строковое представление\n 8-Super Star\n ");
            string key = Console.ReadLine();
            try { 
             key1 = Convert.ToInt32(key);
            }
            catch
            {
                Console.WriteLine("Неверно указано значение!");
                OperationSelect();
            }
            switch (key1) 
            { 
                case 1:
                Console.WriteLine("Длинну какого вектора вы хотите узнать? (1 или 2)");
                    key = Console.ReadLine();
                    try { 
                     key2 = Convert.ToInt32(key);
                    }
                    catch
                    {
                        Console.WriteLine("Неверно указано значение!");
                        OperationSelect();
                    }
                    if (key2 == 1 ) 
                    {
                       double ans= Vector1.lengh1();
                        Console.WriteLine("Длинна вектора {0}: {1}",key2,ans);
                         
                        OperationSelect();
                    }
                    else if(key2==2)
                    {
                       double ans = Vector2.lengh1();
                        Console.WriteLine("Длинна вектора {0}: {1}", key2, ans);
                        OperationSelect();
                    }
                    else 
                    { 
                        Console.WriteLine("Неизвестный идентификатор вектора!");
                        OperationSelect();
                    }
                break;
                case 2:
                    Console.WriteLine("Вот ваша сумма векторов:");
                    double[] plus = Vector1 + Vector2;
                    Console.WriteLine("X: {0} Y: {1} Z: {2}", plus[0],plus[1],plus[2]);
                    OperationSelect();
                    break;
                case 3:
                    Console.WriteLine("Вот ваша разность векторов:");
                    double[] minus = Vector1 - Vector2;
                    Console.WriteLine("X: {0} Y: {1} Z: {2}", minus[0], minus[1], minus[2]);
                    OperationSelect();
                    break;
                case 4:
                    Console.WriteLine("Введите число, на которое хотите умножить вектор!");
                    double num;
                    string numer = Console.ReadLine();
                    try 
                    {
                        num = Convert.ToDouble(numer);
                        double[] multiplai = Vector1 * num;
                        Console.WriteLine("X: {0} Y: {1} Z: {2}", multiplai[0], multiplai[1], multiplai[2]);
                    }
                    catch 
                    {
                        Console.WriteLine("Неправильно указан множитель");
                        OperationSelect(); 
                    }
                    OperationSelect();
                    break;
                case 5:
                    Console.WriteLine("Скалярное произведение векторов:");
                    double SkalarMyltiplai = Vector1 * Vector2;
                    Console.WriteLine("Результат операции: {0} ", SkalarMyltiplai);
                    OperationSelect();
                    break;
                case 6:
                    Console.WriteLine("Полученное сравнение");
                    if (Vector1 < Vector2) { Console.WriteLine("Длинна вектора 1 меньше длинны вектора 2 ({0}<{1})", Vector1.lengh1(), Vector2.lengh1()); }
                    else if (Vector1 > Vector2) { Console.WriteLine("Длинна вектора 1 больше длинны вектора 2 ({0}>{1})", Vector1.lengh1(), Vector2.lengh1()); }
                    else if (Vector1 == Vector2) { Console.WriteLine("Длинна вектора 1 и 2 равны ({0}={1})", Vector1.lengh1(), Vector2.lengh1()); }
                    OperationSelect();
                    break;
                case 7:
                    Console.WriteLine("Получение ToString");
                    string ansew;
                    Console.WriteLine("Данные какого вектора вы хотите узнать? (1 или 2)");
                    string keyyer = Console.ReadLine();
                    int keyyer2=0;
                    try
                    {
                        keyyer2 = Convert.ToInt32(keyyer);
                    }
                    catch
                    {
                        Console.WriteLine("Неверно указано значение!");
                        OperationSelect();
                    }
                    if (keyyer2 == 1)
                    {
                        ansew = Vector1.tring();
                        Console.WriteLine( ansew);

                        OperationSelect();
                    }
                    else if (keyyer2 == 2)
                    {
                        ansew = Vector1.ToString();
                        Console.WriteLine( ansew);
                        OperationSelect();
                    }
                    else
                    {
                        Console.WriteLine("Неизвестный идентификатор вектора!");
                        OperationSelect();
                    }
                    OperationSelect();
                    break;
                case 8:
                    {
                       Console.WriteLine("Введите строку вида(x1 y1 z1 * (x2;y2;z2))");
                        string operation =Console.ReadLine();
                        bool checker = operation.Contains('*');
                        if (checker == false) { Console.WriteLine("Вы не указали оператор ( * )"); OperationSelect(); }
                        checker = operation.Contains(';');
                        if (checker == false) { Console.WriteLine("Вы не указали оператор ( ; )"); OperationSelect(); }
                        operation = operation.Replace(';',' ');
                        
                        checker = operation.Contains('(');
                        if (checker == false) { Console.WriteLine("В текстовом представлении отсутствуют разделители ( ( )"); OperationSelect(); }
                        checker = operation.Contains(')');
                        if (checker == false) { Console.WriteLine("В текстовом представлении отсутствуют разделители ( ) )"); OperationSelect(); }
                        string[] vectors = operation.Split('*');
                        string[] vector1str = (vectors[0].Trim()).Split(' ');

                        if (vector1str.Length != 3) { Console.WriteLine("Неверное кол-во элементов 1-го вектора )"); OperationSelect(); }
                        vectors[1].Replace('(', ' ');
                        vectors[1].Replace(')', ' ');
                        while (vectors[1].Contains(';')) { vectors[1] = vectors[1].Replace(';', ' '); }
                        string[] vector2str = (vectors[1].Trim()).Split(' ');
                        if (vector2str.Length != 3) { Console.WriteLine("Неверное кол-во элементов 2-го вектора )"); OperationSelect(); }
                        vector2str[0]= vector2str[0].Replace('(', ' ');
                        vector2str[2] = vector2str[2].Replace(')', ' ');

                        

                        double[] vector1dbl =new double[3];
                        double[] vector2dbl = new double[3];

                        for(int i=0;i< vector1dbl.Length;i++)
                        {
                            vector1dbl[i] = Convert.ToDouble(vector1str[i]);
                        }

                        for (int i = 0; i < vector2dbl.Length; i++)
                        {
                            vector2dbl[i] = Convert.ToDouble(vector2str[i]);
                        }
                         Vectror Vector3 = new Vectror(vector1dbl[0], vector1dbl[1], vector1dbl[2]);
                        Vectror Vector4 = new Vectror(vector2dbl[0], vector2dbl[1], vector2dbl[2]);
                        double anser = Vector3 / Vector4;
                        Console.WriteLine("Ответ: {0}", anser);
                        OperationSelect();
                        break;
                    }
                default:
                Console.WriteLine("Неизвестная операция, попробуйте выбрать снова!");
                OperationSelect();
                break;
            }

        }
        static void input(out double x, out double y, out double z)
        {
            try { 
            Console.WriteLine("Введите координаты окончания вектора (начинаетсяв точке (0;0;0)) в 3-х мерном пространстве (x y z)");
            string input=Console.ReadLine();
            string[] data = input.Split(' ');
            x = Convert.ToDouble(data[0]);
            y = Convert.ToDouble(data[1]);
            z = Convert.ToDouble(data[2]);
            Console.WriteLine("Вы ввели: X:{0} Y:{1} Z:{2}", x, y, z);
                }
            catch
            {
                Console.WriteLine("Вы ввели некорректные данные");
                input(out x, out y, out z);
            }
        }
    }
    class Vectror
    {

        double  x, y, z, num;
        public Vectror(double x,double y,double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vectror(double num)
        {
            this.num = num;
            
        }

        public static double[] operator +(Vectror Vector1, Vectror Vector2)
        {
            double[] ansew = new double[3];
            double x3, y3, z3;
            x3 = Vector1.x+Vector2.x;
            y3 = Vector1.y+Vector2.y;
            z3 = Vector1.z+Vector2.z;
            ansew[0] = x3;
            ansew[1] = y3;
            ansew[2] = z3;
            return ansew;
        }
        public static double[] operator -(Vectror Vector1, Vectror Vector2)
        {
            double[] ansew = new double[3];
            double x3, y3, z3;
            x3 = Vector1.x - Vector2.x;
            y3 = Vector1.y - Vector2.y;
            z3 = Vector1.z - Vector2.z;
            ansew[0] = x3;
            ansew[1] = y3;
            ansew[2] = z3;
            return ansew;
        }
        public static double[] operator *(Vectror Vector1, double value)
        {
            double[] ansew = new double[3];
            double x3, y3, z3;
            x3 = Vector1.x * value;
            y3 = Vector1.y * value;
            z3 = Vector1.z * value;
            ansew[0] = x3;
            ansew[1] = y3;
            ansew[2] = z3;
            return ansew;
        }
        public static double operator /(Vectror Vector3, Vectror Vector4 )
        {
            double ansew2 = (Vector3.y * Vector4.y) + (Vector3.x * Vector4.x) + (Vector3.z * Vector4.z);
            return ansew2;
        }

        public string tring()
        {
            
            string outer= "("+ x + ";" + y + ";" + z + ")";
            return outer;
        }

        public static double operator *(Vectror Vector1, Vectror Vector2)
        {
           double ansew = (Vector1.y * Vector2.y) + (Vector1.x * Vector2.x) + (Vector1.z * Vector2.z);
            return ansew;
        }


        public static bool operator <(Vectror Vector1, Vectror Vector2)
        {
          
             return Vector2.lengh1() < Vector1.lengh1(); 
            
        }
        public static bool operator >(Vectror Vector1, Vectror Vector2)
        {
            return Vector2.lengh1() > Vector1.lengh1();
        }
        public static bool operator ==(Vectror Vector1, Vectror Vector2)
        {
            return Vector2.lengh1() == Vector1.lengh1();
        }
        
        public static bool operator !=(Vectror Vector1, Vectror Vector2)
        {
            return Vector2.lengh1() != Vector1.lengh1();
        }

        public double lengh1()
        {
            return  Math.Abs(Math.Sqrt(x * x + y * y + z * z));
        }
        
    }
}
