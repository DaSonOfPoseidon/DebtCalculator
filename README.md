This code was created by Jackson Keithley. All un-original code will be referenced at the end, as well as in-line comments. This is a cumulative final project for Mizzou's IT/CS 4400 "C#/.Net Development".

------------------

**DISCLAIMER**

The purpose of this application is to help track debt and inform users. This is not financial advice. 

The math used to calculate the minimum payment on credit cards and non-loan debts is a "universal" formula found below. Some companies use a "floor payment," so the amount owed may be more or less than displayed. Since this data differs by company, credit score, and even different card "tiers", I've decided that the formula below is the best middle ground.

For more information, visit the Chase website in the References Section.

The formula I've used to calculate the minimum monthly Non-Loan payment is: 

((APR / 12) * Debt Amount) + (Debt Amount * 0.02)

The formula I've used to calculate the minimum monthly Loan payment is:

((APR / 12) * Debt Amount) / (1 - (1 + (APR / 12)^-(Number of Payments)))

------------------

**INSTRUCTIONS**

Navigate using the Hamburger Menu on the left side of the Window; if no options are displayed, click on the menu icon (Top left corner, three horizontal lines). Each list item navigates to a new window. 

To access your profile, click the circular icon in the top right corner.

------------------

**REFERENCES**

SingletonSean - "Hamburger Menu/Navigation Drawer" 
https://github.com/SingletonSean/wpf-ui-workshops/tree/master

Chase.com - "How to calculate your minimum credit card payment"
https://www.chase.com/personal/credit-cards/education/basics/how-to-calculate-your-minimum-credit-card-payment

C# Corner - "ToolTips in WPF"
https://www.c-sharpcorner.com/UploadFile/1e050f/tooltip-in-wpf/#:~:text=Basic%20WPF%20ToolTip%20Example,way%20to%20display%20a%20ToolTip.


