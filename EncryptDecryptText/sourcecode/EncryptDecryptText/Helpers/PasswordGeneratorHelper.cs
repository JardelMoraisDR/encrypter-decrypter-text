using System;
using System.Text;

namespace Helpers
{
    public static class PasswordGenerator
    {
        private static string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+=[]{}|;:,.<>?";
        private static Random random = new Random();

        public static string GenerateRandomPassword(int minLength, int maxLength)
        {
            StringBuilder password = new StringBuilder();
            int passwordLength = random.Next(minLength, maxLength + 1);

            for (int i = 0; i < passwordLength; i++)
            {
                int index = random.Next(0, AllowedCharacters.Length);
                password.Append(AllowedCharacters[index]);
            }

            return password.ToString();
        }
    }

}