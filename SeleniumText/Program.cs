using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumText
{

    class Program
    {
       
        static void Main(string[] args)
        {

            Test test = new Test();

            /*
               if(test.DoTask(args[0].Replace(',',' '), args[1].Replace(',', ' '), args[2]))
                MessageCommunicate.SendMessageToTargetWindow("Record", args[2] + ":Success");
               else
                    MessageCommunicate.SendMessageToTargetWindow("Record", args[2] + ":Failed");
            
            */
          

            test.DoTask("alex", "Q", "o65t");

          
        }
    }
    public class Test
    {
        private IWebDriver driver { get; set; }
       public bool DoTask(string email,string pass,string code)
        {
            driver = new ChromeDriver();
            // driver.Manage().Window.Maximize();
            string loginButton = "#Login > div > div > button.btn-standard.call-to-action";
            string emailInput = "email";
            string passwordInput = "password";
            string loginButton2 = "#btnLogin > span";
            string codeType = "codeType";
            string sendCodeButton = "btnSendCode";
            string oneTimeCodeInput = "oneTimeCode";
            string submitButton = "btnSubmit";
            string loginWarnMassage = "body > div.ut-click-shield.ut-click-shield-displayed > section > header > h1";
            string loginContinueButton = "body > div.ut-click-shield.ut-click-shield-displayed > div > div > div > div.ut-livemessage-footer > button";
            string loginContinueButton2 = "body > div.ut-click-shield.ut-click-shield-displayed > div > div > div > div.ut-livemessage-footer > button";
            string squadButtonUnChoosed = "body > section > section > nav > button.view-tab-bar-item.icon-squad";
            string utTile = "body > section > section > section > div.FUINavigationContent > div > div > div.tile.col-1-1.ut-tile-external-link > div.ut-tile-content > p";
            string utLockedMessage = "body > section > section > section > div.FUINavigationContent > div > div > div.tile.col-1-1.ut-tile-transfer-market.disabled > div.ut-tile-dim-overlay.locked > p";
            string signedIntoAnotherDevice = "body > section > section > div > div > div > div.ut-logged-on-console.ut-login-generic > div > div > h2";
            string transferIconButtonUnChoosed = "body > section > section > nav > button.view-tab-bar-item.icon-transfer";
            string activeSquad = "body > section > section > section > div.FUINavigationContent > div > div > div.tile.col-1-1 > div.tileContent > div > div.pitch-image";
            string playersInfo = "squadSlot";
            //
            try
            {
                driver.Navigate().GoToUrl("https://www.easports.com/uk/fifa/ultimate-team/web-app/");
                //click login
                if (IsElementPresentWhinTime(By.CssSelector(loginButton), 30))
                {
                    Thread.Sleep(5000);
                    driver.FindElement(By.CssSelector(loginButton)).Click();
                }
                if(IsElementPresentWhinTime(By.Id(emailInput), 5))
                {
                    Thread.Sleep(5000);
                    driver.FindElement(By.Id(emailInput)).Click();
                    driver.FindElement(By.Id(emailInput)).Clear();
                    driver.FindElement(By.Id(emailInput)).SendKeys(email);
                    driver.FindElement(By.Id(passwordInput)).Click();
                     driver.FindElement(By.Id(passwordInput)).Clear();
                    driver.FindElement(By.Id(passwordInput)).SendKeys(pass);
                    driver.FindElement(By.CssSelector(loginButton2)).Click();
                }
                if(IsElementPresentWhinTime(By.Name(codeType), 5))
                {
                    driver.FindElements(By.Name(codeType))[1].Click();
                    driver.FindElement(By.Id(sendCodeButton)).Click();
                }
                if (IsElementPresentWhinTime(By.Id(oneTimeCodeInput), 5))
                {
                    driver.FindElement(By.Id(oneTimeCodeInput)).Click();
                    string oneCode=AppCode.AppCode.GetEACode(code);
                    driver.FindElement(By.Id(oneTimeCodeInput)).Clear();
                    driver.FindElement(By.Id(oneTimeCodeInput)).SendKeys(oneCode);
                    driver.FindElement(By.Id(submitButton)).Click();
                }
                if(IsElementPresentWhinTime(By.CssSelector(loginWarnMassage),10))
                {
                   
                    IWebElement webElement = driver.FindElement(By.CssSelector(loginWarnMassage));
                    Console.WriteLine(webElement.Text); //Device Suspension
                    if(webElement.Text.Contains("Device Suspension"))
                    {
                        MessageBox.Show("Device Suspension");
                        driver.Close();
                        driver.Dispose();
                        return false;
                    }
                }
                if (IsElementPresentWhinTime(By.CssSelector(signedIntoAnotherDevice), 5))
                {

                    IWebElement webElement = driver.FindElement(By.CssSelector(signedIntoAnotherDevice));
                    Console.WriteLine(webElement.Text); //Signed Into Another Device
                    if (webElement.Text.Contains("SIGNED INTO ANOTHER DEVICE"))
                    {
                        MessageBox.Show("SIGNED INTO ANOTHER DEVICE");
                        driver.Close();
                        driver.Dispose();
                        return false;
                    }
                }
                if (IsElementPresentWhinTime(By.CssSelector(loginContinueButton), 10))
                {
                    Thread.Sleep(2000);
                    driver.FindElement(By.CssSelector(loginContinueButton)).Click();
                    Thread.Sleep(2000);
                    if (IsElementPresentWhinTime(By.CssSelector(loginContinueButton), 3))
                    {
                        driver.FindElement(By.CssSelector(loginContinueButton)).Click();
                        
                    }
                }
                if (IsElementPresentWhinTime(By.CssSelector(loginContinueButton2), 5))
                {
                    Thread.Sleep(2000);
                    driver.FindElement(By.CssSelector(loginContinueButton2)).Click();
                    Thread.Sleep(2000);
                    if (IsElementPresentWhinTime(By.CssSelector(loginContinueButton2), 3))
                    {
                        driver.FindElement(By.CssSelector(loginContinueButton2)).Click();

                    }
                }
                if (IsElementPresentWhinTime(By.CssSelector(transferIconButtonUnChoosed), 5))
                {
                    Thread.Sleep(5000); 
                    driver.FindElement(By.CssSelector(transferIconButtonUnChoosed)).Click();

                }
                if(IsElementPresentWhinTime(By.CssSelector(utTile), 2))
                {
                    IWebElement webElement = driver.FindElement(By.CssSelector(utTile));
                    Console.WriteLine(webElement.Text);
                }
                if (IsElementPresentWhinTime(By.CssSelector(utLockedMessage), 2))
                {
                    IWebElement webElement = driver.FindElement(By.CssSelector(utLockedMessage));
                    Console.WriteLine(webElement.Text); 
                }
                if (IsElementPresentWhinTime(By.CssSelector(squadButtonUnChoosed), 5))
                {
                    Thread.Sleep(3000);
                    driver.FindElement(By.CssSelector(squadButtonUnChoosed)).Click();
                   
                    if (IsElementPresentWhinTime(By.CssSelector(activeSquad), 5))
                    {
                        Thread.Sleep(3000);
                        driver.FindElement(By.CssSelector(activeSquad)).Click();
                    }
                      

                }
                if (IsElementPresentWhinTime(By.ClassName(playersInfo), 2))
                {
                    var webElements = driver.FindElements(By.ClassName(playersInfo));
                     Console.WriteLine(webElements[0].Text);
                }

                //*[@id="cookieBar"]/div/span[2]/a[2]
                /*
                if (IsElementPresentWhinTime(By.CssSelector("#cookieBar > div > span.cookieBarButtons > a.cookieBarButton.cookieBarConsentButton"), 3))
                    driver.FindElement(By.CssSelector("#cookieBar > div > span.cookieBarButtons > a.cookieBarButton.cookieBarConsentButton")).Click();

                //#cookieBar > div > span.cookieBarButtons > a.cookieBarButton.cookieBarConsentButton
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Prepare for the career you want'])[1]/following::span[1]")).Click();
                ///driver.FindElement(By.XPath("(.//*[@id='cookieBar']/div/span[2]/following::a[2]")).Click();
                if (!IsElementPresentWhinTime(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign in with Google'])[1]/following::span[1]"), 5))
                {
                    Console.WriteLine("failed in  Sign in with Google");
                }
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign in with Google'])[1]/following::span[1]")).Click();
                if (IsElementPresentWhinTime(By.LinkText("+ Add account"), 2))
                    driver.FindElement(By.LinkText("+ Add account")).Click();

                driver.FindElement(By.Id("widget")).Click();
                driver.FindElement(By.Name("email")).Click();
                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(email);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email'])[1]/following::input[2]")).Click();
                if (IsElementPresentWhinTime(By.Name("name"), 2))
                {
                    driver.FindElement(By.Name("name")).Clear();
                    driver.FindElement(By.Name("name")).SendKeys(name);
                    driver.FindElement(By.Name("newPassword")).Click();
                    driver.FindElement(By.Name("newPassword")).Clear();
                    driver.FindElement(By.Name("newPassword")).SendKeys("111111");
                    driver.FindElement(By.Name("passwordAgain")).Click();
                    driver.FindElement(By.Name("passwordAgain")).Clear();
                    driver.FindElement(By.Name("passwordAgain")).SendKeys("111111");
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Confirm password'])[1]/following::button[1]")).Click();


                }
                if (IsElementPresentWhinTime(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email'])[1]/following::input[2]"), 2))
                {
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email'])[1]/following::input[2]")).Click();
                    driver.FindElement(By.Name("password")).Click();
                    driver.FindElement(By.Name("password")).Clear();
                    driver.FindElement(By.Name("password")).SendKeys("111111");
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Password'])[1]/following::button[1]")).Click();
                }

                if (IsElementPresentWhinTime(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Personal details'])[1]/following::div[1]"), 5))
                {
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Personal details'])[1]/following::div[1]")).Click();
                    driver.FindElement(By.Id("form01")).Click();
                    driver.FindElement(By.Id("form01")).Clear();
                    driver.FindElement(By.Id("form01")).SendKeys(name);
                    driver.FindElement(By.Id("last_name")).Click();
                    driver.FindElement(By.Id("last_name")).Clear();
                    driver.FindElement(By.Id("last_name")).SendKeys(lastName);
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Yes, please'])[1]/following::div[2]")).Click();

                    driver.FindElement(By.Id("form01")).SendKeys(Keys.PageDown);
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Yes, please'])[2]/following::div[2]")).Click();
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Yes, please'])[3]/following::div[2]")).Click();
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=concat('Google', \"'\", 's Privacy Policy')])[1]/following::button[1]")).Click();


                }
                if (IsElementPresentWhinTime(By.Id("myg-lesson-topic-header__sidenav-trigger"), 2))
                {
                    driver.FindElement(By.Id("myg-lesson-topic-header__sidenav-trigger")).Click();

                    //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::header[1]")).SendKeys(Keys.PageDown);


                    if (IsElementPresentWhinTime(By.Id("topic-1__skip-exam"), 2))
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("topic-1__skip-exam")));
                        Thread.Sleep(1000);
                        driver.FindElement(By.Id("topic-1__skip-exam")).Click();
                        //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::span[1]")).Click();
                        // driver.FindElement(By.Id("skip-to-exam-dialog__button__take-exam")).Click();
                        //#skip-to-exam-dialog__button__take-exam > span
                        if (IsElementPresentWhinTime(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span"), 3))
                            driver.FindElement(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span")).Click();

                    }
                    if (IsElementPresentWhinTime(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='The increased use of the Internet presents a lot of potential for which types of businesses?'])[1]/following::span[3]"), 2))
                    {
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='The increased use of the Internet presents a lot of potential for which types of businesses?'])[1]/following::span[3]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[1]/following::span[1]")));
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[2]/following::span[1]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[2]/following::span[1]")));

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='B'])[3]/following::span[1]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[3]/following::span[1]")));

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[4]/following::span[2]")).Click();
                        scrollAndClick(By.Id("myg-assessment__submit-button"));
                    }




                }

                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::i[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='My Dashboard'])[1]/following::span[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Make search work for you'])[1]/following::a[1]")).Click();
                if (IsElementPresentWhinTime(By.Id("myg-lesson-topic-header__sidenav-trigger"), 2))
                {
                    driver.FindElement(By.Id("myg-lesson-topic-header__sidenav-trigger")).Click();

                    //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::header[1]")).SendKeys(Keys.PageDown);


                    if (IsElementPresentWhinTime(By.Id("topic-7__skip-exam"), 2))
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("topic-7__skip-exam")));
                        Thread.Sleep(1000);
                        driver.FindElement(By.Id("topic-7__skip-exam")).Click();
                        //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::span[1]")).Click();
                        // driver.FindElement(By.Id("skip-to-exam-dialog__button__take-exam")).Click();
                        //#skip-to-exam-dialog__button__take-exam > span
                        if (IsElementPresentWhinTime(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span"), 3))
                        {
                            Thread.Sleep(1000);
                            driver.FindElement(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span")).Click();
                        }

                    }
                    if (IsElementPresentWhinTime(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[1]/following::label[1]"), 2))
                    {
                        /*   driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[1]/following::label[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='B'])[2]/following::span[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Question 3'])[1]/following::span[3]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[2]/following::span[1]")).Click();

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[1]/following::label[1]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[1]/following::span[1]")));

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='B'])[2]/following::span[1]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[2]/following::span[1]")));

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Question 3'])[1]/following::span[3]")).Click();
                        //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[2]/following::span[1]")).Click();
                        scrollAndClick(By.Id("myg-assessment__submit-button"));
                    }




                }
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::i[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='My Dashboard'])[1]/following::span[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Get noticed locally'])[2]/following::a[1]")).Click();
                if (IsElementPresentWhinTime(By.Id("myg-lesson-topic-header__sidenav-trigger"), 2))
                {
                    driver.FindElement(By.Id("myg-lesson-topic-header__sidenav-trigger")).Click();

                    //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::header[1]")).SendKeys(Keys.PageDown);


                    if (IsElementPresentWhinTime(By.Id("topic-12__skip-exam"), 2))
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("topic-12__skip-exam")));
                        Thread.Sleep(1000);
                        driver.FindElement(By.Id("topic-12__skip-exam")).Click();
                        //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::span[1]")).Click();
                        // driver.FindElement(By.Id("skip-to-exam-dialog__button__take-exam")).Click();
                        //#skip-to-exam-dialog__button__take-exam > span
                        if (IsElementPresentWhinTime(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span"), 3))
                        {
                            Thread.Sleep(1000);
                            driver.FindElement(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span")).Click();
                        }
                    }
                    if (IsElementPresentWhinTime(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[1]/following::span[1]"), 2))
                    {
                        /*   driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::span[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[1]/following::span[2]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Which of the following is an example of a local search?'])[1]/following::span[3]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[3]/following::span[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[4]/following::span[2]")).Click();     
                        // driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::span[1]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[1]/following::span[1]")));
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[1]/following::span[2]")).Click();
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Which of the following is an example of a local search?'])[1]/following::span[3]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[1]/following::span[1]")));

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Question 3'])[1]/following::span[3]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[2]/following::span[1]")));

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[3]/following::span[1]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[3]/following::span[1]")));

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[4]/following::span[2]")).Click();
                        scrollAndClick(By.Id("myg-assessment__submit-button"));
                    }




                }
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::i[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='My Dashboard'])[1]/following::span[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Help people nearby find you online'])[1]/following::a[1]")).Click();
                if (IsElementPresentWhinTime(By.Id("myg-lesson-topic-header__sidenav-trigger"), 2))
                {
                    driver.FindElement(By.Id("myg-lesson-topic-header__sidenav-trigger")).Click();

                    //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::header[1]")).SendKeys(Keys.PageDown);


                    if (IsElementPresentWhinTime(By.Id("topic-13__skip-exam"), 2))
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("topic-13__skip-exam")));
                        Thread.Sleep(1000);
                        driver.FindElement(By.Id("topic-13__skip-exam")).Click();
                        //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::span[1]")).Click();
                        // driver.FindElement(By.Id("skip-to-exam-dialog__button__take-exam")).Click();
                        //#skip-to-exam-dialog__button__take-exam > span
                        if (IsElementPresentWhinTime(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span"), 3))

                        {
                            Thread.Sleep(1000);
                            driver.FindElement(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span")).Click();
                        }

                    }
                    if (IsElementPresentWhinTime(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Which of the following factors help search engines determine if your business is local?'])[1]/following::span[3]"), 2))
                    {


                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Which of the following factors help search engines determine if your business is local?'])[1]/following::span[3]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[1]/following::span[1]")));
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Question 2'])[1]/following::span[3]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[2]/following::span[1]")));
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Which of the following can help you gain visibility in search engines?'])[1]/following::span[3]")).Click();
                        scrollAndClick(By.Id("myg-assessment__submit-button"));
                    }




                }
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::i[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='My Dashboard'])[1]/following::span[1]")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Build your online shop'])[2]/following::a[1]")).Click();
                if (IsElementPresentWhinTime(By.Id("myg-lesson-topic-header__sidenav-trigger"), 2))
                {
                    driver.FindElement(By.Id("myg-lesson-topic-header__sidenav-trigger")).Click();

                    //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::header[1]")).SendKeys(Keys.PageDown);


                    if (IsElementPresentWhinTime(By.Id("topic-22__skip-exam"), 2))
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id("topic-22__skip-exam")));
                        Thread.Sleep(1000);
                        driver.FindElement(By.Id("topic-22__skip-exam")).Click();
                        //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::span[1]")).Click();
                        // driver.FindElement(By.Id("skip-to-exam-dialog__button__take-exam")).Click();
                        //#skip-to-exam-dialog__button__take-exam > span
                        if (IsElementPresentWhinTime(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span"), 3))

                        {
                            Thread.Sleep(1000);
                            driver.FindElement(By.CssSelector("#skip-to-exam-dialog__button__take-exam > span")).Click();
                        }

                    }
                    if (IsElementPresentWhinTime(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='B'])[1]/following::span[1]"), 2))
                    {

                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='B'])[1]/following::span[1]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[1]/following::span[1]")));
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[2]/following::span[2]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[2]/following::span[1]")));
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[3]/following::span[1]")).Click();
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='C'])[3]/following::span[1]")));
                        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A'])[4]/following::span[1]")).Click();


                        scrollAndClick(By.Id("myg-assessment__submit-button"));
                    }
                    Thread.Sleep(5000);
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sign out'])[1]/following::i[1]")).Click();

                    driver.FindElement(By.Id("side-nav__student-dashboard")).Click();

                    ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                    Screenshot screenshot = screenshotDriver.GetScreenshot();
                    screenshot.SaveAsFile(email + ".png");

                }


                driver.Close();
                driver.Dispose();
                 */
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                driver.Close();
                driver.Dispose();
                return false;
            }
           

        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsElementPresentWhinTime(By by ,int timeLimit)
        {
            DateTime start = DateTime.Now;
            TimeSpan span = DateTime.Now - start;
            while(span.TotalSeconds<timeLimit)
            {
                try
                {

                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    span = DateTime.Now - start;
                    Thread.Sleep(100);
                    //return false;
                }
                
            }
            return false;
        }

        private void scrollAndClick(By by)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(by));
            //Thread.Sleep(5000);
            driver.FindElement(by).Click();
        }

    }
}
