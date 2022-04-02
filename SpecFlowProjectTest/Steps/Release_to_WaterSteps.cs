using OpenQA.Selenium.Interactions;
using SpecFlowProjectTest.Drivers;
using SpecFlowProjectTest.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProjectTest.PageObjects;

namespace SpecFlowProjectTest.Steps
{
    [Binding]
    public class Release_to_WaterSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public readonly PageFactory _pageFactory;
        public Release_to_WaterSteps(PageFactory pageFactory) => _pageFactory = pageFactory;

       

        [Given(@"I am on the Assure login page")]
        public void GivenIAmOnTheAssureLoginPage()
        {
            _pageFactory.LoginPage.NavigateToLoginpage();
        }

        [Given(@"I entered the '(.*)' and '(.*)'")]
        public void GivenIEnteredTheAnd(string Username, string Password)
        {
            _pageFactory.LoginPage.Username.SendKeys(Username);
            _pageFactory.LoginPage.Password.SendKeys(Password);
        }


        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            _pageFactory.LoginPage.Login_Button.Click();
        }

        [Then(@"I am able to login")]
        public void ThenIAmAbleToLogin()
        {
            string uri = _pageFactory.LoginPage.GetCurrentUrl();

            Assert.Contains("https://stirling.she-development.net/automation", uri);
        }

        [Then(@"I added first new record")]
        public void ThenIAddedFirstNewRecord()
        {
            //no steps required
        }


        [Then(@"I navigate to module ->Environment ->Release To Water")]
        public void ThenINavigateToModule_Environment_ReleaseToWater()
        {
            _pageFactory.LoginPage.Modules_Dropdown.Click();

            Actions actions = new Actions(_pageFactory.Driver);
            actions.MoveToElement(_pageFactory.LoginPage.Environment_Dropdown)
            .Build()
            .Perform();

            _pageFactory.LoginPage.Release_to_water_Text.Click();
        }


        [Then(@"I click New Record Button")]
        public void ThenIClickNewRecordButton()
        {
            _pageFactory.LoginPage.New_Record_Button.Click();
        }

        [Then(@"I fill in the '(.*)' and '(.*)' field")]
        public void ThenIFillInTheAndField(string date, string description)
        {
            _pageFactory.LoginPage.Description_Field.SendKeys(description);
            _pageFactory.LoginPage.Sample_Date_Field.SendKeys(date);

        }
        [Then(@"I click Save and Close Button")]
        public void ThenIClickSaveAndCloseButton()
        {
            _pageFactory.LoginPage.Save_and_Close_Button.Click();
        }

        [Then(@"I added second new record")]
        public void ThenIAddedSecondNewRecord()
        {
            //no steps are required
        }

        [Then(@"I delete the first record")]
        public void ThenIDeleteTheFirstRecord()
        {
            _pageFactory.LoginPage.Cog_Button.Click();
            _pageFactory.LoginPage.Cog_Delete.Click();
            _pageFactory.LoginPage.Confirm_Button.Click();
        }

        [Then(@"I verify that First record has been deleted")]
        public void ThenIVerifyThatFirstRecordHasBeenDeleted()
        {
            _pageFactory.Driver.Navigate().Refresh();

            try
            {


                Assert.False(_pageFactory.LoginPage.Its_a_test_link.Displayed);
                Assert.False(_pageFactory.LoginPage.Sample_Date_link.Displayed);
                Console.WriteLine(" Test failed");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine(" Test Passed");
            }

        }

        [Then(@"I verify that the second record is still available")]
        public void ThenIVerifyThatTheSecondRecordIsStillAvailable()
        {
            Assert.True(_pageFactory.LoginPage.Results_are_True_Link.Displayed);
            Assert.True(_pageFactory.LoginPage.Date_link.Displayed);
        }

        [Then(@"I Click logout Button")]
        public void ThenIClickLogoutButton()
        {
            _pageFactory.LoginPage.User_Drop_Down.Click();
            _pageFactory.LoginPage.Logout_Button.Click();
        }


    }
}
