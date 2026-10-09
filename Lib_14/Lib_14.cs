namespace Lib_14
{
    public static class Calculation
    {
        public static int CalculateSum(int[] mas)
        {
            int sum = 0;

            if (mas == null)
            {
                return 0;
            }

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 8)
                {
                    sum = sum + mas[i];
                }
            }

            return sum;
        }
    }
}
