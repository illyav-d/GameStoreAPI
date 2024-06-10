# GameStoreAPI
 My final project of my course, in collaboration with a great team.
 I will add some documentation in how to set up this project.
 
 In this application we highlight the knowledge of our .NET and C# Syntax in the backend using Async API calls that are seperated in layers, meaning that if you would move this into a mobile UI, 90% of the code is already done.
We also highlight our knowledge of SOLID principles, by applying them as much as we can where possible. This makes the code more readable, clean and open for extension.

In the frontend we used Angular, NodeJS (nmp), Bootstrap and TypeScript to handle the logic and UI of our website.

I would like to thank my partners in this project and would recommend you check them out here

Gilles
https://github.com/JustGilloo - https://justgilloo.github.io

Bart
https://github.com/Bart-Nobels - https://bart-nobels.github.io/

# Program Setup
If you want to try this project you need, visual studio code, visual studio enterprise,npm/ng and sql server management studio.
All of these are free to download in the links below.

S(QL)SMS - 
https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

VS Enterprise - 
https://visualstudio.microsoft.com/vs/enterprise

VS Code - 
https://code.visualstudio.com

npm/ng instructions - 
https://docs.npmjs.com/downloading-and-installing-node-js-and-npm

Once set up, you can clone in your terminal using the git clone git@github.com:illyav-d/GameStoreAPI.git in your terminal application of choice or download the zip directly.

# First Boot Setup
Open the solution file (GameStoreAPI.sln) in the upper folder and go to the Package Manager Console (Search in the top, look for the Package Manager Console if you can not find it at the bottom of the IDE).
First we generate our Database in SSMS by using the Update-Database.

Now the Database is generated, you can run the API by pressing Run at the top.

Now you want to open the UI in Visual Code Basic by right clicking the GameStoreAPI folder and open with code. Or open Visual Code Basic directly and open the folder.
Important!: I recommend opening the API Folder that is in the same folder as the Solution File.

Once in Visual Studio Basic, open a new terminal and type npm install, this will install the required node files.
Now you can type ng serve in the same terminal and open the host it throws.

Hurray, you have now setup the application!

# Using the application and configuring it.

By default we show the user functionality, if you do want to change this, you can do so by going to the services folder in Visual Studio Basic and moving the comments tags (//) from User to Admin.
By doing so you will move the rights of the API Call Functionality from User to Admin allowing you to modify the records inside the DB from the Website.

# Support
In case there are problems feel free to contact me and I will see what I can do to help!
