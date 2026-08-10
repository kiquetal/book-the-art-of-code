# The Art of Code — F# Companion

This directory contains a functional-first, Domain-Driven Design (DDD) companion implementation of the concepts and exercises explored in the book **"The Art of Code" by Sandrine Banas**.

While the book's official exercises are written in Java, this project ports those ideas to F# to explore how functional programming paradigms make domain designs safer, cleaner, and more expressive.

---

## Core Philosophy

* **Type-First Domain Modeling:** We use F#'s Algebraic Data Types (Records and Discriminated Unions) to ensure that invalid domain states are unrepresentable at compile time.
* **Pure Workflows:** Rather than utilizing exception handling or returning `null` values for exceptional paths, our core domain logic uses pure, predictable pipelines that return type-safe `Result` unions.

---

## Getting Started

### Prerequisites
Make sure you have the .NET SDK installed (compatible with .NET 10.0+).

```bash
dotnet --version
```

### Build the Solution
To build the solution and verify type safety:

```bash
dotnet build ArtOfCode.sln
```

### Run Specific Chapters
You can target and execute the demo for specific chapters by passing them as arguments to the runner application:

* **To run Chapter 1:**
  ```bash
  dotnet run --project ArtOfCode.Runner/ArtOfCode.Runner.fsproj -- chapter1
  ```
  *(Or simply use `1` as the argument)*

* **To run Chapter 2:**
  ```bash
  dotnet run --project ArtOfCode.Runner/ArtOfCode.Runner.fsproj -- chapter2
  ```
  *(Or simply use `2` as the argument)*

---

## Directory Structure

* **`ArtOfCode.Domain/`**: The core business logic library containing our models and pure workflows.
  * [`Chapter1.fs`](ArtOfCode.Domain/Chapter1.fs): Port of the Chapter I concepts, demonstrating algebraic pricing details and exception-free flows.
* **`ArtOfCode.Runner/`**: An executable console application demonstrating the core domain logic in action.
  * [`Program.fs`](ArtOfCode.Runner/Program.fs): Sets up mock domain scenarios (valid, discounted, missing values, etc.) and executes them.

---

## Adding New Chapters

When porting a new chapter's concepts:

1. Create a new `.fs` file under `ArtOfCode.Domain/` (e.g., `Chapter2.fs`).
2. Add the file to your compile list inside [`ArtOfCode.Domain.fsproj`](ArtOfCode.Domain/ArtOfCode.Domain.fsproj):
   ```xml
   <ItemGroup>
     <Compile Include="Chapter1.fs" />
     <Compile Include="Chapter2.fs" />
   </ItemGroup>
   ```
   *(Note: Order matters in F#. File compilation order matches the order listed in the `.fsproj`.)*
