using OpenQA.Selenium;

namespace Task3;

public class InputElement : BaseElement
{
    public InputElement(By byLocator, string name) : base(byLocator, name)
    {
    }

    public void InputText(string text)
    {
        WaitUtility.WaitDisplayed(byLocator);
        Logger.LogInfo($"Ввод текста в поле {name}");
        FindElement().SendKeys(text);
    }
}
