using OpenQA.Selenium;

namespace Task3;

public class LinksPage : BasePage
{
    private ButtonElement homeLink = new(By.XPath("//a[@id = 'simpleLink']"), "Home link");

    public LinksPage() : base(By.XPath("//*[contains(@class,'text-center') and contains(text(),'Links')]"), "Links page") 
    {
    }

    public void ClickHomeLink() => homeLink.Click();
}
