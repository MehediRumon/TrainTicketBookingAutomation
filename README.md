# TrainTicketBookingAutomation
Train Ticket Booking Automation using Req n Roll, Selenium &amp; C#. Follows Feature > Elements > Page > Steps model. Uses appsettings.json for config, Excel for data-driven testing, and hooks for setup/teardown.

# Test Automation Framework with Req n Roll

This is a robust BDD-style test automation framework using **C#**, **Selenium WebDriver**, and **Req n Roll**. It follows a clean, structured model for scalable UI testing, designed for flexibility and maintainability.

---

## 🔧 Framework Architecture

- **Elements**: All locators for UI components
- **Page**: WebDriver logic like clicks, sends, waits
- **Steps**: Bindings between Gherkin scenarios and page methods
- **Hooks**: Common setup/teardown (Before/AfterScenario)
- **Helpers**: Reusable utility functions
- **Data**: Excel files for data-driven testing

---

## 🚀 Features

- 🧪 **BDD Testing** with Req n Roll (`[Scenario]`, `[Given]`, `[When]`, `[Then]`)
- 🗂️ **Data-Driven** testing with Excel
- ⚙️ **Configurable appsettings.json** (URLs, credentials, headless mode)
- 🧼 **Hooks** for login, cleanup, logging, and screenshots
- 📦 Lightweight and clean folder structure
- 📊 Test logs and output supported via console or file

---

## 📁 appsettings.json Example

```json
{
  "BaseUrl": "https://example.com",
  "Username": "demo",
  "Password": "pass123",
  "Headless": true
}

Technologies Used
C#

Selenium WebDriver

Req n Roll (BDD Framework)

ExcelDataReader

Newtonsoft.Json

xUnit

How to Run
Clone this repo
git clone

Open with Visual Studio

Add your test data in /Data/TestData.xlsx

Update appsettings.json

Run tests
