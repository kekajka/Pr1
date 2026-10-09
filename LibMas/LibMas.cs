using System;
using System.IO;

namespace LibMas
{
    public static class Massiv
    {
        public static void InitMas(out int[] mas, int column, int randMax)
        {
            Random rnd = new Random();
            mas = new int[column];

            for (int i = 0; i < column; i++)
            {
                mas[i] = rnd.Next(randMax);
            }
        }

        public static void SaveMas(int[] mas, string filePath)
        {
            if (mas == null)
            {
                return;
            }

            StreamWriter file = new StreamWriter(filePath);
            file.WriteLine(mas.Length);

            for (int i = 0; i < mas.Length; i++)
            {
                file.WriteLine(mas[i]);
            }

            file.Close();
        }

        public static void LoadMas(out int[] mas, string filePath)
        {
            if (!File.Exists(filePath))
            {
                mas = new int[0];
                return;
            }

            StreamReader file = new StreamReader(filePath);
            int len = Convert.ToInt32(file.ReadLine());
            mas = new int[len];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Convert.ToInt32(file.ReadLine());
            }

            file.Close();
        }
    }
}
