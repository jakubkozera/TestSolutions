# Script to generate comprehensive test solutions for C# Dev Tools Test Explorer validation
# This creates the complete structure described in testsolutions.md

$rootPath = "c:\Users\Jakub\source\repos\TestSolutions"

Write-Host "Creating comprehensive test solution structure..." -ForegroundColor Green

# Function to create NUnit solution
function Create-NUnitSolution {
    Write-Host "Creating NUnit .NET 8 solution..." -ForegroundColor Cyan
    
    $solutionPath = "$rootPath\NET8\NUnit.Tests"
    New-Item -ItemType Directory -Path $solutionPath -Force | Out-Null
    Set-Location $solutionPath
    
    # Create solution
    dotnet new sln -n NUnit.Tests
    
    # Create projects
    dotnet new nunit -n NUnit.BasicTests
    dotnet new nunit -n NUnit.ParameterizedTests
    dotnet new nunit -n NUnit.CategoryTests
    dotnet new nunit -n NUnit.FixtureTests
    
    # Add to solution
    dotnet sln add NUnit.BasicTests\NUnit.BasicTests.csproj
    dotnet sln add NUnit.ParameterizedTests\NUnit.ParameterizedTests.csproj
    dotnet sln add NUnit.CategoryTests\NUnit.CategoryTests.csproj
    dotnet sln add NUnit.FixtureTests\NUnit.FixtureTests.csproj
    
    Write-Host "NUnit solution created" -ForegroundColor Green
}

# Function to create MSTest solution
function Create-MSTestSolution {
    Write-Host "Creating MSTest .NET 8 solution..." -ForegroundColor Cyan
    
    $solutionPath = "$rootPath\NET8\MSTest.Tests"
    New-Item -ItemType Directory -Path $solutionPath -Force | Out-Null
    Set-Location $solutionPath
    
    # Create solution
    dotnet new sln -n MSTest.Tests
    
    # Create projects
    dotnet new mstest -n MSTest.BasicTests
    dotnet new mstest -n MSTest.DataDrivenTests
    dotnet new mstest -n MSTest.CategoryTests
    dotnet new mstest -n MSTest.LifecycleTests
    
    # Add to solution
    dotnet sln add MSTest.BasicTests\MSTest.BasicTests.csproj
    dotnet sln add MSTest.DataDrivenTests\MSTest.DataDrivenTests.csproj
    dotnet sln add MSTest.CategoryTests\MSTest.CategoryTests.csproj
    dotnet sln add MSTest.LifecycleTests\MSTest.LifecycleTests.csproj
    
    Write-Host "MSTest solution created" -ForegroundColor Green
}

# Function to create MTP solutions (NET10)
function Create-MTPSolutions {
    Write-Host "Creating .NET 10 MTP solutions..." -ForegroundColor Cyan
    
    # XUnit MTP
    $solutionPath = "$rootPath\NET10-MTP\XUnit.MTP.Tests"
    New-Item -ItemType Directory -Path $solutionPath -Force | Out-Null
    Set-Location $solutionPath
    
    dotnet new sln -n XUnit.MTP.Tests
    dotnet new xunit -n XUnit.MTP.BasicTests --framework net10.0
    dotnet new xunit -n XUnit.MTP.ParameterizedTests --framework net10.0
    dotnet new xunit -n XUnit.MTP.ComplexTests --framework net10.0
    dotnet new xunit -n XUnit.MTP.TraitTests --framework net10.0
    
    dotnet sln add XUnit.MTP.BasicTests\XUnit.MTP.BasicTests.csproj
    dotnet sln add XUnit.MTP.ParameterizedTests\XUnit.MTP.ParameterizedTests.csproj
    dotnet sln add XUnit.MTP.ComplexTests\XUnit.MTP.ComplexTests.csproj
    dotnet sln add XUnit.MTP.TraitTests\XUnit.MTP.TraitTests.csproj
    
    # NUnit MTP
    $solutionPath = "$rootPath\NET10-MTP\NUnit.MTP.Tests"
    New-Item -ItemType Directory -Path $solutionPath -Force | Out-Null
    Set-Location $solutionPath
    
    dotnet new sln -n NUnit.MTP.Tests
    dotnet new nunit -n NUnit.MTP.BasicTests --framework net10.0
    dotnet new nunit -n NUnit.MTP.ParameterizedTests --framework net10.0
    dotnet new nunit -n NUnit.MTP.CategoryTests --framework net10.0
    dotnet new nunit -n NUnit.MTP.FixtureTests --framework net10.0
    
    dotnet sln add NUnit.MTP.BasicTests\NUnit.MTP.BasicTests.csproj
    dotnet sln add NUnit.MTP.ParameterizedTests\NUnit.MTP.ParameterizedTests.csproj
    dotnet sln add NUnit.MTP.CategoryTests\NUnit.MTP.CategoryTests.csproj
    dotnet sln add NUnit.MTP.FixtureTests\NUnit.MTP.FixtureTests.csproj
    
    # MSTest MTP
    $solutionPath = "$rootPath\NET10-MTP\MSTest.MTP.Tests"
    New-Item -ItemType Directory -Path $solutionPath -Force | Out-Null
    Set-Location $solutionPath
    
    dotnet new sln -n MSTest.MTP.Tests
    dotnet new mstest -n MSTest.MTP.BasicTests --framework net10.0
    dotnet new mstest -n MSTest.MTP.DataDrivenTests --framework net10.0
    dotnet new mstest -n MSTest.MTP.CategoryTests --framework net10.0
    dotnet new mstest -n MSTest.MTP.LifecycleTests --framework net10.0
    
    dotnet sln add MSTest.MTP.BasicTests\MSTest.MTP.BasicTests.csproj
    dotnet sln add MSTest.MTP.DataDrivenTests\MSTest.MTP.DataDrivenTests.csproj
    dotnet sln add MSTest.MTP.CategoryTests\MSTest.MTP.CategoryTests.csproj
    dotnet sln add MSTest.MTP.LifecycleTests\MSTest.MTP.LifecycleTests.csproj
    
    Write-Host "MTP solutions created" -ForegroundColor Green
}

# Execute
Create-NUnitSolution
Create-MSTestSolution
Create-MTPSolutions

Set-Location $rootPath
Write-Host "`nAll test solutions created successfully!" -ForegroundColor Green
Write-Host "Total: 6 solutions with 24 projects" -ForegroundColor Yellow
