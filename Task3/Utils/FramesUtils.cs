using OpenQA.Selenium;

namespace Task3;

public static class FramesUtils
{
    public static void FrameSwitch(By element) => SingleDriver.GetDriver.SwitchTo().Frame(SingleDriver.GetDriver.FindElement(element));

    public static void MainContentSwitch() => SingleDriver.GetDriver.SwitchTo().DefaultContent();
}
