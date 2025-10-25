using OpenQA.Selenium;

namespace Task3;

public static class AlertsUtils
{
    public static void AcceptAlert() => SingleDriver.GetDriver.SwitchTo().Alert().Accept();

    public static string GetAlertText() => SingleDriver.GetDriver.SwitchTo().Alert().Text;

    public static bool IsExistAlert()
    {
        try
        {
            SingleDriver.GetDriver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    public static void InputTextAlert(string text)
    {
        Logger.LogInfo("Ввод текста в alert");
        SingleDriver.GetDriver.SwitchTo().Alert().SendKeys(text);
    }
}
