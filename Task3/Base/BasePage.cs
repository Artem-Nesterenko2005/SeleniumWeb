using OpenQA.Selenium;

namespace Task3;

public abstract class BasePage
{
    protected readonly string name;

    protected readonly By byLocator;

    private readonly ButtonElement uniqueElement;

    public BasePage(By byLocator, string name)
    {
        this.name = name;
        this.byLocator = byLocator;
        uniqueElement = new ButtonElement(byLocator, "Unique element");
    }

    public bool IsOpened()
    {
        Logger.LogInfo($"Проверка страницы {name} на открытие");
        return uniqueElement.IsDisplayed();
    }
}
