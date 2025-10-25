namespace Task3;

public static class TabsUtils
{
    public static void SwitchTab()
    {
        var newWindow = SingleDriver.GetDriver.WindowHandles.Last();
        SingleDriver.GetDriver.SwitchTo().Window(newWindow);
    }

    public static void SwitchMainTab()
    {
        var newWindow = SingleDriver.GetDriver.WindowHandles[0];
        SingleDriver.GetDriver.SwitchTo().Window(newWindow);
    }

    public static void CloseTab() => SingleDriver.GetDriver.Close();
}
