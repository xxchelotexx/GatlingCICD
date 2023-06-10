using System;
using System.Text;

public class RandomStringGenerator
{
    private static Random random = new Random();

    public static string GenerateRandomString(int length)
    {
        const string characters = "abc def ghi jkl mno pqr stu vwx yzA BCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(characters.Length);
            char character = characters[index];
            sb.Append(character);
        }

        return sb.ToString();
    }
}