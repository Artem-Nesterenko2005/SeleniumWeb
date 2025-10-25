using OpenQA.Selenium;

namespace Task3;

public class SamplePage : BasePage
{
    public SamplePage() : base(By.XPath("//*[@id = 'sampleHeading']"), "Sample page")
    {
    }
}
