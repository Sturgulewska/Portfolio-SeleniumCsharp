using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace EndToEndTests
{
    public class SeleniumTests

    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Url = "https://lamp.ii.us.edu.pl/~mtdyd/zawody/";
            Assert.IsTrue(driver.WindowHandles.Count > 1);
        }

        [Test]
        public void CheckAddToAdultWithMinimumAge()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2003");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Dorosly"));
        }

        [Test]
        public void CheckAddToAdultWithMaximumAge()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-1957");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Dorosly"));
        }

        [Test]
        public void CheckAddToSernior()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-1956");

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Senior"));
        }

        [Test]
        public void CheckAddToSeniorWithoutDocktor()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-1956");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        }


        [Test]
        public void CheckAddChildWithNotEnoughtAge()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2017");

            var parrentAgrement = driver.FindElement(By.Id("rodzice"));
            parrentAgrement.Click();

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Brak"));
        }

        [Test]
        public void CheckAddToJuniorWithMaximumAge()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2004");

            var parrentAgrement = driver.FindElement(By.Id("rodzice"));
            parrentAgrement.Click();

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Junior"));
        }

        [Test]
        public void CheckAddToJuniorWithMaximumAgeWithoutParrent()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2004");

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("danych"));
        }
        [Test]
        public void CheckAddToJuniorWithMaximumAgeWithoutDocktor()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2004");

            var parrentAgrement = driver.FindElement(By.Id("rodzice"));
            parrentAgrement.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        }

        [Test]
        public void CheckAddToJuniorWithMaximumAgeWithoutDocktorAndParrents()
        {

            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2004");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("danych"));
        }

    [Test]
    public void CheckAddToJuniorWithMinimummAge()
    {
        //arrange
        var name = driver.FindElement(By.Id("inputEmail3"));
        name.Clear();
        name.SendKeys("Anna");

        var lastName = driver.FindElement(By.Id("inputPassword3"));
        lastName.Clear();
        lastName.SendKeys("Sturgulewska");

        var date = driver.FindElement(By.Id("dataU"));
        date.Clear();
        date.SendKeys("28-02-2007");

        var parrentAgrement = driver.FindElement(By.Id("rodzice"));
        parrentAgrement.Click();

        var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
        doctorConfirmation.Click();

        var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
        button.Click();
        driver.SwitchTo().Alert().Accept();
        driver.SwitchTo().Alert().Accept();

        var info = driver.FindElement(By.Id("returnSt"));

        Assert.IsTrue(info.Text.Contains("Junior"));
        //  driver.Url = "https://facebook.com";
    }

    [Test]
    public void CheckAddToJuniorWithMinimummAgeAndWithoutParrentsAndDoctor()
    {
        //arrange
        var name = driver.FindElement(By.Id("inputEmail3"));
        name.Clear();
        name.SendKeys("Anna");

        var lastName = driver.FindElement(By.Id("inputPassword3"));
        lastName.Clear();
        lastName.SendKeys("Sturgulewska");

        var date = driver.FindElement(By.Id("dataU"));
        date.Clear();
        date.SendKeys("28-02-2007");

        var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
        button.Click();
        driver.SwitchTo().Alert().Accept();
        driver.SwitchTo().Alert().Accept();

        var info = driver.FindElement(By.Id("returnSt"));

        Assert.IsTrue(info.Text.Contains("danych"));
        //  driver.Url = "https://facebook.com";
    }
        [Test]
        public void CheckAddToJuniorWithMinimummAgeWithoutParrents()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2007");

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("danych"));
        }

        [Test]
        public void CheckAddToJuniorWithMinimummAgeAndWithoutDocktor()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2007");

            var parrentAgrement = driver.FindElement(By.Id("rodzice"));
            parrentAgrement.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("danych"));
        }


        [Test]
    public void CheckAddToSkrzatWithMinimumAge()
    {
        //arrange
        var name = driver.FindElement(By.Id("inputEmail3"));
        name.Clear();
        name.SendKeys("Anna");

        var lastName = driver.FindElement(By.Id("inputPassword3"));
        lastName.Clear();
        lastName.SendKeys("Sturgulewska");

        var date = driver.FindElement(By.Id("dataU"));
        date.Clear();
        date.SendKeys("28-02-2011");

        var parrentAgrement = driver.FindElement(By.Id("rodzice"));
        parrentAgrement.Click();

        var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
        doctorConfirmation.Click();

        var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
        button.Click();

        driver.SwitchTo().Alert().Accept();
        driver.SwitchTo().Alert().Accept();

        var info = driver.FindElement(By.Id("returnSt"));

        Assert.IsTrue(info.Text.Contains("Skrzat"));
    }

        [Test]
        public void CheckAddToSkrzatWithMinimumAgeAndWithoutParrentsAndDoctor()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2011");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("danych"));
        }

        [Test]
        public void CheckAddToSkrzatWithMinimumAgeAndWithoutDoctor()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2011");

            var parrentAgrement = driver.FindElement(By.Id("rodzice"));
            parrentAgrement.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        
    }
        [Test]
        public void CheckAddToSkrzatWithMinimumAgeAndWithoutParrents()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2011");

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("danych"));

        }

     
        [Test]
    public void CheckAddToSkrzatWithMaximumAge()
    {
        //arrange
        var name = driver.FindElement(By.Id("inputEmail3"));
        name.Clear();
        name.SendKeys("Anna");

        var lastName = driver.FindElement(By.Id("inputPassword3"));
        lastName.Clear();
        lastName.SendKeys("Sturgulewska");

        var date = driver.FindElement(By.Id("dataU"));
        date.Clear();
        date.SendKeys("28-02-2010");

        var parrentAgrement = driver.FindElement(By.Id("rodzice"));
        parrentAgrement.Click();


        var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
        doctorConfirmation.Click();

        var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
        button.Click();

        driver.SwitchTo().Alert().Accept();
        driver.SwitchTo().Alert().Accept();

        var info = driver.FindElement(By.Id("returnSt"));

        Assert.IsTrue(info.Text.Contains("Skrzat"));
    }

        [Test]
        public void CheckAddToSkrzatWithMaximumAgeAndWithoutParrents()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2010");

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("danych"));
        }

        [Test]
        public void CheckAddToSkrzatWithMaximumAgeAndWithoutDoctor()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2010");

            var parrentConfirm = driver.FindElement(By.Id("rodzice"));
            parrentConfirm.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("danych"));
        }

        [Test]
        public void CheckAddToSkrzatWithMaximumAgeAndWithoutParrentsAndDocktor()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2010");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
            // driver.Url = "https://facebook.com";
        }

        [Test]
    public void CheckAddToMlodzikWithMinimumAge()
    {
        //arrange
        var name = driver.FindElement(By.Id("inputEmail3"));
        name.Clear();
        name.SendKeys("Anna");

        var lastName = driver.FindElement(By.Id("inputPassword3"));
        lastName.Clear();
        lastName.SendKeys("Sturgulewska");

        var date = driver.FindElement(By.Id("dataU"));
        date.Clear();
        date.SendKeys("28-02-2009");

        var parrentAgrement = driver.FindElement(By.Id("rodzice"));
        parrentAgrement.Click();

        var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
        doctorConfirmation.Click();

        var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
        button.Click();

        driver.SwitchTo().Alert().Accept();
        driver.SwitchTo().Alert().Accept();

        var info = driver.FindElement(By.Id("returnSt"));

        Assert.IsTrue(info.Text.Contains("Mlodzik"));
    }

        [Test]
        public void CheckAddToMlodzikWithMinimumAgeAndWithoutDocktorAndParents()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2009");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        }

        [Test]
        public void CheckAddToMlodzikWithMinimumAgeAndWithoutParents()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2009");

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        }

        [Test]
        public void CheckAddToMlodzikWithMinimumAgeAndWithoutDocktors()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2009");

            var parrentAgrement = driver.FindElement(By.Id("rodzice"));
            parrentAgrement.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        }

        [Test]
        public void CheckAddToMlodzikWithMaximumAge()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2008");

            var parrentAgrement = driver.FindElement(By.Id("rodzice"));
            parrentAgrement.Click();

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Mlodzik"));
        }


        [Test]
        public void CheckAddToMlodzikWithMaximumAgeAndWithoutDocktorAndParrents()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2008");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        }

        [Test]
        public void CheckAddToMlodzikWithMaximumAgeAndWithoutDocktor()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2008");

            var parrentAgrement = driver.FindElement(By.Id("rodzice"));
            parrentAgrement.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        }


        [Test]
        public void CheckAddToMlodzikWithMaximumAgeAndWithoutParrents()
        {
            //arrange
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2008");

            var doctorConfirmation = driver.FindElement(By.Id("lekarz"));
            doctorConfirmation.Click();

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

            var info = driver.FindElement(By.Id("returnSt"));

            Assert.IsTrue(info.Text.Contains("Blad"));
        }

    [Test]
    public void CheckAddWithoutFirstName()
    {
        var lastName = driver.FindElement(By.Id("inputPassword3"));
        lastName.Clear();
        lastName.SendKeys("Sturgulewska");

        var date = driver.FindElement(By.Id("dataU"));
        date.Clear();
        date.SendKeys("28-02-2003");

        var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
        button.Click();

        Assert.IsTrue(driver.SwitchTo().Alert().Text == "First name must be filled out");

    }

        [Test]
        public void CheckAddWithoutLastName()
        {
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var date = driver.FindElement(By.Id("dataU"));
            date.Clear();
            date.SendKeys("28-02-2003");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            Assert.IsTrue(driver.SwitchTo().Alert().Text == "Nazwisko musi byc wypelnione");

        }

        [Test]
        public void CheckAddWithoutDateName()
        {
            var name = driver.FindElement(By.Id("inputEmail3"));
            name.Clear();
            name.SendKeys("Anna");

            var lastName = driver.FindElement(By.Id("inputPassword3"));
            lastName.Clear();
            lastName.SendKeys("Sturgulewska");

            var button = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/div/button"));
            button.Click();

            Assert.IsTrue(driver.SwitchTo().Alert().Text == "Data urodzenia nie moze byc pusta");

        }
    }
}
