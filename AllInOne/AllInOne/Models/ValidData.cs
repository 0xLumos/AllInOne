using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

public class ValidData
{
    private static int Minimum_Length = 7;
    private static int Upper_Case_length = 1;
    private static int Lower_Case_length = 1;
    private static int NonAlpha_length = 1;
    private static int Numeric_length = 1;

    public static bool IsValidEmail(string Email)
    {
        try
        {
            MailAddress m = new MailAddress(Email);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    public static bool IsValidPassword(string Password)
    {
        if (Password.Length < Minimum_Length)
            return false;
        if (UpperCaseCount(Password) < Upper_Case_length)
            return false;
        if (LowerCaseCount(Password) < Lower_Case_length)
            return false;
        if (NumericCount(Password) < 1)
            return false;
        if (NonAlphaCount(Password) < NonAlpha_length)
            return false;
        return true;
    }

    private static int UpperCaseCount(string Password)
    {
        return Regex.Matches(Password, "[A-Z]").Count;
    }

    private static int LowerCaseCount(string Password)
    {
        return Regex.Matches(Password, "[a-z]").Count;
    }
    private static int NumericCount(string Password)
    {
        return Regex.Matches(Password, "[0-9]").Count;
    }
    private static int NonAlphaCount(string Password)
    {
        return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
    }
}