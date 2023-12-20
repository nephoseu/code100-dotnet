# Try Out .Net on Daytona

## Things to try

Once you have this sample opened, you'll be able to work with it like you would locally.

Some things to try:

1. **Restore Packages:** When notified by the C# extension to install packages, click Restore to trigger the process from inside the container! You can also execute `dotnet restore` command in a terminal.

2. **Edit:**
   - Open `Program.cs`
   - Try adding some code and check out the language features.
   - Make a spelling mistake and notice it is detected. The [Code Spell Checker](https://marketplace.visualstudio.com/items?itemName=streetsidesoftware.code-spell-checker) extension was automatically installed because it is referenced in `.devcontainer/devcontainer.json`.
   - Also notice that the [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) extension is installed. Tools are installed in the `mcr.microsoft.com/devcontainers/dotnet` image and Dev Container settings and metadata are automatically picked up from [image labels](https://containers.dev/implementors/reference/#labels).


4. **Build, Run, and Debug:**
   - Open `Program.cs`
   - Add a breakpoint (e.g. on line 16).
   - Press <kbd>F5</kbd> to launch the app in the container.
   - Navigate to the weather endpoint, for example, [http://localhost:5000/paris/weather](http://localhost:5000/paris/weather).
   - Once the breakpoint is hit, try hovering over variables, examining locals, and more.   
   - Continue (<kbd>F5</kbd>). You can connect to the server in the container by either: 
      - Clicking on `Open in Browser` in the notification telling you: `Your service running on port 5000 is available`.
      - Clicking the globe icon in the 'Ports' view. The 'Ports' view gives you an organized table of your forwarded ports, and you can access it with the command **Ports: Focus on Ports View**.
    - Notice port 5000 in the 'Ports' view is labeled "Hello Remote World." In `devcontainer.json`, you can set `"portsAttributes"`, such as a label for your forwarded ports and the action to be taken when the port is autoforwarded.

   > **Note:** In Dev Containers, you can access your app at `http://localhost:5000` in a local browser. But in a browser-based Codespace, you must click the link from the notification or the `Ports` view so that the service handles port forwarding in the browser and generates the correct URL.
