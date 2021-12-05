# Currency-Converter-Command

# Harri Technical Assignment

# Code Author
Umer Saleem - Software Engineer


# Pre-requisites
I have used C# as the primary language to get this task done.

Make sure to have installed the following pre-requisites for a development setup

1. Microsoft Visual Studio v17 or above preferably.
2. Install all the C# related libraries when you set the Visual Stiudio.
3. For detailed guide, please follow this link: https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022

# Instructions to setup the project
1. Download and install GitBash.
2. Clone the repository using GitBash.
3. For detailed guide, please follow this link: https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository

# Loading the project
1. Install the following Nuget packages from the visual studio's nuget package manager:
  a. NewtonSoft.Json
  b. CSVHelper
  c. NUnit 

2. Build the application after installing the packages, output should be successful with no errors.
3. Navigate in the folder **CurrencyConverterConsole\bin\Debug\net5.0** and start command prompt.
4. Type **dotnet CurrencyConverterConsole.dll [InputFilePath]**  (Where InputFilePath can be like C:\Users\Dev\Documents\currencies_output.csv) and then press Enter.
5. If currencies_input.csv will be provided it will output currencies_output.csv
6. If currencies_historical_input.csv will be provided it will output currencies_historical_output.csv
7. Output files will be placed in the same path as input files.



