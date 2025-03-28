William Neal AmplifyAutomation QA Example for Interview.


Alright so basic overview, I am doing a small short demo of some test automation for Amplify 
I made an NUnit 3 test project 

_______________________________________________________________________________
In my console I used the following commands

Install-Package Selenium.WebDriver - This is grabbing selenium

Install-Package Selenium.WebDriver.ChromeDriver - This is my actual web driver
________________________________________________________________________________

Install-Package SpecFlow.NUnit
Install-Package SpecFlow.Tools.MsBuild.Generation

This is for the gherkin I intend to use later

_________________________________________________________________________________

Install-Package NUnit3TestAdapter

This is just an adapter so the project will run

_________________________________________________________________________________

Alright cool looks like we are set up here. Console is showing everything installed just fine.

Next piece I did was build out my folders, I am doing a simple
Drivers/Features/Locators/SD's and Utils set up.
This is just a sample not a full blow automation set up

_________________________________________________________________________________

Tried to do commit but ran into some issues with git

Built out git ignore .txt but still was getting error:

Git failed with a fatal error.
error: open(".vs/Amplify.NETQA/FileContentIndex/39ac97b9-e9d3-41e0-be22-815128ee29aa.vsidx"): Permission denied
fatal: Unable to process path .vs/Amplify.NETQA/FileContentIndex/39ac97b9-e9d3-41e0-be22-815128ee29aa.vsidx 

Decided to migrate to github desktop to help mitigate issue

_________________________________________________________________________________

Github desktop helped briefly but ultimately doesn't integrate well with 2022 community. works much better on enterprise for some reason

_________________________________________________________________________________

Alright spending some time throwing together a quick config file, my first step definitions page, a data helper and some wait
helpers so I dont need to throw thread.sleeps everywhere

_________________________________________________________________________________

Alright couple build issues, first I didnt close the brackets in Data Helper, easy fix.

Also in my BasePageSteps.cs is giving my problems for this:

        public void GreenStartStickerIsVisible()
        {
            GreenStartSticker.IsVisible = true;
        }

Some kind of issue with IsVisible.

Yeah I messed up I have been using playwright/Python for too long now and forgot symantics. IsVisible is for Pytest/Playwright

.Displayed is for selenium and C#. Symantics and language can be easily mixed up. 

_________________________________________________________________________________

Alright another build issue. 

The name 'ExpectedConditions' does not exist in the current context 

For my DataHelper page, seems like a simple nuget package problem. 

DotNetSeleniumExtras.WaitHelpers seems to have made the build pass

_________________________________________________________________________________

Had a small config issue where I had thrown in a nonsense URL before adding in my baseURL. 

Test ran with success !

__________________________________________________________________________________

Wanted to add a couple more steps and buttons, but also noticed something else. I completely forgot to add a
hook for the tear down after the test is done.