# Chihiro's Sushi and Bar

#### By: Sue Roberts, Lilia Krivelyova, Viktoria Zubarieva, Nick Tse

#### This project is a sushi restaurant webpage built using C# and the MVC methodology. Visitors to the site can view the menu, login/out, place orders, and view the order details and history

## Technologies Used

- C#
- .NET 5 SDK
- ASP.NET Core
- HTML
- CSS
- MySQL
- Entity
- Identity

## Description

"Chihiro's Sushi & Bar" is a team week project that models a commercial website for a make-believe restaurant. Visitors are greeted on the home page with images of the restaurant and logo, a slideshow showcasing of some of the food and drinks available, restaurant business hours, and an interactive Google maps API that displays the restaurant's location. At the top of the home page is a nav bar where the user can view the full menu, place an order, or log in. By logging in, the user can view their order history and details such as number of items ordered, subtotal, and total price.

## Setup/Installation Requirements

- _Clone repository from GitHub_
- _Open your terminal and run the command $ git clone https://github.com/vzubarieva/Sushi.Solution_
- _Using the command $ cd Sushi, navigate to the Sushi project directory_
- _Within the Sushi project directory, create a file called appsettings.json_
- _Add the following code to the new appsettings.json file:_
  {
  "ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;database=sushi;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
  }
- _Run the command $ dotnet ef database update_
- _Run the command $ dotnet build_
- _Run the command $ dotnet run_
- _In your web browser, navigate to "http://localhost:5000"_
- _The browser should now display the web application for the user to interact with_

## Known Bugs

- no known bugs

## License

_MIT_

Copyright (c) _2022_ _Sue Roberts, Lilia Krivelyova, Viktoriia Zubarieva, Nick Tse_
