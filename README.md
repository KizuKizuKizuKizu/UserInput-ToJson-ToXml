# 🧠 WinForms JSON → XML Demo
(a.k.a. “What am I even doing?”)

Yes, this is exactly the sort of tiny, self-contained disaster you need when you're learning.
It takes your textboxes, turns the contents into JSON, then converts that JSON into XML because apparently
we enjoy two-step suffering.

This repo intentionally keeps things small so you can poke around, break stuff, and (maybe) understand
how the pieces fit together.

## 🧩 What this actually does

Short version:

- You type stuff into a WinForms form (`UserInputJsonToXml`).
- The form builds a JSON object and POSTs it to a local Azure Function in this repo (`HostBuilderFuncApp`).
- The Function returns an XML representation of that JSON.
- The WinForms app shows the XML and pretends it all went according to plan.

Files of interest:

- `UserInputJsonToXml/` — the WinForms app (Form1 builds JSON and talks HTTP).
- `HostBuilderFuncApp/` — the Azure Function that maps JSON → XML and logs the request.

## 🛠 What you’ll learn (accidentally)

- Making UI controls cooperate (txt boxes, buttons, progress bar).
- Serializing to JSON with Newtonsoft.Json (still alive, somehow).
- Using async/await and HttpClient without deadlocking your app.
- A tiny Azure Function with a request-logging helper you’ll appreciate when things break.

## Architecture (because diagrams calm people)

```text
WinForms (UserInputJsonToXml) ---> POST JSON ---> HostBuilderFuncApp (JsonToXmlFunction)
       ^                                                  |
       |                                                  v
       <-------------------- XML response ------------------>
```

## Quick tour of the features (read this while sipping something caffeinated)

### WinForms Client (`UserInputJsonToXml`)

- Controls used (in `Form1`): `txtCustomerName`, `textOrderId`, `txtAmount`, `txtShippingCity`, `txtResponse`, `progressBar1`.
- The form builds a `JObject` (Newtonsoft) and keeps two handy fields:
  - `_lastJson` — last thing you sent
  - `_lastXml` — last thing the function sent back
- Submit button (`Submit_btn_Click`):
  - Builds the JSON payload from the textboxes
  - Updates `progressBar1` (looks busy: 0 → 40 → 70 → 100)
  - Posts JSON with a static `HttpClient` to the local function URL hardcoded in the form: `http://localhost:7215/api/JsonToXmlFunction`
  - Reads the response as text into `_lastXml`, then displays it in `txtResponse`
  - If anything explodes, the error message goes into `txtResponse` so you can cry into the logs

- `Show Json` / `Show Xml` buttons display `_lastJson` / `_lastXml` without making network calls. Because we’re merciful.

### Azure Function (`HostBuilderFuncApp`)

- Function name: `JsonToXmlFunction` (decorated with `[Function("JsonToXmlFunction")]`).
- Trigger: HTTP POST only (`[HttpTrigger(AuthorizationLevel.Function, "post")]`).
  - Reminder: `AuthorizationLevel.Function` requires a function key in Azure. Locally, Functions Core Tools usually let you call it without fuss.
- Behavior:
  - Uses `HttpRequestDataExtensions.LogRequestAsync` to log method, URL, headers and the body (pretty-prints JSON when possible).
  - Validates the body is not empty and parses JSON.
  - Maps the JSON into an `XElement` XML shape: Order (id attribute), Customer/Name, Shipping/City, Amount and a MappedAtUtc node.
  - Returns `200 OK` with `Content-Type: application/xml` and the XML payload.

### Logging helper (`HttpRequestDataExtensions.LogRequestAsync`)

- Located in `HostBuilderFuncApp/LogRequestAsync.cs`.
- Logs method, URL, all headers, and the body (reads stream with `leaveOpen: true`).
- Tries to pretty-print JSON for readability and returns the body string for the function to parse.

## How to run it (the simple plan)

Requirements:

- .NET 8.0 SDK (the projects target net8.0)
- Azure Functions Core Tools (for local function execution) — optional if you prefer Visual Studio debugging
- Visual Studio (recommended) or any .NET-savvy IDE

Steps:

1. Clone the repo:

```powershell
git clone https://github.com/KizuKizuKizuKizu/UserInput-ToJson-ToXml.git
```

2. Open `UserInput-ToJson-ToXml.sln` in Visual Studio.

3. Start the Azure Function first. Either:

- Debug `HostBuilderFuncApp` from Visual Studio (easy), or
- From a terminal in `HostBuilderFuncApp/`, run:

```powershell
func start
```

When running the WinForms client in this repo, the function URL the app calls is:

```text
http://localhost:7215/api/JsonToXmlFunction
```

4. Run the WinForms app (`UserInputJsonToXml`) from Visual Studio.
5. Fill the fields and hit Submit. Watch the progress bar pretend it’s helpful. The returned XML appears in `txtResponse`.

Notes about auth & deployment:

- The function trigger is `AuthorizationLevel.Function`. In Azure you must send a function key with requests or change the trigger level to `Anonymous` (not recommended for production).

## Try it — example data (copy & paste)

Sample JSON the client sends:

```json
{
  "customer": { "name": "Jane Doe" },
  "order": { "orderId": "12345", "amount": "49.99" },
  "shipping": { "city": "Seattle" }
}
```

Expected XML response (approx):

```xml
<Order id="12345">
  <Customer>
    <Name>Jane Doe</Name>
  </Customer>
  <Shipping>
    <City>Seattle</City>
  </Shipping>
  <Amount>49.99</Amount>
  <MappedAtUtc>2025-...Z</MappedAtUtc>
</Order>
```

## Quick notes (aka things you’ll trip over)

- The WinForms client hardcodes the function URL to `http://localhost:7215/api/JsonToXmlFunction`. Change it in `Form1.cs` if you run the function on a different port.
- The solution builds with a few nullable warnings — harmless for this demo but worth fixing if you turn this into a real app.

---

If you want, I’ll add a tiny PowerShell `Invoke-JsonToXml` script so you can hit the function from the terminal without opening the GUI. Want that?
